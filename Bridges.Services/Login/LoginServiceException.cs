using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services.Login
{
    public class LoginServiceException : Exception
    {
        public LoginServiceException(string message) : base(message)
        {

        }
    }
}
