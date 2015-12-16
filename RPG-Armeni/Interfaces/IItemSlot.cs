namespace RPGArmeni.Interfaces
{
    using System;

    public interface IItemSlot
    {
        IGameItem Item { get; set; }

        bool IsEmpty { get; }

        int  SlotNumber { get; }

        ItemSlotType SlotType { get; }
    }
}
