using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairRequestApi.Data;
using RepairRequestApi.Models;
using System.Security.Claims;

namespace RepairRequestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepairTicketsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RepairTicketsController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(RepairTicket ticket)
    {
        var userId = int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!
        );

        ticket.UserId = userId;

        _context.RepairTickets.Add(ticket);

        await _context.SaveChangesAsync();

        return Ok(ticket);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _context.RepairTickets
            .ToListAsync();

        return Ok(tickets);
    }

    [Authorize(Roles = "Technician")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        RepairTicket updated
    )
    {
        var ticket = await _context.RepairTickets.FindAsync(id);

        if (ticket == null)
        {
            return NotFound();
        }

        ticket.Status = updated.Status;

        await _context.SaveChangesAsync();

        return Ok(ticket);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ticket = await _context.RepairTickets.FindAsync(id);

        if (ticket == null)
        {
            return NotFound();
        }

        _context.RepairTickets.Remove(ticket);

        await _context.SaveChangesAsync();

        return Ok();
    }
}
