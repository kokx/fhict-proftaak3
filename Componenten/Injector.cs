using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    [Serializable]
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

        public KruispuntWachtrij[] Wachtrijen
        {
            get
            {
                return null;
            }
        }

        public Injector(List<Auto> autos)
        {
            this.autos = new Queue<Auto>();

            foreach (Auto auto in autos) {
                this.autos.Enqueue(auto);
            }

            kruispunten = new List<KruispuntDirection>();
        }

        public Injector()
        {
            autos = new Queue<Auto>();
        }

        public void removeKruispunten()
        {
            kruispunten = new List<KruispuntDirection>();
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

        private Direction getOppositeDirection(Direction direction)
        {
            Direction oppositeDirection;
            switch (direction) {
                case Direction.NORTH:
                    oppositeDirection = Direction.SOUTH;
                    break;
                case Direction.SOUTH:
                    oppositeDirection = Direction.NORTH;
                    break;
                case Direction.EAST:
                    oppositeDirection = Direction.WEST;
                    break;
                case Direction.WEST:
                default:
                    oppositeDirection = Direction.EAST;
                    break;
            }

            return oppositeDirection;
        }

        /// <summary>
        /// Shuffle the list
        /// </summary>
        /// <typeparam name="E">type of the list</typeparam>
        /// <param name="inputList"></param>
        /// <returns></returns>
        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();
            List<E> copyList = new List<E>(inputList);

            Random r = new Random();
            int randomIndex = 0;
            while (copyList.Count > 0) {
                randomIndex = r.Next(0, copyList.Count);
                randomList.Add(copyList[randomIndex]);
                copyList.RemoveAt(randomIndex);
            }

            return randomList;
        }


        /// <summary>
        /// Injecteer autos in de verbindingen
        /// </summary>
        public void Simulate()
        {
            List<KruispuntDirection> kruispuntenShuffled = ShuffleList<KruispuntDirection>(kruispunten);
            if ((autos.Count * 3) > kruispunten.Count) {
                // zolang we 3x zo veel autos hierin hebben dan kruispunten,
                // blijven we er 1 aan elk van de kruispunten toevoegen per
                // simulatieronde
                foreach (KruispuntDirection kruispuntDirection in kruispuntenShuffled) {
                    if (autos.Count > 1) {
                        kruispuntDirection.Kruispunt.addAuto(autos.Dequeue(), getOppositeDirection(kruispuntDirection.Direction));
                    }
                }
            } else {
                // we voegen maar aan 1/3 van de kruispunten een auto toe
                // per simulatieronde (random gekozen)
                Random random = new Random();

                foreach (KruispuntDirection kruispuntDirection in kruispuntenShuffled) {
                    if ((autos.Count > 1) && (random.Next(0, 2) == 2)) {
                        kruispuntDirection.Kruispunt.addAuto(autos.Dequeue(), getOppositeDirection(kruispuntDirection.Direction));
                    }
                }
            }
        }
    }
}
