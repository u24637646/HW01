public class Vehicle
{
    public int VehicleId { get; set; }
    public string RegistrationNumber { get; set; }
    public string ServiceType { get; set; }

    // Returns the image URL based on the service type
    public string ImgUrl
    {
        get
        {
            switch (ServiceType)
            {
                case "Advanced Life Support": return "~/Images/ServiceTypes/ALS.png";
                case "Basic Life Support": return "~/Images/ServiceTypes/BLS.png";
                case "Patient Transport": return "~/Images/ServiceTypes/Transport.png";
                case "Medical Utility Vehicle": return "~/Images/ServiceTypes/Utility.png";
                case "Event Medical Ambulance": return "~/Images/ServiceTypes/Event.png";
                case "Air Ambulance": return "~/Images/ServiceTypes/Air.png";
                default: return "~/Images/ServiceTypes/default.png";
            }
        }
    }

    // Constructor to initialize the vehicle properties
    public Vehicle(int id, string regNo, string serviceType)
    {
        VehicleId = id;
        RegistrationNumber = regNo;
        ServiceType = serviceType;
    }
}
