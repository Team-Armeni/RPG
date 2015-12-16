namespace RPGArmeni.Interfaces
{
    using Characters;

    public interface IPlayer : ICharacter, IMoveable, ICollect, IHeal
    {
        PlayerRace Race { get; }
    }
}
