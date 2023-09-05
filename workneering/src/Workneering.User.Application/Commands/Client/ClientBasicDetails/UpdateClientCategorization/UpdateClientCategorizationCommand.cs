using MediatR;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientCategorization
{
    public class UpdateClientCategorizationCommand : IRequest<Unit>
    {
        public List<Guid> CategoryIds { get; set; }
        public List<Guid> SubCategoryIds { get; set; }
        public List<Guid> SkillIds { get; set; }

    }

}
