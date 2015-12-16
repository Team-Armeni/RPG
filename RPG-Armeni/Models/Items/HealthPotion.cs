namespace RPGArmeni.Models.Items
{
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

        private HealthPotionSize HealthPotionSize { get; set; }
    }
}
