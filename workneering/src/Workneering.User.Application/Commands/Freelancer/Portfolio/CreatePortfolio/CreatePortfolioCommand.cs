using MediatR;
using Microsoft.AspNetCore.Http;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.CreatePortfolio
{
    public class CreatePortfolioCommand : IRequest<Unit>
    {
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public List<IFormFile>? PortfolioFiles { get; set; }

    }
}
