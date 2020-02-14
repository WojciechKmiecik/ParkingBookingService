using System;

namespace ParkingBookingService.Definition.Models
{
    public class BookingModel
    {
        public long  Id { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public string ConfirmationNumber { get; set; }

        public long CarId { get; set; }
        public string CarLicencePlate { get; set; }

        public long GarageId { get; set; }
        public string GarageName { get; set; }
        public uint? GarageCapacity { get; set; }
    }
}
