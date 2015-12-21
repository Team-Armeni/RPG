namespace RPGArmeni.Engine.Commands
{
    using Interfaces;

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
        
	    public virtual void Execute(IKeyInfo directionKey)
	    {
	        
	    }

        public abstract void Execute();
    }
}
