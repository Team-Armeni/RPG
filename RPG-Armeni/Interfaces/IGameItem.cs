namespace RPGArmeni.Interfaces
{
    using System;
    using Models.Items;

    public interface IGameItem : IGameObject
    {
        ItemState ItemState { get; set; }
    }
}
