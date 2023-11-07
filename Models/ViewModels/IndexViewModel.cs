using Garage2._0.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage2._0.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; set; } = new List<ParkedVehicle>();
        public IEnumerable<SelectListItem> VehicleTypes { get; set; } = new List<SelectListItem>();
        public string? RegistrationNumber { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}
