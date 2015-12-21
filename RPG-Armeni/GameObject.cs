namespace RPGArmeni
{
    using System;
    using Engine;
    using Exceptions;
    using Interfaces;

    public abstract class GameObject : IGameObject
    {
        private IPosition position;
        private char objectSymbol;

        protected GameObject(IPosition position, char objectSymbol)
        {
            this.Position = position;
            this.ObjectSymbol = objectSymbol;
        }

        public IPosition Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (this.IsOutsideGameField(value))
                {
                    throw new ObjectOutOfBoundsException("Specified coordinates are outside the game map.");
                }

                this.position = value;
            }
        }

        public char ObjectSymbol
        {
            get
            {
                return this.objectSymbol;
            }

            set
            {
                if (!char.IsUpper(value))
                {
                    throw new ArgumentOutOfRangeException("Object symbol must be an upper-case letter.");
                }

                this.objectSymbol = value;
            }
        }

        private bool IsOutsideGameField(IPosition value)
        {
            bool isOutside = value.X < 0
                    || value.Y < 0
                    || value.X >= GameEngine.MapHeight
                    || value.Y >= GameEngine.MapWidth;

            return isOutside;
        }
    }
}
