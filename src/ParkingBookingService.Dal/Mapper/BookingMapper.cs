using ParkingBookingService.Dal.DataModel;
using ParkingBookingService.Definition.Models;

namespace ParkingBookingService.Dal.Mapper
{
    internal static class BookingMapper
    {
        // intentionally not using Automapper.
        public static BookingModel Map(this BookingEntity bookingE)
        {
            var bookingM = new BookingModel();

            if (bookingE != null)
            {
                bookingM.Id = bookingE.Id;
                bookingM.StartDateUtc = bookingE.StartDateUtc;
                bookingM.EndDateUtc = bookingE.EndDateUtc;
                bookingM.ConfirmationNumber = bookingE.ConfirmationNumber;
                bookingM.CarId = bookingE.CarId;
                bookingM.GarageId = bookingE.GarageId;
                bookingM.GarageName = bookingE.Garage?.Name;
                bookingM.GarageCapacity = bookingE.Garage?.Capacity ;
                bookingM.CarLicencePlate = bookingE.Car?.LicencePlate;
            }

            return bookingM;
        }

        public static BookingEntity Map(this BookingModel bookingM)
        {
            var bookingE = new BookingEntity();
            if (bookingM != null)
            {
                bookingE.Id = bookingM.Id;
                bookingE.StartDateUtc = bookingM.StartDateUtc;
                bookingE.EndDateUtc = bookingM.EndDateUtc;
                bookingE.ConfirmationNumber = bookingM.ConfirmationNumber;
                bookingE.CarId = bookingE.CarId;
                bookingE.GarageId = bookingE.GarageId;
            }
            return bookingE;
        }
    }
}
