using Mapster;
using MediatR;
using Workneering.Base.Helpers.Extensions;
using Workneering.Message.Domain.Entities;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Packages.Storage.AWS3.Services;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;
        private readonly IStorageService _storageService;
        public CreateMessageCommandHandler(IMediator mediator, MessagesDbContext identityDatabase, IStorageService storageService)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
            _storageService = storageService;
        }

        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
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
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}