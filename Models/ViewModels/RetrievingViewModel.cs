using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModels
{
    public class RetrievingViewModel
    {
        [RegularExpression(@"^[A-Z]{3}\d{3}$", ErrorMessage = "Please enter a valid registration number with 3 uppercase letters and 3 numbers.")]
        public string? RegistrationNumber { get; set; }
    }
}
