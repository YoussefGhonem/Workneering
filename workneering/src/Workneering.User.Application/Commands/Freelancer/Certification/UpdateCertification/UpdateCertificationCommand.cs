﻿using MediatR;
using System.Text.Json.Serialization;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Certification.UpdateCertification
{
    public class UpdateCertificationCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PassedDate { get; set; }
    }
}