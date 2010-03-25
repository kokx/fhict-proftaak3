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
        /// Richting kruispunt van deze wachtrij
        /// </summary>
        public IKruispunt Richting
        {
            get
            {
                return this.richting;
            }
        }

        /// <summary>
        /// Richting kruispunt van deze wachtrij
        /// </summary>
        protected IKruispunt richting;

        public IKruispunt Richting
        {
            get { return richting; }
        }

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

        public KruispuntWachtrij(IKruispunt richting)
        {
            this.richting = richting;
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