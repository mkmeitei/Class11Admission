using Class11Admission.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Class11Admission.Data
{
    // Notice: IdentityDbContext instead of plain DbContext
    // IdentityUser gives us built-in fields: Email, PasswordHash, etc.
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // This tells EF Core: "create an Applications table"
        public DbSet<Application> Applications { get; set; }
    }
}