namespace RPGArmeni.Engine
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;
    using UI;
    using Factories;
    using Commands;
    using Models;

    public class GameEngine : IGameEngine
    {
        public const int MapHeight = 20;
        public const int MapWidth = 50;
        private const int DefaultNumberOfEnemies = 20;
        private const int DefaultNumberOfItems = 20;

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
            this.NumberOfEnemies = DefaultNumberOfEnemies;
            this.NumberOfItems = DefaultNumberOfItems;
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

        public virtual void Run()
        {
            this.IsRunning = true;
            this.player = PlayerFactory.Instance.CreatePlayer();
            this.player.Engine = this;

            IGameCommand spawnEnemies = new SpawnEnemiesCommand(this);
            spawnEnemies.Execute();

            IGameCommand spawnItems = new SpawnItemsCommand(this);
            spawnItems.Execute();
            ConsoleRenderer.WriteLine("Press F1 to get playing instructions.");

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
            switch (commandKey.Key)
            {
                case ConsoleKey.F1:
                    currentCommand = new HelpCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.M:
                    ConsoleRenderer.Clear();
                    currentCommand = new PrintMapCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    ConsoleRenderer.Clear();
                    RenderSuccessMoveMessage(commandKey);
                    currentCommand = new MovePlayerCommand(this);
                    currentCommand.Execute(commandKey);
                    currentCommand = new PrintMapCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.S:
                    currentCommand = new PlayerStatusCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.C:
                    ConsoleRenderer.Clear();
                    break;
                case ConsoleKey.H: 
                    currentCommand = new HealCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.I:
                    currentCommand = new BoostHealthCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.R:
                    this.Player.Inventory.BackPack.RemoveLastItem();
                    break;
                case ConsoleKey.B: 
                    currentCommand = new BackPackCommand(this);
                    currentCommand.Execute();
                    break;
                case ConsoleKey.Escape:
                    this.ExitApplication();
                    break;
                default:
                    {
                        throw new ArgumentException("Unknown command");
                    }
            }
        }

        private void ExitApplication()
        {
            this.IsRunning = false;
            ConsoleRenderer.WriteLine("Good Bye! Do come again to play this great game!");
        }

        private static void RenderSuccessMoveMessage(IKeyInfo commandKey)
        {
            ConsoleRenderer.WriteLine(
                                    "Moved " +
                                    commandKey.
                                    Key.ToString().ToLower().
                                    Substring(0, commandKey.Key.ToString().Length - 5));
        }

        private void InitializeMap()
        {
            for (int i = 0; i < this.Map.Height; i++)
            {
                for (int j = 0; j < this.Map.Width; j++)
                {
                    if (i > this.Map.Height - 5)
                    {
                        this.Map.Matrix[i, j] = '~'; 
                    }
                    else
                    {
                        this.Map.Matrix[i, j] = '.'; 
                    }
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