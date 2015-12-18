using System;
using System.IO;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
	public static class GameStateScreens
	{
		public static void ShowGameOverScreen()
		{
			const int skullHeight = 19;
			string centerPadding = new string(' ', Console.BufferWidth / 4);

			var deathScreen = File.ReadAllLines("../../UI/Utility/GameOver.txt");
			Console.CursorVisible = false;

			Console.ForegroundColor = ConsoleColor.Gray;
			for (int i = 0; i < skullHeight; i++)
			{
				ConsoleRenderer.Write(centerPadding);
				ConsoleRenderer.WriteLine(deathScreen[i]);
			}
			Console.ForegroundColor = ConsoleColor.Red;
			for (int i = skullHeight; i < deathScreen.Length; i++)
			{
				ConsoleRenderer.Write(centerPadding);
				ConsoleRenderer.WriteLine(deathScreen[i]);
			}

			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
