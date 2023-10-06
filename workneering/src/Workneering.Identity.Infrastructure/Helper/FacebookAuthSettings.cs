using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workneering.Identity.Infrastructure.Helper
{
    public class FacebookAuthSettings
    {
        public const string SectionName = "FaceBookAuth";
        public string AppId { get; set; } = null!;
        public string AppSecret { get; set; } = null!;
    }
}
