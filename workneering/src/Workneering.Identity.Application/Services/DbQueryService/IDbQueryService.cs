﻿using Workneering.Identity.Application.Services.Models;

namespace Workneering.Identity.Application.Services.DbQueryService
{
    public interface IDbQueryService
    {
        public Task<UserBaseData> GetUserData(string UserRole, Domain.Entities.User user, CancellationToken cancellationToken);
        public Task UpdateUserName(Guid id, string name, string tableName, CancellationToken cancellationToken);
    }
}
