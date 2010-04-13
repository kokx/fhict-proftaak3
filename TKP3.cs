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
                        break;
                    case Direction.SOUTH:
                        tStoplicht4.Kleur = GetKleur(wachtrij);
                        break;
                    case Direction.EAST:
                        tStoplicht5.Kleur = GetKleur(wachtrij);
                        break;
                    case Direction.WEST:
                        tStoplicht3.Kleur = GetKleur(wachtrij);
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
            tStoplicht9.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht10.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht11.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht12.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
        }
    }
}
