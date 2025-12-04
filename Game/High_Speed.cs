using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Engine;
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
        private const int TARGET_FPS = 30;                    // бажано 30 кадрів/сек
        private const int FRAME_TIME_MS = 1000 / TARGET_FPS;  // ≈33 мс на кадр

        private bool _running = true;
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

            Console.CursorVisible = false;

            var lastFrameTime = DateTime.UtcNow;

            while (_running)
            {
                var now = DateTime.UtcNow;
                var deltaTime = (now - lastFrameTime).TotalSeconds; // реальний дельта-тайм
                lastFrameTime = now;
                HandleInput();
                for (int y = 0; y < 22; y++)
                {
                    for (int x = 0; x < 51; x++)
                    {
                        if (m.IsPath(y, x + 1) == true && oldX+1==X)
                        {
                            X = x;
                            Y = y;
                            X++;
                            Render(X, Y);
                        }
                        else if (m.IsPath(y + 1, x) == true && oldY+1==Y )
                        {
                            X = x;
                            Y = y;
                            oldX = X;
                            oldY = Y;
                            Y++;
                            Render(X, Y);
                        }
                        else if (x > 1 && y > 1)
                        {
                            if (m.IsPath(y, x - 1) == true && oldX != x - 1)
                            {
                                X = x;
                                Y = y;
                                oldX = X;
                                oldY = Y;
                                X--;
                                Render(X, Y);
                            }
                            else if (m.IsPath(y - 1, x) == true && oldY != y - 1)
                            {
                                X = x;
                                Y = y;
                                oldX = X;
                                oldY = Y;
                                Y--;
                                Render(X, Y);
                            }
                            oldX = X;
                            oldY = Y;
                        }
                      
                    }



                }
                // контроль FPS
                var frameDuration = (int)(DateTime.UtcNow - now).TotalMilliseconds;
                var sleepTime = FRAME_TIME_MS - frameDuration;
                if (sleepTime > 0)
                    Thread.Sleep(sleepTime);

                Console.CursorVisible = true;
                //Console.CursorLeft = oldX;
                //Console.CursorTop = oldY;
                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine("\u2588");
                //Console.ResetColor();



            }
        }

            
        

        private void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape) _running = false;
                // тут будуть башти, пауза тощо
            }
        }

        private void Update(double deltaTime)
        {
            //foreach (var enemy in _enemies)
            //{
            //    enemy.Update(deltaTime, _map);
            //}

            // видаляємо мертвих
            //_enemies.RemoveAll(e => e.Health <= 0);
        }

        private void Render(int X, int Y)
        {
            Main m = new Main();
            // найпростіший спосіб — очищати тільки те, що змінилось
            // або перерисовувати всю карту раз на кадр (для консолі нормально)
            m.Print(); // ти вже маєш метод малювання карти
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(".");
            Console.ResetColor();
        }


    }
}
