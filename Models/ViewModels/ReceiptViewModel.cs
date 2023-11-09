namespace Garage2._0.Models.ViewModels
{
    public class ReceiptViewModel
    {
#nullable disable
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan ParkingTime { get; set; }
        public decimal CostPerHour { get; set; }
        public string FormattedTotalCost
        {
            get
            {
                // Calculate the total cost
                decimal totalCost = (decimal)ParkingTime.TotalHours * CostPerHour;

                // Round the total cost to the nearest whole number
                totalCost = Math.Round(totalCost);

                // Format the total cost with the currency symbol
                string formattedCost = $"{totalCost:C0}";

                return formattedCost;
            }
        }

        // Formatted parking time to display proper decimal places
        public string FormattedParkingTime 
        { 
            get 
            { 
                string formattedTime = string.Empty;
                if (ParkingTime.Days > 0)
                {
                    formattedTime += $"{ParkingTime.Days:D1} days : {ParkingTime.Hours:D1} hours : {ParkingTime.Minutes:D2} minutes : {ParkingTime.Seconds:D2} seconds";
                }

                formattedTime += $"{ParkingTime.Hours:D1} hours : {ParkingTime.Minutes:D2} minutes : {ParkingTime.Seconds:D2} seconds";
                
                return formattedTime;
            } 
        }
    }
}
