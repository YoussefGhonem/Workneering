using Workneering.Base.Domain.Common;

namespace Workneering.Project.Domain.Entities
{
    public record ProjectActivity : BaseEntity
    {
        private string _title;
        private string? _description;

        public ProjectActivity(string title, string description = null)
        {
            _description = description;
            Title = title;
        }

        public string Title { get => _title; private set => _title = value; }
        public string? Description { get => _description; private set => _description = value; }

    }
}
