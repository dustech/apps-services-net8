namespace NorthWind.Console.PSqlClient;

public record Supplier
{
    public Supplier(short supplierId,
        string companyName,
        string city,
        string country)
    {
        this.SupplierId = supplierId;
        this.CompanyName = companyName;
        this.City = city;
        this.Country = country;
    }

    public short SupplierId { get; init; }
    public string CompanyName { get; init; }
    public string City { get; init; }
    public string Country { get; init; }

    public void Deconstruct(out int supplierId, out string companyName,
        out string city, out string country)
    {
        supplierId = SupplierId;
        companyName = CompanyName;
        city = City;
        country = Country;
    }
}