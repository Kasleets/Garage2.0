namespace Garage2._0.Models.Entities
{
    // Enum for vehicle types. 
    public enum VehicleType
    {
        Car,
        Motorcycle,
        Bus,
        Truck
    }

    // Note: redundant code?
    public class VehicleViewModel
    {
        public VehicleType SelectedVehicleType { get; set; }
    }
}
