using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Message.Application.Extensions;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.Notifications.GeNotifications
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GeNotificationsQuery, PaginationResult<MessageNotificationsDto>>
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
        public async Task<PaginationResult<MessageNotificationsDto>> Handle(GeNotificationsQuery request, CancellationToken cancellationToken)
        {

            TypeAdapterConfig<Domain.Entities.MessegeNotifications, MessageNotificationsDto>.NewConfig()
            .Map(dest => dest.SenderImage, src => src.SenderId.Value.SetImageURL(_dbQueryService).Result);


            var (list, total) = await _context.Notifications
                    .Where(x => x.RecipientId == CurrentUser.Id)
                    .AsNoTracking()
                    .OrderByDescending(x => x.CreatedDate)
                    .PaginateForChatAsync(request.Hand, request.Next, cancellationToken);


            return new PaginationResult<MessageNotificationsDto>(list.Adapt<List<MessageNotificationsDto>>(), total);
        }
    }
}
