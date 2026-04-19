using System;
using System.Collections.Generic;
using System.Text;

namespace _08_StatiClassExtensionMethodsExceptions.Exceptions
{
    internal class AccountLockedException:Exception
    {
        public AccountLockedException(string message) : base(message) { }
    }
}
