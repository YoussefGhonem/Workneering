using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Message.Application.Extensions;
using Workneering.Shared.Core.Identity.CurrentUser;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Microsoft.Extensions.Configuration;

namespace Workneering.Message.Application.Queries.Message.GetConversation
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetConversationQuery, PaginationResult<GetConversationDto>>
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
        public async Task<PaginationResult<GetConversationDto>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            var userId = CurrentUser.Id;

            var (list, total) = await _context.Messages.Where(x => x.ProjectId == request.ProjectId)
                    .AsNoTracking()
                    .Where(x => x.Id == request.ProjectId)
                    .Include(x => x.MessageAttachments)
                    .OrderByDescending(x => x.CreatedDate)
                    .PaginateForChatAsync(request.Hand, request.Next, cancellationToken);

            list.Reverse();
            try
            {
                TypeAdapterConfig<Domain.Entities.Message, GetConversationDto>.NewConfig()
                .Map(dest => dest.CreatedUserPhotoUrl, src => src.CreatedUserId.SetImageURL(_dbQueryService).Result)
                .Map(dest => dest.CreatedUserName, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.Name)
                .Map(dest => dest.CreatedUserTitle, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.Title);

                //return list.Adapt<List<GetConversationDto>>();
                return new PaginationResult<GetConversationDto>(list.Adapt<List<GetConversationDto>>(), total);

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
