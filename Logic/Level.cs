using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Logic
{
    class Level:Wave
    {
        int number = 1;
        public void LevelUp()
        {
            number++;
            ResetWave();
        }
    }
}
