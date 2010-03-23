using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public interface IKruispunt
    {
        void addAuto(Auto auto, IKruispunt richting);

        void addKruispunt(IKruispunt kruispunt, int pos);

        void Simulate();
    }
}
