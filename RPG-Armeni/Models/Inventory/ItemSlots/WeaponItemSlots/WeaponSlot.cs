using Game.GameObjects.Inventory.InventoryExceptions;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects.Inventory.ItemSlots.WeaponItemSlots
{
    public abstract class WeaponSlot : ItemSlot
    {
        protected WeaponSlot()
            : base()
        {
            this.SlotType = ItemSlotType.Weapon;
        }

        public override void PutItem(IItem itemToBeEquipped)
        {
            if (!(itemToBeEquipped is IWeapon))
            {
                throw new WrongSlotException(InventoryMessages.WrongSlotMessage);
            }

            this.IsEmpty = false;

            throw new NotImplementedException();
        }

        public override void RemoveItem(IItem itemToBeRemoved)
        {
            this.IsEmpty = true;
            throw new NotImplementedException();
        }
    }
}
