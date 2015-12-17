namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using RPGArmeni.Models.Items;
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
            IGameObject currentEnemy = this.Engine
                .Characters
                .FirstOrDefault(x => x.Position.X == this.Engine.Player.Position.X &&
                x.Position.Y == this.Engine.Player.Position.Y);

            if (currentEnemy != null)
            {
                this.EnterBattle(currentEnemy);
                return;
            }

            IGameItem healthPotion =
                this.Engine.Items
                .FirstOrDefault(
                    e => e.Position.X == this.Engine.Player.Position.X
                        && e.Position.Y == this.Engine.Player.Position.Y
                        && e.ItemState == ItemState.Available);

            if (healthPotion != null)
            {
                //this.player.AddItemToInventory(beer);
                healthPotion.ItemState = ItemState.Collected;
                ConsoleRenderer.WriteLine("Health potion collected!");
            }
        }

        private void EnterBattle(IGameObject currentEnemy)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
        }
    }
}
