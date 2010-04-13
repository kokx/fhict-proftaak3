using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fhict_proftaak3.Componenten;

namespace fhict_proftaak3
{
    public partial class TKP2 : KruispuntForm
    {
        int status = 0;
        int aantalAutos = 0;

        public int AantalAutos
        { get { return aantalAutos; } }

        public int Status
        { get { return status; } }

        public TKP2(Componenten.IKruispunt kruispunt)
        {
            this.component = kruispunt;

            InitializeComponent();
        }

        public override void NieuweStatus()
        {
            foreach (KruispuntWachtrij wachtrij in component.Wachtrijen) {
                switch (wachtrij.From) {
                    case Direction.NORTH:
                        tStoplicht6.Kleur = GetKleur(wachtrij);
                        numericUpDown6.Value = wachtrij.Count;
                        break;
                    case Direction.SOUTH:
                        tStoplicht4.Kleur = GetKleur(wachtrij);
                        numericUpDown3.Value = wachtrij.Count;
                        break;
                    case Direction.EAST:
                        if (wachtrij.HasDirection(Direction.SOUTH)) {
                            tStoplicht9.Kleur = GetKleur(wachtrij);
                            numericUpDown4.Value = wachtrij.Count;
                        } else {
                            tStoplicht8.Kleur = GetKleur(wachtrij);
                            numericUpDown5.Value = wachtrij.Count;
                        }
                        break;
                    case Direction.WEST:
                        if (wachtrij.HasDirection(Direction.NORTH)) {
                            tStoplicht3.Kleur = GetKleur(wachtrij);
                            numericUpDown1.Value = wachtrij.Count;
                        } else {
                            tStoplicht2.Kleur = GetKleur(wachtrij);
                            numericUpDown2.Value = wachtrij.Count;
                        }
                        break;
                }
            }
        }
    }
}
