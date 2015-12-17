namespace RPGArmeni.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IGameEngine
    {
        int NumberOfItems { get; }

        int NumberOfEnemies { get; }

        IPlayer Player { get; }

        IMap Map { get; }

        IEnumerable<IGameObject> Characters { get; }

        IEnumerable<IGameItem> Items { get; }

        void AddItem(IGameItem itemToBeAdded);

        void AddEnemy(ICharacter enemyToBeAdded);

        void Run();
    }
}
