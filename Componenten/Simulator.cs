using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    class Simulator
    {

        protected int ticks;
        public int Ticks
        {
            get { return this.ticks; }
        }

        /// <summary>
        /// PreSimulate event hook
        /// </summary>
        public event EventHandler preSimulate;
        /// <summary>
        /// PostSimulate event hook
        /// </summary>
        public event EventHandler postSimulate;

        protected List<IKruispunt> kruispunten;
        public List<IKruispunt> Kruispunten
        {
            get { return this.kruispunten; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Simulator()
        {
            kruispunten = new List<IKruispunt>();
            ticks = 0;

            InitMap();
        }

        /// <summary>
        /// Genereer een lijst van auto's
        /// </summary>
        /// <returns>gegenereerde auto's</returns>
        public List<Auto> GenerateAutos(int aantal)
        {
            List<Auto> autos = new List<Auto>();

            Random random = new Random();

            for (int i = 0; i < aantal; i++) {
                autos.Add(new Auto(random));
            }

            return autos;
        }

        /// <summary>
        /// Maak een map van 4 kruispunten, ook word een Injector kruispunt
        /// toegevoegd
        /// </summary>
        public void InitMap()
        {
            IKruispunt injector = new Injector(GenerateAutos(100));

            kruispunten.Add(injector);

            // kruispunt north-west
            IKruispunt nw = new Kruispunten.Type1();

            kruispunten.Add(nw);

            injector.addKruispunt(nw, Direction.SOUTH);
            injector.addKruispunt(nw, Direction.EAST);

            // kruispunt 2, north-east
            IKruispunt ne = new Kruispunten.Type2();

            kruispunten.Add(ne);

            injector.addKruispunt(ne, Direction.SOUTH);
            injector.addKruispunt(ne, Direction.WEST);

            // kruispunt 3, south-west
            IKruispunt sw = new Kruispunten.Type2();

            kruispunten.Add(sw);

            injector.addKruispunt(sw, Direction.NORTH);
            injector.addKruispunt(sw, Direction.EAST);

            // kruispunt 4, south-east
            IKruispunt se = new Kruispunten.Type3();

            kruispunten.Add(se);

            injector.addKruispunt(se, Direction.NORTH);
            injector.addKruispunt(se, Direction.WEST);

            // ok, we got the basic setup, now add the roads between them

            ne.addKruispunt(nw, Direction.WEST);
            nw.addKruispunt(ne, Direction.EAST);

            se.addKruispunt(sw, Direction.WEST);
            sw.addKruispunt(se, Direction.EAST);

            ne.addKruispunt(se, Direction.SOUTH);
            se.addKruispunt(ne, Direction.NORTH);

            nw.addKruispunt(sw, Direction.SOUTH);
            sw.addKruispunt(nw, Direction.NORTH);
        }

        /// <summary>
        /// Do a number of simulation rounds
        /// </summary>
        /// <param name="ticks">the number of simulation rounds</param>
        public void Simulate(int ticks)
        {
            for (int i = 0; i < ticks; i++) {
                Simulate();
            }
        }

        /// <summary>
        /// Do one simulation round
        /// </summary>
        public void Simulate()
        {
            this.preSimulate(this, new EventArgs());

            ticks++;

            foreach (IKruispunt kruispunt in kruispunten) {
                kruispunt.Simulate();
            }

            this.postSimulate(this, new EventArgs());
        }
    }
}