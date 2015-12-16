using RPGArmeni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Models.Items.ArmorItems
{
    public abstract class ArmorItem : Item, IArmor
    {
        private int defenceBonus;

        protected ArmorItem(Position position, char itemSymbol, int defenceBonus)
            : base(position, itemSymbol)
        {
            this.DefenceBonus = defenceBonus;
        }

        public int DefenceBonus
        {
            get
            {
                return this.defenceBonus;
            }
            protected set
            {
                this.defenceBonus = value;
            }
        }
    }
}
