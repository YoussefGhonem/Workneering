using MediatR;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientDescription
{
    public class UpdateClientDescriptionCommand : IRequest<Unit>
    {
        public string OverviewDescription { get; set; }

    }
}
