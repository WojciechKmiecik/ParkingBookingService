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
    internal class CarDataService : ICarDataService
    {
        private readonly ParkingBookingContext _ctx;

        public CarDataService(ParkingBookingContext parkingBookingContext)
        {
            _ctx = parkingBookingContext;
        }

        public async Task<List<CarModel>> GetAll()
        {
            return await _ctx.Cars.Select(x => x.Map()).ToListAsync();
        }

        public async Task<CarModel> GetByLicencePlate(string licencePlate)
        {
            return await _ctx.Cars.Select(x => x.Map()).FirstOrDefaultAsync(x => x.LicencePlate == licencePlate);
        }

        public async Task AddCar(CarModel car)
        {
            await _ctx.Cars.AddAsync(car.Map());
            await _ctx.SaveChangesAsync();            
        }        

    }
}
