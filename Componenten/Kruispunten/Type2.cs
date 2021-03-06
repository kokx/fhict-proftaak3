﻿using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten.Kruispunten
{
    [Serializable]
    class Type2 : Vierweg
    {

        public Type2()
        {
            wachtrijen = new KruispuntWachtrij[6];

            // from NORTH
            wachtrijen[0] = new KruispuntWachtrij(new Direction[3] { Direction.WEST,  Direction.SOUTH, Direction.EAST }, Direction.NORTH, this);
            // from SOUTH
            wachtrijen[1] = new KruispuntWachtrij(new Direction[3] { Direction.EAST, Direction.NORTH, Direction.WEST }, Direction.SOUTH, this);
            // from EAST
            wachtrijen[2] = new KruispuntWachtrij(new Direction[1] { Direction.SOUTH },                 Direction.EAST, this);
            wachtrijen[3] = new KruispuntWachtrij(new Direction[2] { Direction.NORTH, Direction.WEST }, Direction.EAST, this);
            // from WEST
            wachtrijen[4] = new KruispuntWachtrij(new Direction[1] { Direction.NORTH },                 Direction.WEST, this);
            wachtrijen[5] = new KruispuntWachtrij(new Direction[2] { Direction.SOUTH, Direction.EAST }, Direction.WEST, this);
        }

        public override void removeKruispunten()
        {
            wachtrijen = new KruispuntWachtrij[6];

            // from NORTH
            wachtrijen[0] = new KruispuntWachtrij(new Direction[3] { Direction.WEST, Direction.SOUTH, Direction.EAST }, Direction.NORTH, this);
            // from SOUTH
            wachtrijen[1] = new KruispuntWachtrij(new Direction[3] { Direction.EAST, Direction.NORTH, Direction.WEST }, Direction.SOUTH, this);
            // from EAST
            wachtrijen[2] = new KruispuntWachtrij(new Direction[1] { Direction.SOUTH }, Direction.EAST, this);
            wachtrijen[3] = new KruispuntWachtrij(new Direction[2] { Direction.NORTH, Direction.WEST }, Direction.EAST, this);
            // from WEST
            wachtrijen[4] = new KruispuntWachtrij(new Direction[1] { Direction.NORTH }, Direction.WEST, this);
            wachtrijen[5] = new KruispuntWachtrij(new Direction[2] { Direction.SOUTH, Direction.EAST }, Direction.WEST, this);

            east = null;
            west = null;
            north = null;
            south = null;
        }
    }
}
