﻿using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Language.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
