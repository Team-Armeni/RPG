using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots.ArmorItemSlots
{
    public class HandArmorSlot : ArmorSlot
    {
        public HandArmorSlot()
            : base()
        {
            this.SlotNumber = InventoryValues.InventoryHandArmorSlotNumber;
        }
    }
}
