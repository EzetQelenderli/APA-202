using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    internal class UserNotFoundException:Exception
    {
       public UserNotFoundException(string message):base(message) { }
    }
}
