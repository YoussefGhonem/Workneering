using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Project.Application.Services.DbQueryService;

namespace Workneering.Project.Application.Commands.CreateProposal
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<CreateProposalCommand, Unit>
    {
        private readonly ProjectsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }
        public async Task<Unit> Handle(CreateProposalCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Projects
                .Include(x => x.Proposals)
                .FirstOrDefault(x => x.Id == request.ProjectId);

            query.AddProposal(CurrentUser.Id, request.CoverLetter, request.ProposalDuration, request.TotalBid, request.HourlyRate);
            _context.Projects.Attach(query);
            _context?.SaveChangesAsync(cancellationToken);

            await _dbQueryService.AddRoom(CurrentUser.Id.Value, query.ClientId.Value);
            return Unit.Value;
        }
    }
}
