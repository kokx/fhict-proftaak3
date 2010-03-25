﻿using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public abstract class Vierweg : IKruispunt
    {

        protected KruispuntWachtrij[] wachtrijen;

        public KruispuntWachtrij[] Wachtrijen
        {
            get
            {
                return wachtrijen;
            }
        }

        protected IKruispunt east;
        protected IKruispunt west;
        protected IKruispunt north;
        protected IKruispunt south;


        public void addAuto(Auto auto, Direction afkomst)
        {
            Direction[] choose = new Direction[3];

            switch (afkomst) {
                case Direction.NORTH:
                    choose[0] = Direction.SOUTH;
                    choose[1] = Direction.EAST;
                    choose[2] = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    choose[0] = Direction.NORTH;
                    choose[1] = Direction.EAST;
                    choose[2] = Direction.WEST;
                    break;
                case Direction.EAST:
                    choose[0] = Direction.NORTH;
                    choose[1] = Direction.SOUTH;
                    choose[2] = Direction.WEST;
                    break;
                case Direction.WEST:
                    choose[0] = Direction.NORTH;
                    choose[1] = Direction.SOUTH;
                    choose[2] = Direction.EAST;
                    break;
            }

            auto.kiesRichting(choose);

            getWachtrij(afkomst, auto.Richting).Add(auto);
        }

        public KruispuntWachtrij getWachtrij(Direction afkomst, Direction richting)
        {
            foreach (KruispuntWachtrij wachtrij in wachtrijen) {
                if ((wachtrij.From == afkomst) && (wachtrij.HasDirection(richting))) {
                    return wachtrij;
                }
            }

            return null;
        }

        public void addKruispunt(IKruispunt kruispunt, Direction direction)
        {
            switch (direction) {
                case Direction.EAST:
                    east = kruispunt;
                    break;
                case Direction.WEST:
                    west = kruispunt;
                    break;
                case Direction.SOUTH:
                    south = kruispunt;
                    break;
                case Direction.NORTH:
                    north = kruispunt;
                    break;
            }
        }

        public void Simulate()
        {
            foreach (KruispuntWachtrij wachtrij in wachtrijen) {
                // check de kleur van het stoplicht
            }
        }
    }
}
