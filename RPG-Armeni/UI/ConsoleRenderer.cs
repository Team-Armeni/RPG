namespace RPGArmeni.UI
{
    using System;

	public static class ConsoleRenderer
    {
        public static void WriteLine(string message, params object[] paramaters)
        {
            Console.WriteLine(message, paramaters);
        }

        public static void Write(string message, params object[] parameters)
        {
            Console.Write(message, parameters);
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
