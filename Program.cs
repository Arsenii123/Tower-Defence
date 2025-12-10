namespace Tower_Defence
{
    using Tower_Defence.Engine;
    using Tower_Defence.Game;
    using Tower_Defence.Logic;
    using Tower_Defence.Menu;

    internal class Program
    {
        // Эти три переменные — общие для всей игры
        static List<Enemy> enemies = new List<Enemy>();
        static List<Tower> towers = new List<Tower>();
        static Main map = new Main();   // твоя карта

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            map.Print();                    // рисуем карту один раз в начале

            SpawnWave(5);                   // первая волна

            // ГЛАВНЫЙ ИГРОВОЙ ЦИКЛ — ВСЁ ПРОИСХОДИТ ЗДЕСЬ
            while (true)
            {
                HandleInput();       // нажал D1/D2/D3 → ставим башню
                UpdateTowers();      // башни стреляют
                CheckWave();         // если все враги умерли/дошли — новая волна

                Thread.Sleep(50);    // чтобы процессор не горел
            }
        }

        // Спавн волны врагов
        static void SpawnWave(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var enemy = new High_health();       // или High_health — как у тебя называется
                enemies.Add(enemy);

                // Каждый враг идёт в своём потоке
                Task.Run(() => enemy.IsMoving(map, towers));

                Thread.Sleep(1000); // пауза между врагами (1 секунда)
            }
        }

        // Обработка нажатий клавиш (покупка башен)
        static void HandleInput()
        {
            if (!Console.KeyAvailable) return;

            var key = Console.ReadKey(true).Key;

            Tower newTower = key switch
            {
                ConsoleKey.D1 => new Archer(),
                ConsoleKey.D2 => new Fire_wizzard(),
                ConsoleKey.D3 => new Ice_wizzard(),
                _ => null
            };

            if (newTower != null)
            {
                towers.Add(newTower);
                newTower.Placement();   // игрок двигает прицел и жмёт B

                // Перерисовываем ВСЁ после установки башни
                RedrawAll();
            }
        }

        // Атака всех башен
        static void UpdateTowers()
        {
            foreach (var tower in towers)
            {
                tower.Attack(enemies);
            }
        }

        // Проверка: кончилась ли волна?
        static void CheckWave()
        {
            if (enemies.All(e => e.health <= 0 || e.End()))
            {
                // Убираем мёртвых и дошедших
                RemoveDeadEnemies();

                if (enemies.Count == 0)
                {
                    Thread.Sleep(2000);     // пауза перед новой волной
                    SpawnWave(7);           // следующая волна пожёстче
                }
            }
        }

        // Удаляем мёртвых врагов
        static void RemoveDeadEnemies()
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].health <= 0 || enemies[i].End())
                {
                    enemies[i].ClearPrevious();  // стираем с карты
                    enemies.RemoveAt(i);
                }
            }
        }

        // Перерисовка всей карты + враги + башни (вызываем после установки башни)
        static void RedrawAll()
        {
            Console.Clear();
            map.Print();

            // Рисуем всех живых врагов
            foreach (var enemy in enemies)
            {
                if (enemy.health > 0 && !enemy.End())
                {
                    enemy.Draw();
                }
            }

            // Рисуем все башни
            foreach (var tower in towers)
            {
                tower.Draw();
            }
        }
    }
}




