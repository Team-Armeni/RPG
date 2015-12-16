namespace RPGArmeni.Models.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Items;
    using RPGArmeni.Models.Containers;

    public class Player : Character, IPlayer
    {
        private const int PlayerStartingX = 0;
        private const int PlayerStartingY = 0;
        private IInventory inventory;
        private IContainer backPack;
        private PlayerRace race;
 
        public Player(Position position, char objectSymbol, string name, PlayerRace race)
            : base(position, objectSymbol, name, PlayerStartingX, PlayerStartingY)
        {
            this.Race = race;
            this.inventory = new Inventory();
            this.BackPack = new BackPack();
            this.SetPlayerStats();
        }

        public PlayerRace Race
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

        public void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    this.Position = new Position(this.Position.X, this.Position.Y - 1);
                    break;
                case "down":
                    this.Position = new Position(this.Position.X, this.Position.Y + 1);
                    break;
                case "right":
                    this.Position = new Position(this.Position.X + 1, this.Position.Y);
                    break;
                case "left":
                    this.Position = new Position(this.Position.X - 1, this.Position.Y);
                    break;
                default:
                    throw new ArgumentException("Invalid direction.", "direction");
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

            this.Health += (healthPotionSlot.GameItem as HealthPotion).HealthRestore;
            this.BackPack.RemoveItem(healthPotionSlot);
        }

        public override string ToString()
        {
            return string.Format("");
        }

        private void SetPlayerStats()
        {
            switch (this.Race)
            {
                case PlayerRace.Elf:
                    this.Damage = 300;
                    this.Health = 100;
                    break;
                case PlayerRace.Archangel:
                    this.Damage = 250;
                    this.Health = 150;
                    break;
                case PlayerRace.Hulk:
                    this.Damage = 350;
                    this.Health = 75;
                    break;
                case PlayerRace.Alcoholic:
                    this.Damage = 200;
                    this.Health = 200;
                    break;
                default:
                    throw new ArgumentException("Unknown player race.");
            }
        }
    }
}
