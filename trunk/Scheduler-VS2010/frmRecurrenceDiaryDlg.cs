using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Scheduler.BusinessLayer;

namespace Scheduler
{
	public class frm_RecurrenceDiaryDlg : Form
    {
        #region Declarations
        private System.Windows.Forms.RadioButton rdb_Daily;
		private System.Windows.Forms.RadioButton rdb_Weekly;
		private System.Windows.Forms.RadioButton rdb_Monthly;
		private System.Windows.Forms.RadioButton rdb_Yearly;
		private System.Windows.Forms.Label lbl_StartDate;
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.RadioButton rdb_NoofEntries;
		private System.Windows.Forms.RadioButton rdb_EndDate;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txt_NoOfEntries;
		private System.Windows.Forms.GroupBox grpAptTime;
		private System.Windows.Forms.ComboBox cmbStart;
		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.Label lblEnd;
		private System.Windows.Forms.ComboBox cmbEnd;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.GroupBox grpPattern;
		private System.Windows.Forms.ComboBox cmbDurr;
		private System.Windows.Forms.DateTimePicker cmb_FinishDate;
		private System.Windows.Forms.DateTimePicker cmb_StartDate;
		private System.Windows.Forms.GroupBox grpRecurrenceRange;
		private System.Windows.Forms.Panel pnlDaily;
		private System.Windows.Forms.RadioButton rdb_Everyday;
		private System.Windows.Forms.RadioButton rdb_EveryWeekday;
		private System.Windows.Forms.ComboBox cmbWeek;
		private System.Windows.Forms.Panel pnlWeek;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox rbSaturday;
		private System.Windows.Forms.CheckBox rbFriday;
		private System.Windows.Forms.CheckBox rbThursday;
		private System.Windows.Forms.CheckBox rbWednesday;
		private System.Windows.Forms.CheckBox rbTuesday;
		private System.Windows.Forms.CheckBox rbMonday;
		private System.Windows.Forms.CheckBox rbSunday;
		private System.Windows.Forms.TextBox txtWeek;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMonth;
		private System.Windows.Forms.TextBox txtDay;
		private System.Windows.Forms.Panel pnlMonth;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmbMonth;
		private System.Windows.Forms.TextBox txtDD;
		private System.Windows.Forms.Panel pnlYear;

		//Local Variable
		private DateTime dtStartDate=new DateTime(1,1,1);
		private DateTime dtEndDate=new DateTime(1,1,1);
		
		public string StartTimeText="";
		public string EndTimeText="";

		private bool boolNoOfEntries=false;
		private bool boolEndDate=false;
		private bool boolNoEndDate=false;
		private string strWeekDay="";
        private bool IsValid = false;

		private string strMode="";
		private int intTaskID=0;
		private int intRID=0;

		private int intDay=0;
		private System.Windows.Forms.GroupBox grpLine;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;

		private string strAppPath = Application.StartupPath + "\\Recurrence.xml";
        #endregion
        public frm_RecurrenceDiaryDlg(string strTempMode,int TaskID,int intRefID)
		{
			
			InitializeComponent();
			strMode = strTempMode;
			intTaskID = TaskID;
			intRID=intRefID;
			//this.Text = "Recurrence";
            		
		}

		public frm_RecurrenceDiaryDlg(DateTime StartDate, DateTime EndDate, string StartTime, string EndTime)
		{
			
			InitializeComponent();

			try
			{
				//StartTime
				StartTime = Convert.ToDateTime(StartTime).ToString("HH:mm");
				if(StartTime.Substring(0,1)=="0")
				{
					StartTime = StartTime.Substring(1, StartTime.Length-1);
				}
				cmbStart.Text = StartTime;

				//EndTime
				//if(EndTime.IndexOf("(")<0)
				//	EndTime = Convert.ToDateTime(EndTime).ToString("hh:mm tt");
				//if(EndTime.Substring(0,1)=="0")
			//{
				//	EndTime = EndTime.Substring(1, EndTime.Length-1);
				//}
                //SetTime(cmbStart, StartTime);
                DateTime testEnd = Convert.ToDateTime(StartTime);
                if (testEnd.Hour >= 23 && testEnd.Minute >= 30)
                    SetTime(cmbEnd, StartTime);
                else
				    SetTime(cmbEnd, EndTime);
			}
            catch{}

			cmb_StartDate.Value=StartDate;
			if(EndDate==Convert.ToDateTime(null))
			{
				cmb_FinishDate.Value = cmb_StartDate.Value;
			}
			else
			{
				cmb_FinishDate.Value=EndDate;
			}

			SetDuration();
            if (cmbDurr.Text == "Invalid")
            {
                cmbStart.SelectedIndex = 0;
                cmbEnd.Items.Clear();
                int index = cmbStart.SelectedIndex;
                for (int i = index; i < cmbStart.Items.Count; i++)
                    cmbEnd.Items.Add(cmbStart.Items[i]);
                cmbEnd.SelectedIndex = 0;
            }

		}
		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.rdb_Yearly = new System.Windows.Forms.RadioButton();
            this.rdb_Monthly = new System.Windows.Forms.RadioButton();
            this.rdb_Weekly = new System.Windows.Forms.RadioButton();
            this.rdb_Daily = new System.Windows.Forms.RadioButton();
            this.lbl_StartDate = new System.Windows.Forms.Label();
            this.rdb_NoofEntries = new System.Windows.Forms.RadioButton();
            this.rdb_EndDate = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_FinishDate = new System.Windows.Forms.DateTimePicker();
            this.cmb_StartDate = new System.Windows.Forms.DateTimePicker();
            this.txt_NoOfEntries = new System.Windows.Forms.TextBox();
            this.grpAptTime = new System.Windows.Forms.GroupBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmbDurr = new System.Windows.Forms.ComboBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.cmbEnd = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.cmbStart = new System.Windows.Forms.ComboBox();
            this.grpPattern = new System.Windows.Forms.GroupBox();
            this.pnlWeek = new System.Windows.Forms.Panel();
            this.grpLine = new System.Windows.Forms.GroupBox();
            this.rbSaturday = new System.Windows.Forms.CheckBox();
            this.rbFriday = new System.Windows.Forms.CheckBox();
            this.rbThursday = new System.Windows.Forms.CheckBox();
            this.rbWednesday = new System.Windows.Forms.CheckBox();
            this.rbTuesday = new System.Windows.Forms.CheckBox();
            this.rbMonday = new System.Windows.Forms.CheckBox();
            this.rbSunday = new System.Windows.Forms.CheckBox();
            this.txtWeek = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDaily = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbWeek = new System.Windows.Forms.ComboBox();
            this.rdb_EveryWeekday = new System.Windows.Forms.RadioButton();
            this.rdb_Everyday = new System.Windows.Forms.RadioButton();
            this.pnlYear = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.txtDD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlMonth = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpRecurrenceRange = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.grpAptTime.SuspendLayout();
            this.grpPattern.SuspendLayout();
            this.pnlWeek.SuspendLayout();
            this.pnlDaily.SuspendLayout();
            this.pnlYear.SuspendLayout();
            this.pnlMonth.SuspendLayout();
            this.grpRecurrenceRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb_Yearly
            // 
            this.rdb_Yearly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_Yearly.Location = new System.Drawing.Point(8, 80);
            this.rdb_Yearly.Name = "rdb_Yearly";
            this.rdb_Yearly.Size = new System.Drawing.Size(64, 15);
            this.rdb_Yearly.TabIndex = 4;
            this.rdb_Yearly.Text = "Yearly";
            this.rdb_Yearly.CheckedChanged += new System.EventHandler(this.rdb_Yearly_CheckedChanged);
            // 
            // rdb_Monthly
            // 
            this.rdb_Monthly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_Monthly.Location = new System.Drawing.Point(8, 56);
            this.rdb_Monthly.Name = "rdb_Monthly";
            this.rdb_Monthly.Size = new System.Drawing.Size(64, 15);
            this.rdb_Monthly.TabIndex = 3;
            this.rdb_Monthly.Text = "Monthly";
            this.rdb_Monthly.CheckedChanged += new System.EventHandler(this.rdb_Monthly_CheckedChanged);
            // 
            // rdb_Weekly
            // 
            this.rdb_Weekly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_Weekly.Location = new System.Drawing.Point(8, 32);
            this.rdb_Weekly.Name = "rdb_Weekly";
            this.rdb_Weekly.Size = new System.Drawing.Size(64, 15);
            this.rdb_Weekly.TabIndex = 2;
            this.rdb_Weekly.Text = "Weekly";
            this.rdb_Weekly.CheckedChanged += new System.EventHandler(this.rdb_Weekly_CheckedChanged);
            // 
            // rdb_Daily
            // 
            this.rdb_Daily.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_Daily.Location = new System.Drawing.Point(8, 7);
            this.rdb_Daily.Name = "rdb_Daily";
            this.rdb_Daily.Size = new System.Drawing.Size(64, 15);
            this.rdb_Daily.TabIndex = 1;
            this.rdb_Daily.Text = "Daily";
            this.rdb_Daily.CheckedChanged += new System.EventHandler(this.rdb_Daily_CheckedChanged);
            // 
            // lbl_StartDate
            // 
            this.lbl_StartDate.AutoSize = true;
            this.lbl_StartDate.Location = new System.Drawing.Point(16, 26);
            this.lbl_StartDate.Name = "lbl_StartDate";
            this.lbl_StartDate.Size = new System.Drawing.Size(57, 13);
            this.lbl_StartDate.TabIndex = 14;
            this.lbl_StartDate.Text = "Start Date";
            // 
            // rdb_NoofEntries
            // 
            this.rdb_NoofEntries.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_NoofEntries.Location = new System.Drawing.Point(232, 27);
            this.rdb_NoofEntries.Name = "rdb_NoofEntries";
            this.rdb_NoofEntries.Size = new System.Drawing.Size(88, 15);
            this.rdb_NoofEntries.TabIndex = 130;
            this.rdb_NoofEntries.Text = "No. of Entries";
            this.rdb_NoofEntries.CheckedChanged += new System.EventHandler(this.rdb_NoofEntries_CheckedChanged);
            // 
            // rdb_EndDate
            // 
            this.rdb_EndDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_EndDate.Location = new System.Drawing.Point(232, 53);
            this.rdb_EndDate.Name = "rdb_EndDate";
            this.rdb_EndDate.Size = new System.Drawing.Size(88, 15);
            this.rdb_EndDate.TabIndex = 131;
            this.rdb_EndDate.Text = "End Date";
            this.rdb_EndDate.CheckedChanged += new System.EventHandler(this.rdb_EndDate_CheckedChanged);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Cancel.Location = new System.Drawing.Point(398, 292);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 134;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_OK.Location = new System.Drawing.Point(318, 292);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 133;
            this.btn_OK.Text = "OK";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdb_Weekly);
            this.panel1.Controls.Add(this.rdb_Yearly);
            this.panel1.Controls.Add(this.rdb_Daily);
            this.panel1.Controls.Add(this.rdb_Monthly);
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 98);
            this.panel1.TabIndex = 135;
            // 
            // cmb_FinishDate
            // 
            this.cmb_FinishDate.CustomFormat = "MM/dd/yyyy";
            this.cmb_FinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmb_FinishDate.Location = new System.Drawing.Point(336, 50);
            this.cmb_FinishDate.Name = "cmb_FinishDate";
            this.cmb_FinishDate.Size = new System.Drawing.Size(104, 21);
            this.cmb_FinishDate.TabIndex = 241;
            this.cmb_FinishDate.ValueChanged += new System.EventHandler(this.cmb_FinishDate_ValueChanged);
            // 
            // cmb_StartDate
            // 
            this.cmb_StartDate.CustomFormat = "MM/dd/yyyy";
            this.cmb_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmb_StartDate.Location = new System.Drawing.Point(88, 24);
            this.cmb_StartDate.Name = "cmb_StartDate";
            this.cmb_StartDate.Size = new System.Drawing.Size(104, 21);
            this.cmb_StartDate.TabIndex = 240;
            // 
            // txt_NoOfEntries
            // 
            this.txt_NoOfEntries.Location = new System.Drawing.Point(336, 24);
            this.txt_NoOfEntries.MaxLength = 3;
            this.txt_NoOfEntries.Name = "txt_NoOfEntries";
            this.txt_NoOfEntries.Size = new System.Drawing.Size(32, 21);
            this.txt_NoOfEntries.TabIndex = 135;
            this.txt_NoOfEntries.Text = "0";
            this.txt_NoOfEntries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpAptTime
            // 
            this.grpAptTime.Controls.Add(this.lblDuration);
            this.grpAptTime.Controls.Add(this.cmbDurr);
            this.grpAptTime.Controls.Add(this.lblEnd);
            this.grpAptTime.Controls.Add(this.cmbEnd);
            this.grpAptTime.Controls.Add(this.lblStart);
            this.grpAptTime.Controls.Add(this.cmbStart);
            this.grpAptTime.ForeColor = System.Drawing.Color.Black;
            this.grpAptTime.Location = new System.Drawing.Point(8, 10);
            this.grpAptTime.Name = "grpAptTime";
            this.grpAptTime.Size = new System.Drawing.Size(464, 47);
            this.grpAptTime.TabIndex = 137;
            this.grpAptTime.TabStop = false;
            this.grpAptTime.Text = "Appointment Time";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(296, 19);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(48, 13);
            this.lblDuration.TabIndex = 263;
            this.lblDuration.Text = "Duration";
            // 
            // cmbDurr
            // 
            this.cmbDurr.DropDownWidth = 75;
            this.cmbDurr.Location = new System.Drawing.Point(352, 17);
            this.cmbDurr.Name = "cmbDurr";
            this.cmbDurr.Size = new System.Drawing.Size(88, 21);
            this.cmbDurr.TabIndex = 262;
            this.cmbDurr.SelectedIndexChanged += new System.EventHandler(this.cmbDurr_SelectedIndexChanged);
            this.cmbDurr.TabIndexChanged += new System.EventHandler(this.cmbDurr_TabIndexChanged);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(146, 19);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(25, 13);
            this.lblEnd.TabIndex = 261;
            this.lblEnd.Text = "End";
            // 
            // cmbEnd
            // 
            this.cmbEnd.DropDownWidth = 140;
            this.cmbEnd.Items.AddRange(new object[] {
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cmbEnd.Location = new System.Drawing.Point(186, 17);
            this.cmbEnd.Name = "cmbEnd";
            this.cmbEnd.Size = new System.Drawing.Size(75, 21);
            this.cmbEnd.TabIndex = 260;
            this.cmbEnd.Leave += new System.EventHandler(this.cmbEnd_Leave);
            this.cmbEnd.TextChanged += new System.EventHandler(this.cmbEnd_TextChanged);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(14, 19);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(31, 13);
            this.lblStart.TabIndex = 259;
            this.lblStart.Text = "Start";
            // 
            // cmbStart
            // 
            this.cmbStart.DropDownWidth = 75;
            this.cmbStart.Items.AddRange(new object[] {
            "01:00",
            "01:30",
            "02:00",
            "02:30",
            "03:00",
            "03:30",
            "04:00",
            "04:30",
            "05:00",
            "05:30",
            "06:00",
            "06:30",
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.cmbStart.Location = new System.Drawing.Point(56, 17);
            this.cmbStart.Name = "cmbStart";
            this.cmbStart.Size = new System.Drawing.Size(75, 21);
            this.cmbStart.TabIndex = 258;
            this.cmbStart.Leave += new System.EventHandler(this.cmbStart_Leave);
            this.cmbStart.SelectedIndexChanged += new System.EventHandler(this.cmbStart_SelectedIndexChanged);
            this.cmbStart.TextChanged += new System.EventHandler(this.cmbStart_TextChanged);
            // 
            // grpPattern
            // 
            this.grpPattern.Controls.Add(this.panel1);
            this.grpPattern.Controls.Add(this.pnlWeek);
            this.grpPattern.Controls.Add(this.pnlDaily);
            this.grpPattern.Controls.Add(this.pnlYear);
            this.grpPattern.Controls.Add(this.pnlMonth);
            this.grpPattern.Location = new System.Drawing.Point(8, 62);
            this.grpPattern.Name = "grpPattern";
            this.grpPattern.Size = new System.Drawing.Size(464, 120);
            this.grpPattern.TabIndex = 138;
            this.grpPattern.TabStop = false;
            this.grpPattern.Text = "Recurrence Pattern";
            // 
            // pnlWeek
            // 
            this.pnlWeek.Controls.Add(this.grpLine);
            this.pnlWeek.Controls.Add(this.rbSaturday);
            this.pnlWeek.Controls.Add(this.rbFriday);
            this.pnlWeek.Controls.Add(this.rbThursday);
            this.pnlWeek.Controls.Add(this.rbWednesday);
            this.pnlWeek.Controls.Add(this.rbTuesday);
            this.pnlWeek.Controls.Add(this.rbMonday);
            this.pnlWeek.Controls.Add(this.rbSunday);
            this.pnlWeek.Controls.Add(this.txtWeek);
            this.pnlWeek.Controls.Add(this.label2);
            this.pnlWeek.Controls.Add(this.label1);
            this.pnlWeek.Location = new System.Drawing.Point(86, 13);
            this.pnlWeek.Name = "pnlWeek";
            this.pnlWeek.Size = new System.Drawing.Size(370, 97);
            this.pnlWeek.TabIndex = 137;
            // 
            // grpLine
            // 
            this.grpLine.Location = new System.Drawing.Point(6, 2);
            this.grpLine.Name = "grpLine";
            this.grpLine.Size = new System.Drawing.Size(2, 94);
            this.grpLine.TabIndex = 142;
            this.grpLine.TabStop = false;
            // 
            // rbSaturday
            // 
            this.rbSaturday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbSaturday.Location = new System.Drawing.Point(192, 62);
            this.rbSaturday.Name = "rbSaturday";
            this.rbSaturday.Size = new System.Drawing.Size(71, 24);
            this.rbSaturday.TabIndex = 7;
            this.rbSaturday.Text = "Saturday";
            this.rbSaturday.CheckedChanged += new System.EventHandler(this.rdb_Saturday_CheckedChanged);
            // 
            // rbFriday
            // 
            this.rbFriday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbFriday.Location = new System.Drawing.Point(118, 62);
            this.rbFriday.Name = "rbFriday";
            this.rbFriday.Size = new System.Drawing.Size(51, 24);
            this.rbFriday.TabIndex = 6;
            this.rbFriday.Text = "Friday";
            this.rbFriday.CheckedChanged += new System.EventHandler(this.rdb_Friday_CheckedChanged);
            // 
            // rbThursday
            // 
            this.rbThursday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbThursday.Location = new System.Drawing.Point(34, 62);
            this.rbThursday.Name = "rbThursday";
            this.rbThursday.Size = new System.Drawing.Size(70, 24);
            this.rbThursday.TabIndex = 5;
            this.rbThursday.Text = "Thursday";
            this.rbThursday.CheckedChanged += new System.EventHandler(this.rdb_Thrusday_CheckedChanged);
            // 
            // rbWednesday
            // 
            this.rbWednesday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbWednesday.Location = new System.Drawing.Point(272, 36);
            this.rbWednesday.Name = "rbWednesday";
            this.rbWednesday.Size = new System.Drawing.Size(77, 24);
            this.rbWednesday.TabIndex = 4;
            this.rbWednesday.Text = "Wednesday";
            this.rbWednesday.CheckedChanged += new System.EventHandler(this.rdb_Wednesday_CheckedChanged);
            // 
            // rbTuesday
            // 
            this.rbTuesday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbTuesday.Location = new System.Drawing.Point(192, 36);
            this.rbTuesday.Name = "rbTuesday";
            this.rbTuesday.Size = new System.Drawing.Size(63, 24);
            this.rbTuesday.TabIndex = 3;
            this.rbTuesday.Text = "Tuesday";
            this.rbTuesday.CheckedChanged += new System.EventHandler(this.rdb_Tuesday_CheckedChanged);
            // 
            // rbMonday
            // 
            this.rbMonday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbMonday.Location = new System.Drawing.Point(118, 36);
            this.rbMonday.Name = "rbMonday";
            this.rbMonday.Size = new System.Drawing.Size(59, 24);
            this.rbMonday.TabIndex = 2;
            this.rbMonday.Text = "Monday";
            this.rbMonday.CheckedChanged += new System.EventHandler(this.rdb_Monday_CheckedChanged);
            // 
            // rbSunday
            // 
            this.rbSunday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbSunday.Location = new System.Drawing.Point(34, 36);
            this.rbSunday.Name = "rbSunday";
            this.rbSunday.Size = new System.Drawing.Size(62, 24);
            this.rbSunday.TabIndex = 1;
            this.rbSunday.Text = "Sunday";
            this.rbSunday.CheckedChanged += new System.EventHandler(this.rdb_Sunday_CheckedChanged);
            // 
            // txtWeek
            // 
            this.txtWeek.Location = new System.Drawing.Point(109, 10);
            this.txtWeek.MaxLength = 2;
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.Size = new System.Drawing.Size(34, 21);
            this.txtWeek.TabIndex = 0;
            this.txtWeek.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(154, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Week(s) on:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recur every";
            // 
            // pnlDaily
            // 
            this.pnlDaily.Controls.Add(this.groupBox1);
            this.pnlDaily.Controls.Add(this.cmbWeek);
            this.pnlDaily.Controls.Add(this.rdb_EveryWeekday);
            this.pnlDaily.Controls.Add(this.rdb_Everyday);
            this.pnlDaily.Location = new System.Drawing.Point(86, 16);
            this.pnlDaily.Name = "pnlDaily";
            this.pnlDaily.Size = new System.Drawing.Size(337, 97);
            this.pnlDaily.TabIndex = 136;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2, 94);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            // 
            // cmbWeek
            // 
            this.cmbWeek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbWeek.Location = new System.Drawing.Point(137, 36);
            this.cmbWeek.Name = "cmbWeek";
            this.cmbWeek.Size = new System.Drawing.Size(122, 21);
            this.cmbWeek.TabIndex = 2;
            this.cmbWeek.Text = "Monday";
            // 
            // rdb_EveryWeekday
            // 
            this.rdb_EveryWeekday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_EveryWeekday.Location = new System.Drawing.Point(34, 38);
            this.rdb_EveryWeekday.Name = "rdb_EveryWeekday";
            this.rdb_EveryWeekday.Size = new System.Drawing.Size(102, 16);
            this.rdb_EveryWeekday.TabIndex = 1;
            this.rdb_EveryWeekday.Text = "Every Weekday";
            this.rdb_EveryWeekday.CheckedChanged += new System.EventHandler(this.rdb_EveryWeekday_CheckedChanged);
            // 
            // rdb_Everyday
            // 
            this.rdb_Everyday.Checked = true;
            this.rdb_Everyday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdb_Everyday.Location = new System.Drawing.Point(34, 14);
            this.rdb_Everyday.Name = "rdb_Everyday";
            this.rdb_Everyday.Size = new System.Drawing.Size(78, 16);
            this.rdb_Everyday.TabIndex = 0;
            this.rdb_Everyday.TabStop = true;
            this.rdb_Everyday.Text = "Everyday";
            this.rdb_Everyday.CheckedChanged += new System.EventHandler(this.rdb_Everyday_CheckedChanged);
            // 
            // pnlYear
            // 
            this.pnlYear.Controls.Add(this.groupBox2);
            this.pnlYear.Controls.Add(this.cmbMonth);
            this.pnlYear.Controls.Add(this.txtDD);
            this.pnlYear.Controls.Add(this.label8);
            this.pnlYear.Location = new System.Drawing.Point(86, 13);
            this.pnlYear.Name = "pnlYear";
            this.pnlYear.Size = new System.Drawing.Size(337, 97);
            this.pnlYear.TabIndex = 139;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2, 94);
            this.groupBox2.TabIndex = 143;
            this.groupBox2.TabStop = false;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(80, 22);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(104, 21);
            this.cmbMonth.TabIndex = 0;
            this.cmbMonth.Text = "January";
            // 
            // txtDD
            // 
            this.txtDD.Location = new System.Drawing.Point(189, 22);
            this.txtDD.MaxLength = 2;
            this.txtDD.Name = "txtDD";
            this.txtDD.Size = new System.Drawing.Size(34, 21);
            this.txtDD.TabIndex = 1;
            this.txtDD.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(40, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Every";
            // 
            // pnlMonth
            // 
            this.pnlMonth.Controls.Add(this.groupBox3);
            this.pnlMonth.Controls.Add(this.label5);
            this.pnlMonth.Controls.Add(this.txtMonth);
            this.pnlMonth.Controls.Add(this.txtDay);
            this.pnlMonth.Controls.Add(this.label3);
            this.pnlMonth.Controls.Add(this.label4);
            this.pnlMonth.Location = new System.Drawing.Point(86, 13);
            this.pnlMonth.Name = "pnlMonth";
            this.pnlMonth.Size = new System.Drawing.Size(337, 97);
            this.pnlMonth.TabIndex = 138;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(6, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(2, 94);
            this.groupBox3.TabIndex = 143;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(206, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "month(s)";
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(160, 22);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(34, 21);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.Text = "1";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(63, 22);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(34, 21);
            this.txtDay.TabIndex = 0;
            this.txtDay.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(109, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "of every";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(34, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Day";
            // 
            // grpRecurrenceRange
            // 
            this.grpRecurrenceRange.Controls.Add(this.cmb_StartDate);
            this.grpRecurrenceRange.Controls.Add(this.cmb_FinishDate);
            this.grpRecurrenceRange.Controls.Add(this.lbl_StartDate);
            this.grpRecurrenceRange.Controls.Add(this.txt_NoOfEntries);
            this.grpRecurrenceRange.Controls.Add(this.rdb_NoofEntries);
            this.grpRecurrenceRange.Controls.Add(this.rdb_EndDate);
            this.grpRecurrenceRange.Location = new System.Drawing.Point(8, 192);
            this.grpRecurrenceRange.Name = "grpRecurrenceRange";
            this.grpRecurrenceRange.Size = new System.Drawing.Size(464, 88);
            this.grpRecurrenceRange.TabIndex = 139;
            this.grpRecurrenceRange.TabStop = false;
            this.grpRecurrenceRange.Text = "Range of Recurrence";
            // 
            // frm_RecurrenceDiaryDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(482, 327);
            this.Controls.Add(this.grpRecurrenceRange);
            this.Controls.Add(this.grpAptTime);
            this.Controls.Add(this.grpPattern);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_RecurrenceDiaryDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment Recurrence";
            this.Load += new System.EventHandler(this.frm_RecurrenceDiaryDlg_Load);
            this.panel1.ResumeLayout(false);
            this.grpAptTime.ResumeLayout(false);
            this.grpAptTime.PerformLayout();
            this.grpPattern.ResumeLayout(false);
            this.pnlWeek.ResumeLayout(false);
            this.pnlWeek.PerformLayout();
            this.pnlDaily.ResumeLayout(false);
            this.pnlYear.ResumeLayout(false);
            this.pnlYear.PerformLayout();
            this.pnlMonth.ResumeLayout(false);
            this.pnlMonth.PerformLayout();
            this.grpRecurrenceRange.ResumeLayout(false);
            this.grpRecurrenceRange.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Form Load
		private void frm_RecurrenceDiaryDlg_Load(object sender, System.EventArgs e)
		{
			try
			{
				Common.SetControlFont(this);
				Common.SetControlFont(grpAptTime);
				Common.SetControlFont(grpPattern);
				Common.SetControlFont(grpRecurrenceRange);
				Common.SetControlFont(panel1);
				Common.SetControlFont(pnlDaily);
				Common.SetControlFont(pnlWeek);
				Common.SetControlFont(pnlMonth);
				Common.SetControlFont(pnlYear);
			}

			catch{}
			this.Refresh();

			Serialize AP = new Serialize();
			AP = AP.Load(strAppPath);
			if(!setToConfig(AP))
			{
				txt_NoOfEntries.Text="10";
				rdb_Daily.Checked=true;
				rdb_EndDate.Checked=true;
			}
		}

		#endregion Form Load

		#region RadioButton Daily Change
		private void rdb_Daily_CheckedChanged(object sender, System.EventArgs e)
		{
			
			if(this.rdb_Daily.Checked==true)
			{
				pnlWeek.Visible=false;
				pnlMonth.Visible=false;
				pnlYear.Visible=false;

				//pnlDaily.Location = new System.Drawing.Point(120, 16);
				pnlDaily.Visible=true;
			}
			else 
			{
				if((rdb_Weekly.Checked==true)||(rdb_Monthly.Checked==true)||(rdb_Yearly.Checked==true))
				{
					pnlDaily.Visible=false;
				}
			}

		}

		private void rdb_Everyday_CheckedChanged(object sender, System.EventArgs e)
		{
		}
		private void rdb_EveryWeekday_CheckedChanged(object sender, System.EventArgs e)
		{
		}
		#endregion RadioButton Daily Change

		#region RadioButton Weekly Change
		private void rdb_Weekly_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.rdb_Weekly.Checked==true)
			{
				pnlDaily.Visible=false;
				pnlMonth.Visible=false;
				pnlYear.Visible=false;

				//pnlWeek.Location = new System.Drawing.Point(104, 17);
				pnlWeek.Visible=true;

			}
			else 
			{
				if((rdb_Daily.Checked==true)||(rdb_Monthly.Checked==true)||(rdb_Yearly.Checked==true))
				{
					pnlWeek.Visible=false;
				}
				
			}


		}

		private void rdb_Sunday_CheckedChanged(object sender, System.EventArgs e)
		{
			intDay=0;
			strWeekDay="Sunday";
		}

		private void rdb_Monday_CheckedChanged(object sender, System.EventArgs e)
		{
			intDay=1;
			strWeekDay="Monday";
		}

		private void rdb_Tuesday_CheckedChanged(object sender, System.EventArgs e)
		{
			intDay=2;
			strWeekDay="Tuesday";
		}

		private void rdb_Wednesday_CheckedChanged(object sender, System.EventArgs e)
		{
			intDay=3;
			strWeekDay="Wednesday";
		}

		private void rdb_Thrusday_CheckedChanged(object sender, System.EventArgs e)
		{
			intDay=4;
			strWeekDay="Thursday";
		}
		private void rdb_Friday_CheckedChanged(object sender, System.EventArgs e)
		{
			intDay=5;
			strWeekDay="Friday";
		}

		private void rdb_Saturday_CheckedChanged(object sender, System.EventArgs e)
		{
			intDay=6;
			strWeekDay="Saturday";

		}

		#endregion RadioButton Weekly Change

		#region RadioButton Monthly Change

		private void rdb_Monthly_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdb_Monthly.Checked==true)
			{
				pnlDaily.Visible=false;
				pnlWeek.Visible=false;
				pnlYear.Visible=false;

				//pnlMonth.Location=new System.Drawing.Point(104, 19);
				pnlMonth.Visible=true;				
			}
			else if((rdb_Daily.Checked==true)||(rdb_Weekly.Checked==true)||(rdb_Yearly.Checked==true))
			{
				pnlMonth.Visible=false;
			}
		
		}

		#endregion RadioButton Weekly Change

		#region RadioButton Yearly Change

		private void rdb_Yearly_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdb_Yearly.Checked==true)
			{
				pnlDaily.Visible=false;
				pnlWeek.Visible=false;
				pnlMonth.Visible=false;

				//pnlYear.Location=new System.Drawing.Point(104, 18);
				pnlYear.Visible=true;
				
			}
			else if((rdb_Daily.Checked==true)||(rdb_Weekly.Checked==true)||(rdb_Monthly.Checked==true))
			{
				pnlYear.Visible=false;
			}
		
		}


		#endregion RadioButton Yearly Change
		
		#region Function
		
	
		private static bool IsBlankDate(DateTime dt)
		{
			if ((dt.Year == 1) && (dt.Month == 1) && (dt.Day == 1) && (dt.Hour == 0) &&
				(dt.Minute == 0) && (dt.Second == 0))
			{
				return true;
			}
			return false;
		}
	
		#endregion Function

		#region StartDate / No of Entries / EndDate

		private void rdb_NoofEntries_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdb_NoofEntries.Checked==true)
			{
				boolNoOfEntries=true;
				txt_NoOfEntries.Text="10";
			}
			else
			{
                boolNoOfEntries=false;
				txt_NoOfEntries.Text="";
			}

		}

		private void rdb_EndDate_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdb_EndDate.Checked==true)
			{
				boolEndDate=true;
			}
			else
			{
				boolEndDate=false;
			}
		
		}

		#endregion StartDate / No of Entries / EndDate

		#region Valid All Fields()
		private bool ValidAllFields()
		{
            if (Convert.ToDateTime(cmbEnd.Text) < Convert.ToDateTime(cmbStart.Text))
            {
                BusinessLayer.Message.MsgInformation("Invalid End Time!");
                cmbEnd.Focus();
                return false;
            }
            
            if(rdb_NoofEntries.Checked)
			{
				if(txt_NoOfEntries.Text=="")
				{
					BusinessLayer.Message.MsgInformation("No. of Entries cannot be blank");
					txt_NoOfEntries.Focus();
					return false;
				}
				if(txt_NoOfEntries.Text=="0")
				{
					BusinessLayer.Message.MsgInformation("Enter No. of Entries");
					txt_NoOfEntries.Focus();
					return false;
				}
			}
			if(rdb_Daily.Checked==true)
			{
				if((rdb_Everyday.Checked==false)&&(rdb_EveryWeekday.Checked==false))
				{
					BusinessLayer.Message.MsgInformation("Choose any Daily recurrence");
					return false;
				}
				if(rdb_EveryWeekday.Checked==true)
				{
					if(rdb_EndDate.Checked==true)
					{
						bool boolHasDay=false;
						DateTime dtSDate=cmb_StartDate.Value;
						DateTime dtEDate=cmb_FinishDate.Value;
						while(dtSDate<=dtEDate)
						{
							int intDay=Convert.ToInt32(dtSDate.DayOfWeek);
							
							if((intDay==0)||(intDay==6))
							{
								boolHasDay=false;
								
							}
							else
							{
								boolHasDay=true;
								break;
							}
							
							dtSDate=dtSDate.AddDays(1);
						}
						if(boolHasDay==false)
						{
							BusinessLayer.Message.MsgInformation("There are no recurring entries to be generated between Start Date and End Date");
							cmb_FinishDate.Focus();
							return false;
						}
					}
				}
			}
			if(rdb_Weekly.Checked==true)
			{
				if(Convert.ToInt16(txtWeek.Text)<1)
				{
					BusinessLayer.Message.MsgInformation("Please enter a value between 1 to 10");
					txtWeek.Focus();
					return false;
				}
				if(Convert.ToInt16(txtWeek.Text)>10)
				{
					BusinessLayer.Message.MsgInformation("Please enter a value between 1 to 10");
					txtWeek.Focus();
					return false;
				}
				if((rbSunday.Checked==false)&&(rbMonday.Checked==false)&&(rbTuesday.Checked==false)&&(rbWednesday.Checked==false)&&(rbThursday.Checked==false)&&(rbFriday.Checked==false)&&(rbSaturday.Checked==false))
				{
					BusinessLayer.Message.MsgInformation("Choose any Weekly recurrence");
					return false;
				}
				if(rdb_EndDate.Checked==true)
				{
					if(Common.IsBlankDate(cmb_FinishDate.Value))
					{
						BusinessLayer.Message.MsgInformation("Enter End Date");
						cmb_FinishDate.Focus();
						return false;
					} 

					if(cmb_FinishDate.Value<cmb_StartDate.Value)
					{
						BusinessLayer.Message.MsgInformation("Start Date must be before End Date");
						//cmb_FinishDate.Value=Convert.ToDateTime(null);
						cmb_FinishDate.Focus();
						return false;
					}

					bool boolHasDay=false;
					DateTime dtSDate=cmb_StartDate.Value;
					DateTime dtEDate=cmb_FinishDate.Value;
					while(dtSDate<=dtEDate)
					{
						if(intDay==Convert.ToInt32(dtSDate.DayOfWeek))
						{
							boolHasDay=true;
						  
						}
						dtSDate=dtSDate.AddDays(1);
					}
					if(boolHasDay==false)
					{
						BusinessLayer.Message.MsgInformation("There are no recurring entries to be generated between Start Date and End Date");
						cmb_FinishDate.Focus();
						return false;
					}
				}
			}
			if(rdb_Monthly.Checked==true)
			{
				if(txtDay.Text=="")
				{
					BusinessLayer.Message.MsgInformation("Enter Day");
					txtDay.Focus();
					return false;
				}
				if(Convert.ToInt16(txtDay.Text)<0)
				{
					BusinessLayer.Message.MsgInformation("Enter positive value");
					txtDay.Text="";
					txtDay.Focus();
					return false;
				}
				if((Convert.ToInt16(txtDay.Text)>31)||(Convert.ToInt16(txtDay.Text)==0))
				{
					BusinessLayer.Message.MsgInformation("Day No. must be between 1 to 31");
					txtDay.Text="";
					txtDay.Focus();
					return false;
				}
				if(Convert.ToInt16(txtMonth.Text)<1)
				{
					BusinessLayer.Message.MsgInformation("Please enter a value between 1 to 10");
					txtMonth.Focus();
					return false;
				}
				if(Convert.ToInt16(txtMonth.Text)>10)
				{
					BusinessLayer.Message.MsgInformation("Please enter a value between 1 to 10");
					txtMonth.Focus();
					return false;
				}
				if(rdb_EndDate.Checked==true)
				{
					if(Common.IsBlankDate(cmb_FinishDate.Value))
					{
						BusinessLayer.Message.MsgInformation("Enter End Date");
						cmb_FinishDate.Focus();
						return false;
					}

					if(cmb_FinishDate.Value<cmb_StartDate.Value)
					{
						BusinessLayer.Message.MsgInformation("Start Date must be before End Date");
						//cmb_FinishDate.Value=Convert.ToDateTime(null);
						cmb_FinishDate.Focus();
						return false;
					}

					bool boolHasDay=false;
					DateTime dtSDate=cmb_StartDate.Value;
					DateTime dtEDate=cmb_FinishDate.Value;
					while(dtSDate<=dtEDate)
					{
						if(Convert.ToInt32(txtDay.Text)==dtSDate.Day)
						{
							boolHasDay=true;
							break;
						}
						dtSDate=dtSDate.AddDays(1);
					}
					if(boolHasDay==false)
					{
						BusinessLayer.Message.MsgInformation("There are no recurring entries to be generated between Start Date and End Date");
						cmb_FinishDate.Focus();
						return false;
					}
				}
				
			}
			if(rdb_Yearly.Checked==true)
			{
				if(cmbMonth.SelectedIndex<0)
				{
					BusinessLayer.Message.MsgInformation("Enter Month");
					cmbMonth.Focus();
					return false;
				}
				if(txtDD.Text=="")
				{
					BusinessLayer.Message.MsgInformation("Enter Day");
					txtDD.Focus();
					return false;
				}
				if(Convert.ToInt16(txtDD.Text)<0)
				{
					BusinessLayer.Message.MsgInformation("Enter positive value");
					txtDD.Text="";
					txtDD.Focus();
					return false;
				}
				if((cmbMonth.SelectedIndex==0)||(cmbMonth.SelectedIndex==2)||(cmbMonth.SelectedIndex==4)||(cmbMonth.SelectedIndex==6)||(cmbMonth.SelectedIndex==7)||(cmbMonth.SelectedIndex==9)||(cmbMonth.SelectedIndex==11))
				{
					if((Convert.ToInt16(txtDD.Text)>31)||(Convert.ToInt16(txtDD.Text)==0))
					{
						BusinessLayer.Message.MsgInformation("Day No. must be between 1 to 31");
						txtDD.Text="";
						txtDD.Focus();
						return false;
					}
				
				}
				if((cmbMonth.SelectedIndex==3)||(cmbMonth.SelectedIndex==5)||(cmbMonth.SelectedIndex==8)||(cmbMonth.SelectedIndex==10))
				{
					if((Convert.ToInt16(txtDD.Text)>30)||(Convert.ToInt16(txtDD.Text)==0))
					{
						BusinessLayer.Message.MsgInformation("Day No. must be between 1 to 30");
						txtDD.Text="";
						txtDD.Focus();
						return false;
					}
				}
				if(cmbMonth.SelectedIndex==1)
				{
					if((Convert.ToInt16(txtDD.Text)>29)||(Convert.ToInt16(txtDD.Text)==0))
					{
						BusinessLayer.Message.MsgInformation("Day No. must be between 1 to 29");
						txtDD.Text="";
						txtDD.Focus();
						return false;
					}
				}
				if(rdb_EndDate.Checked==true)
				{
					if(Common.IsBlankDate(cmb_FinishDate.Value))
					{
						BusinessLayer.Message.MsgInformation("Enter End Date");
						cmb_FinishDate.Focus();
						return false;
					}
										
					if(cmb_FinishDate.Value<cmb_StartDate.Value)
					{
						BusinessLayer.Message.MsgInformation("Start Date must be before End Date");
						//cmb_FinishDate.Value=Convert.ToDateTime(null);
						cmb_FinishDate.Focus();
						return false;
					}

					DateTime dtSDate=cmb_StartDate.Value;
					DateTime dtEDate=cmb_FinishDate.Value;
					DateTime dtFirstDate=Common.GetDate(txtDD.Text,Convert.ToString(cmbMonth.SelectedIndex+1),System.DateTime.Now.Year.ToString());
					DateTime dtLastDate=dtFirstDate.AddYears(1);
					if((dtSDate>dtFirstDate)&&(dtEDate<dtLastDate))
					{
						BusinessLayer.Message.MsgInformation("There are no recurring entries to be generated between Start Date and End Date");
						cmb_StartDate.Focus();
						return false;
					}
					if((dtSDate<dtFirstDate)&&(dtEDate<dtFirstDate))
					{
						BusinessLayer.Message.MsgInformation("There are no recurring entries to be generated between Start Date and End Date");
						cmb_StartDate.Focus();
						return false;
					}
				}
				
			}
			if(Common.IsBlankDate(cmb_StartDate.Value))
			{
				BusinessLayer.Message.MsgInformation("Enter Start Date");
				cmb_StartDate.Focus();
				return false;
			}
			if(rdb_NoofEntries.Checked==true)
			{
				if(Convert.ToInt16(txt_NoOfEntries.Text)==0)
				{
					BusinessLayer.Message.MsgInformation("Enter No. of Entries");
					txt_NoOfEntries.Focus();
					return false;
				}
				if(Convert.ToInt16(txt_NoOfEntries.Text)<0)
				{
					BusinessLayer.Message.MsgInformation("Enter positive  value");
					txt_NoOfEntries.Text="";
					txt_NoOfEntries.Focus();
					return false;
				}
				
			}
			if(rdb_EndDate.Checked==true)
			{
				if(Common.IsBlankDate(cmb_FinishDate.Value))
				{
					BusinessLayer.Message.MsgInformation("Enter End Date");
					cmb_FinishDate.Focus();
					return false;
				}
				
				try
				{
					string strStart = cmb_StartDate.Value.ToShortDateString() + " " + cmbStart.Text;
					string strFinish = cmb_FinishDate.Value.ToShortDateString() + " " + cmbEnd.Text;
					cmb_StartDate.Value = Convert.ToDateTime(strStart);
					cmb_FinishDate.Value = Convert.ToDateTime(strFinish);
				}
				catch{}
				if(!rdb_NoofEntries.Checked)
				{
					if(cmb_FinishDate.Value<cmb_StartDate.Value)
					{
						BusinessLayer.Message.MsgInformation("Start Date/Time must be before End Date/Time");
						cmb_FinishDate.Focus();
						return false;
					}
				}
			}

						
			return true;
		
		}
		#endregion ValidAllFields()

		#region Button Click
		private void btn_OK_Click(object sender, System.EventArgs e)
		{
            IsValid = ValidAllFields();
            if (IsValid)
            {
                Serialize AP = new Serialize();
                AP = saveToConfig(AP);
                AP.Save(strAppPath);

                StartTimeText = cmbStart.Text;
                EndTimeText = cmbEnd.Text;

                this.DialogResult = DialogResult.OK;
                //this.Close();
                //this.Dispose();
            }
		
		}

		private void btn_Cancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


		#endregion Button Click

		public bool setToConfig(Serialize AP)
		{
			if(AP==null) return false;
			string StartDate = AP.StartDate;
			string strEndDate = AP.StartDate;
			string NoEntries = AP.NoEntries;
			string ReccType = AP.ReccType;
			string Pattern1 = AP.Pattern1;
			string Pattern2 = AP.Pattern2;

			if(StartDate=="") return false;

			try
			{
				if(AP.StartDate!="") cmb_StartDate.Value=Convert.ToDateTime(AP.StartDate);
				if(AP.EndDate!="") cmb_FinishDate.Value=Convert.ToDateTime(AP.EndDate);
			}
			catch{}
			
			txt_NoOfEntries.Text = AP.NoEntries;
			if(ReccType=="Daily")
			{
				rdb_Daily.Checked=true;
				if(Pattern1!="")
				{
					rdb_Everyday.Checked=true;
				}
				else
				{
					rdb_EveryWeekday.Checked=true;
					cmbWeek.Text = Pattern2;
				}
			}
			else if(ReccType=="Weekly")
			{
				rdb_Weekly.Checked=true;
				txtWeek.Text = Pattern1;

				string[] arr = Pattern2.Split(new char[]{'|'});

				foreach(string s in arr)
				{
					if(s!="")
					{
						if(s=="Monday") rbMonday.Checked=true;
						if(s=="Tuesday") rbTuesday.Checked=true;
						if(s=="Wednesday") rbWednesday.Checked=true;
						if(s=="Thursday") rbThursday.Checked=true;
						if(s=="Friday") rbFriday.Checked=true;
						if(s=="Saturday") rbSaturday.Checked=true;
						if(s=="Sunday") rbSunday.Checked=true;
					}
				}
			}
			else if(ReccType=="Monthly")
			{
				rdb_Monthly.Checked=true;
				txtDay.Text = Pattern1;
				txtMonth.Text = Pattern2;
			}
			else if(ReccType=="Yearly")
			{
				rdb_Yearly.Checked=true;
				if(Pattern1=="January") cmbMonth.SelectedIndex=0;
				if(Pattern1=="February") cmbMonth.SelectedIndex=1;
				if(Pattern1=="March") cmbMonth.SelectedIndex=2;
				if(Pattern1=="April") cmbMonth.SelectedIndex=3;
				if(Pattern1=="May") cmbMonth.SelectedIndex=4;
				if(Pattern1=="June") cmbMonth.SelectedIndex=5;
				if(Pattern1=="July") cmbMonth.SelectedIndex=6;
				if(Pattern1=="August") cmbMonth.SelectedIndex=7;
				if(Pattern1=="September") cmbMonth.SelectedIndex=8;
				if(Pattern1=="October") cmbMonth.SelectedIndex=9;
				if(Pattern1=="November") cmbMonth.SelectedIndex=10;
				if(Pattern1=="December") cmbMonth.SelectedIndex=11;

				txtDD.Text = Pattern2;
			}

			if(NoEntries=="")
			{
				rdb_EndDate.Checked=true;
			}
			else
			{
				rdb_NoofEntries.Checked=true;
				txt_NoOfEntries.Text = NoEntries;
			}

			return true;
		}

		public Serialize saveToConfig(Serialize AP)
		{
			string StartTime="";
			string EndTime="";

			int startlength=0;
			int endlength=0;

			AP.StartDate = cmb_StartDate.Value.ToString();
			AP.EndDate = cmb_FinishDate.Value.ToString();

			try
			{
				startlength = cmbStart.Text.Length;
				endlength = cmbEnd.Text.Length;

				//StartTime = cmb_StartDate.Value.ToShortDateString() + " " + cmbStart.Text.Substring(0,startlength).Trim();
				//EndTime = cmb_FinishDate.Value.ToShortDateString() + " " + cmbEnd.Text.Substring(0,8).Trim();

				StartTime = cmb_StartDate.Value.ToShortDateString() + " " + cmbStart.Text.Trim();
				EndTime = cmb_FinishDate.Value.ToShortDateString() + " " + cmbEnd.Text.Trim();

				AP.StartDate=StartTime;
				AP.EndDate=EndTime;
			}
			catch{}

			
			AP.NoEntries="";
			if(rdb_NoofEntries.Checked) 
			{
				AP.NoEntries = txt_NoOfEntries.Text;
			}

			AP.FileLocation = strAppPath;
			if(rdb_Daily.Checked)//daily
			{
				AP.ReccType = "Daily";
				if(rdb_Everyday.Checked) AP.Pattern1 = "0";
				if(rdb_EveryWeekday.Checked) AP.Pattern2 = cmbWeek.Text;
			}
			else if(rdb_Weekly.Checked)//weekly
			{
				AP.ReccType="Weekly";
				AP.Pattern1=txtWeek.Text;
				AP.Pattern2="";
				if(rbMonday.Checked) AP.Pattern2 += "Monday|";
				if(rbTuesday.Checked) AP.Pattern2 += "Tuesday|";
				if(rbWednesday.Checked) AP.Pattern2 += "Wednesday|";
				if(rbThursday.Checked) AP.Pattern2 += "Thursday|";
				if(rbFriday.Checked) AP.Pattern2 += "Friday|";
				if(rbSaturday.Checked) AP.Pattern2 += "Saturday|";
				if(rbSunday.Checked) AP.Pattern2 += "Sunday|";
			}
			else if(rdb_Monthly.Checked)
			{
				AP.ReccType="Monthly";
				AP.Pattern1=txtDay.Text;
				AP.Pattern2=txtMonth.Text;
			}
			else if(rdb_Yearly.Checked)
			{
				AP.ReccType="Yearly";
				if(cmbMonth.SelectedIndex==0) AP.Pattern1="January";
				if(cmbMonth.SelectedIndex==1) AP.Pattern1="February";
				if(cmbMonth.SelectedIndex==2) AP.Pattern1="March";
				if(cmbMonth.SelectedIndex==3) AP.Pattern1="April";
				if(cmbMonth.SelectedIndex==4) AP.Pattern1="May";
				if(cmbMonth.SelectedIndex==5) AP.Pattern1="June";
				if(cmbMonth.SelectedIndex==6) AP.Pattern1="July";
				if(cmbMonth.SelectedIndex==7) AP.Pattern1="August";
				if(cmbMonth.SelectedIndex==8) AP.Pattern1="September";
				if(cmbMonth.SelectedIndex==9) AP.Pattern1="October";
				if(cmbMonth.SelectedIndex==10) AP.Pattern1="November";
				if(cmbMonth.SelectedIndex==11) AP.Pattern1="December";
				AP.Pattern2=txtDD.Text;
			}

			return(AP);
		}

		private void SetTime(ComboBox mcb, string mTime)
		{
			mcb.Text = mTime;
            //mcb.SelectedIndex = mcb.Items.IndexOf(mTime);

			/*try{mTime = Convert.ToDateTime(mTime).ToString("HH:mm");}catch{}															   
			
			if(mTime.Length>7)	mTime = mTime.Substring(0,8);
			if(mTime.Substring(0,1)=="0")
			{
				mTime = mTime.Substring(1, mTime.Length-1);
			}
			mTime=mTime.Trim();

			for(int i=0;i<mcb.Items.Count;i++)
			{
				if(mcb.Items[i].ToString().IndexOf(mTime)==0)
				{
					mcb.SelectedIndex=i;
					return;
				}
			}*/
		}

		private void cmbDurr_TabIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void cmbDurr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DateTime dt = Convert.ToDateTime(cmbStart.Text);
			//MessageBox.Show(dt.ToString());
			
			int hours=0, mints=0;
			int index = cmbDurr.SelectedIndex;
			double decimalhours=0;

			if(index>1)
			{
				decimalhours = Convert.ToDouble(index);
				decimalhours = Convert.ToDouble(index*.5);

				hours = Convert.ToInt16(Math.Floor(decimalhours));
				decimalhours = decimalhours-hours;
				if(decimalhours>0) mints=30;
			}
			else if(index==1)
			{
				hours=0;
				mints=30;
			}
			
			TimeSpan ts=new TimeSpan(0, hours, mints, 0, 0);

			dt = dt.Add(ts);

			SetTime(cmbEnd, dt.ToString("HH:mm"));
		}

		private void SetDuration()
		{
			try
			{
				if(cmbStart.Text.Trim()=="") return;
				if(cmbEnd.Text.Trim()=="") return;
			
				string str;
				string[] arr={
								 "12:00",
								 "12:30",
								 "01:00",
								 "01:30",
								 "02:00",
								 "02:30",
								 "03:00",
								 "03:30",
								 "04:00",
								 "04:30",
								 "05:00",
								 "05:30",
								 "06:00",
								 "06:30",
								 "07:00",
								 "07:30",
								 "08:00",
								 "08:30",
								 "09:00",
								 "09:30",
								 "10:00",
								 "10:30",
								 "11:00",
								 "11:30",
								 "12:00",
								 "12:30",
								 "13:00",
								 "13:30",
								 "14:00",
								 "14:30",
								 "15:00",
								 "15:30",
								 "16:00",
								 "16:30",
								 "17:00",
								 "17:30",
								 "18:00",
								 "18:30",
								 "19:00",
								 "19:30",
								 "20:00",
								 "20:30",
								 "21:00",
								 "21:30",
								 "22:00",
								 "22:30",
								 "23:00",
								 "23:30"};


				string[] arrDur=									  {
																		  "(0 minutes)",
																		  "(30 minutes)",
																		  "(1 hour)",
																		  "(1.5 hours)",
																		  "(2 hours)",
																		  "(2.5 hours)",
																		  "(3 hours)",
																		  "(3.5 hours)",
																		  "(4 hours)",
																		  "(4.5 hours)",
																		  "(5 hours)",
																		  "(5.5 hours)",
																		  "(6 hour)",
																		  "(6.5 hours)",
																		  "(7 hours)",
																		  "(7.5 hours)",
																		  "(8 hours)",
																		  "(8.5 hours)",
																		  "(9 hours)",
																		  "(9.5 hours)",
																		  "(10 hours)",
																		  "(10.5 hours)",
																		  "(11 hour)",
																		  "(11.5 hours)",
																		  "(12 hours)",
																		  "(12.5 hours)",
																		  "(13 hours)",
																		  "(3.5 hours)",
																		  "(14 hours)",
																		  "(14.5 hours)",
																		  "(15 hours)",
																		  "(15.5 hours)",
																		  "(16 hour)",
																		  "(16.5 hours)",
																		  "(17 hours)",
																		  "(17.5 hours)",
																		  "(18 hours)",
																		  "(18.5 hours)",
																		  "(19 hours)",
																		  "(19.5 hours)",
																		  "(20 hours)",
																		  "(20.5 hours)",
																		  "(21 hours)",
																		  "(21.5 hours)",
																		  "(22 hours)",
																		  "(22.5 hours)",
																		  "(23 hours)",
																		  "(23.5 hours)"};


				cmbDurr.Items.Clear();
				//foreach(string s in arrDur)
				//	 cmbDurr.Items.Add(s);
				int index = cmbStart.SelectedIndex;
                index = arrDur.Length - index-2;
                for (int i = 0; i < index; i++)
                    cmbDurr.Items.Add(arrDur[i]);

				//cmbEnd.Items.Clear();
				str=cmbStart.Text.Replace(":", ".");
				double dbl1 = Convert.ToDouble(str.Trim());
				double decimalpart1 = dbl1-Math.Floor(dbl1);
				decimalpart1 = Math.Round((10*decimalpart1)/6,2);
				dbl1 = Math.Floor(dbl1) + decimalpart1;

				str=cmbEnd.Text.Replace(":", ".");
				double dbl2 = Convert.ToDouble(str.Trim());
				double decimalpart2 = dbl2-Math.Floor(dbl2);
				decimalpart2 = Math.Round((10*decimalpart2)/6,2);
				dbl2 = Math.Floor(dbl2) + decimalpart2;

				dbl1 = dbl2-dbl1;

				if(dbl1>=0)
				{
					dbl1 = Math.Round(dbl1,2);
					/*decimalpart1 = dbl1-Math.Floor(dbl1);
					if(decimalpart1!=0)
					{
						decimalpart1 = (6*decimalpart1)/10;
						dbl1 = Math.Floor(dbl1) + decimalpart1;
					}*/
					dbl1=Math.Round(dbl1,2);

					if(dbl1==1)
					{
						str = "(1 hour)";
					}
					else if(dbl1<1)
					{
						dbl1 = (dbl1*60);
						dbl1 = Math.Round(dbl1,0);
						str = "(" + dbl1.ToString() + " minutes)";
					}
					else
					{
						str = "(" + dbl1.ToString() + " hours)";
					}
					cmbDurr.Text = str;
				}
				else
				{
					cmbDurr.Text="Invalid";
                    IsValid = false;
				}
			}
			catch{}
		}

		private void cmbStart_TextChanged(object sender, System.EventArgs e)
		{
            /*
			if(cmb_StartDate.Value!=cmb_FinishDate.Value) 
			{
				cmbEnd.Items.Clear();
				foreach(string s in cmbStart.Items)
					cmbEnd.Items.Add(s);

				return;
			}
			try
			{
				if(cmbStart.Text!="")
				{
					bool Go = false;
					cmbEnd.Items.Clear();
					foreach(string s in cmbStart.Items)
					{
						if(Go==false)
						{
							if(cmbStart.Text.Substring(0,2).Trim()==s.Substring(0,2))
							{
								Go=true;
								continue;
							}
						}
						if(Go)
						{
							cmbEnd.Items.Add(s);						
						}
					}

					if(cmbStart.Text.Substring(3,2).Trim()!="00")
					{
						cmbEnd.Items.Remove(cmbEnd.Items[0].ToString());
					}
				}
			}
			catch{}
            */
			SetDuration();
		}

		private void cmbEnd_TextChanged(object sender, System.EventArgs e)
		{
			SetDuration();
		}

        //Checks for valid `Start Time` input.
		private void cmbStart_Leave(object sender, System.EventArgs e)
		{
			try
			{
				DateTime dt=Convert.ToDateTime(cmbStart.Text);
			}
			catch
			{
				BusinessLayer.Message.MsgError("Invalid Start Time");
				cmbStart.Focus();
			}
		}
        
        //Checks for valid `End Time` input.
		private void cmbEnd_Leave(object sender, System.EventArgs e)
		{
			try
			{
				DateTime dt=Convert.ToDateTime(cmbEnd.Text);
			}
			catch
			{
				BusinessLayer.Message.MsgError("Invalid End Time");
				cmbEnd.Focus();
			}
		}

		private void cmb_FinishDate_ValueChanged(object sender, System.EventArgs e)
		{
		}

        private void cmbStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEnd.Items.Clear();
            int index = cmbStart.SelectedIndex;
            for(int i=index;i<cmbStart.Items.Count;i++)
                cmbEnd.Items.Add(cmbStart.Items[i]);
            cmbEnd.SelectedIndex = 0;
        }

    }
}

