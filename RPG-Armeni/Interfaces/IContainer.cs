namespace RPGArmeni.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IContainer
    {
        int NumberOfSlots { get; }

        IEnumerable<ICommonSlot> Slots { get; }

        void AddItem(IGameItem itemToBeAdded);

        void RemoveItem(IGameItem itemToBeRemoved);

        void ListItems();
    }
}
