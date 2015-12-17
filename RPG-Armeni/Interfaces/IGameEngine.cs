namespace RPGArmeni.Interfaces
{
	using System.Collections.Generic;

    public interface IGameEngine
    {
        int NumberOfItems { get; }

        int NumberOfEnemies { get; }

        IPlayer Player { get; }

        IMap Map { get; }

        bool IsRunning { get; set; }

        IEnumerable<IGameObject> Characters { get; }

        IEnumerable<IGameItem> Items { get; }

        void AddItem(IGameItem itemToBeAdded);

        void AddEnemy(ICharacter enemyToBeAdded);

        void RemoveItem(IGameItem itemToBeRemoved);

        void RemoveEnemy(ICharacter enemyToBeRemoved);

        void Run();
    }
}
