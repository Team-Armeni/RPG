namespace RPGArmeni.Engine.Commands
{
    using Interfaces;
    using System;

    public class HealCommand : GameCommand
    {
        public HealCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Player.SelfHeal();
        }
    }
}
