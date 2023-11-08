namespace Garage2._0.Models.ViewModels
{
    public class ReceiptViewModel
    {
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan ParkingTime { get; set; }
    }
}
