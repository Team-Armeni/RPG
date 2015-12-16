namespace RPGArmeni.Models.Containers
{
    using RPGArmeni.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IInventory
    {
        private ISlot mainHandSlot;
        private ISlot offHandSlot;
        private ISlot chestSlot;
        private ISlot headSlot;
        private ISlot feetSlot;
        private ISlot glovesSlot;
        private IContainer backPack;
        private List<ISlot> slotList;

        public Inventory()
        {
            this.MainHandSlot = new Slot();
            this.OffHandSlot = new Slot();
            this.ChestSlot = new Slot();
            this.HeadSlot = new Slot();
            this.HeadSlot = new Slot();
            this.FeetSlot = new Slot();
            this.GlovesSlot = new Slot();
            this.slotList = new List<ISlot>();
            this.slotList.Add(this.MainHandSlot);
        }

        public ISlot MainHandSlot
        {
            get { return this.mainHandSlot; }
            private set
            {
                this.mainHandSlot = value;
            }
        }

        public ISlot OffHandSlot
        {
            get { return this.offHandSlot; }
            private set
            {
                this.offHandSlot = value;
            }
        }

        public ISlot ChestSlot
        {
            get { return this.chestSlot; }
            private set
            {
                this.chestSlot = value;
            }
        }

        public ISlot HeadSlot
        {
            get { return this.headSlot; }
            private set
            {
                this.headSlot = value;
            }
        }

        public ISlot FeetSlot
        {
            get { return this.feetSlot; }
            private set
            {
                this.feetSlot = value;
            }
        }

        public ISlot GlovesSlot
        {
            get { return this.glovesSlot; }
            private set
            {
                this.glovesSlot = value;
            }
        }

        public IContainer BackPack
        {
            get { return this.backPack; }
            private set
            {
                this.backPack = value;
            }
        }

        public IEnumerable<ISlot> SlotList
        {
            get { return this.slotList; }
        }

        public void ClearInventory()
        {
            foreach (ISlot currentSlot in this.SlotList)
            {
                currentSlot.ClearSlot();
            }
        }

        public void EquipItem(IGameItem itemToBeEquipped)
        {
            if (itemToBeEquipped is IWeapon)
            {
                ISlot currentSlot = this.SlotList.FirstOrDefault(x => x.IsEmpty && x.GameItem is IWeapon);

                if (currentSlot == null)
                {

                }
                else
                {
                    currentSlot.GameItem = itemToBeEquipped;
                }
            }
        }

        public void RemoveItem(IGameItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }
    }
}
