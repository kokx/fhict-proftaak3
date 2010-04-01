using System;
using System.Collections.Generic;
using System.Text;
using fhict_proftaak3.Componenten;

namespace fhict_proftaak3
{
    public abstract class KruispuntForm : VerkeersComponentenLibrary.TFormKruispunt
    {
        public IKruispunt Kruispunt {
            get
            {
                return kruispunt;
            }
        }

        protected IKruispunt kruispunt;

        public abstract void NieuweStatus();

        public abstract void NoodStop();
    }
}
