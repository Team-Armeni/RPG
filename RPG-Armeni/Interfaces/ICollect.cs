namespace RPGArmeni.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ICollect
    {
        IInventory Inventory { get; }

        IContainer BackPack { get; }
    }
}
