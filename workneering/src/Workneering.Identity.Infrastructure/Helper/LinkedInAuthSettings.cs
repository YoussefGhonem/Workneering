using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workneering.Identity.Infrastructure.Helper
{
    public class LinkedInAuthSettings
    {
        public const string SectionName = "LinkedInAuth";
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; } = null!;
    }
}
