using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateCountry
{
    public class UpdateCountryCommand : IRequest<Unit>
    {
        public Guid CountryId { get; set; }

    }
}
