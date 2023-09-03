namespace Workneering.Identity.Domain.Entities.ValueObjects
{
    public class UserAddress
    {
        public Guid CountryId { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; } // Street
    }
}
