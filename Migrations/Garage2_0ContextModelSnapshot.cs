﻿// <auto-generated />
using System;
using Garage2._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage2._0.Migrations
{
    [DbContext(typeof(Garage2_0Context))]
    partial class Garage2_0ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Garage2._0.Models.Entities.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWheels")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkedVehicles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2022, 10, 15, 11, 45, 0, 0, DateTimeKind.Unspecified),
                            Brand = "Honda",
                            Color = "Blue",
                            Model = "Civic",
                            NumberOfWheels = 4,
                            RegistrationNumber = "DEF456",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2022, 10, 15, 12, 15, 0, 0, DateTimeKind.Unspecified),
                            Brand = "Ford",
                            Color = "Silver",
                            Model = "Focus",
                            NumberOfWheels = 4,
                            RegistrationNumber = "GHI789",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 4,
                            ArrivalTime = new DateTime(2022, 10, 15, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            Brand = "Harley-Davidson",
                            Color = "Black",
                            Model = "Sportster",
                            NumberOfWheels = 2,
                            RegistrationNumber = "MOT123",
                            VehicleType = 1
                        },
                        new
                        {
                            Id = 5,
                            ArrivalTime = new DateTime(2022, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Brand = "Kawasaki",
                            Color = "White",
                            Model = "Ninja",
                            NumberOfWheels = 2,
                            RegistrationNumber = "MOT456",
                            VehicleType = 1
                        },
                        new
                        {
                            Id = 6,
                            ArrivalTime = new DateTime(2022, 10, 15, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            Brand = "Volvo",
                            Color = "Yellow",
                            Model = "B7R",
                            NumberOfWheels = 6,
                            RegistrationNumber = "BUS001",
                            VehicleType = 2
                        },
                        new
                        {
                            Id = 7,
                            ArrivalTime = new DateTime(2022, 10, 15, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Brand = "Mercedes-Benz",
                            Color = "Green",
                            Model = "Tourismo",
                            NumberOfWheels = 6,
                            RegistrationNumber = "BUS002",
                            VehicleType = 2
                        },
                        new
                        {
                            Id = 8,
                            ArrivalTime = new DateTime(2022, 10, 15, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            Brand = "Scania",
                            Color = "Brown",
                            Model = "R730",
                            NumberOfWheels = 10,
                            RegistrationNumber = "TRK001",
                            VehicleType = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
