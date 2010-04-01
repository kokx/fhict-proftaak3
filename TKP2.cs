using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            aantalAutos = Convert.ToInt32(numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value +
            numericUpDown4.Value + numericUpDown5.Value + numericUpDown6.Value);

            status++;
            switch (status)
            {
                case 1:
                    NoodStop();
                    tStoplicht4.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skGroen;
                    tStoplicht6.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skGroen;
                    break;
                case 2:
                    NoodStop();
                    tStoplicht2.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skGroen;
                    tStoplicht8.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skGroen;
                    break;
                case 3:
                    NoodStop();
                    tStoplicht3.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skGroen;
                    tStoplicht9.Kleur = VerkeersComponentenLibrary.TStoplichtKleur.skGroen;
                    status = 0;
                    break;
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
