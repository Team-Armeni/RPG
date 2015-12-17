namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using RPGArmeni.UI;
    using System;
    using System.Linq;

    public class PlayerStatusCommand : GameCommand
    {
        public PlayerStatusCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
            ConsoleRenderer.WriteLine(this.Engine.Player.ToString());

            ConsoleRenderer.WriteLine(
                "Number of enemies left: {0}",
                this.Engine.Characters.Count());
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
