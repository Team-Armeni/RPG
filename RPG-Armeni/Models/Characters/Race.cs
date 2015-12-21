namespace RPGArmeni.Models.Characters
{
    using Interfaces;

    public abstract class Race : IRace //A base abstract class for playable races. The player picks one.
    {
        private int health;
        private int damage;

        protected Race(int health, int damage)
        {
            this.Health = health;
            this.Damage = damage;
        }

        protected Race()
        {

        }

        public int Health
        {
            get { return this.health; }
            protected set
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
    }
}
