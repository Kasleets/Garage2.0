using Microsoft.EntityFrameworkCore;
using Garage2._0.Models;
using Garage2._0.Models.Entities;

namespace Garage2._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Architecture placeholder. Entity Framework Core. DbContext.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }


    }
}
