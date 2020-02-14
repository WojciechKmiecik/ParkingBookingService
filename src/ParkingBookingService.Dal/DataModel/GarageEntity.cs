using System.Collections.Generic;

namespace ParkingBookingService.Dal.DataModel
{
    internal class GarageEntity : BaseEntity
    {
        public string Name { get; set; }
        public uint Capacity { get; set; }
        // location, or next stuff

        public List<BookingEntity> Bookings { get; set; }
    }
}
