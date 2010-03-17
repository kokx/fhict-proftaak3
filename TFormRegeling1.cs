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
        public TFormRegeling1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.insertKruispuntForm(0, new TKP1(), 0, 0, 484, 339);
            this.insertKruispuntForm(1, new TKP2(), 484, 0, 484, 339);
            this.insertKruispuntForm(2, new TKP3(), 0, 339, 484, 339);
            this.insertKruispuntForm(3, new TKP4(), 484, 339, 484, 339);
        }
    }
}