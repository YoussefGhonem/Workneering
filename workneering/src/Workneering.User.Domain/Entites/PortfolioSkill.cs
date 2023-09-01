﻿using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record PortfolioSkill : BaseEntity
    {
        private string _name;
        private string? _description;

        public PortfolioSkill(string name)
        {
            _name = name;
        }
        public PortfolioSkill()
        {
        }
        public string Name { get => _name; private set => _name = value; }
        public string? Description { get => _description; private set => _description = value; }


        public void UpdateName(string field)
        {
            _name = field;
        }
        public void UpdateDescription(string field)
        {
            _description = field;
        }
    }
}
