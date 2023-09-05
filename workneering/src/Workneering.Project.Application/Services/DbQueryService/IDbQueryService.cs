using Workneering.Project.Application.Services.Models;

namespace Workneering.Project.Application.Services.DbQueryService;

public interface IDbQueryService
{
    public Guid GetUserCategoryId(Guid userId);
    public List<ProjectsListInfo> GetProjectsSortedByClientRating(Guid clientId, int pageSize = 10, int pageNumber = 1);
    public List<ProjectsListInfo> GetProjectsByLocations(List<Guid> categoryIds, int pageSize = 10, int pageNumber = 1);
    public FreelancerInfoForProposalsList GetFreelancerInfoForProposals(Guid freelancerId);
    public FreelancerInfoForProposalsList GetClientInfoForProjectDetails(Guid clientId);
    public CategoryDetailsDto GetCategoryDetails(Guid clientId);

}