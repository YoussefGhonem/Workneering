using MediatR;
using System.Text.Json.Serialization;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Education.UpdateEducation
{
    public class UpdateEducationCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public int YearAttended { get; set; }
        public int YearGraduated { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }
    }
}
