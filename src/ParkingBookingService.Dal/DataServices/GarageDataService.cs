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
    internal class GarageDataService : IGarageDataService
    {
        private readonly ParkingBookingContext _ctx;

        public GarageDataService(ParkingBookingContext parkingBookingContext)
        {
            _ctx = parkingBookingContext;
        }

        public async Task<List<GarageModel>> GetAll()
        {
            return await _ctx.Garages.Select(x => x.Map()).ToListAsync();
        }

        public async Task<GarageModel> GetByName(string name)
        {
            return await _ctx.Garages.Select(x => x.Map()).FirstOrDefaultAsync(x => x.Name == name);
        }
  

    }
}
