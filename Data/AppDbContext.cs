using Class11Admission.Models;
using Microsoft.EntityFrameworkCore;

namespace Class11Admission.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // This tells EF Core: "create an Applications table"
        public DbSet<Application> Applications { get; set; }
    }
}