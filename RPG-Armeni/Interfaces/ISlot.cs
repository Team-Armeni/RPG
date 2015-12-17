namespace RPGArmeni.Interfaces
{
	public interface ISlot
    {
        IGameItem GameItem { get; set; }

        bool IsEmpty { get; set; }

        void ClearSlot();
    }
}
