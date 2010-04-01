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
        private int firstTick;
        private int lastTick;
        private int wachtrij1;
        private int wachtrij2;
        private Simulator simulator;
        IKruispunt kruispunt;
       

        public KruispuntType1(IKruispunt kruispunt, Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = this.simulator.Ticks;
            this.kruispunt = kruispunt;
        }

        public void stopLichtRegeling(int ticksGroen)
        {
            firstTick = ticks;
            while (ticks <= firstTick + ticksGroen)
            {
                if (ticks < firstTick + ticksGroen)
                {
                    kruispunt.Wachtrijen[wachtrij1--].Light = Light.RED;
                    kruispunt.Wachtrijen[wachtrij2--].Light = Light.RED;
                    kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN;
                    kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;

                }
                else
                {
                    kruispunt.Wachtrijen[wachtrij1].Light = Light.ORANGE;
                    kruispunt.Wachtrijen[wachtrij2].Light = Light.ORANGE;
                }
            }


            if (kruispuntWachtrij < 7)
            {
                kruispuntWachtrij = 0;
            }

            else
            {
                kruispuntWachtrij++;
            }
             
        }
            

    }
}
