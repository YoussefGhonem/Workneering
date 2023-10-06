using Dapper;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using System.Data.Common;
using System.Data.SqlClient;
using Workneering.Base.Helpers.Extensions;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Project.Application.Commands.CreateProject;
using Workneering.Project.Application.Services.Models;
using Workneering.Shared.Core.Extention;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Project.Application.Services.DbQueryService;

public class DbQueryService : IDbQueryService
{
    private readonly string _connectionString;
    private readonly IStorageService _storageService;

    public DbQueryService(IConfiguration configuration, IStorageService storageService)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _storageService = storageService;
    }

    public async Task<List<Guid>> GetUserCategoryId(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        string culomnName = string.Empty;
        if (CurrentUser.Roles.Contains(RolesEnum.Freelancer))
        {
            culomnName = "FreelancerId";
        }
        else if (CurrentUser.Roles.Contains(RolesEnum.Client))
        {
            culomnName = "CompanyId";
        }
        if (CurrentUser.Roles.Contains(RolesEnum.Company))
        {
            culomnName = "CompanyId";
        }
        var sql = @$"SELECT CategoryId
                FROM UserSchema.UserCategories c
                WHERE c.{culomnName} = '{userId.ToString()}'";

        var data = con.QueryAsync<Guid>(sql);

        return data.Result.ToList();
    }
    public List<ProjectsListInfo> GetProjectsSortedByClientRating(Guid clientId, int pageSize, int pageNumber)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        var data = con
                    .Query<ProjectsListInfo>(
                        @$" SELECT p.*
                            FROM ProjectsSchema.Projects p
                            INNER JOIN UserSchema.Clients c ON p.ClientId = c.ClientId
                            ORDER BY c.NumOfReviews DESC
                            OFFSET {pageSize} * ({pageNumber} - 1) ROWS
                            FETCH NEXT {pageSize} ROWS ONLY");

        return data.ToList();
    }
    public List<ProjectsListInfo> GetProjectsByLocations(List<Guid> categoryIds, int pageSize, int pageNumber)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        string inClause = string.Join(",", categoryIds);

        var data = con
                    .Query<ProjectsListInfo>(
                        @$"  SELECT p.*
                        FROM ProjectsSchema.Projects p
                        INNER JOIN UserSchema.Clients c ON p.ClientId = c.ClientId
                        INNER JOIN IdentitySchema.Users  u ON c.Id = u.Id
                        WHERE u.CountryId IN ({inClause})
                        OFFSET {pageSize} * ({pageNumber} - 1) ROWS
                        FETCH NEXT {pageSize} ROWS ONLY");

        return data.ToList();
    }
    public async Task<FreelancerInfoForProposalsList>? GetFreelancerInfoForProposals(Guid freelancerId, CancellationToken cancellationToken)
    {
        using var con = new SqlConnection(_connectionString);
        con.OpenAsync();
        var sql = @$"  SELECT  f.Id, f.Name ,f.Title , c.Name as CountryName
                        FROM  UserSchema.Freelancers f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        LEFT JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{freelancerId}' ";
        var data = con.QueryFirstOrDefaultAsync<FreelancerInfoForProposalsList>(sql);

        return data.Result;
    }
    public ClientInfoForProjectDetails GetClientInfoForProjectDetails(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        var userRole = GetUserRole(userId);

        var data = new ClientInfoForProjectDetails();
        if (userRole == RolesEnum.Company.ToString())
        {
            var sql = @$"  SELECT  f.Id, f.Name ,f.Title,f.ImageDetails_Key as KeyImage,f.FoundedIn,f.CompanySize,f.TitleOverview , c.Name as CountryName
                        FROM  UserSchema.Companies f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        LEFT JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{userId}' ";
            data = con.QueryFirst<ClientInfoForProjectDetails>(sql);
        }
        else
        {
            var sql = @$"SELECT  f.Id, f.Name ,f.Title,f.TitleOverview, c.Name as CountryName
                        FROM  UserSchema.Clients f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        LEFT JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{userId}' ";
            data = con
             .QueryFirst<ClientInfoForProjectDetails>(sql);
        }
        if (!string.IsNullOrEmpty(data.KeyImage))
        {
            data.ImageUrl = data.KeyImage.SetDownloadFileUrlByKey(_storageService);
        }
        return data;
    }
    public string GetUserRole(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        var sql = @$"SELECT r.Name AS RoleName
                           FROM IdentitySchema.Roles r
                           INNER JOIN IdentitySchema.UserRoles ur ON r.Id = ur.RoleId
                           INNER JOIN IdentitySchema.Users u ON ur.UserId = u.Id
                           WHERE u.Id = '{userId}' ";

        var data = con.QueryFirst<string>(sql);

        return data;
    }

    public List<CategorizationDto> GetCategoriesForProject(List<Guid>? categoryIds)
    {
        if (!categoryIds.AsNotNull().Any()) return null;
        using var con = new SqlConnection(_connectionString);
        con.Open();

        string inClause = string.Join(",", categoryIds);


        var data = con.Query<CategorizationDto>(
    @"SELECT c.Id, c.Name
      FROM SettingsSchema.Categories c
      WHERE c.Id IN @CategoryIds",
    new { CategoryIds = categoryIds });

        return data.ToList();

    }

    public List<CategorizationDto>? GetSupCateforiesForProject(List<Guid>? suppCategoryIds)
    {
        if (!suppCategoryIds.AsNotNull().Any()) return null;

        using var con = new SqlConnection(_connectionString);
        con.Open();
        string inClause = string.Join(",", suppCategoryIds);

        var data = con.Query<CategorizationDto>(
            @"SELECT c.Id, c.Name
              FROM SettingsSchema.SubCategories c
              WHERE c.Id IN @SuppCategoryIds",
            new { SuppCategoryIds = suppCategoryIds });

        return data.ToList();

    }
    public async Task<CountUnreadMessagesDto>? GetUnreadCount(Guid? projectId, Guid? currentUserId)
    {

        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var sql = @$"SELECT COUNT(*) as UnreadCount
                        FROM ChatSchema.Messages 
                        WHERE IsRead = 0 
                        AND ProjectId = '{projectId}' 
                        AND CreatedUserId != '{currentUserId}'";

        var data = con.QueryFirstAsync<CountUnreadMessagesDto>(sql);
        if (data.Result.UnreadCount == null)
        {
            return new CountUnreadMessagesDto();
        }
        return data.Result;

    }

    public List<CategorizationDto>? GetSkillsForProject(List<Guid>? skillsIds)
    {
        if (!skillsIds.AsNotNull().Any()) return null;

        using var con = new SqlConnection(_connectionString);
        con.Open();
        string inClause = string.Join(",", skillsIds);


        var data = con.Query<CategorizationDto>(
            @"SELECT c.Id, c.Name
             FROM SettingsSchema.Skills c
              WHERE c.Id IN @SkillsIds",
            new { SkillsIds = skillsIds });

        return data.ToList();

    }
    public IndustryDetails? GetIndustryName(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        var sql = string.Empty;
        var userRole = GetUserRole(userId);

        try
        {
            if (userRole == RolesEnum.Company.ToString())
            {
                sql = @$"SELECT r.Name 
                              FROM SettingsSchema.Industries r 
                              JOIN UserSchema.Companies c ON r.Id = c.IndustryId
	                          WHERE c.Id = '{userId}'";

            }
            else
            {
                return null;
                //sql = @$"SELECT r.Name 
                //                  FROM SettingsSchema.Industries r
                //                  JOIN UserSchema.Companies c ON r.Id = c.IndustryId
                //               WHERE c.Id = '{userId}'";
            }
            var data = con.QueryFirstOrDefault<IndustryDetails>(sql);
            return data;
        }
        catch (Exception ex)
        {

            throw;
        }


    }

    public async Task<FreelancerInfoDto> GetFreelancerInfo(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();

        var sql = @$"  SELECT  f.Id, f.Name ,f.Title,c.Name as CountryName
                        FROM  UserSchema.Freelancers f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        LEFT JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{userId}' ";

        var data = await con.QueryFirstAsync<FreelancerInfoDto>(sql);

        return data;

    }

    public async Task<ImageDetailsDto> GetFreelancerImage(Guid? freelancerId)
    {
        if (freelancerId == Guid.Empty || freelancerId == null) return new ImageDetailsDto();

        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();

        var sql = @$"  SELECT f.ImageDetails_Key
                        FROM  UserSchema.Freelancers f
                        WHERE f.Id = '{freelancerId}' ";

        var key = await con.QueryFirstAsync<string>(sql);
        if (string.IsNullOrEmpty(key)) return new ImageDetailsDto();
        var result = new ImageDetailsDto()
        {
            Url = key.SetDownloadFileUrlByKey(_storageService)
        };
        return result;
    }
    public async Task<RoomInfoDto> GetRoomId(Guid clientId, Guid freelancerId)
    {

        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();

        var sql = @$"  SELECT f.Id
                        FROM  [ChatSchema].[Rooms] f
                        WHERE f.FreelancerId = '{freelancerId}' and  f.ClientId = '{clientId}'";

        var room = await con.QueryFirstAsync<RoomInfoDto>(sql);
        if (room == null) return new RoomInfoDto();

        return room;
    }

    public async Task<string> AddRoom(Guid freelancerId, Guid clientId)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();

        string insertSql = "INSERT INTO ChatSchema.Rooms (Id,FreelancerId, ClientId, IsDeleted, CreatedDate) VALUES (@Id, @FreelancerId, @ClientId,@IsDeleted,@CreatedDate)";

        await con.ExecuteAsync(insertSql, new { FreelancerId = freelancerId, ClientId = clientId, Id = Guid.NewGuid(), IsDeleted = false, CreatedDate = DateTimeOffset.UtcNow });
        return string.Empty;
    }
}