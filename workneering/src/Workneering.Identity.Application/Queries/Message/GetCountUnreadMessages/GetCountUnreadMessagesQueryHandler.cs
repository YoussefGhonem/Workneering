﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Queries.Message.GetCountUnreadMessages
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetCountUnreadMessagesQuery, CountUnreadMessagesDto>
    {
        private readonly IdentityDatabaseContext _identityDatabase;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(IdentityDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _identityDatabase = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<CountUnreadMessagesDto> Handle(GetCountUnreadMessagesQuery request, CancellationToken cancellationToken)
        {
            if (_identityDatabase.Users.Any(x => x.Id != CurrentUser.Id)) return new CountUnreadMessagesDto();

            var userId = CurrentUser.Id;

            var messages = await _identityDatabase.Users
                .Include(x => x.MessagesReceived.Where(m => m.IsRead == false && m.Id == userId)).ToListAsync();
            var count = messages.Count();

            return new CountUnreadMessagesDto { UnreadCount = count };
        }
    }
}
