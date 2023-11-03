using Garage2._0.Models.Entities;

namespace Garage2._0.Data
{
    public class ParkedVehicleRepository : IParkedVehicleRepository
    {
        // Todo: Architecture placeholder. Repository. Implementation of the interface.

        private readonly Garage2_0Context _context;
        public ParkedVehicleRepository(Garage2_0Context context)
        {
            _context = context;
        }

        public void Add(ParkedVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkedVehicle> GetAllParkedVehicles()
        {
            return _context.ParkedVehicles.ToList();
        }

        public ParkedVehicle GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ParkedVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void Search(string searchString)
        {
            throw new NotImplementedException();
        }

    }
}