using System.ComponentModel.DataAnnotations;

namespace UniversityServiceDesk.Models;

public class ServiceRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Requester name is required")]
    public string RequesterName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Issue title is required")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;

    public string Priority { get; set; } = "Medium";

    public string Status { get; set; } = "New";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

