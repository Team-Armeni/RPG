using System;

namespace RPGArmeni.Interfaces
{
    public interface IMoveable
    {
        void Move(string direction);

        void Move(IKeyInfo direction);
    }
}
