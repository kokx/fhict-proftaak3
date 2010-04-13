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
        private int ticksGroen;
        private int firstTick;
        private int wachtrij1;
        private int wachtrij2;
        private int zebrapad1;
        private int zebrapad2;
        private int ronde = 0;
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
            // elke ronde heeft 2 wachtrijen en 2 zebrapaden
            switch (ronde)
            {
                case 1:
                    wachtrij1 = 0;
                    wachtrij2 = 2;
                    zebrapad1 = 5;
                    zebrapad2 = 7;
                    break;

                case 2:
                    wachtrij1 = 1;
                    wachtrij2 = 3;
                    zebrapad1 = 4;
                    zebrapad2 = 6;
                    break;
            }

            // aantal groen tikken worden bepaalt door het gemiddelde aantal auto's dat voor een groen 
            // ligt staat
            ticksGroen = kruispunt.Wachtrijen[wachtrij1].Autos.Count +
                kruispunt.Wachtrijen[wachtrij2].Autos.Count / 2;

            // als aantal groen tikke groter zijn als 0 wordt onderstaande code uitgevoerd 
            // zo niet gaat deze naar het einde van de ronde
            if (ticksGroen < 0)
            {               
                // hier worden de stoplichten van een ronde voor een bepaalt aantal tikken groen
                firstTick = ticks;

                while (ticks <= firstTick + ticksGroen)
                {
                    if (ticks < firstTick + ticksGroen)
                    {
                        kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN;
                        kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;
                        
                        if (kruispunt.Wachtrijen[zebrapad1].Autos.Count > 0)
                        {
                            kruispunt.Wachtrijen[zebrapad1].Light = Light.GREEN;                          
                        }
                        if (kruispunt.Wachtrijen[zebrapad2].Autos.Count > 0)
                        {
                            kruispunt.Wachtrijen[zebrapad2].Light = Light.GREEN;
                        }
                    }

                    else
                    {
                        kruispunt.Wachtrijen[wachtrij1].Light = Light.ORANGE;
                        kruispunt.Wachtrijen[wachtrij2].Light = Light.ORANGE;

                        if (kruispunt.Wachtrijen[zebrapad1].Autos.Count > 0)
                        {
                            kruispunt.Wachtrijen[zebrapad1].Light = Light.RED;
                        }
                        if (kruispunt.Wachtrijen[zebrapad2].Autos.Count > 0)
                        {
                            kruispunt.Wachtrijen[zebrapad2].Light = Light.RED;
                        }
                    }
                }
                kruispunt.Wachtrijen[wachtrij1].Light = Light.RED;
                kruispunt.Wachtrijen[wachtrij2].Light = Light.RED;
            }

            // einde van de ronde
            if (ronde < 2)
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
