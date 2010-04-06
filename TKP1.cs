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
            this.kruispunt = kruispunt;

            InitializeComponent();
        }

        public override void NieuweStatus()
        {
            foreach (KruispuntWachtrij wachtrij in kruispunt.Wachtrijen) {
                switch (wachtrij.From) {
                    case Direction.NORTH:
                        if (wachtrij.HasDirection(Direction.WEST)) {
                            tStoplicht8.Kleur = GetKleur(wachtrij);
                        } else {
                            tStoplicht7.Kleur = GetKleur(wachtrij);
                        }
                        break;
                    case Direction.SOUTH:
                        if (wachtrij.HasDirection(Direction.EAST)) {
                            tStoplicht4.Kleur = GetKleur(wachtrij);
                        } else {
                            tStoplicht3.Kleur = GetKleur(wachtrij);
                        }
                        break;
                    case Direction.EAST:
                        if (wachtrij.HasDirection(Direction.NORTH)) {
                            tStoplicht6.Kleur = GetKleur(wachtrij);
                        } else {
                            tStoplicht5.Kleur = GetKleur(wachtrij);
                        }
                        break;
                    case Direction.WEST:
                        if (wachtrij.HasDirection(Direction.SOUTH)) {
                            tStoplicht2.Kleur = GetKleur(wachtrij);
                        } else {
                            tStoplicht1.Kleur = GetKleur(wachtrij);
                        }
                        break;
                }
            }
        }

        public override void NoodStop()
        {
            tStoplicht1.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht2.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht3.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht4.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht5.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht6.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht7.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht8.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
        }
    }
}
