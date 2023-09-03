﻿using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.Language.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public LanguageLevelEnum Level { get; set; }
    }
}
