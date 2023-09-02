namespace Workneering.Settings.Application.Queries.GetCountries
{
    public class CountriesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Capital { get; set; }
        public string NativeName { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string Description { get; set; }
        public decimal Area { get; set; }
        public string CallingCode { get; set; }
        public bool IsActive { get; set; }
    }
}