using RPGArmeni.Attributes;
namespace RPGArmeni.Models.Items
{
    [ItemAttribute]
    class HealthBonusPotion : Item
    {
        private const char HealthBonusPotionSymbol = 'B';

        public HealthBonusPotion(Position position, HealthBonusPotionSize healthBonusPotionSize)
            : base(position, HealthBonusPotionSymbol)
        {
            this.HealthBonusPotionSize = healthBonusPotionSize;
        }

        public int HealthBonus
        {
            get
            {
                return (int)this.HealthBonusPotionSize;
            }
        }

        public HealthBonusPotionSize HealthBonusPotionSize { get; set; }

    }
}
