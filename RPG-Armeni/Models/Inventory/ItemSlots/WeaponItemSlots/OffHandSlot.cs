using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots.WeaponItemSlots
{
    public class OffHandSlot : WeaponSlot
    {
        public OffHandSlot()
            : base()
        {
            this.SlotNumber = InventoryValues.InventoryOffHandSlotNumber;
        }
    }
}
