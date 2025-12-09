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
    using Tower_Defence.Game;
    class Level :Wave
    {
       static uint level = 0;
        public uint Info
        {
            get
            {
                return level;
            }
            set
            {
                if (value > 0)
                    level = value;
            }
        }
       public  Level()
        {
            level = 1;
            Info = level;
        }
        public void LevelUp()
        {
            ///<summary>
            ///Новий рівень
            ///</summary>
            for(int i = 0; i < stage; i++)
            {
                if (i%30==0)
                {
                    level++;
                }
            }
            Console.SetCursorPosition(54, 2); // перемещаем курсор в текущие координаты


            info = $"Level: {level}";
            Console.WriteLine(info);



        }
    }
}
