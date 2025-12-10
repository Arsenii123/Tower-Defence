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
    using Tower_Defence.Logic;
    using global::Tower.Logic;

    /// <summary>
    /// Абастрактний клас ворога який буде успадковуватися
    /// </summary>
    ///<reamrks>
    /// Містить в собі функції як пересування, "анімацїї" та здоров'я
    ///</reamrks>
    abstract class Enemy
    {
        public delegate void MyEventHandler(Main e,List<Tower> t);
        public  MyEventHandler? MakeMove;
        public int health ; // начальное здоровье врага
        public int speed ; // задержка в миллисекундах между шагами (чем меньше — тем быстрее)
        public int x, y; // текущие координаты врага на карте
        public int oldX, oldY; // предыдущие координаты (для стирания старого положения)
        public void StartEvent(Main e, List<Tower> t)
        {
            if (MakeMove != null)
                MakeMove(e,t);
        }
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
        virtual public void IsSlowed(int speed)
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
        virtual public void IsMoving(Main m, List <Tower> t)
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

        virtual public bool End()
        {
            return false;
        }
        virtual public void Up()
        {

        }
        virtual public  void ClearPrevious() // стираем предыдущее положение врага
        {

        }
        virtual public  void Draw() // отрисовываем врага в новой позиции
        {

        }

    }

}
