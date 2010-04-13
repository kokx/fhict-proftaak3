using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3.Ai
{
    class KruispuntType1 : IKruispuntType
    {
        private int ticks;
        private Simulator simulator;
        IKruispunt kruispunt;
        
       

        public KruispuntType1(IKruispunt kruispunt, Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = this.simulator.Ticks;
            this.kruispunt = kruispunt;
        }

        

        public void stopLichtRegeling()
        {
            if ((simulator.Ticks % 5) == 0) {
                int hoogste = 0;
                int second = 0;

                for (int i = 0; i < kruispunt.Wachtrijen.Length; i++) {
                    if (kruispunt.Wachtrijen[i].Count > kruispunt.Wachtrijen[hoogste].Count) {
                        hoogste = i;
                    }
                }

                if (hoogste % 2 == 0) {
                    second = hoogste + 1;
                } else {
                    second = hoogste - 1;
                }


                foreach (KruispuntWachtrij wachtrij in kruispunt.Wachtrijen) {
                    wachtrij.Light = Light.RED;
                }

                kruispunt.Wachtrijen[hoogste].Light = Light.GREEN;
                kruispunt.Wachtrijen[second].Light = Light.GREEN;
            }
        }            

    }
}
