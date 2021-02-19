using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services.Users
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

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAll();
        }

        public void AddUser(User user)
        {
            try
            {
                if (!user.isValid()) throw new UserServiceInValidUserException("donnée utilisateur manquante");
                if (_userRepository.GetByLogin(user.Login) != null) throw new UserServiceLoginAlreadyUseException("Login déja utilisé");                

                user.Password = PasswordHahsingHelper.HashPassword(user.Password);
                user.IsActive = true;
                user.Role = UserRole.Consumer;
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

        public void UpdateUser(User user)
        {
            try
            {
                var userToUpdate = _userRepository.GetById(user.Id);

                if (userToUpdate == null) throw new UserServiceInValidUserException("Id utilisateur non trouvé");

                userToUpdate.Name = user.Name;
                userToUpdate.Firstname = user.Firstname;
                userToUpdate.Role = user.Role;
                userToUpdate.IsActive = user.IsActive;
                userToUpdate.Login = user.Login;

                _userRepository.UpdateUser(userToUpdate);
            }
            catch (UserServiceException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erreur dans UserService.AddUser", ex);
                throw new BridgesServiceException("Erreur dans UserService.AddUser");
            }
        }

        public void DeleteUser(User user)
        {
            try
            {
                var userToDelete = _userRepository.GetById(user.Id);

                if (userToDelete == null) throw new UserServiceInValidUserException("Id utilisateur non trouvé");
                
                _userRepository.DeleteUser(userToDelete);
            }
            catch (UserServiceException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erreur dans UserService.AddUser", ex);
                throw new BridgesServiceException("Erreur dans UserService.AddUser");
            }
        }
    }

}
