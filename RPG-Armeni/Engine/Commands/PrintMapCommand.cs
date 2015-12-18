namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using UI;
    using System;

    public class PrintMapCommand : GameCommand
    {
        public PrintMapCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
        }

        public override void Execute()
        {
            ConsoleRenderer.BackgroundColor(ConsoleColor.Green);
            ConsoleRenderer.ForegroundColor(ConsoleColor.Red);
            for (int i = 0; i < this.Engine.Map.Height; i++)
            {
                for (int j = 0; j < this.Engine.Map.Width; j++)
                {
                    if (this.Engine.Map.Matrix[i, j] == 'H')
                    {
                        ConsoleRenderer.ForegroundColor(ConsoleColor.Blue);
                        ConsoleRenderer.Write(this.Engine.Map.Matrix[i, j].ToString());
                    }
                    else if (this.Engine.Map.Matrix[i, j] == 'P')
                    {
                        ConsoleRenderer.ForegroundColor(ConsoleColor.White);
                        ConsoleRenderer.Write(this.Engine.Map.Matrix[i, j].ToString());
                    }
                    else if ((this.Engine.Map.Matrix[i, j] == 'A') || (this.Engine.Map.Matrix[i, j] == 'S'))
                    {
                        ConsoleRenderer.ForegroundColor(ConsoleColor.DarkCyan);
                        ConsoleRenderer.Write(this.Engine.Map.Matrix[i, j].ToString());
                    }
                    else if (this.Engine.Map.Matrix[i, j] == '~')
                    {
                        ConsoleRenderer.BackgroundColor(ConsoleColor.DarkBlue);
                        ConsoleRenderer.ForegroundColor(ConsoleColor.Cyan);
                        ConsoleRenderer.Write(this.Engine.Map.Matrix[i, j].ToString());
                        ConsoleRenderer.BackgroundColor(ConsoleColor.Green);
                    }
                    else
                    {
                        ConsoleRenderer.ForegroundColor(ConsoleColor.Red);
                        ConsoleRenderer.Write(this.Engine.Map.Matrix[i, j].ToString());
                    }
                }

                ConsoleRenderer.WriteLine(string.Empty);
            }

            ConsoleRenderer.ResetColor();
        }
    }
}
