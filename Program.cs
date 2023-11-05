using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
namespace Garage2._0
{
    // Initial test commit to github.
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'TempGarageContext' not found.")));

            builder.Services.AddScoped<IParkedVehicleRepository, ParkedVehicleRepository>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Garage2_0Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Garage2_0Context") ?? throw new InvalidOperationException("Connection string 'Garage2_0Context' not found.")));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}