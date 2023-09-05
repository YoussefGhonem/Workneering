namespace Workneering.User.Application.Queries.Client.GetClientCategorization
{
    public class ClientCategorizationDto
    {
        public List<Guid> CategoryIds { get; set; }
        public List<Guid> SubCategoryIds { get; set; }
        public List<Guid> SkillIds { get; set; }

    }

}
