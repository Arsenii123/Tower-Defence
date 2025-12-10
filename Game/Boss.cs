using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower.Logic;
using Tower_Defence.Menu;

namespace Tower_Defence.Game
{
    class Boss:Enemy
    {
        private int direction = 0; // начальное направление — вправо

        public Boss() // конструктор класса
        {
            x = 0; // стартовая позиция по горизонтали
            y = 2; // стартовая позиция по вертикали (обычно начало пути)
            oldX = x; // сохраняем начальные координаты как старые
            oldY = y; // сохраняем начальные координаты как старые
            health = 800;
            speed = 500;
        }
        public override void IsAttacked(int damage) // переопределяем метод получения урона
        {
            health -= damage; // уменьшаем здоровье на полученный урон
        }
        public override void ClearPrevious() // стираем предыдущее положение врага
        {
            Console.SetCursorPosition(oldX, oldY); // ставим курсор на старые координаты
            Console.ForegroundColor = ConsoleColor.Yellow; // цвет дорожки (желтый)
            Console.Write("█"); // рисуем блок дорожки на месте, где был враг
            Console.ResetColor(); // сбрасываем цвет
        }
        public override void Draw() // отрисовываем врага в новой позиции
        {
            Console.SetCursorPosition(x, y); // перемещаем курсор в текущие координаты
            Console.ForegroundColor = ConsoleColor.Red; // цвет врага — красный
            Console.Write("#"); // рисуем точку как изображение врага
            Console.ResetColor(); // сбрасываем цвет
        }
        public override void IsMoving(Main map, List<Tower>  t) // основной метод движения врага по карте
        {

            Console.CursorVisible = false; // скрываем мигающий курсор
            // рисуем врага в начальной позиции
            Draw(); // первый кадр отрисовки
            while (health > 0 && !End()) // цикл пока жив и не дошёл до конца карты
            {
                oldX = x; // запоминаем текущие координаты как старые
                oldY = y; // запоминаем текущие координаты как старые
                bool moved = false; // флаг, удалось ли сдвинуться
                                    // сначала пытаемся идти в текущем направлении




                if (health == 0)
                {
                    Console.SetCursorPosition(x, y); // перемещаем курсор в текущие координаты
                    Console.ForegroundColor = ConsoleColor.Yellow; // цвет дорожки (желтый)
                    Console.Write("█"); // рисуем блок дорожки на месте, где был враг
                    Console.ResetColor(); // сбрасываем цвет
                    break;
                }



                if (direction == 0 && x < 50 && map.IsPath(y, x + 1)) // вправо
                {
                    x++; // двигаемся вправо
                    moved = true; // отметили успешное движение
                }
                else if (direction == 1 && y < 21 && map.IsPath(y + 1, x)) // вниз
                {
                    y++; // двигаемся вниз
                    moved = true; // отметили успешное движение
                }
                else if (direction == 2 && x > 0 && map.IsPath(y, x - 1)) // влево
                {
                    x--; // двигаемся влево
                    moved = true; // отметили успешное движение
                }
                else if (direction == 3 && y > 0 && map.IsPath(y - 1, x)) // вверх
                {
                    y--; // двигаемся вверх
                    moved = true; // отметили успешное движение
                }

                else
                {

                    // если вперёд нельзя — ищем поворот по приоритету
                    // приоритет: право → вниз → лево → вверх
                    if (direction == 1 || direction == 3)
                    {
                        if (x < 50 && map.IsPath(y, x + 1)) // пробуем повернуть направо
                        {
                            x++; // двигаемся вправо
                            direction = 0; // обновляем направление
                            moved = true; // отметили движение
                        }
                        else
                        {
                            x--; // двигаемся влево
                            direction = 2; // обновляем направление
                            moved = true; // отметили движение
                        }
                    }



                    else
                    {
                        if (y < 21 && map.IsPath(y + 1, x)) // пробуем вниз
                        {
                            y++; // двигаемся вниз
                            direction = 1; // обновляем направление
                            moved = true; // отметили движение
                        }
                        else
                        {
                            y--; // двигаемся вверх
                            direction = 3; // обновляем направление
                            moved = true; // отметили движение
                        }
                    }



                }






                if (moved) // если враг сдвинулся
                {
                    ClearPrevious(); // стираем старое положение
                    Draw(); // рисуем в новой позиции
                    // обновляем направление на основе реального перемещения
                    if (x > oldX) direction = 0; // двигались вправо
                    if (y > oldY) direction = 1; // двигались вниз
                    if (x < oldX) direction = 2; // двигались влево
                    if (y < oldY) direction = 3; // двигались вверх
                }
                Thread.Sleep(speed); // задержка для контроля скорости
            }
            // если враг дошёл до конца живым — убираем его с экрана
            if (health > 0)
            {
                ClearPrevious(); // стираем последнего положения
            }
            Console.CursorVisible = true; // возвращаем видимость курсора

        }
        public override void Up()
        {
            health += 25;
            speed += 50;
        }
    }

}
