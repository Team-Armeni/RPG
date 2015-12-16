namespace RPGArmeni.Interfaces
{
    using System;

    public interface ISlot
    {
        IGameItem GameItem { get; set; }

        bool IsEmpty { get; set; }

        void ClearSlot();
    }
}
