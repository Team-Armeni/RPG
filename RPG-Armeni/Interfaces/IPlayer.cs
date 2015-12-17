namespace RPGArmeni.Interfaces
{
    using Models.Characters;

    public interface IPlayer : ICharacter, IMoveable, ICollect
    {
        string Name { get; }
        IRace Race { get; }
    }
}
