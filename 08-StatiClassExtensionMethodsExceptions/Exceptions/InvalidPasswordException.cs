using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    internal class InvalidPasswordException:Exception
    {
        public InvalidPasswordException(string message) : base(message) { }
    }
}
