using MediatR;
using Mapster;
using Workneering.User.Infrastructure.Persistence;
using Workneering.Base.Application.GlobalExceptions;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateFreelancerBasicDetailsommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateFreelancerBasicDetailsommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return Unit.Value;

            var query = _userDatabaseContext.Freelancers.FirstOrDefault(x => x.Id == request.Id);
            var result = query.Adapt<Unit>();
            return result;
        }
    }
}
