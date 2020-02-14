using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingBookingService.Dal.DataModel
{
    internal class BookingEntity : BaseEntity
    {
        [Required]
        public DateTime StartDateUtc { get; set; }
        [Required]
        public DateTime EndDateUtc { get; set; }
        // Index here, on confirmation number. make them unique and easy searchable
        [StringLength(50)]
        public string ConfirmationNumber { get; set; }
        // status - like empty, reserved, used
        // type - like Bigger, for wheelchair or for family
        
        public long CarId { get; set; }
        public CarEntity Car { get; set; }

        public long GarageId { get; set; }
        public GarageEntity Garage { get; set; }
    }
}
