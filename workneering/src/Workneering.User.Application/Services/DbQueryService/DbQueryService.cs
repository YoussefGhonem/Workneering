using Dapper;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using System;
using System.Data.SqlClient;
using System.Threading;
using Workneering.Base.Helpers.Extensions;
using Workneering.Shared.Core.Identity.Enums;
using Workneering.User.Application.Queries.Company.GetCompanyCategorization;
using Workneering.User.Application.Services.Models;
using Workneering.User.Domain.Helpr;

namespace Workneering.User.Application.Services.DbQueryService;

public class DbQueryService : IDbQueryService
{
    private readonly string _connectionString;

    public DbQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<UserBasicInfo?> GetUserBasicInfo(Guid userId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var sql = @$"SELECT 
                       [Id],
                       [CountryId]
                      ,[City]
                      ,[ZipCode]
                      ,[Address] 
                FROM IdentitySchema.Users 
                WHERE Id = '{userId.ToString()}'";
        var userBasicInfo = await con
            .QueryFirstOrDefaultAsync<UserBasicInfo>(sql);

        return userBasicInfo;
    }
    public async Task<CountryDetailsDto?> GetCountryInfo(Guid id, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var sql = @$"SELECT 
                     [Id],
                     [Name],
                     [Flag],
                     [Language]
                FROM SettingsSchema.Countries 
                WHERE Id = '{id.ToString()}'";
        var data = await con
            .QueryFirstOrDefaultAsync<CountryDetailsDto>(sql);
        if (data == null)
        {
            return new CountryDetailsDto();
        }
        return data;
    }
    public async Task<CountryDetailsDto?> GetCountryInfoByUserId(Guid userId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var sql = @$"SELECT 
                 c.[Id],
                 c.[Name],
                 c.[Flag],
                 c.[Language]
            FROM SettingsSchema.Countries c
            INNER JOIN IdentitySchema.Users u ON c.Id = u.CountryId
            WHERE u.Id = '{userId.ToString()}'";
        var data = await con
            .QueryFirstOrDefaultAsync<CountryDetailsDto>(sql);
        if (data == null)
        {
            return new CountryDetailsDto();
        }
        return data;
    }
    public async Task<List<LanguagesListDto>> GetLanguagesAsync(List<Guid>? languagesIds)
    {
        if (languagesIds is null || !languagesIds.Any())
        {
            return default!;
        }
        string parameterList = string.Join(',', languagesIds.Select(id => id.ToString()));
        string[] uuids = parameterList.Split(',');
        for (int i = 0; i < uuids.Length; i++)
        {
            uuids[i] = $"'{uuids[i]}'";
        }

        string result = string.Join(",", uuids);

        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var query = $@"SELECT Id, Name FROM SettingsSchema.Languages WHERE Id IN ({result})";
        var languages = await con.QueryAsync<LanguagesListDto>(query);

        return languages.ToList();
    }
    public async Task<string?> UpdateCountryUser(Guid userId, Guid? CountryId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var countryId = CountryId == null ? null : @$"'{CountryId}'";

        var tableName = string.Empty;
        var numberOffield = 0;
        var getRolesql = $@"
                           SELECT r.Name AS RoleName
                           FROM IdentitySchema.Roles r
                           INNER JOIN IdentitySchema.UserRoles ur ON r.Id = ur.RoleId
                           INNER JOIN IdentitySchema.Users u ON ur.UserId = u.Id
                           WHERE u.Id = '{userId}'";
        var getroles = await con.QueryFirstOrDefaultAsync<string>(getRolesql);

        if (getroles == RolesEnum.Freelancer.ToString())
        {
            tableName = "Freelancers";
            numberOffield = typeof(FreelancersPercentageFields).GetProperties().Count();

        }
        else if (getroles == RolesEnum.Company.ToString())
        {
            tableName = "Companies";
            numberOffield = typeof(CompanyPercentageFields).GetProperties().Count();
        }
        else
        {
            tableName = "Clients";
            numberOffield = typeof(ClientPercentageFields).GetProperties().Count();

        }

        var selectCountryValuesql = $@"
                SELECT IsCountainCountry FROM UserSchema.{tableName}
                WHERE Id = '{userId.ToString()}'";
        var selectCountryValue = await con.QueryFirstOrDefaultAsync<bool>(selectCountryValuesql);

        if (selectCountryValue is false)
        {
            var wengazsql = $@"
                SELECT WengazPercentage FROM UserSchema.{tableName}
                WHERE Id = '{userId.ToString()}'";
            decimal wengazeValue = await con.QueryFirstOrDefaultAsync<decimal>(wengazsql);
            decimal numberOfNotNull = (int)Math.Round(((wengazeValue / 100) * numberOffield), MidpointRounding.AwayFromZero);
            var newPercentage = (((numberOfNotNull + 1) / numberOffield) * 100);
            var wengazssql = @$"
                UPDATE UserSchema.{tableName} SET
                WengazPercentage = {newPercentage}
                WHERE Id = '{userId.ToString()}'";
            await con.ExecuteAsync(wengazssql);
        }
        var sql = @$"
                UPDATE IdentitySchema.Users SET
                CountryId = {countryId}
                WHERE Id = '{userId.ToString()}'";
        var updateIsCountaisCountry = $@"
                UPDATE UserSchema.{tableName} SET IsCountainCountry = {1}
                WHERE Id = '{userId.ToString()}'";

        var data = con.Execute(sql);
        await con.ExecuteAsync(updateIsCountaisCountry);

        return string.Empty;
    }

    public async Task<UserAddressDetailsDto> GetAddressUser(Guid userId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);

        var data = await con
            .QueryFirstOrDefaultAsync<UserAddressDetailsDto>(
                @$"SELECT 
                     [Id],
                     [City],
                     [Address],
                     [ZipCode]
                FROM IdentitySchema.Users 
                WHERE Id = '{userId.ToString()}'");

        return data;
    }

    public async Task<CategorizationDto> GetCategorizationAsync(IEnumerable<Guid> categoriesId, IEnumerable<Guid> subCategoriesId, IEnumerable<Guid> skillsId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        string categoriesIdParametrs = categoriesId.Any() ? $"'{string.Join("','", categoriesId)}'" : "null";
        string subCategoriesIdParametrs = subCategoriesId.Any() ? $"'{string.Join("','", subCategoriesId)}'" : "null";
        string skillsIdParametrs = skillsId.Any() ? $"'{string.Join("','", skillsId)}'" : "null";
        string query = @$"SELECT Id, Name From SettingsSchema.Categories AS Categories
                            WHERE Id in ({categoriesIdParametrs})
                            SELECT Id, Name From SettingsSchema.SubCategories AS SubCategories
                            WHERE Id in ({subCategoriesIdParametrs})
                            SELECT Id, Name From SettingsSchema.Skills AS Skills
                            WHERE Id in ({skillsIdParametrs}) ";

        using (var multi = await con.QueryMultipleAsync(query, new
        {
            CategoriesIds = categoriesIdParametrs.Split(','),
            SubCategoriesIds = subCategoriesIdParametrs.Split(','),
            SkillsIds = skillsIdParametrs.Split(',')
        }))
        {
            var result = new CategorizationDto
            {
                Categories = multi.Read<LookupDto>().ToList(),
                SubCategories = multi.Read<LookupDto>().ToList(),
                Skills = multi.Read<LookupDto>().ToList()
            };

            return result;
        }
    }
    public async Task<CategorizationDto> GetCategoriesAsync(IEnumerable<Guid>? categoriesId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        string categoriesIdParametrs = categoriesId.AsNotNull().Any() ? $"'{string.Join("','", categoriesId)}'" : "null";
        string query = @$"SELECT Id, Name From SettingsSchema.Categories AS Categories
                            WHERE Id in ({categoriesIdParametrs}) ";

        using (var multi = await con.QueryMultipleAsync(query, new
        {
            CategoriesIds = categoriesIdParametrs.Split(','),
        }))
        {
            var result = new CategorizationDto
            {
                Categories = multi.Read<LookupDto>().ToList(),
            };

            return result;
        }
    }
    public void UpdateUserIdentityImageKey(Guid userId, string imageKey)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();

        var sql = $@"UPDATE IdentitySchema.Users SET  ImageKey = '{imageKey}'  WHERE Id = '{userId.ToString()}'";

        var data = con.Execute(sql);
    }

    public async Task<string> GetImageKey(Guid ClientId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);

        var data = await con
            .QueryFirstOrDefaultAsync<string>(
                @$"SELECT 
                     [ImageKey]
                FROM IdentitySchema.Users 
                WHERE Id = '{ClientId.ToString()}'");

        return data;
    }


}