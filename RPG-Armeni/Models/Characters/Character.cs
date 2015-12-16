namespace RPGArmeni.Models.Characters
{
    using System;
    using Interfaces;
    using Exceptions;

    public abstract class Character : GameObject, ICharacter
    {
        private string name;
        private int health;
        private int damage;

        protected Character(IPosition position, char objectSymbol, string name, int damage, int health)
            : base(position, objectSymbol)
        {
            this.Damage = damage;
            this.Health = this.ValidateHealth(health);
            this.Name = name;
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

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            protected set
            {
                this.damage = value;
            }
        }

        public void Attack(ICharacter enemy)
        {
            enemy.Health -= this.Damage;
        }

        private int ValidateHealth(int health)
        {
            if (health < 1)
            {
                throw new InvalidHealthException("Starting health cannot be lower than 1.");
            }

            return health;
        }
    }
}
