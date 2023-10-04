using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace Workneering.Message.Application.Commands.Message.CreateMessage
{
    public class CreateMessageCommand : IRequest<Unit>
    {

        [JsonIgnore]
        public Guid ProjectId { get; set; }
        public string Content { get; set; }
        public IEnumerable<IFormFile>? Attachments { get; set; }
    }
}