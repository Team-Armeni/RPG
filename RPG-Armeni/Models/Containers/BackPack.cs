namespace RPGArmeni.Models.Containers
{
    using RPGArmeni.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Exceptions;
    using RPGArmeni.UI;

    public class BackPack : IContainer
    {
        private const int BackPackSlotNumber = 10;
        private List<ISlot> slotList;

        public BackPack()
        {
            this.slotList = new List<ISlot>();
            for (int i = 0; i < BackPackSlotNumber; i++)
            {
                this.slotList.Add(new Slot());
            }
        }

        public IEnumerable<ISlot> SlotList
        {
            get { return this.slotList; }
            private set
            {
                this.slotList = new List<ISlot>();
            }
        }

        public void LootItem(IGameItem itemToBeLooted)
        {
            ISlot emptySlot = this.SlotList.FirstOrDefault(x => x.IsEmpty);

            if (emptySlot == null)
            {
                throw new BackPackFullException("Your backpack is full.");
            }
        }

        public void RemoveItem(IGameItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }

        public void ListItems()
        {
            foreach (IGameItem currentItem in this.SlotList)
            {
                ConsoleRenderer.WriteLine(currentItem.ToString());
            }
        }
    }
}
