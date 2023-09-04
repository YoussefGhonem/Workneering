namespace Workneering.User.Application.Services.Models
{
    public class UserBasicInfo
    {
        public Guid CountryId { get; set; }
    }

    public class UserAddressDetailsDto
    {
        public Guid? CountryId { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Address { get; set; } // Street
    }
}
