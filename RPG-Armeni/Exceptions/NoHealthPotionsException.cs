namespace RPGArmeni.Exceptions
{
    using System;

    public class NoHealthPotionsException : Exception
    {
        public NoHealthPotionsException(string message)
            : base(message)
        {
        }
    }
}
