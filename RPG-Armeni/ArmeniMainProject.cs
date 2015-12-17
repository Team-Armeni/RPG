namespace RPGArmeni
{
    using Engine;
    using Interfaces;
    using UI;
    using Engine.Factories;

    public class ArmeniMainProject
    {
        public static void Main()
        {
            IGameEngine engine = new GameEngine();
            ItemFactory.Instance.Engine = engine;
            CharacterFactory.Instance.Engine = engine;

            engine.Run();
        }
    }
}
