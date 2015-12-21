namespace RPGArmeni.UI
{
    using System;
    using Interfaces;

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
