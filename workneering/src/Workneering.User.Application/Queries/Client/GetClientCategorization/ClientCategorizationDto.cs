using Workneering.User.Application.Queries.Company.GetCompanyCategorization;

namespace Workneering.User.Application.Queries.Client.GetClientCategorization
{
    public class ClientCategorizationDto
    {
		public List<LookupDto> Categories { get; set; } = new();
		public List<LookupDto> SubCategories { get; set; } = new();
		public List<LookupDto> Skills { get; set; } = new();

	}
	public record LookupDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}

}
