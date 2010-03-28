using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public class Auto
    {
        private Random random;

        protected Direction richting;

        public Direction Richting
        {
            get
            {
                return richting;
            }
        }

        public Auto()
        {
            random = new Random();
        }

        public Auto(Random random)
        {
            this.random = random;
        }

        public void kiesRichting(Direction[] directions)
        {
            richting = directions[random.Next(directions.Length)];
        }
    }
}
