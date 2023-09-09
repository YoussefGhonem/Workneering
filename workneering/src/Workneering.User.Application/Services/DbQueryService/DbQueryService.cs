using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Base.Domain.ValueObjects;
using Workneering.User.Application.Queries.Company.GetCompanyCategorization;
using Workneering.User.Application.Services.Models;

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

        var userBasicInfo = await con
            .QueryFirstOrDefaultAsync<UserBasicInfo>(
                @$"SELECT 
                       [Id],
                       [CountryId]
                      ,[City]
                      ,[ZipCode]
                      ,[Address] 
                FROM IdentitySchema.Users 
                WHERE Id = '{userId.ToString()}'");

        return userBasicInfo;
    }
    public async Task<CountryDetailsDto?> GetCountryInfo(Guid id, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);

        var data = await con
            .QueryFirstOrDefaultAsync<CountryDetailsDto>(
                @$"SELECT 
                     [Id],
                     [Name],
                     [Flag],
                     [Language]
                FROM SettingsSchema.Countries 
                WHERE Id = '{id.ToString()}'");

        return data;
    }
    public async Task<List<LanguagesListDto>> GetLanguagesAsync(List<Guid>? languagesIds)
    {
        if (languagesIds is null || !languagesIds.Any())
        {
            return default!;
        }
        string parameterList = string.Join(',', languagesIds.Select(id => id.ToString()));

        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var query = $@"SELECT Id, Name FROM SettingsSchema.Languages WHERE Id IN ('{parameterList}')";
        var languages = await con.QueryAsync<LanguagesListDto>(query);

        return languages.ToList();
    }
    public async Task<string?> UpdateCountryUser(Guid userId, Guid? CountryId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var countryId = CountryId == null ? null : @$"'{CountryId}'";
        var sql = @$"
                UPDATE IdentitySchema.Users SET
                CountryId = {countryId}
                WHERE Id = '{userId.ToString()}'";

        var data = con.Execute(sql);

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

    public async Task<CategorizationDto> GetCategorizationAsync(IEnumerable<Guid> categoriesId, IEnumerable<Guid> subCategoriesId, IEnumerable<Guid> skillsId , CancellationToken cancellationToken)
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

}