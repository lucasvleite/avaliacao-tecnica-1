using CompanyZ.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyZ.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PointsController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet("balance")]
    public async Task<IActionResult> GetBalance()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        return Ok(new { Balance = user?.Points ?? 0 });
    }

    [HttpGet("transactions")]
    public async Task<IActionResult> GetTransactions()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var transactions = await _context.PointTransactions
            .Where(pt => pt.UserId == userId)
            .OrderByDescending(pt => pt.Date)
            .ToListAsync();

        return Ok(transactions);
    }
}