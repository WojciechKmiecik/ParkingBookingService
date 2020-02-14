using ParkingBookingService.Dal.DataModel;
using ParkingBookingService.Definition.Models;
using ParkingBookingService.WebApi.WebModels;
using System;

namespace ParkingBookingService.Dal.Mapper
{
    internal static class BookingMapper
    {
        // intentionally not using Automapper.
        public static BookingModel Map(this BookingRequestWebModel bookingR)
        {
            var bookingM = new BookingModel();

            if (bookingR != null)
            {
                var utcnow = DateTime.UtcNow;
                bookingM.StartDateUtc = bookingR.StartDateUtc ?? utcnow;
                bookingM.EndDateUtc = bookingR.EndDateUtc ?? utcnow.AddHours(1); // add defaults
                bookingM.GarageName = bookingR.GarageName;
                bookingM.CarLicencePlate = bookingR.LicencePlate;
            }

            return bookingM;
        }

    }
}
