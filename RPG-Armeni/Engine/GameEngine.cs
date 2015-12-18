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
            Console.WriteLine("Press F1 to get playing instructions.");

            while (this.IsRunning)
            {
                IKeyInfo commandKey = new KeyInfo();

                try
                {
                    this.ExecuteCommand(commandKey);
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

        protected virtual void ExecuteCommand(IKeyInfo commandKey)
        {
            IGameCommand currentCommand;
            //string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (commandKey.Key)
            {
                case ConsoleKey.F1://"help":
                    currentCommand = new HelpCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.M://"map":
                    ConsoleRenderer.Clear();
                    currentCommand = new PrintMapCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.LeftArrow://"left":
                case ConsoleKey.RightArrow://"right":
                case ConsoleKey.UpArrow://"up":
                case ConsoleKey.DownArrow://"down":
                    ConsoleRenderer.Clear();
                    currentCommand = new MovePlayerCommand(this);
                    currentCommand.Execute(commandKey);
                    ConsoleRenderer.WriteLine(
                        "Moved " + 
                        commandKey.
                        Key.ToString().ToLower().
                        Substring(0, commandKey.Key.ToString().Length - 5));
                    currentCommand = new PrintMapCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.S://"status":
                    currentCommand = new PlayerStatusCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.C://"clear":
                    ConsoleRenderer.Clear();
                    break;
                case ConsoleKey.B: //"backpack":
                    currentCommand = new BackPackCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.Escape: //"exit":
                    this.IsRunning = false;
                    ConsoleRenderer.WriteLine("Good Bye! Do come again to play this great game!");
                    break;
                default:
                    {
                        throw new ArgumentException("Unknown command");
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