using MediatR;
using Mapster;
using Workneering.User.Infrastructure.Persistence;
using Workneering.Base.Application.GlobalExceptions;
using Microsoft.EntityFrameworkCore;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerEducationDetails
{
    public class UpdateFreelancerEducationDetailsHandler : IRequestHandler<UpdateFreelancerEducationDetailsCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateFreelancerEducationDetailsHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateFreelancerEducationDetailsCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return new Unit();

            var query = _userDatabaseContext.Freelancers.Include(x => x.Educations).FirstOrDefault(x => x.Id == request.Id);
            var result = query!.Educations.Adapt<Unit>();
            return result;
        }
    }
}
