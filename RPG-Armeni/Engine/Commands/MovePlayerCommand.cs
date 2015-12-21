namespace RPGArmeni.Engine.Commands
{
	using Interfaces;
	using Models.Items;
	using UI;
	using System.Linq;
    using Exceptions;

	public class MovePlayerCommand : GameCommand
	{
		public MovePlayerCommand(IGameEngine engine)
			: base(engine)
		{
		}

        public override void Execute(IKeyInfo directionKey)
        {
            this.Engine.Player.Move(directionKey);

            ICharacter currentEnemy = this.FindEnemy();

            if (currentEnemy != null)
            {
                this.EnterBattle(currentEnemy);
                return;
            }

            IGameItem currentItem = this.FindItem();

            if (currentItem != null)
            {
                this.CollectItem(currentItem);
            }
        }

        public override void Execute()
        {
        }

        private void CollectItem(IGameItem currentItem)
        {
            currentItem.ItemState = ItemState.Collected;
            this.Engine.Player.Inventory.BackPack.LootItem(currentItem);
            ConsoleRenderer.WriteLine("{0} collected!", currentItem.GetType().Name);
        }


        private void EnterBattle(ICharacter currentEnemy)
		{
			ConsoleRenderer.WriteLine(
                "An enemy {0} is approaching. Prepare for battle!", 
                currentEnemy.GetType().Name);
			while (true)
			{
				this.Engine.Player.Attack(currentEnemy);
				ConsoleRenderer.WriteLine("You smash the {0} for {1} damage!",
					currentEnemy.GetType().Name, this.Engine.Player.Damage);

				if (currentEnemy.Health <= 0)
				{
					ConsoleRenderer.WriteLine("Enemy killed!");
                    ConsoleRenderer.WriteLine("Health Remaining: {0}", this.Engine.Player.Health);
					this.Engine.RemoveEnemy(currentEnemy);
					return;
				}

				currentEnemy.Attack(this.Engine.Player);
				ConsoleRenderer.WriteLine("The {0} hits you for {1} damage!",
					currentEnemy.GetType().Name, currentEnemy.Damage);

                if (this.Engine.Player.Health < 150 && this.Engine.Player.Inventory.BackPack.SlotList.Any(x => x.GameItem is HealthPotion
                    || x.GameItem is HealthBonusPotion))
                {
                    try
                    {
                        this.Engine.Player.SelfHeal();
                    }
                    catch (NoHealthPotionsException ex)
                    {
                        ConsoleRenderer.WriteLine(ex.Message);
                    }
                }

				if (this.Engine.Player.Health <= 0)
				{
					this.Engine.IsRunning = false;
					GameStateScreens.ShowGameOverScreen();
					return;
				}
			}
		}

        private IGameItem FindItem()
        {
            return this.Engine
                            .Items
                            .FirstOrDefault(e => e.Position.X == this.Engine.Player.Position.X
                                                 && e.Position.Y == this.Engine.Player.Position.Y
                                                 && e.ItemState == ItemState.Available);
        }

        private ICharacter FindEnemy()
        {
            return this.Engine
                            .Characters
                            .FirstOrDefault(x => x.Position.X == this.Engine.Player.Position.X
                                                 && x.Position.Y == this.Engine.Player.Position.Y) as ICharacter;
        }
    }
}