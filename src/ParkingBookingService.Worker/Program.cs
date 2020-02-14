using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParkingBookingService.Definition;
using ParkingBookingService.Definition.MessageHandling;
using ParkingBookingService.Definition.Messages;
using ParkingBookingService.Logic;
using ParkingBookingService.Logic.MessageHandling;

namespace ParkingBookingService.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ParkingBookingWorker>();
                    services.AddHostedService<StatisticWorker>();

                    services.ConfigureLogicServices();

                    services.AddScoped<IParkingBookingConsumer, ParkingBookingConsumer>();

                    services.AddScoped<ParkingBookingConsumer>();
                    services.AddMassTransit(x =>
                    {
                        // add the consumer to the container
                        x.AddConsumer<ParkingBookingConsumer>();
                    });

                    services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        var host = cfg.Host("localhost", "/", h => { });

                        cfg.UseExtensionsLogging(provider.GetService<ILoggerFactory>());

                        cfg.ReceiveEndpoint(Constants.QueueNames.ParkingBookingQueue, e =>
                        {
                            e.PrefetchCount = 16;
                            e.UseMessageRetry(x => x.Interval(2, 100));
                            e.Consumer<ParkingBookingConsumer>(provider);


                            EndpointConvention.Map<IBookingRequested>(e.InputAddress);
                        });
                    }));

                });
    }
}
