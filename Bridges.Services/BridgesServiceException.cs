using System;
using System.Collections.Generic;
using System.Text;

namespace Bridges.Services
{
    public class BridgesServiceException : Exception
    {
        public BridgesServiceException() : base()
        {
        }

        public BridgesServiceException(string message) : base(message)
        {
        }

        public BridgesServiceException(string message, Exception ex) : base(message,ex)
        {
        }
    }
}
