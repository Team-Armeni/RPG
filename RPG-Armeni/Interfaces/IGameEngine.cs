namespace RPGArmeni.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IGameEngine
    {
        IPlayer Player { get; }

        IMap Map { get; }

        IEnumerable<IGameObject> Characters { get; }

        IEnumerable<IGameItem> Items { get; }

        void Run();
    }
}
