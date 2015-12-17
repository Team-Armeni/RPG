using RPGArmeni.Attributes;
using System;

namespace RPGArmeni.Models.Items.WeaponItems
{
    [Weapon]
    public class Sward : WeaponItem
    {
        private const char SwardSymbol = 'S';
        private const int SwardAttackBonus = 10;
        public Sward(Position position) : base(position, SwardSymbol, SwardAttackBonus)
        {

        }
    }
}
