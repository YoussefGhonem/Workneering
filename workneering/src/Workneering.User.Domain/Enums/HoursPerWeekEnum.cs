using System.ComponentModel;

namespace Workneering.User.Domain.Enums
{
    public enum HoursPerWeekEnum
    {
        [Description("More than 30 hrs/week")]
        MoreThan30hr = 1,
        [Description("Less than 30 hrs/week")]
        LessThan30hr = 2,
        [Description("As needed - open to offers")]
        OpenToOffers = 3,
        [Description("None")]
        None = 4,
    }
}
