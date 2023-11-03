using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage2_0Context _context;

        public ParkedVehiclesController(Garage2_0Context context)
        {
            _context = context;
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
        public async Task<ActionResult> Parking(ParkedVehicle model)
        {
            if(ModelState.IsValid)
            {
          
                //Implementation for parking vehicle
                _context.ParkedVehicles.Add(model);
                await _context.SaveChangesAsync();

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
        public async Task<ActionResult> Retrieving(string registrationNumber)
        {
            var vehicle = await _context.ParkedVehicles.FirstOrDefaultAsync(v => v.RegistrationNumber == registrationNumber);
            if(vehicle != null)
            {
                _context.ParkedVehicles.Remove(vehicle);
                await _context.SaveChangesAsync();

                TempData["Message"] = "vehicle retrived successfuly!";

            }
            else
            {
                TempData["Message"] = "vehicle not found!";
            }
            return RedirectToAction("Overview");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vehicle = _context.ParkedVehicles.Find(id);
            return View(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ParkedVehicle model)
        {
            var existingVehicle = await _context.ParkedVehicles.FindAsync(model.Id);
            if (existingVehicle != null)
            {
                existingVehicle.VehicleType = model.VehicleType;
                existingVehicle.Color = model.Color;
                existingVehicle.Brand = model.Brand;
                existingVehicle.Model = model.Model;
                existingVehicle.NumberOfWheels = model.NumberOfWheels;
                await _context.SaveChangesAsync();

                TempData["Message"] = "Vehicle edited successfully!";
                return RedirectToAction("Overview");
            }
            else
            {
                TempData["Message"] = "Vehicle not found!";
                return View(model);
            }
        }

        public async Task<ActionResult> Overview(string sortOrder, string searchString)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TimeSortParam = sortOrder == "time" ? "time_desc" : "time";

            var vehicles = from v in _context.ParkedVehicles
                           select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.RegistrationNumber.Contains(searchString));
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

            var vehiclesList = await vehicles.ToListAsync();

            return View(vehiclesList);
        }

    }
}
