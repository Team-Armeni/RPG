using Game.GameObjects.Inventory.ItemSlots;
using Game.GameObjects.Items;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory
{
    public abstract class ItemSlot : IItemSlot
    {
        private IItem item;
        private bool isEmpty;
        private int slotNumber;
        private ItemSlotType slotType;

        protected ItemSlot()
        {
            this.IsEmpty = true;
        }

        public IItem Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.isEmpty;
            }
            protected set
            {
                this.isEmpty = value;
            }
        }

        public int SlotNumber
        {
            get
            {
                return this.slotNumber;
            }
            protected set
            {
                this.slotNumber = value;
            }
        }

        public ItemSlotType SlotType
        {
            get
            {
                return this.slotType;
            }
            protected set
            {
                this.slotType = value;
            }
        }

        public abstract void PutItem(IItem itemToBeEquipped);

        public abstract void RemoveItem(IItem itemToBeRemoved);
    }
}
