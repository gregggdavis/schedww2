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
            this.Tag = programID;
            lblProgramNameValue.Text = programName;
            dataSet11.viewSimpleProgramInfo.Clear();
            string query = "Select * From ViewSimpleProgramInfo Where ProgramID = " + programID + " Order By CourseName";
            dataSet11.viewSimpleProgramInfo.Load(BusinessLayer.DAC.SelectStatement(query), LoadOption.OverwriteChanges);
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FinalProgramInformation frm = new FinalProgramInformation();
            string courseNames = "";
            bool isFirst = true;
            if (gridView1.SelectedRowsCount > 0)
            {
                int[] handles = gridView1.GetSelectedRows();
                foreach (int handle in handles)
                {
                    DataRow row = gridView1.GetDataRow(handle);
                    if (!isFirst)
                    {
                        courseNames += ",";
                    }
                    courseNames += row["CourseID"].ToString();
                    isFirst = false;
                }
                frm.LoadData(Convert.ToInt32(this.Tag), courseNames);
            }
            else
            {
                frm.LoadData(Convert.ToInt32(this.Tag));
            }
            
            frm.CreateDocument();
            frm.ShowPreview();
        }
    }
}