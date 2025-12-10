using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Menu;
using Tower_Defence.Engine;
using Tower.Logic;

namespace Tower_Defence.Game
{
    class High_health : Enemy
    {
        private int direction = 0;

        public High_health()
        {
            x = 0;
            y = 2;
            oldX = x;
            oldY = y;
            health = 150;    // ← теперь работает, потому что health есть в базовом классе Enemy!
            speed = 300;
        }

        public override void IsAttacked(int damage)
        {
            health -= damage;
            if (health < 0) health = 0;
        }

        public override void ClearPrevious()
        {
            Console.SetCursorPosition(oldX, oldY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("█");
            Console.ResetColor();
        }

        public override void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("●");  // чуть красивее, чем точка
            Console.ResetColor();
        }

        public override void IsMoving(Main map, List<Tower> t)
        {
            Draw();

            while (health > 0 && !End())
            {
                oldX = x;
                oldY = y;

                // ← ТУТ ВСЯ ЛОГИКА ДВИЖЕНИЯ (оставь как было, она норм) →
                bool moved = false;

                if (direction == 0 && x < 50 && map.IsPath(y, x + 1)) { x++; moved = true; }
                else if (direction == 1 && y < 21 && map.IsPath(y + 1, x)) { y++; moved = true; }
                else if (direction == 2 && x > 0 && map.IsPath(y, x - 1)) { x--; moved = true; }
                else if (direction == 3 && y > 0 && map.IsPath(y - 1, x)) { y--; moved = true; }
                else
                {
                    // повороты — оставь как было
                    if (direction == 1 || direction == 3)
                    {
                        if (x < 50 && map.IsPath(y, x + 1)) { x++; direction = 0; moved = true; }
                        else { x--; direction = 2; moved = true; }
                    }
                    else
                    {
                        if (y < 21 && map.IsPath(y + 1, x)) { y++; direction = 1; moved = true; }
                        else { y--; direction = 3; moved = true; }
                    }
                }

                if (moved)
                {
                    ClearPrevious();
                    Draw();
                    if (x > oldX) direction = 0;
                    if (y > oldY) direction = 1;
                    if (x < oldX) direction = 2;
                    if (y < oldY) direction = 3;
                }

                Thread.Sleep(speed);
            }

            ClearPrevious(); // убираем врага с карты
        }

        public override bool End()
        {
            return x == 49 && y == 5;
        }
    }
}
