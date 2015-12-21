using System;

namespace RPGArmeni.Exceptions
{
    public class NoHealthBonusPotionsException : Exception
    {
        public NoHealthBonusPotionsException(string message)
            : base(message)
        {
        }
    }
}
