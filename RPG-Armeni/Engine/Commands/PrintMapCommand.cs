namespace RPGArmeni.Engine.Commands
{
    using Interfaces;
    using UI;
    using System;

    public class PrintMapCommand : GameCommand
    {
        public PrintMapCommand(IGameEngine engine)
            : base(engine)
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
                    switch (this.Engine.Map.Matrix[i, j])
                    {
	                    case 'H':
                        case 'B':
		                    ConsoleRenderer.ForegroundColor(ConsoleColor.Blue);
		                    break;
	                    case 'P':
		                    ConsoleRenderer.ForegroundColor(ConsoleColor.White);
		                    break;
	                    case 'A':
	                    case 'S':
		                    ConsoleRenderer.ForegroundColor(ConsoleColor.DarkCyan);
		                    break;
	                    case '~':
		                    ConsoleRenderer.BackgroundColor(ConsoleColor.DarkBlue);
		                    ConsoleRenderer.ForegroundColor(ConsoleColor.Cyan);
		                    break;
	                    default:
		                    ConsoleRenderer.ForegroundColor(ConsoleColor.Red);
		                    break;
					}
					ConsoleRenderer.Write(this.Engine.Map.Matrix[i, j].ToString());
				}

                ConsoleRenderer.WriteLine(string.Empty);
            }

            ConsoleRenderer.ResetColor();
        }
    }
}
