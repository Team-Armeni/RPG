using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Interfaces
{
    public interface IGameCommand
    {
        IGameEngine Engine { get; set; }

        void Execute(string[] args);
    }
}
