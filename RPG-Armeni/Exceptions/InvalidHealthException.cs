using System;

namespace RPGArmeni.Exceptions
{
    public class InvalidHealthException : Exception
    {
        public InvalidHealthException(string message)
            : base(message)
        {
        }
    }
}
