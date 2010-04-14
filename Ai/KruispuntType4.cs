using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3.Ai
{
    [Serializable]
    public class KruispuntType4 : IKruispuntType
    {
        private int ticks;
        private Simulator simulator;
        IKruispunt kruispunt;
        private int hoogste;

        public KruispuntType4(IKruispunt kruispunt, Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = this.simulator.Ticks;
            this.kruispunt = kruispunt;
        }

        // als er op de knop wordt gedrukt voor een zebrapad word de wachtrij op 1 gezet. 
        public void stopLichtRegeling()
        {
            if (((simulator.Ticks % 7) == 0) || ((simulator.Ticks % 7) == 5)) {
                Light light;

                if ((simulator.Ticks % 7) == 0) {
                    light = Light.GREEN;
                    for (int i = 0; i < kruispunt.Wachtrijen.Length; i++) {
                        if (kruispunt.Wachtrijen[i].Count > kruispunt.Wachtrijen[hoogste].Count) {
                            hoogste = i;
                        }
                    }
                } else {
                    light = Light.ORANGE;
                }



                foreach (KruispuntWachtrij wachtrij in kruispunt.Wachtrijen) {
                    wachtrij.Light = Light.RED;
                }

                kruispunt.Wachtrijen[hoogste].Light = light;
            }
        }
    }
}
