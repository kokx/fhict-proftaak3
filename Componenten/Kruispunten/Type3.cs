using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten.Kruispunten
{
    class Type3 : Vierweg
    {

        public override KruispuntWachtrij getWachtrij(Direction afkomst, Direction richting)
        {
            Direction[] afkomstArray = new Direction[1];
            afkomstArray[0] = afkomst;
            return new KruispuntWachtrij(afkomstArray, richting, this);
        }
    }
}
