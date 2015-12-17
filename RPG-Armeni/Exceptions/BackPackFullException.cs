using System;

namespace RPGArmeni.Exceptions
{
    public class BackPackFullException : Exception
    {
        public BackPackFullException(string message)
            : base(message)
        {   
        }
    }
}
