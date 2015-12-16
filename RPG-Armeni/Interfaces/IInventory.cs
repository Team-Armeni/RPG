namespace RPGArmeni.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IInventory
    {
        ISlot MainHandSlot { get; }

        ISlot OffHandSlot { get; }

        ISlot ChestSlot { get; }

        ISlot HeadSlot { get; }

        ISlot FeetSlot { get; }

        ISlot GlovesSlot { get; }

        IContainer BackPack { get; }

        IEnumerable<ISlot> SlotList { get; }

        IDictionary<int, ISlot> WeaponSlots { get; }

        IDictionary<int, ISlot> ArmorSlots { get; }

        IRenderer ConsoleRenderer { get; set; }

        void ClearInventory();

        void EquipItem(IGameItem itemToBeEquipped);

        void RemoveItem(IGameItem itemToBeRemoved);
    }
}
