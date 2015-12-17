namespace RPGArmeni.Interfaces
{
	public interface IGameObject
    {
        IPosition Position { get; set; }

        char ObjectSymbol { get; set; }
    }
}
