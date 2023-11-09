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

        public ActionResult Parking()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Parking(ParkedVehicle viewModel) // changed model to viewModel because there is error.
        {
            if(ModelState.IsValid)
            {
                bool isUnique = !await _context.ParkedVehicles.AnyAsync(p => p.RegistrationNumber == viewModel.RegistrationNumber);

                if (!isUnique)
                {
                    ModelState.AddModelError("RegistrationNumber", "This registration number is already in use.");
                }
                else 
                { 
                    //Implementation for parking vehicle
                    _context.ParkedVehicles.Add(viewModel);
                    await _context.SaveChangesAsync();

                    // Todo: Display to the user that the vehicle was parked successfully. Right now it immediately jumps to overview.
                    TempData["Message"] = "Vehicle Parked successfully!";
                    return RedirectToAction("Overview");
                }
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
                        DepartureTime = DateTime.Now,
                        ParkingTime = (DateTime.Now.Subtract(vehicle.ArrivalTime))
                    };
                    // Format the parking time
                    receiptInfo.ParkingTime = TimeSpan.Parse(receiptInfo.ParkingTime.ToString("hh\\:mm\\:ss"));

                    // Remove the vehicle from the database
                    _context.ParkedVehicles.Remove(vehicle);
                    await _context.SaveChangesAsync();

                    // Store the receipt info in TempData
                    TempData["Receipt"] = JsonConvert.SerializeObject(receiptInfo);

                    // Redirect to the Receipt action with the vehicle's ID
                    return RedirectToAction("Receipt");

                    //Method from before receipt
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
        public async Task<ActionResult> Edit(ParkedVehicle editedModel) // Renamed the parameter as it was same as Park method (build error) 
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
                vehicles = vehicles.Where(v => v.RegistrationNumber.Contains(searchString) || v.Brand.Contains(searchString));
            }

            // Apply sorting based on the selected option
            switch (viewModel.SortOrder)
            {
                case "registration_desc":
                    vehicles = vehicles.OrderByDescending(v => v.RegistrationNumber);
                    break;
                case "time":
                    vehicles = vehicles.OrderBy(v => v.ArrivalTime);
                    break;
                case "time_desc":
                    vehicles = vehicles.OrderByDescending(v => v.ArrivalTime);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.ArrivalTime);
                    break;
            }

            viewModel.ParkedVehicles = await vehicles.ToListAsync();
            viewModel.VehicleType = viewModel.ParkedVehicles.FirstOrDefault()?.VehicleType ?? default(VehicleType);
            //viewModel.TotalParkingTime = DateTime.Now - (viewModel.ParkedVehicles.FirstOrDefault()?.ArrivalTime ?? DateTime.Now);
            viewModel.GetFormattedParkingTime(viewModel.ParkedVehicles.FirstOrDefault());

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id) // Added Detail for Detail page
        {
            var vehicle = await _context.ParkedVehicles.FindAsync(id);  
            if(vehicle == null)
            {
                return NotFound(); // Return 404 not found if vehicle is not found
            }

            var viewModel = new VehicleDetailedViewModel
            {
                Vehicle = vehicle,
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
