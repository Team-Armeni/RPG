using RPGArmeni.Attributes;
using System;

namespace RPGArmeni.Models.Items.WeaponItems
{
    [Weapon]
    [ItemAttribute]
    public class Axe : WeaponItem
    {
        private const char AxeSymbol = 'A';
        private const int AxeAttackBonus = 15;
        public Axe(Position position) : base(position, AxeSymbol, AxeAttackBonus)
        {

        }
    }
}
