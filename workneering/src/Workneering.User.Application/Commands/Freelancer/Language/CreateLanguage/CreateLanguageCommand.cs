using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.Language.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<Unit>
    {
        public Guid LanguageId { get; set; }  // lookup
        public LanguageLevelEnum? Level { get; set; }
    }
}
