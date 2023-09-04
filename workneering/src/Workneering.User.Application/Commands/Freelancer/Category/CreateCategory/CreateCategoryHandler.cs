﻿using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Category.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public CreateCategoryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Categories).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query!.UpdateCategory(request.CategoryId);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
