using RPGArmeni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Engine.Commands
{
    public class SpawnItemsCommand : GameCommand
    {
        public SpawnItemsCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] args)
        {
        }

        public override void Execute()
        {
            for (int i = 0; i < this.Engine.NumberOfItems; i++)
            {
                IGameItem newItem = this.CreateItem();
                this.Engine.AddItem(newItem);
            }
        }
    }
}
