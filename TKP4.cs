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
    public partial class TKP4 : KruispuntForm
    {
        int status = 0;
        int aantalAutos = 0;

        public int AantalAutos
        { get { return aantalAutos; } }

        public int Status
        { get { return status; } }

        public TKP4(Componenten.IKruispunt kruispunt)
        {
            this.component = kruispunt;

            InitializeComponent();
        }

        public override void NieuweStatus()
        {
            foreach (KruispuntWachtrij wachtrij in component.Wachtrijen) {
                switch (wachtrij.From) {
                    case Direction.SOUTH:
                        tStoplicht9.Kleur = GetKleur(wachtrij);
                        numericUpDown2.Value = wachtrij.Count;
                        break;
                    case Direction.EAST:
                        tStoplicht3.Kleur = GetKleur(wachtrij);
                        numericUpDown3.Value = wachtrij.Count;
                        break;
                    case Direction.WEST:
                        tStoplicht4.Kleur = GetKleur(wachtrij);
                        numericUpDown1.Value = wachtrij.Count;
                        break;
                }
            }
        }
    }
}
