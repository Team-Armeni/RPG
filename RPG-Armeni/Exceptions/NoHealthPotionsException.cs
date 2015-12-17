using System;

namespace RPGArmeni.Exceptions
{
    public class NoHealthPotionsException : Exception
    {
        public NoHealthPotionsException(string message)
            : base(message)
        {
        }
    }
}
