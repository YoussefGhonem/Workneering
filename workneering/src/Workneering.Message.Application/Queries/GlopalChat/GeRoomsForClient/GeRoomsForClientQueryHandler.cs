using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Application.Common.Pagination;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Message.Application.Extensions;
using Workneering.Message.Application.Queries.GlopalChat.GeRoomsForFreelancer;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Extention;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRoomsForClient
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GeRoomsForClientQuery, PaginationResult<RoomsForClientDto>>
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
        public async Task<PaginationResult<RoomsForClientDto>> Handle(GeRoomsForClientQuery request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<Domain.Entities.Room, RoomsForClientDto>.NewConfig()
            .Map(dest => dest.FreelancerImageUrl, src => src.ClientId.SetImageURL(_dbQueryService).Result)
            .Map(dest => dest.FreelancerName, src => src.ClientId.GetUserInfo(_dbQueryService).Result.Name)
            .Map(dest => dest.FreelancerCountryName, src => src.ClientId.GetUserInfo(_dbQueryService).Result.CountryName)
            .Map(dest => dest.FreelancerTitle, src => src.ClientId.GetUserInfo(_dbQueryService).Result.Title);


            var (list, total) = await _context.Rooms.Where(x => x.ClientId == CurrentUser.Id && x.IsActive)
                    .AsNoTracking()
                    .OrderByDescending(x => x.CreatedDate)
                    .PaginateAsync(request.PageSize, request.PageNumber, cancellationToken);

            var result = list.Adapt<List<RoomsForClientDto>>().OrderByDescending(x => x.LastMessageCreatedDate);
            foreach (var item in result)
            {
                var lastMessage = _context.GlopalChat.Select(x => new { x.Id, x.CreatedDate, x.RoomId, x.Content }).AsNoTracking()
                            .Where(m => m.RoomId == item.Id)
                            .OrderByDescending(m => m.CreatedDate)
                            .FirstOrDefault();

                item.LastMessage = lastMessage?.Content;
                item.LastMessageCreatedDate = lastMessage?.CreatedDate;
            }

            return new PaginationResult<RoomsForClientDto>(result.ToList(), total);
        }
    }
}
