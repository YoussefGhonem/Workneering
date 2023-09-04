﻿using Workneering.Base.Domain.Common;
using Workneering.Base.Helpers.Enums;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Entites
{
    public record Client : BaseEntity
    {
        private string? _name;
        private string? _overviewDescription;
        private string? _titleOverview;
        private string? _title;
        private GenderEnum? _gender;
        private decimal? _reviews; // 4.3 of 5 stars
        private int? _numOfReviews; // 100 clients for example
        private ReviewersStars? _reviewersStars;
        private List<ClientCategory>? _categories = new();

        public Client(Guid id)
        {
            Id = id;
        }
        public Client()
        {

        }

        #region Public fields
        public string? Name { get => _name; set => _name = value; }
        public string? Description { get => _overviewDescription; set => _overviewDescription = value; }
        public GenderEnum? Gender { get => _gender; private set => _gender = value; }
        public string? TitleOverview { get => _titleOverview; set => _titleOverview = value; }
        public string? Title { get => _title; set => _title = value; }

        public int? NumOfReviews { get => _numOfReviews; set => _numOfReviews = value; }

        public decimal? Reviews { get => _reviews; private set => _reviews = value; }

        public ReviewersStars? ReviewersStars { get => _reviewersStars; set => _reviewersStars = value; }
        public List<ClientCategory>? Categories => _categories;


        #endregion

        #region Public Methods

        #region Basic Details
        public void UpdateGender(GenderEnum? field)
        {
            _gender = field;
        }
        public void UpdateReviews(decimal field)
        {
            _numOfReviews++;
            var summ = _reviews + field;
            _reviews = summ / _numOfReviews;
        }
        public void UpdateReviewersStars(ReviewersStars field)
        {
            _reviewersStars = field;
        }
        public void UpdateTitle(string? field)
        {
            _titleOverview = field;
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
        public void UpdateCategory(Guid? categoryId)
        {
            _categories.FirstOrDefault().UpdateCategoryId(categoryId.Value);

        }
        #endregion

        #endregion
    }
}
