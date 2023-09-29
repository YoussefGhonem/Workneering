using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Message.Application.Services.Models;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Project.Application.Commands.CreateProject;
using Workneering.Shared.Core.Extention;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Message.Application.Services.DbQueryService;

public class DbQueryService : IDbQueryService
{
    private readonly string _connectionString;
    private readonly IStorageService _storageService;

    public DbQueryService(IConfiguration configuration, IStorageService storageService)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _storageService = storageService;
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

    public async Task<UserInfoDto> GetUserInfo(Guid id)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();

        string role = GetUserRole(id);
        string tableName = string.Empty;
        if (role.ToLower() == RolesEnum.Freelancer.ToString().ToLower())
        {
            tableName = "Freelancers";
        }
        else if (role.ToLower() == RolesEnum.Client.ToString().ToLower())
        {
            tableName = "Clients";
        }
        else if (role.ToLower() == RolesEnum.Company.ToString().ToLower())
        {
            tableName = "Companies";
        }

        var sql = @$"  SELECT  f.Id, f.Name ,f.Title,c.Name as CountryName
                        FROM  UserSchema.{tableName} f
                        INNER JOIN IdentitySchema.Users u ON f.Id = u.Id
                        LEFT JOIN SettingsSchema.Countries c ON u.CountryId = c.Id
                        WHERE f.Id = '{id}' ";

        var data = await con.QueryFirstAsync<UserInfoDto>(sql);

        return data;
    }

    public async Task<ImageDetailsDto> GetUserImage(Guid userId)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();

        var sql = @$"  SELECT f.ImageKey
                        FROM  IdentitySchema.Users f
                        WHERE f.Id = '{userId}' ";

        var key = await con.QueryFirstAsync<string>(sql);

        if (string.IsNullOrEmpty(key)) return new ImageDetailsDto();

        var result = new ImageDetailsDto()
        {
            Url = key.SetDownloadFileUrlByKey(_storageService)
        };
        return result;
    }
}