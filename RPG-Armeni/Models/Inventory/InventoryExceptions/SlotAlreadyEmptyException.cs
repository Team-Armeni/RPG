using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.InventoryExceptions
{
    public class SlotAlreadyEmptyException : Exception
    {
        public SlotAlreadyEmptyException(string message)
            : base(message)
        {
        }
    }
}
