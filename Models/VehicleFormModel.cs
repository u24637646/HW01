using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u24637646_HW01.Models
{
    public class VehicleFormModel
    {
        // Unique identifier for the vehicle
        public int VehicleId { get; set; }

        // Vehicle registration number (e.g. license plate)
        public string RegistrationNumber { get; set; }

        // The type of service this vehicle belongs to
        public string ServiceType { get; set; }
    }
}
