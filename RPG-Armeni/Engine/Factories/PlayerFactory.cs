namespace RPGArmeni.Engine.Factories
{
    using RPGArmeni.Interfaces;
    using System;
    using RPGArmeni.UI;
using System.Text.RegularExpressions;

    public class PlayerFactory
    {
        private static PlayerFactory instance;
        private static readonly Regex playerNamePattern = new Regex("([a-zA-Z]+){2,10}");

        private PlayerFactory()
        {
        }

        public static PlayerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerFactory();
                }

                return instance;
            }
        }

        public IPlayer CreatePlayer()
        {
            string name = this.GetPlayerName();
            return null;

        }

        private string GetPlayerName()
        {
            string name;
            Console.ForegroundColor = ConsoleColor.Green;
            ConsoleRenderer.Write("Type player's name : ");
            Console.ResetColor();
            ConsoleRenderer.WriteLine("(including only small and capital letters and between 2 and 10 characters)");
            while (true)
            {
                try
                {
                    name = ConsoleInputReader.ReadLine();

                    if (!playerNamePattern.IsMatch(name))
                    {
                        throw new ArgumentException("Invalid name. Try again.");
                    }

                    break;
                }
                catch (ArgumentException ex)
                {
                    ConsoleRenderer.WriteLine(ex.Message);
                } 
            }

            Console.ForegroundColor = ConsoleColor.Green;
            ConsoleRenderer.WriteLine("Player name set to: {0}", name);
            Console.ResetColor();

            return name;
        }
    }
}
