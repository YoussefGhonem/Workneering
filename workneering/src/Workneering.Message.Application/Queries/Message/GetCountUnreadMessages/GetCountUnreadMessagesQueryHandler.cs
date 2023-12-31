﻿using MediatR;
using ServiceStack;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.Message.GetCountUnreadMessages
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetCountUnreadMessagesQuery, CountUnreadMessagesDto>
    {
        private readonly MessagesDbContext _identityDatabase;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(MessagesDbContext userDatabaseContext, IStorageService storageService)
        {
            _identityDatabase = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<CountUnreadMessagesDto> Handle(GetCountUnreadMessagesQuery request, CancellationToken cancellationToken)
        {
            var userId = CurrentUser.Id;

            var messages = _identityDatabase.Messages
                .Where(m => m.IsRead == false && m.ProjectId == request.ProjectId
                && m.CreatedUserId != CurrentUser.Id);
            var count = messages.Count();

            return new CountUnreadMessagesDto() { UnreadCount = count };
        }
    }
}
