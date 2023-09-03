﻿using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetExperiences
{
    public class GetExperiencesQuery : IRequest<List<FreelancerExperienceDto>>
    {
    }
}
