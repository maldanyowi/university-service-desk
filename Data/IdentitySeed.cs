using Microsoft.AspNetCore.Identity;

namespace UniversityServiceDesk.Data;

public static class IdentitySeed
{
    public static async Task CreateRolesAndTechnicianAsync(
        IServiceProvider services,
        IConfiguration configuration)
    {
        var roleManager =
            services.GetRequiredService<RoleManager<IdentityRole>>();

        var userManager =
            services.GetRequiredService<UserManager<IdentityUser>>();

        string[] roles =
        {
            "Requester",
            "Technician"
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(
                    new IdentityRole(role));
            }
        }

        var technicianEmail =
            configuration["TechnicianAccount:Email"];

        var technicianPassword =
            configuration["TechnicianAccount:Password"];

        if (string.IsNullOrWhiteSpace(technicianEmail) ||
            string.IsNullOrWhiteSpace(technicianPassword))
        {
            return;
        }

        var technician =
            await userManager.FindByEmailAsync(technicianEmail);

        if (technician == null)
        {
            technician = new IdentityUser
            {
                UserName = technicianEmail,
                Email = technicianEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(
                technician,
                technicianPassword);

            if (!result.Succeeded)
            {
                return;
            }
        }

        if (!await userManager.IsInRoleAsync(
                technician,
                "Technician"))
        {
            await userManager.AddToRoleAsync(
                technician,
                "Technician");
        }
    }
}