using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public interface IKruispunt
    {
        void addAuto(Auto auto, IKruispunt afkomst);
        void removeAuto(Auto auto, IKruispunt afkomst);

        void addKruispunt(IKruispunt kruispunt, int pos);
    }
}
