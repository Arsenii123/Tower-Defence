using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Logic;

namespace Tower_Defence.Game
{
    class Tower
    {
       protected int damage;
       protected double speed;
       protected double price;
       public  Tower(int coins)
        {
            Console.WriteLine(coins);
        }
        public Tower():this(0)
        {
            damage = 15;
            speed = 3;
            price = 5;
        }
        public  void Attack(Enemy e)
        {
            e = new Enemy();
            e.IsAttacked(damage);
        }

    }
}
