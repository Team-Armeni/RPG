namespace RPGArmeni.Engine.Commands
{
    using Factories;
    using Interfaces;
    using System;

    public class SpawnEnemiesCommand : GameCommand
    {
        public SpawnEnemiesCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute()
        {
            for (int i = 0; i < this.Engine.NumberOfEnemies; i++)
            {
                ICharacter enemy = CharacterFactory.Instance.CreateCharacter();
                this.Engine.AddEnemy(enemy);
            }
        }
    }
}
