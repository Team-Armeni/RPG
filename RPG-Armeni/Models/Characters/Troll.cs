namespace RPGArmeni.Models.Characters
{
    using Attributes;

    [Enemy]
    public class Troll : Character
    {
        private const int TrollDamage = 45;
        private const int TrollHealth = 400;
        private const char TrollSymbol = 'T';

        public Troll(Position position)
            : base(position, TrollSymbol, TrollDamage, TrollHealth)
        {
        }
    }
}
