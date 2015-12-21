namespace RPGArmeni.Engine.Commands
{
    using Interfaces;
    using UI;
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
           throw new NotImplementedException();
        }

        public override void Execute()
        {
            ConsoleRenderer.WriteLine(this.Engine.Player.ToString());

            ConsoleRenderer.WriteLine(
                "Number of enemies left: {0}",
                this.Engine.Characters.Count());
        }
    }
}
