namespace Workneering.User.Application.Queries.Company.GetCompanyCategorization
{
    public class CompanyCategorizationDto
    {
        public List<Guid> CategoryIds { get; set; }
        public List<Guid> SubCategoryIds { get; set; }
        public List<Guid> SkillIds { get; set; }

    }

}
