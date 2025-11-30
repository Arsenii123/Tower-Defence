using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Logic
{
    using Tower_Defence.Game;
    /// <summary>
    /// Клас хвилі
    /// </summary>
    ///<reamrks>
    /// Містить в собі функцію як перевантаження левелу
    ///</reamrks>
    class Wave :High_Speed
    {
        uint stage = 0;
        int enemy_health;
        protected uint Waves
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
            health += 15;
        }
        public void ResetWave()
        {
            /// <summary>
            /// Функція перевантаження
            /// </summary>
            health = 0;
            speed = 0;
            stage = 0;
        }


    }
}
