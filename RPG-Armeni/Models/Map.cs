using RPGArmeni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Models
{
    public class Map : IMap
    {
        private int height;
        private int width;
        public readonly int[,] matrix;

        public Map(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.matrix = new int[this.Height, this.Width];
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
    }
}
