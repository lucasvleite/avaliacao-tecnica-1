namespace CompanyZ.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal PointsRequired { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public int SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; } = default!;
}