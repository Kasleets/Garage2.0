using Garage2._0.Models.Entities;

namespace Garage2._0.Services
{
    public interface IParkingService
    {
        IEnumerable<ParkedVehicle> GetAllParkedVehicles();
        ParkedVehicle GetParkedVehicleById(int id);
        void ParkVehicle(ParkedVehicle vehicle);
        void RetrieveVehicle(int id);   
        void EditVehicle(ParkedVehicle vehicle);
        IEnumerable<ParkedVehicle> Search(string searchString);
    }
}


/*
Encapsulates business logic
The service layer can call the repository methods to interact with the data layer (database).
This structure ensures that the presentation layer (controllers) and the data layer (repositories) are not directly dependent on each other
seperation of concern 
 */