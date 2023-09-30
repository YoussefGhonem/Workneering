﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Workneering.Identity.Application.Services.Models;

namespace Workneering.Identity.Application.Services.DbQueryService
{
    public class DbQueryService : IDbQueryService
    {
        private readonly string _connectionString;

        public DbQueryService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<UserBaseData> GetUserData(string UserRole, Domain.Entities.User user, CancellationToken cancellationToken)
        {
            await using var con = new SqlConnection(_connectionString);
            await con.OpenAsync(cancellationToken);

            if (UserRole == "Freelancer")
            {
                var userBasicData = await con
                        .QueryFirstOrDefaultAsync<UserBaseData>(
                            @$"SELECT 
							   [WengazPoint],
							   [WengazPercentage] 
						FROM UserSchema.Freelancers 
						WHERE Id = '{user.Id.ToString()}'");
                return userBasicData;
            }
            else if (UserRole == "Company")
            {
                var userBasicData = await con
                        .QueryFirstOrDefaultAsync<UserBaseData>(
                            @$"SELECT 
							   [WengazPoint],
							   [WengazPercentage] 
						FROM UserSchema.Companies 
						WHERE Id = '{user.Id.ToString()}'");
                return userBasicData;
            }
            else if (UserRole == "Client")
            {
                var userBasicData = await con
                        .QueryFirstOrDefaultAsync<UserBaseData>(
                            @$"SELECT 
							   [WengazPoint],
							   [WengazPercentage] 
						FROM UserSchema.Clients 
						WHERE Id = '{user.Id.ToString()}'");
                return userBasicData;
            }
            return new UserBaseData();
        }
    }
}
