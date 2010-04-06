using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;

namespace fhict_proftaak3
{
    public class KruispuntForm : VerkeersComponentenLibrary.TFormKruispunt
    {
        public IKruispunt Kruispunt {
            get
            {
                return kruispunt;
            }
        }

        public VerkeersComponentenLibrary.TStoplichtKleur GetKleur(KruispuntWachtrij wachtrij)
        {
            switch (wachtrij.Light) {
                case Light.GREEN:
                    return VerkeersComponentenLibrary.TStoplichtKleur.skGroen;
                    break;
                case Light.ORANGE:
                    return VerkeersComponentenLibrary.TStoplichtKleur.skGeel;
                    break;
                case Light.RED:
                    return VerkeersComponentenLibrary.TStoplichtKleur.skRood;
                    break;
            }
            NoodStop();
            return VerkeersComponentenLibrary.TStoplichtKleur.skGeelKnipper;
        }

        protected IKruispunt kruispunt;

        public virtual void NieuweStatus()
        {
        }

        public virtual void NoodStop()
        {
        }
    }
}
