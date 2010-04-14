using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    [Serializable]
    /// <summary>
    /// Drieweg kruispunt implementatie
    /// 
    /// Let op! Om het gemakkelijk te houden, heeft een Drieweg gewoon geen
    /// noord richting, en geen positionering
    /// </summary>
    public abstract class Drieweg : IKruispunt
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
        protected IKruispunt south;


        public abstract void removeKruispunten();

        public void addAuto(Auto auto, Direction afkomst)
        {
            Direction[] choose = new Direction[2];

            switch (afkomst) {
                case Direction.SOUTH:
                    choose[0] = Direction.EAST;
                    choose[1] = Direction.WEST;
                    break;
                case Direction.EAST:
                    choose[0] = Direction.SOUTH;
                    choose[1] = Direction.WEST;
                    break;
                case Direction.WEST:
                    choose[0] = Direction.SOUTH;
                    choose[1] = Direction.EAST;
                    break;
            }

            auto.kiesRichting(choose);

            if (afkomst != Direction.NORTH) {
                getWachtrij(afkomst, auto.Richting).Add(auto);
            }
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
            }
        }

        public void Simulate()
        {
            Auto auto;
            foreach (KruispuntWachtrij wachtrij in wachtrijen) {
                if (null == wachtrij) {
                    continue;
                }
                switch (wachtrij.Light) {
                    case Light.ORANGE:
                        // we should involve a random number to determine if
                        // the car should drive through or not
                        Random random = new Random();

                        if (random.Next(0, 3) != 1) { // one in four chance
                            auto = wachtrij.Pop();

                            if (null == auto) {
                                break;
                            }

                            switch (auto.Richting) {
                                case Direction.SOUTH:
                                    south.addAuto(auto, Direction.NORTH);
                                    break;
                                case Direction.EAST:
                                    east.addAuto(auto, Direction.WEST);
                                    break;
                                case Direction.WEST:
                                    west.addAuto(auto, Direction.EAST);
                                    break;
                            }
                        }
                        break;
                    case Light.GREEN:
                        // ok, great, pop the car from the Queue and let it
                        // drive through
                        auto = wachtrij.Pop();

                        if (null == auto) {
                            break;
                        }

                        switch (auto.Richting) {
                            case Direction.SOUTH:
                                south.addAuto(auto, Direction.NORTH);
                                break;
                            case Direction.EAST:
                                east.addAuto(auto, Direction.WEST);
                                break;
                            case Direction.WEST:
                                west.addAuto(auto, Direction.EAST);
                                break;
                        }
                        break;
                    case Light.RED:
                        // don't move the car
                        break;
                }
            }
        }
    }
}
