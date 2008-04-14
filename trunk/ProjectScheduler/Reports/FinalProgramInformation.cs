using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Scheduler.Reports
{
    public partial class FinalProgramInformation : DevExpress.XtraReports.UI.XtraReport
    {
        public FinalProgramInformation()
        {
            InitializeComponent();
        }

        public void LoadData(string programName)
        {
            lblProgramNameValue.Text = programName;
        }

    }
}
