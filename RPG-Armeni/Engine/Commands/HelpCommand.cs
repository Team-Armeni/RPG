namespace RPGArmeni.Engine.Commands
{
    using Interfaces;
    using System.IO;
    using UI;

    public class HelpCommand : GameCommand
    {
        public HelpCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            string helpInfo = File.ReadAllText("../../UI/Utility/HelpInfo.txt");

            ConsoleRenderer.WriteLine(helpInfo);
        }
    }
}
