using ParkingBookingService.Definition.DataServices;
using ParkingBookingService.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ParkingBookingService.Definition.Services;

namespace ParkingBookingService.Logic.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingDataService _bookingData;
        private readonly IGarageDataService _garageData;
        private readonly ICarDataService _carData;

        public BookingService(IBookingDataService bookingData, IGarageDataService garageData, ICarDataService carData)
        {
            _bookingData = bookingData;
            _garageData = garageData;
            _carData = carData;
        }

        public async Task<string> PostNewBooking(BookingModel bookingModel)
        {
            // not paraler, like Task.WhenAll() since they are accesing the same resource
            var garage = await _garageData.GetByName(bookingModel.GarageName);

            if (garage == null)
            {
                throw new ArgumentException("Garage unknown");
            }

            // get or add could be fine there
            CarModel car = await _carData.GetByLicencePlate(bookingModel.CarLicencePlate);
            if (car == null)
            {
                await _carData.AddCar(new CarModel() { LicencePlate = bookingModel.CarLicencePlate });
                car = await _carData.GetByLicencePlate(bookingModel.CarLicencePlate);
                if (car == null)
                {
                    throw new ArgumentNullException("Cannot store the car, database error");
                }
            }

            var bookingsList = await _bookingData.GetAllBetweenDates(bookingModel.StartDateUtc, bookingModel.EndDateUtc);
            if (bookingsList == null)
            {
                throw new ArgumentNullException("Cannot get current bookings information, database error");
            }

            if (bookingsList.Count >= garage.Capacity)
            {
                return "Garage is full";
            }

            bookingModel.CarId = car.Id;
            bookingModel.GarageId = garage.Id;
            bookingModel.ConfirmationNumber = Guid.NewGuid().ToString(); // for simplicity

            var retObj = await _bookingData.SaveBooking(bookingModel);

            if (retObj == null)
            {
                throw new ArgumentNullException("Cannot save the booking, Database Error");
            }
            return retObj.ConfirmationNumber;
                
        }
    }
}

