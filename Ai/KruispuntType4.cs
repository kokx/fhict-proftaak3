using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3.Ai
{
    public class KruispuntType4 : IKruispuntType
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

        public KruispuntType4(IKruispunt kruispunt, Simulator simulator)
        {
            this.simulator = simulator;
            this.ticks = this.simulator.Ticks;
            this.kruispunt = kruispunt;
        }

        public void stopLichtRegeling(bool zebrapad)
        {
            // als aantal groen tikke groter zijn als 0 wordt onderstaande code uitgevoerd 
            // zo niet gaat deze naar het einde van de ronde
            if (ticksGroen < 0)
            {
                // ronde 0 heeft 2 wachtrijen en 2 zebrapaden
                // ronde 1 heeft 1 wachtrij en 1 zebrapad
                switch (ronde)
                {
                    case 0:
                        wachtrij1 = 0;
                        wachtrij2 = 1;
                        zebrapad1 = 0;
                        zebrapad2 = 1;
                        break;
                    case 1:
                        wachtrij1 = 2;
                        wachtrij2 = 2;
                        zebrapad1 = 2;
                        zebrapad2 = 2;
                        break;
                }
            }

            // aantal groen tikken worden bepaalt door het gemiddelde aantal auto's dat voor een groen 
            // ligt staat
            ticksGroen = kruispunt.Wachtrijen[wachtrij1].Autos.Count +
                kruispunt.Wachtrijen[wachtrij2].Autos.Count / 2;

            while (ticks <= firstTick + ticksGroen)
            {
                if (ticks < firstTick + ticksGroen)
                {
                    kruispunt.Wachtrijen[wachtrij1].Light = Light.GREEN;
                    kruispunt.Wachtrijen[wachtrij2].Light = Light.GREEN;

                    if (zebrapad)
                    {
                        kruispunt.Wachtrijen[zebrapad1].Light = Light.GREEN;
                        kruispunt.Wachtrijen[zebrapad2].Light = Light.GREEN;
                    }
                }

                else
                {
                    kruispunt.Wachtrijen[wachtrij1].Light = Light.ORANGE;
                    kruispunt.Wachtrijen[wachtrij2].Light = Light.ORANGE;

                    if (zebrapad)
                    {
                        kruispunt.Wachtrijen[zebrapad1].Light = Light.RED;
                        kruispunt.Wachtrijen[zebrapad2].Light = Light.RED;
                    }
                }
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
