using Mapster;
using Workneering.Project.Application.Services.DbQueryService;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Queries.Proposal.GetProposals
{
    public static class Mapper
    {
        public static void Mapping(IDbQueryService _dbQueryService)
        {
            TypeAdapterConfig<Domain.Entities.Project, ProjectProposalsDto>.NewConfig()
                    .Map(dest => dest.Client.Name, src => _dbQueryService.GetClientInfoForProjectDetails(src.ClientId.Value).Name)
                    .Map(dest => dest.Client.ImageUrl, src => _dbQueryService.GetClientInfoForProjectDetails(src.ClientId.Value).ImageUrl)
                    .Map(dest => dest.Client.Title, src => _dbQueryService.GetClientInfoForProjectDetails(src.ClientId.Value).Title)
                    .Map(dest => dest.Client.CountryName, src => _dbQueryService.GetClientInfoForProjectDetails(src.ClientId.Value).CountryName)
                    .Map(dest => dest.UnreadCount, src => _dbQueryService.GetUnreadCount(src.Id, CurrentUser.Id).Result.UnreadCount);




        }
    }
}
