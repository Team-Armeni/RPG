namespace RPGArmeni.UI
{
    using System;
    using Interfaces;

    public static class ConsoleRenderer
    {
        public static void WriteLine(string message, params object[] paramaters)
        {
            Console.WriteLine(message, paramaters);
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
