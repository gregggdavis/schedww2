using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraTab;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraEditors;


namespace Scheduler.Helpers {
	public class MasterDetailControl : XtraUserControl {
		
		MyPrintControl pc = new MyPrintControl();
		string DBFileName;
		string connectionString;
		DataView dv;

		XtraTabControl PSTab;
		XtraTabPage tabPage1;
		System.Windows.Forms.ImageList imageList1;
		System.Windows.Forms.ImageList imageList2;
		System.ComponentModel.IContainer components;
		PrintingSystem printingSystem;

		public event EventHandler PrintControlChanged;

		public PrintControl PrintControl {
			get {
				XtraTabPage tp = PSTab.TabPages[PSTab.SelectedTabPageIndex];
				if(tp.Controls.Count > 0) {
					PrintControl pc = tp.Controls[0] as PrintControl;
					if(pc != null)
						return pc;
				}
				return null;
			}
		}


        public PrintingSystem PrintingSystem
        {
            get { return printingSystem; }
            set
            {
                printingSystem = value;
                //CreateReport(printingSystem, dv, wCustomers, sCustomers, imageList1, 0, "Customers", imageList2.Images[0]);
                pc.PrintingSystem = printingSystem;
                printingSystem.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.All);
                printingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.All);
                printingSystem.SetCommandVisibility(PrintingSystemCommand.ExportCsv, CommandVisibility.All);
                printingSystem.SetCommandVisibility(PrintingSystemCommand.ExportHtm, CommandVisibility.All);
                printingSystem.SetCommandVisibility(PrintingSystemCommand.ExportMht, CommandVisibility.All);
                printingSystem.SetCommandVisibility(PrintingSystemCommand.ExportRtf, CommandVisibility.All);
                

                printingSystem.SetCommandVisibility(PrintingSystemCommand.SendTxt, CommandVisibility.All);
                printingSystem.SetCommandVisibility(PrintingSystemCommand.SendXls, CommandVisibility.All);
                printingSystem.SetCommandVisibility(PrintingSystemCommand.SendCsv, CommandVisibility.All);
                
            }
        }

		public MasterDetailControl() {
			InitializeComponent();

			pc.ChangeClickBrick += new EventHandler(ChangeClickBrick);
			pc.Dock = DockStyle.Fill;
			tabPage1.Controls.Add((System.Windows.Forms.Control)pc);
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MasterDetailControl));
			this.PSTab = new XtraTabControl();
			this.tabPage1 = new XtraTabPage();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.PSTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbExport
			// 
			// 
			// cmbEdit
			// 
			// 
			// PSTab
			// 
			this.PSTab.TabPages.Add(this.tabPage1);
			//			this.PSTab.Controls.AddRange(new System.Windows.Forms.Control[] {
			//																				this.tabPage1});
			this.PSTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PSTab.Location = new System.Drawing.Point(1, 1);
			this.PSTab.Name = "PSTab";
			this.PSTab.SelectedTabPageIndex = 0;
			this.PSTab.Size = new System.Drawing.Size(698, 295);
			this.PSTab.TabIndex = 3;
			this.PSTab.SelectedPageChanged += new TabPageChangedEventHandler(this.PSTab_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(690, 269);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Main Report";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// imageList2
			// 
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList2.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// PreviewControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.PSTab});
			this.Name = "PreviewControl";
			this.PSTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	
	
		private void ChangeClickBrick(object sender, EventArgs e) {
			Brick brick = sender as Brick;

			if(brick.Value.Equals("Main")) {
				PSTab.SelectedTabPageIndex = 0;
				return;
			}

			int i = brick.Value.Equals(0) ? 1 : 0;
			brick.Value = i;
			((ImageBrick)brick).Image = imageList1.Images[i];
			pc.InvalidateBrick(brick);
			string tpName = "Orders[" + brick.ID + "]";

			if(i == 1) {
				XtraTabPage tp = new XtraTabPage();
				tp.Text = tpName;
				tp.Tag = brick.ID;
				PSTab.TabPages.Add(tp);
				PrintingSystem ps = new PrintingSystem();
				ps.SetCommandVisibility(PrintingSystemCommand.ClosePreview, CommandVisibility.None);
				MyPrintControl pcNew = new MyPrintControl();
				pcNew.ChangeClickBrick += new EventHandler(ChangeClickBrick);
				pcNew.Dock = DockStyle.Fill;
				pcNew.PrintingSystem = ps;
				tp.Controls.Add((System.Windows.Forms.Control)pcNew);

				PSTab.SelectedTabPageIndex = FindTabPageIndex(tpName, PSTab);
				//this.Focus();
			} else {
				PSTab.TabPages.RemoveAt(FindTabPageIndex(tpName, PSTab));
				PSTab.SelectedTabPageIndex = 0;
			}
		}
	
		private int FindTabPageIndex(string s, XtraTabControl tbc) {
			for(int i = 0; i < tbc.TabPages.Count; i++)
				if(tbc.TabPages[i].Text == s) return i;
			return -1;
		}
	
		private void PSTab_SelectedIndexChanged(object sender, TabPageChangedEventArgs e) {
			OnPrintControlChanged();
		}
		void OnPrintControlChanged() {
			if(PrintControlChanged != null)
				PrintControlChanged(this, new EventArgs());
		}
	}
	
}
