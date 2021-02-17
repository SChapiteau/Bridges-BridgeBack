using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Bridges.Services.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bridges.Services.Login
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
                    

        public User Authenticate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) return null; //throw new LoginServiceException("Login ou passworn non valide");

            User user = _userRepository.GetByLogin(login);

            if(user != null && user.IsActive && isCredentialValid(user, password))
            {
                return user;
            }
            else
                return null;

            
        }

        private bool isCredentialValid(User user, string password)
        {
            return PasswordHahsingHelper.ValidatePassword(password, user.Password);
        }

        //private string CreateToken(User user)
        //{
        //    // authentication successful so generate jwt token
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_configuration["secret"]);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
                    
        //            new Claim(ClaimNames.ID.ToString(), user.Id.ToString()),
        //            new Claim(ClaimNames.NAME.ToString(), user.Name),
        //            //new Claim(ClaimTypes.Email, user.Name),
        //            new Claim(ClaimNames.ROLE.ToString(), ((int)user.Role).ToString()),                    
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
