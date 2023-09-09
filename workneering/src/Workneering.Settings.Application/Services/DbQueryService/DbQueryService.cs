using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Base.Helpers.Extensions;
using Workneering.Settings.Application.Services.Models;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Settings.Application.Services.DbQueryService;

public class DbQueryService : IDbQueryService
{
    private readonly string _connectionString;

    public DbQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }


    public List<SubcategoryDetailsDto> GetSkillsBuSubCategoriesIds(List<Guid>? subcategoryIds, int pageSize = 10, int pageNumber = 1)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        var list = subcategoryIds.AsNotNull();
        List<string> stringList = list.Select(guid => guid.ToString()).ToList();

        string inClause = string.Join(",", stringList.AsNotNull());
        string subcategoryIdsString = string.Join(",", subcategoryIds.Select(id => $"'{id}'"));

        string sqlQuery = @$"
                            SELECT s.Id , s.Name
                            FROM SettingsSchema.Skills s
                            JOIN SettingsSchema.SubCategories sub ON s.SubCategoryId = sub.Id
                            WHERE sub.Id IN ({subcategoryIdsString})
                            ORDER BY sub.Id";
        var data = con.Query<SubcategoryDetailsDto>(sqlQuery);

        return data.ToList();
    }
}