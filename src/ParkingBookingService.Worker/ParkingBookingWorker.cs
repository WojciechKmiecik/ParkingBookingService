using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ParkingBookingService.Worker
{
    public class ParkingBookingWorker : BackgroundService
    {
        private readonly ILogger<ParkingBookingWorker> _logger;

        public ParkingBookingWorker(ILogger<ParkingBookingWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            for (; ; )
            {
                // smarter scheudler like  Hangfire or Quartz.NET
                // for now - check every 30 if there are any messages
                Thread.Sleep(30 * 1000);

                // pickup order

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                } 
            }
        }
    }
}
