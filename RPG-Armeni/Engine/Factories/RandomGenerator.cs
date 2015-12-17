using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Engine.Factories
{
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
