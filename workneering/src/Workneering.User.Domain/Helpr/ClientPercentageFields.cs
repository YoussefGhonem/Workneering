using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workneering.Base.Helpers.Enums;
using Workneering.User.Domain.Entites;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Helpr
{
    public class ClientPercentageFields
    {
        public string? Name { get; set; }
        public string? OverviewDescription { get; set; }   
        public string? WhoIAm {  get; set; }   
        public string? whatDoIdo { get; set; }
        public string? TitleOverview { get; set; }
        public string? Title {  get; set; }
        public bool _isCountainCountry { get; set; }
    }
}
