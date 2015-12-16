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

        public CharacterFactory Instance
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

        public ICharacter CreateCharacter(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
