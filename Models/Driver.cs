namespace u24637646_HW01.Models
{
    // Enum to represent gender options
    public enum Gender { Male, Female }

    public class Driver
    {
        // Unique identifier for the driver
        public int DriverId { get; set; }

        // Driver's first name
        public string FirstName { get; set; }

        // Driver's last name
        public string LastName { get; set; }

        // Driver's contact phone number
        public string PhoneNumber { get; set; }

        // Service type the driver is assigned to
        public string ServiceType { get; set; }

        // Driver's gender
        public Gender Gender { get; set; }

        // Returns image URL based on gender
        public string ImgUrl => Gender == Gender.Male
            ? "~/Images/Drivers/Male.jpg"
            : "~/Images/Drivers/Female.png";

        // Constructor to initialize a Driver instance
        public Driver(int id, string firstName, string lastName, string phone, Gender gender, string serviceType)
        {
            DriverId = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phone;
            Gender = gender;
            ServiceType = serviceType;
        }
    }
}
