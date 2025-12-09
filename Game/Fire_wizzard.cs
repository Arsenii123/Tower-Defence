using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Game
{
    class Fire_wizzard:Tower
    {
        protected int damage;
        protected double price;
        static int X = 0;
        static int Y = 0;
        public int fire_damage;

        public override int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                Damage = value;
            }
        }
        public Fire_wizzard()
        {
            ///<example>
            ///Приклад конструктора
            ///<code>
            ///Tower e =new Tower();
            ///</code>
            ///налаштування параметрів
            ///</example>
            damage = 10;
            price = 10;
            fire_damage = 2;
        }
        public override void Placement()
        {
            char fullBlock = '█';   // Полный блок
            char vertical = '│';    // Вертикальная линия
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
                        X += 5;
                        break;
                    case ConsoleKey.LeftArrow:
                        X -= 5;
                        break;
                    case ConsoleKey.UpArrow:
                        Y -= 5;
                        break;
                    case ConsoleKey.DownArrow:
                        Y += 5;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{vertical}{fullBlock}{fullBlock}{vertical}");
                    break;
                }

            }
        }
        public override void Effect(int health)
        {
            health -= fire_damage;
        }
    }
}
