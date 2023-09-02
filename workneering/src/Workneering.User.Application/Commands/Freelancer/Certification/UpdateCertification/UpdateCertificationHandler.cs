using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Certification.UpdateCertification
{
    public class UpdateCertificationHandler : IRequestHandler<UpdateCertificationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateCertificationHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateCertificationCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Certifications).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.Certification>();
            query.UpdateCertification(request.Id, result);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
