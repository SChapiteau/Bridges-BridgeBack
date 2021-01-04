using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bridges.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration _configuration;

        //Pour test
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" },
            new User { Id = 2, FirstName = "Test2", LastName = "User2", Username = "test2", Password = "test2" }
        };

        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
                    

        public User Authenticate(string username, string password)
        {
            //refaire la méthde de verficiation de password
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            user.Token = CreateToken(user);

            // remove password before returning
            user.Password = null;

            return user;
        }

        private string CreateToken(User user)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim("CustomClaim", "custom string"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
