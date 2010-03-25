using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public interface IKruispunt
    {
        void addAuto(Auto auto, Direction afkomst);

        void addKruispunt(IKruispunt kruispunt, Direction direction);

        KruispuntWachtrij getWachtrij(Direction afkomst, Direction richting);

        void Simulate();
    }
}
