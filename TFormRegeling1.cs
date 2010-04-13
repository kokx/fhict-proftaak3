using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fhict_proftaak3.Ai;
using fhict_proftaak3.Componenten;
using fhict_proftaak3.Componenten.Kruispunten;
using System.IO;

namespace fhict_proftaak3
{
    public partial class TFormRegeling1 : VerkeersComponentenLibrary.TFormRegeling
    {
        
        KruispuntForm nw;
        KruispuntForm ne;
        KruispuntForm sw;
        KruispuntForm se;

        public Simulator simulator;

        string logline = Convert.ToString(DateTime.Now);

        public Ai.Ai ai;

        public TFormRegeling1()
        {
            InitializeComponent();

            simulator = new Simulator();

            simulator.postSimulate += new EventHandler(simulator_postSimulate);
        }

        private KruispuntForm createKruispunt(ComboBox comboBox)
        {
            KruispuntForm kruispunt;

            if (comboBox.Text == "Type 1") {
                kruispunt = new TKP1(new Type1());
            } else if (comboBox.Text == "Type 2") {
                kruispunt = new TKP2(new Type2());
            } else if (comboBox.Text == "Type 3") {
                kruispunt = new TKP3(new Type3());
            } else if (comboBox.Text == "Type 4") {
                kruispunt = new TKP4(new Type4());
            } else {
                return null;
            }

            return kruispunt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Toevoegen Locatie 1
            if (comboBox1.Text != "Geen")
            {
                nw = createKruispunt(comboBox1);
                this.insertKruispuntForm(0, nw, 0, 0, 484, 339);
            }

            //Toevoegen Locatie 2
            if (comboBox2.Text != "Geen")
            {
                ne = createKruispunt(comboBox2);
                this.insertKruispuntForm(1, ne, 484, 0, 484, 339);
            }

            //Toevoegen Locatie 3
            if (comboBox3.Text != "Geen")
            {
                sw = createKruispunt(comboBox3);
                this.insertKruispuntForm(2, sw, 0, 339, 484, 339);
            }

            //Toevoegen Locatie 4
            if (comboBox4.Text != "Geen")
            {
                se = createKruispunt(comboBox4);
                this.insertKruispuntForm(3, se, 484, 339, 484, 339);
            }

            simulator.InitMap(nw.Component, ne.Component, sw.Component, se.Component);

            ai = new Ai.Ai(simulator);

            button2.Enabled = true;
        }

        void simulator_postSimulate(object sender, EventArgs e)
        {
            nw.NieuweStatus();
            ne.NieuweStatus();
            sw.NieuweStatus();
            se.NieuweStatus();

            string logline = Convert.ToString(DateTime.Now);

            int i = 0;
            foreach (KruispuntWachtrij wachtrij in nw.Component.Wachtrijen)
            {
                i++;
                logline += ": Wachtrij " + i + ": " + Convert.ToString(wachtrij.Count);
                  
            }
            
            Log(logline);            
            
        }
        public static void Log(string Message)
        {
            File.AppendAllText("C:\\Users\\Chris\\Documents\\logfile.txt", Message + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            simulator.Noodstop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            simulator.Simulate();
        }
    }
}