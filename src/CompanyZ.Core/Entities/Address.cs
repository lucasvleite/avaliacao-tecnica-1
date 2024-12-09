namespace CompanyZ.Core.Entities;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = default!;
    public string Number { get; set; } = default!;
    public string Complement { get; set; } = default!;
    public string Neighborhood { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string ZipCode { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
}