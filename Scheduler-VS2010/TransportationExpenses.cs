using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using DevExpress.XtraGrid;
namespace Scheduler
{
    public partial class TransportationExpenses : DevExpress.XtraEditors.XtraForm
    {
        public TransportationExpenses()
        {
            InitializeComponent();
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

        private void TransportationExpenses_Load(object sender, EventArgs e)
        {
            dateEditEndDate.EditValue = System.DateTime.Today;
            dateEditStartDate.EditValue = System.DateTime.Today;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Helpers.MainFunctionHelper.Print(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridControl1);
            PrintGrid(gridControl1, false);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Helpers.MainFunctionHelper.PrintPreview(Scheduler.Helpers.MainFunctionHelper.ViewDisplayed.SimpleView, gridControl1);
            PrintGrid(gridControl1, true);
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

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            dateEditStartDate.Enabled = checkEdit1.Checked;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            dateEditEndDate.Enabled = checkEdit2.Checked;
        }

        public void PrintGrid(DevExpress.XtraGrid.GridControl gc,bool printPreview)
        {
            //GridView gvwContact = (GridView) gc.DefaultView;
           // string strHeader = strMenuOption;
            //strHeader = strHeader.Remove(strHeader.Length - 3, 3);
            //strHeader += " Information";
            PageHeaderFooter phf = new PageHeaderFooter();
            phf.Header.Font = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point);
            string str = "";
            phf.Header.LineAlignment = BrickAlignment.Near;
            str = "Transportation Expenses";
           // str.AppendFormat(Environment.NewLine);
            //Page header = phf.Header;
            phf.Header.Content.Add(str);
           // str.AppendFormat("Date Generated: {0}", System.DateTime.Today.ToShortDateString());
            //str.AppendFormat(Environment.NewLine);
            if(checkEdit1.Checked && checkEdit2.Checked)
                str = dateEditStartDate.DateTime.ToShortDateString() + " - " + dateEditEndDate.DateTime.ToShortDateString();
            else if (checkEdit1.Checked && !checkEdit2.Checked)
            {
                str = dateEditStartDate.DateTime.ToLongDateString() + " - Unlimited";
            }
            else if (!checkEdit1.Checked && checkEdit2.Checked)
            {
                str = "Unlimited - " + dateEditEndDate.DateTime.ToShortDateString();
            }
            else
            {
                str = "";
                //str.AppendFormat("From: Not Filtered To: Not Filtered");
            }
            phf.Header.LineAlignment = BrickAlignment.Center;
            phf.Header.Content.Add(str);
            phf.Footer.LineAlignment = BrickAlignment.Near;
            phf.Footer.Content.Add("");
            phf.Footer.LineAlignment = BrickAlignment.Center;
            phf.Footer.Content.Add("");
            phf.Footer.LineAlignment = BrickAlignment.Far;
            String footer = "Date Generated: " + System.DateTime.Today.ToShortDateString();
            phf.Footer.Content.Add(footer);
            phf.Footer.LineAlignment = BrickAlignment.Far;

            PrintableComponentLink _link = new PrintableComponentLink(new PrintingSystem());
            _link.Component = gc;
            _link.Landscape = true;
            _link.PageHeaderFooter = phf;
            _link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            _link.Margins.Top = 60;
            _link.Margins.Bottom = 60;
            _link.Margins.Left = 10;
            _link.Margins.Right = 10;
            if (printPreview)
                _link.ShowPreviewDialog();
            else
                _link.PrintDlg();

            /*
            PrinterSettings settings = printDocument1.PrinterSettings;
            //Set PageSize to 'A4'
            bool found=false;
            foreach (PaperSize size in settings.PaperSizes)
            {
                if (size.PaperName == "A4, 210x297 mm")
                    found = true;
                if (found)
                {
                    settings.DefaultPageSettings.PaperSize = size;
                    break;
                }
                else continue;
            }

			printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(50, 50, 15, 50);
            //printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4, 210x297 mm", 827, 1169);
            
			dataGridPrinter1 = new GridViewPrinter(gc, printDocument1, gvwContact);
			dataGridPrinter1.PageNumber = 1;
			dataGridPrinter1.RowCount = 0;
			if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
			}*/
        }

    }
}