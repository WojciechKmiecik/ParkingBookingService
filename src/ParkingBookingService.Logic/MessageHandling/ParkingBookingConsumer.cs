using MassTransit;
using ParkingBookingService.Definition.MessageHandling;
using ParkingBookingService.Definition.Messages;
using ParkingBookingService.Definition.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBookingService.Logic.MessageHandling
{
    public class ParkingBookingConsumer :
        IConsumer<IBookingRequested>, IParkingBookingConsumer
    {
        private readonly IBookingService _bookingService;

        public ParkingBookingConsumer(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task Consume(ConsumeContext<IBookingRequested> context)
        {
            var serviceResponse = await _bookingService.PostNewBooking(context.Message.BookingModel);

            await context.RespondAsync<IBookingProcessed>(new
            {
                Message = serviceResponse
            });
            // respond or send mail or use signalR. 

        }
    }
}
