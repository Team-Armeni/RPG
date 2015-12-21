using System;

namespace RPGArmeni.Interfaces
{
	public interface IGameCommand
    {
        IGameEngine Engine { get; set; }

        void Execute(IKeyInfo directionKey);

        void Execute();
    }
}
