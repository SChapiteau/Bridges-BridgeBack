using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services
{
    public class UserServiceException : Exception
    {
        public UserServiceException(string message) : base(message)
        {
        }
    }

    public class UserServiceInValidLoginException : UserServiceException
    {
        public UserServiceInValidLoginException(string message) : base(message)
        {
        }
    }    
}
