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

        public void stopLichtRegeling(int ticksGroen)
        {
            // onder staande code wordt uitgevoerd als groentikken voor een ronde groter zijn als 0
            // zo niet gaat deze naar het einde van de ronde
            if (ticksGroen > 0)
            {

            //elke ronden heeft 2 wachtrijen
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

                    // zebra pad1
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

                    // zebra pad2
                    else if (wachtrij2 == 7)
                    {
                        if (kruispunt.Wachtrijen[4].Autos.Count > kruispunt.Wachtrijen[0].Autos.Count)
                        { wachtrij1 = 4; }

                        else
                        { wachtrij1 = 0; }
                    }
                }

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
                        if (wachtrij1 = 6)
                        {
                            kruispunt.Wachtrijen[wachtrij1].Light = Light.RED;
                        }

                        if (wachtrij2 = 7)
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
