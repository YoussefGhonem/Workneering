using Workneering.Base.Domain.Common;

namespace Workneering.Settings.Domain.Entities
{
    public record Country : BaseEntity
    {
        #region Private members

        private string _name;
        private string? _description;
        private string _flag;
        private string? _alpha2Code;
        private string? _alpha3Code;
        private string? _currency;
        private string? _language;
        private decimal? _area;
        private string? _nativeName;
        private string? _capital;
        private string? _callingCode;
        private bool _isActive;

        #endregion

        #region CTOR

        private Country()
        {
        }

        public Country(string name, string? callingCode, string? description, string flag, string? alpha2Code,
            string? alpha3Code,
            string? currency, string? language, decimal? area, string? nativeName, string? capital)
        {
            _name = name;
            _description = description;
            _flag = flag;
            _alpha2Code = alpha2Code;
            _alpha3Code = alpha3Code;
            _currency = currency;
            _language = language;
            _area = area;
            _nativeName = nativeName;
            _capital = capital;
            _callingCode = callingCode;
            _isActive = true;
        }

        #endregion

        #region Public setters

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string? CallingCode

        {
            get => _callingCode;
            private set => _callingCode = value;
        }

        public string? Description
        {
            get => _description;
            private set => _description = value;
        }

        public string? Capital
        {
            get => _capital;
            private set => _capital = value;
        }

        public string Flag
        {
            get => _flag;
            private set => _flag = value;
        }

        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }

        public string? Alpha2Code
        {
            get => _alpha2Code;
            private set => _alpha2Code = value;
        }

        public string? Alpha3Code
        {
            get => _alpha3Code;
            private set => _alpha3Code = value;
        }

        public string? NativeName
        {
            get => _nativeName;
            private set => _nativeName = value;
        }

        public string? Currency
        {
            get => _currency;
            private set => _currency = value;
        }

        public string? Language
        {
            get => _language;
            private set => _language = value;
        }

        public decimal? Area
        {
            get => _area;
            private set => _area = value;
        }

        #endregion
    }
}