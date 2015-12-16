using Game.GameObjects.Inventory.InventoryExceptions;
using Game.GameObjects.Inventory.ItemSlots;
using Game.GameObjects.Items;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.Containers
{
    public abstract class Container : IContainer
    {
        private int numberOfSlots;
        private List<CommonSlot> slots;

        protected Container()
        {
            this.slots = new List<CommonSlot>();
        }

        public int NumberOfSlots
        {
            get
            {
                return this.numberOfSlots;
            }
            protected set
            {
                this.numberOfSlots = value;
            }
        }

        public IEnumerable<CommonSlot> Slots
        {
            get
            {
                return this.slots;
            }
        }

        public void AddItem(IItem itemToBeAdded)
        {
            if (this.IsFull())
            {
                throw new BackpackFullException(InventoryMessages.BackpackFullMessage);
            }

            CommonSlot currentSlot = this.slots.First(x => x.IsEmpty);
            currentSlot.PutItem(itemToBeAdded);
        }

        public void RemoveItem(IItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            bool isFull = this.slots.Any(x => x.IsEmpty == true);
            return isFull;
        }

        protected void AddSlot()
        {
            this.slots.Add(new CommonSlot());
        }

        public void ListItems()
        {
            foreach (IItem currentItem in this.Slots)
            {
                Console.WriteLine(currentItem.ToString());
            }
        }
    }
}
