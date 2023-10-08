using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Helpers.Extensions;
using Workneering.Message.Domain.Entities;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Commands.GlopalChat.CreateGlopalChat
{
    public class CreateGlopalChatCommandHandler : IRequestHandler<CreateGlopalChatCommand, Unit>
    {
        private readonly MessagesDbContext _messagesDbContext;
        private readonly IStorageService _storageService;
        private readonly IDbQueryService _dbQueryService;

        public CreateGlopalChatCommandHandler(MessagesDbContext messagesDbContext, IStorageService storageService, IDbQueryService dbQueryService)
        {
            _messagesDbContext = messagesDbContext;
            _storageService = storageService;
            _dbQueryService = dbQueryService;
        }

        public async Task<Unit> Handle(CreateGlopalChatCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Content) && !request.Attachments.AsNotNull().Any())
            {
                return Unit.Value;
            }
            TypeAdapterConfig<StoredFile, GlopalChatAttachments>.NewConfig()
                      .Map(dest => dest.Attachments.Key, src => src.Key)
                      .Map(dest => dest.Attachments.Extension, src => src.Extension)
                      .Map(dest => dest.Attachments.FileName, src => src.FileName)
                      .Map(dest => dest.Attachments.FileSize, src => src.FileSize);

            var attachments = new List<StoredFile>();
            if (request.Attachments.AsNotNull().Any())
            {
                var conectToUpload = await _storageService.UploadFiles(request.Attachments!.ToList(), cancellationToken);
                attachments.AddRange(conectToUpload);
            }
            var attachmentsFileDto = attachments?.Adapt<List<GlopalChatAttachments>>();

            var room = await _messagesDbContext.Rooms.FirstOrDefaultAsync(x => x.Id == request.RoomId);
            room.SetIsActive();
            _messagesDbContext.Rooms.Attach(room);

            var message = new Domain.Entities.GlopalChat(request.Content, request.RoomId, attachmentsFileDto);
            await _messagesDbContext.GlopalChat.AddAsync(message, cancellationToken);

            // add notification
            var isFreelancer = CurrentUser.Roles.Contains(Shared.Core.Identity.Enums.RolesEnum.Freelancer);

            var recieveId = isFreelancer ? room.ClientId : room.FreelancerId;
            var userInfo = await _dbQueryService.GetUserInfo(CurrentUser.Id.Value);
            var title = @$"You have new message from '{userInfo.Name}'";
            var content = @$"{userInfo.Name} send you new message";
            var notification = new MessegeNotifications(recieveId, title, content, null, request.RoomId, CurrentUser.Id);
            await _messagesDbContext.Notifications.AddAsync(notification, cancellationToken);

            await _messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}