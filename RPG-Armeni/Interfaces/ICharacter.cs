namespace RPGArmeni.Interfaces
{
    public interface ICharacter : IGameObject, IAttack, IDestroyable
    {
        string Name { get; }

        int Health { get; set; }
    }
}
