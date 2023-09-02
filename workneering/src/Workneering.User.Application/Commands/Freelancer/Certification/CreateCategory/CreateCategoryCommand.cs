﻿using MediatR;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Category.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}