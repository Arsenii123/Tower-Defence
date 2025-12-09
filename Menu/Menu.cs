using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Game;

namespace Tower_Defence.Menu
{
    /// <summary>
    /// Клас меню
    /// </summary>
    ///<reamrks>
    /// Містить в собі функції для меню та показ карти
    ///</reamrks>
    class Main
    {
         int[,] map = new int[22, 51];
        
        public void Print()
        {
            ///<example>
            ///Приклад на показ меню, а потім карти
            ///</example>
            Console.CursorLeft = 50;
            Console.CursorTop = 3;
            Console.WriteLine("Tower Defence");
            Thread.Sleep(5000);
            Console.Clear();
            string path = "\u2588";
            string wall = "\u2588";
            string block= "\u2588";
            string stone = "\u25A0";
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 22; y++)
                {
                    if (y == 2 && x >= 0 && x <= 15 || x == 15 && y >= 2 && y <= 9 || y == 9 && x >= 2 && x <= 15 || x == 2 && y >= 9 && y < 20 || y==20 && x>=2 && x<=30 || x==30 && y>=5 && y<=20 || y==5 && x>=30 && x<=50)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.WriteLine(path);
                        Console.ResetColor();
                    }
                    else if(y==1 && x>=0 && x<=15 || y==3 && x>=0 && x<=14 || x==14 && y>=3 && y<9 || x==16 && y>=1 && y<=9 || y==8 && x>=1 && x<=14 || y==10 && x>=3 && x<=15 || x==1 && y>=8 && y<=21 || x==3 && y>=11 && y<19 || y==21 &&  x>=1 && x<=30 || y==19 && x>=1 && x<=30 || x==31 && y>=5 && y<=20 || x==29 && y>=5 && y<=20|| y==6 && x>=30 && x<=50 || y==4 && x >= 30 && x <= 50  ){
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.WriteLine(wall);
                        Console.ResetColor();
                    }
                    else
                    {
                        Random rnd = new Random();
                        int color = rnd.Next(1, 4);
                        string brush = "";
                        if (color == 1 || color==2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            brush = block;
                        }
                        else
                        {
                            int dark = rnd.Next(1, 10);
                            if (dark == 1 || dark == 2 || dark==3 || dark==4 || dark==6 || dark==7 || dark==8)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                brush = block;
                                map.SetValue(3, y, x);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                brush = stone;
                                map.SetValue(4, y, x);

                            }
                        }
                        Console.CursorLeft = x;
                        Console.CursorTop = y;
                        Console.WriteLine(brush);
                        Console.ResetColor();
                        
                    }
                }
                Console.WriteLine();
            }
            Console.CursorTop = 25;
            Console.CursorLeft = 0;
            Console.WriteLine(" ");

        }
        public Main()
        {
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 22; y++)
                {
                    if (y == 2 && x >= 0 && x <= 15 || x == 15 && y >= 2 && y <= 9 || y == 9 && x >= 2 && x <= 15 || x == 2 && y >= 9 && y < 20 || y == 20 && x >= 2 && x <= 30 || x == 30 && y >= 5 && y <= 20 || y == 5 && x >= 30 && x <= 50)
                    {
                        map.SetValue(1, y, x);
                    }
                    else if (y == 1 && x >= 0 && x <= 15 || y == 3 && x >= 0 && x <= 14 || x == 14 && y >= 3 && y < 9 || x == 16 && y >= 1 && y <= 9 || y == 8 && x >= 1 && x <= 14 || y == 10 && x >= 3 && x <= 15 || x == 1 && y >= 8 && y <= 21 || x == 3 && y >= 11 && y < 19 || y == 21 && x >= 1 && x <= 30 || y == 19 && x >= 1 && x <= 30 || x == 31 && y >= 5 && y <= 20 || x == 29 && y >= 5 && y <= 20 || y == 6 && x >= 30 && x <= 50 || y == 4 && x >= 30 && x <= 50)
                    {
                        map.SetValue(2, y, x);
                    }
                }
            }
                        
        }
        public bool  IsPath(int y,int x)
        {
            ///<example>
            ///Якщо це дорога то буде повертатися true
            ///</example>
            if (y<22 && x <= 50)
            {
                if (map[y, x] == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


     }
              
            
}
    

    

