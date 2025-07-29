namespace u24637646_HW01.Models
{
    // Model used for Driver form data binding and validation
    public class DriverFormModel
    {
        // Driver's unique identifier (0 for new drivers)
        public int DriverId { get; set; }

        // Driver's first name
        public string FirstName { get; set; }

        // Driver's last name
        public string LastName { get; set; }

        // Driver's phone number
        public string PhoneNumber { get; set; }

        // Service type assigned to the driver
        public string ServiceType { get; set; }

        // Driver's gender
        public Gender Gender { get; set; }
    }
}
