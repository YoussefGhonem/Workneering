namespace Workneering.Settings.Domain.Entities
{
    public class Language
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NativeName { get; set; }

        public Language(string? code, string? name, string? nativeName)
        {
            Code = code;
            Name = name;
            NativeName = nativeName;
        }
    }
}
