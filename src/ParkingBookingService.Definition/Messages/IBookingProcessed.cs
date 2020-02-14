using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingBookingService.Definition.Messages
{
    public interface IBookingProcessed
    {
        string Message { get; } // confirmation, or faliure. Could be send via e-mail or signalR
        
    }
}
