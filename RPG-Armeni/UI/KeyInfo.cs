using System;
using System.Collections.Generic;
using System.Linq;
using RPGArmeni.Interfaces;

namespace RPGArmeni.UI
{
    public class KeyInfo : IKeyInfo
    {
        private ConsoleKeyInfo keyInfo;

        public KeyInfo()
        {
            this.keyInfo = Console.ReadKey();
        }

        public ConsoleKey Key
        {
            get { return keyInfo.Key; }
        }
    }
}
