namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MovePlayerCommand : GameCommand
    {
        public MovePlayerCommand(IGameEngine engine)
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
