using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using u24637646_HW01.Models;

namespace u24637646_HW01.Controllers
{
    public class ManagementController : Controller
    {
        // Display manage page with optional filters
        public ActionResult Manage(string searchFirstName, string searchServiceType)
        {
            var allDrivers = DriverVehicleRepository.GetAllDrivers();
            var allVehicles = DriverVehicleRepository.GetAllVehicles();

            // Filter drivers by first name and service type
            var filteredDrivers = allDrivers.Where(d =>
                (string.IsNullOrEmpty(searchFirstName) || d.FirstName.ToLower().Contains(searchFirstName.ToLower())) &&
                (string.IsNullOrEmpty(searchServiceType) || d.ServiceType == searchServiceType)
            ).ToList();

            // Prepare view model with filtered data and service types
            var viewModel = new ManagementViewModel
            {
                SearchFirstName = searchFirstName,
                SearchServiceType = searchServiceType,
                Drivers = filteredDrivers,
                Vehicles = allVehicles,
                AllServices = GetAllServiceTypes()
            };

            return View(viewModel);
        }

        // Return list of service types for dropdowns
        private List<SelectListItem> GetAllServiceTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Advanced Life Support", Value = "Advanced Life Support" },
                new SelectListItem { Text = "Basic Life Support", Value = "Basic Life Support" },
                new SelectListItem { Text = "Patient Transport", Value = "Patient Transport" },
                new SelectListItem { Text = "Medical Utility Vehicle", Value = "Medical Utility Vehicle" },
                new SelectListItem { Text = "Event Medical Ambulance", Value = "Event Medical Ambulance" },
                new SelectListItem { Text = "Air Ambulance", Value = "Air Ambulance" }
            };
        }

        // Export all vehicles to a text file
        [HttpPost]
        public ActionResult ExportVehicles()
        {
            var vehicles = DriverVehicleRepository.GetAllVehicles();
            var lines = vehicles.Select(v => $"{v.RegistrationNumber}, {v.ServiceType}");

            var filePath = Server.MapPath("~/App_Data/VehiclesExport.txt");
            System.IO.File.WriteAllLines(filePath, lines);

            return File(filePath, "text/plain", "VehiclesExport.txt");
        }

        // Show driver form for create or edit
        public ActionResult DriverForm(int? id)
        {
            var services = GetAllServiceTypes();
            ViewBag.Services = services;

            if (id.HasValue)
            {
                var driver = DriverVehicleRepository.GetDriverById(id.Value);
                if (driver == null) return HttpNotFound();

                var model = new DriverFormModel
                {
                    DriverId = driver.DriverId,
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    PhoneNumber = driver.PhoneNumber,
                    ServiceType = driver.ServiceType,
                    Gender = driver.Gender
                };
                return PartialView("_DriverForm", model);
            }

            // Return empty form for new driver
            return PartialView("_DriverForm", new DriverFormModel());
        }

        // Add new driver to repository
        [HttpPost]
        public ActionResult CreateDriver(DriverFormModel model)
        {
            if (ModelState.IsValid)
            {
                var driver = new Driver(0, model.FirstName, model.LastName, model.PhoneNumber, model.Gender, model.ServiceType);
                DriverVehicleRepository.AddDriver(driver);
                TempData["Message"] = "Driver added successfully.";
            }
            return RedirectToAction("Manage");
        }

        // Update existing driver details
        [HttpPost]
        public ActionResult EditDriver(DriverFormModel model)
        {
            if (ModelState.IsValid)
            {
                var driver = new Driver(model.DriverId, model.FirstName, model.LastName, model.PhoneNumber, model.Gender, model.ServiceType);
                DriverVehicleRepository.UpdateDriver(driver);
            }
            return RedirectToAction("Manage");
        }

        // Delete driver by ID
        [HttpGet]
        public ActionResult DeleteDriver(int driverId)
        {
            DriverVehicleRepository.DeleteDriver(driverId);
            TempData["Message"] = "Driver deleted successfully.";
            return RedirectToAction("Manage");
        }

        // Show vehicle form for create or edit
        public ActionResult VehicleForm(int? id)
        {
            var services = GetAllServiceTypes();
            ViewBag.Services = services;

            if (id.HasValue)
            {
                var vehicle = DriverVehicleRepository.GetVehicleById(id.Value);
                if (vehicle == null)
                    return HttpNotFound();

                var model = new VehicleFormModel
                {
                    VehicleId = vehicle.VehicleId,
                    RegistrationNumber = vehicle.RegistrationNumber,
                    ServiceType = vehicle.ServiceType
                };

                return PartialView("_VehicleForm", model);
            }

            // Return empty form for new vehicle
            var newVehicleModel = new VehicleFormModel
            {
                VehicleId = 0,
                RegistrationNumber = "",
                ServiceType = services.First().Value
            };

            return PartialView("_VehicleForm", newVehicleModel);
        }

        // Add or update vehicle based on ID
        [HttpPost]
        public ActionResult SaveVehicle(VehicleFormModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.VehicleId == 0)
                {
                    // Add new vehicle
                    var newVehicle = new Vehicle(0, model.RegistrationNumber, model.ServiceType);
                    DriverVehicleRepository.AddVehicle(newVehicle);
                    TempData["Message"] = "Vehicle added successfully.";
                }
                else
                {
                    // Update existing vehicle
                    var updatedVehicle = new Vehicle(model.VehicleId, model.RegistrationNumber, model.ServiceType);
                    DriverVehicleRepository.UpdateVehicle(updatedVehicle);
                    TempData["Message"] = "Vehicle updated successfully.";
                }

                return RedirectToAction("Manage");
            }

            // Reload form with errors and service list
            ViewBag.Services = GetAllServiceTypes();
            return PartialView("_VehicleForm", model);
        }

        // Delete vehicle by ID
        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            DriverVehicleRepository.DeleteVehicle(id);
            TempData["Message"] = "Vehicle deleted successfully.";
            return RedirectToAction("Manage");
        }
    }
}
