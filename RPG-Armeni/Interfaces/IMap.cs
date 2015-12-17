using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Interfaces
{
    public interface IMap
    {
        int Width { get; }

        int Height { get; }

        char[,] Matrix { get; }
    }
}
