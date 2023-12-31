﻿using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetLanguages
{
    public class GetLanguagesQuery : IRequest<List<LanguagesListDto>>
    {

        public Guid? FreelancerId { get; set; }
    }
}
