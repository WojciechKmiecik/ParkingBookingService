using ParkingBookingService.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBookingService.Definition.DataServices
{
    public interface IBookingDataService
    {
        public Task<List<BookingModel>> GetAll();
        public Task<List<BookingModel>> GetAllBetweenDates(DateTime startDateUtc, DateTime endDateUtc);
        public Task<BookingModel> SaveBooking(BookingModel model);
    }
}
