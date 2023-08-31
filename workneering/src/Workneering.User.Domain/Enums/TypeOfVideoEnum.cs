using System.ComponentModel;

namespace Workneering.User.Domain.Enums
{
    public enum TypeOfVideoEnum
    {
        [Description("Me talking about my skills and experience")]
        SkillsAndExperience = 1,
        [Description("Visual samples of my work")]
        Work = 2,
        [Description("Something else")]
        SomethingElse = 3,

    }
}
