using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services
{
    public class UserService : IUSerService
    {
        private ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILoggerFactory loggerFactory, IUserRepository userRepository)
        {
            _logger = loggerFactory.CreateLogger<UserService>();
            _userRepository = userRepository;
        }


        public void AddUser(User user)
        {
            try
            {
                if (_userRepository.GetByLogin(user.Login) == null) throw new UserServiceInValidLoginException("Login déja utilisé");                

                user.Password = PasswordHahsingHelper.HashPassword(user.Password);
                user.IsActive = true;
                _userRepository.AddUser(user);
                 
            }            
            catch(UserServiceException e)
            {
                throw e;
            }
            catch( Exception ex)
            {
                _logger.LogError("Erreur dans UserService.AddUser", ex);
                throw new BridgesServiceException("Erreur dans UserService.AddUser");
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAll();
        }
    }

}
