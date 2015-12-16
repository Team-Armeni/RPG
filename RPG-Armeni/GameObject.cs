namespace RPGArmeni
{
    using System;
    using Engine;
    using Exceptions;

    public abstract class GameObject
    {
        private Position position;
        private char objectSymbol;

        protected GameObject(Position position, char objectSymbol)
        {
            this.Position = position;
            this.ObjectSymbol = objectSymbol;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (this.IsOutsideGameField(value))
                {
                    throw new ObjectOutOfBoundsException("Specified coordinates are outside map.");
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

        private bool IsOutsideGameField(Position value)
        {
            bool isOutside = value.X < 0
                    || value.Y < 0
                    || value.X >= GameEngine.MapWidth
                    || value.Y >= GameEngine.MapHeight;

            return isOutside;
        }
    }
}
