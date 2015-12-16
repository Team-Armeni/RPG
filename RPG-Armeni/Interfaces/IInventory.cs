namespace RPGArmeni.Interfaces
{
    using System;

    public interface IInventory
    {
        ICommonSlot MainHandSlot { get; }

        ICommonSlot OffHandSlot { get; }

        ICommonSlot ChestSlot { get; }

        ICommonSlot HeadSlot { get; }

        ICommonSlot FeetSlot { get; }

        ICommonSlot HandSlot { get; }

        ICommonSlot BackPack { get; }
    }
}
