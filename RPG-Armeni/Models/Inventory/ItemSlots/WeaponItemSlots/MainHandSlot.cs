using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots.WeaponItemSlots
{
    public class MainHandSlot : WeaponSlot
    {
        public MainHandSlot()
            : base()
        {
            this.SlotNumber = InventoryValues.InventoryMainHandSlotNumber;
        }
    }
}
