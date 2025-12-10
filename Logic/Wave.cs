using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Logic
{
    using System.Xml.Linq;
    using Tower_Defence.Game;
    /// <summary>
    /// Клас хвилі
    /// </summary>
    ///<reamrks>
    /// Містить в собі функцію як перевантаження левелу
    ///</reamrks>
    class Wave
    {
      static protected uint stage = 0;
        public string info = $"Waves: {stage}";

        public uint Waves
        {
            get
            {
                return stage;
            }
            set
            {
                if (value > 0)
                    stage = value;
            }
        }
        public Wave()
        {
            /// <summary>
            /// Конструктор для налаштування хвилі
            /// </summary>
            stage++;
            Console.SetCursorPosition(54, 0); // перемещаем курсор в текущие координаты

            Console.WriteLine(info);



        }
        public void NextWave(int e)
        {

                if (e ==5*stage)
                {
                    stage++;
                }


           Console.SetCursorPosition(54, 0); // перемещаем курсор в текущие координаты


            info = $"Waves: {stage}";
                Console.WriteLine(info);
            }
        public bool  Is_Next_Wave(int e)
        {
            if (e == 5 * stage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void ResetWave(List<Enemy> e)
        {
            /// <summary>
            /// Функція перевантаження
            /// </summary>
            for (int i = 0; i < e.Count; i++) {
                e[i]--;
            }

            
            stage = 0;
        }


    }
}
