using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    /// <summary>
    /// Injector implementatie van een kruispunt
    /// </summary>
    public class Injector : IKruispunt
    {

        /// <summary>
        /// Cars that are in this injector
        /// </summary>
        protected List<Auto> autos;

        /// <summary>
        /// Connecties met kruispunten
        /// </summary>
        protected SortedList<Direction, IKruispunt> kruispunten;


        public Injector(List<Auto> autos)
        {
            this.autos = autos;
            kruispunten = new SortedList<Direction,IKruispunt>();
        }

        public Injector()
        {
            autos = new List<Auto>();
        }

        public void addAuto(Auto auto, Direction afkomst)
        {
            autos.Add(auto);
        }

        public void addKruispunt(IKruispunt kruispunt, Direction direction)
        {
            kruispunten.Add(direction, kruispunt);
        }

        public KruispuntWachtrij getWachtrij(Direction afkomst, Direction richting)
        {
            return null;
        }

        public void Simulate()
        {
            // inject autos in de kruispunten
        }
    }
}
