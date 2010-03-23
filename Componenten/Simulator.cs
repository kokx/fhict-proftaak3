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

        protected IKruispunt[] kruispunten;
        public IKruispunt[] Kruispunten
        {
            get { return this.kruispunten; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Simulator(int maxKruispunten)
        {
            kruispunten = new IKruispunt[maxKruispunten];
            ticks = 0;
        }

        public void Set(IKruispunt kruispunt, int pos)
        {
            kruispunten[pos] = kruispunt;
        }

        public void simulate(int ticks)
        {
            for (int i = 0; i < ticks; i++) {
                this.simulate();
            }
        }

        public void simulate()
        {
            this.preSimulate(this, new EventArgs());

            ticks++;
            // execute one simulation round

            this.postSimulate(this, new EventArgs());
        }
    }
}