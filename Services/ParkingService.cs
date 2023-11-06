using Garage2._0.Data;
using Garage2._0.Models.Entities;

namespace Garage2._0.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkedVehicleRepository _repository; // The repository is used for data access to parked vehicle

        public ParkingService (IParkedVehicleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ParkedVehicle> GetAllParkedVehicles()
        {
            return _repository.GetAllParkedVehicles();
        }

        public ParkedVehicle GetParkedVehicleById(int id)
        {
            return _repository.GetById(id);
        }

        public void ParkVehicle (ParkedVehicle vehicle)
        {
            _repository.Add(vehicle);
        }

        public void RetrieveVehicle(int id)
        {
            _repository.Remove(id);
        }

        public void EditVehicle(ParkedVehicle vehicle)
        {
            _repository.Update(vehicle);
        }

        public IEnumerale<ParkedVehicle> Search(string searchString)
        {
            return _repository.Search(searchString);
        }
}
