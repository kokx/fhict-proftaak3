using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public class Vierweg
    {
        protected KruispuntWachtrij[] wachtrijen;

        protected IKruispunt[] kruispunten;

        public Vierweg()
        {
            kruispunten = new IKruispunt[4];
            wachtrijen = new KruispuntWachtrij[12];
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
                    // *3 is NOT something magic and copy-able
                    // it is because we have 3 directions in this type of junction
                    // for every incoming road
                    wachtrijen[pos * 3] = new KruispuntWachtrij(kruispunt, kruispunten[i]);
                }
            }
        }
    }
}
