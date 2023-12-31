﻿using Microsoft.EntityFrameworkCore;
using Garage2._0.Models.Entities;

namespace Garage2._0.Data
{
    public class Garage2_0Context : DbContext
    {
        public Garage2_0Context (DbContextOptions<Garage2_0Context> options)
            : base(options)
        {
        }

        public DbSet<ParkedVehicle> ParkedVehicles { get; set; } = null!;

        
    }
}
