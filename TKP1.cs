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
    public partial class TKP1 : KruispuntForm
    {
        int status = 0;
        int aantalAutos = 0;

        public int AantalAutos
        { get { return aantalAutos; } }

        public int Status 
        { get { return status; } }

        public TKP1(Componenten.IKruispunt kruispunt)
        {
            this.component = kruispunt;

            InitializeComponent();
        }

        public override void NieuweStatus()
        {
            foreach (KruispuntWachtrij wachtrij in component.Wachtrijen) {
                switch (wachtrij.From) {
                    case Direction.NORTH:
                        if (wachtrij.HasDirection(Direction.WEST)) {
                            tStoplicht8.Kleur = GetKleur(wachtrij);
                            numericUpDown8.Value = wachtrij.Count;
                        } else {
                            tStoplicht7.Kleur = GetKleur(wachtrij);
                            numericUpDown7.Value = wachtrij.Count;
                        }
                        break;
                    case Direction.SOUTH:
                        if (wachtrij.HasDirection(Direction.EAST)) {
                            tStoplicht4.Kleur = GetKleur(wachtrij);
                            numericUpDown4.Value = wachtrij.Count;
                        } else {
                            tStoplicht3.Kleur = GetKleur(wachtrij);
                            numericUpDown3.Value = wachtrij.Count;
                        }
                        break;
                    case Direction.EAST:
                        if (wachtrij.HasDirection(Direction.NORTH)) {
                            tStoplicht6.Kleur = GetKleur(wachtrij);
                            numericUpDown6.Value = wachtrij.Count;
                        } else {
                            tStoplicht5.Kleur = GetKleur(wachtrij);
                            numericUpDown5.Value = wachtrij.Count;
                        }
                        break;
                    case Direction.WEST:
                        if (wachtrij.HasDirection(Direction.SOUTH)) {
                            tStoplicht2.Kleur = GetKleur(wachtrij);
                            numericUpDown2.Value = wachtrij.Count;
                        } else {
                            tStoplicht1.Kleur = GetKleur(wachtrij);
                            numericUpDown1.Value = wachtrij.Count;
                        }
                        break;
                }
            }
        }
    }
}
