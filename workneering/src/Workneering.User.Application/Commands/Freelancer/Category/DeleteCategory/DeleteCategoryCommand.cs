using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Category.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
