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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParkedVehicle>().HasData(
                new ParkedVehicle
                {
                    Id = 2,
                    RegistrationNumber = "DEF456",
                    VehicleType = VehicleType.Car,
                    ArrivalTime = DateTime.Parse("2022-10-15 11:45"),
                    Color = "Blue",
                    Brand = "Honda",
                    Model = "Civic",
                    NumberOfWheels = 4
                },
                new ParkedVehicle
                {
                    Id = 3,
                    RegistrationNumber = "GHI789",
                    VehicleType = VehicleType.Car,
                    ArrivalTime = DateTime.Parse("2022-10-15 12:15"),
                    Color = "Silver",
                    Brand = "Ford",
                    Model = "Focus",
                    NumberOfWheels = 4
                },

                // Seed data for Motorcycles
                new ParkedVehicle
                {
                    Id = 4,
                    RegistrationNumber = "MOT123",
                    VehicleType = VehicleType.Motorcycle,
                    ArrivalTime = DateTime.Parse("2022-10-15 13:30"),
                    Color = "Black",
                    Brand = "Harley-Davidson",
                    Model = "Sportster",
                    NumberOfWheels = 2
                },
                new ParkedVehicle
                {
                    Id = 5,
                    RegistrationNumber = "MOT456",
                    VehicleType = VehicleType.Motorcycle,
                    ArrivalTime = DateTime.Parse("2022-10-15 14:00"),
                    Color = "White",
                    Brand = "Kawasaki",
                    Model = "Ninja",
                    NumberOfWheels = 2
                },

                // Seed data for Buses
                new ParkedVehicle
                {
                    Id = 6,
                    RegistrationNumber = "BUS001",
                    VehicleType = VehicleType.Bus,
                    ArrivalTime = DateTime.Parse("2022-10-15 15:30"),
                    Color = "Yellow",
                    Brand = "Volvo",
                    Model = "B7R",
                    NumberOfWheels = 6
                },
                new ParkedVehicle
                {
                    Id = 7,
                    RegistrationNumber = "BUS002",
                    VehicleType = VehicleType.Bus,
                    ArrivalTime = DateTime.Parse("2022-10-15 16:00"),
                    Color = "Green",
                    Brand = "Mercedes-Benz",
                    Model = "Tourismo",
                    NumberOfWheels = 6
                },

                // Seed data for Trucks
                new ParkedVehicle
                {
                    Id = 8,
                    RegistrationNumber = "TRK001",
                    VehicleType = VehicleType.Truck,
                    ArrivalTime = DateTime.Parse("2022-10-15 17:30"),
                    Color = "Brown",
                    Brand = "Scania",
                    Model = "R730",
                    NumberOfWheels = 10
                }

            );
        }

    }
}
