using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services
{
    public class UserService : IUSerService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public bool AddUser(User user)
        {
            try
            {
                user.Password = PasswordHahsingHelper.HashPassword(user.Password);
                _userRepository.AddUser(user);

                return true;
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAll();
        }
    }
}
