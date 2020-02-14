using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingBookingService.WebApi.WebModels
{
    public class BookingRequestWebModel
    {
        public string LicencePlate { get; set; }
        public string GarageName { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
    }
}
