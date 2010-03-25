using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten.Kruispunten
{
    class Type1 : Vierweg
    {

        public Type1()
        {
            wachtrijen = new KruispuntWachtrij[8];

            // from NORTH
            wachtrijen[0] = new KruispuntWachtrij(new Direction[1] { Direction.WEST },                  Direction.NORTH, this);
            wachtrijen[1] = new KruispuntWachtrij(new Direction[2] { Direction.SOUTH, Direction.EAST }, Direction.NORTH, this);
            // from SOUTH
            wachtrijen[2] = new KruispuntWachtrij(new Direction[1] { Direction.EAST },                  Direction.SOUTH, this);
            wachtrijen[3] = new KruispuntWachtrij(new Direction[2] { Direction.NORTH, Direction.WEST }, Direction.SOUTH, this);
            // from EAST
            wachtrijen[4] = new KruispuntWachtrij(new Direction[1] { Direction.NORTH },                 Direction.EAST, this);
            wachtrijen[5] = new KruispuntWachtrij(new Direction[2] { Direction.SOUTH, Direction.WEST }, Direction.EAST, this);
            // from WEST
            wachtrijen[6] = new KruispuntWachtrij(new Direction[1] { Direction.SOUTH },                 Direction.WEST, this);
            wachtrijen[7] = new KruispuntWachtrij(new Direction[2] { Direction.NORTH, Direction.EAST }, Direction.WEST, this);
        }
    }
}
