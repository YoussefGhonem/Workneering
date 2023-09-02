using MediatR;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Language.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? Level { get; set; }
    }
}
