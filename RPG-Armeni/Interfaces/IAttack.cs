namespace RPGArmeni.Interfaces
{
    public interface IAttack
    {
        int Damage { get; }

        void Attack(ICharacter enemy);
    }
}
