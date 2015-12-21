namespace RPGArmeni.Engine.Commands
{
    using Interfaces;
    using System;

    public class BackPackCommand : GameCommand
    {
        public BackPackCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            this.Engine.Player.Inventory.BackPack.ListItems();
        }
    }
}
