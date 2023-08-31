using Workneering.User.Domain.Enums;

namespace Workneering.User.Domain.valueobjects
{
    public class VideoIntroduction
    {
        public string? LinkYoutube { get; set; }
        public TypeOfVideoEnum? TypeOfVideo { get; set; }
    }
}
