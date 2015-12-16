using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots.ArmorItemSlots
{
    public class ChestArmorSlot : ArmorSlot
    {
        public ChestArmorSlot()
            : base()
        {
            this.SlotNumber = InventoryValues.InventoryChesArmorSlotNumber;
        }
    }
}
