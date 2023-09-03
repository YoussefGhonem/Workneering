using MediatR;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateWhoAreWe
{
    public class UpdateWhoAreWeCommand : IRequest<Unit>
    {
        public string WhoAreWe { get; set; }

    }
}
