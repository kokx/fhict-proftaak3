using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    class Simulator
    {

        protected int ticks;

        public event EventHandler preSimulate;
        public event EventHandler postSimulate;

        public Simulator()
        {
            ticks = 0;
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