using RPGArmeni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Engine.Commands
{
    public class HealCommand : GameCommand
    {
        public HealCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            this.Engine.Player.SelfHeal();
        }
    }
}
