using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Commands.CreateProposal
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<CreateProposalCommand, Unit>
    {
        private readonly ProjectsDbContext _context;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProposalCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Projects
                .Include(x => x.Proposals)
                .FirstOrDefault(x => x.Id == request.ProjectId);

            query.AddProposal(CurrentUser.Id, request.CoverLetter, request.ProposalDuration, request.TotalBid, request.HourlyRate);
            _context.Projects.Attach(query);
            _context?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
