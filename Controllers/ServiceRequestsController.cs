using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityServiceDesk.Data;
using UniversityServiceDesk.Models;

namespace UniversityServiceDesk.Controllers;

[Authorize]
public class ServiceRequestsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ServiceRequestsController(
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Requesters see their own requests.
    // Technicians see all requests.
    public async Task<IActionResult> Index(
        string? searchString,
        string? status)
    {
        var requests =
            _context.ServiceRequests.AsQueryable();

        if (!User.IsInRole("Technician"))
        {
            var userId = _userManager.GetUserId(User);

            requests = requests.Where(
                request => request.UserId == userId);
        }

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            requests = requests.Where(request =>
                request.RequesterName.Contains(searchString) ||
                request.Department.Contains(searchString) ||
                request.Title.Contains(searchString));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            requests = requests.Where(
                request => request.Status == status);
        }

        return View(await requests
            .OrderByDescending(request => request.CreatedAt)
            .ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var serviceRequest =
            await _context.ServiceRequests
                .FirstOrDefaultAsync(
                    request => request.Id == id);

        if (serviceRequest == null)
        {
            return NotFound();
        }

        if (!CanAccess(serviceRequest))
        {
            return Forbid();
        }

        return View(serviceRequest);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("RequesterName,Department,Title,Description")]
        ServiceRequest serviceRequest)
    {
        if (ModelState.IsValid)
        {
            serviceRequest.Priority = "Medium";
            serviceRequest.Status = "New";
            serviceRequest.CreatedAt = DateTime.Now;
            serviceRequest.UserId =
                _userManager.GetUserId(User);

            _context.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(serviceRequest);
    }

    [Authorize(Roles = "Technician")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var serviceRequest =
            await _context.ServiceRequests.FindAsync(id);

        if (serviceRequest == null)
        {
            return NotFound();
        }

        return View(serviceRequest);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Technician")]
    public async Task<IActionResult> Edit(
        int id,
        ServiceRequest serviceRequest)
    {
        if (id != serviceRequest.Id)
        {
            return NotFound();
        }

        var existingRequest =
            await _context.ServiceRequests.FindAsync(id);

        if (existingRequest == null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            existingRequest.RequesterName =
                serviceRequest.RequesterName;

            existingRequest.Department =
                serviceRequest.Department;

            existingRequest.Title =
                serviceRequest.Title;

            existingRequest.Description =
                serviceRequest.Description;

            existingRequest.Priority =
                serviceRequest.Priority;

            existingRequest.Status =
                serviceRequest.Status;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(serviceRequest);
    }

    [Authorize(Roles = "Technician")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var serviceRequest =
            await _context.ServiceRequests
                .FirstOrDefaultAsync(
                    request => request.Id == id);

        if (serviceRequest == null)
        {
            return NotFound();
        }

        return View(serviceRequest);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Technician")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var serviceRequest =
            await _context.ServiceRequests.FindAsync(id);

        if (serviceRequest != null)
        {
            _context.ServiceRequests.Remove(serviceRequest);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool CanAccess(ServiceRequest serviceRequest)
    {
        if (User.IsInRole("Technician"))
        {
            return true;
        }

        var userId = _userManager.GetUserId(User);

        return serviceRequest.UserId == userId;
    }
}