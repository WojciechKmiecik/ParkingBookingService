using ParkingBookingService.Dal.Context;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using ParkingBookingService.Definition.Models;
using System.Threading.Tasks;
using ParkingBookingService.Dal.Mapper;
using Microsoft.EntityFrameworkCore;
using ParkingBookingService.Definition.DataServices;

namespace ParkingBookingService.Dal.DataServices
{
    internal class BookingDataService : IBookingDataService
    {
        private readonly ParkingBookingContext _ctx;

        public BookingDataService(ParkingBookingContext parkingBookingContext)
        {
            _ctx = parkingBookingContext;
        }

        public async Task<List<BookingModel>> GetAll()
        {
            return await _ctx.Bookings.Select(x => x.Map()).ToListAsync();
        }

        public async Task<List<BookingModel>> GetAllBetweenDates(DateTime startDateUtc, DateTime endDateUtc)
        {
            return await _ctx.Bookings.Where(entry => entry.StartDateUtc <= startDateUtc && endDateUtc <= entry.EndDateUtc).Select(x => x.Map()).ToListAsync();
        }

        public async Task<BookingModel> SaveBooking(BookingModel model)
        {
            var entity = model.Map();

            try
            {
                await _ctx.Bookings.AddAsync(entity);
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateException dbu)
            {
                // log

            }
            return entity.Map();
        }



    }
}
