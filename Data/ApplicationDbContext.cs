using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityServiceDesk.Models;

namespace UniversityServiceDesk.Data;

public class ApplicationDbContext
    : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ServiceRequest> ServiceRequests { get; set; }
}

