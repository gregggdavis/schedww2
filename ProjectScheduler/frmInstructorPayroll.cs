using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Scheduler
{
    public partial class frmInstructorPayroll : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public frmInstructorPayroll()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
        }
        DataView dv = new DataView();
        public void PerformSearch()
        {
            if (checkEdit1.Checked && checkEdit2.Checked)
            {
                if (dateEditStartDate.DateTime > dateEditEndDate.DateTime)
                {
                    DateTime d = dateEditStartDate.DateTime;
                    dateEditStartDate.DateTime = dateEditEndDate.DateTime;

                    dateEditEndDate.DateTime = d;

                }
                dateEditEndDate.DateTime = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                dv.RowFilter = " StartDateTime >= '" + dateEditStartDate.DateTime + "' AND StartDateTime <= '" + dateEditEndDate.DateTime + "' ";
                //pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, false, dataSet11);
            }
            else if (checkEdit1.Checked && !checkEdit2.Checked)
                //pay.GetData(dateEditStartDate.DateTime, Convert.ToDateTime("12/12/9999"), false, dataSet11);
                dv.RowFilter = " StartDateTime >= '" + dateEditStartDate.DateTime + "'";
            else if (checkEdit2.Checked && !checkEdit1.Checked)
            {
                DateTime d = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                //pay.GetData(Convert.ToDateTime("12/12/1879"), d, false, dataSet11);
                dv.RowFilter = " StartDateTime <= '" + dateEditEndDate.DateTime + "' ";
            }
            else
                //pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, true, dataSet11);
                dv.RowFilter = "";

        }
        public void LoadData()
        {
            try
            {
                dv.Table = dataSet11.viewInstructorPaymentDetails;
                //BusinessLayer.Connection conn = new Scheduler.BusinessLayer.Connection();
                //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();
                dateEditEndDate.EditValue = System.DateTime.Today;
                dateEditStartDate.EditValue = System.DateTime.Today;

                string query = "select * from viewInstructorPaymentDetails";
                //conn.Connect();
                //command.Connection.ConnectionString = BusinessLayer.Common.ConnString;
                //System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                //adapter.SelectCommand = command;

                //adapter.Fill(dataSet11, "viewInstructorPaymentDetails");
                BusinessLayer.DAC.ConnectionString = BusinessLayer.Common.ConnString;
                dataSet11.viewInstructorPaymentDetails.Clear();
                dataSet11.viewInstructorPaymentDetails.Load(BusinessLayer.DAC.SelectStatement(query), LoadOption.OverwriteChanges);
                gridControl1.DataSource = dv;
                //conn.DisConnect();
                PerformSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //string lastRowFilter = "";
        private void frmInstructorPayroll_Load(object sender, EventArgs e)
        {
            dateEditEndDate.EditValue = System.DateTime.Today;
            dateEditStartDate.EditValue = System.DateTime.Today;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.MainFunctionHelper.Print(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridControl1);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.MainFunctionHelper.PrintPreview(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridControl1);
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Helpers.MainFunctionHelper.ExportToExcel(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridView1);
        }

        private void exportToHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.MainFunctionHelper.ExportToHTML(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridView1);

        }

        private void exportToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.MainFunctionHelper.ExportToXML(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridView1);
        }

        private void exportToTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helpers.MainFunctionHelper.ExportToTXT(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridView1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked && checkEdit2.Checked)
            {
                if (dateEditStartDate.DateTime > dateEditEndDate.DateTime)
                {
                    DateTime d = dateEditStartDate.DateTime;
                    dateEditStartDate.DateTime = dateEditEndDate.DateTime;

                    dateEditEndDate.DateTime = d;

                }
                dateEditEndDate.DateTime = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                dv.RowFilter = " StartDateTime >= '" + dateEditStartDate.DateTime + "' AND StartDateTime <= '" + dateEditEndDate.DateTime + "' ";
                //pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, false, dataSet11);
            }
            else if (checkEdit1.Checked && !checkEdit2.Checked)
                //pay.GetData(dateEditStartDate.DateTime, Convert.ToDateTime("12/12/9999"), false, dataSet11);
                dv.RowFilter = " StartDateTime >= '" + dateEditStartDate.DateTime + "'";
            else if (checkEdit2.Checked && !checkEdit1.Checked)
            {
                DateTime d = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                //pay.GetData(Convert.ToDateTime("12/12/1879"), d, false, dataSet11);
                dv.RowFilter = " StartDateTime <= '" + dateEditEndDate.DateTime + "' ";
            }
            else
                //pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, true, dataSet11);
                dv.RowFilter = "";

            //lastRowFilter = dv.RowFilter;
            
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
            dateEditStartDate.Enabled = checkEdit1.Checked;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            dateEditEndDate.Enabled = checkEdit2.Checked;
            
        }
    }
}