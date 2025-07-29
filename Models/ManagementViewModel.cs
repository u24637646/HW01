using System.Collections.Generic;
using System.Web.Mvc;

namespace u24637646_HW01.Models
{
    public class ManagementViewModel
    {
        // List of drivers to display in management view
        public List<Driver> Drivers { get; set; }

        // List of vehicles to display in management view
        public List<Vehicle> Vehicles { get; set; }

        // Search filter for driver's first name
        public string SearchFirstName { get; set; }

        // Search filter for service type
        public string SearchServiceType { get; set; }

        // Dropdown list containing all available service types
        public List<SelectListItem> AllServices { get; set; }

        // Constructor to initialize the lists to avoid null references
        public ManagementViewModel()
        {
            Drivers = new List<Driver>();
            Vehicles = new List<Vehicle>();
            AllServices = new List<SelectListItem>();
        }
    }
}
