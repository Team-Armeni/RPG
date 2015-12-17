namespace RPGArmeni.Models.Characters
{
    using Attributes;

    [Enemy]
    public class Goblin : Character
    {
        private const int GoblinDamage = 25;
        private const int GoblinHealth = 130;
        private const char GoblinSymbol = 'G';

        public Goblin(Position position)
            : base(position, GoblinSymbol, GoblinDamage, GoblinHealth)
        {
        }
    }
}
