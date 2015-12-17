using System.IO;

namespace RPGArmeni.Engine.Commands
{
	using Interfaces;
	using Models.Items;
	using UI;
	using System;
	using System.Linq;

	public class MovePlayerCommand : GameCommand
	{
		public MovePlayerCommand(IGameEngine engine)
			: base(engine)
		{
		}

		public override void Execute(string[] args)
		{
			string direction = args[0];

			this.Engine.Player.Move(direction);

			ICharacter currentEnemy = this.Engine
				.Characters
				.FirstOrDefault(x => x.Position.X == this.Engine.Player.Position.X
				                     && x.Position.Y == this.Engine.Player.Position.Y) as ICharacter;

			if (currentEnemy != null)
			{
				this.EnterBattle(currentEnemy);
				return;
			}

			IGameItem currentItem = this.Engine
				.Items
				.FirstOrDefault(e => e.Position.X == this.Engine.Player.Position.X
				                     && e.Position.Y == this.Engine.Player.Position.Y
				                     && e.ItemState == ItemState.Available);

			if (currentItem != null)
			{
				currentItem.ItemState = ItemState.Collected;
				this.Engine.Player.Inventory.BackPack.LootItem(currentItem);
				ConsoleRenderer.WriteLine("Health potion collected!");
			}
		}

		private void EnterBattle(ICharacter currentEnemy)
		{
			ConsoleRenderer.WriteLine("An enemy {0} is approaching. Prepare for battle!", currentEnemy.GetType().Name);
			while (true)
			{
				this.Engine.Player.Attack(currentEnemy);
				ConsoleRenderer.WriteLine("You smash the {0} for {1} damage!",
					currentEnemy.GetType().Name, this.Engine.Player.Damage);

				if (currentEnemy.Health <= 0)
				{
					ConsoleRenderer.WriteLine("Enemy killed!");
					this.Engine.RemoveEnemy(currentEnemy);
					return;
				}

				currentEnemy.Attack(this.Engine.Player);
				ConsoleRenderer.WriteLine("The {0} hits you for {1} damage!",
					currentEnemy.GetType().Name, currentEnemy.Damage);

				if (this.Engine.Player.Health <= 0)
				{
					this.Engine.IsRunning = false;
					ShowGameOverScreen();
					return;
				}
			}
		}

		private static void ShowGameOverScreen()
		{
			// todo: refactor this into another class

			const int skullHeight = 19;
			string centerPadding = new string(' ', Console.BufferWidth / 4);

			var deathScreen = File.ReadAllLines("../../UI/Utility/GameOver.txt");
			Console.Clear();
			Console.CursorVisible = false;

			Console.ForegroundColor = ConsoleColor.Gray;
			for (int i = 0; i < skullHeight; i++)
			{
				Console.Write(centerPadding);
				ConsoleRenderer.WriteLine(deathScreen[i]);
			}
			Console.ForegroundColor = ConsoleColor.Red;
			for (int i = skullHeight; i < deathScreen.Length; i++)
			{
				Console.Write(centerPadding);
				ConsoleRenderer.WriteLine(deathScreen[i]);
			}

			Console.ForegroundColor = ConsoleColor.White;
		}

		public override void Execute()
		{
		}
	}
}