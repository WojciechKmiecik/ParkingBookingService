using ParkingBookingService.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingBookingService.Definition.Messages
{
    public interface IBookingRequested
    {
        BookingModel BookingModel { get; set; }
    }
}
