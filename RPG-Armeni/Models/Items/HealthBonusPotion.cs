using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Models.Items
{
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
