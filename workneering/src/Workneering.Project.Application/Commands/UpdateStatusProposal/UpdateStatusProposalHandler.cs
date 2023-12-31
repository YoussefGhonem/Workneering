﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Domain.Enums;
using Workneering.Project.Infrastructure.Persistence;

namespace Workneering.Project.Application.Commands.UpdateStatusProposal
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateStatusProposalCommand, Unit>
    {
        private readonly ProjectsDbContext _context;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateStatusProposalCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Projects
                .Include(x => x.Proposals)
                .FirstOrDefault(x => x.Id == request.ProjectId);

            if (request.Status == ProposalStatusEnum.Accepted)
            {
                query.AcceptProposal(request.ProposalId);
                query.SetAssginedFreelancerId(request.AssginedFreelancerId);
            }
            else if (request.Status == ProposalStatusEnum.Rejected)
            {
                query.RejectedProposal(request.ProposalId);
            }
            _context.Projects.Attach(query);
            _context?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
