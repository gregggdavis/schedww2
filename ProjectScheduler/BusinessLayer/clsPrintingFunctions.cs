using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Scheduler.BusinessLayer
{
	/// <summary>
	/// Summary description for clsPrintingFunctions.
	/// </summary>
	public class PrintingFunctions
	{
		public PrintingFunctions()
		{
			//
			// TODO: Add constructor logic here
			//
		}



		public static void ShowPageSettings(ref PageSettings ps) 
		{ 
			if(ps==null)
			{
				ps=new PageSettings();
			}
            PageSetupDialog setup = new PageSetupDialog(); 
			PageSettings settings = ps;
            PrinterSettings printersettings = new PrinterSettings();
			setup.PageSettings = settings;
            //Set PageSize to 'A4'
            bool found = false;
            foreach (PaperSize size in printersettings.PaperSizes)
            {
                if (size.PaperName == "A4, 210x297 mm")
                    found = true;
                if (found)
                {
                    setup.PageSettings.PaperSize = size;
                    break;
                }
                else continue;
            }

			// display the dialog and, 
			if(setup.ShowDialog() == DialogResult.OK) 
			{
				ps = setup.PageSettings; 
			}
		}

		public static void SetProperties(ref FormPrinting fp, PageSettings ps)
		{
			fp.TextBoxBoxed = false;
			fp.TabControlBoxed = false;
			fp.LabelInBold = true;
			fp.PrintPreview = true;
			fp.DisabledControlsInGray = true;
			fp.PageNumbering = true;
            fp.TopMargin = 50;

			if(ps==null)
			{
				fp.Orientation = FormPrinting.OrientationENum.Automatic;
				fp.Orientation = FormPrinting.OrientationENum.Portrait;
				fp.DelegatePrintingReportTitle = null;
				//fp.ps=null;
			}
			else
			{
				fp.TextBoxBoxed = false;
				fp.TabControlBoxed = false;
				fp.LabelInBold = true;
				fp.PrintPreview = true;
				fp.DisabledControlsInGray = true;
				fp.PageNumbering = true;

				if(ps.Landscape)
				{
					fp.Orientation = FormPrinting.OrientationENum.Lanscape;
				}
				else
				{
					fp.Orientation = FormPrinting.OrientationENum.Portrait;
				}

				//fp.ps = ps;
			}
		}

        public static void RemoveGroupBoxes(ref Panel panel)
        {
            foreach (Control _control in panel.Controls)
            {
                if (_control.Name.Contains("groupBox"))
                    panel.Controls.Remove(_control);
                else if (_control.Name.Contains("label") || _control.Name.Contains("lbl"))
                    _control.Width += 10;
            }
        }
	}
}
