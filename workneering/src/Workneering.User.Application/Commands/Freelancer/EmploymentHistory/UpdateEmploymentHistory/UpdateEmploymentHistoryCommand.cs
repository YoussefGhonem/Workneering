using MediatR;
using System.Text.Json.Serialization;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.UpdateEmploymentHistory
{
    public class UpdateEmploymentHistoryCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Role { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
    }
}
