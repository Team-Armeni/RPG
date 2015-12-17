namespace RPGArmeni.Interfaces
{
    public interface ICharacter : IGameObject, IAttack, IDestroyable
    {
        int Health { get; set; }
    }
}
