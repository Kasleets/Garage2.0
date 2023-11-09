using Garage2._0.Models.Entities;

namespace Garage2._0.Models.ViewModels
{
#nullable disable
    public class VehicleDetailedViewModel
    {
        public ParkedVehicle Vehicle { get; set; }
        public string GetFormattedParkingTime(ParkedVehicle vehicle)
        {
            var parkingTime = DateTime.Now - vehicle.ArrivalTime;
            string formattedTime = string.Empty;
            if (parkingTime.Days > 0)
            {
                return formattedTime += $"{parkingTime.Days:D1} days: {parkingTime.Hours:D1} hours : {parkingTime.Minutes:D2} minutes : {parkingTime.Seconds:D2} seconds";
                
            }
            else
            {
                formattedTime += $"{parkingTime.Hours:D1} hours : {parkingTime.Minutes:D2} minutes : {parkingTime.Seconds:D2} seconds";
                return formattedTime;
            }
        }
    }
}
