namespace RPGArmeni.Models.Characters
{
    using Attributes;

    [Race]
    public class Orc : Race //A playable race character.
    {
        private const int OrcBaseDamage = 30;
        private const int OrcBaseHealth = 150;

        public Orc(int health, int damage)
            : base(OrcBaseHealth, OrcBaseDamage)
        {
        }

        public Orc()
            : base()
        {
            this.Health = OrcBaseHealth;
            this.Damage = OrcBaseDamage;
        }
    }
}
