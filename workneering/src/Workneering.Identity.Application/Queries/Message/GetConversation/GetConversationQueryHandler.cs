using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Queries.Message.GetConversation
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetConversationQuery, GetConversationDto>
    {
        private readonly IdentityDatabaseContext _identityDatabase;

        public GetFreelancerEducationDetailsQueryHandler(IdentityDatabaseContext userDatabaseContext)
        {
            _identityDatabase = userDatabaseContext;
        }
        public async Task<GetConversationDto> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            if (_identityDatabase.Users.Any(x => x.Id != CurrentUser.Id)) return new GetConversationDto();


            var user = await _identityDatabase.Users
             .Include(u => u.MessagesReceived)
             .Include(u => u.MessagesSent)
             .Where(u => u.Id == CurrentUser.Id) // You may need to adjust the property name for the user ID
             .SingleOrDefaultAsync();

            //if (user != null)
            //{
            //    var messages = user.MessagesReceived
            //        .Where(m => !m.RecipientDeleted && m.Id == recipientId)
            //        .Concat(user.MessagesSent.Where(m => !m.SenderDeleted && m.RecipientId == recipientId))
            //        .OrderByDescending(m => m.MessageSent)
            //        .ToList();
            //    // Messages will contain the combined list of MessagesReceived and MessagesSent
            //}

            return new GetConversationDto();
        }
    }
}
