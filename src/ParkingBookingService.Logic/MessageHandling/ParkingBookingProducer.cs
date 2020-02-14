using MassTransit;
using ParkingBookingService.Definition.MessageHandling;
using ParkingBookingService.Definition.Messages;
using ParkingBookingService.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingBookingService.Logic.MessageHandling
{
    public class ParkingBookingProducer : IParkingBookingProducer
    {
        private readonly IRequestClient<IBookingRequested> _requestClient;

        public ParkingBookingProducer(IRequestClient<IBookingRequested> requestClient)
        {
            _requestClient = requestClient;
        }

        public async Task SendRequest(BookingModel bookingModel)
        {
            _requestClient.Create(new { BookingModel = bookingModel });
        }

    }
}
