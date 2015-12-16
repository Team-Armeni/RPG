using Game.GameObjects.Inventory.ItemSlots.ArmorItemSlots;
using Game.GameObjects.Inventory.ItemSlots.WeaponItemSlots;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory
{
    public class Inventory : IInventory
    {
        private MainHandSlot mainHandSlot;
        private OffHandSlot offHandSlot;
        private ChestArmorSlot chestSlot;
        private HeadArmorSlot headSlot;
        private FeetArmorSlot feetSlot;
        private HandArmorSlot handSlot;

        private Backpack backPack;

        public Inventory()
        {
            this.InitializeInventory();
        }

        public MainHandSlot MainHandSlot
        {
            get
            {
                return this.mainHandSlot;
            }
            private set
            {
                this.mainHandSlot = value;
            }
        }

        public OffHandSlot OffHandSlot
        {
            get
            {
                return this.offHandSlot;
            }
            private set
            {
                this.offHandSlot = value;
            }
        }

        public ChestArmorSlot ChestSlot
        {
            get
            {
                return this.chestSlot;
            }
            private set
            {
                this.chestSlot = value;
            }
        }

        public HeadArmorSlot HeadSlot
        {
            get
            {
                return this.headSlot;
            }
            private set
            {
                this.headSlot = value;
            }
        }

        public FeetArmorSlot FeetSlot
        {
            get
            {
                return this.feetSlot;
            }
            private set
            {
                this.feetSlot = value;
            }
        }

        public HandArmorSlot HandSlot
        {
            get
            {
                return this.handSlot;
            }
            private set
            {
                this.handSlot = value;
            }
        }

        public Backpack BackPack
        {
            get
            {
                return this.backPack;
            }
            private set
            {
                this.backPack = value;
            }
        }

        private void InitializeInventory()
        {
            this.BackPack = new Backpack();
            this.MainHandSlot = new MainHandSlot();
            this.OffHandSlot = new OffHandSlot();
            this.ChestSlot = new ChestArmorSlot();
            this.HeadSlot = new HeadArmorSlot();
            this.FeetSlot = new FeetArmorSlot();
            this.HandSlot = new HandArmorSlot();
        }
    }
}
