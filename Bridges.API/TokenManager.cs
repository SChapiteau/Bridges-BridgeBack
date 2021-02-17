using Bridges.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BridgeFront
{
    public class TokenManager
    {
        public string CreateToken(User user, byte[] secretkey)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_configuration["secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimNames.ID.ToString(), user.Id.ToString()),
                    new Claim(ClaimNames.NAME.ToString(), user.Name),
                    //new Claim(ClaimTypes.Email, user.Name),
                    new Claim(ClaimNames.ROLE.ToString(), ((int)user.Role).ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetClaim(string token, ClaimNames claimType)
        {            
            return GetClaimFromToken(token, claimType);
        }

        public T GetClaim<T>(string token, ClaimNames claimType) where T : Enum
        {            
            var stringClaimValue = GetClaimFromToken(token, claimType);
            return (T)Enum.Parse(typeof(T), stringClaimValue);
        }

        private string GetClaimFromToken(string token, ClaimNames claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.FirstOrDefault(claim => claim.Type == claimType.ToString()).Value;
            return stringClaimValue;
        }
    }

    public enum ClaimNames
    {
        ID,
        NAME,
        ROLE,
    }
}
