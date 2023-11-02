using Garage2._0.Models.Entities;

namespace Garage2._0.Data
{
    public interface IParkedVehicleRepository
    {
        // Todo: Architecture placeholder. Interface for the repository.
        // Data access layer. The repository is the only class that can access the database.
        // CRUD operations. Create, Read, Update, Delete.

        IEnumerable<ParkedVehicle> GetAllParkedVehicles();
        ParkedVehicle GetById(int id); // For the details button.
        void Add(ParkedVehicle vehicle); // For the park button.
        void Remove(int id); // For the unpark button.
        void Update(ParkedVehicle vehicle); // For the edit button.
        void Search(string searchString); // For the search button.
        
    }
}
