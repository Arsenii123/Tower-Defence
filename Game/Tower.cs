using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tower_Defence.Logic;

namespace Tower_Defence.Game
{
    using System.IO;
    using System.Xml.Linq;
    using Tower_Defence.Menu;
    using static System.Net.Mime.MediaTypeNames;

    /// <summary>
    /// Абастрактний клас башні  який буде успадковуватися
    /// </summary>
    ///<reamrks>
    /// Містить в собі функції як атака та явний і неявний конструктор
    ///</reamrks>
    abstract class Tower
    {
        public delegate void MyTower();
        virtual public int Damage
        {
            get;
            set;
        }
        public static Tower operator --(Tower e)
        {
            e = null;
            return null;


        }


        virtual public void Placement()
        {
        }
        virtual public void Effect(List<Enemy> e)
        {

        }
        virtual public void Up()
        {

        }
        virtual public void Attack(List <Enemy> e)
        {

        }

        virtual public int this[Tower t]
        {
            get
            {
                return Damage;

            }
            set
            {
                t.Up();
            }
        }
        virtual   public  void Draw()
        {
           
        }



    }
}





