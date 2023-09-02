namespace Workneering.Base.Domain.ValueObjects;

public class AddressDto
{
    public AddressCountryDto Country { get; set; } = new();
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
}

public class AddressCountryDto
{
    public Guid? CountryId { get; set; }
    public string? Name { get; set; }
    public string? Flag { get; set; }
}