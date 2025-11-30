using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Logic;

namespace Tower_Defence.Game
{
    using System.IO;
    using Tower_Defence.Menu;
    /// <summary>
    /// Абастрактний клас башні  який буде успадковуватися
    /// </summary>
    ///<reamrks>
    /// Містить в собі функції як атака та явний і неявний конструктор
    ///</reamrks>
    class Tower
    {
       protected int damage;
       protected double speed;
       protected double price;
        public delegate void  MyTower();
        public static Tower operator --(Tower e)
        {
            e = null;
            return null;
          
            
        }
        public  Tower(int coins)
        {
            ///<example>
            ///Приклад конструктора
            ///<code>
            ///Tower e =new Tower(18);
            ///</code>
            ///*18
            ///</example>
            ///<value>кількість монет</value>
            Console.WriteLine(coins);
        }
        public Tower():this(0)
        {
            ///<example>
            ///Приклад конструктора
            ///<code>
            ///Tower e =new Tower();
            ///</code>
            ///налаштування параметрів
            ///</example>
            damage = 15;
            speed = 3;
            price = 5;
        }
        public void Attack(Enemy  e)
        {
            ///<example>
            ///Приклад атаки
            ///<code>
            ///Tower a =new Tower(e);
            ///a.Attack
            ///</code>
            ///*атака
            ///</example>
            ///<value> e - абстркатний клас ворога для виклику його функції </value>
            e = new High_Speed();
            e.IsAttacked(damage);
        }
        public void Placement()
        {
            char fullBlock = '█';   // Полный блок
            char vertical = '│';    // Вертикальная линия
            int X = 0;
            int Y = 0;
            int oldX = 0;
            int oldY = 0;
            while (true)
            {   
                    ConsoleKeyInfo k = Console.ReadKey(true);
                     oldX = X;
                     oldY = Y;

                        switch (k.Key)
                        {
                            case ConsoleKey.RightArrow:
                                X++;
                                break;
                            case ConsoleKey.LeftArrow:
                                X--;
                                break;
                            case ConsoleKey.UpArrow:
                                Y--;
                                break;
                            case ConsoleKey.DownArrow:
                                Y++;
                                break;

                        }
                        Console.CursorLeft = X;
                        Console.CursorTop = Y;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(".");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorLeft = oldX;
                        Console.CursorTop = oldY;
                        Console.WriteLine("\u2588");
                        Console.ResetColor();
                if (k.Key == ConsoleKey.B)
                {
                    Console.CursorLeft = X;
                    Console.CursorTop = Y;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{vertical}{fullBlock}{fullBlock}{vertical}");
                    break;
                }

            }
            }
        }

    }





