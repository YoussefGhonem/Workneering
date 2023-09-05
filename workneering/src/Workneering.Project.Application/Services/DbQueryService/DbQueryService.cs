using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Project.Application.Services.Models;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Project.Application.Services.DbQueryService;

public class DbQueryService : IDbQueryService
{
    private readonly string _connectionString;

    public DbQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public List<Guid> GetUserCategoryId(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        con.OpenAsync();

        var data = con
            .Query<Guid>(
                @$"SELECT CategoryId
                FROM ProjectsSchema.ProjectCategories WHERE
                WHERE c.UserId = '{userId.ToString()}'");

        return data.ToList();
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
    public FreelancerInfoForProposalsList GetFreelancerInfoForProposals(Guid freelancerId)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();

        var data = con
                    .QueryFirst<FreelancerInfoForProposalsList>(
                        @$"  SELECT  f.Id, f.Name ,f.Title , c.Name as CountryName
                        FROM  UserSchema.Freelancers f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        INNER JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{freelancerId}' ");

        return data;
    }
    public ClientInfoForProjectDetails GetClientInfoForProjectDetails(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        var userRole = GetUserRole(userId);
        dynamic data;
        if (userRole == RolesEnum.Company)
        {
            data = con
                       .QueryFirst<ClientInfoForProjectDetails>(
                           @$"  SELECT  f.Id, f.Name ,f.Title,f.FoundedIn,f.CompanySize,f.TitleOverview , c.Name as CountryName
                        FROM  UserSchema.Companies f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        INNER JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{userId}' ");
        }
        else
        {
            data = con
             .QueryFirst<ClientInfoForProjectDetails>(
                 @$"SELECT  f.Id, f.Name ,f.Title,f.TitleOverview, c.Name as CountryName
                        FROM  UserSchema.Clients f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        INNER JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{userId}' ");
        }

        return data;
    }
    public RolesEnum GetUserRole(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();

        var data = con
                    .QueryFirst<RolesEnum>(
                        @$"SELECT r.Name AS RoleName
                           FROM IdentitySchema.Roles r
                           INNER JOIN IdentitySchema.UserRoles ur ON r.Id = ur.RoleId
                           INNER JOIN IdentitySchema.Users u ON ur.UserId = u.Id
                           WHERE u.Id = '{userId}' ");

        return data;
    }


}