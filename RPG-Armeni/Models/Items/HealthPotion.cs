using RPGArmeni.Attributes;

namespace RPGArmeni.Models.Items
{
    [ItemAttribute]
    public class HealthPotion : Item
    {
        private const char HealthPotionSymbol = 'H';

        public HealthPotion(Position position, HealthPotionSize healthPotionSize)
            : base(position, HealthPotionSymbol)
        {
            this.HealthPotionSize = healthPotionSize;
        }

        public int HealthRestore
        {
            get
            {
                return (int)this.HealthPotionSize;
            }
        }

        public HealthPotionSize HealthPotionSize { get; set; }
    }
}
