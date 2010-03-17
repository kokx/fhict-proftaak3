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
        /// Kruispunt van deze wachtrij
        /// </summary>
        public IKruispunt Kruispunt
        {
            get
            {
                return this.kruispunt;
            }
        }

        /// <summary>
        /// Kruispunt van deze wachtrij
        /// </summary>
        protected IKruispunt kruispunt;

        /// <summary>
        /// Auto's in deze wachtrij
        /// </summary>
        protected List<Auto> autos;


        public KruispuntWachtrij(IKruispunt kruispunt)
        {
            this.kruispunt = kruispunt;
            autos          = new List<Auto>();
        }

        public void Add(Auto auto)
        {
            autos.Add(auto);
        }

        public void Remove(Auto auto)
        {
            autos.Remove(auto);
        }
    }
}