using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services.Users
{
    public class UserServiceException : Exception
    {
        public UserServiceException(string message) : base(message)
        {
        }
    }

    public class UserServiceLoginAlreadyUseException : UserServiceException
    {
        public UserServiceLoginAlreadyUseException(string message) : base(message)
        {
        }
    }

    public class UserServiceInValidUserException : UserServiceException
    {
        public UserServiceInValidUserException(string message) : base(message)
        {
        }
    }
}
