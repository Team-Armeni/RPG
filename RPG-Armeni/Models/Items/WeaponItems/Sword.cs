using RPGArmeni.Attributes;
using System;

namespace RPGArmeni.Models.Items.WeaponItems
{
    [Weapon]
    [ItemAttribute]
    public class Sword : WeaponItem
    {
        private const char SwardSymbol = 'S';
        private const int SwardAttackBonus = 10;
        public Sword(Position position) : base(position, SwardSymbol, SwardAttackBonus)
        {

        }
    }
}
