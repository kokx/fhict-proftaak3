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

        public void stopLichtRegeling(int ticksGroen)
        {
            firstTick = ticks;
            wachtrij3 = wachtrij1--;
            if (wachtrij3 == -1)
            {
                wachtrij3 = 8;
            }

            if (kruispunt.Wachtrijen[wachtrij1].Autos.Count = 0)
            {
                geenAutosBij1 = true;
                if (wachtrij1 = 0)
                { wachtrij4 = 5; }

                if (wachtrij1 = 2)
                { wachtrij4 = 8;}

                if (wachtrij1 = 1)
                { wachtrij4 = 1; }

                if (wachtrij1 = 7)
                { wachtrij4 = 3; }
            }

            if (ticksGroen > 0)
            {
                while (ticks <= firstTick + ticksGroen)
                {
                    if (ticks < firstTick + ticksGroen)
                    {
                        if (geenAutosBij1)
                        { kruispunt.Wachtrijen[wachtrij4].Light = Light.GREEN; }
                        else
                        { kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN; }

                        kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;
                        kruispunt.Wachtrijen[wactrij3].Light = Light.GREEN;

                    }
                    else
                    {
                        if (geenAutosBij1)
                        { kruispunt.Wachtrijen[wachtrij4].Light = Light.ORANGE; }
                        else
                        { kruispunt.Wachtrijen[wachtrij1].Light = Light.ORANGE; }

                        kruispunt.Wachtrijen[wachtrij2].Light = Light.ORANGE;
                        kruispunt.Wachtrijen[wactrij3].Light = Light.ORANGE;
                    }
                }
                kruispunt.Wachtrijen[wachtrij1].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij2].Light = Light.RED;
                kruispunt.Wachtrijen[wactrij3].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij4].Light = Light.RED;

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
