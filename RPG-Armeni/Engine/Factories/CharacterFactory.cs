using RPGArmeni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Engine.Factories
{
    public class CharacterFactory
    {
        private static CharacterFactory instance;

        private CharacterFactory()
        {
        }

        public static CharacterFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CharacterFactory();
                }

                return instance;
            }
        }

        public IGameEngine Engine { get; set; }

        public ICharacter CreateCharacter()
        {
            throw new NotImplementedException();
        }
    }
}
