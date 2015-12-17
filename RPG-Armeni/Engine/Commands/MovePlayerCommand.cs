namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using RPGArmeni.Models.Items;
    using RPGArmeni.UI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
                ConsoleRenderer.WriteLine("The {0} hits you for {1}",
                    currentEnemy.GetType().Name, currentEnemy.Damage);

                if (this.Engine.Player.Health <= 0)
                {
                    this.Engine.IsRunning = false;
                    ConsoleRenderer.WriteLine("You died!");
                    return;
                }
            }
        }

        public override void Execute()
        {
        }
    }
}
