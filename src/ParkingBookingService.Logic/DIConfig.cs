using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingBookingService.Dal;
using ParkingBookingService.Definition.MessageHandling;
using ParkingBookingService.Definition.Services;
using ParkingBookingService.Logic.MessageHandling;
using ParkingBookingService.Logic.Messaging;
using ParkingBookingService.Logic.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingBookingService.Logic
{
    public static class DIConfig
    {
        public static void ConfigureLogicServices(this IServiceCollection services)
        {
            services.ConfigureDalServices();

            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IParkingBookingProducer, ParkingBookingProducer>();
            services.AddSingleton<IHostedService, BusService>();
        }
    }
}
