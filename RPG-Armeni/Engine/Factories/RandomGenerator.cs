namespace RPGArmeni.Engine.Factories
{
    using System;

    public static class RandomGenerator
    {
        private static Random randomGenerator = new Random();

        public static int GenerateNumber(int limit)
        {
            return randomGenerator.Next(limit);
        }

        public static int GenerateNumber(int start, int end)
        {
            return randomGenerator.Next(start, end);
        }
    }
}
