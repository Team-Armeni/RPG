namespace RPGArmeni.Engine
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;
    using RPGArmeni.UI;
    using RPGArmeni.Engine.Factories;
    using RPGArmeni.Engine.Commands;
    using RPGArmeni.Models;

    public class GameEngine : IGameEngine
    {
        public const int MapHeight = 20;
        public const int MapWidth = 50;

        private int numberOfEnemies;
        private int numberOfItems;

        private readonly IList<IGameObject> characters;
        private readonly IList<IGameItem> items;
        private IPlayer player;
        private IMap map;

        public GameEngine()
        {
            this.characters = new List<IGameObject>();
            this.items = new List<IGameItem>();
            this.Map = new Map(MapHeight, MapWidth);
            this.InitializeMap();
            this.NumberOfEnemies = 20;
            this.NumberOfItems = 20;
        }

        public IEnumerable<IGameObject> Characters
        {
            get
            {
                return this.characters;
            }
        }

        public IEnumerable<IGameItem> Items
        {
            get
            {
                return this.items;
            }
        }

        public IPlayer Player
        {
            get { return this.player; }
            private set
            {
                this.player = value;
            }
        }

        public IMap Map
        {
            get { return this.map; }
            private set
            {
                this.map = value;
            }
        }

        public int NumberOfItems
        {
            get { return this.numberOfItems; }
            private set
            {
                this.numberOfItems = value;
            }
        }

        public int NumberOfEnemies
        {
            get { return this.numberOfEnemies; }
            private set
            {
                this.numberOfEnemies = value;
            }
        }

        public bool IsRunning { get; set; }

        public void Run()
        {
            this.IsRunning = true;
            this.player = PlayerFactory.Instance.CreatePlayer();
            this.player.Engine = this;

            IGameCommand spawnEnemies = new SpawnEnemiesCommand(this);
            spawnEnemies.Execute();

            IGameCommand spawnItems = new SpawnItemsCommand(this);
            spawnItems.Execute();

            while (this.IsRunning)
            {
                string command = ConsoleInputReader.ReadLine();

                try
                {
                    this.ExecuteCommand(command);
                }
                catch (ObjectOutOfBoundsException ex)
                {
                    ConsoleRenderer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    ConsoleRenderer.WriteLine(ex.Message);
                }

                if (this.characters.Count == 0)
                {
                    this.IsRunning = false;
                    ConsoleRenderer.WriteLine("All your enemies are dead. Congratulations! You are the only one left on earth.");
                }
            }
        }

        protected virtual void ExecuteCommand(string command)
        {
            IGameCommand currentCommand;
            string[] commandArgs = command.Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (command)
            {
                case "help":
                    currentCommand = new HelpCommand(this);
                    currentCommand.Execute(commandArgs);
                    break;
                case "map":
                    currentCommand = new PrintMapCommand(this);
                    currentCommand.Execute(commandArgs);
                    break;
                case "left":
                case "right":
                case "up":
                case "down":
                    currentCommand = new MovePlayerCommand(this);
                    currentCommand.Execute(commandArgs);
                    break;
                case "status":
                    currentCommand = new PlayerStatusCommand(this);
                    currentCommand.Execute(commandArgs);
                    break;
                case "clear":
                    ConsoleRenderer.Clear();
                    break;
                case "exit":
                    this.IsRunning = false;
                    ConsoleRenderer.WriteLine("Good Bye! Do come again to play this great game!");
                    break;
                default:
                    {
                        throw new ArgumentException("Unknown command");
                    }
            }
        }

        private void EnterBattle(ICharacter enemy)
        {
            while (true) //Fighting until one of them is dead. No one is running from combat.
            {
                this.player.Attack(enemy);

                if (enemy.Health <= 0)
                {
                    ConsoleRenderer.WriteLine("Enemy killed!");
                    this.characters.Remove(enemy as GameObject);
                    return;
                }

                enemy.Attack(this.player);

                if (this.player.Health <= 0)
                {
                    this.IsRunning = false;
                    ConsoleRenderer.WriteLine("You died!");
                    return;
                }
                
            }
        }

        private void InitializeMap()
        {
            for (int i = 0; i < this.Map.Height; i++)
            {
                for (int j = 0; j < this.Map.Width; j++)
                {
                    this.Map.Matrix[i, j] = '.';
                }
            }
        }

        public void AddItem(IGameItem itemToBeAdded)
        {
            this.items.Add(itemToBeAdded);
        }

        public void AddEnemy(ICharacter enemyToBeAdded)
        {
            this.characters.Add(enemyToBeAdded);
        }

        public void RemoveItem(IGameItem itemToBeRemoved)
        {
            this.items.Remove(itemToBeRemoved);
        }

        public void RemoveEnemy(ICharacter enemyToBeRemoved)
        {
            this.characters.Remove(enemyToBeRemoved);
        }
    }
}
