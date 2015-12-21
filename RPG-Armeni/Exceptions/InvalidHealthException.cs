namespace RPGArmeni.Exceptions
{
    using System;

    public class InvalidHealthException : Exception
    {
        public InvalidHealthException(string message)
            : base(message)
        {
        }
    }
}
