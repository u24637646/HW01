using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u24637646_HW01.Models
{
    public class Booking
    {
        // Unique identifier for booking
        public string BookingId { get; set; }

        // Date and time when booking was made
        public DateTime BookingDate { get; set; }

        // Name of the person who made the booking
        public string FullName { get; set; }

        // Contact phone number
        public string Phone { get; set; }

        // Scheduled pick-up date and time
        public DateTime PickUpTime { get; set; }

        // Pick-up address/location
        public string Address { get; set; }

        // Type of service booked
        public string ServiceType { get; set; }

        // Driver assigned to booking
        public Driver Driver { get; set; }

        // Vehicle assigned to booking
        public Vehicle Vehicle { get; set; }

        // Indicates if booking is an emergency SOS
        public bool IsSOS { get; set; }
    }
}
