using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fhict_proftaak3
{
    static class TRegelingApplicatie
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TFormRegeling1());
        }
    }
}