namespace RPGArmeni.Interfaces
{
	public interface ICollect
    {
        IInventory Inventory { get; }

        IContainer BackPack { get; }
    }
}
