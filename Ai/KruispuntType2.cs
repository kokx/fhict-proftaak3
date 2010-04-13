using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3.Ai
{
    public class KruispuntType2 : IKruispuntType
    {
        private int ticks;
        private int ticksGroen;
        private int firstTick;
        private int wachtrij1;
        private int wachtrij2;
        private int ronde = 0;
        private Simulator simulator;
        IKruispunt kruispunt;
        
         public KruispuntType2(IKruispunt kruispunt, Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = this.simulator.Ticks;
            this.kruispunt = kruispunt;
        }

         // als er op de knop wordt gedrukt voor een zebrapad word de wachtrij op 1 gezet. 
        public void stopLichtRegeling()
        {
            // elke ronden heeft 2 wachtrijen            
            switch (ronde)
            {
                case 0:
                    wachtrij1 = 0;
                    wachtrij2 = 1;
                    break;

                case 1:
                    wachtrij1 = 3;
                    wachtrij2 = 4;
                    break;

                case 2:
                    wachtrij1 = 2;
                    wachtrij2 = 5;
                    break;

                // zebrapaden
                case 3:
                    wachtrij1 = 6;
                    wachtrij2 = 7;
                    break;
            }

            // als er geen auto's zijn in wachtrij1 wordt een alternatieve 
            // wachtrij gekozen als daar wel auto's staan
            if (kruispunt.Wachtrijen[wachtrij1].Autos.Count == 0)
            {
                if (wachtrij1 == 0)
                {
                    if (kruispunt.Wachtrijen[4].Autos.Count > 0)
                    { wachtrij1 = 4; }
                }

                else if (wachtrij1 == 3)
                {
                    if (kruispunt.Wachtrijen[3].Autos.Count > 0)
                    { wachtrij1 = 1; }
                }

                  // als er niemand bij zebra pad1 staat wordt een andere wachtrij gekozen
                else if (wachtrij1 == 6)
                {
                    if (kruispunt.Wachtrijen[1].Autos.Count > kruispunt.Wachtrijen[3].Autos.Count)
                    { wachtrij1 = 4; }

                    else
                    { wachtrij1 = 0; }
                }
            }

           

            // als er geen auto's zijn in wachtrij2 wordt een alternatieve 
            // wachtrij gekozen als daar wel auto's staan
            if (kruispunt.Wachtrijen[wachtrij2].Autos.Count == 0)
            {
                if (wachtrij2 == 1)
                {
                    if (kruispunt.Wachtrijen[3].Autos.Count > 0)
                    { wachtrij1 = 3; }
                }

                else if (wachtrij2 == 4)
                {
                    if (kruispunt.Wachtrijen[0].Autos.Count > 0)
                    { wachtrij1 = 0; }
                }

                  // als er niemand bij zebra pad2 staat wordt een andere wachtrij gekozen
                else if (wachtrij2 == 7)
                {
                    if (kruispunt.Wachtrijen[4].Autos.Count > kruispunt.Wachtrijen[0].Autos.Count)
                    { wachtrij1 = 4; }

                    else
                    { wachtrij1 = 0; }
                }
            }
           

            // aantal groen tikken worden bepaalt door het gemiddelde aantal auto's dat voor een groen 
            // ligt staat alleen de ronde van de zebrapaden heeft een vaste waarde 
            if (ronde == 3)
            {
                if (kruispunt.Wachtrijen[6].Autos.Count > 0 || kruispunt.Wachtrijen[7].Autos.Count > 0 )
                { ticksGroen = 10; }

                else
                { ticksGroen = 0; }
            }

            else
            {
                ticksGroen = kruispunt.Wachtrijen[wachtrij1].Autos.Count +
                kruispunt.Wachtrijen[wachtrij2].Autos.Count / 2;
            }

            // onder staande code wordt uitgevoerd als groentikken voor een ronde groter zijn als 0
            // zo niet gaat deze naar het einde van de ronde
            if (ticksGroen > 0)              
            {
                // hier worden de stoplichten van een ronde voor een bepaalt aantal tikken groen
                firstTick = ticks;

                while (ticks <= firstTick + ticksGroen)
                {
                    if (ticks < firstTick + ticksGroen)
                    {
                        kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN;
                        kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;
                    }
                    else
                    {
                        if (wachtrij1 == 6)
                        {
                            kruispunt.Wachtrijen[wachtrij1].Light = Light.RED;
                        }

                        if (wachtrij2 == 7)
                        {
                            kruispunt.Wachtrijen[wachtrij2].Light = Light.RED;
                        }

                        else
                        {
                            kruispunt.Wachtrijen[wachtrij1].Light = Light.ORANGE;
                            kruispunt.Wachtrijen[wachtrij2].Light = Light.ORANGE;
                        }
                    }
                }
                kruispunt.Wachtrijen[wachtrij1].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij2].Light = Light.RED;
            }

            // het einde van de ronde
            if (ronde < 4)
            {
                ronde++;
            }
            else
            {
                ronde = 0;
            }
        }

    }
}
