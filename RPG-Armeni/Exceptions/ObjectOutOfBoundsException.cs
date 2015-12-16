namespace RPGArmeni.Exceptions
{
    using System;

    public class ObjectOutOfBoundsException : Exception
    {
        public ObjectOutOfBoundsException(string message)
            : base(message)
        {
        }
    }
}
