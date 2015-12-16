namespace RPGArmeni.Interfaces
{
    using Models.Characters;

    public interface IPlayer : ICharacter, IMoveable, ICollect, IHeal
    {
        PlayerRace Race { get; }
    }
}
