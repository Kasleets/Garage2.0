using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.Entities
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime ArrivalTime { get; set; }
        public ParkedVehicle() 
        { 
            ArrivalTime = DateTime.Now;
        }

        // Note: Should we use constructor for ArrivalTime? Or should we use a method? 
    }
}
