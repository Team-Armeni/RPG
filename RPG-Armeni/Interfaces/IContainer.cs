namespace RPGArmeni.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IContainer
    {
        IEnumerable<ISlot> SlotList { get; }

        void LootItem(IGameItem itemToBeLooted);

        void RemoveItem(IGameItem itemToBeRemoved);

        void ListItems();
    }
}
