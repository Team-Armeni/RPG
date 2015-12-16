using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameObjects.Inventory.InventoryExceptions;

namespace Game.GameObjects.Inventory
{
    public class InventoryManager
    {
        private Inventory inventory;

        public InventoryManager()
        {
            this.inventory = new Inventory();
        }

        public void LootItem(IItem itemToBeLooted)
        {
            try
            {
                this.inventory.BackPack.AddItem(itemToBeLooted);
            }
            catch (BackpackFullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RemoveFromInventory(IItem itemToBeRemoved)
        {
            throw new NotImplementedException();
        }

        public void ListAllWeaponsInBackpack()
        {
            throw new NotImplementedException();
        }

        public void ListAllArmorItemsInBackPack()
        {
            throw new NotImplementedException();
        }

        public void ListAllConsumables()
        {
            throw new NotImplementedException();
        }

        public void ListAllItemsInBackpack()
        {
            throw new NotImplementedException();
        }

        public void ListEquipment()
        {
            throw new NotImplementedException();
        }

        public bool ContainsItem(IItem itemToBeFound)
        {
            throw new NotImplementedException();
        }

        public void ClearBackpack()
        {
            throw new NotImplementedException();
        }
    }
}
