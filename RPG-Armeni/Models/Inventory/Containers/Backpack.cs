using Game.GameObjects.Inventory.Containers;
using Game.GameObjects.Inventory.InventoryExceptions;
using Game.GameObjects.Inventory.ItemSlots;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory
{
    public class Backpack : Container
    {
        public Backpack()
            : base()
        {
            this.NumberOfSlots = InventoryValues.BackpackBaseNumberOfSlots;
            this.InitializeSlots();
        }

        private void InitializeSlots()
        {
            for (int i = 0; i < this.NumberOfSlots; i++)
            {
                this.AddSlot();
            }
        }
    }
}
