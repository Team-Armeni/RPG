namespace RPGArmeni.Engine.Factories
{
    using Attributes;
    using Interfaces;
    using Models.Items;
    using System;
    using System.Linq;
    using System.Reflection;

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
            int currentX = RandomGenerator.GenerateNumber(0, this.Engine.Map.Height);
            int currentY = RandomGenerator.GenerateNumber(0, this.Engine.Map.Width);

            bool isEmptySpot = this.Engine.Map.Matrix[currentX, currentY] == '.';

            while (!isEmptySpot)
            {
                currentX = RandomGenerator.GenerateNumber(0, this.Engine.Map.Height);
                currentY = RandomGenerator.GenerateNumber(0, this.Engine.Map.Width);

                isEmptySpot = this.Engine.Map.Matrix[currentX, currentY] == '.';
            }
            var itemTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.CustomAttributes
                    .Any(a => a.AttributeType == typeof(ItemAttribute)))
                    .ToArray();
            Type currentType = itemTypes[RandomGenerator.GenerateNumber(0, itemTypes.Length)];
            IGameItem currentItem;
            if (currentType.Name == "HealthPotion")
            {
                int potionType = RandomGenerator.GenerateNumber(0, 3);

                HealthPotionSize potionSize;

                switch (potionType)
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
                        throw new ArgumentOutOfRangeException("Invalid potion type.");
                }

                currentItem = new HealthPotion(new Position(currentX, currentY), potionSize);
                this.Engine.Map.Matrix[currentX, currentY] = currentItem.ObjectSymbol;
                return currentItem;
            }
            else if (currentType.Name == "HealthBonusPotion")
            {
                int potionType = RandomGenerator.GenerateNumber(0, 3);

                HealthBonusPotionSize potionSize;

                switch (potionType)
                {
                    case 0:
                        potionSize = HealthBonusPotionSize.Minor;
                        break;
                    case 1:
                        potionSize = HealthBonusPotionSize.Normal;
                        break;
                    case 2:
                        potionSize = HealthBonusPotionSize.Major;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Invalid potion type.");
                }

                currentItem = new HealthBonusPotion(new Position(currentX, currentY), potionSize);
                this.Engine.Map.Matrix[currentX, currentY] = currentItem.ObjectSymbol;
                return currentItem;
            }
            currentItem = Activator.CreateInstance(currentType, new Position(currentX, currentY)) as IGameItem;
            this.Engine.Map.Matrix[currentX, currentY] = currentItem.ObjectSymbol;

            return currentItem;
            
        }
    }
}
