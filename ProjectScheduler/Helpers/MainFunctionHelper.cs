using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.Data;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using DevExpress.Utils;
using System.Windows.Forms;


using System.Collections;
namespace Scheduler.Helpers
{
    
    public class MainFunctionHelper
    {
        public enum ViewDisplayed
        {
            SimpleView = 0,
            AdvancedView = 1,
            RecordView = 2,
            QuickView = 4,
            Normal = 8
        }

        public static ArrayList arr = new ArrayList();
        #region Functions
        private static void ExportTo(IExportProvider provider, Helpers.MainFunctionHelper.ViewDisplayed view, Object obj)
        {
            //System.Windows.Forms.Cursor currentCursor = System.Windows.Forms.Cursor.Current;
            //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            BaseExportLink link;
            switch (view)
            {
                case ViewDisplayed.AdvancedView:
                    link = ((DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)obj).CreateExportLink(provider);
                    break;
                case ViewDisplayed.SimpleView:
                    link = ((DevExpress.XtraGrid.Views.Grid.GridView)obj).CreateExportLink(provider);
                    break;

                default:
                    link = ((DevExpress.XtraGrid.Views.Grid.GridView)obj).CreateExportLink(provider);
                    break;
            }

            (link as GridViewExportLink).ExpandAll = false;
            //link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progerss);
            link.ExportTo(true);

            //Cursor.Current = currentCursor;
        }
        private static string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = "Export To " + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private static void OpenFile(string fileName)
        {
            if (MessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    MessageBox.Show("Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void ExportToXML(Helpers.MainFunctionHelper.ViewDisplayed view, Object obj)
        {
            string fileName = ShowSaveFileDialog("Microsoft XML Document", "Microsoft XML|*.xml");
            if (fileName != "")
            {
                ExportTo(new ExportXmlProvider(fileName), view, obj);
                OpenFile(fileName);
            }
        }
        public static void ExportToHTML(Helpers.MainFunctionHelper.ViewDisplayed view, Object obj)
        {
            string fileName = ShowSaveFileDialog("Microsoft HTML Document", "Microsoft HTML|*.html");
            if (fileName != "")
            {
                ExportTo(new ExportHtmlProvider(fileName), view, obj);
                OpenFile(fileName);
            }
        }
        public static void ExportToExcel(Helpers.MainFunctionHelper.ViewDisplayed view, Object obj)
        {
            string fileName = ShowSaveFileDialog("Microsoft Excel Document", "Microsoft Excel|*.xls");
            if (fileName != "")
            {
                ExportTo(new ExportXlsProvider(fileName), view, obj);
                OpenFile(fileName);
            }
        }
        public static void ExportToTXT(Helpers.MainFunctionHelper.ViewDisplayed view, Object obj)
        {
            string fileName = ShowSaveFileDialog("Microsoft Text Document", "Microsoft Text|*.txt");
            if (fileName != "")
            {
                ExportTo(new ExportTxtProvider(fileName), view, obj);
                OpenFile(fileName);
            }
        }
        public static void PrintPreview(Helpers.MainFunctionHelper.ViewDisplayed view, Object obj)
        {
            if (DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable)
            {
                switch (view)
                {
                    case ViewDisplayed.AdvancedView:
                        DevExpress.XtraPrinting.PrintHelper.ShowPreview((DevExpress.XtraGrid.GridControl)obj);
                        break;
                    case ViewDisplayed.SimpleView:
                        DevExpress.XtraPrinting.PrintHelper.ShowPreview((DevExpress.XtraGrid.GridControl)obj);
                        break;
                }


            }
        }
        public static void Print(Helpers.MainFunctionHelper.ViewDisplayed view, Object obj)
        {
            if (DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable)
            {
                switch (view)
                {
                    case ViewDisplayed.AdvancedView:
                        DevExpress.XtraPrinting.PrintHelper.Print(((DevExpress.XtraGrid.GridControl)obj));
                        break;
                    case ViewDisplayed.SimpleView:
                        DevExpress.XtraPrinting.PrintHelper.Print(((DevExpress.XtraGrid.GridControl)obj));
                        break;
                }
            }
        }
        #endregion

        #region Main Functions
        #endregion
    }
}
