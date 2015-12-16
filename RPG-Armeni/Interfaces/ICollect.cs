namespace RPGArmeni.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ICollect
    {
        IEnumerable<IGameItem> Inventory { get; }

        void AddItemToInventory(IGameItem item);
    }
}
