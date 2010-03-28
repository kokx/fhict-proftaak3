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

        public void addAuto(Auto auto, IKruispunt afkomst)
        {
            Direction direction;
            if (afkomst == north) {
                direction = Direction.NORTH;
            } else if (afkomst == south) {
                direction = Direction.SOUTH;
            } else if (afkomst == east) {
                direction = Direction.EAST;
            } else {
                direction = Direction.WEST;
            }

            addAuto(auto, direction);
        }

        public KruispuntWachtrij getWachtrij(Direction afkomst, Direction richting)
        {
            foreach (KruispuntWachtrij wachtrij in wachtrijen) {
                if ((null != wachtrij) && (wachtrij.From == afkomst) && (wachtrij.HasDirection(richting))) {
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
                if (null == wachtrij) {
                    continue;
                }
                switch (wachtrij.Light) {
                    case Light.GREEN:
                        // ok, great, pop the car from the Queue and let it
                        // drive through
                        Auto auto = wachtrij.Pop();

                        switch (auto.Richting) {
                            case Direction.NORTH:
                                north.addAuto(auto, Direction.SOUTH);
                                break;
                            case Direction.SOUTH:
                                north.addAuto(auto, Direction.NORTH);
                                break;
                            case Direction.EAST:
                                north.addAuto(auto, Direction.WEST);
                                break;
                            case Direction.WEST:
                                north.addAuto(auto, Direction.EAST);
                                break;
                        }
                        break;
                    case Light.ORANGE:
                        // currently, we don't move the car
                        // later on, we should involve a random number to
                        // determine if the car should drive through or not
                        break;
                    case Light.RED:
                        // don't move the car
                        break;
                }
            }
        }
    }
}
