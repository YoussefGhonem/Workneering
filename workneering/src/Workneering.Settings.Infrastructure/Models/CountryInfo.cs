namespace Workneering.Settings.Infrastructure.Models
{
    public class CountryInfo
    {
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string Capital { get; set; }
        public string Subregion { get; set; }
        public string NativeName { get; set; }
        public string Area { get; set; }
        public CountryInfoApi_Flag Flags { get; set; }
        public List<CountryInfoApi_Currency> Currencies { get; set; }
        public List<CountryInfoApi_Language> Languages { get; set; }
        public List<string> CallingCodes { get; set; }
    }

    public class CountryInfoApi_Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
    }

    public class CountryInfoApi_Language
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
    }

    public class CountryInfoApi_Flag
    {
        public string SVG { get; set; }
        public string PNG { get; set; }
    }
}