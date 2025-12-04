using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Threading;
using System.Collections.Generic;
using Tower_Defence.Game;
using Tower_Defence.Menu;

namespace Tower_Defence.Engine
{
    class GameEngine
    {
        private const int TARGET_FPS = 30;                    // бажано 30 кадрів/сек
        private const int FRAME_TIME_MS = 1000 / TARGET_FPS;  // ≈33 мс на кадр

        private bool _running = true;
        private List<Enemy> _enemies = new List<Enemy>();
        private Main _map;

        public void Run(int X,int Y)
        {
            Console.CursorVisible = false;
            _map = new Main(); // твоя карта

            // додаємо тестового ворога
            _enemies.Add(new High_Speed());

            var lastFrameTime = DateTime.UtcNow;

            while (_running)
            {
                var now = DateTime.UtcNow;
                var deltaTime = (now - lastFrameTime).TotalSeconds; // реальний дельта-тайм
                lastFrameTime = now;
                HandleInput();
                //Update(deltaTime);
                Render( X, Y);
                // контроль FPS
                var frameDuration = (int)(DateTime.UtcNow - now).TotalMilliseconds;
                var sleepTime = FRAME_TIME_MS - frameDuration;
                if (sleepTime > 0)
                    Thread.Sleep(sleepTime);
               
            }

            Console.CursorVisible = true;
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

        private void Render(int X,int Y)
        {
            // найпростіший спосіб — очищати тільки те, що змінилось
            // або перерисовувати всю карту раз на кадр (для консолі нормально)
            _map.Print(); // ти вже маєш метод малювання карти
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(".");
            Console.ResetColor();
        }
    }
}
