using RPGArmeni.Interfaces;

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

        public override string ToString()
        {
            return string.Format("{0} attack bonus: {1}", this.GetType().Name, this.AttackBonus);
        }
    }
}
