using System.Collections.Generic;
using System.Linq;

namespace u24637646_HW01.Models
{
    public static class DriverVehicleRepository
    {
        // Static list of drivers prepopulated with sample data
        public static List<Driver> Drivers = new List<Driver>
        {
            // Advanced Life Support drivers
            new Driver(1, "Zoe", "Mia", "0123456789", Gender.Female, "Advanced Life Support"),
            new Driver(2, "Xario", "Zeekoei", "0234567890", Gender.Male, "Advanced Life Support"),
            new Driver(3, "Clara", "Brown", "0345678901", Gender.Female, "Advanced Life Support"),

            // Basic Life Support drivers
            new Driver(4, "David", "White", "0456789012", Gender.Male, "Basic Life Support"),
            new Driver(5, "Eva", "Green", "0567890123", Gender.Female, "Basic Life Support"),
            new Driver(6, "Frank", "Black", "0678901234", Gender.Male, "Basic Life Support"),

            // Air Ambulance drivers
            new Driver(7, "Grace", "Hall", "0789012345", Gender.Female, "Air Ambulance"),
            new Driver(8, "Henry", "Moore", "0890123456", Gender.Male, "Air Ambulance"),
            new Driver(9, "Ivy", "Lee", "0901234567", Gender.Female, "Air Ambulance"),

            // Patient Transport drivers
            new Driver(16, "Alice", "Walker", "0102221888", Gender.Female, "Patient Transport"),
            new Driver(17, "Bob", "Martin", "0102221999", Gender.Male, "Patient Transport"),
            new Driver(18, "Clara", "Evans", "0102222000", Gender.Female, "Patient Transport"),

            // Medical Utility Vehicle drivers
            new Driver(10, "Bob", "Jones", "0101111222", Gender.Male, "Medical Utility Vehicle"),
            new Driver(11, "Alice", "Smith", "0101111333", Gender.Female, "Medical Utility Vehicle"),
            new Driver(12, "Olive", "Grant", "0101111444", Gender.Male, "Medical Utility Vehicle"),

            // Event Medical Ambulance drivers
            new Driver(13, "Kara", "Queen", "0101111555", Gender.Female, "Event Medical Ambulance"),
            new Driver(14, "Jack", "King", "0101111666", Gender.Male, "Event Medical Ambulance"),
            new Driver(15, "Nate", "Ford", "0101111777", Gender.Female, "Event Medical Ambulance")
        };

        // Static list of vehicles prepopulated with sample data
        public static List<Vehicle> Vehicles = new List<Vehicle>
        {
            // Advanced Life Support vehicles
            new Vehicle(1, "ALS-101", "Advanced Life Support"),
            new Vehicle(2, "ALS-102", "Advanced Life Support"),
            new Vehicle(3, "ALS-103", "Advanced Life Support"),

            // Basic Life Support vehicles
            new Vehicle(4, "BLS-201", "Basic Life Support"),
            new Vehicle(5, "BLS-202", "Basic Life Support"),
            new Vehicle(6, "BLS-203", "Basic Life Support"),

            // Air Ambulance vehicles
            new Vehicle(7, "AIR-301", "Air Ambulance"),
            new Vehicle(8, "AIR-302", "Air Ambulance"),
            new Vehicle(9, "AIR-303", "Air Ambulance"),

            // Patient Transport vehicles
            new Vehicle(16, "PT-201", "Patient Transport"),
            new Vehicle(17, "PT-202", "Patient Transport"),
            new Vehicle(18, "PT-203", "Patient Transport"),

            // Medical Utility Vehicle vehicles
            new Vehicle(10, "UTIL-401", "Medical Utility Vehicle"),
            new Vehicle(11, "UTIL-402", "Medical Utility Vehicle"),
            new Vehicle(12, "UTIL-403", "Medical Utility Vehicle"),

            // Event Medical Ambulance vehicles
            new Vehicle(13, "EVENT-501", "Event Medical Ambulance"),
            new Vehicle(14, "EVENT-502", "Event Medical Ambulance"),
            new Vehicle(15, "EVENT-503", "Event Medical Ambulance")
        };

        // Returns all drivers filtered by service type
        public static List<Driver> GetDriversByService(string serviceType)
        {
            return Drivers.Where(d => d.ServiceType == serviceType).ToList();
        }

        // Returns all vehicles filtered by service type
        public static List<Vehicle> GetVehiclesByService(string serviceType)
        {
            return Vehicles.Where(v => v.ServiceType == serviceType).ToList();
        }

        // Retrieves a driver by unique ID
        public static Driver GetDriverById(int id)
        {
            return Drivers.FirstOrDefault(d => d.DriverId == id);
        }

        // Retrieves a vehicle by unique ID
        public static Vehicle GetVehicleById(int id)
        {
            return Vehicles.FirstOrDefault(v => v.VehicleId == id);
        }

        // Returns all drivers
        public static List<Driver> GetAllDrivers()
        {
            return Drivers.ToList();
        }

        // Returns all vehicles
        public static List<Vehicle> GetAllVehicles()
        {
            return Vehicles.ToList();
        }

        // Adds a new driver, assigning a new ID
        public static void AddDriver(Driver driver)
        {
            driver.DriverId = Drivers.Any() ? Drivers.Max(d => d.DriverId) + 1 : 1;
            Drivers.Add(driver);
        }

        // Updates an existing driver by matching ID
        public static void UpdateDriver(Driver updated)
        {
            var index = Drivers.FindIndex(d => d.DriverId == updated.DriverId);
            if (index != -1) Drivers[index] = updated;
        }

        // Deletes a driver by ID
        public static void DeleteDriver(int id)
        {
            Drivers.RemoveAll(d => d.DriverId == id);
        }

        // Adds a new vehicle, assigning a new ID
        public static void AddVehicle(Vehicle vehicle)
        {
            vehicle.VehicleId = Vehicles.Any() ? Vehicles.Max(v => v.VehicleId) + 1 : 1;
            Vehicles.Add(vehicle);
        }

        // Updates an existing vehicle by matching ID
        public static void UpdateVehicle(Vehicle updated)
        {
            var index = Vehicles.FindIndex(v => v.VehicleId == updated.VehicleId);
            if (index != -1) Vehicles[index] = updated;
        }

        // Deletes a vehicle by ID
        public static void DeleteVehicle(int id)
        {
            Vehicles.RemoveAll(v => v.VehicleId == id);
        }
    }
}
