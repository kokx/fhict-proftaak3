using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public class KruispuntDirection
    {
        protected Direction direction;

        public Direction Direction
        {
            get
            {
                return direction;
            }
        }

        protected IKruispunt kruispunt;

        public IKruispunt Kruispunt
        {
            get
            {
                return kruispunt;
            }
        }

        public KruispuntDirection(IKruispunt kruispunt, Direction direction)
        {
            this.kruispunt = kruispunt;
            this.direction = direction;
        }
    }

    /// <summary>
    /// Injector implementatie van een kruispunt
    /// </summary>
    public class Injector : IKruispunt
    {

        /// <summary>
        /// Cars that are in this injector
        /// </summary>
        protected Queue<Auto> autos;

        /// <summary>
        /// Connecties met kruispunten
        /// </summary>
        protected List<KruispuntDirection> kruispunten;


        public Injector(List<Auto> autos)
        {
            foreach (Auto auto in autos) {
                this.autos.Enqueue(auto);
            }

            kruispunten = new List<KruispuntDirection>();
        }

        public Injector()
        {
            autos = new Queue<Auto>();
        }

        public void addAuto(Auto auto, Direction afkomst)
        {
            autos.Enqueue(auto);
        }

        public void addKruispunt(IKruispunt kruispunt, Direction direction)
        {
            kruispunten.Add(new KruispuntDirection(kruispunt, direction));
        }

        public KruispuntWachtrij getWachtrij(Direction afkomst, Direction richting)
        {
            return null;
        }

        /// <summary>
        /// Injecteer autos in de verbindingen
        /// </summary>
        public void Simulate()
        {
            // zolang we 3x zo veel autos hierin hebben dan kruispunten,
            // blijven we er 1 aan elk van de kruispunten toevoegen per
            // simulatie
            if ((autos.Count) * 3 > kruispunten.Count) {
                foreach (KruispuntDirection kruispuntDirection in kruispunten) {
                    Direction direction;
                    switch (kruispuntDirection.Direction) {
                        case Direction.NORTH:
                            direction = Direction.SOUTH;
                            break;
                        case Direction.SOUTH:
                            direction = Direction.NORTH;
                            break;
                        case Direction.EAST:
                            direction = Direction.WEST;
                            break;
                        case Direction.WEST:
                        default:
                            direction = Direction.EAST;
                            break;
                    }

                    kruispuntDirection.Kruispunt.addAuto(autos.Dequeue(), direction);
                }
            }
        }
    }
}
