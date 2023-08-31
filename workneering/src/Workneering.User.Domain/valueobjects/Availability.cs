using Workneering.User.Domain.Enums;

namespace Workneering.User.Domain.valueobjects
{
    public class Availability
    {
        public HoursPerWeekEnum HoursPerWeek { get; set; }
        public DateTimeOffset? DateForNewWork { get; set; } // if Hours Per Week is None
        public bool ContractToHire { get; set; } = false;
    }
}
