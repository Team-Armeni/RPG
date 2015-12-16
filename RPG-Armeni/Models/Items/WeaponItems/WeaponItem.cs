using RPGArmeni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Models.Items.WeaponItems
{
    public abstract class WeaponItem : Item, IWeapon
    {
        private int attackBonus;

        protected WeaponItem(Position position, char itemSymbol, int attackBonus)
            : base(position, itemSymbol)
        {
            this.AttackBonus = attackBonus;
        }

        public int AttackBonus
        {
            get { return this.attackBonus; }
            protected set
            {
                this.attackBonus = value;
            }
        }
    }
}
