namespace CompanyZ.Core.Entities;

public class SubCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public List<Product> Products { get; set; } = new();
}