using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence.Logic
{
    using Tower_Defence.Game;
    class Wave:Enemy
    {
        uint stage = 0;
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
            stage++;
            this.health = +15;
        }
        public void ResetWave()
        {
            health = 0;
            speed = 0;
            stage = 0;
        }


    }
}
