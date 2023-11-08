using System.Collections.Generic;
using Garage2._0.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage2._0.Models.ViewModels
{
#nullable disable
    public class VehicleOverviewViewModel // Updated to correct name to solve build error
    {
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; set; }

        //New properties for sorting
        public string SortOrder { get; set; }// property to hold selected sorting option

        public List<SelectListItem> SortOrderItems { get; set; }// List of sorting options as SelectListItem

        public string SearchString { get; set; }
    }
}
