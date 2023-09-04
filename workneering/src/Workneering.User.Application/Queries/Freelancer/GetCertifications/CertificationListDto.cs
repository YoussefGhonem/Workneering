﻿namespace Workneering.User.Application.Queries.Freelancer.GetCertifications
{
    public class CertificationListDto
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        public string? AwardAreaOfStudy { get; set; }
        public string? GivenBy { get; set; }
        public string? Licence { get; set; }
    }
}
