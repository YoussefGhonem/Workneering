﻿using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class GetFreelancerBasicDetailsQuery : IRequest<FreelancerBasicDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
