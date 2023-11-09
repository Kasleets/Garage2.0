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

        public VehicleType VehicleType { get; set; }

        //public TimeSpan TotalParkingTime { 
        //    get
        //    {
        //        string totalFormattedTime = string.Empty;
        //        if (TotalParkingTime.Days > 0)
        //        {
        //            totalFormattedTime += $"{TotalParkingTime.Days:D1} days : ";
        //        }

        //        totalFormattedTime += $"{TotalParkingTime.Hours:D1} hours : {TotalParkingTime.Minutes:D2} minutes : {TotalParkingTime.Seconds:D2} seconds";

        //        return totalFormattedTime;
        //    }

        // Method to calculate and format the parking time for a single vehicle
        public string GetFormattedParkingTime(ParkedVehicle vehicle)
        {
            var parkingTime = DateTime.Now - vehicle.ArrivalTime;
            if (parkingTime.Days > 0)
            {
                return $"est. {parkingTime.Days:D1} days";
            }
            else
            {
                return $"est. {parkingTime.Hours:D1} hours";
            }
        }


    }
}
