namespace RPGArmeni.Models.Characters
{
    using System;
    using Interfaces;
    using Exceptions;

    public abstract class Character : GameObject, ICharacter
    {
        private int health;
        private int damage;

        protected Character(IPosition position, char objectSymbol, int damage, int health)
            : base(position, objectSymbol)
        {
            this.Damage = damage;
            this.Health = this.ValidateHealth(health);
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
                if (value < 0)
                {
                    throw new ArgumentException("Character damage", "Damage value cannot be negative.");
                }
                this.damage = value;
            }
        }

        public void Attack(ICharacter enemy)
        {
            enemy.Health -= this.Damage;
            if (enemy is IPlayer)
            {
                enemy.Health += (enemy as IPlayer).DefensiveBonus;
            }
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
