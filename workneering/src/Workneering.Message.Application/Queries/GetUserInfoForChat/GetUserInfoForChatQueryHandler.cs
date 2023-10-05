using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Message.Application.Extensions;
using Workneering.Message.Application.Queries.GlopalChat.GetGlopalChat;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Queries.GetUserInfoForChat
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetUserInfoForChatQuery, UserInfoForChatDto>
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
        public async Task<UserInfoForChatDto> Handle(GetUserInfoForChatQuery request, CancellationToken cancellationToken)
        {
            TypeAdapterConfig<Domain.Entities.GlopalChat, UserInfoForChatDto>.NewConfig()
            .Map(dest => dest.UserPhotoUrl, src => src.CreatedUserId.SetImageURL(_dbQueryService).Result)
            .Map(dest => dest.UserName, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.Name)
            .Map(dest => dest.UserCountryName, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.CountryName)
            .Map(dest => dest.UserTitle, src => src.CreatedUserId.GetUserInfo(_dbQueryService).Result.Title);

            var isFreelancer = CurrentUser.Roles.Contains(Shared.Core.Identity.Enums.RolesEnum.Freelancer);

            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == request.RoomId);
            var userId = isFreelancer ? room.ClientId : room.FreelancerId;
            var userInfo = new UserInfoForChatDto
            {
                Id = userId,
                UserName = _dbQueryService.GetUserInfo(userId).Result.Name,
                UserCountryName = _dbQueryService.GetUserInfo(userId).Result.CountryName,
                UserTitle = _dbQueryService.GetUserInfo(userId).Result.Title,
                UserPhotoUrl = userId.SetImageURL(_dbQueryService).Result,
                UserRole = userId.GetUserInfo(_dbQueryService).Result.RoleName.ToLower(),
            };

            return userInfo;
        }


    }
}
