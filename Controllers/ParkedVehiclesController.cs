using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage2._0.Data;
using Garage2._0.Models.Entities;
using Garage2._0.Services; 

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        //Dependency injection of repository and service through constructor
        private readonly IParkedVehicleRepository _repository;
        private readonly IParkingService _service;

        public ParkedVehiclesController(IParkedVehicleRepository repository, IParkingService service)
        {
            _repository = repository;
            _service = service;
        }

        public ActionResult Parking()
        {
            var vehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            });
            ViewBag.VehicleTypes = new SelectList(vehicleTypes, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Parking(ParkedVehicle model) //Implements Add park vehicle
        {
            if (ModelState.IsValid)
            {
                _service.ParkVehicle(model);//use service to park

                TempData["Message"] = "Vehicle Parked successfully!";
                return RedirectToAction("Overview");
            }

            var vehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            });
            ViewBag.VehicleTypes = new SelectList(vehicleTypes, "Value", "Text");
            return View(model);
        }

        [HttpGet]
        public ActionResult Retrieving()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Retrieving(string registrationNumber) //Implements Retrieve vehicle 
        {
            var vehicle = await _repository.GetByRegistrationNumberAsync(registrationNumber);
            if (vehicle != null)
            {
                _service.UnparkVehicle(vehicle.Id);//use service to unpark

                TempData["Message"] = "Vehicle retrieved successfully!";
            }
            else
            {
                TempData["Message"] = "Vehicle not found!";
            }
            return RedirectToAction("Overview");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vehicle = _repository.GetById(id);
            return View(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ParkedVehicle model) //Implements Update in vehicle
        {
            if (ModelState.IsValid)
            {
                var updated = _service.UpdateVehicle(model);

                if (updated != null)
                {
                    TempData["Message"] = "Vehicle edited successfully!";
                    return RedirectToAction("Overview");
                }
                else
                {
                    TempData["Message"] = "Vehicle not found!";
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Overview(string sortOrder, string searchString) //Implements sort and search 
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TimeSortParam = sortOrder == "time" ? "time_desc" : "time";

            var vehicles = _repository.GetAllParkedVehicles();

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = _repository.SearchVehicles(searchString);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(v => v.RegistrationNumber);
                    break;
                case "time":
                    vehicles = vehicles.OrderBy(v => v.ArrivalTime);
                    break;
                case "time_desc":
                    vehicles = vehicles.OrderByDescending(v => v.ArrivalTime);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.RegistrationNumber);
                    break;
            }
            return View(vehicles);
        }
    }
}
