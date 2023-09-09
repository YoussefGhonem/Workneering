namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategorization
{
    public class FreelancerCategorizationDto
    {
        public List<Guid> CategoryIds { get; set; }
        public List<Guid> SubCategoryIds { get; set; }
        public List<Guid> SkillIds { get; set; }
    }
}
