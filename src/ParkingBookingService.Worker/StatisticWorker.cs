using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ParkingBookingService.Worker
{
    public class StatisticWorker : BackgroundService
    {
        private readonly ILogger<ParkingBookingWorker> _logger;

        public StatisticWorker(ILogger<ParkingBookingWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            for (; ; )
            {
                // smarter scheudler like  Hangfire or Quartz.NET
                // for now - check every 30 sec if there are any messages

                Thread.Sleep(60 * 60 * 1000);

                // algorithm here
                // check last running date 
                // - if null then calculate for whole period
                // - if not null, then take current values (min, max, count, avg), and calculate only from last date
                // - for each uncalculated entry - check in one run
                // - store new values, so controller can fetchTehem

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                } 
            }
        }
    }
}
