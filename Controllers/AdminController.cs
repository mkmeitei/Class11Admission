using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Class11Admission.Data;
using Class11Admission.Models;

namespace Class11Admission.Controllers
{
    [Authorize(Roles = "Admin")]  // ← only Admin role can access ANY action in this controller
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;

        public AdminController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /Admin/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var applications = await _db.Applications
                .OrderByDescending(a => a.AppliedOn)
                .ToListAsync();

            return View(applications);
        }

        // GET: /Admin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var application = await _db.Applications
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
                return NotFound();

            return View(application);
        }

        // POST: /Admin/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var application = await _db.Applications
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
                return NotFound();

            application.Status = status;
            await _db.SaveChangesAsync();

            TempData["Message"] = $"Status updated to {status} for {application.FullName}";

            return RedirectToAction("Dashboard");
        }
    }
}