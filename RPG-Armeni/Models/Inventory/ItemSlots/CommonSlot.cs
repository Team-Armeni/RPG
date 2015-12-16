using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots
{
    public class CommonSlot : ItemSlot
    {
        public CommonSlot()
            : base()
        {
            this.SlotType = ItemSlotType.Common;
            this.SlotNumber = InventoryValues.InventoryCommonSlotNumber;
        }

        public override void PutItem(Interfaces.IItem itemToBeEquipped)
        {
            throw new NotImplementedException();
        }

        public override void RemoveItem(Interfaces.IItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }
    }
}
