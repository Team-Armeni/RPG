namespace RPGArmeni.Interfaces
{
    using System;

    public interface IGameCommand
    {
        IGameEngine Engine { get; set; }

        void Execute(string[] args);
    }
}
