using System.Collections.Generic;
using Garage2._0.Models.Entities;

namespace Garage2._0.Models
{
    public class VehicleOverviewViewModel // Updated to correct name to solve build error
    {
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; set; }
        public string NameSortParam { get; set; }
        public string TimeSortParam { get; set; }
        public string SearchString { get; set; }
    }
}
