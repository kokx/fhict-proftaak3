using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;
using fhict_proftaak3.Ai;

namespace fhict_proftaak3
{
    public partial class TFormRegeling1 : VerkeersComponentenLibrary.TFormRegeling
    {
        List<VerkeersComponentenLibrary.TFormKruispunt> kruispunten
            = new List<VerkeersComponentenLibrary.TFormKruispunt>();

        public Simulator simulator;

        public TFormRegeling1()
        {
            InitializeComponent();

            simulator = new Simulator();

            simulator.postSimulate += new EventHandler(simulator_postSimulate);
        }

        private KruispuntForm createKruispunt(ComboBox comboBox)
        {
            KruispuntForm kruispunt;

            if (comboBox1.Text == "Type 1")
                kruispunt = new TKP1(new Type1());
            if (comboBox1.Text == "Type 2")
                kruispunt = new TKP2(new Type2());
            if (comboBox1.Text == "Type 3")
                kruispunt = new TKP3(new Type3());
            if (comboBox1.Text == "Type 4")
                kruispunt = new TKP4(new Type4());
            else
                return null;

            return kruispunt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear kruispunten
            kruispunten.Clear();
            for (int i = 0; i < 4; i++)
            {
                this.removeKruispuntForm(i);
            }
            //Toevoegen Locatie 1
            if (comboBox1.Text != "Geen")
            {
                kruispunten[0] = createKruispunt(comboBox1);
                this.insertKruispuntForm(0, kruispunten[0], 0, 0, 484, 339);
            }
            else { kruispunten.Add(null); }

            //Toevoegen Locatie 2
            if (comboBox2.Text != "Geen")
            {
                kruispunten[1] = createKruispunt(comboBox2);
                this.insertKruispuntForm(1, kruispunten[1], 484, 0, 484, 339);
            }
            else { kruispunten.Add(null);}

            //Toevoegen Locatie 3
            if (comboBox3.Text != "Geen")
            {
                kruispunten[2] = createKruispunt(comboBox3);
                this.insertKruispuntForm(2, kruispunten[2], 0, 339, 484, 339);
            }
            else { kruispunten.Add(null); }

            //Toevoegen Locatie 4
            if (comboBox4.Text != "Geen")
            {
                kruispunten[3] = createKruispunt(comboBox4);
                this.insertKruispuntForm(3, kruispunten[3], 484, 339, 484, 339);
            }
            else { kruispunten.Add(null); }
        }

        void simulator_postSimulate(object sender, EventArgs e)
        {
            //MessageBox.Show("I am dishonored!");

            foreach (KruispuntForm k in kruispunten)
            {
                k.NieuweStatus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            simulator.Simulate(100);

            MessageBox.Show("Simulatie compleet");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (KruispuntForm k in kruispunten)
            {
                k.NoodStop();
            }
        }
    }
}