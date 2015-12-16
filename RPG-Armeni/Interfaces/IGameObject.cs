namespace RPGArmeni.Interfaces
{
    using System;

    public interface IGameObject
    {
        IPosition Position { get; set; }

        char ObjectSymbol { get; set; }
    }
}
