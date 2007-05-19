using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Scheduler.Helpers
{
    public partial class PreviewRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public PreviewRibbonForm()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            printRibbonController1.PrintControl = masterDetailControl1.PrintControl;
            // TODO: Add any constructor code after InitializeComponent call
        }

        public DevExpress.XtraPrinting.PrintingSystem MyPrintingSystem
        {
            set
            {
                printingSystem = value;
                masterDetailControl1.PrintingSystem = value;
            }
            get { return printingSystem; }
        }

        private void masterDetailControl1_PrintControlChanged(object sender, EventArgs e)
        {
            printRibbonController1.PrintControl = masterDetailControl1.PrintControl;
        }
    }
}