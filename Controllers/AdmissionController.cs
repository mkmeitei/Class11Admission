using System.Data.Common;
using Class11Admission.Data;
using Class11Admission.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace Class11Admission.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly AppDbContext _db;

        // ASP.NET automatically injects the database for us
        public AdmissionController(AppDbContext db)
        {
            _db = db;
        }


        // GET: /Admission/Apply
        // This just shows the empty form
        public IActionResult Apply()
        {
            return View();
        }


        // POST: /Admission/Apply
        // This runs when the student submits the form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(Application application)
        {
            if (ModelState.IsValid)
            {
                // Generate a unique tracking ID for the student
                application.TrackingId = "ADM" + Guid.NewGuid()
                .ToString("N")
                .Substring(0, 8)
                .ToUpper();

                application.AppliedOn = DateTime.Now;
                application.Status = "Pending";

                //Save to Database
                _db.Applications.Add(application);
                await _db.SaveChangesAsync();

                // Redirect to confirmation page with tracking ID
                return RedirectToAction("Confirmation", new { trackingId = application.TrackingId });
            }

            // If validation failed, show the form again with error messages
            return View(application);
        }

        // GET: /Admission/Confirmation
        public IActionResult Confirmation(string trackingId)
        {
            ViewBag.TrackingId = trackingId;
            return View();
        }

        // GET: /Admission/CheckStatus
        public IActionResult CheckStatus()
        {
            return View();
        }

        // POST: /Admission/CheckStatus
        [HttpPost]
        public async Task<IActionResult> CheckStatus(string trackingId)
        {
            var application = await _db.Applications
                .FirstOrDefaultAsync(a => a.TrackingId == trackingId);

            if (application == null)
            {
                ViewBag.Error = "No application found with this Tracking ID.";
                return View();
            }

            return View("StatusResult", application);
        }

    }
}