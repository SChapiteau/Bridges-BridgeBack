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
        private List<Utilisateur> _users = new List<Utilisateur>
        {
            new Utilisateur { Id = Guid.NewGuid(), Prenom = "Test", Nom = "User", Pseudo = "test"},
            new Utilisateur { Id = Guid.NewGuid(), Prenom = "Test2", Nom = "User2", Pseudo = "test2"}
        };

        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
                    

        public Utilisateur Authenticate(string username, string password)
        {
            //refaire la méthde de verficiation de password
            var user = _users.SingleOrDefault(x => x.Pseudo == username);//&& x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            user.Token = CreateToken(user);
            
            return user;
        }

        private string CreateToken(Utilisateur user)
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
