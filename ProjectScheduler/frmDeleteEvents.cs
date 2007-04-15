using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Scheduler.BusinessLayer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmDeleteEvents.
	/// </summary>
	public class frmDeleteEvents : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pbxErrorInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbtnCalendarEvt;
		private System.Windows.Forms.RadioButton rbtnEvent;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int EventID=0;
		private int CalendarEventID=0;

		public frmDeleteEvents()
		{
			InitializeComponent();
		}
		public frmDeleteEvents(int _eventid, int _caleventid)
		{
			InitializeComponent();
			EventID = _eventid;
			CalendarEventID = _caleventid;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDeleteEvents));
			this.pbxErrorInfo = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rbtnCalendarEvt = new System.Windows.Forms.RadioButton();
			this.rbtnEvent = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// pbxErrorInfo
			// 
			this.pbxErrorInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbxErrorInfo.Image")));
			this.pbxErrorInfo.Location = new System.Drawing.Point(14, 15);
			this.pbxErrorInfo.Name = "pbxErrorInfo";
			this.pbxErrorInfo.Size = new System.Drawing.Size(32, 32);
			this.pbxErrorInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbxErrorInfo.TabIndex = 6;
			this.pbxErrorInfo.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(58, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 48);
			this.label1.TabIndex = 7;
			this.label1.Text = "Do you want to delete all occurences of the Recurring Event  or just this one?";
			// 
			// rbtnCalendarEvt
			// 
			this.rbtnCalendarEvt.Checked = true;
			this.rbtnCalendarEvt.Location = new System.Drawing.Point(58, 64);
			this.rbtnCalendarEvt.Name = "rbtnCalendarEvt";
			this.rbtnCalendarEvt.Size = new System.Drawing.Size(160, 24);
			this.rbtnCalendarEvt.TabIndex = 8;
			this.rbtnCalendarEvt.TabStop = true;
			this.rbtnCalendarEvt.Text = "Delete this occuerence.";
			// 
			// rbtnEvent
			// 
			this.rbtnEvent.Location = new System.Drawing.Point(58, 87);
			this.rbtnEvent.Name = "rbtnEvent";
			this.rbtnEvent.Size = new System.Drawing.Size(160, 24);
			this.rbtnEvent.TabIndex = 9;
			this.rbtnEvent.Text = "Delete the series..";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(49, 120);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(134, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmDeleteEvents
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(258, 160);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.rbtnEvent);
			this.Controls.Add(this.rbtnCalendarEvt);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pbxErrorInfo);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDeleteEvents";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirm Delete";
			this.Load += new System.EventHandler(this.frmDeleteEvents_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
			this.DialogResult=DialogResult.Cancel;
		}

		private void frmDeleteEvents_Load(object sender, System.EventArgs e)
		{
			ActiveControl = btnOK;

			try
			{
				Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();

		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			string strMess="";
			
			Events evt = new Events();
			evt.EventID = EventID;
			strMess = evt.CheckClassEvent();
			if(strMess=="") strMess = evt.CheckProgramEcent();

			if(strMess!="")
			{
				BusinessLayer.Message.MsgWarning("This Event is linked with" + strMess + ".\n\nEvent cannot be deleted.");
				Close();
				this.DialogResult=DialogResult.Cancel;
				return;
			}

			if(rbtnCalendarEvt.Checked)
			{
				evt.CalendarEventID = CalendarEventID;
				evt.DeleteData(false);
			}
			else
			{
				evt.DeleteData(true);
			}

			Close();
			this.DialogResult=DialogResult.OK;
		}
	}
}
