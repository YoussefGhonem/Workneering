using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Message.Infrustructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Message.Domain.Entities;
using Mapster;
using Workneering.Packages.Storage.AWS3.Models;
using Workneering.Project.Domain.Entities;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Base.Helpers.Extensions;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly MessagesDbContext messagesDbContext;
        private readonly IMediator _mediator;
        private readonly IStorageService _storageService;
        public CreateMessageCommandHandler(IMediator mediator, MessagesDbContext identityDatabase)
        {
            messagesDbContext = identityDatabase;
            _mediator = mediator;
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
                attachments = await _storageService.UploadFiles(request.Attachments, cancellationToken);
            }
            var attachmentsFileDto = attachments?.Adapt<List<MessageAttachments>>();
            var message = new Domain.Entities.Message(request.Content, request.ProjectId, attachmentsFileDto);
            await messagesDbContext.Messages.AddAsync(message, cancellationToken);
            await messagesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}