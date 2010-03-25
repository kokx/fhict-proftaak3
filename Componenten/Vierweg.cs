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


        public void addAuto(Auto auto, IKruispunt richting)
        {
            foreach (KruispuntWachtrij wachtrij in wachtrijen) {
                if (wachtrij.Richting == richting) {
                    wachtrij.Add(auto);
                }
            }
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
