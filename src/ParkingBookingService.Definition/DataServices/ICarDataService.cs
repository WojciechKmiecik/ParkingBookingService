using ParkingBookingService.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBookingService.Definition.DataServices
{
    public interface ICarDataService
    {
        public Task<List<CarModel>> GetAll();

        public Task<CarModel> GetByLicencePlate(string licencePlate);

        public Task AddCar(CarModel car);
    }
}
