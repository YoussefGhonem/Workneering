using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Language.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public List<Guid> Ids { get; set; } // this list of ids is not deleted (get ths ids from ui)
    }
}
