﻿namespace RPGArmeni.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params object[] paramaters);

        void Clear();
    }
}
