namespace Tower_Defence
{
    using Tower.Logic;
    using Tower_Defence.Engine;
    using Tower_Defence.Game;
    using Tower_Defence.Logic;
    using Tower_Defence.Menu;

    internal class Program
        {
            static void Main(string[] args)
            {
              int enemies = 0;
             List<Enemy> e = new List<Enemy>();
             List<Tower> simple=new List<Tower>();
              Level l = new Level();
              Main  m = new Main();
              Wave w = new Wave();
              m.Print();

             while (true)
             {
                e.Add(new High_health());
                e[enemies].MakeMove += e[enemies].MakeMove += e[enemies].IsMoving;
                e[enemies].StartEvent(m, simple);

                if (e[enemies].End()==true)
                {
                    break;
                }
                enemies++;

            }
              //w.AllWave(enemies);
              l.LevelUp();


        }
        }
    

}
