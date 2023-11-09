using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.ViewModels
{
    public class RetrievingViewModel
    {
        private string? _registrationNumber;
        [MaxLength(10)]
        [RegularExpression("^[A-Z0-9]*$", ErrorMessage = "A valid registration number is required.")]
        public string? RegistrationNumber
        { 
            get => _registrationNumber; 
        
            set => _registrationNumber = value?.ToUpper();
        }
    }
}
