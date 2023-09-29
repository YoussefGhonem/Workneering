using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects.Filters;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectClientBasicDetails;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects
{
    public class GetClientProjectsQueryHandler : IRequestHandler<GetClientProjectsQuery, PaginationResult<ClientProjectsDto>>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetClientProjectsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<ClientProjectsDto>> Handle(GetClientProjectsQuery request, CancellationToken cancellationToken)
        {

            var projects = await _context.Projects.Where(x => x.ClientId == CurrentUser.Id)
                .Include(x => x.Proposals)
                .AsQueryable()
                .Filter(request)
                .OrderBy(x => x.CreatedDate)
                .PaginateAsync(request.PageSize, request.PageNumber);
            var result = projects.list.ToList();
            var data = new List<ClientProjectsDto>();

            foreach (var project in projects.list)
            {
                var projectDto = project.Adapt<ClientProjectsDto>();

                // Count the number of proposals for the project
                projectDto.NumberOfProposals = project.Proposals.Count;

                if (projectDto.AssginedFreelancerId != null)
                {
                    var userInfo = await _dbQueryService.GetFreelancerInfo(projectDto.AssginedFreelancerId.Value);
                    projectDto.AssginedFreelancer = new AssginedFreelancerDto
                    {
                        FreelancerId = projectDto.AssginedFreelancerId.Value,
                        CountryName = userInfo.CountryName,
                        Name = userInfo.Name,
                        Title = userInfo.Title
                    };
                }

                // Populate the proposals for the project
                projectDto.Proposals = new List<ClientProposalsDto>();

                foreach (var proposal in project.Proposals)
                {
                    var userInfo = await _dbQueryService.GetFreelancerInfo(proposal.FreelancerId!.Value);
                    var clientProposalDto = new ClientProposalsDto
                    {
                        FreelancerDetails = new SubmittedOffersDto
                        {
                            FreelancerId = proposal.FreelancerId,
                            Name = userInfo.Name,
                            CountryName = userInfo.CountryName,
                            Title = userInfo.Title
                        },
                        CoverLetter = proposal.CoverLetter,
                        TotalBid = proposal.TotalBid,
                        ProposalDuration = proposal.ProposalDuration,
                        ProposalStatus = proposal.ProposalStatus
                    };
                    projectDto.Proposals.Add(clientProposalDto);
                }

                data.Add(projectDto);
            }

            return new PaginationResult<ClientProjectsDto>(data.ToList(), projects.total);

        }
    }
}
