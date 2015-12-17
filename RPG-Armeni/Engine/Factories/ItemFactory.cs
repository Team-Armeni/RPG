namespace RPGArmeni.Engine.Factories
{
    using RPGArmeni.Interfaces;
    using RPGArmeni.Models.Items;
    using System;
    using System.Linq;

    public class ItemFactory
    {
        private static ItemFactory instance;

        private ItemFactory()
        {
        }

        public static ItemFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemFactory();
                }

                return instance;
            }
        }

        public IGameEngine Engine { get; set; }

        public IGameItem CreateItem()
        {
            int currentX = RandomGenerator.GenerateNumber(1, this.Engine.Map.Height);
            int currentY = RandomGenerator.GenerateNumber(1, this.Engine.Map.Width);

            bool containsEnemy = this.Engine.Characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            bool containsBeer = this.Engine.Items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            while (containsEnemy || containsBeer)
            {
                currentX = RandomGenerator.GenerateNumber(1, this.Engine.Map.Height);
                currentY = RandomGenerator.GenerateNumber(1, this.Engine.Map.Width);

                containsEnemy = this.Engine.Characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

                containsBeer = this.Engine.Items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }

            int beerType = RandomGenerator.GenerateNumber(0, 3);

            HealthPotionSize potionSize;

            switch (beerType)
            {
                case 0:
                    potionSize = HealthPotionSize.Minor;
                    break;
                case 1:
                    potionSize = HealthPotionSize.Normal;
                    break;
                case 2:
                    potionSize = HealthPotionSize.Major;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("potionType", "Invalid potion type.");
            }

            return new HealthPotion(new Position(currentX, currentY), potionSize);
        }
    }
}
