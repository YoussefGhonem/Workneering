using MediatR;

namespace Workneering.User.Application.Queries.Company.GetCompanyCategorization
{
    public class GetCompanyCategorizationQuery : IRequest<CompanyCategorizationDto>
    {
        public Guid CompanyId { get; set; }
    }
}
