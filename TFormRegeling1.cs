using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fhict_proftaak3
{
    public partial class TFormRegeling1 : VerkeersComponentenLibrary.TFormRegeling
    {
        List<VerkeersComponentenLibrary.TFormKruispunt> kruispunten
            = new List<VerkeersComponentenLibrary.TFormKruispunt>();
        TKP1 tkp1 = new TKP1();
        TKP2 tkp2 = new TKP2();
        TKP3 tkp3 = new TKP3();
        TKP4 tkp4 = new TKP4();

        public TFormRegeling1()
        {
            InitializeComponent();
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
                if (comboBox1.Text == "Type 1")
                    kruispunten.Add(new TKP1());
                if (comboBox1.Text == "Type 2")
                    kruispunten.Add(new TKP2());
                if (comboBox1.Text == "Type 3")
                    kruispunten.Add(new TKP3());
                if (comboBox1.Text == "Type 4")
                    kruispunten.Add(new TKP4());
                this.insertKruispuntForm(0, kruispunten[0], 0, 0, 484, 339);
            }
            else { kruispunten.Add(null); }

            //Toevoegen Locatie 2
            if (comboBox2.Text != "Geen")
            {
                if (comboBox2.Text == "Type 1")
                    kruispunten.Add(new TKP1());
                if (comboBox2.Text == "Type 2")
                    kruispunten.Add(new TKP2());
                if (comboBox2.Text == "Type 3")
                    kruispunten.Add(new TKP3());
                if (comboBox2.Text == "Type 4")
                    kruispunten.Add(new TKP4());
                this.insertKruispuntForm(1, kruispunten[1], 484, 0, 484, 339);
            }
            else { kruispunten.Add(null);}

            //Toevoegen Locatie 3
            if (comboBox3.Text != "Geen")
            {
                if (comboBox3.Text == "Type 1")
                    kruispunten.Add(new TKP1());
                if (comboBox3.Text == "Type 2")
                    kruispunten.Add(new TKP2());
                if (comboBox3.Text == "Type 3")
                    kruispunten.Add(new TKP3());
                if (comboBox3.Text == "Type 4")
                    kruispunten.Add(new TKP4());
                this.insertKruispuntForm(2, kruispunten[2], 0, 339, 484, 339);
            }
            else { kruispunten.Add(null); }

            //Toevoegen Locatie 4
            if (comboBox4.Text != "Geen")
            {
                if (comboBox4.Text == "Type 1")
                    kruispunten.Add(new TKP1());
                if (comboBox4.Text == "Type 2")
                    kruispunten.Add(new TKP2());
                if (comboBox4.Text == "Type 3")
                    kruispunten.Add(new TKP3());
                if (comboBox4.Text == "Type 4")
                    kruispunten.Add(new TKP4());
                this.insertKruispuntForm(3, kruispunten[3], 484, 339, 484, 339);
            }
            else { kruispunten.Add(null); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (VerkeersComponentenLibrary.TFormKruispunt k in kruispunten)
            {
                //blabla
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (VerkeersComponentenLibrary.TFormKruispunt k in kruispunten)
            {
                //BlaBlaBla
            }
        }
    }
}