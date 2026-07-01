using Microsoft.AspNetCore.Identity;

namespace Class11Admission.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            // 1. Create the "Admin" role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // 2. Create a default admin user if none exists
            string adminEmail = "admin@school.com";
            string adminPassword = "Admin@123";

            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    // 3. Assign the Admin role to this user
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}