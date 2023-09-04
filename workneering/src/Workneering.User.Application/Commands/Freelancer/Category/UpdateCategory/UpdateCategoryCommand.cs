using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.Category.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid? CategoryId { get; set; }

    }
}
