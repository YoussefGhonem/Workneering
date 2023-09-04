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
    public async Task<string?> UpdateOnAddressUser(Guid userId, UserAddressDetailsDto userAddressDetails, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var countryId = userAddressDetails.CountryId == null ? null : @$"'{userAddressDetails.CountryId}'";
        var City = userAddressDetails.City == null ? null : @$"'{userAddressDetails.City}'";
        var ZipCode = userAddressDetails.ZipCode == null ? null : @$"'{userAddressDetails.ZipCode}'";
        var Address = userAddressDetails.Address == null ? null : @$"'{userAddressDetails.Address}'";
        var sql = @$"
                UPDATE IdentitySchema.Users SET
                CountryId = {countryId}, 
                City = {City}, 
                ZipCode = {ZipCode}, 
                Address = {Address}
                WHERE Id = '{userId.ToString()}'";

        var data = con.Execute(sql);

        return string.Empty;
    }
}