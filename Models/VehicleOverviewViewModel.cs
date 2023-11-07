namespace Garage2._0.Models
{
    public class VehicleOverviewViewModel
    {

            public IEnumerable<ParkedVehicle> Vehicles { get; set; }
            public string SortOrder { get; set; }
            public string SearchString { get; set; }
        
    }
}

