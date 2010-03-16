using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fhict_proftaak3.Kruispunt
{
    public interface IKruispunt
    {
        void addAuto(Auto auto, IKruispunt kruispunt);
        void removeAuto(Auto auto, IKruispunt kruispunt);

        void addKruispunt(IKruispunt kruispunt, int pos);
    }
}
