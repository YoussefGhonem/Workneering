using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Project.Application.Services.Models;

namespace Workneering.Project.Application.Services.DbQueryService;

public class DbQueryService : IDbQueryService
{
    private readonly string _connectionString;

    public DbQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public Guid GetUserCategoryId(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        con.OpenAsync();

        var data = con
            .QueryFirstOrDefault<Guid>(
                @$"SELECT 
                c.CategoryId
                FROM UserSchema.Freelancers f
                INNER JOIN
                UserSchema.FreelancerCategories c ON f.CategoryId = c.CategoryId
                WHERE f.Id = '{userId.ToString()}'");
        return data;
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
}