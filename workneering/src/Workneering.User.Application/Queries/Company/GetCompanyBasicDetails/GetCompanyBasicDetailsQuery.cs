﻿using MediatR;

namespace Workneering.User.Application.Queries.Company.GetCompanyBasicDetails
{
    public class GetCompanyBasicDetailsQuery : IRequest<CompanyBasicDetailsDto>
    {
        public Guid CompanyId { get; set; }
    }
}
