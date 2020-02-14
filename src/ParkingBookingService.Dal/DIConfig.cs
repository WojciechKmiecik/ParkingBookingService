using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParkingBookingService.Dal.Context;
using ParkingBookingService.Dal.DataServices;
using ParkingBookingService.Definition.DataServices;

namespace ParkingBookingService.Dal
{
    public static class DIConfig
    {
        public static void ConfigureDalServices(this IServiceCollection services)
        {
            services.AddDbContext<ParkingBookingContext>(opt => opt.UseInMemoryDatabase("ParkingBooking"));
            //(Alternative: DbContext using a SQL Server provider
            //services.AddDbContext<ParkingBookingContext>(c =>
            //{
            // c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //
            //});

            services.AddScoped<ICarDataService, CarDataService>();
            services.AddScoped<IGarageDataService, GarageDataService>();
            services.AddScoped<IBookingDataService, BookingDataService>();
        }
    }
}

