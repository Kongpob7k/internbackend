using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairRequestApi.Data;

namespace RepairRequestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var totalTickets = await _context.RepairTickets.CountAsync();
        var pendingTickets = await _context.RepairTickets.CountAsync(t => t.Status == "Pending");
        var completedTickets = await _context.RepairTickets.CountAsync(t => t.Status == "Completed");
        var totalUsers = await _context.Users.CountAsync();

        return Ok(new
        {
            TotalTickets = totalTickets,
            PendingTickets = pendingTickets,
            CompletedTickets = completedTickets,
            TotalUsers = totalUsers
        });
    }
}