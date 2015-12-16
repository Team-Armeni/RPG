using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.InventoryExceptions
{
    public class WrongSlotException : Exception
    {
        public WrongSlotException(string message)
            : base(message)
        {
        }
    }
}
