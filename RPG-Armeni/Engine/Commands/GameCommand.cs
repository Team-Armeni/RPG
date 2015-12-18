using System;

namespace RPGArmeni.Engine.Commands
{
    using RPGArmeni.Interfaces;

	public abstract class GameCommand : IGameCommand
    {
        private IGameEngine engine;

        public GameCommand(IGameEngine engine)
        {
            this.Engine = engine;
        }

        public IGameEngine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }

        public abstract void Execute(string[] args);

	    public virtual void Execute(ConsoleKeyInfo directionKey)
	    {
	        
	    }

        public abstract void Execute();
    }
}
