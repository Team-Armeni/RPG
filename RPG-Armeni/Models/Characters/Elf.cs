namespace RPGArmeni.Models.Characters
{
    using Attributes;

    [Race]
    public class Elf : Race //A playable race character.
    {
        private const int ElfBaseDamage = 30;
        private const int ElfBaseHealth = 250;

        public Elf(int health, int damage)
            : base(ElfBaseHealth, ElfBaseDamage)
        {
        }

        public Elf()
            : base()
        {
            this.Health = ElfBaseHealth;
            this.Damage = ElfBaseDamage;
        }
    }
}
