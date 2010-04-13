using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3.Ai
{
    [Serializable]
    public class KruispuntType3 : IKruispuntType
    {
        private int ticks;
        private Simulator simulator;
        IKruispunt kruispunt;

        public KruispuntType3(IKruispunt kruispunt, Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = this.simulator.Ticks;
            this.kruispunt = kruispunt;
        }

        // als er op de knop wordt gedrukt voor een zebrapad word de wachtrij op 1 gezet. 
        public void stopLichtRegeling()
        {
            if ((simulator.Ticks % 5) == 0) {
                int hoogste = 0;

                for (int i = 0; i < kruispunt.Wachtrijen.Length; i++) {
                    if (kruispunt.Wachtrijen[i].Count > kruispunt.Wachtrijen[hoogste].Count) {
                        hoogste = i;
                    }
                }


                foreach (KruispuntWachtrij wachtrij in kruispunt.Wachtrijen) {
                    wachtrij.Light = Light.RED;
                }

                kruispunt.Wachtrijen[hoogste].Light = Light.GREEN;
            }
        }
    }
}
