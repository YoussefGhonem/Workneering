namespace Workneering.Base.Domain.Common
{
    public record RefrenceEntity : BaseEntity
    {
        public RefrenceEntity(string name)
        {
            Name = name;
        }

        public string Description { get; private set; }
        public string Name { get; private set; }

        public void UpdateName(string field)
        {
            Name = field;
        }
        public void UpdateDescription(string field)
        {
            Description = field;
        }
    }
}
