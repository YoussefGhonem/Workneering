using MediatR;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyCategorization
{
    public class UpdateCompanyCategorizationCommand : IRequest<Unit>
    {
        public List<Guid> CategoryIds { get; set; }
        public List<Guid> SubCategoryIds { get; set; }
        public List<Guid> SkillIds { get; set; }

    }

}
