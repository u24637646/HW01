using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace u24637646_HW01.Models
{
    public class BookingViewModel
    {
        // User's full name; required field
        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        // User's phone number; required and must be valid format
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        // Pick-up time; required field
        [Required(ErrorMessage = "Pick-up time is required.")]
        [Display(Name = "Pick-Up Time")]
        public DateTime? PickUpTime { get; set; }

        // Reason for booking; selected from dropdown, required
        [Required(ErrorMessage = "Please select a reason.")]
        [Display(Name = "Reason")]
        public int? SelectedReasonId { get; set; }

        // Vehicle selection; required dropdown
        [Required(ErrorMessage = "Please select a vehicle.")]
        [Display(Name = "Vehicle")]
        public int? SelectedVehicleId { get; set; }

        // Driver selection; required dropdown
        [Required(ErrorMessage = "Please select a driver.")]
        [Display(Name = "Driver")]
        public int? SelectedDriverId { get; set; }

        // Pick-up address; required text input
        [Required(ErrorMessage = "Pick-up address is required.")]
        [Display(Name = "Pick-Up Address")]
        public string Address { get; set; }

        // Name of the service for booking
        public string ServiceName { get; set; }

        // List of reasons for dropdown population
        public List<SelectListItem> Reasons { get; set; }

        // List of available vehicles for dropdown population
        public List<SelectListItem> Vehicles { get; set; }

        // List of available drivers for dropdown population
        public List<SelectListItem> Drivers { get; set; }
    }
}
