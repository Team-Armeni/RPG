namespace RPGArmeni.Interfaces
{
	using Models.Items;

    public interface IGameItem : IGameObject
    {
        ItemState ItemState { get; set; }
    }
}
