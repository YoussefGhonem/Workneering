using Workneering.Shared.Core.Models;
using Workneering.User.Domain.Entites;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetFreelancerPortfolios
{
    public class FreelancerPortfolioDto
    {
        public Guid Id { get; set; }
        public string ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public List<ImageDetailsDto> PortfolioFiles { get; set; }
    }
    public class ImageDetailsDto
    {
        public string? Url { get; set; }
        public string? Key { get; set; }
        public string? FileName { get; set; }
    }

    public class PortfolioFileDto
    {
        public ImageDetailsDto? FileDetails { get; set; }

    }

}
