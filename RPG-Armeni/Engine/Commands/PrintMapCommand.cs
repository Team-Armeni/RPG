﻿namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using RPGArmeni.Models.Items;
    using RPGArmeni.UI;
    using System;
    using System.Text;

    public class PrintMapCommand : GameCommand
    {
        public PrintMapCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < this.Engine.Map.Height; row++)
            {
                for (int col = 0; col < this.Engine.Map.Width; col++)
                {
                    if (this.Engine.Player.Position.X == col && this.Engine.Player.Position.Y == row)
                    {
                        sb.Append('P');
                        continue;
                    }

                    //var character =
                    //     this.Engine.Characters
                    //     .Cast<ICharacter>()
                    //     .FirstOrDefault(c => c.Position.X == col
                    //         && c.Position.Y == row
                    //         && c.Health > 0);

                    //var item = this.Engine.Items
                    //    .Cast<IGameItem>()
                    //    .FirstOrDefault(c => c.Position.X == col
                    //        && c.Position.Y == row
                    //        && c.ItemState == ItemState.Available);

                    //if (character == null && item == null)
                    //{
                    //    sb.Append('.');
                    //}
                    //else if (character != null)
                    //{
                    //    var ch = character as GameObject;
                    //    sb.Append(ch.ObjectSymbol);
                    //}
                    //else
                    //{
                    //    sb.Append(item.ObjectSymbol);
                    //}
                }

                sb.AppendLine();
            }

            ConsoleRenderer.WriteLine(sb.ToString());
        }
    }
}