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
        private int wachtrij1 = 0;
        private int wachtrij2 = 1;
        private int wactrij3;
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
            wactrij3 = wachtrij1--;
            if (wactrij3 == -1)
            {
                wactrij3 = 8;
            }

            if (ticksGroen > 0)
            {
                while (ticks <= firstTick + ticksGroen)
                {
                    if (ticks < firstTick + ticksGroen)
                    {
                        kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN;
                        kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;
                        kruispunt.Wachtrijen[wactrij3].Light = Light.GREEN;

                    }
                    else
                    {
                        kruispunt.Wachtrijen[wachtrij1].Light = Light.ORANGE;
                        kruispunt.Wachtrijen[wachtrij2].Light = Light.ORANGE;
                        kruispunt.Wachtrijen[wactrij3].Light = Light.ORANGE;
                    }
                }
                kruispunt.Wachtrijen[wachtrij1].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij2].Light = Light.RED;
                kruispunt.Wachtrijen[wactrij3].Light = Light.RED;

                if (wachtrij1 < 6 && wachtrij2 < 7)
                {
                    wachtrij1 += 2;
                    wachtrij2 += 2;
                }
                else
                {
                    wachtrij1 = 0;
                    wachtrij2 = 1;
                }
            }


             
        }
            

    }
}
