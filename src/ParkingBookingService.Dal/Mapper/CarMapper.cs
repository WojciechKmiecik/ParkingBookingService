using ParkingBookingService.Dal.DataModel;
using ParkingBookingService.Definition.Models;

namespace ParkingBookingService.Dal.Mapper
{
    internal static class CarMapper
    {
        // intentionally not using Automapper.
        public static CarModel Map(this CarEntity carE)
        {
            var carM = new CarModel();

            if (carE != null)
            {
                carM.Id = carE.Id;
                carM.LicencePlate = carE.LicencePlate;
            }

            return carM;
        }

        public static CarEntity Map(this CarModel carM)
        {
            var carE = new CarEntity();
            if (carM != null)
            {
                carE.Id = carM.Id;
                carE.LicencePlate = carM.LicencePlate;
            }
            return carE;
        }
    }
}
