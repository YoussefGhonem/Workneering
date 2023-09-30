using Workneering.Base.Domain.Common;

namespace Workneering.Project.Domain.Entities
{
    public record ProjectActivity : BaseEntity
    {
        private string _title;
        private string? _description;
        private string? _classStyleName; //color1:green,color2:black, color3:red , color4:baby blue , color5:orange , color6:mauve

        public ProjectActivity(string title, string description = null, string classStyleName = null)
        {
            _title = title;
            _description = description;
            _classStyleName = classStyleName;
        }
        public ProjectActivity()
        {

        }
        public string Title { get => _title; private set => _title = value; }
        public string? ClassStyleName { get => _classStyleName; private set => _classStyleName = value; }
        public string? Description { get => _description; private set => _description = value; }

    }
}
