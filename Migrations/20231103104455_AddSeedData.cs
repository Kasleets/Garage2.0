using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Garage2._0.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VehicleType",
                table: "ParkedVehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ParkedVehicles",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "Model", "NumberOfWheels", "RegistrationNumber", "VehicleType" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 10, 15, 11, 45, 0, 0, DateTimeKind.Unspecified), "Honda", "Blue", "Civic", 4, "DEF456", 0 },
                    { 3, new DateTime(2022, 10, 15, 12, 15, 0, 0, DateTimeKind.Unspecified), "Ford", "Silver", "Focus", 4, "GHI789", 0 },
                    { 4, new DateTime(2022, 10, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), "Harley-Davidson", "Black", "Sportster", 2, "MOT123", 1 },
                    { 5, new DateTime(2022, 10, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), "Kawasaki", "White", "Ninja", 2, "MOT456", 1 },
                    { 6, new DateTime(2022, 10, 15, 15, 30, 0, 0, DateTimeKind.Unspecified), "Volvo", "Yellow", "B7R", 6, "BUS001", 2 },
                    { 7, new DateTime(2022, 10, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), "Mercedes-Benz", "Green", "Tourismo", 6, "BUS002", 2 },
                    { 8, new DateTime(2022, 10, 15, 17, 30, 0, 0, DateTimeKind.Unspecified), "Scania", "Brown", "R730", 10, "TRK001", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkedVehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkedVehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParkedVehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ParkedVehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ParkedVehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "ParkedVehicles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
