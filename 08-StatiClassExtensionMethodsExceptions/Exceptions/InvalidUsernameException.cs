using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    internal class InvalidUsernameException:Exception
    {
        public InvalidUsernameException(string message):base(message) { }
    }
}
