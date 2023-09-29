using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectClientBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetProjectClientBasicDetailsQuery, ProjectClientBasicDetailsDto>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext dbContext, IDbQueryService dbQueryService)
        {
            _context = dbContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<ProjectClientBasicDetailsDto> Handle(GetProjectClientBasicDetailsQuery request, CancellationToken cancellationToken)
        {
            var project = _context.Projects.Include(x => x.Proposals)
                .Include(x => x.Proposals)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .Include(x => x.Skills)
                .FirstOrDefault(x => x.Id == request.ProjectId);

            var result = project?.Adapt<ProjectClientBasicDetailsDto>();

            if (project == null || !project.Proposals.Any())
            {
                return result;
            }

            foreach (var proposal in project.Proposals)
            {
                var userInfo = await _dbQueryService.GetFreelancerInfo(proposal.FreelancerId!.Value);
                var freelancerImage = await _dbQueryService.GetFreelancerImage(proposal.FreelancerId.Value);

                var submittedOffer = new SubmittedOffersDto
                {
                    FreelancerId = proposal.FreelancerId,
                    Name = userInfo.Name,
                    CountryName = userInfo.CountryName,
                    Title = userInfo.Title,
                    ImageUrl = freelancerImage.Url,
                };
                result.SubmittedOffers.Add(submittedOffer);
            }

            result.NumberOfProposals = project.Proposals.Count;
            return result;
        }


    }
}
