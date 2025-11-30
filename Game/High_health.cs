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
    class High_health:Enemy
    {
        protected int health = 0;
        protected int speed = 0;
        public static High_health operator --(High_health e)
        {
            e = null;
            return null;


        }
        public High_health()
        {
            /// <summary>
            /// Задаємо у цьому кострукторі параматри
            /// </summary>
            health += 25;
            speed += 5000;
        }
        public override void IsAttacked(int damage)
        {
            ///<summary>
            ///налаштування функції яку взяли з батька
            ///</summary>
            health = health - damage;

        }
        public override void Appear()
        {
            ///<summary>
            ///налаштування функції яку взяли з батька
            ///</summary>
            while (true)
            {
                Console.WriteLine(".");
                Thread.Sleep(speed);
            }

        }
        public override void IsMoving(Main m)
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
                    Console.CursorLeft = X;
                    Console.CursorTop = Y;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ResetColor();
                    Thread t = new Thread(Appear);
                    t.Start();
                    Console.CursorLeft = oldX;
                    Console.CursorTop = oldY;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\u2588");
                    Console.ResetColor();

                }
                Console.WriteLine();
            }
        }
    }
}
