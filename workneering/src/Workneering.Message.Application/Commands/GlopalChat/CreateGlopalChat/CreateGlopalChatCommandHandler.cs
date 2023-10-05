using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Helpers.Extensions;
using Workneering.Message.Domain.Entities;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;

namespace Workneering.Message.Application.Commands.GlopalChat.CreateGlopalChat
{
    public class CreateGlopalChatCommandHandler : IRequestHandler<CreateGlopalChatCommand, Unit>
    {
        private readonly MessagesDbContext _messagesDbContext;
        private readonly IStorageService _storageService;

        public CreateGlopalChatCommandHandler(MessagesDbContext messagesDbContext, IStorageService storageService)
        {
            _messagesDbContext = messagesDbContext;
            _storageService = storageService;
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
            await _messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}