using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Workneering.Message.Application.Commands.GlopalChat.CreateGlopalChat
{
    public class CreateGlopalChatCommand : IRequest<Unit>
    {

        [JsonIgnore]
        public Guid RoomId { get; set; }
        public string? Content { get; set; }
        public IEnumerable<IFormFile>? Attachments { get; set; }
    }
}