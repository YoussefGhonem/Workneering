﻿using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record FreelancerCategory : BaseEntity
    {
        private Guid? _categoryId;

        public FreelancerCategory()
        {

        }
        public FreelancerCategory(Guid categoryId)
        {
            _categoryId = categoryId;
        }

        public Guid? CategoryId { get => _categoryId; private set => _categoryId = value; }

        public void UpdateCategoryId(Guid? field)
        {
            _categoryId = field;
        }

    }
}
