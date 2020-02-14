using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingBookingService.Dal.DataModel
{
    internal class CarEntity : BaseEntity
    {
        public string LicencePlate { get; set; }
        // next props, like country of registration

        public List<BookingEntity> Bookings { get; set; }
    }
}
