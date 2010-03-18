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
            for (int i = 0; i < 4; i++)
            {
                this.removeKruispuntForm(i);
            }
            //Toevoegen Locatie 1
            if (comboBox1.Text == "Type 1")
                this.insertKruispuntForm(0, tkp1, 0, 0, 484, 339);
            if (comboBox1.Text == "Type 2")
                this.insertKruispuntForm(0, tkp2, 0, 0, 484, 339);
            if (comboBox1.Text == "Type 3")
                this.insertKruispuntForm(0, tkp3, 0, 0, 484, 339);
            if (comboBox1.Text == "Type 4")
                this.insertKruispuntForm(0, tkp4, 0, 0, 484, 339);
            //Toevoegen Locatie 2
            if (comboBox2.Text == "Type 1")
                this.insertKruispuntForm(1, tkp1, 484, 0, 484, 339);
            if (comboBox2.Text == "Type 2")
                this.insertKruispuntForm(1, tkp2, 484, 0, 484, 339);
            if (comboBox2.Text == "Type 3")
                this.insertKruispuntForm(1, tkp3, 484, 0, 484, 339);
            if (comboBox2.Text == "Type 4")
                this.insertKruispuntForm(1, tkp4, 484, 0, 484, 339);
            //Toevoegen Locatie 3
            if (comboBox3.Text == "Type 1")
                this.insertKruispuntForm(2, tkp1, 0, 339, 484, 339);
            if (comboBox3.Text == "Type 2")
                this.insertKruispuntForm(2, tkp2, 0, 339, 484, 339);
            if (comboBox3.Text == "Type 3")
                this.insertKruispuntForm(2, tkp3, 0, 339, 484, 339);
            if (comboBox3.Text == "Type 4")
                this.insertKruispuntForm(2, tkp4, 0, 339, 484, 339);

            //this.insertKruispuntForm(0, tkp1, 0, 0, 484, 339);
            //this.insertKruispuntForm(1, tkp2, 484, 0, 484, 339);
            //this.insertKruispuntForm(2, tkp3, 0, 339, 484, 339);
            //this.insertKruispuntForm(3, tkp4, 484, 339, 484, 339);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}