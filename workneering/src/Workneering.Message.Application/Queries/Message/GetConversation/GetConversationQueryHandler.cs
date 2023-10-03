using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Message.Application.Extensions;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.Message.GetConversation
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetConversationQuery, List<GetConversationDto>>
    {
        private readonly MessagesDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(MessagesDbContext userDatabaseContext, IStorageService storageService, IDbQueryService dbQueryService)
        {
            _context = userDatabaseContext;
            _storageService = storageService;
            _dbQueryService = dbQueryService;
        }
        public async Task<List<GetConversationDto>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            var userId = CurrentUser.Id;

            var messages = await _context.Messages
                .Where(m => m.RecipientId == userId && m.SenderId == request.RecipientId ||
                        m.RecipientId == request.RecipientId && m.SenderId == userId)
                        .OrderByDescending(m => m.CreatedDate).ToListAsync();
            try
            {
                TypeAdapterConfig<Domain.Entities.Message, GetConversationDto>.NewConfig()
                .Map(dest => dest.RecipientPhotoUrl, src => src.RecipientId.Value.SetImageURL(_dbQueryService).Result)
                .Map(dest => dest.SenderPhotoUrl, src => src.SenderId.Value.SetImageURL(_dbQueryService).Result)
                .Map(dest => dest.SenderName, src => src.SenderId.Value.GetUserInfo(_dbQueryService).Result.Name)
                .Map(dest => dest.RecipientName, src => src.RecipientId.Value.GetUserInfo(_dbQueryService).Result.Name)
                .Map(dest => dest.SenderTitle, src => src.SenderId.Value.GetUserInfo(_dbQueryService).Result.Title)
                .Map(dest => dest.RecipientTitle, src => src.RecipientId.Value.GetUserInfo(_dbQueryService).Result.Title);

                return messages.ToList().Adapt<List<GetConversationDto>>();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
