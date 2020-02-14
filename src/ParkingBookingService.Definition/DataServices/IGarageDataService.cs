using ParkingBookingService.Definition.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBookingService.Definition.DataServices
{
    public interface IGarageDataService
    {
        public  Task<List<GarageModel>> GetAll();

        public  Task<GarageModel> GetByName(string name);
    }
}
