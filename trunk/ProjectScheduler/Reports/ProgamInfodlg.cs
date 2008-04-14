using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Scheduler.Reports
{
    public partial class ProgamInfodlg : DevExpress.XtraEditors.XtraForm
    {
        public ProgamInfodlg()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        public void LoadData(string programID,string programName)
        {
            lblProgramNameValue.Text = programName;
            dataSet11.viewSimpleProgramInfo.Clear();
            dataSet11.viewSimpleProgramInfo.Load(BusinessLayer.DAC.SelectStatement("Select * From ViewSimpleProgramInfo Where ProgramID = " + programID), LoadOption.OverwriteChanges);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FinalProgramInformation frm = new FinalProgramInformation();
            frm.LoadData(lblProgramNameValue.Text);
            frm.CreateDocument();
            frm.ShowPreview();
        }
    }
}