using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Game
{
    internal class Archer : Tower
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int damage = 15;

        public override int Damage => damage;

        public override void Placement()
        {
            int posX = 20;  // стартовая позиция прицела
            int posY = 10;
            int oldX = posX;
            int oldY = posY;

            Console.CursorVisible = false;

            while (true)
            {
                // Стираем старый прицел
                Console.SetCursorPosition(oldX, oldY);
                Console.Write(" ");

                // Ждём нажатия клавиши
                var key = Console.ReadKey(true).Key;

                // Запоминаем старое положение перед движением
                oldX = posX;
                oldY = posY;

                // Двигаем прицел стрелками
                switch (key)
                {
                    case ConsoleKey.LeftArrow: posX -= 5; break;
                    case ConsoleKey.RightArrow: posX += 5; break;
                    case ConsoleKey.UpArrow: posY -= 1; break;
                    case ConsoleKey.DownArrow: posY += 1; break;

                    // ВОТ ТУТ — СТАВИМ БАШНЮ!
                    case ConsoleKey.B:
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        this.X = posX;
                        this.Y = posY;
                        Draw();                     // рисуем башню сразу
                        Console.CursorVisible = true;
                        return;                     // выходим — башня поставлена!
                }

                // Рисуем новый прицел
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("✛");  // красивый прицел
                Console.ResetColor();
            }
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("│██│");
            Console.ResetColor();
        }

        public override void Attack(List<Enemy> enemies)
        {
            var target = enemies.FirstOrDefault(e => e.health > 0 && !e.End());
            if (target != null)
                target.IsAttacked(damage);
        }

        public override void Up()
        {
            damage += 10;
        }
    }
}

