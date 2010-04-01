using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
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
            }
        }

        public void Simulate()
        {
            // TODO: finish this method
        }
    }
}
