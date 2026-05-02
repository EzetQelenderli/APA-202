using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    internal class IncorrectPasswordException:Exception
    {
        public IncorrectPasswordException(string message):base (message) { }
        
    }
}
