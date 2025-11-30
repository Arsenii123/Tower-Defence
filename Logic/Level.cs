using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Logic
{
    /// <summary>
    /// Клас про рівень 
    /// </summary>
    ///<reamrks>
    /// Містить в собі функцію про переход на новий рівень
    ///</reamrks>
    class Level :Wave
    {
        int number = 1;
        public void LevelUp()
        {
            ///<summary>
            ///Новий рівень
            ///</summary>
            number++;
            ResetWave();
        }
    }
}
