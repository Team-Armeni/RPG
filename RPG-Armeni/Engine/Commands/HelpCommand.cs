using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string helpInfo = File.ReadAllText("../../HelpInfo.txt");

            ConsoleRenderer.WriteLine(helpInfo);
        }
    }
}
