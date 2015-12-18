using System;
using RPGArmeni.Interfaces;
using System.IO;
using RPGArmeni.UI;

namespace RPGArmeni.Engine.Commands
{
    public class HelpCommand : GameCommand
    {
        public HelpCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
            
        }

        public override void Execute()
        {
            string helpInfo = File.ReadAllText("../../UI/Utility/HelpInfo.txt");

            ConsoleRenderer.WriteLine(helpInfo);
        }
    }
}
