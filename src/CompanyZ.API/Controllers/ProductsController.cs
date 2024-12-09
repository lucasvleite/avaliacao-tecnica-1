using CompanyZ.Core.Entities;
using CompanyZ.Core.Enums;
using CompanyZ.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyZ.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] int? categoryId, [FromQuery] int? subCategoryId)
    {
        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.SubCategory)
            .AsQueryable();

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId);

        if (subCategoryId.HasValue)
            query = query.Where(p => p.SubCategoryId == subCategoryId);

        var products = await query.ToListAsync();
        return Ok(products);
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Categories
            .Include(c => c.SubCategories)
            .ToListAsync();
        return Ok(categories);
    }

    [HttpPost("redeem")]
    public async Task<IActionResult> RedeemProduct(RedeemModel model)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var user = await _context.Users.FindAsync(userId);
        var product = await _context.Products.FindAsync(model.ProductId);
        var address = await _context.Addresses.FindAsync(model.AddressId);

        if (user == null || product == null || address == null)
            return NotFound();

        if (user.Points < product.PointsRequired)
            return BadRequest("Insufficient points");

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            user.Points -= product.PointsRequired;

            var order = new Order
            {
                UserId = userId!,
                ProductId = product.Id,
                AddressId = address.Id,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                PointsSpent = product.PointsRequired
            };

            var pointTransaction = new PointTransaction
            {
                UserId = userId!,
                Points = -product.PointsRequired,
                Date = DateTime.UtcNow,
                Description = $"Product redemption: {product.Name}",
                Type = TransactionType.Spent
            };

            _context.Orders.Add(order);
            _context.PointTransactions.Add(pointTransaction);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new { OrderId = order.Id });
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}

public class RedeemModel
{
    public int ProductId { get; set; }
    public int AddressId { get; set; }
}