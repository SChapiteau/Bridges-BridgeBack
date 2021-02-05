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
        private readonly IUserRepository _userRepository;

        public LoginService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
                    

        public string Authenticate(string login, string password)
        {            
            User user = _userRepository.GetByLogin(login);

            if(user != null && user.IsActive && isCredentialValid(user, password))
            {
                return CreateToken(user);                
            }
            else
                return null;

            
        }

        private bool isCredentialValid(User user, string password)
        {
            return PasswordHahsingHelper.ValidatePassword(password, user.Password);
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
                    
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    //new Claim(ClaimTypes.Email, user.Name),
                    new Claim(ClaimTypes.Role, ((int)user.Role).ToString()),                    
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
