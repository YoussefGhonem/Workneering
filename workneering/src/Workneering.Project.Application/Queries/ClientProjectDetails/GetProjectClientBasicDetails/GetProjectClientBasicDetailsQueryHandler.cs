using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Models;
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
            var project = _context.Projects.Include(x => x.Proposals).FirstOrDefault(x => x.Id == request.ProjectId);
            var result = project?.Adapt<ProjectClientBasicDetailsDto>();

            if (!project.Proposals.Any())
                return result;
            foreach (var proposal in project.Proposals)
            {
                var userInfo = await _dbQueryService.GetFreelancerInfo(proposal.FreelancerId!.Value);
                result.SubmittedOffers.Add(new SubmittedOffersDto
                {
                    FreelancerId = proposal.FreelancerId,
                    Name = userInfo.Name,
                    CountryName = userInfo.CountryName,
                    Title = userInfo.Title
                });
            }

            foreach (var proposal in project.Proposals)
            {
                var userInfo = await _dbQueryService.GetFreelancerInfo(proposal.FreelancerId!.Value);
                result.Proposals.Add(new ClientProposalsDto
                {
                    FreelancerDetails = new SubmittedOffersDto
                    {
                        FreelancerId = proposal.FreelancerId,
                        Name = userInfo.Name,
                        CountryName = userInfo.CountryName,
                        Title = userInfo.Title
                    },
                    CoverLetter = proposal.CoverLetter,
                    HourlyRate = proposal.HourlyRate,
                    ProposalDuration = proposal.ProposalDuration,
                    ProposalStatus = proposal.ProposalStatus
                });
            }

            return result;
        }
    }
}
