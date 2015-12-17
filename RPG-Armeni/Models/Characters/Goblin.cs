namespace RPGArmeni.Models.Characters
{
    using Attributes;

    [Enemy]
    public class Goblin : Character
    {
        private const int GoblinDamage = 5;
        private const int GoblinHealth = 30;
        private const char GoblinSymbol = 'G';

        public Goblin(Position position)
            : base(position, GoblinSymbol, GoblinDamage, GoblinHealth)
        {
        }
    }
}
