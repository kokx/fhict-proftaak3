using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fhict_proftaak3.Kruispunt
{
    public abstract class Drieweg : IKruispunt
    {

        public void addAuto(Auto auto, IKruispunt kruispunt);
        public void removeAuto(Auto auto, IKruispunt kruispunt);

        public void addKruispunt(IKruispunt kruispunt);
    }
}
