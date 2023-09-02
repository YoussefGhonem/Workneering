using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Certification.DeleteCertification
{
    public class DeleteCertificationHandler : IRequestHandler<DeleteCertificationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public DeleteCertificationHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(DeleteCertificationCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Certifications).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query.RemoveCertification(request.Id);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
