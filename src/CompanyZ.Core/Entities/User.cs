using Microsoft.AspNetCore.Identity;

namespace CompanyZ.Core.Entities;

public class User : IdentityUser
{
    public string Name { get; set; } = default!;
    public decimal Points { get; set; }
    public List<Address> Addresses { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<PointTransaction> PointTransactions { get; set; } = new();
}