namespace RPGArmeni.Models.Containers
{
    using RPGArmeni.Interfaces;
    using System;

    public class Inventory : IInventory
    {
        private IItemSlot mainHandSlot;
        private IItemSlot offHandSlot;
        private IItemSlot chestSlot;
        private IItemSlot headSlot;
        private IItemSlot feetSlot;
        private IItemSlot glovesSlot;
        private IContainer backPack;

        public Inventory()
        {
            
        }

        public IItemSlot MainHandSlot
        {
            get { return this.mainHandSlot; }
            private set
            {
                this.mainHandSlot = value;
            }
        }

        public IItemSlot OffHandSlot
        {
            get { return this.offHandSlot; }
            private set
            {
                this.offHandSlot = value;
            }
        }

        public IItemSlot ChestSlot
        {
            get { return this.chestSlot; }
            private set
            {
                this.chestSlot = value;
            }
        }

        public IItemSlot HeadSlot
        {
            get { return this.headSlot; }
            private set
            {
                this.headSlot = value;
            }
        }

        public IItemSlot FeetSlot
        {
            get { return this.feetSlot; }
            private set
            {
                this.feetSlot = value;
            }
        }

        public IItemSlot GlovesSlot
        {
            get { return this.glovesSlot; }
            private set
            {
                this.glovesSlot = value;
            }
        }

        public IContainer BackPack
        {
            get { throw new NotImplementedException(); }
        }
    }
}
