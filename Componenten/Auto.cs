using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public class Auto
    {
        private Random route;

        public Auto(Random route)
        {
            this.route = new Random();
        }        
                    

        public int maakRoute(int aantalWegen)
        {
            return this.route.Next(aantalWegen);

        }


    }
}
