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
        private int ticksGroen;
        private int firstTick;
        private int wachtrij1 = 0;
        private int wachtrij2 = 1;
        private int wachtrij3;
        private int wachtrij4;
        private bool geenAutosBij1;
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
            ticks = simulator.Ticks / 5;

            int wachtrij1 = (ticks % 4) * 2;
            int wachtrij2 = wachtrij1 + 1;

            foreach (KruispuntWachtrij wachtrij in kruispunt.Wachtrijen) {
                wachtrij.Light = Light.RED;
            }

            kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN;
            kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;
        }            

    }
}
