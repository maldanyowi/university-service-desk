using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniversityServiceDesk.Models;

public class ServiceRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Requester name is required")]
    [StringLength(100)]
    public string RequesterName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    [StringLength(100)]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Issue title is required")]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    public string Priority { get; set; } = "Medium";

    public string Status { get; set; } = "New";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? UserId { get; set; }

    public IdentityUser? User { get; set; }
}