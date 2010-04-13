using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten.Kruispunten
{
    [Serializable]
    class Type4 : Drieweg
    {

        public Type4()
        {
            wachtrijen = new KruispuntWachtrij[3];

            // from SOUTH
            wachtrijen[0] = new KruispuntWachtrij(new Direction[2] { Direction.EAST, Direction.WEST }, Direction.SOUTH, this);
            // from EAST
            wachtrijen[1] = new KruispuntWachtrij(new Direction[2] { Direction.WEST, Direction.SOUTH }, Direction.EAST, this);
            // from WEST
            wachtrijen[2] = new KruispuntWachtrij(new Direction[2] { Direction.SOUTH, Direction.EAST  }, Direction.WEST, this);
        }

        public override void removeKruispunten()
        {
            wachtrijen = new KruispuntWachtrij[3];
        }
    }
}