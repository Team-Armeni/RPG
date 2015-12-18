namespace RPGArmeni.Models.Items
{
    using Interfaces;

    public abstract class Item : GameObject, IGameItem
    {
        private ItemState itemState;

        protected Item(Position position, char itemSymbol)
            : base(position, itemSymbol)
        {
            this.ItemState = ItemState.Available;
        }

        public ItemState ItemState
        {
            get
            {
                return this.itemState;
            }
            set
            {
                this.itemState = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", this.GetType().Name);
        }
    }
}
