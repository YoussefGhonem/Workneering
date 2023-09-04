using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.Language.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }  // lookup
        public LanguageLevelEnum? Level { get; set; }
    }
}
