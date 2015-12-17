using RPGArmeni.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Models.Characters
{
    public abstract class Race : IRace //A base abstract class for playable races. The player picks one.
    {
        private int health;
        private int damage;

        public Race(int health, int damage)
        {
            this.Health = health;
            this.Damage = damage;
        }

        public Race()
        {

        }

        public int Health
        {
            get { return this.health; }
            protected set
            {
                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            protected set
            {
                this.damage = value;
            }
        }
    }
}
