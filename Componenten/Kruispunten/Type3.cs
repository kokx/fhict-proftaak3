using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten.Kruispunten
{
    [Serializable]
    class Type3 : Vierweg
    {

        public Type3()
        {
            wachtrijen = new KruispuntWachtrij[4];

            // from NORTH
            wachtrijen[0] = new KruispuntWachtrij(new Direction[3] { Direction.EAST, Direction.WEST, Direction.SOUTH  }, Direction.NORTH, this);
            // from SOUTH
            wachtrijen[1] = new KruispuntWachtrij(new Direction[3] { Direction.EAST, Direction.WEST, Direction.NORTH  }, Direction.SOUTH, this);
            // from EAST
            wachtrijen[2] = new KruispuntWachtrij(new Direction[3] { Direction.WEST, Direction.SOUTH, Direction.NORTH }, Direction.EAST, this);
            // from WEST
            wachtrijen[3] = new KruispuntWachtrij(new Direction[3] { Direction.SOUTH, Direction.EAST, Direction.NORTH }, Direction.WEST, this);
        }

        public override void removeKruispunten()
        {
            wachtrijen = new KruispuntWachtrij[4];
        }
    }
}
