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
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int EventID=0;
        private DevExpress.XtraEditors.RadioGroup rdDeleteChoice;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteEvents));
            this.pbxErrorInfo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rdDeleteChoice = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.pbxErrorInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdDeleteChoice.Properties)).BeginInit();
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
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(49, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(134, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rdDeleteChoice
            // 
            this.rdDeleteChoice.EditValue = true;
            this.rdDeleteChoice.Location = new System.Drawing.Point(49, 67);
            this.rdDeleteChoice.Name = "rdDeleteChoice";
            this.rdDeleteChoice.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdDeleteChoice.Properties.Appearance.Options.UseBackColor = true;
            this.rdDeleteChoice.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdDeleteChoice.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Delete this occuerence"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Delete the series")});
            this.rdDeleteChoice.Size = new System.Drawing.Size(225, 55);
            this.rdDeleteChoice.TabIndex = 12;
            // 
            // frmDeleteEvents
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(269, 162);
            this.Controls.Add(this.rdDeleteChoice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxErrorInfo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeleteEvents";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm Delete";
            this.Load += new System.EventHandler(this.frmDeleteEvents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxErrorInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdDeleteChoice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
			if(strMess=="") strMess = evt.CheckProgramEvent();

			if(strMess!="")
			{
				BusinessLayer.Message.MsgWarning("This Event is linked with" + strMess + ".\n\nEvent cannot be deleted.");
				Close();
				this.DialogResult=DialogResult.Cancel;
				return;
			}
            if (Convert.ToBoolean(rdDeleteChoice.EditValue))
            {
                evt.CalendarEventID = CalendarEventID;
                evt.DeleteData(false);
                if (!evt.CheckEventExists(EventID))
                {
                    string module = string.Empty;
                    int _uid = 0;
                    int _eventtypeindex = 0;
                    Events objEvent = new Events();
                    //Returns Course/Program ID
                    _uid = objEvent.GetEvent(EventID, ref module, ref _eventtypeindex);
                    objEvent.EventID = 0;
                    objEvent.UpdateClassEvent(_uid, "EventId");
                }
            }
            else
            {
                evt.DeleteData(true);
                evt.DeleteCalendarEvent();
                string module = string.Empty;
                int _uid = 0;
                int _eventtypeindex = 0;
                Events objEvent = new Events();
                //Returns Course/Program ID
                _uid = objEvent.GetEvent(EventID, ref module, ref _eventtypeindex);
                objEvent.EventID = 0;
                objEvent.UpdateClassEvent(_uid, "EventId");
            }
			

			Close();
			this.DialogResult=DialogResult.OK;
		}

        private void rbtnCalendarEvt_CheckedChanged(object sender, EventArgs e)
        {

        }
	}
}
