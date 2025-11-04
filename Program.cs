namespace Tower_Defence
{
    using Tower.Logic;
    using Tower_Defence.Game;
    using Tower_Defence.Logic;
    using Tower_Defence.Menu;
    internal class Program
        {
            static void Main(string[] args)
            {
              Enemy e = new Enemy();
              Tower simple = new Tower();
              Level l = new Level();
              Upgrade next = new Upgrade();
              Main  m = new Main();
              Wave w = new Wave();
               m.Print();
               l.LevelUp();
               simple.Attack(e);



        }
        }
    

}
