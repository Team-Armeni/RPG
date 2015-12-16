namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using System;

    public class CreateItemCommand : GameCommand
    {
        public CreateItemCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
