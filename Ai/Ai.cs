using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;

namespace fhict_proftaak3.Ai
{
    public class Ai
    {

        private Simulator simulator;

        public Ai(Simulator simulator)
        {
            this.simulator = simulator;

            // maak een initial state aan


            // register event handlers
            this.simulator.postSimulate += new EventHandler(simulator_postSimulate);
            this.simulator.preSimulate += new EventHandler(simulator_preSimulate);
        }

        private void checkState()
        {
            foreach (IKruispunt kruispunt in simulator.Kruispunten) {
                // we can't set anything on the injector
                if (kruispunt is Injector) {
                    continue;
                }

                // make the first light green
                kruispunt.Wachtrijen[0].Light = Light.GREEN;
            }
        }

        void simulator_preSimulate(object sender, EventArgs e)
        {
            checkState();
        }

        void simulator_postSimulate(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
