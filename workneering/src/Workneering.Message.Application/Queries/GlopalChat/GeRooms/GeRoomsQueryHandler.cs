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
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GeRoomsQuery, PaginationResult<RoomsDto>>
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
        public async Task<PaginationResult<RoomsDto>> Handle(GeRoomsQuery request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<Domain.Entities.Room, RoomsDto>.NewConfig()
            .Map(dest => dest.UserImageUrl, src => src.ClientId.SetImageURL(_dbQueryService).Result)
            .Map(dest => dest.UserName, src => src.ClientId.GetUserInfo(_dbQueryService).Result.Name)
            .Map(dest => dest.UserCountryName, src => src.ClientId.GetUserInfo(_dbQueryService).Result.CountryName)
            .Map(dest => dest.UserTitle, src => src.ClientId.GetUserInfo(_dbQueryService).Result.Title);

            var isFreelancer = CurrentUser.Roles.Contains(Shared.Core.Identity.Enums.RolesEnum.Freelancer);
            var (list, total) = await _context.Rooms.Where(x => (isFreelancer ? x.FreelancerId : x.ClientId) == CurrentUser.Id && x.IsActive)
                    .AsNoTracking()
                    .OrderByDescending(x => x.CreatedDate)
                    .PaginateAsync(request.PageSize, request.PageNumber, cancellationToken);

            var result = list.Adapt<List<RoomsDto>>().OrderByDescending(x => x.LastMessageCreatedDate);
            foreach (var item in result)
            {
                var lastMessage = _context.GlopalChat.Select(x => new { x.Id, x.CreatedDate, x.RoomId, x.Content }).AsNoTracking()
                            .Where(m => m.RoomId == item.Id)
                            .OrderByDescending(m => m.CreatedDate)
                            .FirstOrDefault();

                item.LastMessage = lastMessage?.Content;
                item.LastMessageCreatedDate = lastMessage?.CreatedDate;
            }
            return new PaginationResult<RoomsDto>(result.ToList(), total);
        }
    }
}
