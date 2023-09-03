using MediatR;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Language.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? Level { get; set; }
    }
}
