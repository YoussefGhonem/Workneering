using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workneering.User.Domain.Entites;
using Workneering.User.Domain.Enums;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Helpr
{
    public class CompanyPercentageFields
    {
        public string? Name { get; set; }
        public string? Description { get; set ; }
        public string? WhoAreWe { get; set; }
        public string? WhatDoWeDo { get; set; }
        public bool IsCountainCountry { get; set; }
        public DateTimeOffset? FoundedIn { get; set; }
        public CompanySizeEnum? CompanySize { get; set; }
        public Guid? IndustryId { get; set; }
    }
}
