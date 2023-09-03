namespace Workneering.User.Application.Services.Models
{
    public class UserAddressDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
