﻿using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetEmploymentHistory
{
    public class GetEmploymentHistoryQuery : IRequest<List<EmploymentHistoryDto>>
    {
    }
}
