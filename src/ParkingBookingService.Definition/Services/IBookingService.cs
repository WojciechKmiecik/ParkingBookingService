using ParkingBookingService.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBookingService.Definition.Services
{
    public interface IBookingService
    {
        public Task<string> PostNewBooking(BookingModel bookingModel);
    }
}
