using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
namespace Scheduler
{
    public partial class frmPayrollByInstructor : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public frmPayrollByInstructor()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
        }
        BusinessLayer.PayrollByInstructor pay = new Scheduler.BusinessLayer.PayrollByInstructor();
        public void LoadData()
        {
            try
            {
                //BusinessLayer.Connection conn = new Scheduler.BusinessLayer.Connection();
                //System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();


                //string query = "select * from viewPayrollByInstructor";
                //conn.Connect();
                //command.Connection.ConnectionString = BusinessLayer.Common.ConnString;
                //System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter();
                //adapter.SelectCommand = command;

                //adapter.Fill(dataSet11, "viewInstructorPaymentDetails");
                //BusinessLayer.DAC.ConnectionString = BusinessLayer.Common.ConnString;
               // pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, true, dataSet11);
                //gridView1.CollapseAllGroups();
                dateEditEndDate.EditValue = System.DateTime.Today;
                dateEditStartDate.EditValue = System.DateTime.Today;
                if (checkEdit1.Checked && checkEdit2.Checked)
                {
                    if (dateEditStartDate.DateTime > dateEditEndDate.DateTime)
                    {
                        DateTime d = dateEditStartDate.DateTime;
                        dateEditStartDate.DateTime = dateEditEndDate.DateTime;

                        dateEditEndDate.DateTime = d;

                    }
                    dateEditEndDate.DateTime = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                    pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, false, dataSet11);
                }
                else if (checkEdit1.Checked && !checkEdit2.Checked)
                    pay.GetData(dateEditStartDate.DateTime, Convert.ToDateTime("12/12/9999"), false, dataSet11);
                else if (checkEdit2.Checked && !checkEdit1.Checked)
                {
                    DateTime d = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                    pay.GetData(Convert.ToDateTime("12/12/1879"), d, false, dataSet11);
                }
                else
                    pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, true, dataSet11);
                //thread.Abort();

                gridView1.CollapseAllGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        void StartMarquee()
        {
            SearchWait frm = new SearchWait();
            frm.ShowDialog();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(StartMarquee));
            //thread.Start();
            if (checkEdit1.Checked && checkEdit2.Checked)
            {
                if (dateEditStartDate.DateTime > dateEditEndDate.DateTime)
                {
                    DateTime d = dateEditStartDate.DateTime;
                    dateEditStartDate.DateTime = dateEditEndDate.DateTime;
                    
                    dateEditEndDate.DateTime = d;

                }
                dateEditEndDate.DateTime = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, false, dataSet11);
            }
            else if(checkEdit1.Checked && !checkEdit2.Checked)
                pay.GetData(dateEditStartDate.DateTime, Convert.ToDateTime("12/12/9999"), false, dataSet11);
            else if (checkEdit2.Checked && !checkEdit1.Checked)
            {
                DateTime d = Convert.ToDateTime(dateEditEndDate.DateTime.ToShortDateString() + " " + "11:59 PM");
                pay.GetData(Convert.ToDateTime("12/12/1879"), d, false, dataSet11);
            }
            else
                pay.GetData(dateEditStartDate.DateTime, dateEditEndDate.DateTime, true, dataSet11);
            //thread.Abort();

            gridView1.CollapseAllGroups();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            dateEditStartDate.Enabled = checkEdit1.Checked;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            dateEditEndDate.Enabled = checkEdit2.Checked;
        }

        private void frmPayrollByInstructor_Load(object sender, EventArgs e)
        {
            dateEditEndDate.DateTime = System.DateTime.Today;
            dateEditStartDate.DateTime = System.DateTime.Today;
        }
    }
}