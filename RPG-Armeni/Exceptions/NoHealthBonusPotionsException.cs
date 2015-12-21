namespace RPGArmeni.Exceptions
{
    using System;

    public class NoHealthBonusPotionsException : Exception
    {
        public NoHealthBonusPotionsException(string message)
            : base(message)
        {
        }
    }
}
