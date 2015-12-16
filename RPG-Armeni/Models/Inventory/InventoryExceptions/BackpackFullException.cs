using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.InventoryExceptions
{
    public class BackpackFullException : Exception
    {
        public BackpackFullException(string message)
            : base(message)
        {
        }
    }
}
