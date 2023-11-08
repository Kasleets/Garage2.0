using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models; // Add missing using statement to resolve build error
using Garage2._0.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Garage2._0.Models.ViewModels;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage2_0Context _context;

        public ParkedVehiclesController(Garage2_0Context context)
        {
            _context = context;
        }
        #region snippet_Index old bloat
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

        #endregion



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

                // Todo: Display to the user that the vehicle was parked successfully. Right now it immediately jumps to overview.
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
        public async Task<ActionResult> Retrieving(RetrievingViewModel viewModel)
        {
            if (ModelState.IsValid)// Check if there are any validation errors
            {
                // Retrieve the vehicle based on the registration number
                var vehicle = await _context.ParkedVehicles.FirstOrDefaultAsync(v => v.RegistrationNumber == viewModel.RegistrationNumber);

                if (vehicle != null)
                {

                    // Receipt view
                    var receiptInfo = new ReceiptViewModel
                    {
                        VehicleId = vehicle.Id,
                        RegistrationNumber = vehicle.RegistrationNumber,
                        ArrivalTime = vehicle.ArrivalTime,
                        DepartureTime = DateTime.Now
                    };

                    // Remove the vehicle from the database
                    _context.ParkedVehicles.Remove(vehicle);
                    await _context.SaveChangesAsync();

                    // Store the receipt info in TempData
                    TempData["Receipt"] = JsonConvert.SerializeObject(receiptInfo);

                    // Redirect to the Receipt action with the vehicle's ID
                    return RedirectToAction("Receipt");

                    //Commenting to add receipt question to the user //Kasleet
                    // Added receipt question to the user //Kasleet
                    //TempData["Message"] = "Vehicle retrieved successfully! Would you like a receipt?";

                    //return RedirectToAction("Overview");
                }
                else
                {
                    // If vehicle is not found
                    ModelState.AddModelError("RegistrationNumber", "Vehicle not found.");
                }
            }

            // If ModelState is not valid or if vehicle is not found, return the view with errors
            //return View("Retrieving", viewModel);
            return View(viewModel);
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
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TimeSortParam = sortOrder == "time" ? "time_desc" : "time";

            var vehicles = from v in _context.ParkedVehicles
                           select v;

            if (!string.IsNullOrEmpty(searchString))
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

            // Update the ViewModel class name to resolve build error
            var viewModel = new VehicleOverviewViewModel
            {
                ParkedVehicles = vehiclesList,
                NameSortParam = sortOrder,  
                TimeSortParam = sortOrder == "time" ? "time_desc" : "time",  
                SearchString = searchString
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Receipt()
        {
            if (TempData["Receipt"] is string receiptJson)
            {
                var receiptInfo = JsonConvert.DeserializeObject<ReceiptViewModel>(receiptJson);
                return View(receiptInfo);
            }
            else
            {
                // Handle the case when TempData does not contain receipt information
                return RedirectToAction("Error"); //Double check routing
            }
        }


    }
}
