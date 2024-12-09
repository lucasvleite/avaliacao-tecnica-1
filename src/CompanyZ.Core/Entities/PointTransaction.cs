using CompanyZ.Core.Enums;

namespace CompanyZ.Core.Entities;

public class PointTransaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Points { get; set; }
    public string Description { get; set; } = default!;
    public TransactionType Type { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}