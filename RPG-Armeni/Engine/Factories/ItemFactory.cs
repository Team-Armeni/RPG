namespace RPGArmeni.Engine.Factories
{
    using RPGArmeni.Interfaces;
    using System;

    public class ItemFactory
    {
        private static ItemFactory instance;

        private ItemFactory()
        {
        }

        public ItemFactory Instance
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

        public IGameItem CreateItem(string[] args);
    }
}
