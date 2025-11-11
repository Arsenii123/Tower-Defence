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

    class Enemy
         {
          protected int health= 0;
          protected int speed = 0;
          private static Timer timer;
        public Enemy()
        {
            health+=15;
            speed += 3000;
        }
        public void IsAttacked(int damage)
        {
            health = health - damage;

        }
        public void IsMoving(Main m)
        {
             m = new Main();
            int X = 0;
            int Y = 2;
            int oldX = 0;
            int oldY = 0;
            for(int y =0; y < 22; y++)
            {
                for(int x=0; x < 51; x++)
                {
                    oldX = X;
                    oldY = Y;
                    if (m.IsPath(y, x + 1) == true)
                    {
                        X = x;
                        Y = y;
                        X++;
                    }
                    else if (m.IsPath(y + 1, x) == true )
                    {
                        X = x;
                        Y = y;
                        Y++;
                    }
                    else if (x > 1 && y > 1)
                    {
                        if ( m.IsPath(y, x - 1) == true)
                        {
                            X = x;
                            Y = y;
                            X--;
                        }
                        else if ( m.IsPath(y - 1, x) == true)
                        {
                            X = x;
                            Y = y;
                            Y--;
                        }
                    }

                    // Создаем таймер на 3 секунды (3000 миллисекунд)
                    timer = new Timer(3000);

                    // Авто сброс false, чтобы событие выполнялось только один раз
                    timer.AutoReset = true;
                    timer.Enabled = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.CursorLeft = X;
                    Console.CursorTop = Y;
                    timer.Start();
                    Console.WriteLine(".");
                    Console.ResetColor();
                    timer.Start();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.CursorLeft = X;
                    Console.CursorTop = Y;
                    Console.WriteLine("\u2588");
                    Console.ResetColor();



                }
                Console.WriteLine();
            }



        }

    }


    }
