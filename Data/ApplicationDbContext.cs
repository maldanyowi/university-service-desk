using Microsoft.EntityFrameworkCore;
using UniversityServiceDesk.Models;

namespace UniversityServiceDesk.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ServiceRequest> ServiceRequests { get; set; }
}


