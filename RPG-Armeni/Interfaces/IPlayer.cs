namespace RPGArmeni.Interfaces
{
	public interface IPlayer : ICharacter, IMoveable, ICollect
    {
        string Name { get; }

        IRace Race { get; }

        int DefensiveBonus { get; }

        IGameEngine Engine { get; set; }

        void SelfHeal();
        
        void DrinkHealthBonusPotion();
    }
}
