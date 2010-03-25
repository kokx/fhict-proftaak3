using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten.Kruispunten
{
    class Type4 : Drieweg
    {

        public Type4()
        {
            wachtrijen = new KruispuntWachtrij[3];
        }

        public override KruispuntWachtrij getWachtrij(Direction afkomst, Direction richting)
        {
            Direction[] afkomstArray = new Direction[1];
            afkomstArray[0] = afkomst;
            return new KruispuntWachtrij(afkomstArray, richting, this);
        }
    }
}