using ParkingBookingService.Dal.DataModel;
using ParkingBookingService.Definition.Models;

namespace ParkingBookingService.Dal.Mapper
{
    internal static class GarageMapper
    {
        // intentionally not using Automapper.
        public static GarageModel Map(this GarageEntity garageE)
        {
            var garageM = new GarageModel();

            if (garageE != null)
            {
                garageM.Id = garageE.Id;
                garageM.Name = garageE.Name;
                garageM.Capacity = garageE.Capacity;
            }

            return garageM;
        }

        public static GarageEntity Map(this GarageModel garageM)
        {
            var garageE = new GarageEntity();
            if (garageM != null)
            {
                garageE.Id = garageM.Id;
                garageE.Name = garageM.Name;
                garageE.Capacity = garageM.Capacity;
            }
            return garageE;
        }
    }
}
