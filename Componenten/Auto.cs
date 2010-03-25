using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public class Auto
    {
        private Random random;

        public Auto()
        {
            random = new Random();
        }

        public Direction kiesRoute(Direction[] directions)
        {
            return directions[random.Next(directions.Length)];
        }
    }
}
