using Workneering.Base.Domain.Common;
using Workneering.User.Domain.Enums;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Entites
{
    public record Company : BaseEntity
    {
        private string? _name;
        private string? _overviewDescription;
        private string? _websiteLink;
        private string? _titleOverview;
        private string? _title;
        private string? _vatId;
        private string? _whoAreWe;
        private string? _whatDoWeDo;
        private int? _numOfReviews; // 100 clients for example
        private decimal? _reviews; // 4.3 of 5 stars
        private DateTimeOffset? _foundedIn;
        private CompanySizeEnum? _companySize;
        private ReviewersStars? _reviewersStars;
        private List<CompanyCategory>? _categories = new();

        public Company(Guid id, string? name)
        {
            Id = id;
            _name = name;
        }
        public Company()
        {

        }

        #region Public fields
        public string? Name { get => _name; set => _name = value; }
        public string? VatId { get => _vatId; set => _vatId = value; }
        public string? Description { get => _overviewDescription; set => _overviewDescription = value; }
        public string? WebsiteLink { get => _websiteLink; set => _websiteLink = value; }
        public string? TitleOverview { get => _titleOverview; set => _titleOverview = value; }
        public string? WhoAreWe { get => _whoAreWe; set => _whoAreWe = value; }
        public string? WhatDoWeDo { get => _whatDoWeDo; set => _whatDoWeDo = value; }
        public string? Title { get => _title; set => _title = value; }
        public int? NumOfReviews { get => _numOfReviews; set => _numOfReviews = value; }
        public decimal? Reviews { get => _reviews; private set => _reviews = value; }

        public DateTimeOffset? FoundedIn { get => _foundedIn; set => _foundedIn = value; }

        public CompanySizeEnum? CompanySize { get => _companySize; set => _companySize = value; }

        public ReviewersStars? ReviewersStars { get => _reviewersStars; set => _reviewersStars = value; }
        public List<CompanyCategory>? Categories => _categories;


        #endregion

        #region Public Methods

        public void UpdateCategory(Guid? categoryId)
        {
            _categories.FirstOrDefault().UpdateCategoryId(categoryId.Value);

        }
        #region Basic Details
        public void UpdateWhoAreWe(string? field)
        {
            _whoAreWe = field;
        }
        public void UpdateVatId(string? field)
        {
            _vatId = field;
        }
        public void UpdateName(string? field)
        {
            _name = field;
        }
        public void UpdateCompanySize(CompanySizeEnum? field)
        {
            _companySize = field;
        }

        public void UpdateFoundedIn(DateTimeOffset? field)
        {
            _foundedIn = field;
        }
        public void UpdateWhatDoWeDo(string? field)
        {
            _whatDoWeDo = field;
        }
        public void UpdateReviews(decimal? field)
        {
            _numOfReviews++;
            var summ = _reviews + field;
            _reviews = summ / _numOfReviews;
        }
        public void UpdateReviewersStars(ReviewersStars? field)
        {
            _reviewersStars = field;
        }

        public void UpdateTitle(string? field)
        {
            _titleOverview = field;
        }

        public void UpdateWebsiteLink(string? field)
        {
            _websiteLink = field;
        }
        public void UpdateTitleOverview(string? field)
        {
            _titleOverview = field;
        }

        public void UpdateOverviewDescription(string? field)
        {
            _overviewDescription = field;
        }

        #endregion

        #region Category
        public void AddCategory(List<CompanyCategory> data)
        {
            _categories.AddRange(data);
        }
        public void AddCategory(CompanyCategory data)
        {
            _categories.Add(data);
        }
        public void RemoveCategory(Guid id)
        {
            var data = _categories.FirstOrDefault(x => x.Id == id);
            data.MarkAsDeleted(id);
        }
        public void UpdateCategory(Guid categoryId)
        {
            var data = _categories.FirstOrDefault();
            if (data is null) return;
            data.UpdateCategoryId(categoryId);
        }
        #endregion
        #endregion

    }
}
