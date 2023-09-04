using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.Category.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public Guid? CategoryId { get; set; }
    }
}
