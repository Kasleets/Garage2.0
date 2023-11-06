using Garage2._0.Models.Entities;

namespace Garage2._0.Data
{
    public class ParkedVehicleRepository : IParkedVehicleRepository
    {

        private readonly Garage2_0Context _context;

        public ParkedVehicleRepository(Garage2_0Context context)
        {
            _context = context;
        }

        public IEnumerable<ParkedVehicle> GetAllParkedVehicles() //Get all parked vehicle from DB
        {
            return _context.ParkedVehicles.ToList();
        }

        public ParkedVehicle GetById(int id)//Get parked vehicle by ID
        {
            return _context.ParkedVehicles.Find(id);
        }

        public void Add(ParkedVehicle vehicle) // Add vehicle to DB
        {
            _context.ParkedVehicles.Add(vehicle);
        }

        public void Remove(int id)//Remove vehicle from DB
        {
            var vehicle = _context.ParkedVehicles.Find(id);
            if (vehicle != null)
            {
                _context.ParkedVehicles.Remove(vehicle);
            }
        }

        public void Update(ParkedVehicle vehicle)//Update existing vehicle in DB
        {
            _context.ParkedVehicles.Update(vehicle);
        }

        public IEnumerable<ParkedVehicle> Search(string searchString)//search parked vehicle based on search string
        {
            return _context.ParkedVehicles.Where(v => v.RegistrationNumber.Contains(searchString))
                .ToList();
        }

    }
}