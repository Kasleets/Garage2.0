using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.Entities
{
    public class ParkedVehicle
    {
#nullable disable

        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle type is required.")]
        public VehicleType VehicleType { get; set; }

        // Added conversion to uppercase for registration number //Kasleet
        private string _registrationNumber;
        [Required]
        [MaxLength(10)]
        [RegularExpression("^[A-Z0-9]*$", ErrorMessage = "Registration number should be uppercase alphanumeric.")]
        public string RegistrationNumber { 
            
            get => _registrationNumber; 
            
            set => _registrationNumber = value.ToUpper(); }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        // Double check before final submission if the int.MaxValue is good to keep
        [Range(0, int.MaxValue, ErrorMessage = "Number of wheels must be non-negative.")]
        public int NumberOfWheels { get; set; }

        public DateTime ArrivalTime { get; set; }

        public ParkedVehicle() => ArrivalTime = DateTime.Now;
    }
}
