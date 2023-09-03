using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetCertifications
{
    public class GetCertificationsQuery : IRequest<List<CertificationListDto>>
    {
    }
}
