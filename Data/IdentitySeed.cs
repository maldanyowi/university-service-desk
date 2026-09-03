using Microsoft.AspNetCore.Identity;
using UniversityServiceDesk.Models;

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
            services.GetRequiredService<UserManager<ApplicationUser>>();

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

        if (!string.IsNullOrWhiteSpace(technicianEmail) &&
            !string.IsNullOrWhiteSpace(technicianPassword))
        {
            var technician =
                await userManager.FindByEmailAsync(technicianEmail);

            if (technician == null)
            {
                technician = new ApplicationUser
                {
                    FullName = "Administrator",
                    UserName = technicianEmail,
                    Email = technicianEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(
                    technician,
                    technicianPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(
                        technician,
                        "Technician");
                }
            }
            else
            {
                technician.FullName = "Administrator";
                technician.EmailConfirmed = true;

                await userManager.UpdateAsync(technician);

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

        var requester =
            await userManager.FindByEmailAsync(
                "requester@university.local");

        if (requester != null)
        {
            requester.FullName = "Nora Alharbi";

            await userManager.UpdateAsync(requester);

            if (!await userManager.IsInRoleAsync(
                    requester,
                    "Requester"))
            {
                await userManager.AddToRoleAsync(
                    requester,
                    "Requester");
            }
        }
    }
}