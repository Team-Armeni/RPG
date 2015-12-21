namespace RPGArmeni.Models.Characters
{
    using System;
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Items;
    using Containers;
    using System.Text;
    using UI;

    public class Player : Character, IPlayer
    {
        private const int PlayerStartingX = 0;
        private const int PlayerStartingY = 0;
        private const char DefaultPlayerSymbol = 'P';
        private const char DefaultEmptyMapSybmol = '.';
            
        private int startHealth;
        private string name;
        private int defensiveBonus;
        private IInventory inventory;
        private IRace race;
 
        public Player(IPosition position, char objectSymbol, string name, IRace race)
            : base(position, objectSymbol, race.Damage, race.Health)
        {
            this.Name = name;
            this.Race = race;
            this.Inventory = new Inventory();
            this.startHealth = race.Health;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidNameException("Name cannot be null, empty or whitespace.");
                }

                this.name = value;
            }
        }

        public int DefensiveBonus
        {
            get { return this.defensiveBonus; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player defensive bonus.", "Defensive bonus value cannot be negative.");
                }
                this.defensiveBonus = value;
            }
        }
        
        public IRace Race
        {
            get { return this.race; }
            private set
            {
                this.race = value;
            }
        }

        public IInventory Inventory
        {
            get
            {
                return this.inventory;
            }
            private set
            {
                this.inventory = value;
            }
        }

        public IGameEngine Engine { get; set; }
        
        public void Move(IKeyInfo directionKey)
        {
            switch (directionKey.Key)
            {
                case ConsoleKey.UpArrow:
                    this.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    this.MoveDown();
                    break;
                case ConsoleKey.RightArrow:
                    this.MoveRight();
                    break;
                case ConsoleKey.LeftArrow:
                    this.MoveLeft();
                    break;
                default:
                {
                    throw new ArgumentException("Invalid direction.");
                }
            }
        }
        
        public void SelfHeal()
        {
            ISlot healthPotionSlot = this.Inventory
                .BackPack
                .SlotList
                .FirstOrDefault(x => x.GameItem is HealthPotion);

            if (healthPotionSlot == null)
            {
                throw new NoHealthPotionsException("There are no health potions left in the backpack.");
            }
            
            int maximumHealthRestore = this.startHealth;
            this.Health += (healthPotionSlot.GameItem as HealthPotion).HealthRestore;
            ConsoleRenderer.WriteLine("You restored {0} health points using Health Potion!", 
                (healthPotionSlot.GameItem as HealthPotion).HealthRestore);
            if (this.Health > maximumHealthRestore) //Healing potions only restore health to the player's current Health value.
            {
                this.Health = maximumHealthRestore;
            }
            this.Inventory.BackPack.RemoveItem(healthPotionSlot);
        }

        public void DrinkHealthBonusPotion()
        {
            ISlot healthBonusPotionSlot = this.Inventory
                .BackPack
                .SlotList
                .FirstOrDefault(x => x.GameItem is HealthBonusPotion);

            if (healthBonusPotionSlot == null)
            {
                throw new NoHealthBonusPotionsException("There are no health bonus potions left in the backpack.");
            }
            this.Health += (healthBonusPotionSlot.GameItem as HealthBonusPotion).HealthBonus;
            ConsoleRenderer.WriteLine("You boosted your health with {0} points using Health Bonus Potion!",
                (healthBonusPotionSlot.GameItem as HealthBonusPotion).HealthBonus);
            this.startHealth += (healthBonusPotionSlot.GameItem as HealthBonusPotion).HealthBonus; 
            this.Inventory.BackPack.RemoveItem(healthBonusPotionSlot);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Player stats:");
            output.AppendFormat("Health: {0}, Damage: {1}, Defensive Bonus: {2}", this.Health, this.Damage, this.DefensiveBonus);
            return output.ToString();
        }

        private void MoveLeft()
        {
            if (this.Position.Y - 1 < 0)
            {
                throw new ObjectOutOfBoundsException("You have reached the border of the map.");
            }

            this.ChangePlayerCoordinates(0, -1);

            
        }

        private void MoveRight()
        {
            if (this.Position.Y + 1 >= this.Engine.Map.Width)
            {
                throw new ObjectOutOfBoundsException("You have reached the border of the map.");
            }

            this.ChangePlayerCoordinates(0, 1);
        }

        private void MoveDown()
        {
            if (this.Position.X + 1 >= this.Engine.Map.Height)
            {
                throw new ObjectOutOfBoundsException("You have reached the border of the map.");
            }

            this.ChangePlayerCoordinates(1, 0);
        }

        private void MoveUp()
        {
            if (this.Position.X - 1 < 0)
            {
                throw new ObjectOutOfBoundsException("You have reached the border of the map.");
            }

            this.ChangePlayerCoordinates(-1, 0);
        }

        private void ChangePlayerCoordinates(int x, int y)
        {
            this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = DefaultEmptyMapSybmol;
            this.Position = new Position(this.Position.X + x, this.Position.Y + y);
            this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = DefaultPlayerSymbol;
        }
    }
}
