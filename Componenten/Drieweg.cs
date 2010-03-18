using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public class Drieweg : IKruispunt
    {
        protected KruispuntWachtrij[] wachtrijen;

        protected IKruispunt[] kruispunten;

        public Drieweg()
        {
            kruispunten = new IKruispunt[3];
            wachtrijen = new KruispuntWachtrij[6];
        }

        public void addAuto(Auto auto, IKruispunt afkomst, IKruispunt richting)
        {
            foreach (KruispuntWachtrij wachtrij in wachtrijen) {
                if ((wachtrij.Afkomst == afkomst) && (wachtrij.Richting == richting)) {
                    wachtrij.Add(auto);
                }
            }
        }

        public void removeAuto(Auto auto)
        {
            foreach (KruispuntWachtrij wachtrij in wachtrijen) {
                if (wachtrij.Remove(auto)) {
                    return;
                }
            }
        }

        public void addKruispunt(IKruispunt kruispunt, int pos)
        {
            kruispunten[pos] = kruispunt;

            for (int i = 0; i < kruispunten.Length; i++) {
                if (i != pos) {
                    // *2 is NOT something magic and copy-able
                    // it is because we have 2 directions in this type of junction
                    // for every incoming road
                    wachtrijen[pos * 2] = new KruispuntWachtrij(kruispunt, kruispunten[i]);
                }
            }
        }
    }
}
