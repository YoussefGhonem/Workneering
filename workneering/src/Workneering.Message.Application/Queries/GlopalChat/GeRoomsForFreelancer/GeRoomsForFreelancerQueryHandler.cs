using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Message.Application.Extensions;
using Workneering.Message.Application.Queries.GlopalChat.GeRoomsForClient;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Extention;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRoomsForFreelancer
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GeRoomsForFreelancerQuery, PaginationResult<RoomsForFreelancerDto>>
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
        public async Task<PaginationResult<RoomsForFreelancerDto>> Handle(GeRoomsForFreelancerQuery request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<Domain.Entities.Room, RoomsForFreelancerDto>.NewConfig()
            .Map(dest => dest.ClientImageUrl, src => src.ClientId.SetImageURL(_dbQueryService).Result)
            .Map(dest => dest.ClientName, src => src.ClientId.GetUserInfo(_dbQueryService).Result.Name)
            .Map(dest => dest.ClientCountryName, src => src.ClientId.GetUserInfo(_dbQueryService).Result.CountryName)
            .Map(dest => dest.ClientTitle, src => src.ClientId.GetUserInfo(_dbQueryService).Result.Title);


            var (list, total) = await _context.Rooms.Where(x => x.ClientId == CurrentUser.Id && x.IsActive)
                    .AsNoTracking()
                    .OrderByDescending(x => x.CreatedDate)
                    .PaginateAsync(request.PageSize, request.PageNumber, cancellationToken);

            var result = list.Adapt<List<RoomsForFreelancerDto>>().OrderByDescending(x => x.LastMessageCreatedDate);
            foreach (var item in result)
            {
                var lastMessage = _context.GlopalChat.Select(x => new { x.Id, x.CreatedDate, x.RoomId, x.Content }).AsNoTracking()
                            .Where(m => m.RoomId == item.Id)
                            .OrderByDescending(m => m.CreatedDate)
                            .FirstOrDefault();

                item.LastMessage = lastMessage?.Content;
                item.LastMessageCreatedDate = lastMessage?.CreatedDate;
            }
            return new PaginationResult<RoomsForFreelancerDto>(result.ToList(), total);
        }
    }
}
