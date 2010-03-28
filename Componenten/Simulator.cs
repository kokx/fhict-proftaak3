using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    class Simulator
    {

        protected int ticks;
        public int Ticks
        {
            get { return this.ticks; }
        }

        /// <summary>
        /// PreSimulate event hook
        /// </summary>
        public event EventHandler preSimulate;
        /// <summary>
        /// PostSimulate event hook
        /// </summary>
        public event EventHandler postSimulate;

        protected List<IKruispunt> kruispunten;
        public List<IKruispunt> Kruispunten
        {
            get { return this.kruispunten; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Simulator()
        {
            kruispunten = new List<IKruispunt>();
            ticks = 0;
        }

        public void InitMap()
        {
            // maak een map van 4 echte kruispunten, en sub-reele om het op te vullen
        }

        /// <summary>
        /// Do a number of simulation rounds
        /// </summary>
        /// <param name="ticks">the number of simulation rounds</param>
        public void Simulate(int ticks)
        {
            for (int i = 0; i < ticks; i++) {
                Simulate();
            }
        }

        /// <summary>
        /// Do one simulation round
        /// </summary>
        public void Simulate()
        {
            this.preSimulate(this, new EventArgs());

            ticks++;

            foreach (IKruispunt kruispunt in kruispunten) {
                kruispunt.Simulate();
            }

            this.postSimulate(this, new EventArgs());
        }
    }
}