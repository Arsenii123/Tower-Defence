using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Tower.Logic
{
    /// <summary>
    /// Клас апгрейду
    /// </summary>
    ///<reamrks>
    /// Містить в собі функцію про збільшення 
    ///</reamrks>
    using Tower_Defence.Game;
    class Upgrade
    {
        List<int> upgrades=new List<int>();
        public  Upgrade()
        {

        }
        public void LevelUp(List<Tower> t)
        {
            /// <summary>
            /// Функція про підвищення характеристик
            /// </summary>


            while (true)
            {
                Console.SetCursorPosition(54, 2);
                Console.WriteLine("Number of tower(if nothing print -1):");
                int number = Convert.ToInt32(Console.ReadLine());
                ConsoleKeyInfo k = Console.ReadKey(true);
                if (upgrades[number] != 10 || number!=-1)
                {
                    t[number].Up();
                    upgrades[number]++;
                }
                else
                {
                    Console.WriteLine("Can`t upgrade(if you dont press -1 this tower has max level)");
                }
                if (k.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
 

        }
    }
}
