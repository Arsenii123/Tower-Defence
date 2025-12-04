namespace Tower_Defence
{
    using Tower_Defence.Engine;
    using Tower_Defence.Game;
    using Tower_Defence.Logic;
    using Tower_Defence.Menu;

    internal class Program
        {
            static void Main(string[] args)
            {
              
              Enemy  e = new High_Speed();
              Tower simple = new Tower();
              Level l = new Level();
              Main  m = new Main();
              Wave w = new Wave();
              GameEngine game = new GameEngine();
            m.Print();
             e.IsMoving(m);



        }
        }
    

}
