using MediatR;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhoIAm
{
    public class UpdateClientWhoIAmCommand : IRequest<Unit>
    {
        public string WhoIAm { get; set; }

    }
}
