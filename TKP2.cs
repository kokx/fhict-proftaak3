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
            this.kruispunt = kruispunt;

            InitializeComponent();
        }

        public override void NieuweStatus()
        {
            foreach (KruispuntWachtrij wachtrij in kruispunt.Wachtrijen) {
                switch (wachtrij.From) {
                    case Direction.NORTH:
                        tStoplicht6.Kleur = GetKleur(wachtrij);
                        break;
                    case Direction.SOUTH:
                        tStoplicht4.Kleur = GetKleur(wachtrij);
                        break;
                    case Direction.EAST:
                        if (wachtrij.HasDirection(Direction.SOUTH)) {
                            tStoplicht9.Kleur = GetKleur(wachtrij);
                        } else {
                            tStoplicht8.Kleur = GetKleur(wachtrij);
                        }
                        break;
                    case Direction.WEST:
                        if (wachtrij.HasDirection(Direction.NORTH)) {
                            tStoplicht3.Kleur = GetKleur(wachtrij);
                        } else {
                            tStoplicht2.Kleur = GetKleur(wachtrij);
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
            tStoplicht9.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
            tStoplicht10.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skRood;
        }
    }
}
