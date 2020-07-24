using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Exceptions
{
    public class CustomerAlreadyRegisteredException : Exception
    {
        public CustomerAlreadyRegisteredException()
        {
        }

        public CustomerAlreadyRegisteredException(string message)
            : base(message)
        {
        }

        public CustomerAlreadyRegisteredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
