using System.Xml.Linq;
using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities.Refrences
{
    public record Specialty : RefrenceEntity
    {
        public Specialty(string name) : base(name) { }

    }
}
