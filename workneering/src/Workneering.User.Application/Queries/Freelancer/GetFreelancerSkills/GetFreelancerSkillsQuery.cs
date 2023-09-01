﻿using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerSkills
{
    public class GetFreelancerSkillsQuery : IRequest<List<FreelancerSkillDto>>
    {
        public Guid Id { get; set; }
    }
}
