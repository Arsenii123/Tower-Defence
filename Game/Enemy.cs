using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Game
{
    class Enemy
    {
        protected int health= 0;
        protected double speed = 0;
        public Enemy()
        {
            health+=15;
            speed += 2.6;
        }
        public void IsAttacked(int damage)
        {
            health = health - damage;
            Console.WriteLine($" Health:{health}");//проверка на работу
        }
    }
}
