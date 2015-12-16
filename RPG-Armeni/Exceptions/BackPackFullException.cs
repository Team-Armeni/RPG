using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Exceptions
{
    public class BackPackFullException : Exception
    {
        public BackPackFullException(string message)
            : base(message)
        {   
        }
    }
}
