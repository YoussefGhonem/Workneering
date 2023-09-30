using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.UpdatePortfolio
{
    public class UpdateFreelancerPortfolioCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid? Id { get; set; }
        public string ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public List<string> ImageKyes { get; set; }
        public List<IFormFile>? PortfolioFiles { get; set; }

    }

}
