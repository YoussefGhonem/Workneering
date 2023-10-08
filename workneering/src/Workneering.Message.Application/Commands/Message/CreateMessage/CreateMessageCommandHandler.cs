using Mapster;
using MediatR;
using ServiceStack;
using Workneering.Base.Helpers.Extensions;
using Workneering.Message.Domain.Entities;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Message.Application.Services.DbQueryService;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;
        private readonly IStorageService _storageService;
        private readonly IDbQueryService _dbQueryService;
        public CreateMessageCommandHandler(IMediator mediator, MessagesDbContext identityDatabase, IStorageService storageService, IDbQueryService dbQueryService)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
            _storageService = storageService;
            _dbQueryService = dbQueryService;
        }

        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.Content) && !request.Attachments.AsNotNull().Any())
            {
                return Unit.Value;
            }

            TypeAdapterConfig<StoredFile, MessageAttachments>.NewConfig()
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
            var attachmentsFileDto = attachments?.Adapt<List<MessageAttachments>>();
            var message = new Domain.Entities.Message(request.Content, request.ProjectId, attachmentsFileDto);
            await messagesDbContext.Messages.AddAsync(message, cancellationToken);

            // add notification
            var isFreelancer = CurrentUser.Roles.Contains(Shared.Core.Identity.Enums.RolesEnum.Freelancer);
            var projectInfo = await _dbQueryService.GeProjectInfo(request.ProjectId);
            var recieveId = isFreelancer ? projectInfo.ClientId.Value : projectInfo.AssginedFreelancerId.Value;
            var userInfo = await _dbQueryService.GetUserInfo(CurrentUser.Id.Value);
            var title = @$"You have new message with '{projectInfo.ProjectTitle}'";
            var content = @$"{userInfo.Name} send you new message with '{projectInfo.ProjectTitle}'";
            var isExistMessege = messagesDbContext.Notifications
                .Any(x => x.IsRead == false && x.ProjectId == request.ProjectId && x.RecipientId == recieveId);
            if (!isExistMessege)
            {
                var notification = new MessegeNotifications(recieveId, title, content, request.ProjectId, null, CurrentUser.Id);
                await messagesDbContext.Notifications.AddAsync(notification, cancellationToken);
            }

            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}