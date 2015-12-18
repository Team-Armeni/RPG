namespace RPGArmeni.Models.Characters
{
    using Attributes;

    [Race]
    public class Human : Race //A playable race character.
    {
        private const int HumanBaseDamage = 35;
        private const int HumanBaseHealth = 220;

        public Human(int health, int damage)
            : base(HumanBaseHealth, HumanBaseDamage)
        {
        }

        public Human()
            : base()
        {
            this.Health = HumanBaseHealth;
            this.Damage = HumanBaseDamage;
        }
    }
}