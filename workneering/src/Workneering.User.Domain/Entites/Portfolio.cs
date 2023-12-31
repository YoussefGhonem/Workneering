﻿using Workneering.Base.Domain.Common;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Domain.Entites
{
    public record Portfolio : BaseEntity
    {
        #region Private Fields
        private string _projectTitle;
        private int? _startYaer;
        private int? _endnYear;
        private string? _projectDescription;

        private List<PortfolioFile> _portfolioFiles = new();

        // template case study
        #endregion
        public Portfolio(string projectTitle, int? startYaer, int? endnYear, string? projectDescription, List<PortfolioFile> portfolioFiles = null)
        {
            _projectTitle = projectTitle;
            _startYaer = startYaer;
            _endnYear = endnYear;
            _projectDescription = projectDescription;
            _portfolioFiles = portfolioFiles;

        }
        public Portfolio()
        {

        }

        #region public fields
        public virtual List<PortfolioFile> PortfolioFiles => _portfolioFiles;
        public string ProjectTitle { get => _projectTitle; private set => _projectTitle = value; }
        public string? ProjectDescription { get => _projectDescription; private set => _projectDescription = value; }
        public int? StartYear { get => _startYaer; private set => _startYaer = value; }
        public int? EndYear { get => _endnYear; private set => _endnYear = value; }
        #endregion

        #region public methods

        public void UpdateAttachments(List<string>? keys)
        {
            var portfolioFiles = _portfolioFiles.Select(x => x.FileDetails.Key);
            var removeItems = portfolioFiles.Except(keys);

            foreach (var item in removeItems)
            {
                var obj = _portfolioFiles.FirstOrDefault(x => x.FileDetails.Key == item);
                obj.MarkAsDeleted(null);
            }
        }
        public void AddAttachments(List<PortfolioFile>? files)
        {
            _portfolioFiles.AddRange(files);
        }

        public void UpdateProjectTitle(string field)
        {
            _projectTitle = field;
        }
        public void UpdateProjectDescription(string? field)
        {
            _projectDescription = field;
        }
        public void UpdateStartYear(int? field)
        {
            _startYaer = field;
        }
        public void UpdateEndYear(int? field)
        {
            _endnYear = field;
        }
        #endregion
    }
}
