﻿using Workneering.Base.Domain.Common;
using Workneering.Base.Helpers.Enums;
using Workneering.Shared.Core.Models;
using Workneering.User.Domain.Helpr;
using Workneering.User.Domain.valueobjects;

namespace Workneering.User.Domain.Entites
{
    public record Client : BaseEntity
    {
        private string? _name;
        private FileDto? _imageDetails;
        private string? _overviewDescription;
        private string? _whoIAm;
        private string? _whatDoIdo;
        private string? _titleOverview;
        private string? _title;
        private GenderEnum? _gender;
        private decimal? _reviews; // 4.3 of 5 stars
        private int? _numOfReviews; // 100 clients for example
        private decimal _wengazPercentage;
        private decimal _profilePoint;
        private decimal _monthPoint;
        private decimal _packagePoint;
        private decimal _deductedPoint;
        private decimal _wengazPoint;
        private bool _isCountainCountry;
        private ReviewersStars? _reviewersStars;
        private List<UserCategory>? _categories = new();
        private List<UserSubCategory>? _subCategories = new();
        private List<UserSkill>? _skills = new();

        public Client(Guid id)
        {
            Id = id;
        }
        public Client()
        {

        }

        #region Public fields
        public FileDto? ImageDetails { get => _imageDetails; set => _imageDetails = value; }
        public string? Name { get => _name; set => _name = value; }
        public string? WhoIAm { get => _whoIAm; set => _whoIAm = value; }
        public string? WhatDoIDo { get => _whatDoIdo; set => _whatDoIdo = value; }
        public string? Description { get => _overviewDescription; set => _overviewDescription = value; }
        public GenderEnum? Gender { get => _gender; private set => _gender = value; }
        public string? TitleOverview { get => _titleOverview; set => _titleOverview = value; }
        public string? Title { get => _title; set => _title = value; }
        public int? NumOfReviews { get => _numOfReviews; set => _numOfReviews = value; }
        public decimal? Reviews { get => _reviews; private set => _reviews = value; }
        public decimal WengazPercentage { get => _wengazPercentage; private set => _wengazPercentage = 0; }
        public decimal ProfilePoint { get => _profilePoint; private set => _profilePoint = 0; }
        public decimal MonthPoint { get => _monthPoint; private set => _monthPoint = 0; }
        public decimal PackagePoint { get => _packagePoint; private set => _packagePoint = 0; }
        public decimal DeductedPoint { get => _deductedPoint; private set => _deductedPoint = 0; }
        public decimal WengazPoint { get => _wengazPoint; private set => _wengazPoint = 0; }
        public bool IsCountainCountry { get => _isCountainCountry; private set => _isCountainCountry = false; }

        public ReviewersStars? ReviewersStars { get => _reviewersStars; set => _reviewersStars = value; }
        public List<UserCategory>? Categories => _categories;
        public List<UserSubCategory>? SubCategories => _subCategories;
        public List<UserSkill>? Skills => _skills;

        #endregion

        #region Public Methods

        #region Basic Details
        public void UpdateImage(FileDto? imageDetails)
        {
            _imageDetails = imageDetails;
        }
        public void UpdateWhoIAm(string? field)
        {
            _whoIAm = field;
        }
        public void UpdateWhatDoIdo(string? field)
        {
            _whatDoIdo = field;
        }

        public void UpdateName(string? field)
        {
            _name = field;
        }
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
            _title = field;
        }

        public void UpdateTitleOverview(string? field)
        {
            _titleOverview = field;
        }

        public void UpdateOverviewDescription(string? field)
        {
            _overviewDescription = field;
        }
        private decimal CalculateNullValue()
        {
            decimal nullFieldCount = 0;
            if (string.IsNullOrEmpty(_name)) { nullFieldCount++; }
            if (string.IsNullOrEmpty(_whoIAm)) { nullFieldCount++; }
            if (string.IsNullOrEmpty(_whatDoIdo)) { nullFieldCount++; }
            if (_isCountainCountry == false) { nullFieldCount++; }
            if (string.IsNullOrEmpty(_overviewDescription)) nullFieldCount++;
            if (string.IsNullOrEmpty(_titleOverview)) nullFieldCount++;
            if (_gender == null) nullFieldCount++;
            return nullFieldCount;
        }
        public void UpdateAllPointAndPercentage()
        {
            UpdateWengazPercentage();
            UpdateProrilePoint();
            UpdateDeductedPoint();
            UpdateWengazPoint();
        }
        public void UpdateWengazPercentage()
        {

            decimal nullValue = CalculateNullValue();
            decimal allValue = typeof(ClientPercentageFields).GetProperties().Count();
            _wengazPercentage = (((allValue - nullValue) / allValue) * 100);

        }
        public void UpdateProrilePoint()
        {
            decimal nullValue = CalculateNullValue();
            decimal allValue = typeof(ClientPercentageFields).GetProperties().Count();
            _profilePoint = ((allValue - nullValue) * 10);
        }
        public void UpdateMonthPoint(decimal field)
        {
            _monthPoint = field;
        }
        public void UpdatePackagePoint(decimal field)
        {
            _packagePoint = field;
        }
        public void UpdateDeductedPoint()
        {
            decimal allValue = typeof(ClientPercentageFields).GetProperties().Count();
            _deductedPoint = (allValue * 10) - _profilePoint;
        }
        public void UpdateWengazPoint()
        {
            _wengazPoint = _packagePoint + _profilePoint + _monthPoint;
        }
        #endregion




        #region categorization
        public void UpdateCategory(List<Guid>? categoryIds)
        {
            var ids = _categories.Select(x => x.CategoryId).ToList();
            //if (!ids.Any()) return;

            var addNewItems = categoryIds?.Except(ids);
            var removeItems = ids?.Except(categoryIds);
            var result = addNewItems.Select(x => new UserCategory(x));
            _categories.AddRange(result);

            foreach (var item in removeItems)
            {
                var data = _categories.FirstOrDefault(x => x.CategoryId == item);
                data.MarkAsDeleted(null);
            }

        }
        public void UpdateSubCategory(List<Guid>? externalIds)
        {
            var ids = _subCategories?.Select(x => x.SubCategoryId).ToList();
            //if (!ids.Any()) return;

            var addNewItems = externalIds?.Except(ids);
            var removeItems = ids?.Except(externalIds);
            var result = addNewItems.Select(x => new UserSubCategory(x));
            _subCategories.AddRange(result);

            foreach (var item in removeItems)
            {
                var data = _subCategories.FirstOrDefault(x => x.SubCategoryId == item);
                data.MarkAsDeleted(null);
            }

        }
        public void UpdateSkills(List<Guid> externalIds)
        {
            var ids = _skills.Select(x => x.SkillId).ToList();
            // if (!ids.Any()) return;

            var addNewItems = externalIds.Except(ids);
            var removeItems = ids.Except(externalIds);
            var result = addNewItems.Select(x => new UserSkill(x));
            _skills.AddRange(result);

            foreach (var item in removeItems)
            {
                var data = _skills.FirstOrDefault(x => x.SkillId == item);
                data.MarkAsDeleted(null);
            }

        }
        #endregion

        #endregion
    }
}
