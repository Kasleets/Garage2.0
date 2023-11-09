// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Event listener for the "Pickup" button
document.addEventListener('DOMContentLoaded', function () {
    const pickupButton = document.querySelector('#pickupButton');


    if (pickupButton) {
        pickupButton.addEventListener('click', function () {
            const registrationNumber = document.getElementById('RegistrationNumber').value;

            alert('You have successfully picked up the vehicle with registration number: ' + registrationNumber);
        });
    }
});

// Event listener for form submission
document.addEventListener('DOMContentLoaded', function () {
    const parkingForm = document.querySelector('#parkingForm');

    if (parkingForm) {
        parkingForm.addEventListener('submit', function (event) {
            event.preventDefault(); // Prevent the default form submission

            const regNo = document.getElementById('RegistrationNumber').value
            // get vehicle type
            const vehicleTypeElement = document.getElementById('VehicleType');
            const selectedIndex = vehicleTypeElement.selectedIndex;
            const selectedOption = vehicleTypeElement.options[selectedIndex];
            const vehicleType = selectedOption.text;

            alert(`Your ${vehicleType} with registration number ${regNo} is successfully parked!`);
        });
    }
});

