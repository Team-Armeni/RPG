namespace RPGArmeni.Exceptions
{
    using System;

    public class NoSlotAvailableException : Exception
    {
        public NoSlotAvailableException(string message)
            : base(message)
        {
        }
    }
}
