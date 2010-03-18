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
        /// Afkomst kruispunt van deze wachtrij
        /// </summary>
        public IKruispunt Afkomst
        {
            get
            {
                return this.Afkomst;
            }
        }

        /// <summary>
        /// Afkomst kruispunt van deze wachtrij
        /// </summary>
        protected IKruispunt afkomst;

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

        /// <summary>
        /// Auto's in deze wachtrij
        /// </summary>
        protected List<Auto> autos;


        public KruispuntWachtrij(IKruispunt afkomst, IKruispunt richting)
        {
            this.afkomst = afkomst;
            this.richting = richting;
        }

        public void Add(Auto auto)
        {
            autos.Add(auto);
        }

        public bool Remove(Auto auto)
        {
            if (autos.Contains(auto)) {
                autos.Remove(auto);
                return true;
            }
            return false;
        }
    }
}