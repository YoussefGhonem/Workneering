using MediatR;

namespace Workneering.Settings.Application.Queries.GetLanguages;

public class GetLanguagesQuery : IRequest<List<GetLanguagesDto>>
{
}
