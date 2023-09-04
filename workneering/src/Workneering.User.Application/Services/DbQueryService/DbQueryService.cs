using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Base.Domain.ValueObjects;
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
    public async Task<string?> UpdateCountryUser(Guid userId, Guid? CountryId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var countryId = CountryId == null ? null : @$"'{CountryId}'";
        var sql = @$"
                UPDATE IdentitySchema.Users SET
                CountryId = {countryId}, 
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
}