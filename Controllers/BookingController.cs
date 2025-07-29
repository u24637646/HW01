using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using u24637646_HW01.Models;

namespace u24637646_HW01.Controllers
{
    public class BookingController : Controller
    {
        // GET: Book - Display booking form for a service
        public ActionResult Book(string serviceName)
        {
            // Get vehicles for the selected service
            var vehicles = DriverVehicleRepository.GetVehiclesByService(serviceName);
            // Get drivers for the selected service
            var drivers = DriverVehicleRepository.GetDriversByService(serviceName);

            // Prepare the booking view model
            var model = new BookingViewModel
            {
                ServiceName = serviceName,
                Reasons = GetReasons(),
                Vehicles = vehicles
                    .Select(v => new SelectListItem
                    {
                        Value = v.VehicleId.ToString(),
                        Text = v.RegistrationNumber
                    })
                    .ToList(),
                Drivers = drivers
                    .Select(d => new SelectListItem
                    {
                        Value = d.DriverId.ToString(),
                        Text = $"{d.FirstName} {d.LastName}"
                    })
                    .ToList()
            };

            // Store service image path in ViewBag
            ViewBag.ServiceImagePath = GetImagePath(serviceName);

            // Return view with model
            return View(model);
        }

        // POST: SubmitBooking - Process booking submission
        [HttpPost]
        public ActionResult SubmitBooking(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve selected driver and vehicle by ID
                var selectedDriver = DriverVehicleRepository.GetDriverById(model.SelectedDriverId ?? 0);
                var selectedVehicle = DriverVehicleRepository.GetVehicleById(model.SelectedVehicleId ?? 0);

                // Create new booking object
                var booking = new Booking
                {
                    BookingId = Guid.NewGuid().ToString(),
                    BookingDate = DateTime.Now,
                    FullName = model.FullName,
                    Phone = model.Phone,
                    PickUpTime = model.PickUpTime ?? DateTime.Now,
                    Address = model.Address,
                    ServiceType = model.ServiceName,
                    Driver = selectedDriver,
                    Vehicle = selectedVehicle,
                    IsSOS = false
                };

                // Get existing bookings from session or initialize list
                var bookings = Session["Bookings"] as List<Booking> ?? new List<Booking>();

                // Add new booking and update session
                bookings.Add(booking);
                Session["Bookings"] = bookings;
                Session["LastBooking"] = booking;

                // Redirect to confirmation page
                return RedirectToAction("Confirmation");
            }

            // Repopulate dropdowns if validation fails
            model.Reasons = GetReasons();
            model.Vehicles = DriverVehicleRepository.GetVehiclesByService(model.ServiceName)
                .Select(v => new SelectListItem
                {
                    Value = v.VehicleId.ToString(),
                    Text = v.RegistrationNumber
                })
                .ToList();
            model.Drivers = DriverVehicleRepository.GetDriversByService(model.ServiceName)
                .Select(d => new SelectListItem
                {
                    Value = d.DriverId.ToString(),
                    Text = $"{d.FirstName} {d.LastName}"
                })
                .ToList();

            // Reset service image path
            ViewBag.ServiceImagePath = GetImagePath(model.ServiceName);

            // Collect error messages to display
            ViewBag.ErrorMessage = string.Join("<br/>", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            // Return booking view with errors
            return View("Book", model);
        }

        // GET: Confirmation - Show booking confirmation
        public ActionResult Confirmation(string id = null)
        {
            // Get bookings list from session
            var bookings = Session["Bookings"] as List<Booking> ?? new List<Booking>();

            // Find booking by id or use last booking
            Booking bookingToShow = !string.IsNullOrEmpty(id)
                ? bookings.FirstOrDefault(b => b.BookingId == id)
                : Session["LastBooking"] as Booking;

            // Redirect if booking not found
            if (bookingToShow == null)
            {
                return RedirectToAction("RideHistory");
            }

            // Show confirmation view with booking details
            return View(bookingToShow);
        }

        // GET: RideHistory - List all bookings
        public ActionResult RideHistory()
        {
            // Get all bookings from session
            var bookings = Session["Bookings"] as List<Booking> ?? new List<Booking>();

            // Return ride history view
            return View(bookings);
        }

        // Provide reasons for booking dropdown
        private List<SelectListItem> GetReasons()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Medical Emergency" },
                new SelectListItem { Value = "2", Text = "Non-Emergency Transport" },
                new SelectListItem { Value = "3", Text = "Event Standby" }
            };
        }

        // Return image path based on service name
        private string GetImagePath(string serviceName)
        {
            switch (serviceName)
            {
                case "Advanced Life Support":
                    return Url.Content("~/Images/ServiceTypes/ALS.png");
                case "Basic Life Support":
                    return Url.Content("~/Images/ServiceTypes/BLS.png");
                case "Patient Transport":
                    return Url.Content("~/Images/ServiceTypes/Transport.png");
                case "Medical Utility Vehicle":
                    return Url.Content("~/Images/ServiceTypes/Utility.png");
                case "Event Medical Ambulance":
                    return Url.Content("~/Images/ServiceTypes/Event.png");
                case "Air Ambulance":
                    return Url.Content("~/Images/ServiceTypes/Air.png");
                default:
                    return Url.Content("~/Images/ServiceTypes/default.png");
            }
        }
    }
}
