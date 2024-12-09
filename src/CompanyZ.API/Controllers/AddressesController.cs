using CompanyZ.Core.Entities;
using CompanyZ.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyZ.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AddressesController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetUserAddresses()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var addresses = await _context.Addresses
            .Where(a => a.UserId == userId)
            .ToListAsync();

        return Ok(addresses);
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress(AddressModel model)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        
        var address = new Address
        {
            Street = model.Street,
            Number = model.Number,
            Complement = model.Complement,
            Neighborhood = model.Neighborhood,
            City = model.City,
            State = model.State,
            ZipCode = model.ZipCode,
            UserId = userId!
        };

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserAddresses), new { id = address.Id }, address);
    }
}

public class AddressModel
{
    public string Street { get; set; } = default!;
    public string Number { get; set; } = default!;
    public string Complement { get; set; } = default!;
    public string Neighborhood { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
}