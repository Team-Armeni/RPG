namespace RPGArmeni.Items
{
    public class HealthPotion : Item
    {
        private const char HealthPotionSymbol = 'H';

        public HealthPotion(Position position, HealthPotionSize beerSize)
            : base(position, HealthPotionSymbol)
        {
            this.BeerSize = beerSize;
        }

        public int HealthRestore
        {
            get
            {
                return (int)this.BeerSize;
            }
        }

        private HealthPotionSize BeerSize { get; set; }
    }
}
