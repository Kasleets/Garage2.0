using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models; // Add missing using statement to resolve build error
using Garage2._0.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage2._0.Models.ViewModels;
using System.Linq.Expressions;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage2_0Context _context;

        public ParkedVehiclesController(Garage2_0Context context)
        {
            _context = context;
        }

       // // Add controller for Home
       // public IActionResult Home()
       // {
       //     return View();
       // }

       // [HttpGet]
       // // Add controller for Index
       // public async Task<IActionResult> Index()
       // {
       //     var vehicles = await _context.ParkedVehicles.ToListAsync();

       //     var model = new IndexViewModel
       //     {
       //         ParkedVehicles = vehicles,
       //         VehicleTypes = GetVehicleType(vehicles)
       //     };


       //     return View(model);
       // }

       //// Add function to get vehicle type
       // private static List<SelectListItem> GetVehicleType(List<ParkedVehicle> vehicles)
       // {
          
       //         return vehicles.Select(v => v.VehicleType)
       //                                        .Distinct()
       //                                        .Select(g => new SelectListItem
       //                                        {
       //                                            Text = g.ToString(),
       //                                            Value = g.ToString()
       //                                        })
       //                                        .ToList();
            
       // }

       // // Add controller for ParkVehicle
       // public IActionResult ParkVehicle()
       // {
       //     return View();
       // }





        public ActionResult Parking()
        {
            //var vehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>().Select(v => new SelectListItem
            //{
            //    Text = v.ToString(),
            //    Value = ((int)v).ToString()
            //});
            //ViewBag.VehicleTypes = new SelectList(vehicleTypes, "Value", "Text");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Parking(ParkedVehicle viewModel)// change model to viewModel because there is error.
        {
            if(ModelState.IsValid)
            {
                //Implementation for parking vehicle
                _context.ParkedVehicles.Add(viewModel);
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
            return View(viewModel);
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
        public async Task<ActionResult> Edit(ParkedVehicle editedModel) // Renamed the parameter as it was same as Park method ( build error) 
        {
            var existingVehicle = await _context.ParkedVehicles.FindAsync(editedModel.Id);
            if (existingVehicle != null)
            {
                existingVehicle.VehicleType = editedModel.VehicleType;
                existingVehicle.Color = editedModel.Color;
                existingVehicle.Brand = editedModel.Brand;
                existingVehicle.Model = editedModel.Model;
                existingVehicle.NumberOfWheels = editedModel.NumberOfWheels;
                await _context.SaveChangesAsync();

                TempData["Message"] = "Vehicle edited successfully!";
                return RedirectToAction("Overview");
            }
            else
            {
                TempData["Message"] = "Vehicle not found!";
                return View(editedModel);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Overview(string sortOrder, string searchString)
        {
            // Create the view model and populate sorting options
            var viewModel = new VehicleOverviewViewModel
            {
                SearchString = searchString,
                SortOrder = sortOrder,
                SortOrderItems = new List<SelectListItem>
        {
            new SelectListItem { Text = "Registration Number (Asc)", Value = "registration_asc" },
            new SelectListItem { Text = "Registration Number (Desc)", Value = "registration_desc" },
            new SelectListItem { Text = "Arrival Time (Asc)", Value = "time_asc" },
            new SelectListItem { Text = "Arrival Time (Desc)", Value = "time_desc" }
        }
            };

            // Query to retrieve data and apply sorting/search
            var vehicles = from v in _context.ParkedVehicles select v;

            if (!string.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.RegistrationNumber.Contains(searchString));
            }

            // Apply sorting based on the selected option
            vehicles = viewModel.SortOrder switch
            {
                "registration_desc" => vehicles.OrderByDescending(v => v.RegistrationNumber),
                "time" => vehicles.OrderBy(v => v.ArrivalTime),
                "time_desc" => vehicles.OrderByDescending(v => v.ArrivalTime),
                _ => vehicles.OrderBy(v => v.RegistrationNumber), // Default sorting
            };

            viewModel.ParkedVehicles = await vehicles.ToListAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)// Added Detail for Detail page
        {
            var vehicle = await _context.ParkedVehicles.FindAsync(id);  
            if(vehicle == null)
            {
                return NotFound();// Return 404 not found if vehicle is not found
            }

            var viewModel = new VehicleDetailedViewModel
            {
                Vehicle = vehicle,
            };

            return View(viewModel);
        }



    }
}
