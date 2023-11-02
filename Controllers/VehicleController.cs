using Microsoft.AspNetCore.Mvc;

namespace Garage2._0.Controllers
{
    public class VehicleController : Controller
    {

        // Note: Should we stick to all async functions or mix async with sync?
        // Todo: Architecture placeholder. For Controller

        [HttpGet]
        public async Task<IActionResult> Park()
        {
            // TODO: Display the form for parking a vehicle to the user.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Park(string vehicleType, string registrationNumber, string color, string brand, string model, int numberOfWheels)
        {
            // TODO: Add vehicle to garage logic here.
            return RedirectToAction("ParkedVehicles");
        }

        [HttpGet]
        public async Task<IActionResult> Unpark()
        {
            // TODO: Display the form for unpark logic here.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUnpark(int id)
        {
            // TODO: Add unpark logic here.
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Receipt(int id)
        {
            // TODO: Add receipt logic here.
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            // TODO: Display the search form logic here.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchResults(string searchProperty)
        {
            // TODO: Process the search and add search logic result here.
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ParkedVehicles(string sortOrder)
        {
            // TODO: Display the parked vehicles, make optionally sorted order e.g. Ascending order.
            return View();
        }

        

    }
}
