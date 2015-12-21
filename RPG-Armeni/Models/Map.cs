namespace RPGArmeni.Models
{
    using Interfaces;

    public class Map : IMap
    {
        private int height;
        private int width;
        private char[,] matrix;

        public Map(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.Matrix = new char[this.Height, this.Width];
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = value;
            }
        }


        public char[,] Matrix
        {
            get { return this.matrix; }
            private set
            {
                this.matrix = value;
            }
        }
    }
}
