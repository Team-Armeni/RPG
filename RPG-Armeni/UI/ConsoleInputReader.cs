namespace RPGArmeni.UI
{
    using System;
    using Interfaces;

    public static class ConsoleInputReader : IInputReader
    {
        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
