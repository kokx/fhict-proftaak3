using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3.Ai
{
    public class Ai
    {

        private Simulator simulator;
        private int ticks;
        private int firstTick;
        private List<IKruispuntType> kruispunten;

        public Ai(Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = simulator.Ticks;
            kruispunten = new List<IKruispuntType>();

            // maak een initial state aan
            foreach (IKruispunt kruispunt in this.simulator.Kruispunten)
            {
                if (kruispunt is Type1)
                {
                    kruispunten.Add(new KruispuntType1(kruispunt, simulator));
                }

                else if (kruispunt is Type2)
                {
                    kruispunten.Add(new KruispuntType2());
                }

                else if (kruispunten is Type3)
                {
                    kruispunten.Add(new KruispuntType3());
                }

                else if (kruispunten is Type4)
                {
                    kruispunten.Add(new KruispuntType4());
                }
            }


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
                    firstTick = ticks; 
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
