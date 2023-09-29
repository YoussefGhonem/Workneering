using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Extention;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Queries.Message.GetConversation
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetConversationQuery, List<GetConversationDto>>
    {
        private readonly IdentityDatabaseContext _identityDatabase;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(IdentityDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _identityDatabase = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<List<GetConversationDto>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            if (_identityDatabase.Users.Any(x => x.Id != CurrentUser.Id)) return new List<GetConversationDto>();

            var userId = CurrentUser.Id;

            var query = await _identityDatabase.Users
                    .Where(u => u.Id == userId)
                    .SelectMany(u => u.MessagesSent
                    .Where(m => m.Recipient.Id == request.RecipientId || m.Sender.Id == request.RecipientId))
                    .Include(m => m.Sender)
                    .Include(m => m.Recipient)
                    .OrderByDescending(m => m.CreatedDate)
                    .ToListAsync(cancellationToken: cancellationToken);

            TypeAdapterConfig<Domain.Entities.User, GetConversationDto>.NewConfig()
                    .Map(dest => dest.SenderPhotoUrl, src => src.ImageKey == null ? null : src.ImageKey.SetDownloadFileUrlByKey(_storageService))
                    .Map(dest => dest.RecipientPhotoUrl, src => src.ImageKey == null ? null : src.ImageKey.SetDownloadFileUrlByKey(_storageService));

            var result = query.Adapt<List<GetConversationDto>>();

            return result;
        }
    }
}
