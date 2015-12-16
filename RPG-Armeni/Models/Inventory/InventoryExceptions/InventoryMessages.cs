using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.InventoryExceptions
{
    public static class InventoryMessages
    {
        public const string WrongSlotMessage = "The item cannot be equipped in that slot!";
        public const string BackpackFullMessage = "Backpack is full!";
        public const string SlotAlreadyEmptyMessage = "The slot is empty. There is no item to remove!";
    }
}
