using Workneering.Project.Application.Commands.CreateProject;
using Workneering.Project.Application.Services.Models;

namespace Workneering.Project.Application.Services.DbQueryService;

public interface IDbQueryService
{
    public Task<List<Guid>> GetUserCategoryId(Guid userId);
    public List<ProjectsListInfo> GetProjectsSortedByClientRating(Guid clientId, int pageSize = 10, int pageNumber = 1);
    public List<ProjectsListInfo> GetProjectsByLocations(List<Guid> categoryIds, int pageSize = 10, int pageNumber = 1);
    public Task<FreelancerInfoForProposalsList> GetFreelancerInfoForProposals(Guid freelancerId, CancellationToken cancellationToken = default);
    public Task<ImageDetailsDto> GetFreelancerImage(Guid? freelancerId);
    public ClientInfoForProjectDetails GetClientInfoForProjectDetails(Guid clientId);
    public IndustryDetails? GetIndustryName(Guid clientId);
    public string GetUserRole(Guid userId);
    public Task<CountUnreadMessagesDto>? GetUnreadCount(Guid? projectId, Guid? currentUserId);
    public List<CategorizationDto> GetSkillsForProject(List<Guid>? skillsIds);
    public List<CategorizationDto> GetSupCateforiesForProject(List<Guid>? suppCategoryIds);
    public List<CategorizationDto> GetCategoriesForProject(List<Guid>? categoryIds);
    public Task<FreelancerInfoDto> GetFreelancerInfo(Guid Id);
    public Task<string> AddRoom(Guid freelancerId, Guid clientId);
    public Task<RoomInfoDto> GetRoomId(Guid clientId, Guid freelancerId);

}