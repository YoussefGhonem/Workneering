using MediatR;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateWhatDoWeDo
{
    public class UpdateWhatDoWeDoCommand : IRequest<Unit>
    {
        public string WhatDoWeDo { get; set; }

    }
}
