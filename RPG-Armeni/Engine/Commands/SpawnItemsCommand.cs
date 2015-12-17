using RPGArmeni.Engine.Factories;
using RPGArmeni.Interfaces;

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
                IGameItem newItem = ItemFactory.Instance.CreateItem();
                this.Engine.AddItem(newItem);
            }
        }
    }
}
