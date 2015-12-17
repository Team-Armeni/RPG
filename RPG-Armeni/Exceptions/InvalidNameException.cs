using System;

namespace RPGArmeni.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message)
            : base(message)
        {
        }
    }
}
