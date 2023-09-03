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
                    [Address_CountryId],
                    [City],
                    [CountryId],
                FROM IdentitySchema.Users 
                WHERE Id = '{userId.ToString()}'");

        return userBasicInfo;
    }
    public async Task<UserAddressDto?> GetCountryInfo(Guid id, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);

        var data = await con
            .QueryFirstOrDefaultAsync<UserAddressDto>(
                @$"SELECT 
                     [Id],
                     [Name],
                     [Flag],
                     [Language]
                FROM SettingsSchema.Countries 
                WHERE Id = '{id.ToString()}'");

        return data;
    }

}