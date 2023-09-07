namespace Workneering.Settings.Infrastructure.Models
{
    public class CategoriesDto
    {
        public string? Name { get; set; }
        public List<SubCategoriesDto> Subcategories { get; set; }
    }
    public class SubCategoriesDto
    {
        public string? Name { get; set; }
        public List<SkillsDto> Skills { get; set; }

    }
    public class SkillsDto
    {
        public string? Name { get; set; }
    }
}
