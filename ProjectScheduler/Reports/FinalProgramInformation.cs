using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Scheduler.BusinessLayer;

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

        public void LoadData(int programID)
        {
            dataSet11.ViewProgramReport.Clear();
            dataSet11.ViewProgramReport.Load(DAC.SelectStatement("Select * From ViewProgramReport Where ProgramID = " + programID), System.Data.LoadOption.OverwriteChanges);

        }

    }
}
