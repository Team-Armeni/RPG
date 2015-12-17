namespace RPGArmeni
{
    using Engine;
    using Interfaces;
    using UI;

    public class ArmeniMainProject
    {
        public static void Main()
        {
            IGameEngine engine = new GameEngine();

            engine.Run();
        }
    }
}
