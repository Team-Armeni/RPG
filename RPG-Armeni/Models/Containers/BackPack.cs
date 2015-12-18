namespace RPGArmeni.Models.Containers
{
    using RPGArmeni.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using RPGArmeni.UI;
    using System;

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
        }

        public void LootItem(IGameItem itemToBeLooted)
        {
            ISlot emptySlot = this.SlotList.FirstOrDefault(x => x.IsEmpty);

            if (emptySlot == null)
            {
                throw new BackPackFullException("Your backpack is full.");
            }

            emptySlot.GameItem = itemToBeLooted;
            emptySlot.IsEmpty = false;
        }

        public void RemoveItem(ISlot slot)
        {
            slot.GameItem = null;
            slot.IsEmpty = true;
        }

        public void ListItems()
        {
            var fullSlots = this.SlotList.Where(x => !x.IsEmpty);
            foreach (ISlot currentSlot in fullSlots)
            {
                ConsoleRenderer.WriteLine(currentSlot.GameItem.ToString());
            }

            Console.ForegroundColor = ConsoleColor.Green;
            ConsoleRenderer.WriteLine("Empty slots: {0}",
                this.SlotList.Count() - fullSlots.Count());
            Console.ResetColor();
        }
    }
}
