using MediatR;

namespace Workneering.User.Application.Queries.Company.GetCompanyCategorization
{
    public class GetCompanyCategorizationQuery : IRequest<CategorizationDto>
    {
        public Guid CompanyId { get; set; }
    }
}
