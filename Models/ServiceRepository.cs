using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u24637646_HW01.Models
{
    public static class ServiceRepository
    {
        // Returns a list of all available services
        public static List<Service> GetAllServices()
        {
            return new List<Service>
            {
                new Service { Id = 1, Name = "Advanced Life Support", ImagePath = "~/Content/Images/ServiceTypes/ALS.png" },
                new Service { Id = 2, Name = "Basic Life Support", ImagePath = "~/Content/Images/ServiceTypes/BLS.png" },
                new Service { Id = 3, Name = "Patient Transport", ImagePath = "~/Content/Images/ServiceTypes/Transport.png" },
                new Service { Id = 4, Name = "Medical Utility Vehicle", ImagePath = "~/Content/Images/ServiceTypes/Utility.png" },
                new Service { Id = 5, Name = "Event Medical Ambulance", ImagePath = "~/Content/Images/ServiceTypes/Event.png" },
                new Service { Id = 6, Name = "Air Ambulance", ImagePath = "~/Content/Images/ServiceTypes/Air.png" }
            };
        }

        // Retrieves a service by its name; returns null if not found
        public static Service GetByName(string name)
        {
            return GetAllServices().FirstOrDefault(s => s.Name == name);
        }
    }
}
