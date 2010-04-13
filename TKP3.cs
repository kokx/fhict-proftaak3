using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;

namespace fhict_proftaak3
{
    public partial class TKP3 : KruispuntForm
    {
        int status = 0;
        int aantalAutos = 0;

        public int AantalAutos
        { get { return aantalAutos; } }

        public int Status
        { get { return status; } }

        public TKP3(Componenten.IKruispunt kruispunt)
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
                        numericUpDown4.Value = wachtrij.Count;
                        break;
                    case Direction.SOUTH:
                        tStoplicht4.Kleur = GetKleur(wachtrij);
                        numericUpDown2.Value = wachtrij.Count;
                        break;
                    case Direction.EAST:
                        tStoplicht5.Kleur = GetKleur(wachtrij);
                        numericUpDown3.Value = wachtrij.Count;
                        break;
                    case Direction.WEST:
                        tStoplicht3.Kleur = GetKleur(wachtrij);
                        numericUpDown1.Value = wachtrij.Count;
                        break;
                }
            }
        }
    }
}
