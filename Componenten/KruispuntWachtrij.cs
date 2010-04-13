using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    
    /// <summary>
    /// Status van het verkeerslicht van de wachtrij
    /// </summary>
    public enum Light
    {
        RED,
        ORANGE,
        GREEN
    }

    /// <summary>
    /// Wachtrij voor een kruispunt
    /// 
    /// TODO:
    /// - Implementeer een aantal states voor de auto's
    /// </summary>
    [Serializable]
    public class KruispuntWachtrij
    {

        /// <summary>
        /// Auto's in deze wachtrij
        /// </summary>
        protected Queue<Auto> autos;

        /// <summary>
        /// Auto's die wachten in deze wachtrij
        /// </summary>
        public Queue<Auto> Autos
        {
            get
            {
                return autos;
            }
        }

        /// <summary>
        /// Aantal auto's in de wachtrij
        /// </summary>
        public int Count
        {
            get
            {
                return autos.Count;
            }
        }

        /// <summary>
        /// Richtingen die auto's op kunnen
        /// </summary>
        protected Direction[] directions;

        /// <summary>
        /// Richtingen die auto's op kunnen
        /// </summary>
        public Direction[] Directions
        {
            get
            {
                return directions;
            }
        }

        /// <summary>
        /// Richting waar de auto's vandaan komen
        /// </summary>
        protected Direction from;

        /// <summary>
        /// Richting waar de auto's vandaan komen
        /// </summary>
        public Direction From
        {
            get
            {
                return from;
            }
        }

        /// <summary>
        /// Kruispunt van deze wachtrij
        /// </summary>
        protected IKruispunt kruispunt;

        /// <summary>
        /// Stoplicht van deze wachtrij
        /// </summary>
        protected Light light;

        /// <summary>
        /// Stoplicht van deze wachtrij
        /// </summary>
        public Light Light
        {
            get
            {
                return light;
            }
            set
            {
                if ((value == Light.GREEN) && (light != Light.RED)) {
                    return;
                }

                this.light = value;
            }
        }


        public KruispuntWachtrij(Direction[] directions, Direction from, IKruispunt kruispunt)
        {
            this.directions = directions;
            this.from = from;
            this.kruispunt = kruispunt;

            autos = new Queue<Auto>();
        }

        public bool HasDirection(Direction direction)
        {
            foreach (Direction direct in directions) {
                if (direction == direct) {
                    return true;
                }
            }
            return false;
        }

        public void Add(Auto auto)
        {
            autos.Enqueue(auto);
        }

        public Auto Pop()
        {
            if (autos.Count > 0) {
                return autos.Dequeue();
            }
            return null;
        }
    }
}