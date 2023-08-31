﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Workneering.Identity.Domain.Entities;
using Workneering.Base.Application.Extensions;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Commands.Identity.Login
{
    public static class JsonWebTokenGeneration
    {
        public static string GenerateJwtToken(IConfiguration configuration, User user)
        {
            var jwtConfig = configuration.GetJwtConfig();
            var signingKey = Convert.FromBase64String(jwtConfig.Key);

            #region Add Claims

            var claims = new List<Claim>();

            claims.AddClaim(ClaimKeys.Id, user.Id.ToString());
            claims.AddClaim(ClaimKeys.Email, user.Email);
            claims.AddClaim(ClaimKeys.FirstName, user.GetClaimValue(ClaimKeys.FirstName));
            claims.AddClaim(ClaimKeys.LastName, user.GetClaimValue(ClaimKeys.LastName));
            claims.AddRange(user.UserRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Role.Name)));

            #endregion

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(jwtConfig.ExpiryDuration),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);

            return token;
        }

        #region Add Claims Helper Methods

        private static void AddClaim(this ICollection<Claim> claims, string propKey, string? propValue)
        {
            if (propValue is null) return;
            claims.Add(new Claim(propKey, propValue));
        }

        private static string? GetClaimValue(this User user, string claimType)
        {
            var userClaim = user.Claims.FirstOrDefault(u => u.ClaimType == claimType);
            return userClaim?.ClaimValue;
        }

        #endregion
    }
}