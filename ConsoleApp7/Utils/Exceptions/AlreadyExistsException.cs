using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message)
        {

        }
    }
}
