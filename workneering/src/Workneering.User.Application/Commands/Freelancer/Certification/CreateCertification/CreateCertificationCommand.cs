﻿using MediatR;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Certification.CreateCertification
{
    public class CreateCertificationCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string AwardAreaOfStudy { get; set; }
        public string GivenBy { get; set; }
        public string? Licence { get; set; }
        public Microsoft.AspNetCore.Http.IFormFile? CertifictionFile { get; set; }

    }
}
