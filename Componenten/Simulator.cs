using System;
using System.Collections.Generic;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public class Simulator
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

        protected Injector injector;

        public Injector Injector
        {
            get { return injector; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Simulator()
        {
            kruispunten = new List<IKruispunt>();
            ticks = 0;
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
        /// Maak een map van vier opgegeven kruispunten
        /// </summary>
        /// <param name="nw">Kruispunt in het noordwesten</param>
        /// <param name="ne">Kruispunt in het noordoosten</param>
        /// <param name="sw">Kruispunt in het zuidwesten</param>
        /// <param name="se">Kruispunt in het zuidoosten</param>
        public void InitMap(IKruispunt nw, IKruispunt ne, IKruispunt sw, IKruispunt se)
        {
            // refresh the kruispunten list
            kruispunten = new List<IKruispunt>();

            injector = new Injector(GenerateAutos(1000));

            // kruispunt north-west
            kruispunten.Add(nw);
            nw.removeKruispunten();

            injector.addKruispunt(nw, Direction.SOUTH);
            injector.addKruispunt(nw, Direction.EAST);

            nw.addKruispunt(injector, Direction.NORTH);
            nw.addKruispunt(injector, Direction.WEST);

            // kruispunt 2, north-east
            kruispunten.Add(ne);
            ne.removeKruispunten();

            injector.addKruispunt(ne, Direction.SOUTH);
            injector.addKruispunt(ne, Direction.WEST);

            ne.addKruispunt(injector, Direction.NORTH);
            ne.addKruispunt(injector, Direction.EAST);

            // kruispunt 3, south-west
            kruispunten.Add(sw);
            sw.removeKruispunten();

            injector.addKruispunt(sw, Direction.NORTH);
            injector.addKruispunt(sw, Direction.EAST);

            sw.addKruispunt(injector, Direction.SOUTH);
            sw.addKruispunt(injector, Direction.WEST);

            // kruispunt 4, south-east
            kruispunten.Add(se);
            se.removeKruispunten();

            injector.addKruispunt(se, Direction.NORTH);
            injector.addKruispunt(se, Direction.WEST);

            se.addKruispunt(injector, Direction.SOUTH);
            se.addKruispunt(injector, Direction.EAST);

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
        /// Maak een map van 4 kruispunten, ook word een Injector kruispunt
        /// toegevoegd
        /// </summary>
        public void InitMap()
        {
            injector = new Injector(GenerateAutos(100));

            // kruispunt north-west
            IKruispunt nw = new Kruispunten.Type1();

            kruispunten.Add(nw);

            injector.addKruispunt(nw, Direction.SOUTH);
            injector.addKruispunt(nw, Direction.EAST);

            nw.addKruispunt(injector, Direction.NORTH);
            nw.addKruispunt(injector, Direction.WEST);

            // kruispunt 2, north-east
            IKruispunt ne = new Kruispunten.Type2();

            kruispunten.Add(ne);

            injector.addKruispunt(ne, Direction.SOUTH);
            injector.addKruispunt(ne, Direction.WEST);

            ne.addKruispunt(injector, Direction.NORTH);
            ne.addKruispunt(injector, Direction.EAST);

            // kruispunt 3, south-west
            IKruispunt sw = new Kruispunten.Type2();

            kruispunten.Add(sw);

            injector.addKruispunt(sw, Direction.NORTH);
            injector.addKruispunt(sw, Direction.EAST);

            sw.addKruispunt(injector, Direction.SOUTH);
            sw.addKruispunt(injector, Direction.WEST);

            // kruispunt 4, south-east
            IKruispunt se = new Kruispunten.Type3();

            kruispunten.Add(se);

            injector.addKruispunt(se, Direction.NORTH);
            injector.addKruispunt(se, Direction.WEST);

            se.addKruispunt(injector, Direction.SOUTH);
            se.addKruispunt(injector, Direction.EAST);

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
            if (null != preSimulate) {
                preSimulate(this, new EventArgs());
            }

            ticks++;

            injector.Simulate();

            foreach (IKruispunt kruispunt in kruispunten) {
                kruispunt.Simulate();
            }

            if (null != postSimulate) {
                postSimulate(this, new EventArgs());
            }
        }
    }
}