using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.DeleteEmploymentHistory
{
    public class DeleteEmploymentHistoryCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
