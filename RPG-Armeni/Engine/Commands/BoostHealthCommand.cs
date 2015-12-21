namespace RPGArmeni.Engine.Commands
{
    using Interfaces;
    using System;

    public class BoostHealthCommand : GameCommand
    {
        public BoostHealthCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Player.DrinkHealthBonusPotion();
        }
    }
}
