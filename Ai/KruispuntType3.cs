using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3.Ai
{
    public class KruispuntType3 : IKruispuntType
    {
        private int ticks;
        private int firstTick;
        private int wachtrij1;
        private int wachtrij2;
        private int ronde = 0;
        private Simulator simulator;
        IKruispunt kruispunt;

        public KruispuntType3(IKruispunt kruispunt, Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = this.simulator.Ticks;
            this.kruispunt = kruispunt;
        }

        public void stopLichtRegeling(int ticksGroen)
        {
        }
    }
}
