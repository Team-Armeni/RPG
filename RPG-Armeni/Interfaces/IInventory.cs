using Game.GameObjects.Inventory;
using Game.GameObjects.Inventory.ItemSlots.ArmorItemSlots;
using Game.GameObjects.Inventory.ItemSlots.WeaponItemSlots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IInventory
    {
        MainHandSlot MainHandSlot { get; }

        OffHandSlot OffHandSlot { get; }

        ChestArmorSlot ChestSlot { get; }

        HeadArmorSlot HeadSlot { get; }

        FeetArmorSlot FeetSlot { get;}

        HandArmorSlot HandSlot { get; }

        Backpack BackPack { get; }
    }
}
