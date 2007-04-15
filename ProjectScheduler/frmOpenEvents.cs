using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Scheduler.BusinessLayer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmOpenEvents.
	/// </summary>
	public class frmOpenEvents : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.RadioButton rbtnEvent;
		private System.Windows.Forms.RadioButton rbtnCalendarEvt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pbxErrorInfo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOpenEvents()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOpenEvents));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.rbtnEvent = new System.Windows.Forms.RadioButton();
			this.rbtnCalendarEvt = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.pbxErrorInfo = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(136, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(48, 120);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 16;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// rbtnEvent
			// 
			this.rbtnEvent.Location = new System.Drawing.Point(56, 88);
			this.rbtnEvent.Name = "rbtnEvent";
			this.rbtnEvent.Size = new System.Drawing.Size(160, 24);
			this.rbtnEvent.TabIndex = 15;
			this.rbtnEvent.Text = "Open the series..";
			// 
			// rbtnCalendarEvt
			// 
			this.rbtnCalendarEvt.Checked = true;
			this.rbtnCalendarEvt.Location = new System.Drawing.Point(56, 64);
			this.rbtnCalendarEvt.Name = "rbtnCalendarEvt";
			this.rbtnCalendarEvt.Size = new System.Drawing.Size(160, 24);
			this.rbtnCalendarEvt.TabIndex = 14;
			this.rbtnCalendarEvt.TabStop = true;
			this.rbtnCalendarEvt.Text = "Open this occuerence.";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 48);
			this.label1.TabIndex = 13;
			this.label1.Text = "Do you want to open all occurences of the Recurring Event  or just this one?";
			// 
			// pbxErrorInfo
			// 
			this.pbxErrorInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbxErrorInfo.Image")));
			this.pbxErrorInfo.Location = new System.Drawing.Point(16, 16);
			this.pbxErrorInfo.Name = "pbxErrorInfo";
			this.pbxErrorInfo.Size = new System.Drawing.Size(32, 32);
			this.pbxErrorInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbxErrorInfo.TabIndex = 12;
			this.pbxErrorInfo.TabStop = false;
			// 
			// frmOpenEvents
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(256, 166);
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
			this.Name = "frmOpenEvents";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Confirm Open";
			this.Load += new System.EventHandler(this.frmOpenEvents_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public int Option=0;

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
			this.DialogResult=DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(rbtnEvent.Checked) Option=0;
			if(rbtnCalendarEvt.Checked) Option=1;

			Close();
			this.DialogResult=DialogResult.OK;
		}

		private void frmOpenEvents_Load(object sender, System.EventArgs e)
		{
			ActiveControl = btnOK;

			try
			{
				Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();

		}
	}
}
