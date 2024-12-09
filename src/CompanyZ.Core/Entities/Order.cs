using CompanyZ.Core.Enums;

namespace CompanyZ.Core.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public int AddressId { get; set; }
    public Address DeliveryAddress { get; set; } = default!;
    public decimal PointsSpent { get; set; }
}