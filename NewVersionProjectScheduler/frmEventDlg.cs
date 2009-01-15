using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Scheduler.BusinessLayer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmEventDlg.
	/// </summary>
	public class frmEventDlg : System.Windows.Forms.Form
    {
        #region Initialization
        #region Controls
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblEventType;
		private System.Windows.Forms.ComboBox cmbEventType;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ComboBox cmbBlock;
		private System.Windows.Forms.TextBox txtLocation;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.TextBox txtRoomNo;
		private System.Windows.Forms.Label lblRoomNo;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.TextBox txtNote;
		public System.Windows.Forms.DateTimePicker dtEnd;
		public System.Windows.Forms.DateTimePicker dtStart;
		public System.Windows.Forms.ComboBox cmbStartTime;
		public System.Windows.Forms.ComboBox cmbEndTime;
		private System.Windows.Forms.Label lblDtComp;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblEnddt;
        private System.Windows.Forms.Label lblStartdt;
		private System.Windows.Forms.DateTimePicker dtDateComplete;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.ComboBox cmbEventStatus;
		private System.Windows.Forms.TextBox txtRomaji;
		private System.Windows.Forms.TextBox txtPhonetic;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.LinkLabel llblTeacher1;
		private System.Windows.Forms.ComboBox cmbTeacher1;
		private System.Windows.Forms.LinkLabel llblTeacher2;
		private System.Windows.Forms.ComboBox cmbTeacher2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsHoliday;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.LinkLabel llblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.LinkLabel llbDepartment;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.LinkLabel llblProgram;
        private System.Windows.Forms.ComboBox cmbProgram;
        private System.Windows.Forms.LinkLabel llblClass;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblEvent1;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtChangeReason;
        private System.Windows.Forms.Label lblChangeReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbExceptionReason;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        #endregion

        #region Declarations
        //Class/Program
		private string _eventName="";

		
		private string XMLData="";
		private string RepeatRule = "";
		private string NegativeException = "";
		private int IsRecurrenceFlag=0;
		private string NoEntries = "";
		private string ReccType = "";
		private string Pattern1 = "";
		private string Pattern2 = "";
		private string strAppPath = Application.StartupPath + "\\Recurrence.xml";

		private string _mode="";
		private int  _eventid=0;
		private int  _calendareventid=0;

		private Scheduler.BusinessLayer.Events objEvent=null;
		private Serialize AP=null;
        private string _startdate;
        private string _enddate;

		private bool boolSaveSeries=true;
        private bool boolAllowExtraClasses = true;
        private bool boolAllowTestInitial = true;
        private bool boolAllowTestMid = true;
        private bool boolAllowTestFinal = true;

		private int intClientID=0;
		private int intDepartmentID=0;
		private int intProgramID=0;
		private int intClassID=0;
		private int intTestEventID=0;

		private bool OpenFromClsProg=false;

		private DateTime dtAppDate=new DateTime();
		private DateTime dtAppTime=new DateTime();
        private string strMode = "";
        private string StartTime = "";
        private string EndTime = "";
		private string strStartTime="00:00";
		private string strEndTime="00:00";
		private string StartDate="", EndDate="";

		private bool boolNoOfRecords = false;

		private bool AutoSave=true;
		private DataTable dtblDates=null;
        private CheckBox chkEventModified;
        private CheckBox chkEventStatus_I;
        private EventType _eventtype;
        //private EventType _eventtype_initial;
        #endregion

        #region Properties
        public string Mode
		{
			get{return _mode;}
			set{_mode=value;}
		}
		public string EventName
		{
			get{return _eventName;}
			set
			{
				_eventName=value;
				txtName.Text = _eventName;
			}
		}
		public int EventID
		{
			get{return _eventid;}
			set{_eventid=value;}
		}
        public bool AllowExtraClasses
        {
            get { return boolAllowExtraClasses; }
            set { boolAllowExtraClasses = value; }
        }
        public bool AllowTestInitial
        {
            get { return boolAllowTestInitial; }
            set { boolAllowTestInitial = value; }
        }
        public bool AllowTestMid
        {
            get { return boolAllowTestMid; }
            set { boolAllowTestMid = value; }
        }
        public bool AllowTestFinal
        {
            get { return boolAllowTestFinal; }
            set { boolAllowTestFinal = value; }
        }
        public EventType EventType
        {
            get { return _eventtype; }
            set { _eventtype = value; }
        }
        public int CourseId
        {
            get { return intClassID; }
            set { intClassID = value; }
        }
        public int ProgramId
        {
            get { return intProgramID; }
            set { intProgramID = value; }
        }
        #endregion

        #region Constructor
        public frmEventDlg()
		{
			InitializeComponent();
            
            //Populate Client and Teacher combo boxes
            Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 and " +
				"ContactStatus=0 Order By CompanyName ");
            
			Common.PopulateDropdown(
				cmbTeacher1, "Select " +
					"TeacherName = CASE " + 
					"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
					"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
					"ELSE NickName " +
					"END From " +
				"Contact Where ContactType=1 " +
				" Order By LastName, FirstName ");
			
			Common.PopulateDropdown(
				cmbTeacher2, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				" Order By ContactID");
		}

		//Most probably, not needed anymore
        public frmEventDlg(DateTime dtDate,string strStart,string strEnd,string strViewMode)
		{
			InitializeComponent();

			dtAppDate=dtDate;
			//dtAppTime=dtTime;
			strMode=strViewMode;
			strStartTime = strStart;
			strEndTime = strEnd;


			
			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 and " +
				"ContactStatus=0 Order By CompanyName ");

			Common.PopulateDropdown(
				cmbTeacher1, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				" Order By ContactID");
			
			Common.PopulateDropdown(
				cmbTeacher2, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FirstName ");
		}

		public frmEventDlg(bool mOpenFromClsProg)
		{
			InitializeComponent();
			
			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 and " +
				"ContactStatus=0 Order By CompanyName ");

			Common.PopulateDropdown(
				cmbTeacher1, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FisrtName ");
			
			Common.PopulateDropdown(
				cmbTeacher2, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FisrtName ");

			OpenFromClsProg=true;

			llblClass.Enabled=false;
			llblProgram.Enabled=false;
			llblClient.Enabled=false;
			llbDepartment.Enabled=false;
			cmbClient.Enabled=false;
			cmbDept.Enabled=false;
			cmbClass.Enabled=false;
			cmbProgram.Enabled=false;
			cmbEvent.Enabled=false;
		}

		//Useful
        public frmEventDlg(int mEventID, int mCalEventID)
		{
			InitializeComponent();

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 and " +
				"ContactStatus=0 Order By CompanyName ");

			Common.PopulateDropdown(
				cmbTeacher1, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FirstName ");
			
			Common.PopulateDropdown(
				cmbTeacher2, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FirstName ");

			_eventid = mEventID;
			_calendareventid=mCalEventID;

			//boolSaveSeries=false;
        }
        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventDlg));
            this.txtRomaji = new System.Windows.Forms.TextBox();
            this.txtPhonetic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnddt = new System.Windows.Forms.Label();
            this.lblStartdt = new System.Windows.Forms.Label();
            this.lblEventType = new System.Windows.Forms.Label();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbBlock = new System.Windows.Forms.ComboBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtRoomNo = new System.Windows.Forms.TextBox();
            this.lblRoomNo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbEventStatus = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.dtDateComplete = new System.Windows.Forms.DateTimePicker();
            this.lblDtComp = new System.Windows.Forms.Label();
            this.llblTeacher1 = new System.Windows.Forms.LinkLabel();
            this.cmbTeacher1 = new System.Windows.Forms.ComboBox();
            this.llblTeacher2 = new System.Windows.Forms.LinkLabel();
            this.cmbTeacher2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsHoliday = new System.Windows.Forms.CheckBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.chkEventStatus_I = new System.Windows.Forms.CheckBox();
            this.chkEventModified = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExceptionReason = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtChangeReason = new System.Windows.Forms.TextBox();
            this.lblChangeReason = new System.Windows.Forms.Label();
            this.lblEvent1 = new System.Windows.Forms.Label();
            this.llblClass = new System.Windows.Forms.LinkLabel();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.llblClient = new System.Windows.Forms.LinkLabel();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.llbDepartment = new System.Windows.Forms.LinkLabel();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.llblProgram = new System.Windows.Forms.LinkLabel();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.pnlBottom.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRomaji
            // 
            this.txtRomaji.Location = new System.Drawing.Point(128, 65);
            this.txtRomaji.MaxLength = 255;
            this.txtRomaji.Name = "txtRomaji";
            this.txtRomaji.Size = new System.Drawing.Size(152, 21);
            this.txtRomaji.TabIndex = 2;
            // 
            // txtPhonetic
            // 
            this.txtPhonetic.Location = new System.Drawing.Point(128, 42);
            this.txtPhonetic.MaxLength = 255;
            this.txtPhonetic.Name = "txtPhonetic";
            this.txtPhonetic.Size = new System.Drawing.Size(152, 21);
            this.txtPhonetic.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(15, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Name Romaji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(15, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Name Phonetic";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(128, 19);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(152, 21);
            this.txtName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(15, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "Name";
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "MM/dd/yyyy";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(400, 54);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(104, 21);
            this.dtEnd.TabIndex = 5;
            this.dtEnd.ValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "MM/dd/yyyy";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStart.Location = new System.Drawing.Point(400, 30);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(104, 21);
            this.dtStart.TabIndex = 3;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // lblEnddt
            // 
            this.lblEnddt.AutoSize = true;
            this.lblEnddt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEnddt.Location = new System.Drawing.Point(304, 56);
            this.lblEnddt.Name = "lblEnddt";
            this.lblEnddt.Size = new System.Drawing.Size(77, 13);
            this.lblEnddt.TabIndex = 242;
            this.lblEnddt.Text = "End Date/Time";
            // 
            // lblStartdt
            // 
            this.lblStartdt.AutoSize = true;
            this.lblStartdt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartdt.Location = new System.Drawing.Point(304, 32);
            this.lblStartdt.Name = "lblStartdt";
            this.lblStartdt.Size = new System.Drawing.Size(83, 13);
            this.lblStartdt.TabIndex = 241;
            this.lblStartdt.Text = "Start Date/Time";
            // 
            // lblEventType
            // 
            this.lblEventType.AutoSize = true;
            this.lblEventType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventType.Location = new System.Drawing.Point(304, 131);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(62, 13);
            this.lblEventType.TabIndex = 237;
            this.lblEventType.Text = "Event Type";
            // 
            // cmbEventType
            // 
            this.cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventType.Items.AddRange(new object[] {
            "Extra Class",
            "Test Initial",
            "Test Mid-term",
            "Test Final"});
            this.cmbEventType.Location = new System.Drawing.Point(400, 129);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(120, 21);
            this.cmbEventType.TabIndex = 16;
            this.cmbEventType.SelectedIndexChanged += new System.EventHandler(this.cmbEventType_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Location = new System.Drawing.Point(16, 131);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(31, 13);
            this.label29.TabIndex = 244;
            this.label29.Text = "Block";
            // 
            // cmbBlock
            // 
            this.cmbBlock.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H"});
            this.cmbBlock.Location = new System.Drawing.Point(128, 129);
            this.cmbBlock.Name = "cmbBlock";
            this.cmbBlock.Size = new System.Drawing.Size(72, 21);
            this.cmbBlock.TabIndex = 13;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(128, 102);
            this.txtLocation.MaxLength = 255;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(152, 21);
            this.txtLocation.TabIndex = 12;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.Location = new System.Drawing.Point(16, 104);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(47, 13);
            this.lblLocation.TabIndex = 246;
            this.lblLocation.Text = "Location";
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.Location = new System.Drawing.Point(400, 102);
            this.txtRoomNo.MaxLength = 255;
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(72, 21);
            this.txtRoomNo.TabIndex = 15;
            this.txtRoomNo.Text = "0";
            this.txtRoomNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomNo_KeyPress);
            // 
            // lblRoomNo
            // 
            this.lblRoomNo.AutoSize = true;
            this.lblRoomNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRoomNo.Location = new System.Drawing.Point(304, 104);
            this.lblRoomNo.Name = "lblRoomNo";
            this.lblRoomNo.Size = new System.Drawing.Size(54, 13);
            this.lblRoomNo.TabIndex = 249;
            this.lblRoomNo.Text = "Room No.";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(530, 131);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 250;
            this.lblStatus.Text = "Status";
            // 
            // cmbEventStatus
            // 
            this.cmbEventStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbEventStatus.Location = new System.Drawing.Point(616, 129);
            this.cmbEventStatus.Name = "cmbEventStatus";
            this.cmbEventStatus.Size = new System.Drawing.Size(120, 21);
            this.cmbEventStatus.TabIndex = 18;
            this.cmbEventStatus.SelectedIndexChanged += new System.EventHandler(this.cmbEventStatus_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point(14, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 3);
            this.groupBox2.TabIndex = 252;
            this.groupBox2.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescription.Location = new System.Drawing.Point(16, 318);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 253;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(128, 315);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(608, 21);
            this.txtDescription.TabIndex = 23;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 508);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(754, 36);
            this.pnlBottom.TabIndex = 255;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(663, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(560, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(15, 342);
            this.txtNote.MaxLength = 255;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(723, 144);
            this.txtNote.TabIndex = 24;
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.Items.AddRange(new object[] {
            "00:00",
            "00:30",
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
            this.cmbStartTime.Location = new System.Drawing.Point(507, 30);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(75, 21);
            this.cmbStartTime.TabIndex = 4;
            this.cmbStartTime.SelectedIndexChanged += new System.EventHandler(this.cmbStartTime_SelectedIndexChanged);
            this.cmbStartTime.Leave += new System.EventHandler(this.cmbStartTime_Leave);
            this.cmbStartTime.TextChanged += new System.EventHandler(this.cmbStartTime_TextChanged);
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.DropDownWidth = 145;
            this.cmbEndTime.Items.AddRange(new object[] {
            "00:00",
            "00:30",
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
            this.cmbEndTime.Location = new System.Drawing.Point(507, 54);
            this.cmbEndTime.MaxLength = 5;
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(75, 21);
            this.cmbEndTime.TabIndex = 6;
            this.cmbEndTime.SelectedIndexChanged += new System.EventHandler(this.cmbEndTime_SelectedIndexChanged);
            this.cmbEndTime.Leave += new System.EventHandler(this.cmbEndTime_Leave);
            // 
            // dtDateComplete
            // 
            this.dtDateComplete.CustomFormat = "MM/dd/yyyy";
            this.dtDateComplete.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateComplete.Location = new System.Drawing.Point(616, 102);
            this.dtDateComplete.Name = "dtDateComplete";
            this.dtDateComplete.Size = new System.Drawing.Size(120, 21);
            this.dtDateComplete.TabIndex = 17;
            this.dtDateComplete.Visible = false;
            // 
            // lblDtComp
            // 
            this.lblDtComp.AutoSize = true;
            this.lblDtComp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDtComp.Location = new System.Drawing.Point(530, 104);
            this.lblDtComp.Name = "lblDtComp";
            this.lblDtComp.Size = new System.Drawing.Size(84, 13);
            this.lblDtComp.TabIndex = 260;
            this.lblDtComp.Text = "Date Completed";
            this.lblDtComp.Visible = false;
            // 
            // llblTeacher1
            // 
            this.llblTeacher1.AutoSize = true;
            this.llblTeacher1.Location = new System.Drawing.Point(16, 161);
            this.llblTeacher1.Name = "llblTeacher1";
            this.llblTeacher1.Size = new System.Drawing.Size(107, 13);
            this.llblTeacher1.TabIndex = 263;
            this.llblTeacher1.TabStop = true;
            this.llblTeacher1.Text = "Scheduled Instructor";
            this.llblTeacher1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblTeacher1_LinkClicked);
            // 
            // cmbTeacher1
            // 
            this.cmbTeacher1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher1.Items.AddRange(new object[] {
            "Class",
            "Desk",
            "Presentation Training",
            "Recording",
            "Mendan",
            "Other"});
            this.cmbTeacher1.Location = new System.Drawing.Point(128, 153);
            this.cmbTeacher1.Name = "cmbTeacher1";
            this.cmbTeacher1.Size = new System.Drawing.Size(152, 21);
            this.cmbTeacher1.TabIndex = 19;
            // 
            // llblTeacher2
            // 
            this.llblTeacher2.AutoSize = true;
            this.llblTeacher2.Location = new System.Drawing.Point(16, 220);
            this.llblTeacher2.Name = "llblTeacher2";
            this.llblTeacher2.Size = new System.Drawing.Size(88, 13);
            this.llblTeacher2.TabIndex = 265;
            this.llblTeacher2.TabStop = true;
            this.llblTeacher2.Text = "Actual Instructor";
            this.llblTeacher2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblTeacher2_LinkClicked);
            // 
            // cmbTeacher2
            // 
            this.cmbTeacher2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher2.Enabled = false;
            this.cmbTeacher2.Items.AddRange(new object[] {
            "Class",
            "Desk",
            "Presentation Training",
            "Recording",
            "Mendan",
            "Other"});
            this.cmbTeacher2.Location = new System.Drawing.Point(128, 218);
            this.cmbTeacher2.Name = "cmbTeacher2";
            this.cmbTeacher2.Size = new System.Drawing.Size(152, 21);
            this.cmbTeacher2.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(13, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 3);
            this.groupBox1.TabIndex = 266;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(208, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 267;
            this.label1.Text = "Is Holiday";
            // 
            // chkIsHoliday
            // 
            this.chkIsHoliday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIsHoliday.Location = new System.Drawing.Point(266, 131);
            this.chkIsHoliday.Name = "chkIsHoliday";
            this.chkIsHoliday.Size = new System.Drawing.Size(24, 16);
            this.chkIsHoliday.TabIndex = 14;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.chkEventStatus_I);
            this.pnlBody.Controls.Add(this.chkEventModified);
            this.pnlBody.Controls.Add(this.label2);
            this.pnlBody.Controls.Add(this.cmbExceptionReason);
            this.pnlBody.Controls.Add(this.groupBox4);
            this.pnlBody.Controls.Add(this.txtChangeReason);
            this.pnlBody.Controls.Add(this.lblChangeReason);
            this.pnlBody.Controls.Add(this.lblEvent1);
            this.pnlBody.Controls.Add(this.llblClass);
            this.pnlBody.Controls.Add(this.cmbClass);
            this.pnlBody.Controls.Add(this.cmbEvent);
            this.pnlBody.Controls.Add(this.llblClient);
            this.pnlBody.Controls.Add(this.cmbClient);
            this.pnlBody.Controls.Add(this.llbDepartment);
            this.pnlBody.Controls.Add(this.cmbDept);
            this.pnlBody.Controls.Add(this.llblProgram);
            this.pnlBody.Controls.Add(this.cmbProgram);
            this.pnlBody.Controls.Add(this.chkIsHoliday);
            this.pnlBody.Controls.Add(this.label1);
            this.pnlBody.Controls.Add(this.llblTeacher2);
            this.pnlBody.Controls.Add(this.llblTeacher1);
            this.pnlBody.Controls.Add(this.lblDtComp);
            this.pnlBody.Controls.Add(this.txtNote);
            this.pnlBody.Controls.Add(this.txtDescription);
            this.pnlBody.Controls.Add(this.lblDescription);
            this.pnlBody.Controls.Add(this.lblStatus);
            this.pnlBody.Controls.Add(this.txtRoomNo);
            this.pnlBody.Controls.Add(this.lblRoomNo);
            this.pnlBody.Controls.Add(this.txtLocation);
            this.pnlBody.Controls.Add(this.lblLocation);
            this.pnlBody.Controls.Add(this.label29);
            this.pnlBody.Controls.Add(this.lblEnddt);
            this.pnlBody.Controls.Add(this.lblStartdt);
            this.pnlBody.Controls.Add(this.lblEventType);
            this.pnlBody.Controls.Add(this.txtRomaji);
            this.pnlBody.Controls.Add(this.txtPhonetic);
            this.pnlBody.Controls.Add(this.label4);
            this.pnlBody.Controls.Add(this.label5);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.label6);
            this.pnlBody.Controls.Add(this.groupBox1);
            this.pnlBody.Controls.Add(this.cmbTeacher2);
            this.pnlBody.Controls.Add(this.cmbTeacher1);
            this.pnlBody.Controls.Add(this.dtDateComplete);
            this.pnlBody.Controls.Add(this.cmbEndTime);
            this.pnlBody.Controls.Add(this.cmbStartTime);
            this.pnlBody.Controls.Add(this.groupBox2);
            this.pnlBody.Controls.Add(this.cmbEventStatus);
            this.pnlBody.Controls.Add(this.cmbBlock);
            this.pnlBody.Controls.Add(this.dtEnd);
            this.pnlBody.Controls.Add(this.dtStart);
            this.pnlBody.Controls.Add(this.cmbEventType);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(754, 508);
            this.pnlBody.TabIndex = 271;
            // 
            // chkEventStatus_I
            // 
            this.chkEventStatus_I.AutoSize = true;
            this.chkEventStatus_I.Location = new System.Drawing.Point(400, 195);
            this.chkEventStatus_I.Name = "chkEventStatus_I";
            this.chkEventStatus_I.Size = new System.Drawing.Size(111, 17);
            this.chkEventStatus_I.TabIndex = 290;
            this.chkEventStatus_I.Text = "Cancel This Event";
            this.chkEventStatus_I.UseVisualStyleBackColor = true;
            this.chkEventStatus_I.CheckedChanged += new System.EventHandler(this.chkEventStatus_I_CheckedChanged);
            // 
            // chkEventModified
            // 
            this.chkEventModified.AutoSize = true;
            this.chkEventModified.Location = new System.Drawing.Point(128, 195);
            this.chkEventModified.Name = "chkEventModified";
            this.chkEventModified.Size = new System.Drawing.Size(128, 17);
            this.chkEventModified.TabIndex = 289;
            this.chkEventModified.Text = "Modify the Instructor";
            this.chkEventModified.UseVisualStyleBackColor = true;
            this.chkEventModified.CheckedChanged += new System.EventHandler(this.chkEventModified_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(304, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 287;
            this.label2.Text = "Reason";
            // 
            // cmbExceptionReason
            // 
            this.cmbExceptionReason.Items.AddRange(new object[] {
            "Cancelled",
            "Extra",
            "Make-Up"});
            this.cmbExceptionReason.Location = new System.Drawing.Point(400, 217);
            this.cmbExceptionReason.Name = "cmbExceptionReason";
            this.cmbExceptionReason.Size = new System.Drawing.Size(256, 21);
            this.cmbExceptionReason.TabIndex = 22;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Location = new System.Drawing.Point(8, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(730, 3);
            this.groupBox4.TabIndex = 285;
            this.groupBox4.TabStop = false;
            // 
            // txtChangeReason
            // 
            this.txtChangeReason.Enabled = false;
            this.txtChangeReason.Location = new System.Drawing.Point(128, 247);
            this.txtChangeReason.MaxLength = 100;
            this.txtChangeReason.Multiline = true;
            this.txtChangeReason.Name = "txtChangeReason";
            this.txtChangeReason.Size = new System.Drawing.Size(166, 48);
            this.txtChangeReason.TabIndex = 21;
            // 
            // lblChangeReason
            // 
            this.lblChangeReason.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChangeReason.Location = new System.Drawing.Point(15, 250);
            this.lblChangeReason.Name = "lblChangeReason";
            this.lblChangeReason.Size = new System.Drawing.Size(108, 26);
            this.lblChangeReason.TabIndex = 284;
            this.lblChangeReason.Text = "Instructor Change Reason";
            // 
            // lblEvent1
            // 
            this.lblEvent1.AutoSize = true;
            this.lblEvent1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent1.Location = new System.Drawing.Point(1336, 104);
            this.lblEvent1.Name = "lblEvent1";
            this.lblEvent1.Size = new System.Drawing.Size(35, 13);
            this.lblEvent1.TabIndex = 282;
            this.lblEvent1.Text = "Event";
            // 
            // llblClass
            // 
            this.llblClass.AutoSize = true;
            this.llblClass.Location = new System.Drawing.Point(1104, 129);
            this.llblClass.Name = "llblClass";
            this.llblClass.Size = new System.Drawing.Size(32, 13);
            this.llblClass.TabIndex = 278;
            this.llblClass.TabStop = true;
            this.llblClass.Text = "Class";
            this.llblClass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClass_LinkClicked);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Location = new System.Drawing.Point(1200, 127);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(120, 21);
            this.cmbClass.TabIndex = 10;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // cmbEvent
            // 
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.Items.AddRange(new object[] {
            "Test Initial",
            "Test Mid-term",
            "Test Final"});
            this.cmbEvent.Location = new System.Drawing.Point(1424, 102);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(120, 21);
            this.cmbEvent.TabIndex = 11;
            // 
            // llblClient
            // 
            this.llblClient.AutoSize = true;
            this.llblClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llblClient.Location = new System.Drawing.Point(816, 104);
            this.llblClient.Name = "llblClient";
            this.llblClient.Size = new System.Drawing.Size(34, 13);
            this.llblClient.TabIndex = 275;
            this.llblClient.TabStop = true;
            this.llblClient.Text = "Client";
            this.llblClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClient_LinkClicked);
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Location = new System.Drawing.Point(928, 102);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(152, 21);
            this.cmbClient.TabIndex = 7;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // llbDepartment
            // 
            this.llbDepartment.AutoSize = true;
            this.llbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llbDepartment.Location = new System.Drawing.Point(816, 129);
            this.llbDepartment.Name = "llbDepartment";
            this.llbDepartment.Size = new System.Drawing.Size(64, 13);
            this.llbDepartment.TabIndex = 274;
            this.llbDepartment.TabStop = true;
            this.llbDepartment.Text = "Department";
            this.llbDepartment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDepartment_LinkClicked);
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(928, 127);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(152, 21);
            this.cmbDept.TabIndex = 8;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // llblProgram
            // 
            this.llblProgram.AutoSize = true;
            this.llblProgram.Location = new System.Drawing.Point(1104, 104);
            this.llblProgram.Name = "llblProgram";
            this.llblProgram.Size = new System.Drawing.Size(47, 13);
            this.llblProgram.TabIndex = 270;
            this.llblProgram.TabStop = true;
            this.llblProgram.Text = "Program";
            this.llblProgram.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblProgram_LinkClicked);
            // 
            // cmbProgram
            // 
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Location = new System.Drawing.Point(1200, 102);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(120, 21);
            this.cmbProgram.TabIndex = 9;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // frmEventDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(754, 544);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEventDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Events...";
            this.Load += new System.EventHandler(this.frmEventDlg_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmEventDlg_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEventDlg_KeyDown);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        #endregion

        private void cmbStartTime_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TimeSpan ts=new TimeSpan(1,0,0,0,0);
			if(dtStart.Value!=dtEnd.Value)
			{
				if(cmbStartTime.SelectedIndex+1!=cmbStartTime.Items.Count)
				{
					if(cmbEndTime.Items.Count>=cmbStartTime.SelectedIndex)
					{
						cmbEndTime.SelectedIndex=cmbStartTime.SelectedIndex+1;
					}
				}
				else
				{
					dtEnd.Value = dtEnd.Value.Add(ts);
					cmbEndTime.SelectedIndex=0;
				}
			}
			else
			{
				if(cmbStartTime.SelectedIndex+1!=cmbStartTime.Items.Count)
				{
					int startindex = cmbStartTime.SelectedIndex;
					cmbEndTime.SelectedIndex=0;
				}
				else
				{
					dtEnd.Value = dtEnd.Value.Add(ts);
					cmbEndTime.SelectedIndex=0;
				}
			}

			/*string str;
			string[] arr=									  {
															  "12:00 AM",
															  "12:30 AM",
															  "1:00 AM",
															  "1:30 AM",
															  "2:00 AM",
															  "2:30 AM",
															  "3:00 AM",
															  "3:30 AM",
															  "4:00 AM",
															  "4:30 AM",
															  "5:00 AM",
															  "5:30 AM",
															  "6:00 AM",
															  "6:30 AM",
															  "7:00 AM",
															  "7:30 AM",
															  "8:00 AM",
															  "8:30 AM",
															  "9:00 AM",
															  "9:30 AM",
															  "10:00 AM",
															  "10:30 AM",
															  "11:00 AM",
															  "11:30 AM",
															  "12:00 PM",
															  "12:30 PM",
															  "1:00 PM",
															  "1:30 PM",
															  "2:00 PM",
															  "2:30 PM",
															  "3:00 PM",
															  "3:30 PM",
															  "4:00 PM",
															  "4:30 PM",
															  "5:00 PM",
															  "5:30 PM",
															  "6:00 PM",
															  "6:30 PM",
															  "7:00 PM",
															  "7:30 PM",
															  "8:00 PM",
															  "8:30 PM",
															  "9:00 PM",
															  "9:30 PM",
															  "10:00 PM",
															  "10:30 PM",
															  "11:00 PM",
															  "11:30 PM"};


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


			cmbEndTime.Items.Clear();
			str=cmbStartTime.Text;

			int cnt=0;
			foreach(string s in arr)
			{
				if(s==str) break;
				cnt++;
			}
			
			int cntDurr=0;
			for(int i=cnt;i<(48);i++)
			{
				cmbEndTime.Items.Add(arr[i] + "    " + arrDur[cntDurr]);
				cntDurr++;
			}
			for(int i=0;i<cnt;i++)
			{
				cmbEndTime.Items.Add(arr[i] + "    " + arrDur[cntDurr]);
				cntDurr++;
			}

			cmbEndTime.SelectedIndex=1;*/
		}

		private void GenerateTimeCombo()
		{
			string str = DateTime.Now.ToShortTimeString();
			bool boolAM=false;
			
			if(str.IndexOf("AM")>0) boolAM=true;
			str=str.Replace("AM","");
			str=str.Replace("PM","");
			str=str.Trim();
			string[] arr=str.Split(new char[]{':'});
			if(Convert.ToInt16(arr[1])<30) 
			{
				arr[1]="30";
			}
			else
			{
				int i=Convert.ToInt16(arr[0]);
				if(i==12) i=1;
				else if(i==11) i=12;
				else i++;

				arr[0] = i.ToString();
				arr[1] = "00";
			}
			if(boolAM)
				cmbStartTime.Text = arr[0] + ":" + arr[1] + " AM";
			else
				cmbStartTime.Text = arr[0] + ":" + arr[1] + " PM";

			dtStart.Value = DateTime.Now;
			dtEnd.Value=DateTime.Now;
		}
		
		private void frmEventDlg_Load(object sender, System.EventArgs e)
		{
            //MessageBox.Show("sa7 el sa7");
			this.ActiveControl = txtName;

			try
			{
				Common.SetControlFont(this);
				Common.SetControlFont(pnlBody);
				Common.SetControlFont(pnlBottom);
			}
			catch{}
			this.Refresh();
            
			if(_mode=="Edit")
			{
				this.Text = "Editing Event...";
				cmbStartTime.Text = StartTime;
				cmbEndTime.Text = EndTime;

                LoadData();
                cmbEventType.Enabled = false;
			}
			else
			{
                string query = "Select " +
                "TeacherName = CASE " +
                "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
                "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
                "ELSE NickName " +
                "END From " +
                "Contact Where ContactType=1 and " +
                "ContactStatus=1 Order By ContactID";
                IDataReader reader = DAC.SelectStatement(query);
                while (reader.Read())
                {
                    if (reader["TeacherName"] != DBNull.Value)
                    {
                        cmbTeacher1.Items.Remove(reader["TeacherName"].ToString());
                        cmbTeacher2.Items.Remove(reader["TeacherName"].ToString());
                    }
                }
				dtDateComplete.Value = DateTime.Now;
			
				if(strMode=="")
				{
					dtStart.Value = DateTime.Now;
					dtEnd.Value = DateTime.Now;
				}
				else
				{
					dtStart.Value = dtAppDate;
					dtEnd.Value = dtAppDate;
				}
				
				if(File.Exists(strAppPath))
				{
					File.Delete(strAppPath);
				}
				this.Text = "Adding Event...";
				//GenerateTimeCombo();
				cmbEventStatus.SelectedIndex=0;
                SetDefaultEventType();
                //cmbEventType.SelectedIndex=-1;

				if(strMode=="")
				{
					cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
                    if (Convert.ToDateTime(cmbStartTime.Text).Hour >= 23 && Convert.ToDateTime(cmbStartTime.Text).Minute >= 30)
                    {
                        cmbEndTime.Text = cmbStartTime.Text;
                    }
                    else
					    cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0,0,30,0,0)).ToString("HH:mm");
				}
				else
				{
					if((strStartTime!="")&&(strEndTime!=""))
					{
						cmbStartTime.Text = strStartTime.Trim();
                        if (Convert.ToDateTime(cmbStartTime.Text).Hour >= 23 && Convert.ToDateTime(cmbStartTime.Text).Minute >= 30)
                            cmbEndTime.Text = cmbStartTime.Text;
                        else
						    cmbEndTime.Text = strEndTime.Trim();
					}
					else
					{
						cmbStartTime.Text = "08:00";
						cmbEndTime.Text = "08:30";
					}
				}
			}
            if (!chkEventStatus_I.Checked && cmbTeacher2.SelectedIndex <= 0 && cmbExceptionReason.SelectedIndex <= 0 && cmbExceptionReason.Text == "")
                SetEventModificationControls(false);
            else
                SetEventModificationControls(true);
		}

		public bool setToConfig()
		{
			string StartDate = AP.StartDate;
			string EndDate = AP.EndDate;
			NoEntries = AP.NoEntries;
			ReccType = AP.ReccType;
			Pattern1 = AP.Pattern1;
			Pattern2 = AP.Pattern2;

			if(StartDate=="") return false;

			_startdate=AP.StartDate;
			_enddate=AP.EndDate;

			try
			{
				dtStart.Value = Convert.ToDateTime(StartDate);
				dtEnd.Value = Convert.ToDateTime(EndDate);
			}
			catch{}

			try
			{
				//if(AP.StartDate!="") cmb_StartDate.Value=Convert.ToDateTime(AP.StartDate);
				//if(AP.EndDate!="") cmb_FinishDate.Value=Convert.ToDateTime(AP.EndDate);
			}
			catch{}

			return true;
		}

        /// <summary>
        /// Checks for event information validity.
        /// </summary>
        /// <returns>A boolean indicating whether the entered information is correct or not.</returns>
		private bool IsValid()
		{
			if(txtName.Text=="")
			{
				BusinessLayer.Message.MsgInformation("Enter Name");
				txtName.Focus();
				return false;
			}

			try
			{
				string strStart = dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text;
				string strFinish = dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text;
				dtStart.Value = Convert.ToDateTime(strStart);
				dtEnd.Value = Convert.ToDateTime(strFinish);
			}
			catch{}

			if(!boolNoOfRecords)
			{
				if(dtEnd.Value<dtStart.Value)
				{
					BusinessLayer.Message.MsgInformation("Start Date/Time must be before End Date/Time");
					dtStart.Focus();
					return false;
				}
			}
			return true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

		private bool IsCheckOverlapTime(ref string confilictingEvent, 
			string instructortype,
			ref string conflictMess)
		{
			bool Ok=false;
			
            if(EventID>0)
			{
				//DateTime dtOS=Convert.ToDateTime(StartDate);
				//DateTime dtOE=Convert.ToDateTime(StartDate);

				DateTime dtNS=Convert.ToDateTime(dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text);
				DateTime dtNE=Convert.ToDateTime(dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text);

				/*
                if((dtOS==dtNS) && (dtNE==dtOE))
				{
					Ok=false;
					return false;
				}*/
			}
            
			string[] arr1;
			if(instructortype=="Scheduled")
				arr1 = cmbTeacher1.Text.Split(new char[]{','});
			else
				arr1 = cmbTeacher2.Text.Split(new char[]{','});

			string str1="", str2="";
			str1 = arr1[0].Trim();
			if(arr1.Length>1) str2 = arr1[1].Trim();

			if((str1=="") && (str2=="")) return false;
			int intTeacherID = Common.GetTeacherID(
				"Select ContactID From Contact " +
				"Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
				);

			int evtid =  Common.CheckOverlapTime(intTeacherID, EventID, instructortype, ref confilictingEvent, 
				dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text,
				dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text);
		
		
			if(evtid>0)
			{
				string sOverlapMess=string.Empty;
				sOverlapMess = Common.GetConflictMess(evtid);

				conflictMess=sOverlapMess;

				return true;
			}
			else return false;
		}

		private bool IsCheckOverlapTime(ref string confilictingEvent, 
			string instructortype, 
			string dt1, 
			string dt2,
			ref string conflictMess)
		{
			bool Ok=false;
			string[] arr1;

			if(instructortype=="Scheduled")
				arr1 = cmbTeacher1.Text.Split(new char[]{','});
			else
				arr1 = cmbTeacher2.Text.Split(new char[]{','});

			string str1="", str2="";
			str1 = arr1[0].Trim();
			if(arr1.Length>1) str2 = arr1[1].Trim();

			if((str1=="") && (str2=="")) return false;
			int intTeacherID = Common.GetTeacherID(
				"Select ContactID From Contact " +
				"Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
				);

			int evtid = Common.CheckOverlapTime(intTeacherID, EventID, instructortype, ref confilictingEvent, 
				dt1,
				dt2);

			if(evtid>0)
			{
				string sOverlapMess=string.Empty;
				sOverlapMess = Common.GetConflictMess(evtid);

				conflictMess=sOverlapMess;
				return true;
			}
			else return false;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string sConflictingEvent="";
			if(!IsValid()) return;

			//check real teacher first
			string strOverLapMess="";

			strOverLapMess = strOverLapMess.Trim();
			
			//AutoSave=false;
			//GenerateEvent(IsRecurrenceFlag);
			//AutoSave=true;

			if(cmbTeacher2.Text.Trim()!="")
			{
				bool Ok=false;
				if(dtblDates==null)
				{
					Ok = IsCheckOverlapTime(ref sConflictingEvent, "Real", ref strOverLapMess);
				}
				else
				{
					foreach(DataRow dr in dtblDates.Rows)
					{
						Ok = IsCheckOverlapTime(ref sConflictingEvent, "Real", dr[0].ToString(), dr[1].ToString(), ref strOverLapMess);
						if(Ok) break;
					}
				}
				if(Ok)
				{
					DialogResult dlg = 
						BusinessLayer.Message.MsgConfirmation(
						"<" + cmbTeacher2.Text + "> is already scheduled in <" + 
						sConflictingEvent + ">" + strOverLapMess +
						"\nDo you still wish to save this event?");
					if(dlg==DialogResult.No) 
					{
						return;
					}
				}
			}
			else
			{
				//if real instructor is blank then check scheduled teacher
				bool Ok=false;
				if(dtblDates==null)
					Ok = IsCheckOverlapTime(ref sConflictingEvent, "Scheduled", ref strOverLapMess);
				else
					foreach(DataRow dr in dtblDates.Rows)
					{
						Ok = IsCheckOverlapTime(ref sConflictingEvent, "Scheduled", dr[0].ToString(), dr[1].ToString(), ref strOverLapMess);
						if(Ok) break;
					}

				if(Ok)
				{
					DialogResult dlg = 
						BusinessLayer.Message.MsgConfirmation(
						"<" + cmbTeacher1.Text + "> is already scheduled in <" + 
						sConflictingEvent + ">" + strOverLapMess +
						"\nDo you still wish to save this event?");
					if(dlg==DialogResult.No) 
    					return;
				}
			}

            // Saving Logic
            /* Differentiate on the basis of current mode. For Edit mode, the event will
             * be updated after ensuring no conflicts arise as a result of the changes.
             * For Add, the event will be added after ensuring no conflicts arise.
             */
            Boolean boolSuccess = false;
            if (_mode == "Edit")
            {
                //TODO:Differentiate between Class and Program
                if(objEvent.CalendarEventID > 0)
                    if (!objEvent.IsConflicting(dtStart.Value, dtEnd.Value))
                    {
                        SaveCalendarData(dtStart.Value, dtEnd.Value);

                        if (_eventtype == EventType.Initial || _eventtype == EventType.MidTerm || _eventtype == EventType.Final)
                        {
                            objEvent.RepeatRule = "";
                            objEvent.NegativeException = "";
                            objEvent.RecurrenceText = "";
                            objEvent.Description = txtDescription.Text;
                            objEvent.EventStatus = cmbEventStatus.SelectedIndex;

                            boolSuccess = objEvent.UpdateData();

                            if (!boolSuccess)
                            {
                                Scheduler.BusinessLayer.Message.ShowException("Updating Event record.", objEvent.Message);
                                return;
                            }
                        }
                    }
            }
            else if (_mode == "Add")
            {
                //Create a new 'Event' object
                objEvent = new Events();

                if (_eventtype == EventType.Extra)
                {
                    //Add Extra Class - add record to 'CalendarEvent' table ONLY
                    SaveCalendarEvent(dtStart.Value, dtEnd.Value);                    
                }
                else if (_eventtype == EventType.Final || _eventtype == EventType.Initial || _eventtype == EventType.MidTerm)
                {
                    //Add Test Event - add record to 'Event' AND 'CalendarEvent' tables AND update 'Course' table
                    string strField = "";
                    if (intClassID != 0 || intProgramID != 0)
                    {
                        switch (_eventtype)
                        { 
                            default: case EventType.Initial: strField = "TestInitialEventID"; break;
                            case EventType.MidTerm: strField = "TestMidtermEventID"; break;
                            case EventType.Final: strField = "TestFinalEventID"; break;
                        }

                        SaveData();
                        SaveCalendarEvent(dtStart.Value, dtEnd.Value);
                        if (intClassID != 0)
                            objEvent.UpdateClassEvent(intClassID, strField);
                        else if (intProgramID != 0)
                            objEvent.UpdateProgramEvent(intProgramID, strField);
                    }
                }
            }
            
            /*
			if(boolSaveSeries)
			{
				SaveData();
				if(_mode=="Edit") objEvent.DeleteCalendarEvent();
				//GenerateEvent(IsRecurrenceFlag);
			}
			else
				SaveCalendarData(dtStart.Value, dtEnd.Value);

			if(!OpenFromClsProg)
			{
				//Updating the Test Event
				string strField="";
				if(intClassID!=0)
				{
					if(cmbEvent.SelectedIndex==0) strField="EventID";
					else if(cmbEvent.SelectedIndex==1) strField="TestInitialEventID";
					else if(cmbEvent.SelectedIndex==2) strField="TestMidtermEventID";
					else if(cmbEvent.SelectedIndex==3) strField="TestFinalEventID";

					objEvent.UpdateTestEvent("Class", strField, objEvent.EventID, intClassID);
				}
				else if(intProgramID!=0)
				{
					if(cmbEvent.SelectedIndex==0) strField="TestInitialEventID";
					else if(cmbEvent.SelectedIndex==1) strField="TestMidtermEventID";
					else if(cmbEvent.SelectedIndex==2) strField="TestFinalEventID";

					objEvent.UpdateTestEvent("Program", strField, objEvent.EventID, intProgramID);
				}
				else
				{
					objEvent.RemoveTestEvent(objEvent.EventID, intClassID);
				}
			}
            */
			this.DialogResult = DialogResult.OK;
		}

		public void LoadData()
		{
			if(_mode=="Edit")
			{
				DataTable dtbl=null;

				this.Text = "Editing Event...";
                
				objEvent=new Scheduler.BusinessLayer.Events();
				objEvent.EventID = _eventid;

				if(_calendareventid>0)
					objEvent.CalendarEventID=_calendareventid;
				
                dtbl = objEvent.LoadData();

				string strClient="", strDept="", strClass="", strProgram="";

				foreach(DataRow dr in dtbl.Rows)
				{
					if(dr["Client"]!=System.DBNull.Value) strClient = dr["Client"].ToString();
					if(dr["Department"]!=System.DBNull.Value) strDept = dr["Department"].ToString();
					if(dr["Program"]!=System.DBNull.Value) strProgram = dr["Program"].ToString();
					if(dr["Class"]!=System.DBNull.Value) strClass = dr["Class"].ToString();

					if(dr["ProgramID"]!=System.DBNull.Value) intProgramID = Convert.ToInt32(dr["ProgramID"].ToString());
					if(dr["CourseID"]!=System.DBNull.Value) intClassID = Convert.ToInt32(dr["CourseID"].ToString());

					cmbClient.Text = strClient;
					if(strClient.Trim()!="")
					{
						intClientID = Common.GetCompanyID(
							"Select ContactID From Contact " +
							"Where (CompanyName =@CompanyName OR NickName=@CompanyName)", cmbClient.Text
							);
						
						if(intClientID!=0)
						{
							cmbDept.Text = strDept;

							intDepartmentID = Common.GetCompanyID(
								"Select D.DepartmentID from Department D, Contact C " +
								"Where D.ContactID=C.ContactID and (C.CompanyName= @CompanyName OR NickName=@CompanyName)", cmbDept.Text
								);
						}
						if(intDepartmentID!=0)
						{
							cmbProgram.Text = strProgram;
							intProgramID = Common.GetCompanyID(
								"Select ProgramID From Program " +
								"Where ([Name]= @CompanyName OR NickName=@CompanyName)", cmbProgram.Text
								);
						}
						if(intProgramID!=0)
						{
							cmbClass.Text = strClass;
							intClassID = Common.GetCompanyID(
								"Select CourseID From Course " +
								"Where ([Name]= @CompanyName OR NickName=@CompanyName) and ProgramID=" + intProgramID.ToString(), cmbClass.Text
								);
						}

						if(dr["TestEvent"]!=System.DBNull.Value)
						{
							cmbEvent.Text = dr["TestEvent"].ToString();
							cmbEvent.Tag = cmbEvent.SelectedIndex.ToString();
						}
					}
					
					RepeatRule= dr["RepeatRule"].ToString();
					NegativeException = dr["NegetiveException"].ToString();
					
					txtName.Text = dr["Name"].ToString();
					txtPhonetic.Text = dr["NamePhonetic"].ToString();
					txtRomaji.Text = dr["NameRomaji"].ToString();

                    if (dr["EventType"] != System.DBNull.Value)
                    {
                        if(dr["EventType"].ToString() == "Test Midterm")
                            cmbEventType.SelectedIndex = cmbEventType.Items.IndexOf("Test Mid-term");
                        else
                            cmbEventType.SelectedIndex = cmbEventType.Items.IndexOf(dr["EventType"].ToString());

                        switch (dr["EventType"].ToString())
                        {
                            case "Extra Class": _eventtype = EventType.Extra; break;
                            case "Test Initial": _eventtype = EventType.Initial; break;
                            case "Test Midterm": _eventtype = EventType.MidTerm; break;
                            case "Test Mid-term": _eventtype = EventType.MidTerm; break;
                            case "Test Final": _eventtype = EventType.Final; break;
                        }
                    }
                    else
                        SetDefaultEventType();
                        //cmbEventType.SelectedIndex = -1;
					
                    txtLocation.Text = dr["Location"].ToString();
					cmbBlock.Text = dr["BlockCode"].ToString();
					txtRoomNo.Text = dr["RoomNumber"].ToString();
					txtDescription.Text = dr["Description"].ToString();
					txtNote.Text = dr["Note"].ToString();
					
                    if(dr["ExceptionReason"]!=System.DBNull.Value)
						cmbExceptionReason.Text = dr["ExceptionReason"].ToString();

                    cmbEventStatus.SelectedIndex = Convert.ToInt16(dr["EventStatus"].ToString());
					cmbTeacher1.Text = dr["ScheduledTeacher"].ToString();
					cmbTeacher2.Text = dr["RealTeacher"].ToString();
                    string query = "Select " +
                "TeacherName = CASE " +
                "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
                "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
                "ELSE NickName " +
                "END From " +
                "Contact Where ContactType=1 and " +
                "ContactStatus=1 Order By ContactID";
                    IDataReader reader = DAC.SelectStatement(query);
                    while (reader.Read())
                    {
                        if (reader["TeacherName"] != DBNull.Value && reader["TeacherName"].ToString() != cmbTeacher1.Text &&  reader["TeacherName"].ToString() != cmbTeacher2.Text)
                        {
                            cmbTeacher1.Items.Remove(reader["TeacherName"].ToString());
                            cmbTeacher2.Items.Remove(reader["TeacherName"].ToString());
                        }
                    }

					txtChangeReason.Text = dr["ChangeReason"].ToString();
					
                    if(dr["IsHoliday"]==System.DBNull.Value)
						chkIsHoliday.Checked=false;
					else
						chkIsHoliday.Checked = (Convert.ToInt16(dr["IsHoliday"])>0);

                    XMLData = dr["RepeatRule"].ToString();

					if(dr["RecurrenceText"]!=System.DBNull.Value)
						if(dr["RecurrenceText"].ToString()!="")
							IsRecurrenceFlag = 1;
                    if (Convert.ToInt16(dr["EventStatus"].ToString()) == 1)
                        chkEventStatus_I.Checked = true;
                    else
                        chkEventStatus_I.Checked = false;
				    dtStart.Value = Convert.ToDateTime(dr["StartDateTime"].ToString());
				    dtEnd.Value = Convert.ToDateTime(dr["EndDateTime"].ToString());

				    StartTime = dtStart.Value.ToString("HH:mm");
				    EndTime = dtEnd.Value.ToString("HH:mm");
				    try
				    {
					    SetTime(cmbStartTime, Convert.ToDateTime(StartTime).ToString("HH:mm"));
					    SetTime(cmbEndTime, Convert.ToDateTime(EndTime).ToString("HH:mm"));
				    }
					catch{}

					dtDateComplete.Value = Convert.ToDateTime(dr["DateCompleted"].ToString());
					
					StartDate = dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text;
					EndDate = dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text;

					break;
				}
                
                if (dtbl.Rows.Count <= 0)
                {
                    _mode = "Add";
                    _eventid = 0;
                    dtDateComplete.Value = DateTime.Now;
                    dtStart.Value = DateTime.Now;
                    dtEnd.Value = DateTime.Now;
                    if (File.Exists(strAppPath))
                        File.Delete(strAppPath);

                    this.Text = "Adding Event...";
                    //GenerateTimeCombo();
                    cmbEventStatus.SelectedIndex = 0;
                    SetDefaultEventType();
                    //cmbEventType.SelectedIndex = -1;
                }
            }
		}
        
        /// <summary>
        /// Saves data to the 'Event' Table
        /// </summary>
		private void SaveData()
		{
			bool boolSuccess;
			objEvent=null;
			
            /*
			if(File.Exists(strAppPath))
			{
				StreamReader re = File.OpenText(strAppPath);
				XMLData = re.ReadToEnd();
				re.Close();
				re=null;
			}
			else 
			{
				XMLData="";
				IsRecurrenceFlag=0;
			}*/
			
			objEvent=new Scheduler.BusinessLayer.Events();
			objEvent.EventID=0;
			//objEvent.RepeatRule = XMLData;
            objEvent.RepeatRule = "";
			objEvent.NegativeException = "";
            objEvent.RecurrenceText = "";
			objEvent.Description = txtDescription.Text;
			objEvent.EventStatus = cmbEventStatus.SelectedIndex;
			
            /*
			if(IsRecurrenceFlag>0)
				objEvent.RecurrenceText = lblRecurrenceText.Text;
			else
				objEvent.RecurrenceText = "";
            */

			
			if(objEvent.Exists())
			{
				Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Name not allowed");
				txtName.Focus();
				return;
			}
			
            boolSuccess = objEvent.InsertData();
			_eventid = objEvent.EventID;

			
			if(!boolSuccess)
			{
	    		Scheduler.BusinessLayer.Message.ShowException("Inserting Event record.", objEvent.Message);
				return;
			}

			//this.DialogResult = DialogResult.OK;
			//Close();
		}
        /*
		private void GenerateEvent(int IsRecur)
		{
			DateTime StartDate = dtStart.Value;
			DateTime EndDate = dtEnd.Value;

			if(IsRecur>0)
			{
				if(ReccType=="Daily")
				{
					if(Pattern1!="")
					{
						GenerateDataForDaily("EveryDay");
					}
					else if(Pattern2!="")
					{
						GenerateDataForDaily("EveryWeekDay");
					}
				}
				else if(ReccType=="Weekly")
				{
					if(Pattern1!="")
					{
						GenerateDataForWeekly();
					}
				}
				else if(ReccType=="Monthly")
				{
					if(Pattern1!="")
					{
						GenerateDataForMonthly();
					}
				}
				else if(ReccType=="Yearly")
				{
					if(Pattern1!="")
					{
						GenerateDataForYearly();
					}
				}
			}
			else
			{
				//No Recurrence....
				SaveCalendarEvent(StartDate, EndDate);
			}

		}

		private void GenerateDataForDaily(string option)
		{
			int NoOfRecords=0;
			DateTime StartDate=Convert.ToDateTime(null);
			StartDate = dtStart.Value;

			if(NoEntries=="")
			{
				TimeSpan ts = dtEnd.Value - StartDate;
				NoOfRecords = ts.Days;
				NoOfRecords++;
			}
			else 
			{
				NoOfRecords = Convert.ToInt16(NoEntries);
				if(option=="EveryWeekDay")
				{
					NoOfRecords = NoOfRecords*7;
				}
			}

			if(option=="EveryDay")
			{
				while(NoOfRecords>0)
				{
					//MessageBox.Show(StartDate.ToString());
					SaveCalendarEvent(StartDate, StartDate);
					StartDate = StartDate.AddDays(1);
					NoOfRecords--;
				}
			}
			else if(option=="EveryWeekDay")
			{
				bool boolOk=false;
				while(NoOfRecords>0)
				{
					if((Pattern2=="Monday") && (StartDate.DayOfWeek==DayOfWeek.Monday)) boolOk=true;
					else if((Pattern2=="Tuesday") && (StartDate.DayOfWeek==DayOfWeek.Tuesday)) boolOk=true;
					else if((Pattern2=="Wednesday") && (StartDate.DayOfWeek==DayOfWeek.Wednesday)) boolOk=true;
					else if((Pattern2=="Thursday") && (StartDate.DayOfWeek==DayOfWeek.Thursday)) boolOk=true;
					else if((Pattern2=="Friday") && (StartDate.DayOfWeek==DayOfWeek.Friday)) boolOk=true;
					else if((Pattern2=="Saturday") && (StartDate.DayOfWeek==DayOfWeek.Saturday)) boolOk=true;
					else if((Pattern2=="Sunday") && (StartDate.DayOfWeek==DayOfWeek.Sunday)) boolOk=true;

					if(boolOk)
					{
						//MessageBox.Show(StartDate.ToString());
						SaveCalendarEvent(StartDate, StartDate);
					}
					StartDate = StartDate.AddDays(1);
					NoOfRecords--;
					
					boolOk=false;
				}
			}
		}

		private void GenerateDataForWeekly()
		{
			int NoOfRecords=0;
			DateTime StartDate=Convert.ToDateTime(null);
			StartDate = dtStart.Value;

			int WeekNo=0;
			string WeekDay="";

			WeekNo = Convert.ToInt16(Pattern1);
			
			string[] arr = Pattern2.Split(new char[]{'|'});
			int counter=arr.Length-1;
			WeekDay = Pattern2;

			bool boolEntries=false;
			if(NoEntries=="")
			{
				TimeSpan ts = dtEnd.Value - StartDate;
				NoOfRecords = ts.Days;
				NoOfRecords++;
			}
			else 
			{
				NoOfRecords = Convert.ToInt16(NoEntries);
				boolEntries=true;
			}

			bool boolOk=false;
			int cnt=0;
			while(NoOfRecords>0)
			{
				foreach(string s in arr)
				{
					if(s!="")
					{
						boolOk=false;
						if((s=="Monday") && (StartDate.DayOfWeek==DayOfWeek.Monday)) boolOk=true;
						else if((s=="Tuesday") && (StartDate.DayOfWeek==DayOfWeek.Tuesday)) boolOk=true;
						else if((s=="Wednesday") && (StartDate.DayOfWeek==DayOfWeek.Wednesday)) boolOk=true;
						else if((s=="Thursday") && (StartDate.DayOfWeek==DayOfWeek.Thursday)) boolOk=true;
						else if((s=="Friday") && (StartDate.DayOfWeek==DayOfWeek.Friday)) boolOk=true;
						else if((s=="Saturday") && (StartDate.DayOfWeek==DayOfWeek.Saturday)) boolOk=true;
						else if((s=="Sunday") && (StartDate.DayOfWeek==DayOfWeek.Sunday)) boolOk=true;

						if(boolOk)
						{
							if(cnt<counter)
							{
								if(boolOk)
								{
									boolOk=false;
								}
								SaveCalendarEvent(StartDate, StartDate);
								if(boolEntries) NoOfRecords--;
							}
							cnt++;
						}
					}
				}
				if(cnt==WeekNo*counter) cnt=0;
				StartDate = StartDate.AddDays(1);
				if(boolEntries==false) NoOfRecords--;
			}
		}

		private void GenerateDataForMonthly()
		{
			int NoOfRecords=0;
			DateTime StartDate=Convert.ToDateTime(null);
			StartDate = dtStart.Value;

			int DayNo=0;
			int MonthFreqiency=0;

			DayNo = Convert.ToInt16(Pattern1);
			MonthFreqiency = Convert.ToInt16(Pattern2);

			if(NoEntries=="")
			{
				TimeSpan ts = dtEnd.Value - StartDate;
				NoOfRecords = ts.Days;
				NoOfRecords++;
			}
			else 
			{
				NoOfRecords = Convert.ToInt16(NoEntries);
				DateTime dtCaclEnd = StartDate.AddMonths(NoOfRecords);
				TimeSpan ts = new TimeSpan();
				ts = dtCaclEnd.Subtract(StartDate);
				NoOfRecords = (int)Math.Round(ts.TotalDays,0);
				//NoOfRecords = NoOfRecords*31;
			}

			bool boolOk=false;
			int cnt=0;
			while(NoOfRecords>0)
			{
				if(StartDate.Day==DayNo) boolOk=true;
				if(boolOk)
				{
					if(cnt==0)
					{
						//MessageBox.Show(StartDate.ToString());
						SaveCalendarEvent(StartDate, StartDate);
					}
					cnt++;
					if(cnt==MonthFreqiency) cnt=0;
				}
				StartDate = StartDate.AddDays(1);
				NoOfRecords--;
					
				boolOk=false;
			}
		}

		private void GenerateDataForYearly()
		{
			int NoOfRecords=0;
			DateTime StartDate=Convert.ToDateTime(null);
			StartDate = dtStart.Value;

			string Month="";
			int DayNo=0;

			Month = Pattern1;
			DayNo = Convert.ToInt16(Pattern2);

			if(NoEntries=="")
			{
				TimeSpan ts = dtEnd.Value - StartDate;
				NoOfRecords = ts.Days;
				NoOfRecords++;
			}
			else 
			{
				NoOfRecords = Convert.ToInt16(NoEntries);
				NoOfRecords = NoOfRecords*366;
			}

			int MonthNo=0;
			bool boolOk=false;

			if(Month=="January") MonthNo=1;
			else if(Month=="February") MonthNo=2;
			else if(Month=="March") MonthNo=3;
			else if(Month=="April") MonthNo=4;
			else if(Month=="May") MonthNo=5;
			else if(Month=="June") MonthNo=6;
			else if(Month=="July") MonthNo=7;
			else if(Month=="August") MonthNo=8;
			else if(Month=="September") MonthNo=9;
			else if(Month=="October") MonthNo=10;
			else if(Month=="November") MonthNo=11;
			else if(Month=="December") MonthNo=12;

			while(NoOfRecords>0)
			{
				if((StartDate.Day==DayNo) && (StartDate.Month==MonthNo)) boolOk=true;
				if(boolOk)
				{
					//MessageBox.Show(StartDate.ToString());
					SaveCalendarEvent(StartDate, StartDate);
				}
				StartDate = StartDate.AddDays(1);
				NoOfRecords--;
					
				boolOk=false;
			}
		}
        */
		
        //Adds a Calendar Event to database
        private void SaveCalendarEvent(DateTime mStart, DateTime mEnd)
		{
			/*
             if(!AutoSave)
			{
				if(dtblDates!=null)
				{
					dtblDates.Rows.Add(new object[]{mStart, mEnd});
				}
				return true;
			}*/

			bool boolSuccess=false;
			string StartTime="";
			string EndTime="";
			int startlength=8;
			int endlength=8;

			if(objEvent==null) objEvent	= new Scheduler.BusinessLayer.Events();
            
            objEvent.EventID = _eventid;
            objEvent.Name = txtName.Text;
			objEvent.NamePhonetic = txtPhonetic.Text;
			objEvent.NameRomaji = txtRomaji.Text;

			string[] arr1 = cmbTeacher1.Text.Split(new char[]{','});
			string[] arr2 = cmbTeacher1.Text.Split(new char[]{','});

			string str1="", str2="";
			str1 = arr1[0].Trim();
			if(arr1.Length>1) str2 = arr1[1].Trim();

			objEvent.SchedulerTeacherID = Common.GetTeacherID(
					"Select ContactID From Contact " +
					"Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
					);

			str1="";
			str2="";
			arr1 = cmbTeacher2.Text.Split(new char[]{','});
			arr2 = cmbTeacher2.Text.Split(new char[]{','});
			str1 = arr2[0].Trim();
			if(arr2.Length>1) str2 = arr2[1].Trim();

			objEvent.RealTeacherID = Common.GetTeacherID(
					"Select ContactID From Contact " +
					"Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
					);

           
            objEvent.EventType = cmbEventType.Text;
			objEvent.Location = txtLocation.Text;
			objEvent.BlockCode = cmbBlock.Text;
			objEvent.RoomNo = txtRoomNo.Text;
			objEvent.ChangeReason = txtChangeReason.Text;

			try
			{
				startlength = cmbStartTime.Text.Length;
				endlength = cmbEndTime.Text.Length;

				StartTime = mStart.ToShortDateString() + " " + cmbStartTime.Text.Trim();
				EndTime = mEnd.ToShortDateString() + " " + cmbEndTime.Text.Trim();

				mStart=Convert.ToDateTime(StartTime);
				mEnd=Convert.ToDateTime(EndTime);
			}
			catch{}
			objEvent.StartDate = mStart;
			objEvent.EndDate = mEnd;
			objEvent.DateCompleted = dtDateComplete.Value;

			if(chkIsHoliday.Checked)
				objEvent.IsHoliday = 1;
			else
				objEvent.IsHoliday = 0;
			
			objEvent.Description = txtDescription.Text;
			objEvent.Notes = txtNote.Text;
			objEvent.ExceptionReason = cmbExceptionReason.Text;

			objEvent.CalendarEventStatus = cmbEventStatus.SelectedIndex;

			boolSuccess = objEvent.InsertCalendarEventData();
			
            if(!boolSuccess)
			{
				Scheduler.BusinessLayer.Message.ShowException("Inserting Calendar Event record.", objEvent.Message);
                return;
			}
		}

        //Updates the Calendar Event
		private void SaveCalendarData(DateTime mStart, DateTime mEnd)
		{
			bool boolSuccess=false;
			string StartTime="";
			string EndTime="";
			int startlength=8;
			int endlength=8;

			if(objEvent==null) objEvent	= new Scheduler.BusinessLayer.Events();
			objEvent.EventID = _eventid;
			objEvent.Name = txtName.Text;
			objEvent.NamePhonetic = txtPhonetic.Text;
			objEvent.NameRomaji = txtRomaji.Text;
			objEvent.CalendarEventID = _calendareventid;


			string[] arr1 = cmbTeacher1.Text.Split(new char[]{','});
			string[] arr2 = cmbTeacher1.Text.Split(new char[]{','});

			string str1="", str2="";
			str1 = arr1[0].Trim();
			if(arr1.Length>1) str2 = arr1[1].Trim();

			objEvent.SchedulerTeacherID = Common.GetTeacherID(
				"Select ContactID From Contact " +
				"Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
				);

			str1="";
			str2="";
			arr1 = cmbTeacher2.Text.Split(new char[]{','});
			arr2 = cmbTeacher2.Text.Split(new char[]{','});
			str1 = arr2[0].Trim();
			if(arr2.Length>1) str2 = arr2[1].Trim();

			objEvent.RealTeacherID = Common.GetTeacherID(
				"Select ContactID From Contact " +
				"Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
				);

			objEvent.ChangeReason = txtChangeReason.Text;
            if(cmbEventType.Text == "Test Mid-term")
                objEvent.EventType = "Test Midterm";
            else
                objEvent.EventType = cmbEventType.Text;
			objEvent.Location = txtLocation.Text;
			objEvent.BlockCode = cmbBlock.Text;
			objEvent.RoomNo = txtRoomNo.Text;

			try
			{
				startlength = cmbStartTime.Text.Length;
				endlength = cmbEndTime.Text.Length;

				//StartTime = mStart.ToShortDateString() + " " + cmbStartTime.Text.Substring(0,startlength).Trim();
				//EndTime = mEnd.ToShortDateString() + " " + cmbEndTime.Text.Substring(0,8).Trim();

				StartTime = mStart.ToShortDateString() + " " + cmbStartTime.Text.Trim();
				EndTime = mEnd.ToShortDateString() + " " + cmbEndTime.Text.Trim();

				mStart=Convert.ToDateTime(StartTime);
				mEnd=Convert.ToDateTime(EndTime);
			}
			catch{}
			objEvent.StartDate = mStart;
			objEvent.EndDate = mEnd;
			objEvent.DateCompleted = dtDateComplete.Value;

			if(chkIsHoliday.Checked)
				objEvent.IsHoliday = 1;
			else
				objEvent.IsHoliday = 0;
			
			objEvent.Description = txtDescription.Text;
			objEvent.Notes = txtNote.Text;
			objEvent.ExceptionReason = cmbExceptionReason.Text;

			objEvent.CalendarEventStatus = cmbEventStatus.SelectedIndex;

			boolSuccess = objEvent.UpdateCalendarEventData();
			if(!boolSuccess)
				Scheduler.BusinessLayer.Message.ShowException("Updating Calendar Event record.", objEvent.Message);
		}

		private void llblTeacher1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmInstructorDlg fContDlg=new frmInstructorDlg();
			fContDlg.Mode="Add";
			if(fContDlg.ShowDialog()==DialogResult.OK)
			{
				Common.PopulateDropdown(
					cmbTeacher1, "Select " +
					"TeacherName = CASE " + 
					"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
					"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
					"ELSE NickName " +
					"END From " +
					"Contact Where ContactType=1 " +
					" Order By LastName, FirstName ");

                string query = "Select " +
                    "TeacherName = CASE " +
                    "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
                    "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
                    "ELSE NickName " +
                    "END From " +
                    "Contact Where ContactType=1 and " +
                    "ContactStatus=1 Order By LastName, FirstName ";

                IDataReader reader = DAC.SelectStatement(query);
                

				cmbTeacher1.SelectedIndex = cmbTeacher1.Items.Count-1;
                while (reader.Read())
                {
                    if (reader["TeacherName"] != DBNull.Value && reader["TeacherName"].ToString() != cmbTeacher1.Text)
                    {
                        cmbTeacher1.Items.Remove(reader["TeacherName"].ToString());
                    }
                }
				cmbTeacher2.Tag = cmbTeacher2.Text;
				cmbTeacher2.Items.Clear();
				foreach(string s in cmbTeacher1.Items)
				{
					cmbTeacher2.Items.Add(s);
				}
				cmbTeacher2.Text = cmbTeacher2.Tag.ToString();
			}
			fContDlg.Close();
			fContDlg.Dispose();
			fContDlg=null;
		}

		private void llblTeacher2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmInstructorDlg fContDlg=new frmInstructorDlg();
			fContDlg.Mode="Add";
			if(fContDlg.ShowDialog()==DialogResult.OK)
			{
				Common.PopulateDropdown(
					cmbTeacher2, "Select " +
					"TeacherName = CASE " + 
					"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
					"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
					"ELSE NickName " +
					"END From " +
					"Contact Where ContactType=1 " +
					" Order By LastName, FirstName ");
                cmbTeacher2.SelectedIndex = cmbTeacher2.Items.Count - 1;
                string query = "Select " +
                    "TeacherName = CASE " +
                    "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
                    "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
                    "ELSE NickName " +
                    "END From " +
                    "Contact Where ContactType=1 and " +
                    "ContactStatus=1 Order By LastName, FirstName ";

                IDataReader reader = DAC.SelectStatement(query);
                while (reader.Read())
                {
                    if (reader["TeacherName"] != DBNull.Value && reader["TeacherName"].ToString() != cmbTeacher2.Text)
                    {
                        cmbTeacher2.Items.Remove(reader["TeacherName"].ToString());
                    }
                }
				cmbTeacher1.Tag = cmbTeacher1.Text;
				cmbTeacher1.Items.Clear();
				foreach(string s in cmbTeacher2.Items)
				{
					cmbTeacher1.Items.Add(s);
				}
				cmbTeacher1.Text = cmbTeacher1.Tag.ToString();
			}
			fContDlg.Close();
			fContDlg.Dispose();
			fContDlg=null;
		}

		private void frmEventDlg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				this.ProcessTabKey(true);
			}
			if (e.KeyData == Keys.Escape) 
			{
				Close();
			}
		}

		private void txtRoomNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			Common.MaskInteger(e);
		}

		private void cmbEventType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (cmbEventType.Text=="Extra Class" && this.AllowExtraClasses == false)
            {
                Scheduler.BusinessLayer.Message.MsgError("Extra Classes are not allowed for this class. Sorry!");
                cmbEventType.SelectedIndex = -1;
            }
            else
            {
                if(cmbEventType.Items.IndexOf("Extra Class")==0)
                    switch (cmbEventType.Text)
                    {
                        default:
                        case "Extra Class": _eventtype = EventType.Extra; break;
                        case "Test Initial": _eventtype = EventType.Initial; break;
                        case "Test Mid-term": _eventtype = EventType.MidTerm; break;
                        case "Test Final": _eventtype = EventType.Final; break;
                    }
                else
                    switch (cmbEventType.Text)
                    {
                        default:
                        case "Test Initial": _eventtype = EventType.Initial; break;
                        case "Test Mid-term": _eventtype = EventType.MidTerm; break;
                        case "Test Final": _eventtype = EventType.Final; break;
                    }
            }
            
            /*
            if(cmbEventType.SelectedIndex==0)
				dtDateComplete.Enabled=false;
			else
				dtDateComplete.Enabled=true;
            */
		}

		private int WeekNumber_Entire4DayWeekRule(DateTime date)
		{
			const int JAN = 1;
			const int DEC = 12;
			const int LASTDAYOFDEC = 31;
			const int FIRSTDAYOFJAN = 1;
			const int THURSDAY = 4;
			bool ThursdayFlag = false;

			// Get the day number since the beginning of the year
			int DayOfYear = date.DayOfYear;

			// Get the numeric weekday of the first day of the 
			// year (using sunday as FirstDay)
			int StartWeekDayOfYear = 
				(int)(new DateTime(date.Year, JAN, FIRSTDAYOFJAN)).DayOfWeek;
			int EndWeekDayOfYear = 
				(int)(new DateTime(date.Year, DEC, LASTDAYOFDEC)).DayOfWeek;

			// Compensate for the fact that we are using monday
			// as the first day of the week
			if( StartWeekDayOfYear == 0)
				StartWeekDayOfYear = 7;
			if( EndWeekDayOfYear == 0)
				EndWeekDayOfYear = 7;

			// Calculate the number of days in the first and last week
			int DaysInFirstWeek = 8 - (StartWeekDayOfYear  );
			int DaysInLastWeek = 8 - (EndWeekDayOfYear );

			// If the year either starts or ends on a thursday it will have a 53rd week
			if (StartWeekDayOfYear == THURSDAY || EndWeekDayOfYear == THURSDAY)
				ThursdayFlag = true;

			// We begin by calculating the number of FULL weeks between the start of the year and
			// our date. The number is rounded up, so the smallest possible value is 0.
			int FullWeeks = (int) Math.Ceiling((DayOfYear - (DaysInFirstWeek))/7.0);
    
			int WeekNumber = FullWeeks; 
     
			// If the first week of the year has at least four days, then the actual week number for our date
			// can be incremented by one.
			if (DaysInFirstWeek >= THURSDAY)
				WeekNumber = WeekNumber +1;

			// If week number is larger than week 52 (and the year doesn't either start or end on a thursday)
			// then the correct week number is 1. 
			if (WeekNumber > 52 && !ThursdayFlag)
				WeekNumber = 1;

			// If week number is still 0, it means that we are trying to evaluate the week number for a
			// week that belongs in the previous year (since that week has 3 days or less in our date's year).
			// We therefore make a recursive call using the last day of the previous year.
			if (WeekNumber == 0)
				WeekNumber = WeekNumber_Entire4DayWeekRule(
					new DateTime(date.Year-1, DEC, LASTDAYOFDEC));
			return WeekNumber;
		}

		private void SetTime(ComboBox mcb, string mTime)
		{
			mcb.Text = mTime;
		}

		private void SetTime(ComboBox mcb, string mTime, bool Dummy)
		{
			mTime = Convert.ToDateTime(mTime).ToString("HH:mm");
			mTime = mTime.Substring(0,8);
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
			}
		}

		private void cmbEventStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(_mode=="Edit")
			{
				if(cmbEventStatus.SelectedIndex==1)
				{
					Common.MakeReadOnly(pnlBody, false);
					cmbEventStatus.Enabled=true;
				}
				else
				{
					Common.MakeEnabled(pnlBody, false);
				}
				cmbEventType_SelectedIndexChanged(sender, null);

				if(OpenFromClsProg)
				{
					llblClass.Enabled=false;
					llblProgram.Enabled=false;
					llblClient.Enabled=false;
					llbDepartment.Enabled=false;
					cmbClient.Enabled=false;
					cmbDept.Enabled=false;
					cmbClass.Enabled=false;
					cmbProgram.Enabled=false;
					cmbEvent.Enabled=false;
				}
			}
		}

		private void cmbProgram_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbProgram.SelectedIndex==0) intProgramID=0;			
			intProgramID = Common.GetCompanyID(
				"Select ProgramID From Program " +
				"Where ([Name]= @CompanyName OR NickName=@CompanyName)", cmbProgram.Text
				);

			if(intProgramID!=0)
			{
				Common.PopulateDropdown(
					cmbClass, "Select ClassName = CASE " +
					"WHEN NickName IS NULL THEN Name " +
					"WHEN NickName = '' THEN Name " +
					"ELSE NickName " +
					"END " +
					"From Course Where CourseStatus=0 and ProgramID=" + intProgramID + 
					" Order By ClassName ");
			}

			cmbEvent.Items.Clear();
			cmbEvent.Items.AddRange(new object[]{"Test Initial", "Test Mid-term", "Test Final"});
		}

		private void cmbClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbClass.SelectedIndex==0) intClassID=0;
			intClassID = Common.GetCompanyID(
				"Select CourseID From Course " +
				"Where ([Name]= @CompanyName OR NickName=@CompanyName) and ProgramID=" + intProgramID.ToString(), cmbClass.Text
				);


			if(cmbClass.Text.Trim()!="")
			{
				cmbProgram.Enabled=false;
				llblProgram.Enabled=false;
				cmbEvent.Items.Clear();
				cmbEvent.Items.AddRange(new object[]{"Class Event", "Test Initial", "Test Mid-term", "Test Final"});
			}
			else
			{
				cmbProgram.Enabled=true;
				llblProgram.Enabled=true;
				cmbEvent.Items.Clear();
				cmbEvent.Items.AddRange(new object[]{"Test Initial", "Test Mid-term", "Test Final"});
			}
		}

		private void cmbClient_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbClient.SelectedIndex==0) intClientID=0;			
			intClientID = Common.GetCompanyID(
				"Select ContactID From Contact " +
				"Where (CompanyName =@CompanyName OR NickName=@CompanyName)", cmbClient.Text
				);

			if(intClientID!=0)
			{
				Common.PopulateDropdown(
					cmbDept, "Select CompanyName = CASE " +
					"WHEN C.NickName IS NULL THEN C.CompanyName " +
					"WHEN C.NickName = '' THEN C.CompanyName " +
					"ELSE C.NickName " +
					"END " +
					"From Department D, Contact C Where D.ContactID=C.ContactID and " +
					"D.DepartmentStatus=0 and D.ClientID=" + intClientID + 
					" Order By D.CompanyName ");
			}
		}

		private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbDept.SelectedIndex==0) intDepartmentID=0;			
			intDepartmentID = Common.GetCompanyID(
				"Select D.DepartmentID from Department D, Contact C " +
				"Where D.ContactID=C.ContactID and (C.CompanyName= @CompanyName OR C.NickName=@CompanyName) and ClientID=" + intClientID.ToString(), cmbDept.Text
				);


			if(intDepartmentID!=0)
			{
				Common.PopulateDropdown(
					cmbProgram, "Select ProgramName = CASE " +
					"WHEN NickName IS NULL THEN Name " +
					"WHEN NickName = '' THEN Name " +
					"ELSE NickName " +
					"END " +
					"From Program Where ProgramStatus=0 and DepartmentID=" + intDepartmentID + 
					" Order By ProgramName ");
			}
		}

		private void llblClient_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmClientDlg fContDlg=new frmClientDlg();
			fContDlg.Mode="Add";
			string str=cmbClient.Text;
			if(fContDlg.ShowDialog()==DialogResult.OK)
			{
				Common.PopulateDropdown(
					cmbClient, "Select CompanyName = CASE " +
					"WHEN NickName IS NULL THEN CompanyName " +
					"WHEN NickName = '' THEN CompanyName " +
					"ELSE NickName " +
					"END " +
					"From Contact Where ContactType=2 and " +
					"ContactStatus=0 Order By CompanyName ");

				cmbClient.Text=str;
			}
			fContDlg.Close();
			fContDlg.Dispose();
			fContDlg=null;
		}

		private void llbDepartment_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmDepartmentDlg fDeptDlg=new frmDepartmentDlg();
			fDeptDlg.Mode="Add";
			string str=cmbDept.Text;
			if(fDeptDlg.ShowDialog()==DialogResult.OK)
			{
				//Common.PopulateDropdown(
				//	cmbDept, "Select C.CompanyName from Department D, Contact C Where D.ContactID=C.ContactID and D.DepartmentStatus=0 Order By D.DepartmentID");
				//cmbDept.SelectedIndex = cmbDept.Items.Count-1;

				cmbClient_SelectedIndexChanged(sender, null);
				cmbDept.Text=str;
			}
			fDeptDlg.Close();
			fDeptDlg.Dispose();
			fDeptDlg=null;
		}

		private void llblProgram_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmProgramDlg fProgDlg=new frmProgramDlg();
			fProgDlg.Mode="Add";
			string str=cmbProgram.Text;
			if(fProgDlg.ShowDialog()==DialogResult.OK)
			{
				cmbDept_SelectedIndexChanged(sender, null);
				cmbProgram.Text = str;
			}
			fProgDlg.Close();
			fProgDlg.Dispose();
			fProgDlg=null;
		}

		private void llblClass_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmClassDlg fProgDlg=new frmClassDlg();
			fProgDlg.Mode="Add";
			string str=cmbClass.Text;
			if(fProgDlg.ShowDialog()==DialogResult.OK)
			{
				cmbProgram_SelectedIndexChanged(sender, null);
				cmbClass.Text = str;
			}
			fProgDlg.Close();
			fProgDlg.Dispose();
			fProgDlg=null;
		}

		private void cmbEndTime_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cmbStartTime_TextChanged(object sender, System.EventArgs e)
		{
			if(dtStart.Value!=dtEnd.Value) return;
			try
			{
				if(cmbStartTime.Text!="")
				{
					bool Go = false;
					cmbEndTime.Items.Clear();
					foreach(string s in cmbStartTime.Items)
					{
						if(Go==false)
						{
							if(cmbStartTime.Text.Substring(0,2).Trim()==s.Substring(0,2))
							{
								Go=true;
								continue;
							}
						}
						if(Go)
						{
							cmbEndTime.Items.Add(s);						
						}
					}

					if(cmbStartTime.Text.Substring(3,2).Trim()!="00")
					{
						cmbEndTime.Items.Remove(cmbEndTime.Items[0].ToString());
					}
				}
			}
			catch{}
		}

		private void cmbStartTime_Leave(object sender, System.EventArgs e)
		{
			try
			{
				DateTime dt=Convert.ToDateTime(cmbStartTime.Text);
			}
			catch
			{
				BusinessLayer.Message.MsgError("Invalid Start Time");
				cmbStartTime.Focus();
			}
		}

		private void cmbEndTime_Leave(object sender, System.EventArgs e)
		{
			try
			{
				DateTime dt=Convert.ToDateTime(cmbEndTime.Text);
			}
			catch
			{
				BusinessLayer.Message.MsgError("Invalid End Time");
				cmbEndTime.Focus();
			}
		}

		private void dtEnd_ValueChanged(object sender, System.EventArgs e)
		{
			if((dtEnd.Value>dtStart.Value) || (dtEnd.Value<dtStart.Value))
			{
				cmbEndTime.Items.Clear();
				foreach(string s in cmbStartTime.Items)
				{
					cmbEndTime.Items.Add(s);
				}
			}
		}

		private void dtStart_ValueChanged(object sender, System.EventArgs e)
		{
			if((dtEnd.Value>dtStart.Value) || (dtEnd.Value<dtStart.Value))
			{
				cmbEndTime.Items.Clear();
				foreach(string s in cmbStartTime.Items)
				{
					cmbEndTime.Items.Add(s);
				}
			}
		}

		private void frmEventDlg_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(File.Exists(strAppPath))
				File.Delete(strAppPath);
		}

        private void SetDefaultEventType()
        {
            if (!AllowExtraClasses)
                cmbEventType.Items.RemoveAt(cmbEventType.Items.IndexOf("Extra Class"));
            if (!AllowTestInitial)
                cmbEventType.Items.RemoveAt(cmbEventType.Items.IndexOf("Test Initial"));
            if (!AllowTestMid)
            {
                int index = cmbEventType.Items.IndexOf("Test Midterm");
                if(index >= 0)
                    cmbEventType.Items.RemoveAt(index);
                index = cmbEventType.Items.IndexOf("Test Mid-term");
                if (index >= 0)
                    cmbEventType.Items.RemoveAt(index);
                //cmbEventType.Items.RemoveAt(cmbEventType.Items.IndexOf("Test Mid-term"));
            }
            if(!AllowTestFinal)
                cmbEventType.Items.RemoveAt(cmbEventType.Items.IndexOf("Test Final"));

            if (cmbEventType.Items.Count > 0)
            {
                cmbEventType.SelectedIndex = 0;

                switch (cmbEventType.Text)
                {
                    default:
                    case "Extra Class": _eventtype = EventType.Extra; break;
                    case "Test Initial": _eventtype = EventType.Initial; break;
                    case "Test Midterm": _eventtype = EventType.MidTerm; break;
                    case "Test Mid-term": _eventtype = EventType.MidTerm; break;
                    case "Test Final": _eventtype = EventType.Final; break;
                }
            }
            else
                cmbEventType.SelectedIndex = -1;
        }

        private void chkEventModified_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEventModified.Checked)
                SetEventModificationControls(true);
            else
                SetEventModificationControls(false);
        }
        private void SetEventModificationControls(bool boolEnableControls)
        {
            if (boolEnableControls)
            {
                //cmbEventStatus_I.Enabled = true;
                chkEventStatus_I.Enabled = true;
                chkEventModified.Checked = true;
                if (!chkEventStatus_I.Checked)
                {
                    cmbTeacher2.Enabled = true;
                    //cmbExceptionReason_I.Enabled = true;
                    txtChangeReason.Enabled = true;

                }
            }
            else
            {
                chkEventModified.Checked = false;
                //if(!chkEventStatus_I.Checked) chkEventStatus_I.Enabled = false;
                cmbTeacher2.Enabled = false;
                //cmbExceptionReason_I.Enabled = false;
                txtChangeReason.Enabled = false;
            }
        }

        private void chkEventStatus_I_CheckedChanged(object sender, EventArgs e)
        {
            //IsEventChanged = true;
            //if (GetCurrentEventID((TabPage)pnlEvent.Parent) > 0)
            //{
                
            //}
            //cmbEventType_SelectedIndexChanged(sender, null);
            if (chkEventStatus_I.Checked)
            {
                Common.MakeReadOnly(pnlBody, false);
                chkEventStatus_I.Enabled = true;
                cmbExceptionReason.Enabled = true;
               
            }
            else
            {
                Common.MakeEnabled(pnlBody, false);
                cmbTeacher2.Enabled = chkEventModified.Checked;
                txtChangeReason.Enabled = chkEventModified.Checked;
                //cmbExceptionReason_I.Enabled = false;
            }
        }

	}
}