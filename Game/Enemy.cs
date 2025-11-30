using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Logic;

namespace Tower_Defence.Game
{
    using Tower_Defence.Menu;
    using System.Timers;

/// <summary>
/// Абастрактний клас ворога який буде успадковуватися
/// </summary>
///<reamrks>
/// Містить в собі функції як пересування, "анімацїї" та здоров'я
///</reamrks>
    abstract class Enemy
    {
        public delegate void MyEnemy();
        public static Enemy operator --(Enemy e)
        {
            e = null;
            return null;


        }
        virtual public void IsAttacked(int damage)
        {
            ///<example>
            ///Приклад  атаки
            ///<code>
            ///Enemy e =new Enemy();
            ///e.IsAttacked(20);
            ///</code>
            ///</example>
        }
        virtual public void Appear()
        {
            ///<example>
            ///Приклад  анімації
            ///<code>
            ///Enemy e =new Enemy();
            ///e.Appear();
            ///</code>
            ///*анімація
            ///</example>

        }
        virtual public void IsMoving(Main m)
        {
            ///<example>
            ///Приклад пересування
            ///<code>
            ///Enemy e =new Enemy();
            ///e.IsMoving(m)
            ///</code>
            ///</example>
            /// <value>    m- це клас який створює  карту, ми його викликаємо щоб перенести інформацію про дорогу в клас </value>
        }

    }

}
