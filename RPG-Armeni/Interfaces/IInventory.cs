namespace RPGArmeni.Interfaces
{
    using System;

    public interface IInventory
    {
        IItemSlot MainHandSlot { get; }

        IItemSlot OffHandSlot { get; }

        IItemSlot ChestSlot { get; }

        IItemSlot HeadSlot { get; }

        IItemSlot FeetSlot { get; }

        IItemSlot GlovesSlot { get; }

        IContainer BackPack { get; }
    }
}
