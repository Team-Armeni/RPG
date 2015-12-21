namespace RPGArmeni
{
    using Interfaces;

    public struct Position : IPosition
    {
        public Position(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
