using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u24637646_HW01.Models;

namespace u24637646_HW01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index page
        public ActionResult Index()
        {
            return View();
        }

        // GET: Service selection page
        public ActionResult SelectService()
        {
            return View();
        }

        // GET: Emergency booking auto-dispatch
        public ActionResult Emergency()
        {
            // Define emergency service info
            string serviceName = "Advanced Life Support";
            string emergencyPhone = "10177";
            string emergencyReg = "RSA-EM999";

            // Create emergency driver instance
            var driver = new Driver(
                id: 999,
                firstName: "Emergency",
                lastName: "Driver",
                phone: emergencyPhone,
                gender: Gender.Male,
                serviceType: serviceName
            );

            // Create emergency vehicle instance
            var vehicle = new Vehicle(
                id: 999,
                regNo: emergencyReg,
                serviceType: serviceName
            );

            // Create emergency booking record
            var booking = new Booking
            {
                BookingId = Guid.NewGuid().ToString(),
                BookingDate = DateTime.Now,
                FullName = "Emergency Auto-Dispatch",
                Phone = "N/A",
                PickUpTime = DateTime.Now,
                Address = "Auto-generated SOS Location",
                ServiceType = serviceName,
                Driver = driver,
                Vehicle = vehicle,
                IsSOS = true
            };

            // Retrieve existing bookings or create new list
            var bookings = Session["Bookings"] as List<Booking> ?? new List<Booking>();

            // Add new booking to session
            bookings.Add(booking);
            Session["Bookings"] = bookings;
            Session["LastBooking"] = booking;

            // Redirect to booking confirmation view
            return RedirectToAction("Confirmation", "Booking");
        }

        // GET: About page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // GET: Contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
