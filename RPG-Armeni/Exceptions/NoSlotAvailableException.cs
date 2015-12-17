using System;

namespace RPGArmeni.Exceptions
{
    public class NoSlotAvailableException : Exception
    {
        public NoSlotAvailableException(string message)
            : base(message)
        {
        }
    }
}
