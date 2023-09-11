using MediatR;
using Workneering.Base.Helpers.Enums;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientBasicDetails
{
    public class UpdateClientBasicDetailsCommand : IRequest<Unit>
    {
        public Guid? CategoryId { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? TitleOverview { get; set; }
        public Guid? CountryId { get; set; } 
    }
}
