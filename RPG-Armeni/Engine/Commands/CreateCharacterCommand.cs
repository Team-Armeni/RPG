namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using System;

    public class CreateCharacterCommand : GameCommand
    {
        public CreateCharacterCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
