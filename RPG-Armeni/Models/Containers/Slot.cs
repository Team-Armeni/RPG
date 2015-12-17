namespace RPGArmeni.Models.Containers
{
    using RPGArmeni.Interfaces;

	public class Slot : ISlot
    {
        private IGameItem gameItem;
        private bool isEmpty;

        public IGameItem GameItem
        {
            get
            {
                return this.gameItem;
            }
            set
            {
                this.gameItem = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.isEmpty;
            }
            set
            {
                this.isEmpty = value;
            }
        }

        public void ClearSlot()
        {
            this.GameItem = null;
            this.IsEmpty = true;
        }
    }
}
