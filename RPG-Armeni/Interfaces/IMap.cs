namespace RPGArmeni.Interfaces
{
    public interface IMap
    {
        int Width { get; }

        int Height { get; }

        char[,] Matrix { get; }
    }
}
