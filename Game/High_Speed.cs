using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Menu;

namespace Tower_Defence.Game
{
    /// <summary>
    /// Це нащадок ворога 
    /// </summary>
    class High_Speed : Enemy
    {
        public static High_Speed operator --(High_Speed e)
        {
            e = null;
            return null;


        }
        protected  int health = 0;
        protected int speed = 0;
        public High_Speed() 
        {
            health += 15;
            speed += 3000;
        }
        public override void  IsAttacked(int damage)
        {
            /// <summary>
            /// Задаємо у цьому кострукторі параматри
            /// </summary>
            health = health - damage;

        }
        public void Animation()
        {
            Thread.Sleep(speed);
        }
        public  void Appear(int X, int Y)
        {
            ///<summary>
            ///налаштування функції яку взяли з батька
            ///</summary>
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(".");
            Console.ResetColor();


        }
        public void Exit(int oldX,int oldY)
        {
            Console.CursorLeft = oldX;
            Console.CursorTop = oldY;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\u2588");
            Console.ResetColor();
        }
        public override void  IsMoving(Main m)
        {
            ///<summary>
            ///налаштування функції яку взяли з батька
            ///</summary>
            m = new Main();
            int X = 0;
            int Y = 2;
            int oldX = 0;
            int oldY = 0;
            for (int y = 0; y < 22; y++)
            {
                for (int x = 0; x < 51; x++)
                {
                    oldX = X;
                    oldY = Y;
                    if (m.IsPath(y, x + 1) == true)
                    {
                        X = x;
                        Y = y;
                        X++;
                    }
                    else if (m.IsPath(y + 1, x) == true)
                    {
                        X = x;
                        Y = y;
                        Y++;
                    }
                    else if (x > 1 && y > 1)
                    {
                        if (m.IsPath(y, x - 1) == true)
                        {
                            X = x;
                            Y = y;
                            X--;
                        }
                        else if (m.IsPath(y - 1, x) == true)
                        {
                            X = x;
                            Y = y;
                            Y--;
                        }
                    }
                    Appear(X, Y);
                    Exit(oldX, oldY);
                    Thread t = new Thread(Animation);
                    t.Start();



                }
                Console.WriteLine();
            }
        }


    }
}
