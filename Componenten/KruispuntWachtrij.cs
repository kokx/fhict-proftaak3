using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    /// <summary>
    /// Wachtrij voor een kruispunt
    /// 
    /// TODO:
    /// - Implementeer een aantal states voor de auto's
    /// </summary>
    public class KruispuntWachtrij
    {

        /// <summary>
        /// Auto's in deze wachtrij
        /// </summary>
        protected Queue<Auto> autos;

        public Queue<Auto> Autos
        {
            get
            {
                return autos;
            }
        }

        protected Direction[] directions;

        public Direction[] Directions
        {
            get
            {
                return directions;
            }
        }

        protected Direction from;

        public Direction From
        {
            get
            {
                return from;
            }
        }

        protected IKruispunt kruispunt;


        public KruispuntWachtrij(Direction[] directions, Direction from, IKruispunt kruispunt)
        {
            this.directions = directions;
            this.from = from;
            this.kruispunt = kruispunt;

            autos = new Queue<Auto>();
        }

        public void Add(Auto auto)
        {
            autos.Enqueue(auto);
        }

        public Auto shift()
        {
            return autos.Dequeue();
        }
    }
}