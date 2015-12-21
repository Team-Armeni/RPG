namespace RPGArmeni.Exceptions
{
    using System;

    public class BackPackFullException : Exception
    {
        public BackPackFullException(string message)
            : base(message)
        {   
        }
    }
}
