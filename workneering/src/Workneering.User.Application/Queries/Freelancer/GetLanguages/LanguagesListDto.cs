namespace Workneering.User.Application.Queries.Freelancer.GetLanguages
{
    public class LanguagesListDto
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
    }
}
