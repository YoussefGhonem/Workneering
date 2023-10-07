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
using Workneering.Shared.Core.Extention;

namespace Workneering.Message.Application.Queries.GlopalChat.GetGlopalChat
{
    public class GetGlopalChatQueryHandler : IRequestHandler<GetGlopalChatQuery, PaginationResult<GlopalChatDto>>
    {
        private readonly MessagesDbContext _context;
        private readonly IStorageService _storageService;
        private readonly IDbQueryService _dbQueryService;

        public GetGlopalChatQueryHandler(MessagesDbContext userDatabaseContext, IStorageService storageService, IDbQueryService dbQueryService)
        {
            _context = userDatabaseContext;
            _storageService = storageService;
            _dbQueryService = dbQueryService;
        }
        public async Task<PaginationResult<GlopalChatDto>> Handle(GetGlopalChatQuery request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<Domain.Entities.GlopalChat, GlopalChatDto>.NewConfig()
            .Map(dest => dest.CreatedUserPhotoUrl, src => src.CreatedUserId.SetImageURL(_dbQueryService).Result)
            .Map(dest => dest.CreatedUserName, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.Name)
            .Map(dest => dest.CreatedUserCountryName, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.CountryName)
            .Map(dest => dest.CreatedUserTitle, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.Title);


            TypeAdapterConfig<Domain.Entities.GlopalChatAttachments, GlopalChatAttachmentsDto>.NewConfig()
            .Map(dest => dest.Url, src => src.Attachments.Key.SetDownloadFileUrlByKey(_storageService))
            .Map(dest => dest.Key, src => src.Attachments.Key)
            .Map(dest => dest.FileName, src => src.Attachments.FileName)
            .Map(dest => dest.FileSize, src => src.Attachments.FileSize);


            var (list, total) = await _context.GlopalChat.Where(x => x.RoomId == request.RoomId)
                    .AsNoTracking()
                    .Include(x => x.GlopalChatAttachments)
                    .OrderByDescending(x => x.CreatedDate)
                    .PaginateForChatAsync(request.Hand, request.Next, cancellationToken);

            list.Reverse();

            var result = list.Adapt<List<GlopalChatDto>>();

            return new PaginationResult<GlopalChatDto>(result, total);
        }
    }
}
