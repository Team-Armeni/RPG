namespace RPGArmeni.Models.Characters
{
    using System;
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Items;
    using RPGArmeni.Models.Containers;
    using System.Text;
    using RPGArmeni.UI;

    public class Player : Character, IPlayer
    {
        private const int PlayerStartingX = 0;
        private const int PlayerStartingY = 0;
        private string name;
        private int defensiveBonus;
        private IInventory inventory;
        private IContainer backPack;
        private IRace race;
 
        public Player(IPosition position, char objectSymbol, string name, IRace race)
            : base(position, objectSymbol, race.Damage, race.Health)
        {
            this.Name = name;
            this.Race = race;
            this.inventory = new Inventory();
            this.BackPack = new BackPack();
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

        public IContainer BackPack
        {
            get
            {
                return this.backPack;
            }
            private set
            {
                this.backPack = value;
            }
        }

        public IGameEngine Engine { get; set; }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    if (this.Position.X - 1 < 0)
                    {
                        throw new ObjectOutOfBoundsException("You have reached the border of the map.");
                    }

                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = '.';
                    this.Position = new Position(this.Position.X - 1, this.Position.Y);
                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = 'P';
                    break;
                case "down":
                    if (this.Position.X + 1 >= this.Engine.Map.Height)
                    {
                        throw new ObjectOutOfBoundsException("You have reached the border of the map.");
                    }

                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = '.';
                    this.Position = new Position(this.Position.X + 1, this.Position.Y);
                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = 'P';
                    break;
                case "right":
					if (this.Position.Y + 1 >= this.Engine.Map.Width)
                    {
                        throw new ObjectOutOfBoundsException("You have reached the border of the map.");
                    }

                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = '.';
                    this.Position = new Position(this.Position.X, this.Position.Y + 1);
                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = 'P';
                    break;
                case "left":
                    if (this.Position.Y - 1 < 0)
                    {
                        throw new ObjectOutOfBoundsException("You have reached the border of the map.");
                    }

                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = '.';
                    this.Position = new Position(this.Position.X, this.Position.Y - 1);
                    this.Engine.Map.Matrix[this.Position.X, this.Position.Y] = 'P';
                    break;
                default:
                    {
                        throw new ArgumentException("Invalid direction.");
                    }
            }
        }

        public void SelfHeal()
        {
            ISlot healthPotionSlot = this.BackPack
                .SlotList
                .FirstOrDefault(x => x is HealthPotion);

            if (healthPotionSlot == null)
            {
                throw new NoHealthPotionsException("There are no health potions left in the backpack.");
            }

            int maximumHealthRestore = this.Health;
            this.Health += (healthPotionSlot.GameItem as HealthPotion).HealthRestore;
            ConsoleRenderer.WriteLine("You restored {0} health points using Health Potion!", 
                (healthPotionSlot.GameItem as HealthPotion).HealthRestore);
            if (this.Health > maximumHealthRestore) //Healing potions only restore health to the player's current Health value.
            {
                this.Health = maximumHealthRestore;
            }
            this.BackPack.RemoveItem(healthPotionSlot);
        }

        public void DrinkHealthBonusPotion()
        {
            ISlot healthPotionSlot = this.BackPack
                .SlotList
                .FirstOrDefault(x => x is HealthBonusPotion);

            if (healthPotionSlot == null)
            {
                throw new NoHealthPotionsException("There are no health potions left in the backpack.");
            }
            this.Health += (healthPotionSlot.GameItem as HealthBonusPotion).HealthBonus;
            this.BackPack.RemoveItem(healthPotionSlot);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Player stats:");
            output.AppendFormat("Health: {0}, Damage: {1}, Defensive Bonus: {2}", this.Health, this.Damage, this.DefensiveBonus);
            return output.ToString();
        }
    }
}
