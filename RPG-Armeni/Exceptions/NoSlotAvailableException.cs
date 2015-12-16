using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Exceptions
{
    public class NoSlotAvailableException : Exception
    {
        public NoSlotAvailableException(string message)
            : base(message)
        {
        }
    }
}
