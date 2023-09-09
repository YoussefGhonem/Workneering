using MediatR;

namespace Workneering.Settings.Application.Queries.GetPrimaryIndustry;

public class GetPrimaryIndustryQuery : IRequest<List<PrimaryIndustryDto>>
{
}
