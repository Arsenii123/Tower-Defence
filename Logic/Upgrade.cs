using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Tower.Logic
{
    using Tower_Defence.Game;
    class Upgrade:Tower
    {
       public  Upgrade():base()
        {
            damage = +5;
            speed -= 0.8;
        }
        public void LevelUp()
        {
            damage += 2;
            speed -= 0.3;
            price += 10;
        }
    }
}
