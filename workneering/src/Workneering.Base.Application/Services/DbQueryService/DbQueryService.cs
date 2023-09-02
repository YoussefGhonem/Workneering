using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Base.Domain.ValueObjects;

namespace Workneering.Base.Application.Services.DbQueryService;

public class DbQueryService : IDbQueryService
{
    private readonly string _connectionString;

    public DbQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<AddressCountryDto> GetAddressCountryDtoByIdAsync(Guid? countryId)
    {
        if (countryId is null) return new AddressCountryDto();
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var country = await con
            .QueryFirstOrDefaultAsync<AddressCountryDto>(
                @$"SELECT [Id]as [CountryId],[Name],[Flag]
                    FROM [SettingsSchema].[Countries] WHERE Id='{countryId}'");
        return country;
    }


    public async Task<bool> IsCountryIdExistAsync(Guid countryId, CancellationToken cancellationToken)
    {
        await using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);

        var country = await con
            .QueryFirstOrDefaultAsync<Guid?>(
                @$"SELECT Id
                FROM [SettingsSchema].[Countries] WHERE Id='{countryId}'");
        return country is not null;
    }
}