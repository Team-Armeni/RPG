namespace RPGArmeni.Interfaces
{
	public interface IGameCommand
    {
        IGameEngine Engine { get; set; }

        void Execute(string[] args);

        void Execute();
    }
}
