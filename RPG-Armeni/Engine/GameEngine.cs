namespace RPGArmeni.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Attributes;
    using RPGArmeni.Models.Characters;
    using Exceptions;
    using Interfaces;
    using RPGArmeni.UI;
    using RPGArmeni.Models.Items;
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

        public bool IsRunning { get; private set; }

        public void Run()
        {
            this.IsRunning = true;
            this.player = PlayerFactory.Instance.CreatePlayer();

            //this.PopulateEnemies();

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
                    this.MovePlayer(command);
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

        private void MovePlayer(string command)
        {
            this.player.Move(command);

            ICharacter enemy =
                this.characters.Cast<ICharacter>()
                .FirstOrDefault(
                    e => e.Position.X == this.player.Position.X 
                        && e.Position.Y == this.player.Position.Y 
                        && e.Health > 0);

            if (enemy != null)
            {
                this.EnterBattle(enemy);
                return;
            }

            IGameItem healthPotion =
                this.items.Cast<IGameItem>()
                .FirstOrDefault(
                    e => e.Position.X == this.player.Position.X 
                        && e.Position.Y == this.player.Position.Y 
                        && e.ItemState == ItemState.Available);

            if (healthPotion != null)
            {
                //this.player.AddItemToInventory(beer);
                healthPotion.ItemState = ItemState.Collected;
                ConsoleRenderer.WriteLine("Health potion collected!");
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

        //private void PopulateItems()
        //{
        //    for (int i = 0; i < numberOfItems; i++)
        //    {
        //        IGameItem beer = this.CreateItem();
        //        this.items.Add(beer);
        //    }
        //}

        private IGameItem CreateItem()
        {
            int currentX = RandomGenerator.GenerateNumber(1, MapWidth);
            int currentY = RandomGenerator.GenerateNumber(1, MapHeight);

            bool containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            bool containsBeer = this.items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            while (containsEnemy || containsBeer)
            {
                currentX = RandomGenerator.GenerateNumber(1, MapWidth);
                currentY = RandomGenerator.GenerateNumber(1, MapHeight);

                containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

                containsBeer = this.items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }

            int beerType = RandomGenerator.GenerateNumber(0, 3);

            HealthPotionSize potionSize;

            switch (beerType)
            {
                case 0:
                    potionSize = HealthPotionSize.Minor;
                    break;
                case 1:
                    potionSize = HealthPotionSize.Normal;
                    break;
                case 2:
                    potionSize = HealthPotionSize.Major;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("potionType", "Invalid potion type.");
            }

            return new HealthPotion(new Position(currentX, currentY), potionSize);
        }

        private void PopulateEnemies()
        {
            for (int i = 0; i < NumberOfEnemies; i++)
            {
                GameObject enemy = this.CreateEnemy();
                this.characters.Add(enemy);
            }
        }

        private GameObject CreateEnemy()
        {
            int currentX = RandomGenerator.GenerateNumber(1, MapWidth);
            int currentY = RandomGenerator.GenerateNumber(1, MapHeight);

            bool containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            while (containsEnemy)
            {
                currentX = RandomGenerator.GenerateNumber(1, MapWidth);
                currentY = RandomGenerator.GenerateNumber(1, MapHeight);

                containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }
            var enemyTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.CustomAttributes
                    .Any(a => a.AttributeType == typeof(EnemyAttribute)))
                    .ToArray();

            var type = enemyTypes[RandomGenerator.GenerateNumber(0, enemyTypes.Length)];

            GameObject character = Activator
                .CreateInstance(type, new Position(currentX, currentY)) as GameObject;

            return character;
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
    }
}
