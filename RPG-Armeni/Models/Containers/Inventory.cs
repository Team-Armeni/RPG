namespace RPGArmeni.Models.Containers
{
    using RPGArmeni.Exceptions;
    using RPGArmeni.Interfaces;
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
        private Dictionary<int, ISlot> weaponSlots;
        private Dictionary<int, ISlot> armorSlots;

        public Inventory()
        {
            this.MainHandSlot = new Slot();
            this.OffHandSlot = new Slot();
            this.ChestSlot = new Slot();
            this.HeadSlot = new Slot();
            this.FeetSlot = new Slot();
            this.GlovesSlot = new Slot();
            this.slotList = new List<ISlot>();
            this.slotList.Add(this.MainHandSlot);
            this.weaponSlots = new Dictionary<int, ISlot>();
            this.armorSlots = new Dictionary<int, ISlot>();
            this.BackPack = new BackPack();

            this.weaponSlots.Add(1, this.MainHandSlot);
            this.weaponSlots.Add(2, this.OffHandSlot);

            this.armorSlots.Add(1, this.ChestSlot);
            this.armorSlots.Add(2, this.HeadSlot);
            this.armorSlots.Add(3, this.FeetSlot);
            this.armorSlots.Add(4, this.GlovesSlot);
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

        public IDictionary<int, ISlot> WeaponSlots
        {
            get { return this.weaponSlots; }
        }

        public IDictionary<int, ISlot> ArmorSlots
        {
            get { return this.armorSlots; }
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
                    throw new NoSlotAvailableException("There is no available slot.");
                }
                else
                {
                    currentSlot.GameItem = itemToBeEquipped;
                }
            }
        }

        public void RemoveItem(IGameItem itemToBeRemoved)
        {
            ISlot currentSlot = this.SlotList.FirstOrDefault(x => x.GameItem == itemToBeRemoved);
            currentSlot.GameItem = null;
            currentSlot.IsEmpty = true;
        }
    }
}
