namespace RPGArmeni.Models.Characters
{
    using Attributes;

    [Enemy]
    public class EnemyHuman : Character
    {
        private const int EnemyHumanDamage = 15;
        private const int EnemyHumanHealth = 80;
        private const char EnemyHumanSymbol = 'M';

        public EnemyHuman(Position position)
            : base(position, EnemyHumanSymbol, EnemyHumanDamage, EnemyHumanHealth)
        {
        }
    }
}
