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
            // onderstaande code wordt uitgevoerd als aantal groentikken groter zijn als 0
            // zo niet gaat deze naar het einde van de ronde
            if (ticksGroen > 0)
            {

            firstTick = ticks;
            wachtrij3 = wachtrij1--;
            if (wachtrij3 == -1)
            {
                wachtrij3 = 8;
            }

            // Als er bij het eerst wachtrij geen auto's zijn wordt een alternatieve wachtrij gekozen 
            // als daar wel auto's staan.
            if (kruispunt.Wachtrijen[wachtrij1].Autos.Count == 0)
            {                
                if (wachtrij1 == 0)
                {                     
                    if (kruispunt.Wachtrijen[5].Autos.Count > 0)
                    {
                        wachtrij4 = 5;
                        geenAutosBij1 = true;
                    }
                }

                if (wachtrij1 == 2)
                {
                    if (kruispunt.Wachtrijen[1].Autos.Count > 0)
                    {
                        wachtrij4 = 1;
                        geenAutosBij1 = true;
                    }
                }

                if (wachtrij1 == 4)
                {
                    if (kruispunt.Wachtrijen[1].Autos.Count > 0)
                    {
                        wachtrij4 = 1;
                        geenAutosBij1 = true;
                    }
                }

                if (wachtrij1 == 6)
                {
                    if (kruispunt.Wachtrijen[5].Autos.Count > 0)
                    {
                        wachtrij4 = 5;
                        geenAutosBij1 = true;
                    }
                }
            }
            else
            {
                geenAutosBij1 = false;
            }
           
                while (ticks <= firstTick + ticksGroen)
                {
                    if (ticks < firstTick + ticksGroen)
                    {
                        if (geenAutosBij1)
                        { kruispunt.Wachtrijen[wachtrij4].Light = Light.GREEN; }
                        else
                        { kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN; }

                        kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;
                        kruispunt.Wachtrijen[wachtrij3].Light = Light.GREEN;

                    }
                    else
                    {
                        if (geenAutosBij1)
                        { kruispunt.Wachtrijen[wachtrij4].Light = Light.ORANGE; }
                        else
                        { kruispunt.Wachtrijen[wachtrij1].Light = Light.ORANGE; }

                        kruispunt.Wachtrijen[wachtrij2].Light = Light.ORANGE;
                        kruispunt.Wachtrijen[wachtrij3].Light = Light.ORANGE;
                    }
                }
                kruispunt.Wachtrijen[wachtrij1].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij2].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij3].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij4].Light = Light.RED;                               
            }

            // einde van de ronde
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
