using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing.Printing;
using Scheduler.BusinessLayer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmClassDlg.
	/// </summary>
	public class frmClassDlg : System.Windows.Forms.Form
    {
        #region Initialization
        #region Controls
        private TabControl tbcCourse;
		private TabPage tbpCourse;
		private TabPage tbpDescription;
		private TabPage tbpSpecialRemarks;
		private TabPage tbpCurriculam;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label4;
		private Label label3;
		private ComboBox cmbCourseType;
		private Label label2;
		private Label label1;
		private Label lblPassword;
		private Label lblStatus;
		private Label lblUser;
		private ComboBox cmbStatus;
		private TextBox txtDescription;
		private TextBox txtRemarks;
		private TextBox txtCurriculam;
		private Button btnCancel;
		private Button btnSave;
		private TextBox txtNameRomaji;
		private TextBox txtNamePhonetic;
		private TextBox txtHomeWorkMinutes;
		private TextBox txtNumberStudents;
		private TextBox txtInitialEvent;
		private TextBox txtFinalEvent;
		private TextBox txtMidtermEvent;
		private TextBox txtInitialForm;
		private TextBox txtMidtermForm;
		private TextBox txtFinalForm;
		private TextBox txtCourseName;
		private ComboBox cmbProgram;
		private Label label13;
		private GroupBox groupBox1;
		private Label label12;
		private GroupBox grpTest;
		private LinkLabel llblProgram;
		private Label label11;
		private GroupBox groupBox2;
		private LinkLabel llblFinalEvt;
		private LinkLabel llblMidEvt;
        private LinkLabel llblInitialEvt;
        private IContainer components;
		private LinkLabel llblEvent;
		private TextBox txtEvent;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label label14;
		private Button btnDelete;
		private LinkLabel llblClient;
		private ComboBox cmbClient;
		private LinkLabel llbDepartment;
		private ComboBox cmbDept;
		private TextBox txtNickName;
		private Label lblNickName;
        private TabPage tbpClassEvent;
        private TabPage tbpOtherEvents;
		private Panel pnlEvent;
		private Panel pnlBody_I;
		private Label lblExReason_I;
		private ComboBox cmbExceptionReason_I;
        private GroupBox groupBox4;
		private PictureBox picAlert_I;
		private CheckBox chkIsHoliday;
		private Label lblIsHoliday_I;
		private LinkLabel llblTeacher2_I;
		private LinkLabel llblTeacher1_I;
		private Label lblDtComp_I;
		private TextBox txtNote_I;
		private TextBox txtDescription_I;
        private Label lblDescription_I;
		private TextBox txtRoomNo_I;
		private Label lblRoomNo_I;
		private TextBox txtLocation_I;
		private Label lblLocation_I;
		private Label lblBlock_I;
		private Label lblEnddt_I;
		private Label lblStartdt_I;
		private Label lblEventType_I;
		private TextBox txtRomaji_I;
		private TextBox txtPhonetic_I;
		private Label lblRomaji_I;
		private Label lblPhonetic_I;
		private TextBox txtName_I;
		private Label lblName_I;
		private GroupBox groupBox5;
		private ComboBox cmbTeacher2_I;
		private ComboBox cmbTeacher1_I;
		private DateTimePicker dtDateComplete_I;
		public ComboBox cmbEndTime;
		public ComboBox cmbStartTime;
        private GroupBox groupBox6;
		private ComboBox cmbBlock_I;
		public DateTimePicker dtEnd;
		public DateTimePicker dtStart;
		private ComboBox cmbEventType_I;
		public Label lblRecurrenceText_I;
		private Panel pnlTop_I;
		private Label lblRecurrenceText1_I;
		private PictureBox picAlert1_I;
        private Panel pnlBottom;
		private Button btn_ClearRecc;
		private Button btnRecurrence;
		#endregion Controls

        #region Declarations
        private int intProgramID=0;
		private bool deleted=false;
		private int intClientID=0;
		private int intDepartmentID=0;
		private string strEventText="";
		private int intIndex=0;
        private bool IsRecurringSeries = false;
        private bool HasTestInitialEvent = false;
        private bool HasTestMidtermEvent = false;
        private bool HasTestFinalEvent = false;

		//Events newly added
		public EventType evtType = 0;
		private bool boolSaveSeries_initial=true;
		private bool boolNoOfRecords_Initial = false;
		private string strAppPath = Application.StartupPath + "\\Recurrence.xml";
		private Events objEvent=null;
		private Serialize AP=null;
        private frmEventDlg frmEvent = null;
		private string XMLData_Initial="";
		private string RepeatRule = "";
		private string NegativeException = "";
		private int IsRecurrenceFlag_Initial=0; // tells whether the current event is newly-created or already present
		private string NoEntries = "";
		private string ReccType = "";
		private string Pattern1 = "";
		private string Pattern2 = "";
		private string _startdate_Initial;
		private string _enddate_Initial;
		private string _eventmode_Initial="";
		private int  _eventid_Initial=0;
		private int  _calendareventid_Initial=0;
		//end

		private int _curreventid=0;
		private string StartTime=string.Empty;
		private string EndTime=string.Empty;
		private string StartDate=string.Empty;
		private string EndDate=string.Empty;
		private int[] eventid = new int[4];
		private int[] calendareventid = new int[4];
		private bool IsEventChanged=false;

		private bool AutoSave=true;
		private System.Windows.Forms.Button btnPageSetup;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Drawing.Printing.PrintDocument printDocument1;
        private DataTable dtblDates = null;
        public DevExpress.XtraGrid.GridControl grdEvents;
        public DevExpress.XtraGrid.Views.Grid.GridView gvwEvents;
        public DevExpress.XtraGrid.Columns.GridColumn gcolEventID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEventType;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCaldendarEventID;
        private Button btnDel;
        private Button btnEdit;
        private Button btnAdd;
        private Panel pnlButtons;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStartDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEndDateTime;

		private PageSettings ps=null;
        
        private CheckBox chkEventModified;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        NormalPrinting nm = null;
        private CheckBox chkEventStatus_I;
        private TextBox txtChangeReason_I;
        private Label lblChangeReason_I;
        BusinessLayer.DevExpressPrinting xtraPrinting;
        #endregion

        #region Constructors
        public frmClassDlg()
		{
			InitializeComponent();

            //IsRecurringSeries = true;

			//Common.PopulateDropdown(
			//	cmbProgram, "Select Name from Program Where ProgramStatus=0 Order By ProgramID");
			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
					"WHEN NickName IS NULL THEN CompanyName " +
					"WHEN NickName = '' THEN CompanyName " +
					"ELSE NickName " +
					"END From " +
					"Contact Where ContactType=2 " +
					" Order By CompanyName");

            

			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FirstName ");

            
			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				" Order By LastName, FirstName");

			IsEventChanged=false;
		}
		public frmClassDlg(int id)
		{
			InitializeComponent();
			_courseid=id;

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 " +
				"Order By Companyname");

			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FirstName ");
			
			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
                "Order By LastName, FirstName");

			IsEventChanged=false;
		}
		public frmClassDlg(int id, int eventindex)
		{
			InitializeComponent();

			//tbpClassEvent.Controls.Remove(pnlEvent);

            //IsRecurringSeries = true;

			_courseid=id;
			_mode="Edit";

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 " +
				"Order By Companyname");

			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FirstName ");
			
			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
                "Order By LastName, FirstName");

            if (eventindex != 4)
                intIndex = eventindex;
            else intIndex = 3;
			LoadData();
			IsEventChanged=false;

			switch(eventindex)
			{
                case 0:
                case 1:
                case 2:
                case 4:
                    tbcCourse.SelectedTab = tbpOtherEvents;
                    break;
				default : 
                case 3 :
				{
                    tbcCourse.SelectedTab = tbpClassEvent;
					break;
				}
			}
            tbcCourse_SelectedIndexChanged(tbcCourse, new EventArgs());
            txtNote_I.Height = 130;
		}
    	public frmClassDlg(int id, int eventindex, int CalID)
		{
			InitializeComponent();

			//tbpClassEvent.Controls.Remove(pnlEvent);

			_courseid=id;
			_mode="Edit";

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 " +
				"Order By Companyname");

			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
				"Order By LastName, FirstName ");
			
			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				"TeacherName = CASE " + 
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 " +
                "Order By LastName, FirstName");

			calendareventid[eventindex] = CalID;
			intIndex = eventindex;
			IsEventChanged=false;
			LoadData();
			IsEventChanged=false;

			switch(eventindex)
			{
                case 0:
                case 1:
                case 2:
                case 4:
                    tbcCourse.SelectedTab = tbpOtherEvents;
                    break;
                default: 
				case 3 :
				{
					calendareventid[3] = CalID;
					tbcCourse.SelectedTab = tbpClassEvent;
					break;
				}
			}
			//tbcCourse_SelectedIndexChanged(tbcCourse, new EventArgs());
			//txtNote_I.Height = 150;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassDlg));
            this.tbcCourse = new System.Windows.Forms.TabControl();
            this.tbpCourse = new System.Windows.Forms.TabPage();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.lblNickName = new System.Windows.Forms.Label();
            this.llblClient = new System.Windows.Forms.LinkLabel();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.llbDepartment = new System.Windows.Forms.LinkLabel();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.llblEvent = new System.Windows.Forms.LinkLabel();
            this.llblFinalEvt = new System.Windows.Forms.LinkLabel();
            this.llblMidEvt = new System.Windows.Forms.LinkLabel();
            this.llblInitialEvt = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.llblProgram = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.txtFinalForm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMidtermForm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInitialForm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFinalEvent = new System.Windows.Forms.TextBox();
            this.txtMidtermEvent = new System.Windows.Forms.TextBox();
            this.txtInitialEvent = new System.Windows.Forms.TextBox();
            this.txtHomeWorkMinutes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumberStudents = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameRomaji = new System.Windows.Forms.TextBox();
            this.txtNamePhonetic = new System.Windows.Forms.TextBox();
            this.cmbCourseType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tbpDescription = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tbpSpecialRemarks = new System.Windows.Forms.TabPage();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tbpCurriculam = new System.Windows.Forms.TabPage();
            this.txtCurriculam = new System.Windows.Forms.TextBox();
            this.tbpClassEvent = new System.Windows.Forms.TabPage();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btn_ClearRecc = new System.Windows.Forms.Button();
            this.btnRecurrence = new System.Windows.Forms.Button();
            this.pnlBody_I = new System.Windows.Forms.Panel();
            this.txtChangeReason_I = new System.Windows.Forms.TextBox();
            this.lblChangeReason_I = new System.Windows.Forms.Label();
            this.chkEventStatus_I = new System.Windows.Forms.CheckBox();
            this.chkEventModified = new System.Windows.Forms.CheckBox();
            this.lblExReason_I = new System.Windows.Forms.Label();
            this.cmbExceptionReason_I = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.picAlert_I = new System.Windows.Forms.PictureBox();
            this.chkIsHoliday = new System.Windows.Forms.CheckBox();
            this.lblIsHoliday_I = new System.Windows.Forms.Label();
            this.llblTeacher2_I = new System.Windows.Forms.LinkLabel();
            this.llblTeacher1_I = new System.Windows.Forms.LinkLabel();
            this.lblDtComp_I = new System.Windows.Forms.Label();
            this.txtNote_I = new System.Windows.Forms.TextBox();
            this.txtDescription_I = new System.Windows.Forms.TextBox();
            this.lblDescription_I = new System.Windows.Forms.Label();
            this.txtRoomNo_I = new System.Windows.Forms.TextBox();
            this.lblRoomNo_I = new System.Windows.Forms.Label();
            this.txtLocation_I = new System.Windows.Forms.TextBox();
            this.lblLocation_I = new System.Windows.Forms.Label();
            this.lblBlock_I = new System.Windows.Forms.Label();
            this.lblEnddt_I = new System.Windows.Forms.Label();
            this.lblStartdt_I = new System.Windows.Forms.Label();
            this.lblEventType_I = new System.Windows.Forms.Label();
            this.txtRomaji_I = new System.Windows.Forms.TextBox();
            this.txtPhonetic_I = new System.Windows.Forms.TextBox();
            this.lblRomaji_I = new System.Windows.Forms.Label();
            this.lblPhonetic_I = new System.Windows.Forms.Label();
            this.txtName_I = new System.Windows.Forms.TextBox();
            this.lblName_I = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbTeacher2_I = new System.Windows.Forms.ComboBox();
            this.cmbTeacher1_I = new System.Windows.Forms.ComboBox();
            this.dtDateComplete_I = new System.Windows.Forms.DateTimePicker();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbBlock_I = new System.Windows.Forms.ComboBox();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.cmbEventType_I = new System.Windows.Forms.ComboBox();
            this.lblRecurrenceText_I = new System.Windows.Forms.Label();
            this.pnlTop_I = new System.Windows.Forms.Panel();
            this.lblRecurrenceText1_I = new System.Windows.Forms.Label();
            this.picAlert1_I = new System.Windows.Forms.PictureBox();
            this.tbpOtherEvents = new System.Windows.Forms.TabPage();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.grdEvents = new DevExpress.XtraGrid.GridControl();
            this.gvwEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolCaldendarEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStartDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEndDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.tbcCourse.SuspendLayout();
            this.tbpCourse.SuspendLayout();
            this.tbpDescription.SuspendLayout();
            this.tbpSpecialRemarks.SuspendLayout();
            this.tbpCurriculam.SuspendLayout();
            this.tbpClassEvent.SuspendLayout();
            this.pnlEvent.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBody_I.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlert_I)).BeginInit();
            this.pnlTop_I.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlert1_I)).BeginInit();
            this.tbpOtherEvents.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcCourse
            // 
            this.tbcCourse.Controls.Add(this.tbpCourse);
            this.tbcCourse.Controls.Add(this.tbpDescription);
            this.tbcCourse.Controls.Add(this.tbpSpecialRemarks);
            this.tbcCourse.Controls.Add(this.tbpCurriculam);
            this.tbcCourse.Controls.Add(this.tbpClassEvent);
            this.tbcCourse.Controls.Add(this.tbpOtherEvents);
            this.tbcCourse.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcCourse.Location = new System.Drawing.Point(0, 0);
            this.tbcCourse.Multiline = true;
            this.tbcCourse.Name = "tbcCourse";
            this.tbcCourse.SelectedIndex = 0;
            this.tbcCourse.ShowToolTips = true;
            this.tbcCourse.Size = new System.Drawing.Size(770, 569);
            this.tbcCourse.TabIndex = 0;
            this.tbcCourse.SelectedIndexChanged += new System.EventHandler(this.tbcCourse_SelectedIndexChanged);
            // 
            // tbpCourse
            // 
            this.tbpCourse.Controls.Add(this.txtCourseName);
            this.tbpCourse.Controls.Add(this.txtNickName);
            this.tbpCourse.Controls.Add(this.lblNickName);
            this.tbpCourse.Controls.Add(this.llblClient);
            this.tbpCourse.Controls.Add(this.cmbClient);
            this.tbpCourse.Controls.Add(this.llbDepartment);
            this.tbpCourse.Controls.Add(this.cmbDept);
            this.tbpCourse.Controls.Add(this.label14);
            this.tbpCourse.Controls.Add(this.label7);
            this.tbpCourse.Controls.Add(this.label6);
            this.tbpCourse.Controls.Add(this.label5);
            this.tbpCourse.Controls.Add(this.txtEvent);
            this.tbpCourse.Controls.Add(this.llblEvent);
            this.tbpCourse.Controls.Add(this.llblFinalEvt);
            this.tbpCourse.Controls.Add(this.llblMidEvt);
            this.tbpCourse.Controls.Add(this.llblInitialEvt);
            this.tbpCourse.Controls.Add(this.label11);
            this.tbpCourse.Controls.Add(this.groupBox2);
            this.tbpCourse.Controls.Add(this.llblProgram);
            this.tbpCourse.Controls.Add(this.label12);
            this.tbpCourse.Controls.Add(this.grpTest);
            this.tbpCourse.Controls.Add(this.label13);
            this.tbpCourse.Controls.Add(this.groupBox1);
            this.tbpCourse.Controls.Add(this.cmbProgram);
            this.tbpCourse.Controls.Add(this.txtFinalForm);
            this.tbpCourse.Controls.Add(this.label8);
            this.tbpCourse.Controls.Add(this.txtMidtermForm);
            this.tbpCourse.Controls.Add(this.label9);
            this.tbpCourse.Controls.Add(this.txtInitialForm);
            this.tbpCourse.Controls.Add(this.label10);
            this.tbpCourse.Controls.Add(this.txtFinalEvent);
            this.tbpCourse.Controls.Add(this.txtMidtermEvent);
            this.tbpCourse.Controls.Add(this.txtInitialEvent);
            this.tbpCourse.Controls.Add(this.txtHomeWorkMinutes);
            this.tbpCourse.Controls.Add(this.label4);
            this.tbpCourse.Controls.Add(this.txtNumberStudents);
            this.tbpCourse.Controls.Add(this.label3);
            this.tbpCourse.Controls.Add(this.txtNameRomaji);
            this.tbpCourse.Controls.Add(this.txtNamePhonetic);
            this.tbpCourse.Controls.Add(this.cmbCourseType);
            this.tbpCourse.Controls.Add(this.label2);
            this.tbpCourse.Controls.Add(this.label1);
            this.tbpCourse.Controls.Add(this.lblPassword);
            this.tbpCourse.Controls.Add(this.lblStatus);
            this.tbpCourse.Controls.Add(this.lblUser);
            this.tbpCourse.Controls.Add(this.cmbStatus);
            this.tbpCourse.Location = new System.Drawing.Point(4, 22);
            this.tbpCourse.Name = "tbpCourse";
            this.tbpCourse.Size = new System.Drawing.Size(762, 543);
            this.tbpCourse.TabIndex = 0;
            this.tbpCourse.Text = "Class";
            this.tbpCourse.UseVisualStyleBackColor = true;
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(208, 25);
            this.txtCourseName.MaxLength = 255;
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(320, 21);
            this.txtCourseName.TabIndex = 0;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(208, 98);
            this.txtNickName.MaxLength = 255;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(320, 21);
            this.txtNickName.TabIndex = 3;
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNickName.Location = new System.Drawing.Point(64, 100);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(96, 13);
            this.lblNickName.TabIndex = 338;
            this.lblNickName.Text = "Abbreviated Name";
            // 
            // llblClient
            // 
            this.llblClient.AutoSize = true;
            this.llblClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llblClient.Location = new System.Drawing.Point(64, 186);
            this.llblClient.Name = "llblClient";
            this.llblClient.Size = new System.Drawing.Size(34, 13);
            this.llblClient.TabIndex = 92;
            this.llblClient.TabStop = true;
            this.llblClient.Text = "Client";
            this.llblClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClient_LinkClicked);
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Location = new System.Drawing.Point(208, 184);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(320, 21);
            this.cmbClient.TabIndex = 5;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // llbDepartment
            // 
            this.llbDepartment.AutoSize = true;
            this.llbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llbDepartment.Location = new System.Drawing.Point(64, 210);
            this.llbDepartment.Name = "llbDepartment";
            this.llbDepartment.Size = new System.Drawing.Size(64, 13);
            this.llbDepartment.TabIndex = 90;
            this.llbDepartment.TabStop = true;
            this.llbDepartment.Text = "Department";
            this.llbDepartment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDepartment_LinkClicked);
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(208, 208);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(320, 21);
            this.cmbDept.TabIndex = 6;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Location = new System.Drawing.Point(64, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 84;
            this.label14.Text = "Class Event";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(64, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 83;
            this.label7.Text = "Test Final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(64, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 82;
            this.label6.Text = "Test Mid-term";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(64, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 81;
            this.label5.Text = "Test Initial";
            // 
            // txtEvent
            // 
            this.txtEvent.Enabled = false;
            this.txtEvent.Location = new System.Drawing.Point(416, 136);
            this.txtEvent.MaxLength = 15;
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.ReadOnly = true;
            this.txtEvent.Size = new System.Drawing.Size(112, 21);
            this.txtEvent.TabIndex = 80;
            this.txtEvent.TabStop = false;
            this.txtEvent.Tag = "N";
            this.txtEvent.Text = "0";
            this.txtEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEvent.Visible = false;
            // 
            // llblEvent
            // 
            this.llblEvent.Location = new System.Drawing.Point(208, 128);
            this.llblEvent.Name = "llblEvent";
            this.llblEvent.Size = new System.Drawing.Size(320, 54);
            this.llblEvent.TabIndex = 4;
            this.llblEvent.TabStop = true;
            this.llblEvent.Text = "None";
            this.llblEvent.MouseLeave += new System.EventHandler(this.llblEvent_MouseLeave);
            this.llblEvent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblEvent_LinkClicked);
            this.llblEvent.MouseEnter += new System.EventHandler(this.llblEvent_MouseEnter);
            // 
            // llblFinalEvt
            // 
            this.llblFinalEvt.Location = new System.Drawing.Point(208, 424);
            this.llblFinalEvt.Name = "llblFinalEvt";
            this.llblFinalEvt.Size = new System.Drawing.Size(320, 21);
            this.llblFinalEvt.TabIndex = 12;
            this.llblFinalEvt.TabStop = true;
            this.llblFinalEvt.Text = "None";
            this.llblFinalEvt.TextChanged += new System.EventHandler(this.llblFinalEvt_TextChanged);
            this.llblFinalEvt.MouseLeave += new System.EventHandler(this.llblFinalEvt_MouseLeave);
            this.llblFinalEvt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblFinalEvt_LinkClicked);
            this.llblFinalEvt.MouseEnter += new System.EventHandler(this.llblFinalEvt_MouseEnter);
            // 
            // llblMidEvt
            // 
            this.llblMidEvt.Location = new System.Drawing.Point(208, 376);
            this.llblMidEvt.Name = "llblMidEvt";
            this.llblMidEvt.Size = new System.Drawing.Size(320, 21);
            this.llblMidEvt.TabIndex = 11;
            this.llblMidEvt.TabStop = true;
            this.llblMidEvt.Text = "None";
            this.llblMidEvt.TextChanged += new System.EventHandler(this.llblMidEvt_TextChanged);
            this.llblMidEvt.MouseLeave += new System.EventHandler(this.llblMidEvt_MouseLeave);
            this.llblMidEvt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblMidEvt_LinkClicked);
            this.llblMidEvt.MouseEnter += new System.EventHandler(this.llblMidEvt_MouseEnter);
            // 
            // llblInitialEvt
            // 
            this.llblInitialEvt.Location = new System.Drawing.Point(208, 330);
            this.llblInitialEvt.Name = "llblInitialEvt";
            this.llblInitialEvt.Size = new System.Drawing.Size(320, 21);
            this.llblInitialEvt.TabIndex = 10;
            this.llblInitialEvt.TabStop = true;
            this.llblInitialEvt.Text = "None";
            this.llblInitialEvt.TextChanged += new System.EventHandler(this.llblInitialEvt_TextChanged);
            this.llblInitialEvt.MouseLeave += new System.EventHandler(this.llblInitialEvt_MouseLeave);
            this.llblInitialEvt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblInitialEvt_LinkClicked);
            this.llblInitialEvt.MouseEnter += new System.EventHandler(this.llblInitialEvt_MouseEnter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(32, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 75;
            this.label11.Text = "Test Event Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(26, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 3);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            // 
            // llblProgram
            // 
            this.llblProgram.AutoSize = true;
            this.llblProgram.Location = new System.Drawing.Point(64, 234);
            this.llblProgram.Name = "llblProgram";
            this.llblProgram.Size = new System.Drawing.Size(47, 13);
            this.llblProgram.TabIndex = 4;
            this.llblProgram.TabStop = true;
            this.llblProgram.Text = "Program";
            this.llblProgram.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblProgram_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(32, 478);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 73;
            this.label12.Text = "Class Details";
            // 
            // grpTest
            // 
            this.grpTest.Location = new System.Drawing.Point(26, 487);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(558, 3);
            this.grpTest.TabIndex = 72;
            this.grpTest.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(32, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 71;
            this.label13.Text = "Basic Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(26, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 3);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // cmbProgram
            // 
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Location = new System.Drawing.Point(208, 232);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(320, 21);
            this.cmbProgram.TabIndex = 7;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // txtFinalForm
            // 
            this.txtFinalForm.Enabled = false;
            this.txtFinalForm.Location = new System.Drawing.Point(208, 448);
            this.txtFinalForm.MaxLength = 50;
            this.txtFinalForm.Name = "txtFinalForm";
            this.txtFinalForm.Size = new System.Drawing.Size(320, 21);
            this.txtFinalForm.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(64, 450);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Test Final Form";
            // 
            // txtMidtermForm
            // 
            this.txtMidtermForm.Enabled = false;
            this.txtMidtermForm.Location = new System.Drawing.Point(208, 398);
            this.txtMidtermForm.MaxLength = 50;
            this.txtMidtermForm.Name = "txtMidtermForm";
            this.txtMidtermForm.Size = new System.Drawing.Size(320, 21);
            this.txtMidtermForm.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Location = new System.Drawing.Point(64, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Test Mid-term Form";
            // 
            // txtInitialForm
            // 
            this.txtInitialForm.Enabled = false;
            this.txtInitialForm.Location = new System.Drawing.Point(208, 352);
            this.txtInitialForm.MaxLength = 50;
            this.txtInitialForm.Name = "txtInitialForm";
            this.txtInitialForm.Size = new System.Drawing.Size(320, 21);
            this.txtInitialForm.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Location = new System.Drawing.Point(64, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Test Initial Form";
            // 
            // txtFinalEvent
            // 
            this.txtFinalEvent.Enabled = false;
            this.txtFinalEvent.Location = new System.Drawing.Point(640, 280);
            this.txtFinalEvent.MaxLength = 15;
            this.txtFinalEvent.Name = "txtFinalEvent";
            this.txtFinalEvent.ReadOnly = true;
            this.txtFinalEvent.Size = new System.Drawing.Size(72, 21);
            this.txtFinalEvent.TabIndex = 10;
            this.txtFinalEvent.TabStop = false;
            this.txtFinalEvent.Tag = "N";
            this.txtFinalEvent.Text = "0";
            this.txtFinalEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFinalEvent.Visible = false;
            this.txtFinalEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberStudents_KeyPress);
            // 
            // txtMidtermEvent
            // 
            this.txtMidtermEvent.Enabled = false;
            this.txtMidtermEvent.Location = new System.Drawing.Point(560, 280);
            this.txtMidtermEvent.MaxLength = 15;
            this.txtMidtermEvent.Name = "txtMidtermEvent";
            this.txtMidtermEvent.ReadOnly = true;
            this.txtMidtermEvent.Size = new System.Drawing.Size(72, 21);
            this.txtMidtermEvent.TabIndex = 9;
            this.txtMidtermEvent.TabStop = false;
            this.txtMidtermEvent.Tag = "N";
            this.txtMidtermEvent.Text = "0";
            this.txtMidtermEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMidtermEvent.Visible = false;
            this.txtMidtermEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberStudents_KeyPress);
            // 
            // txtInitialEvent
            // 
            this.txtInitialEvent.Enabled = false;
            this.txtInitialEvent.Location = new System.Drawing.Point(640, 256);
            this.txtInitialEvent.MaxLength = 15;
            this.txtInitialEvent.Name = "txtInitialEvent";
            this.txtInitialEvent.ReadOnly = true;
            this.txtInitialEvent.Size = new System.Drawing.Size(72, 21);
            this.txtInitialEvent.TabIndex = 8;
            this.txtInitialEvent.TabStop = false;
            this.txtInitialEvent.Tag = "N";
            this.txtInitialEvent.Text = "0";
            this.txtInitialEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInitialEvent.Visible = false;
            this.txtInitialEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberStudents_KeyPress);
            // 
            // txtHomeWorkMinutes
            // 
            this.txtHomeWorkMinutes.Location = new System.Drawing.Point(456, 498);
            this.txtHomeWorkMinutes.MaxLength = 15;
            this.txtHomeWorkMinutes.Name = "txtHomeWorkMinutes";
            this.txtHomeWorkMinutes.Size = new System.Drawing.Size(72, 21);
            this.txtHomeWorkMinutes.TabIndex = 14;
            this.txtHomeWorkMinutes.Tag = "N";
            this.txtHomeWorkMinutes.Text = "0";
            this.txtHomeWorkMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHomeWorkMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberStudents_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(304, 500);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Homework Minutes per Class";
            // 
            // txtNumberStudents
            // 
            this.txtNumberStudents.Location = new System.Drawing.Point(208, 498);
            this.txtNumberStudents.MaxLength = 15;
            this.txtNumberStudents.Name = "txtNumberStudents";
            this.txtNumberStudents.Size = new System.Drawing.Size(72, 21);
            this.txtNumberStudents.TabIndex = 13;
            this.txtNumberStudents.Tag = "N";
            this.txtNumberStudents.Text = "0";
            this.txtNumberStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumberStudents.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberStudents_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(64, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "No. of Students";
            // 
            // txtNameRomaji
            // 
            this.txtNameRomaji.Location = new System.Drawing.Point(208, 73);
            this.txtNameRomaji.MaxLength = 255;
            this.txtNameRomaji.Name = "txtNameRomaji";
            this.txtNameRomaji.Size = new System.Drawing.Size(320, 21);
            this.txtNameRomaji.TabIndex = 2;
            // 
            // txtNamePhonetic
            // 
            this.txtNamePhonetic.Location = new System.Drawing.Point(208, 49);
            this.txtNamePhonetic.MaxLength = 255;
            this.txtNamePhonetic.Name = "txtNamePhonetic";
            this.txtNamePhonetic.Size = new System.Drawing.Size(320, 21);
            this.txtNamePhonetic.TabIndex = 1;
            // 
            // cmbCourseType
            // 
            this.cmbCourseType.Items.AddRange(new object[] {
            "Class",
            "Desk",
            "Presentation Training",
            "Recording",
            "Mendan",
            "Other"});
            this.cmbCourseType.Location = new System.Drawing.Point(208, 256);
            this.cmbCourseType.Name = "cmbCourseType";
            this.cmbCourseType.Size = new System.Drawing.Size(184, 21);
            this.cmbCourseType.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(64, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Job Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(64, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Name Romaji";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPassword.Location = new System.Drawing.Point(64, 51);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 13);
            this.lblPassword.TabIndex = 32;
            this.lblPassword.Text = "Name Phonetic";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(64, 282);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 34;
            this.lblStatus.Text = "Status";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Location = new System.Drawing.Point(64, 27);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(34, 13);
            this.lblUser.TabIndex = 30;
            this.lblUser.Text = "Name";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(208, 280);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(112, 21);
            this.cmbStatus.TabIndex = 9;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // tbpDescription
            // 
            this.tbpDescription.Controls.Add(this.txtDescription);
            this.tbpDescription.Location = new System.Drawing.Point(4, 22);
            this.tbpDescription.Name = "tbpDescription";
            this.tbpDescription.Size = new System.Drawing.Size(762, 543);
            this.tbpDescription.TabIndex = 1;
            this.tbpDescription.Text = "Description";
            this.tbpDescription.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.MaxLength = 4000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(762, 543);
            this.txtDescription.TabIndex = 0;
            // 
            // tbpSpecialRemarks
            // 
            this.tbpSpecialRemarks.Controls.Add(this.txtRemarks);
            this.tbpSpecialRemarks.Location = new System.Drawing.Point(4, 22);
            this.tbpSpecialRemarks.Name = "tbpSpecialRemarks";
            this.tbpSpecialRemarks.Size = new System.Drawing.Size(762, 543);
            this.tbpSpecialRemarks.TabIndex = 2;
            this.tbpSpecialRemarks.Text = "Special Remarks";
            this.tbpSpecialRemarks.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(0, 0);
            this.txtRemarks.MaxLength = 4000;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(762, 543);
            this.txtRemarks.TabIndex = 1;
            // 
            // tbpCurriculam
            // 
            this.tbpCurriculam.Controls.Add(this.txtCurriculam);
            this.tbpCurriculam.Location = new System.Drawing.Point(4, 22);
            this.tbpCurriculam.Name = "tbpCurriculam";
            this.tbpCurriculam.Size = new System.Drawing.Size(762, 543);
            this.tbpCurriculam.TabIndex = 3;
            this.tbpCurriculam.Text = "Curriculum";
            this.tbpCurriculam.UseVisualStyleBackColor = true;
            // 
            // txtCurriculam
            // 
            this.txtCurriculam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurriculam.Location = new System.Drawing.Point(0, 0);
            this.txtCurriculam.MaxLength = 4000;
            this.txtCurriculam.Multiline = true;
            this.txtCurriculam.Name = "txtCurriculam";
            this.txtCurriculam.Size = new System.Drawing.Size(762, 543);
            this.txtCurriculam.TabIndex = 2;
            // 
            // tbpClassEvent
            // 
            this.tbpClassEvent.Controls.Add(this.pnlEvent);
            this.tbpClassEvent.Location = new System.Drawing.Point(4, 22);
            this.tbpClassEvent.Name = "tbpClassEvent";
            this.tbpClassEvent.Size = new System.Drawing.Size(762, 543);
            this.tbpClassEvent.TabIndex = 4;
            this.tbpClassEvent.Text = "Class Event";
            this.tbpClassEvent.UseVisualStyleBackColor = true;
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.pnlBottom);
            this.pnlEvent.Controls.Add(this.pnlBody_I);
            this.pnlEvent.Controls.Add(this.pnlTop_I);
            this.pnlEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvent.Location = new System.Drawing.Point(0, 0);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(762, 543);
            this.pnlEvent.TabIndex = 289;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btn_ClearRecc);
            this.pnlBottom.Controls.Add(this.btnRecurrence);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(0, 507);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(762, 36);
            this.pnlBottom.TabIndex = 272;
            // 
            // btn_ClearRecc
            // 
            this.btn_ClearRecc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ClearRecc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_ClearRecc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearRecc.Location = new System.Drawing.Point(118, 6);
            this.btn_ClearRecc.Name = "btn_ClearRecc";
            this.btn_ClearRecc.Size = new System.Drawing.Size(118, 23);
            this.btn_ClearRecc.TabIndex = 29;
            this.btn_ClearRecc.Text = "Clear Recurrence...";
            this.btn_ClearRecc.UseVisualStyleBackColor = false;
            this.btn_ClearRecc.Visible = false;
            this.btn_ClearRecc.Click += new System.EventHandler(this.btn_ClearRecc_Click);
            // 
            // btnRecurrence
            // 
            this.btnRecurrence.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecurrence.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRecurrence.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecurrence.Location = new System.Drawing.Point(16, 6);
            this.btnRecurrence.Name = "btnRecurrence";
            this.btnRecurrence.Size = new System.Drawing.Size(96, 23);
            this.btnRecurrence.TabIndex = 28;
            this.btnRecurrence.Text = "Recurrence...";
            this.btnRecurrence.UseVisualStyleBackColor = false;
            this.btnRecurrence.Click += new System.EventHandler(this.btnRecurrence_Click);
            // 
            // pnlBody_I
            // 
            this.pnlBody_I.Controls.Add(this.txtChangeReason_I);
            this.pnlBody_I.Controls.Add(this.lblChangeReason_I);
            this.pnlBody_I.Controls.Add(this.chkEventStatus_I);
            this.pnlBody_I.Controls.Add(this.chkEventModified);
            this.pnlBody_I.Controls.Add(this.lblExReason_I);
            this.pnlBody_I.Controls.Add(this.cmbExceptionReason_I);
            this.pnlBody_I.Controls.Add(this.groupBox4);
            this.pnlBody_I.Controls.Add(this.picAlert_I);
            this.pnlBody_I.Controls.Add(this.chkIsHoliday);
            this.pnlBody_I.Controls.Add(this.lblIsHoliday_I);
            this.pnlBody_I.Controls.Add(this.llblTeacher2_I);
            this.pnlBody_I.Controls.Add(this.llblTeacher1_I);
            this.pnlBody_I.Controls.Add(this.lblDtComp_I);
            this.pnlBody_I.Controls.Add(this.txtNote_I);
            this.pnlBody_I.Controls.Add(this.txtDescription_I);
            this.pnlBody_I.Controls.Add(this.lblDescription_I);
            this.pnlBody_I.Controls.Add(this.txtRoomNo_I);
            this.pnlBody_I.Controls.Add(this.lblRoomNo_I);
            this.pnlBody_I.Controls.Add(this.txtLocation_I);
            this.pnlBody_I.Controls.Add(this.lblLocation_I);
            this.pnlBody_I.Controls.Add(this.lblBlock_I);
            this.pnlBody_I.Controls.Add(this.lblEnddt_I);
            this.pnlBody_I.Controls.Add(this.lblStartdt_I);
            this.pnlBody_I.Controls.Add(this.lblEventType_I);
            this.pnlBody_I.Controls.Add(this.txtRomaji_I);
            this.pnlBody_I.Controls.Add(this.txtPhonetic_I);
            this.pnlBody_I.Controls.Add(this.lblRomaji_I);
            this.pnlBody_I.Controls.Add(this.lblPhonetic_I);
            this.pnlBody_I.Controls.Add(this.txtName_I);
            this.pnlBody_I.Controls.Add(this.lblName_I);
            this.pnlBody_I.Controls.Add(this.groupBox5);
            this.pnlBody_I.Controls.Add(this.cmbTeacher2_I);
            this.pnlBody_I.Controls.Add(this.cmbTeacher1_I);
            this.pnlBody_I.Controls.Add(this.dtDateComplete_I);
            this.pnlBody_I.Controls.Add(this.cmbEndTime);
            this.pnlBody_I.Controls.Add(this.cmbStartTime);
            this.pnlBody_I.Controls.Add(this.groupBox6);
            this.pnlBody_I.Controls.Add(this.cmbBlock_I);
            this.pnlBody_I.Controls.Add(this.dtEnd);
            this.pnlBody_I.Controls.Add(this.dtStart);
            this.pnlBody_I.Controls.Add(this.cmbEventType_I);
            this.pnlBody_I.Controls.Add(this.lblRecurrenceText_I);
            this.pnlBody_I.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody_I.Location = new System.Drawing.Point(0, 32);
            this.pnlBody_I.Name = "pnlBody_I";
            this.pnlBody_I.Size = new System.Drawing.Size(762, 511);
            this.pnlBody_I.TabIndex = 275;
            // 
            // txtChangeReason_I
            // 
            this.txtChangeReason_I.Enabled = false;
            this.txtChangeReason_I.Location = new System.Drawing.Point(128, 246);
            this.txtChangeReason_I.MaxLength = 100;
            this.txtChangeReason_I.Multiline = true;
            this.txtChangeReason_I.Name = "txtChangeReason_I";
            this.txtChangeReason_I.Size = new System.Drawing.Size(152, 65);
            this.txtChangeReason_I.TabIndex = 290;
            // 
            // lblChangeReason_I
            // 
            this.lblChangeReason_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChangeReason_I.Location = new System.Drawing.Point(15, 249);
            this.lblChangeReason_I.Name = "lblChangeReason_I";
            this.lblChangeReason_I.Size = new System.Drawing.Size(87, 34);
            this.lblChangeReason_I.TabIndex = 291;
            this.lblChangeReason_I.Text = "Instructor Change Reason";
            // 
            // chkEventStatus_I
            // 
            this.chkEventStatus_I.AutoSize = true;
            this.chkEventStatus_I.Location = new System.Drawing.Point(400, 196);
            this.chkEventStatus_I.Name = "chkEventStatus_I";
            this.chkEventStatus_I.Size = new System.Drawing.Size(111, 17);
            this.chkEventStatus_I.TabIndex = 289;
            this.chkEventStatus_I.Text = "Cancel This Event";
            this.chkEventStatus_I.UseVisualStyleBackColor = true;
            this.chkEventStatus_I.CheckedChanged += new System.EventHandler(this.chkEventStatus_I_CheckedChanged);
            // 
            // chkEventModified
            // 
            this.chkEventModified.AutoSize = true;
            this.chkEventModified.Location = new System.Drawing.Point(128, 196);
            this.chkEventModified.Name = "chkEventModified";
            this.chkEventModified.Size = new System.Drawing.Size(128, 17);
            this.chkEventModified.TabIndex = 288;
            this.chkEventModified.Text = "Modify the Instructor";
            this.chkEventModified.UseVisualStyleBackColor = true;
            this.chkEventModified.CheckedChanged += new System.EventHandler(this.chkEventModified_CheckedChanged);
            // 
            // lblExReason_I
            // 
            this.lblExReason_I.AutoSize = true;
            this.lblExReason_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExReason_I.Location = new System.Drawing.Point(304, 224);
            this.lblExReason_I.Name = "lblExReason_I";
            this.lblExReason_I.Size = new System.Drawing.Size(43, 13);
            this.lblExReason_I.TabIndex = 287;
            this.lblExReason_I.Text = "Reason";
            // 
            // cmbExceptionReason_I
            // 
            this.cmbExceptionReason_I.Items.AddRange(new object[] {
            "Weather",
            "Instructor",
            "Client"});
            this.cmbExceptionReason_I.Location = new System.Drawing.Point(400, 221);
            this.cmbExceptionReason_I.Name = "cmbExceptionReason_I";
            this.cmbExceptionReason_I.Size = new System.Drawing.Size(256, 21);
            this.cmbExceptionReason_I.TabIndex = 22;
            this.cmbExceptionReason_I.SelectedIndexChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Location = new System.Drawing.Point(19, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(730, 3);
            this.groupBox4.TabIndex = 285;
            this.groupBox4.TabStop = false;
            // 
            // picAlert_I
            // 
            this.picAlert_I.Image = ((System.Drawing.Image)(resources.GetObject("picAlert_I.Image")));
            this.picAlert_I.Location = new System.Drawing.Point(296, 24);
            this.picAlert_I.Name = "picAlert_I";
            this.picAlert_I.Size = new System.Drawing.Size(32, 24);
            this.picAlert_I.TabIndex = 268;
            this.picAlert_I.TabStop = false;
            this.picAlert_I.Visible = false;
            // 
            // chkIsHoliday
            // 
            this.chkIsHoliday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIsHoliday.Location = new System.Drawing.Point(266, 131);
            this.chkIsHoliday.Name = "chkIsHoliday";
            this.chkIsHoliday.Size = new System.Drawing.Size(24, 16);
            this.chkIsHoliday.TabIndex = 14;
            // 
            // lblIsHoliday_I
            // 
            this.lblIsHoliday_I.AutoSize = true;
            this.lblIsHoliday_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblIsHoliday_I.Location = new System.Drawing.Point(208, 131);
            this.lblIsHoliday_I.Name = "lblIsHoliday_I";
            this.lblIsHoliday_I.Size = new System.Drawing.Size(54, 13);
            this.lblIsHoliday_I.TabIndex = 267;
            this.lblIsHoliday_I.Text = "Is Holiday";
            // 
            // llblTeacher2_I
            // 
            this.llblTeacher2_I.AutoSize = true;
            this.llblTeacher2_I.Location = new System.Drawing.Point(14, 221);
            this.llblTeacher2_I.Name = "llblTeacher2_I";
            this.llblTeacher2_I.Size = new System.Drawing.Size(88, 13);
            this.llblTeacher2_I.TabIndex = 265;
            this.llblTeacher2_I.TabStop = true;
            this.llblTeacher2_I.Text = "Actual Instructor";
            this.llblTeacher2_I.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblTeacher2_LinkClicked);
            // 
            // llblTeacher1_I
            // 
            this.llblTeacher1_I.AutoSize = true;
            this.llblTeacher1_I.Location = new System.Drawing.Point(481, 107);
            this.llblTeacher1_I.Name = "llblTeacher1_I";
            this.llblTeacher1_I.Size = new System.Drawing.Size(107, 13);
            this.llblTeacher1_I.TabIndex = 263;
            this.llblTeacher1_I.TabStop = true;
            this.llblTeacher1_I.Text = "Scheduled Instructor";
            this.llblTeacher1_I.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblTeacher1_LinkClicked);
            // 
            // lblDtComp_I
            // 
            this.lblDtComp_I.AutoSize = true;
            this.lblDtComp_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDtComp_I.Location = new System.Drawing.Point(536, 107);
            this.lblDtComp_I.Name = "lblDtComp_I";
            this.lblDtComp_I.Size = new System.Drawing.Size(84, 13);
            this.lblDtComp_I.TabIndex = 260;
            this.lblDtComp_I.Text = "Date Completed";
            this.lblDtComp_I.Visible = false;
            // 
            // txtNote_I
            // 
            this.txtNote_I.Location = new System.Drawing.Point(16, 335);
            this.txtNote_I.MaxLength = 255;
            this.txtNote_I.Multiline = true;
            this.txtNote_I.Name = "txtNote_I";
            this.txtNote_I.Size = new System.Drawing.Size(729, 134);
            this.txtNote_I.TabIndex = 24;
            this.txtNote_I.TextChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // txtDescription_I
            // 
            this.txtDescription_I.Location = new System.Drawing.Point(128, 159);
            this.txtDescription_I.MaxLength = 255;
            this.txtDescription_I.Name = "txtDescription_I";
            this.txtDescription_I.Size = new System.Drawing.Size(616, 21);
            this.txtDescription_I.TabIndex = 23;
            this.txtDescription_I.TextChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // lblDescription_I
            // 
            this.lblDescription_I.AutoSize = true;
            this.lblDescription_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescription_I.Location = new System.Drawing.Point(16, 162);
            this.lblDescription_I.Name = "lblDescription_I";
            this.lblDescription_I.Size = new System.Drawing.Size(60, 13);
            this.lblDescription_I.TabIndex = 253;
            this.lblDescription_I.Text = "Description";
            // 
            // txtRoomNo_I
            // 
            this.txtRoomNo_I.Location = new System.Drawing.Point(400, 105);
            this.txtRoomNo_I.MaxLength = 255;
            this.txtRoomNo_I.Name = "txtRoomNo_I";
            this.txtRoomNo_I.Size = new System.Drawing.Size(72, 21);
            this.txtRoomNo_I.TabIndex = 15;
            this.txtRoomNo_I.Text = "0";
            this.txtRoomNo_I.TextChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // lblRoomNo_I
            // 
            this.lblRoomNo_I.AutoSize = true;
            this.lblRoomNo_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRoomNo_I.Location = new System.Drawing.Point(304, 107);
            this.lblRoomNo_I.Name = "lblRoomNo_I";
            this.lblRoomNo_I.Size = new System.Drawing.Size(54, 13);
            this.lblRoomNo_I.TabIndex = 249;
            this.lblRoomNo_I.Text = "Room No.";
            // 
            // txtLocation_I
            // 
            this.txtLocation_I.Location = new System.Drawing.Point(128, 105);
            this.txtLocation_I.MaxLength = 255;
            this.txtLocation_I.Name = "txtLocation_I";
            this.txtLocation_I.Size = new System.Drawing.Size(152, 21);
            this.txtLocation_I.TabIndex = 12;
            this.txtLocation_I.TextChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // lblLocation_I
            // 
            this.lblLocation_I.AutoSize = true;
            this.lblLocation_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation_I.Location = new System.Drawing.Point(16, 107);
            this.lblLocation_I.Name = "lblLocation_I";
            this.lblLocation_I.Size = new System.Drawing.Size(47, 13);
            this.lblLocation_I.TabIndex = 246;
            this.lblLocation_I.Text = "Location";
            // 
            // lblBlock_I
            // 
            this.lblBlock_I.AutoSize = true;
            this.lblBlock_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBlock_I.Location = new System.Drawing.Point(16, 131);
            this.lblBlock_I.Name = "lblBlock_I";
            this.lblBlock_I.Size = new System.Drawing.Size(31, 13);
            this.lblBlock_I.TabIndex = 244;
            this.lblBlock_I.Text = "Block";
            // 
            // lblEnddt_I
            // 
            this.lblEnddt_I.AutoSize = true;
            this.lblEnddt_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEnddt_I.Location = new System.Drawing.Point(304, 56);
            this.lblEnddt_I.Name = "lblEnddt_I";
            this.lblEnddt_I.Size = new System.Drawing.Size(77, 13);
            this.lblEnddt_I.TabIndex = 242;
            this.lblEnddt_I.Text = "End Date/Time";
            // 
            // lblStartdt_I
            // 
            this.lblStartdt_I.AutoSize = true;
            this.lblStartdt_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartdt_I.Location = new System.Drawing.Point(304, 32);
            this.lblStartdt_I.Name = "lblStartdt_I";
            this.lblStartdt_I.Size = new System.Drawing.Size(83, 13);
            this.lblStartdt_I.TabIndex = 241;
            this.lblStartdt_I.Text = "Start Date/Time";
            // 
            // lblEventType_I
            // 
            this.lblEventType_I.AutoSize = true;
            this.lblEventType_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventType_I.Location = new System.Drawing.Point(536, 131);
            this.lblEventType_I.Name = "lblEventType_I";
            this.lblEventType_I.Size = new System.Drawing.Size(62, 13);
            this.lblEventType_I.TabIndex = 237;
            this.lblEventType_I.Text = "Event Type";
            this.lblEventType_I.Visible = false;
            // 
            // txtRomaji_I
            // 
            this.txtRomaji_I.Location = new System.Drawing.Point(128, 65);
            this.txtRomaji_I.MaxLength = 255;
            this.txtRomaji_I.Name = "txtRomaji_I";
            this.txtRomaji_I.Size = new System.Drawing.Size(152, 21);
            this.txtRomaji_I.TabIndex = 2;
            this.txtRomaji_I.TextChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // txtPhonetic_I
            // 
            this.txtPhonetic_I.Location = new System.Drawing.Point(128, 42);
            this.txtPhonetic_I.MaxLength = 255;
            this.txtPhonetic_I.Name = "txtPhonetic_I";
            this.txtPhonetic_I.Size = new System.Drawing.Size(152, 21);
            this.txtPhonetic_I.TabIndex = 1;
            this.txtPhonetic_I.TextChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // lblRomaji_I
            // 
            this.lblRomaji_I.AutoSize = true;
            this.lblRomaji_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRomaji_I.Location = new System.Drawing.Point(15, 67);
            this.lblRomaji_I.Name = "lblRomaji_I";
            this.lblRomaji_I.Size = new System.Drawing.Size(69, 13);
            this.lblRomaji_I.TabIndex = 83;
            this.lblRomaji_I.Text = "Name Romaji";
            // 
            // lblPhonetic_I
            // 
            this.lblPhonetic_I.AutoSize = true;
            this.lblPhonetic_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPhonetic_I.Location = new System.Drawing.Point(15, 44);
            this.lblPhonetic_I.Name = "lblPhonetic_I";
            this.lblPhonetic_I.Size = new System.Drawing.Size(78, 13);
            this.lblPhonetic_I.TabIndex = 82;
            this.lblPhonetic_I.Text = "Name Phonetic";
            // 
            // txtName_I
            // 
            this.txtName_I.Location = new System.Drawing.Point(128, 19);
            this.txtName_I.MaxLength = 255;
            this.txtName_I.Name = "txtName_I";
            this.txtName_I.Size = new System.Drawing.Size(152, 21);
            this.txtName_I.TabIndex = 0;
            this.txtName_I.TextChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // lblName_I
            // 
            this.lblName_I.AutoSize = true;
            this.lblName_I.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblName_I.Location = new System.Drawing.Point(15, 21);
            this.lblName_I.Name = "lblName_I";
            this.lblName_I.Size = new System.Drawing.Size(34, 13);
            this.lblName_I.TabIndex = 81;
            this.lblName_I.Text = "Name";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Location = new System.Drawing.Point(14, 90);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(730, 3);
            this.groupBox5.TabIndex = 266;
            this.groupBox5.TabStop = false;
            // 
            // cmbTeacher2_I
            // 
            this.cmbTeacher2_I.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher2_I.Enabled = false;
            this.cmbTeacher2_I.Items.AddRange(new object[] {
            "Class",
            "Desk",
            "Presentation Training",
            "Recording",
            "Mendan",
            "Other"});
            this.cmbTeacher2_I.Location = new System.Drawing.Point(128, 219);
            this.cmbTeacher2_I.Name = "cmbTeacher2_I";
            this.cmbTeacher2_I.Size = new System.Drawing.Size(152, 21);
            this.cmbTeacher2_I.TabIndex = 20;
            this.cmbTeacher2_I.SelectedIndexChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // cmbTeacher1_I
            // 
            this.cmbTeacher1_I.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeacher1_I.Items.AddRange(new object[] {
            "Class",
            "Desk",
            "Presentation Training",
            "Recording",
            "Mendan",
            "Other"});
            this.cmbTeacher1_I.Location = new System.Drawing.Point(592, 105);
            this.cmbTeacher1_I.Name = "cmbTeacher1_I";
            this.cmbTeacher1_I.Size = new System.Drawing.Size(152, 21);
            this.cmbTeacher1_I.TabIndex = 19;
            this.cmbTeacher1_I.SelectedIndexChanged += new System.EventHandler(this.txtName_I_TextChanged);
            // 
            // dtDateComplete_I
            // 
            this.dtDateComplete_I.CustomFormat = "MM/dd/yyyy";
            this.dtDateComplete_I.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateComplete_I.Location = new System.Drawing.Point(624, 105);
            this.dtDateComplete_I.Name = "dtDateComplete_I";
            this.dtDateComplete_I.Size = new System.Drawing.Size(120, 21);
            this.dtDateComplete_I.TabIndex = 17;
            this.dtDateComplete_I.Visible = false;
            this.dtDateComplete_I.ValueChanged += new System.EventHandler(this.txtName_I_TextChanged);
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
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Location = new System.Drawing.Point(14, 187);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(730, 3);
            this.groupBox6.TabIndex = 252;
            this.groupBox6.TabStop = false;
            // 
            // cmbBlock_I
            // 
            this.cmbBlock_I.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H"});
            this.cmbBlock_I.Location = new System.Drawing.Point(128, 129);
            this.cmbBlock_I.Name = "cmbBlock_I";
            this.cmbBlock_I.Size = new System.Drawing.Size(72, 21);
            this.cmbBlock_I.TabIndex = 13;
            this.cmbBlock_I.SelectedIndexChanged += new System.EventHandler(this.txtName_I_TextChanged);
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
            // cmbEventType_I
            // 
            this.cmbEventType_I.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventType_I.Items.AddRange(new object[] {
            "Event",
            "Correcting Task",
            "Translating Task"});
            this.cmbEventType_I.Location = new System.Drawing.Point(624, 129);
            this.cmbEventType_I.Name = "cmbEventType_I";
            this.cmbEventType_I.Size = new System.Drawing.Size(120, 21);
            this.cmbEventType_I.TabIndex = 16;
            this.cmbEventType_I.Visible = false;
            this.cmbEventType_I.SelectedIndexChanged += new System.EventHandler(this.cmbEventType_I_SelectedIndexChanged);
            // 
            // lblRecurrenceText_I
            // 
            this.lblRecurrenceText_I.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecurrenceText_I.ForeColor = System.Drawing.Color.Black;
            this.lblRecurrenceText_I.Location = new System.Drawing.Point(344, 26);
            this.lblRecurrenceText_I.Name = "lblRecurrenceText_I";
            this.lblRecurrenceText_I.Size = new System.Drawing.Size(392, 62);
            this.lblRecurrenceText_I.TabIndex = 261;
            this.lblRecurrenceText_I.Text = "Recurrence : ";
            this.lblRecurrenceText_I.Visible = false;
            // 
            // pnlTop_I
            // 
            this.pnlTop_I.Controls.Add(this.lblRecurrenceText1_I);
            this.pnlTop_I.Controls.Add(this.picAlert1_I);
            this.pnlTop_I.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop_I.Location = new System.Drawing.Point(0, 0);
            this.pnlTop_I.Name = "pnlTop_I";
            this.pnlTop_I.Size = new System.Drawing.Size(762, 32);
            this.pnlTop_I.TabIndex = 273;
            this.pnlTop_I.Visible = false;
            // 
            // lblRecurrenceText1_I
            // 
            this.lblRecurrenceText1_I.BackColor = System.Drawing.SystemColors.Info;
            this.lblRecurrenceText1_I.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecurrenceText1_I.ForeColor = System.Drawing.Color.Black;
            this.lblRecurrenceText1_I.Location = new System.Drawing.Point(56, 5);
            this.lblRecurrenceText1_I.Name = "lblRecurrenceText1_I";
            this.lblRecurrenceText1_I.Size = new System.Drawing.Size(680, 24);
            this.lblRecurrenceText1_I.TabIndex = 270;
            this.lblRecurrenceText1_I.Text = "Recurrence : ";
            this.lblRecurrenceText1_I.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRecurrenceText1_I.Visible = false;
            // 
            // picAlert1_I
            // 
            this.picAlert1_I.Image = ((System.Drawing.Image)(resources.GetObject("picAlert1_I.Image")));
            this.picAlert1_I.Location = new System.Drawing.Point(16, 6);
            this.picAlert1_I.Name = "picAlert1_I";
            this.picAlert1_I.Size = new System.Drawing.Size(32, 24);
            this.picAlert1_I.TabIndex = 269;
            this.picAlert1_I.TabStop = false;
            this.picAlert1_I.Visible = false;
            // 
            // tbpOtherEvents
            // 
            this.tbpOtherEvents.Controls.Add(this.pnlButtons);
            this.tbpOtherEvents.Controls.Add(this.grdEvents);
            this.tbpOtherEvents.Location = new System.Drawing.Point(4, 22);
            this.tbpOtherEvents.Name = "tbpOtherEvents";
            this.tbpOtherEvents.Size = new System.Drawing.Size(762, 543);
            this.tbpOtherEvents.TabIndex = 8;
            this.tbpOtherEvents.Text = "Other Events";
            this.tbpOtherEvents.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 501);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(762, 42);
            this.pnlButtons.TabIndex = 32;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(25, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Location = new System.Drawing.Point(115, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 29;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(205, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 30;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // grdEvents
            // 
            this.grdEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEvents.EmbeddedNavigator.Name = "";
            this.grdEvents.Location = new System.Drawing.Point(0, 0);
            this.grdEvents.MainView = this.gvwEvents;
            this.grdEvents.Name = "grdEvents";
            this.grdEvents.Size = new System.Drawing.Size(762, 543);
            this.grdEvents.TabIndex = 31;
            this.grdEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwEvents});
            this.grdEvents.DoubleClick += new System.EventHandler(this.grdEvents_DoubleClick);
            // 
            // gvwEvents
            // 
            this.gvwEvents.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvwEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolCaldendarEventID,
            this.gcolEventID,
            this.gcolEventType,
            this.gcolStartDateTime,
            this.gcolEndDateTime});
            this.gvwEvents.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvwEvents.GridControl = this.grdEvents;
            this.gvwEvents.Name = "gvwEvents";
            this.gvwEvents.OptionsBehavior.Editable = false;
            this.gvwEvents.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gvwEvents.OptionsCustomization.AllowFilter = false;
            this.gvwEvents.OptionsDetail.EnableDetailToolTip = true;
            this.gvwEvents.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvwEvents.OptionsPrint.UsePrintStyles = true;
            this.gvwEvents.OptionsView.ShowDetailButtons = false;
            this.gvwEvents.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwEvents.OptionsView.ShowGroupPanel = false;
            this.gvwEvents.OptionsView.ShowHorzLines = false;
            this.gvwEvents.OptionsView.ShowIndicator = false;
            // 
            // gcolCaldendarEventID
            // 
            this.gcolCaldendarEventID.Caption = "Calendar Event ID";
            this.gcolCaldendarEventID.FieldName = "CalendarEventId";
            this.gcolCaldendarEventID.Name = "gcolCaldendarEventID";
            this.gcolCaldendarEventID.Width = 79;
            // 
            // gcolEventID
            // 
            this.gcolEventID.Caption = "EventID";
            this.gcolEventID.FieldName = "EventId";
            this.gcolEventID.Name = "gcolEventID";
            // 
            // gcolEventType
            // 
            this.gcolEventType.Caption = "Event Type";
            this.gcolEventType.FieldName = "EventType";
            this.gcolEventType.Name = "gcolEventType";
            this.gcolEventType.Visible = true;
            this.gcolEventType.VisibleIndex = 0;
            this.gcolEventType.Width = 157;
            // 
            // gcolStartDateTime
            // 
            this.gcolStartDateTime.Caption = "Start Date";
            this.gcolStartDateTime.DisplayFormat.FormatString = "d";
            this.gcolStartDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcolStartDateTime.FieldName = "StartDateTime";
            this.gcolStartDateTime.Name = "gcolStartDateTime";
            this.gcolStartDateTime.Visible = true;
            this.gcolStartDateTime.VisibleIndex = 1;
            // 
            // gcolEndDateTime
            // 
            this.gcolEndDateTime.Caption = "End Date";
            this.gcolEndDateTime.DisplayFormat.FormatString = "d";
            this.gcolEndDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcolEndDateTime.FieldName = "EndDateTime";
            this.gcolEndDateTime.Name = "gcolEndDateTime";
            this.gcolEndDateTime.Visible = true;
            this.gcolEndDateTime.VisibleIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(599, 575);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(516, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(682, 575);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPageSetup.Location = new System.Drawing.Point(103, 575);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(75, 23);
            this.btnPageSetup.TabIndex = 26;
            this.btnPageSetup.Text = "Page Setup";
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(15, 575);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printingSystem
            // 
            this.printingSystem.StartPrint += new DevExpress.XtraPrinting.PrintDocumentEventHandler(this.printingSystem_StartPrint);
            //this.printingSystem.BeforePagePaint += new DevExpress.XtraPrinting.PageEventHandler(this.printingSystem_BeforePagePaint);
            //this.printingSystem.AfterPagePaint += new DevExpress.XtraPrinting.PageEventHandler(this.printingSystem_AfterPagePaint);
            this.printingSystem.AfterPagePrint += new DevExpress.XtraPrinting.PageEventHandler(this.printingSystem_AfterPagePrint);
            // 
            // frmClassDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(770, 610);
            this.Controls.Add(this.btnPageSetup);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbcCourse);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClassDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding Class...";
            this.Load += new System.EventHandler(this.frmCourseDlg_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmCourseDlg_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCourseDlg_KeyDown);
            this.tbcCourse.ResumeLayout(false);
            this.tbpCourse.ResumeLayout(false);
            this.tbpCourse.PerformLayout();
            this.tbpDescription.ResumeLayout(false);
            this.tbpDescription.PerformLayout();
            this.tbpSpecialRemarks.ResumeLayout(false);
            this.tbpSpecialRemarks.PerformLayout();
            this.tbpCurriculam.ResumeLayout(false);
            this.tbpCurriculam.PerformLayout();
            this.tbpClassEvent.ResumeLayout(false);
            this.pnlEvent.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBody_I.ResumeLayout(false);
            this.pnlBody_I.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlert_I)).EndInit();
            this.pnlTop_I.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAlert1_I)).EndInit();
            this.tbpOtherEvents.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
        #endregion

        #region Loading
        private string _mode="";
		private int  _courseid=0;

		public string Mode
		{
			get{return _mode;}
			set{_mode=value;}
		}
		public int CourseID
		{
			get{return _courseid;}
			set{_courseid=value;}
		}
        public bool IsSeries
        {
            get { return IsRecurringSeries; }
            set { IsRecurringSeries = (bool)value; }
        }

		private void frmCourseDlg_Load(object sender, System.EventArgs e)
		{
            if (Common.LogonType == 2)
            {
                this.btnDelete.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnEdit.Text = "View";
                this.llblClient.Enabled = false;
                this.llbDepartment.Enabled = false;
                this.llblEvent.Enabled = false;
                this.llblFinalEvt.Enabled = false;
                this.llblInitialEvt.Enabled = false;
                this.llblMidEvt.Enabled = false;
                this.llblProgram.Enabled = false;
                this.llblTeacher1_I.Enabled = false;
                this.llblTeacher2_I.Enabled = false;
            }
			this.ActiveControl = txtCourseName;
            //cmbEventStatus_I.SelectedIndex = 0;
            
			cmbEventType_I.SelectedIndex=0;
			IsEventChanged=false;

			try
			{
				Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();

			if(_mode=="Edit")
			{
				this.Text = "Editing Class...";
			}
			else if(_mode=="Add")
			{
				btnDelete.Enabled=false;
                btnAdd.Enabled = false;
				this.Text = "Adding Class...";
				if(cmbProgram.Items.Count>0) cmbProgram.SelectedIndex=0;
				cmbStatus.SelectedIndex=0;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if(!deleted) this.DialogResult = DialogResult.Cancel;
			else if(deleted) this.DialogResult = DialogResult.OK;
			Close();
		}

		public void LoadData()
		{
            if (_mode == "Edit" || _mode == "AddClone")
			{
                if (_mode == "Edit")
                    this.Text = "Editing Course...";
                else
                {
                    this.Text = "Adding Course Clone...";
                    btnDelete.Enabled = false;
                }
				
				Scheduler.BusinessLayer.Course objCourse=new Scheduler.BusinessLayer.Course();
				objCourse.CourseID = _courseid;
				objCourse.LoadData();
                IsRecurringSeries = objCourse.IsRecurring();
                bool[] boolArray = objCourse.CheckTestEvents();
                HasTestInitialEvent = boolArray[0];
                HasTestMidtermEvent = boolArray[1];
                HasTestFinalEvent = boolArray[2];

				foreach(DataRow dr in objCourse.CourseDataTable.Rows)
				{
					//Get the Client/Department/Program
					if(dr["Client"]!=System.DBNull.Value)
						cmbClient.Text = dr["Client"].ToString();

                    intClientID = Common.GetCompanyID(
						"Select ContactID From Contact " +
						"Where (CompanyName=@CompanyName OR NickName=@CompanyName) ", cmbClient.Text
						);

					if(intClientID!=0)
					{
                        llblClient.Tag = intClientID;
						Common.PopulateDropdown(
							cmbDept, "Select CompanyName = CASE " + 
							"WHEN C.NickName IS NULL THEN C.CompanyName " +
							"WHEN C.NickName = '' THEN C.CompanyName " +
							"ELSE C.NickName " +
							"END From " +
							"Department D, Contact C Where D.ContactID=C.ContactID " +
							"and D.ClientID=" + intClientID + 
							" Order By CompanyName");
					}
					if(dr["Department"]!=System.DBNull.Value)
						cmbDept.Text = dr["Department"].ToString();

                    string query = "Select CompanyName = CASE " +
                            "WHEN C.NickName IS NULL THEN C.CompanyName " +
                            "WHEN C.NickName = '' THEN C.CompanyName " +
                            "ELSE C.NickName " +
                            "END From " +
                            "Department D, Contact C Where D.ContactID=C.ContactID and " +
                            "D.DepartmentStatus=1 and D.ClientID=" + intClientID +
                            " Order By CompanyName";

                    IDataReader reader = DAC.SelectStatement(query);

                    while (reader.Read())
                    {
                        if (reader["CompanyName"] != DBNull.Value && reader["CompanyName"].ToString() != cmbDept.Text)
                        {
                            cmbDept.Items.Remove(reader["CompanyName"].ToString()); ;
                        }
                    }

					intDepartmentID = Common.GetCompanyID(
						"Select D.DepartmentID, C.ContactID From Department D, Contact C " +
						"Where D.ContactID=C.ContactID and (C.CompanyName=@CompanyName OR C.NickName=@CompanyName) and D.ClientID = '" + intClientID + "' ", cmbDept.Text
						);

                    if (intDepartmentID != 0)
                    {
                        llbDepartment.Tag = intDepartmentID;

                        Common.PopulateDropdown(
                            cmbProgram, "Select [Name] = CASE " +
                            "WHEN NickName IS NULL THEN [Name] " +
                            "WHEN NickName = '' THEN [Name] " +
                            "ELSE NickName " +
                            "END From " +
                            "Program Where DepartmentID=" + intDepartmentID +
                            " Order By [Name]");
                    }

                    if (dr["Program"] != System.DBNull.Value)
                    {
                        llblProgram.Tag = dr["ProgramId"].ToString();
                        cmbProgram.SelectedIndex = cmbProgram.Items.IndexOf(dr["Program"].ToString());
                    }

                    query = "Select [Name] = CASE " +
                            "WHEN NickName IS NULL THEN [Name] " +
                            "WHEN NickName = '' THEN [Name] " +
                            "ELSE NickName " +
                            "END From " +
                            "Program Where ProgramStatus=1 and DepartmentID=" + intDepartmentID +
                            " Order By [Name]";

                    reader = DAC.SelectStatement(query);

                    while (reader.Read())
                    {
                        if (reader["Name"] != DBNull.Value && reader["Name"].ToString() != cmbProgram.Text)
                        {
                            cmbProgram.Items.Remove(reader["Name"].ToString()); ;
                        }
                    }

					txtCourseName.Text = dr["Name"].ToString();
                    if (_mode == "AddClone") txtCourseName.Text = "Copy of " + txtCourseName.Text;
					txtNamePhonetic.Text = dr["NamePhonetic"].ToString();
					txtNameRomaji.Text = dr["NameRomaji"].ToString();
					txtNickName.Text = dr["NickName"].ToString();

					txtDescription.Text = dr["Description"].ToString();
					txtRemarks.Text = dr["SpecialRemarks"].ToString();
					txtCurriculam.Text = dr["Curriculam"].ToString();

					cmbCourseType.Text = dr["CourseType"].ToString();
					txtNumberStudents.Text = dr["NumberStudents"].ToString();
					txtHomeWorkMinutes.Text = dr["HomeWorkMinutes"].ToString();

                    if (dr["CourseStatus"].ToString() == "Active")
                        cmbStatus.SelectedIndex = 0;
                    else
                    {
                        cmbStatus.SelectedIndex = 1;
                        //chkEventModified.Checked = true;
                    }

                    if (_mode == "Edit")
                    {
                        txtInitialEvent.Text = dr["TestInitialEventId"].ToString();
                        txtMidtermEvent.Text = dr["TestMidTermEventId"].ToString();
                        txtFinalEvent.Text = dr["TestFinalEventId"].ToString();
                        txtEvent.Text = dr["EventID"].ToString();

                        eventid[0] = Convert.ToInt32(dr["TestInitialEventId"].ToString());
                        eventid[1] = Convert.ToInt32(dr["TestMidTermEventId"].ToString());
                        eventid[2] = Convert.ToInt32(dr["TestFinalEventId"].ToString());
                        eventid[3] = Convert.ToInt32(dr["EventID"].ToString());

                        //Making sure all events on record exist
                        if (eventid[0] > 0)
                        {
                            if (!objCourse.IsEventExists(eventid[0]))
                                eventid[0] = 0;
                        }
                        if (eventid[1] > 0)
                        {
                            if (!objCourse.IsEventExists(eventid[1]))
                                eventid[1] = 0;
                        }
                        if (eventid[2] > 0)
                        {
                            if (!objCourse.IsEventExists(eventid[2]))
                                eventid[2] = 0;
                        }
                        if (eventid[3] > 0)
                        {
                            if (!objCourse.IsEventExists(eventid[3]))
                                eventid[3] = 0;
                        }

                        txtInitialForm.Text = dr["TestInitialForm"].ToString();
                        txtMidtermForm.Text = dr["TestMidTermForm"].ToString();
                        txtFinalForm.Text = dr["TestFinalForm"].ToString();
                    }
                    else
                    {
                        txtInitialEvent.Text = String.Empty;
                        txtMidtermEvent.Text = String.Empty;
                        txtFinalEvent.Text = String.Empty;
                        txtEvent.Text = String.Empty;

                        eventid[0] = 0;
                        eventid[1] = 0;
                        eventid[2] = 0;
                        eventid[3] = 0;

                        txtInitialForm.Text = String.Empty;
                        txtMidtermForm.Text = String.Empty;
                        txtFinalForm.Text = String.Empty;
                    }
                    break;
				}


                if (_mode == "Edit")
                {
                    //Load Events if any
                    string strHint = "";
                    llblInitialEvt.Text = objCourse.getEventText(txtInitialEvent.Text, "Initial", ref strHint);
                    if (strHint == "None") txtInitialEvent.Text = "0";
                    strHint = "";

                    llblMidEvt.Text = objCourse.getEventText(txtMidtermEvent.Text, "Midterm", ref strHint);
                    if (strHint == "None") txtMidtermEvent.Text = "0";
                    strHint = "";

                    llblFinalEvt.Text = objCourse.getEventText(txtFinalEvent.Text, "Final", ref strHint);
                    if (strHint == "None") txtFinalEvent.Text = "0";
                    strHint = "";

                    llblEvent.Text = objCourse.getEventText(txtEvent.Text, "Event", ref strHint);
                    if (strHint != "") llblEvent.Text = strHint;
                    if (strHint == "None") txtEvent.Text = "0";
                    strHint = "";

                    if (eventid[intIndex] > 0)
                        LoadEvent(eventid[intIndex], calendareventid[intIndex]);
                }
                else
                {
                    llblInitialEvt.Text = String.Empty;
                    txtInitialEvent.Text = "0";

                    llblMidEvt.Text = String.Empty;
                    txtMidtermEvent.Text = "0";

                    llblFinalEvt.Text = String.Empty;
                    txtFinalEvent.Text = "0";

                    llblEvent.Text = String.Empty;
                    txtEvent.Text = "0";
                }

                if (_mode == "Edit")
                {
                    string query = "Select CompanyName = CASE " +
                    "WHEN NickName IS NULL THEN CompanyName " +
                    "WHEN NickName = '' THEN CompanyName " +
                    "ELSE NickName " +
                    "END From " +
                    "Contact Where ContactType=2 and " +
                    "ContactStatus=1 Order By CompanyName";
                    IDataReader reader = DAC.SelectStatement(query);
                    while (reader.Read())
                    {
                        if (reader["CompanyName"] != DBNull.Value && reader["CompanyName"].ToString() != cmbClient.Text)
                            cmbClient.Items.Remove(reader["CompanyName"].ToString());
                    }

                    query = "Select " +
                        "TeacherName = CASE " +
                        "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
                        "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
                        "ELSE NickName " +
                        "END From " +
                        "Contact Where ContactType=1 and " +
                        "ContactStatus=1 Order By LastName, FirstName ";
                    reader = DAC.SelectStatement(query);
                    while (reader.Read())
                    {
                        if (reader["TeacherName"] != DBNull.Value && reader["TeacherName"].ToString() != cmbTeacher2_I.Text && reader["TeacherName"].ToString() != cmbTeacher1_I.Text)
                        {
                            cmbTeacher1_I.Items.Remove(reader["TeacherName"].ToString());
                            cmbTeacher2_I.Items.Remove(reader["TeacherName"].ToString());
                        }
                    }
                }
			}
			else
			{
				this.Text = "Adding Class...";

                string query = "Select CompanyName = CASE " +
                    "WHEN NickName IS NULL THEN CompanyName " +
                    "WHEN NickName = '' THEN CompanyName " +
                    "ELSE NickName " +
                    "END From " +
                    "Contact Where ContactType=2 and " +
                    "ContactStatus=1 Order By CompanyName";
                IDataReader reader = DAC.SelectStatement(query);
                while (reader.Read())
                {
                    if (reader["CompanyName"] != DBNull.Value )
                        cmbClient.Items.Remove(reader["CompanyName"].ToString());
                }

                query = "Select " +
                    "TeacherName = CASE " +
                    "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
                    "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
                    "ELSE NickName " +
                    "END From " +
                    "Contact Where ContactType=1 and " +
                    "ContactStatus=1 Order By LastName, FirstName ";
                reader = DAC.SelectStatement(query);
                while (reader.Read())
                {
                    if (reader["TeacherName"] != DBNull.Value)
                    {
                        cmbTeacher1_I.Items.Remove(reader["TeacherName"].ToString());
                        cmbTeacher2_I.Items.Remove(reader["TeacherName"].ToString());
                    }
                }

				cmbClient.Text = String.Empty;
				cmbDept.Text = String.Empty;
				cmbProgram.Text = String.Empty;


				txtCourseName.Text = String.Empty;
				txtNamePhonetic.Text = String.Empty;
				txtNameRomaji.Text = String.Empty;
				txtNickName.Text = String.Empty;
				txtDescription.Text = String.Empty;
				txtRemarks.Text = String.Empty;
				txtCurriculam.Text = String.Empty;

				cmbCourseType.Text = String.Empty;
				txtNumberStudents.Text = String.Empty;
				txtHomeWorkMinutes.Text = String.Empty;

				txtInitialEvent.Text = String.Empty;
				txtMidtermEvent.Text = String.Empty;
				txtFinalEvent.Text = String.Empty;
				txtEvent.Text = String.Empty;

				eventid[0] = 0;
				eventid[1] = 0;
				eventid[2] = 0;
				eventid[3] = 0;

				txtInitialForm.Text = String.Empty;
				txtMidtermForm.Text = String.Empty;
				txtFinalForm.Text = String.Empty;

				cmbStatus.SelectedIndex = 0;
                SetEventModificationControls(false);

				//load Events if any
				llblInitialEvt.Text = String.Empty;
				txtInitialEvent.Text = "0";

				llblMidEvt.Text = String.Empty;
				txtMidtermEvent.Text = "0";

				llblFinalEvt.Text = String.Empty;
				txtFinalEvent.Text = "0";

				llblEvent.Text = String.Empty;
				llblEvent.Text = String.Empty;
			}
		}
        /*
		private void LoadEvent()
		{
			llblEvent.Text = "None";
			llblInitialEvt.Text = "None";
			llblMidEvt.Text = "None";
			llblFinalEvt.Text = "None";

			Scheduler.BusinessLayer.Course objCourse=new Scheduler.BusinessLayer.Course();
			objCourse.CourseID = _courseid;
			objCourse.LoadData();

			foreach(DataRow dr in objCourse.CourseDataTable.Rows)
			{
				txtEvent.Text = dr["EventID"].ToString();
				txtInitialEvent.Text = dr["TestInitialEventId"].ToString();
				txtMidtermEvent.Text = dr["TestMidTermEventId"].ToString();
				txtFinalEvent.Text = dr["TestFinalEventId"].ToString();
				break;
			}

			string strHint="";

			llblEvent.Text = objCourse.getEventText(txtEvent.Text, "Event", ref strHint);
			if(strHint!="") llblEvent.Text = strHint;

			strHint="";
			llblInitialEvt.Text = objCourse.getEventText(txtInitialEvent.Text, "Initial", ref strHint);
			strHint="";

			llblMidEvt.Text = objCourse.getEventText(txtMidtermEvent.Text, "Midterm", ref strHint);
			strHint="";

			llblFinalEvt.Text = objCourse.getEventText(txtEvent.Text, "Event", ref strHint);
			strHint="";
		}
        */
        private bool LoadEvent(int _eventid, ref ArrayList arrEvent)
        {
            //SaveEventData(ref _eventid);
            
            if (_eventid == 0) return false;
            DataTable dtbl = null;
            DateTime dt1 = Convert.ToDateTime(null);
            DateTime dt2 = Convert.ToDateTime(null);
            string sReccText = string.Empty;

            objEvent = new Scheduler.BusinessLayer.Events();
            objEvent.EventID = _eventid;

            dtbl = objEvent.LoadData();
            if (dtbl.Rows.Count <= 0)
            {
                return false;
            }

            arrEvent.Add("");
            foreach (DataRow dr in dtbl.Rows)
            {
                bool IsRecc = false;
                #region oldCode
                /*if(dr["RecurrenceText"]!=System.DBNull.Value)
                {
                    if(dr["RecurrenceText"].ToString()!="")
                    {
                        IsRecc=true;
                        FileInfo fi = new FileInfo(strAppPath);
                        StreamWriter Tex =fi.CreateText();
                        Tex.Write(XMLData_Initial);
                        Tex.Close();
                        Tex=null;

                        if(AP==null) AP = new Serialize();
                        AP = AP.Load(strAppPath);

                        if(AP==null)
                        {
                            dt1 = Convert.ToDateTime(dr["StartDateTime"].ToString());
                            dt2 = Convert.ToDateTime(dr["EndDateTime"].ToString());
                        }
                        else
                        {
                            try
                            {
                                setToConfig();
                                dt1 = Convert.ToDateTime(_startdate_Initial);
                                dt2 = Convert.ToDateTime(_enddate_Initial);

                                sReccText = SeforRecurrence();
                            }
                            catch{}
                        }
					
                    }
                }*/
                #endregion
                if (IsRecc == false)
                {
                    dt1 = Convert.ToDateTime(dr["StartDateTime"].ToString());
                    dt2 = Convert.ToDateTime(dr["EndDateTime"].ToString());
                }


                arrEvent.Add(dr["Name"].ToString());
                arrEvent.Add(dr["NamePhonetic"].ToString());
                arrEvent.Add(dr["NameRomaji"].ToString());

                arrEvent.Add(dt1.ToString());
                arrEvent.Add(dt2.ToString());
                //arrEvent.Add(sReccText.Trim());

                arrEvent.Add(dr["Location"].ToString());
                arrEvent.Add(dr["BlockCode"].ToString());
                arrEvent.Add(dr["RoomNumber"].ToString());
                if (dr["IsHoliday"] == System.DBNull.Value)
                {
                    arrEvent.Add("No");
                }
                else
                {
                    if (Convert.ToInt16(dr["IsHoliday"]) > 0)
                        arrEvent.Add("Yes");
                    else
                        arrEvent.Add("No");
                }
                if (dr["DateCompleted"] != System.DBNull.Value)
                {
                    arrEvent.Add(dr["DateCompleted"].ToString());
                }
                else
                {
                    arrEvent.Add("");
                }
                if (Convert.ToInt16(dr["EventStatus"].ToString()) == 0)
                {
                    arrEvent.Add("Active");
                }
                else
                {
                    arrEvent.Add("InActive");
                }
                arrEvent.Add(dr["ScheduledTeacher"].ToString());
                arrEvent.Add(dr["RealTeacher"].ToString());

                if (dr["ChangeReason"] != System.DBNull.Value)
                {
                    arrEvent.Add(dr["ChangeReason"].ToString());
                }
                else
                {
                    arrEvent.Add("");
                }
                if (dr["ExceptionReason"] != System.DBNull.Value)
                {
                    arrEvent.Add(dr["ExceptionReason"].ToString());
                }
                else
                {
                    arrEvent.Add("");
                }
                if (dr["Description"] != System.DBNull.Value)
                {
                    arrEvent.Add(dr["Description"].ToString());
                }
                else
                {
                    arrEvent.Add("");
                }
                if (dr["Note"] != System.DBNull.Value)
                {
                    arrEvent.Add(dr["Note"].ToString());
                }
                else
                {
                    arrEvent.Add("");
                }

                break;

            }
            return true;
        }

        //Loads other events (positive exceptions and tests) for a class event
        private void LoadOtherEvents()
        {
            BusinessLayer.Course objCourse = new Course();
            objCourse.CourseID = _courseid;
            /*
             * A Class MUST have an event of it's own to have EXTRA CLASSES.
             * A Class can HOWEVER have TEST EVENTS without an event of it's own
             */
            objCourse.EventID = eventid[3];
            objCourse.LoadData();
            //Load Events depending upon whether class re-occurs or not
            DataTable dtbl = objCourse.LoadOtherEvents(IsRecurringSeries);
            grdEvents.DataSource = dtbl;
            if (dtbl.Rows.Count==0)
            {
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
            }
            
            if (!IsRecurringSeries && HasTestInitialEvent && HasTestMidtermEvent && HasTestFinalEvent)
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;

            if (Common.LogonType == 2)
            {
                this.btnDelete.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnEdit.Text = "View";
            }
        }
        
        /*
        private bool OpenEvent(TextBox tb, string eType)
        {
            if (txtCourseName.Text == "")
            {
                BusinessLayer.Message.MsgInformation("Enter Class Name");
                txtCourseName.Focus();
                return false;
            }

            frmEventDlg fEvt = null;
            try
            {
                fEvt = new frmEventDlg(true);

                fEvt.EventName = txtCourseName.Text + " " + eType;
                if (tb.Text != "0")
                {
                    fEvt.EventID = Convert.ToInt32(tb.Text);
                    fEvt.Mode = "Edit";
                    fEvt.LoadData();
                }
                if (fEvt.ShowDialog() == DialogResult.OK)
                {
                    tb.Text = fEvt.EventID.ToString();
                    if (fEvt.EventID <= 0)
                    {
                        strEventText = "None";
                        return true;
                    }
                    strEventText = fEvt.dtStart.Value.ToShortDateString() + " " + fEvt.cmbStartTime.Text + " - " +
                        fEvt.dtEnd.Value.ToShortDateString() + " " + fEvt.cmbEndTime.Text;
                    if (strEventText.IndexOf("(") > 0)
                    {
                        strEventText = strEventText.Substring(0, strEventText.IndexOf("("));
                        strEventText = strEventText.Trim();
                    }

                    if (eType == "Event")
                    {
                        llblEvent.Tag = fEvt.lblRecurrenceText.Text;
                    }
                    return true;
                }
                else
                {
                    return false;
                    if(tb.Text!="0")
                    {
                        tb.Text = fEvt.EventID.ToString();
                        strEventText = fEvt.dtStart.Value.ToShortDateString() + " " + fEvt.cmbStartTime.Text + " - " +
                            fEvt.dtEnd.Value.ToShortDateString() + " " + fEvt.cmbEndTime.Text;
                        if(strEventText.IndexOf("(")>0)
                        {
                            strEventText = strEventText.Substring(0, strEventText.IndexOf("("));
                            strEventText=strEventText.Trim();
                        }

                        if(eType=="Event")
                        {
                            llblEvent.Tag = fEvt.lblRecurrenceText.Text;
                        }
                    }
                }
            }
            finally
            {
                fEvt.Close();
                fEvt.Dispose();
                fEvt = null;
            }
        }
        */
        void DrawTopLabel(Graphics g)
        {
            int TopMargin = printDocument1.DefaultPageSettings.Margins.Top;

            Font _font =
                new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            g.DrawString("Class Information", _font, new SolidBrush(label1.ForeColor), 20, 40, new StringFormat());
        }

        public void DrawTopLabel(DevExpress.XtraPrinting.BrickGraphics g)
        {

            int TopMargin = printingSystem.PageSettings.Margins.Top;

            Font _font =
                new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            g.Font = _font;
            RectangleF rect = new RectangleF(20, 40, 300, 300);
            try
            {
                Color c = label1.ForeColor;
                g.DrawString("Class Information", c, rect, DevExpress.XtraPrinting.BorderSide.None);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Methods for Events

        private void OpenInstructor(object sender)
		{
			ComboBox cbx = (ComboBox)sender;
			frmInstructorDlg fContDlg=new frmInstructorDlg();
			fContDlg.Mode="Add";
			if(fContDlg.ShowDialog()==DialogResult.OK)
			{
				Common.PopulateDropdown(
					cbx, "Select " +
					"TeacherName = CASE " + 
					"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
					"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
					"ELSE NickName " +
					"END From " +
					"Contact Where ContactType=1 " +
					" Order By LastName, FirstName ");

				cbx.SelectedIndex = cbx.Items.Count-1;

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
                    if (reader["TeacherName"] != DBNull.Value && reader["TeacherName"].ToString() != cbx.Text)
                    {
                        cbx.Items.Remove(reader["TeacherName"].ToString()); ;
                    }
                }
				//cmbTeacher2_I.Tag = cmbTeacher2_I.Text;
				/*cmbTeacher2_I.Items.Clear();
				foreach(string s in cmbTeacher1_I.Items)
				{
					cmbTeacher2_I.Items.Add(s);
				}
				cmbTeacher2_I.Text = cmbTeacher2_I.Tag.ToString();
				*/
			}
			fContDlg.Close();
			fContDlg.Dispose();
			fContDlg=null;
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

		//Checks for recurrence and generates text for it. Also hides/shows relevant panels
        private void SeforRecurrence(bool IsRecur)
		{
            if(IsRecur)
			{
				if(AP!=null)
				{
					if(AP.NoEntries!="")
					{boolNoOfRecords_Initial=true;}
				}
				string strText="";
				if(ReccType=="Daily")
				{
					if(Pattern1!="")
					{
						strText = "Occurs every " + Pattern2.ToString() + " day effective " + dtStart.Value.ToString("MM/dd/yy") + " from " + cmbStartTime.Text + " to " + cmbEndTime.Text;
					}
					else if(Pattern2!="")
					{
						strText = "Occurs every " + Pattern2 + " effective " + dtStart.Value.ToString("MM/dd/yy") + " from " + cmbStartTime.Text + " to " + cmbEndTime.Text.Trim();
					}
				}
				else if(ReccType=="Weekly")
				{
					if(Pattern1!="")
					{
						string s = Pattern2;
						s=s.Replace("|", ",");
						if(s.LastIndexOf(",")==s.Length-1)
						{
							s=s.Substring(0, s.Length-1);
						}
						strText = "Occurs weekly " + s + " of every " + Pattern1 + " week(s) effective " + dtStart.Value.ToString("MM/dd/yy") + " from " + cmbStartTime.Text + " to " + cmbEndTime.Text;
					}
				}
				else if(ReccType=="Monthly")
				{
					if(Pattern1!="")
					{
						strText = "Occurs day " + Pattern1.ToString() + " of every " + Pattern2 + " month(s) effective " + dtStart.Value.ToString("MM/dd/yy") + " from " + cmbStartTime.Text + " to " + cmbEndTime.Text;
					}
				}
				else if(ReccType=="Yearly")
				{
					if(Pattern1!="")
					{
						strText = "Occurs every " + Pattern1.ToString() + " " + Pattern2 + " effective " + dtStart.Value.ToString("MM/dd/yy") + " from " + cmbStartTime.Text + " to " + cmbEndTime.Text;
					}
				}

				lblRecurrenceText_I.Text = "Recurrence : " + strText;

				if((_curreventid>0) && (boolSaveSeries_initial==false))
				{
                    //for single occurrences in repeating class

					lblRecurrenceText1_I.Text = lblRecurrenceText_I.Text.Trim();

					if(lblRecurrenceText1_I.Text!="")
					{
						pnlTop_I.Visible=true;
						lblRecurrenceText1_I.Visible=true;
						picAlert1_I.Visible=true;
                        pnlBottom.Visible = false;
					}
					else
					{
						pnlTop_I.Visible=false;
						if (pnlBottom.Visible)
							txtNote_I.Height = 130;
						else
							txtNote_I.Height = 150;
					}

					lblRecurrenceText_I.Visible=false;
					picAlert_I.Visible=false;
					lblStartdt_I.Visible=true;
					lblEnddt_I.Visible=true;
					dtStart.Visible=true;
					dtEnd.Visible=true;
					cmbStartTime.Visible=true;
					cmbEndTime.Visible=true;
					if (pnlBottom.Visible)
						txtNote_I.Height = 130;
					else
						txtNote_I.Height = 150;
				}
				else
				{
                    IsRecurringSeries = true;
                    lblRecurrenceText_I.Visible=true;
					picAlert_I.Visible=true;
                    pnlTop_I.Visible = false;
                    pnlBottom.Visible = true;
                    btn_ClearRecc.Visible = true;
                    boolSaveSeries_initial = true;
					lblStartdt_I.Visible=false;
					lblEnddt_I.Visible=false;
					dtStart.Visible=false;
					dtEnd.Visible=false;
					cmbStartTime.Visible=false;
					cmbEndTime.Visible=false;
				}
			}
			else
			{
				//non-repeating class event
                lblRecurrenceText_I.Text="";
				lblRecurrenceText_I.Visible=false;
                btn_ClearRecc.Visible = false;
				picAlert_I.Visible=false;
                pnlBottom.Visible = true;
				lblStartdt_I.Visible=true;
				lblEnddt_I.Visible=true;
				dtStart.Visible=true;
				dtEnd.Visible=true;
				cmbStartTime.Visible=true;
				cmbEndTime.Visible=true;
			}
            /*
            if (IsRecurringSeries)
            {
                boolSaveSeries_initial = false;
                picAlert_I.Visible = true;
                lblRecurrenceText_I.Visible = true;
                picAlert1_I.Visible = false;
                lblRecurrenceText1_I.Visible = false;
                pnlTop_I.Visible = false;
                pnlBottom.Visible = true;
                lblStartdt_I.Visible = false;
                lblEnddt_I.Visible = false;
                dtStart.Visible = false;
                dtEnd.Visible = false;
                cmbStartTime.Visible = false;
                cmbEndTime.Visible = false;
            }*/
		}

		public bool setToConfig()
		{
			StartDate = AP.StartDate;
			EndDate = AP.EndDate;
			NoEntries = AP.NoEntries;
			ReccType = AP.ReccType;
			Pattern1 = AP.Pattern1;
			Pattern2 = AP.Pattern2;

			if(StartDate=="") return false;

			_startdate_Initial=AP.StartDate;
			_enddate_Initial=AP.EndDate;

			try
			{
				dtStart.Value = Convert.ToDateTime(StartDate);
				dtEnd.Value = Convert.ToDateTime(EndDate);
			}
			catch{}

			return true;
		}

		private void InitializeEventForm()
		{
			lblRecurrenceText1_I.Visible=false;
			picAlert1_I.Visible=false;
			lblStartdt_I.Visible=true;
			lblEnddt_I.Visible=true;
			dtStart.Visible=true;
			dtEnd.Visible=true;
			cmbStartTime.Visible=true;
			cmbEndTime.Visible=true;
			if (pnlBottom.Visible)
				txtNote_I.Height = 130;
			else
				txtNote_I.Height = 150;

			IsRecurrenceFlag_Initial=0;
			lblRecurrenceText_I.Text="";
			lblRecurrenceText1_I.Text="";
			XMLData_Initial="";
			if(File.Exists(strAppPath))
			{
				File.Delete(strAppPath);
			}
			SeforRecurrence(false);
			btn_ClearRecc.Visible=false;

			boolNoOfRecords_Initial = false;
			Common.MakeEnabled(pnlBody_I, false);

			foreach(Control c in pnlEvent.Controls)
			{
				if(c.GetType().ToString()=="System.Windows.Forms.Panel")
				{
					foreach(Control c1 in c.Controls)
					{
						if(c1.GetType().ToString()=="System.Windows.Forms.CheckBox")
						{
							CheckBox chk = c1 as CheckBox;
							chk.Checked=false;
						}
						else if(c1.GetType().ToString()=="System.Windows.Forms.RadioButton")
						{
							RadioButton rbtn = c1 as RadioButton;
							rbtn.Checked=false;
						}
						else if(c1.GetType().ToString()=="System.Windows.Forms.TextBox")
						{
							TextBox tbox = c1 as TextBox;
							tbox.Text="";
						}
						else if(c1.GetType().ToString()=="System.Windows.Forms.ComboBox")
						{
							ComboBox cbx = c1 as ComboBox;
							cbx.SelectedIndex=-1;
							cbx.Text="";
						}
						else if(c1.GetType().ToString()=="System.Windows.Forms.DateTimePicker")
						{
							DateTimePicker dt = c1 as DateTimePicker;
							dt.Value = DateTime.Now;
						}
					}
				}

				if(c.GetType().ToString()=="System.Windows.Forms.CheckBox")
				{
					CheckBox chk = c as CheckBox;
					chk.Checked=false;
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.RadioButton")
				{
					RadioButton rbtn = c as RadioButton;
					rbtn.Checked=false;
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.TextBox")
				{
					TextBox tbox = c as TextBox;
					tbox.Text="";
				}
				else if(c.GetType().ToString()=="System.Windows.Forms.ComboBox")
				{
					ComboBox cbx = c as ComboBox;
					cbx.Text="";
				}
			}

			cmbEventType_I.SelectedIndex=0;
		}

        
		#endregion

		#region Control Events for Calendar
		private void llblTeacher1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			OpenInstructor(cmbTeacher1_I);
		}

		private void llblTeacher2_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			OpenInstructor(cmbTeacher2_I);		
		}

		private void btnRecurrence_Click(object sender, System.EventArgs e)
		{
			string strEndTime="";

			frm_RecurrenceDiaryDlg frmRecc=new frm_RecurrenceDiaryDlg(dtStart.Value, dtEnd.Value, cmbStartTime.Text, cmbEndTime.Text);
			if(frmRecc.ShowDialog()==DialogResult.OK)
			{
				if(dtblDates==null)
				{
					dtblDates = new DataTable();
					dtblDates.Columns.Add("StartDate", Type.GetType("System.DateTime"));
					dtblDates.Columns.Add("EndDate", Type.GetType("System.DateTime"));
				}
				else
				{
					dtblDates.Rows.Clear();
				}

				IsEventChanged=true;
				cmbStartTime.Text = frmRecc.StartTimeText;
				
				strEndTime = frmRecc.EndTimeText;
				if(strEndTime.Length>7)
				{
					strEndTime = strEndTime.Substring(0,8).ToString().Trim();
				}
				SetTime(cmbEndTime, strEndTime);
				//boolSaveSeries_initial=true;

				boolNoOfRecords_Initial = frmRecc.rdb_NoofEntries.Checked;
			}
			frmRecc.Close();
			frmRecc.Dispose();
			frmRecc=null;

			if(File.Exists(strAppPath))
			{
				if(AP==null) AP=new Serialize();
				AP = AP.Load(strAppPath);
				if(AP==null) SeforRecurrence(false);
				else
				{
					if(!setToConfig())
					{
						SeforRecurrence(false);
					}
					else
					{
						btn_ClearRecc.Visible=true;
						IsRecurrenceFlag_Initial=1;
                        SeforRecurrence(true);
					}
				}
			}
			else SeforRecurrence(false);
		}

		private void btn_ClearRecc_Click(object sender, System.EventArgs e)
		{
			if(dtblDates!=null)
			{
				dtblDates.Rows.Clear();
			}
			IsEventChanged=true;

			IsRecurrenceFlag_Initial=0;
			lblRecurrenceText_I.Text="";
			lblRecurrenceText1_I.Text="";
			XMLData_Initial="";
			if(File.Exists(strAppPath))
			{
				File.Delete(strAppPath);
			}
			SeforRecurrence(false);
			btn_ClearRecc.Visible=false;

			boolNoOfRecords_Initial = false;
		}

		

		private void tbcCourse_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//DoProcessCourseTabChanging(true, tbcCourse.SelectedTab!=pnlEvent.Parent);
            DoProcessCourseTabChanging(true);
		}
        bool saved = false;
		private void DoProcessCourseTabChanging(bool showOnChangeConfirmation) 
		{
			pnlTop_I.Visible=false;
			//this.tbcCourse.SelectedIndexChanged -= new System.EventHandler(this.tbcCourse_SelectedIndexChanged);
			try
			{
				TabPage tbpSelected=tbcCourse.SelectedTab;
                /*
				if((tbcCourse.SelectedTab == tbpInitial) ||
				   (tbcCourse.SelectedTab == tbpMidterm) ||
				   (tbcCourse.SelectedTab == tbpFinal) ||
				   (tbcCourse.SelectedTab == tbpClassEvent))
                    */
                if ((tbcCourse.SelectedTab == tbpClassEvent) || (tbcCourse.SelectedTab == tbpOtherEvents))
                {
                    if (saved)
                    {
                        IsEventChanged = false;
                        saved = false;
                    }
					if(IsEventChanged)
					{
						if(pnlEvent.Parent!=tbpSelected)
						{
							tbcCourse.SelectedTab=(TabPage)pnlEvent.Parent;
						}

						DialogResult dlg = DialogResult.No;
							
						if (showOnChangeConfirmation)
						{
                            if(Common.LogonType != 2)
							    dlg = MessageBox.Show(this, "Do you want to save the current Class Event?", "Scheduler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
						}
						
						if(dlg==DialogResult.No)
						{
							tbcCourse.SelectedTab = (TabPage)pnlEvent.Parent;
							return;
						}
						else if(dlg==DialogResult.Yes)
						{
							if(!doSaveEvents(GetCurrentEventID((TabPage)pnlEvent.Parent)))
							{
								tbcCourse.SelectedTab = (TabPage)pnlEvent.Parent;
								return;
							}
						}
                        
						tbcCourse.SelectedTab = tbpSelected;
					}
				    
                    //re-loads all controls on the new tab (no longer needed)
                    /*
					if(reloadControl)
					{
						if(pnlEvent.Parent!=null)
						{
							pnlEvent.Parent.Controls.Remove(pnlEvent);
						}
						tbcCourse.SelectedTab.Controls.Add(pnlEvent);
						InitializeEventForm();
					}
                    
					if(tbcCourse.SelectedTab==tbpInitial)
					{
						if(eventid[0]==0)
						{
							txtName_I.Text = txtCourseName.Text + " Initial Test";
							cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
							cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0,0,30,0,0)).ToString("HH:mm");
						}
						else
						{
							LoadEvent(eventid[0], calendareventid[0]);
						}
					}
					if(tbcCourse.SelectedTab==tbpMidterm)
					{

						if(eventid[1]==0)
						{
							txtName_I.Text = txtCourseName.Text + " Midterm Test";
							cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
							cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0,0,30,0,0)).ToString("HH:mm");
						}
						else
						{
							LoadEvent(eventid[1], calendareventid[1]);
						}
					}
					if(tbcCourse.SelectedTab==tbpFinal)
					{

						if(eventid[2]==0)
						{
							txtName_I.Text = txtCourseName.Text + " Final Test";
							cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
							cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0,0,30,0,0)).ToString("HH:mm");
						}
						else
						{
							LoadEvent(eventid[2], calendareventid[2]);
						}
					}*/
					if(tbcCourse.SelectedTab==tbpClassEvent)
					{

						if(eventid[3]==0)
						{
							txtName_I.Text = txtCourseName.Text;
							cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
                            DateTime testEnd = Convert.ToDateTime(cmbStartTime.Text);
                            if (testEnd.Hour >= 23 && testEnd.Minute >= 30)
                                cmbEndTime.Text = cmbStartTime.Text;
                            else
							    cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0,0,30, 0,0)).ToString("HH:mm");
						}
						else
						{
							LoadEvent(eventid[3], calendareventid[3]);
						}
					}

                    if (tbcCourse.SelectedTab == tbpOtherEvents)
                    {
                        if(_mode=="Edit") LoadOtherEvents();
                    }
						
					IsEventChanged=false;
				}
				else
				{
					_curreventid=0;
				}
			}
			finally
			{/*
				if((tbcCourse.SelectedTab == tbpInitial) ||
				   (tbcCourse.SelectedTab == tbpMidterm) ||
				   (tbcCourse.SelectedTab == tbpFinal) ||
				   (tbcCourse.SelectedTab == tbpClassEvent))*/
				if(tbcCourse.SelectedTab == tbpClassEvent)
                {
					this.ActiveControl = txtName_I;
				}
				if(tbcCourse.SelectedTab==tbpClassEvent)
				{
                    /*
					if(boolSaveSeries_initial)
					{
						pnlBottom.Visible = false;
					}
					else
					{
						pnlBottom.Visible = true;
					}*/
				}/*
				else
				{
					pnlBottom.Visible = false;
				}*/

				if (pnlBottom.Visible)
					txtNote_I.Height = 130;
				else
					txtNote_I.Height = 150;

				//this.tbcCourse.SelectedIndexChanged += new System.EventHandler(this.tbcCourse_SelectedIndexChanged);
			}
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

		private void cmbStartTime_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			IsEventChanged=true;

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

		private void dtStart_ValueChanged(object sender, System.EventArgs e)
		{
			IsEventChanged=true;
			if((dtEnd.Value>dtStart.Value) || (dtEnd.Value<dtStart.Value))
			{
				cmbEndTime.Items.Clear();
				foreach(string s in cmbStartTime.Items)
				{
					cmbEndTime.Items.Add(s);
				}
			}
		}

		private void dtEnd_ValueChanged(object sender, System.EventArgs e)
		{
			IsEventChanged=true;
			if((dtEnd.Value>dtStart.Value) || (dtEnd.Value<dtStart.Value))
			{
				cmbEndTime.Items.Clear();
				foreach(string s in cmbStartTime.Items)
				{
					cmbEndTime.Items.Add(s);
				}
			}
		}

		private void txtName_I_TextChanged(object sender, System.EventArgs e)
		{
			IsEventChanged=true;
		}

		private void btnDelete1_Click(object sender, System.EventArgs e)
		{
			int _eventid=0;
			if(Scheduler.BusinessLayer.Message.MsgDelete())
			{
				string strMess="";
				Events evt = new Events();
                /*
				if(pnlEvent.Parent==tbpInitial)
				{
					_eventid=eventid[0];
					
					evt.EventID = _eventid;
					evt.DeleteData(true);

					//Update the Class data
					evt.UpdateClassEvent("TestInitialEventID", 0, _courseid);
					
					eventid[0]=0;
				}
				else if(pnlEvent.Parent==tbpMidterm)
				{
					_eventid=eventid[1];
					evt.EventID = _eventid;
					evt.DeleteData(true);

					//Update the Class data
					evt.UpdateClassEvent("TestMidTermEventID", 0, _courseid);
					
					eventid[1]=0;
				}
				else if(pnlEvent.Parent==tbpFinal)
				{
					_eventid=eventid[2];
					evt.EventID = _eventid;
					evt.DeleteData(true);

					//Update the Class data
					evt.UpdateClassEvent("TestFinalEventID", 0, _courseid);
					
					eventid[2]=0;
				}
				else*/ if(pnlEvent.Parent==tbpClassEvent)
				{
					_eventid=eventid[3];
					evt.EventID = _eventid;
					evt.DeleteData(true);

					//Update the Class data
					evt.UpdateClassEvent("EventID", 0, _courseid);
					
					eventid[3]=0;
				}

				_curreventid=0;

				InitializeEventForm();
				IsEventChanged=false;
			}
		}

		private void cmbEventStatus_I_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            //IsEventChanged=true;
            //if(GetCurrentEventID((TabPage)pnlEvent.Parent)>0)
            //{
            //    if(cmbEventStatus_I.SelectedIndex==1)
            //    {
            //        Common.MakeReadOnly(pnlBody_I, false);
            //        cmbEventStatus_I.Enabled=true;
            //    }
            //    else
            //    {
            //        Common.MakeEnabled(pnlBody_I, false);
            //    }
            //    cmbEventType_I_SelectedIndexChanged(sender, null);
            //}
		}

		private void cmbEventType_I_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			IsEventChanged=true;
			if(cmbEventType_I.SelectedIndex==0)
			{
				dtDateComplete_I.Enabled=false;
			}
			else
			{
				dtDateComplete_I.Enabled=true;
			}
		}

		#endregion

        #region Event Handling

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            btnEventSave_Click(sender, e); //fake call to save event. it is here to remove a save button. actually the code below is unclear to me sorry

            #region Course Validation
            if (txtCourseName.Text == "")
            {
                tbcCourse.SelectedIndex = 0;
                Scheduler.BusinessLayer.Message.MsgInformation("Enter Class Name");
                txtCourseName.Focus();
                return;
            }
            if (cmbProgram.Text == "")
            {
                tbcCourse.SelectedIndex = 0;
                Scheduler.BusinessLayer.Message.MsgInformation("Enter Program");
                cmbProgram.Focus();
                return;
            }
            if (cmbCourseType.Text == "")
            {
                tbcCourse.SelectedIndex = 0;
                Scheduler.BusinessLayer.Message.MsgInformation("Enter Job Type");
                cmbCourseType.Focus();
                return;
            }

            bool boolSuccess;
            #endregion

            Scheduler.BusinessLayer.Course objCourse = null;

            #region Setting Course Object
            objCourse = new Scheduler.BusinessLayer.Course();
            objCourse.CourseID = 0;

            objCourse.name = txtCourseName.Text;
            objCourse.NamePhonetic = txtNamePhonetic.Text;
            objCourse.NameRomaji = txtNameRomaji.Text;
            objCourse.NickName = txtNickName.Text;
            objCourse.ProgramID = intProgramID;

            objCourse.CourseType = cmbCourseType.Text;
            int noOfStudents = 0;
            if (txtNumberStudents.Text != "")
                Int32.TryParse(txtNumberStudents.Text, out noOfStudents);
            int homeworkMinutes = 0;
            if (txtHomeWorkMinutes.Text != "")
                Int32.TryParse(txtHomeWorkMinutes.Text, out homeworkMinutes);
            objCourse.NumberStudents = noOfStudents;
            objCourse.HomeWorkMinutes = homeworkMinutes;

            objCourse.Description = txtDescription.Text;
            objCourse.SpecialRemarks = txtRemarks.Text;
            objCourse.Curriculam = txtCurriculam.Text;

            objCourse.TestInitialEventID = eventid[0];//Convert.ToInt32(txtInitialEvent.Text);
            objCourse.TestMidEventID = eventid[1];//Convert.ToInt32(txtMidtermEvent.Text);
            objCourse.TestFinalEventID = eventid[2];//Convert.ToInt32(txtFinalEvent.Text);
            objCourse.EventID = eventid[3];//Convert.ToInt32(txtEvent.Text);

            objCourse.TestInitialForm = txtInitialForm.Text;
            objCourse.TestMidtermForm = txtMidtermForm.Text;
            objCourse.TestFinalForm = txtFinalForm.Text;

            objCourse.CourseStatus = cmbStatus.SelectedIndex;

            objCourse.CourseID = _courseid;
            //if (objCourse.Exists())
            //{
            //    Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Class Name not allowed");
            //    txtCourseName.Focus();
            //    return;
            //}
            if (txtNickName.Text != "")
            {
                if (objCourse.NickNameExists())
                {
                    Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Abbreviated Name not allowed");
                    txtNickName.Focus();
                    return;
                }
            }
            if ((_mode == "Add") || (_mode == "AddClone") || (_mode == ""))
            {
                boolSuccess = objCourse.InsertData();
            }
            else
            {
                objCourse.CourseID = _courseid;
                boolSuccess = objCourse.UpdateData();
            }
            #endregion

            #region Handling the event saving
            if (IsEventChanged)
            {
                DialogResult dlg = MessageBox.Show(this,
                                                "You have made changes to the events.\n\nWould you like to save the changes?",
                                                "Scheduler",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                {
                    SaveAllEvents(GetCurrentEventID((TabPage)pnlEvent.Parent));
                }
            }
            if (objEvent != null)
            {
                //Update the events
                _courseid = objCourse.CourseID;
                if (_courseid != 0)
                {
                    int _id = 0;
                    //Test Initial Event
                    if (eventid[0] != 0)
                    {
                        _id = eventid[0];
                        if (_id < 0) _id = 0;
                        objEvent.UpdateClassEvent("TestInitialEventID", _id, _courseid);
                        _id = 0;
                    }
                    //Test Midterm Event
                    if (eventid[1] != 0)
                    {
                        _id = eventid[1];
                        if (_id < 0) _id = 0;
                        objEvent.UpdateClassEvent("TestMidtermEventID", _id, _courseid);
                        _id = 0;
                    }
                    //Test Final Event
                    if (eventid[2] != 0)
                    {
                        _id = eventid[2];
                        if (_id < 0) _id = 0;
                        objEvent.UpdateClassEvent("TestFinalEventID", _id, _courseid);
                        _id = 0;
                    }
                    //Class Event
                    if (eventid[3] != 0)
                    {
                        _id = eventid[3];
                        if (_id < 0) _id = 0;
                        objEvent.UpdateClassEvent("EventID", _id, _courseid);
                        _id = 0;
                    }
                }
            }

            #endregion
            if (!boolSuccess)
            {
                if (_mode == "Add")
                    Scheduler.BusinessLayer.Message.ShowException("Inserting Class record.", objCourse.Message);
                else if (_mode == "AddClone")
                    Scheduler.BusinessLayer.Message.ShowException("Cloning Class record.", objCourse.Message);
                else
                    Scheduler.BusinessLayer.Message.ShowException("Updating Class record.", objCourse.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void llblProgram_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            frmProgramDlg fProgDlg = new frmProgramDlg();
            if (llblProgram.Tag == null || Convert.ToInt32(llblProgram.Tag) == 0)
                fProgDlg.Mode = "Add";
            else
            {
                fProgDlg.ProgramID = Convert.ToInt32(llblProgram.Tag);
                fProgDlg.Mode = "Edit";
                fProgDlg.LoadData();
            }
            
            if (fProgDlg.ShowDialog() == DialogResult.OK)
            {
                Common.PopulateDropdown(
                    cmbProgram, "Select Name = CASE " +
                    "WHEN NickName IS NULL THEN Name " +
                    "WHEN NickName = '' THEN Name " +
                    "ELSE NickName " +
                    "END From " +
                    "Program Where ProgramStatus=0 Order By [Name] ");
                cmbProgram.SelectedIndex = cmbProgram.Items.Count - 1;
            }
            fProgDlg.Close();
            fProgDlg.Dispose();
            fProgDlg = null;
        }

        private void txtNumberStudents_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Common.MaskInteger(e);
        }

        private void frmCourseDlg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

        private void llblInitialEvt_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //if(!OpenEvent(txtInitialEvent, "Initial Test")) return;
            //llblInitialEvt.Text = strEventText;
            //if(strEventText=="") llblInitialEvt.Text = "None";

            //tbcCourse.SelectedTab = tbpInitial;
            tbcCourse.SelectedTab = tbpOtherEvents;
        }

        private void llblMidEvt_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //if(!OpenEvent(txtMidtermEvent, "Midterm Test")) return;
            //llblMidEvt.Text = strEventText;
            //if(strEventText=="") llblMidEvt.Text = "None";

            //tbcCourse.SelectedTab = tbpMidterm;
            tbcCourse.SelectedTab = tbpOtherEvents;
        }

        private void llblFinalEvt_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //if(!OpenEvent(txtFinalEvent, "Final Test")) return;
            //llblFinalEvt.Text = strEventText;
            //if(strEventText=="") llblFinalEvt.Text = "None";

            //tbcCourse.SelectedTab = tbpFinal;
            tbcCourse.SelectedTab = tbpOtherEvents;
        }

        private void llblEvent_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //OpenEvent(txtEvent, "Event");	

            if (txtCourseName.Text == "")
            {
                BusinessLayer.Message.MsgInformation("Enter Class Name");
                txtCourseName.Focus();
                return;
            }

            tbcCourse.SelectedTab = tbpClassEvent;

            /*frmEventDlg fEvt=null;
            try
            {
                fEvt = new frmEventDlg(true);

                fEvt.EventName = txtCourseName.Text + " " + "Event";
                if(txtEvent.Text!="0")
                {
                    fEvt.EventID = Convert.ToInt32(txtEvent.Text);
                    fEvt.Mode="Edit";
                    fEvt.LoadData();
                }
                if(fEvt.ShowDialog()==DialogResult.OK)
                {
                    txtEvent.Text = fEvt.EventID.ToString();
                    if(fEvt.EventID<=0)
                    {
                        txtEvent.Text="None";
                        return;
                    }
                    strEventText = fEvt.dtStart.Value.ToShortDateString() + " " + fEvt.cmbStartTime.Text + " - " +
                        fEvt.dtEnd.Value.ToShortDateString() + " " + fEvt.cmbEndTime.Text;
                    if(strEventText.IndexOf("(")>0)
                    {
                        strEventText = strEventText.Substring(0, strEventText.IndexOf("("));
                        strEventText=strEventText.Trim();
                    }

                    llblEvent.Tag = fEvt.lblRecurrenceText.Text;
                }
                else
                {
                    return;
                }
			
                llblEvent.Text = strEventText;
                if(strEventText.IndexOf("(")>0)
                {
                    strEventText = strEventText.Substring(0, strEventText.IndexOf("(")+1);
                }

                if(strEventText=="") llblEvent.Text = "None";
                if(llblEvent.Tag!=null)
                {
                    if((llblEvent.Tag.ToString().Trim()!="Recurrence :") && (llblEvent.Tag.ToString()!=""))
                        llblEvent.Text = llblEvent.Tag.ToString();
                }

                cmbClient.Focus();
            }
            finally
            {
                fEvt.Close();
                fEvt.Dispose();
                fEvt=null;
            }*/
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (BusinessLayer.Message.MsgDelete())
            {
                Scheduler.BusinessLayer.Course objCourse = new Scheduler.BusinessLayer.Course();
                objCourse.CourseID = _courseid;
                if (!objCourse.DeleteData())
                {
                    BusinessLayer.Message.MsgWarning("Class cannot be deleted");
                    return;
                }
                else
                {
                    deleted = true;
                    btnDelete.Enabled = false;
                    this.Text = "Adding Class...";
                    _mode = "Add";
                    _courseid = 0;

                    foreach (Control c in tbpCourse.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            if (c.Tag == null) c.Text = "";
                            else if (c.Tag.ToString() == "N") c.Text = "0";
                        }
                        if (c.GetType().ToString() == "System.Windows.Forms.LinkLabel")
                        {
                            c.Text = "None";
                        }
                        if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            c.Text = "";
                        }
                    }
                    foreach (Control c in tbpCurriculam.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            if (c.Tag == null) c.Text = "";
                            else if (c.Tag.ToString() == "N") c.Text = "0";
                        }
                        if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            c.Text = "";
                        }
                    }
                    foreach (Control c in tbpDescription.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            if (c.Tag == null) c.Text = "";
                            else if (c.Tag.ToString() == "N") c.Text = "0";
                        }
                        if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            c.Text = "";
                        }
                    }
                    foreach (Control c in tbpSpecialRemarks.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            if (c.Tag == null) c.Text = "";
                            else if (c.Tag.ToString() == "N") c.Text = "0";
                        }
                        if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            c.Text = "";
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }

        }

        private void llblInitialEvt_MouseEnter(object sender, System.EventArgs e)
        {
            if (llblInitialEvt.Tag != null)
            {
                //lblHint.Text = llblInitialEvt.Tag.ToString();
                //if(lblHint.Text!="") lblHint.Visible=true;
                //lblHint.Top = llblInitialEvt.Top + 20;
            }
        }

        private void llblInitialEvt_MouseLeave(object sender, System.EventArgs e)
        {
            //lblHint.Visible=false;		
        }

        private void llblMidEvt_MouseEnter(object sender, System.EventArgs e)
        {
            if (llblMidEvt.Tag != null)
            {
                //lblHint.Text = llblMidEvt.Tag.ToString();
                //if(lblHint.Text!="") lblHint.Visible=true;
                //lblHint.Top = llblMidEvt.Top + 20;
            }
        }

        private void llblMidEvt_MouseLeave(object sender, System.EventArgs e)
        {
            //lblHint.Visible=false;		
        }

        private void llblFinalEvt_MouseEnter(object sender, System.EventArgs e)
        {
            if (llblFinalEvt.Tag != null)
            {
                //lblHint.Text = llblFinalEvt.Tag.ToString();
                //if(lblHint.Text!="") lblHint.Visible=true;
                //lblHint.Top = llblFinalEvt.Top + 20;
            }
        }

        private void llblFinalEvt_MouseLeave(object sender, System.EventArgs e)
        {
            //lblHint.Visible=false;		
        }

        private void llblEvent_MouseEnter(object sender, System.EventArgs e)
        {
            //if(llblEvent.Tag!=null)
            //{
            //	lblHint.Text = llblEvent.Tag.ToString();
            //	if(lblHint.Text!="") lblHint.Visible=true;
            //	lblHint.Top = llblEvent.Top + 20;
            //}
        }

        private void llblEvent_MouseLeave(object sender, System.EventArgs e)
        {
            //lblHint.Visible=false;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //if (_mode == "Edit")
            {
                if (cmbStatus.SelectedIndex == 1)
                {
                    Common.MakeReadOnly(tbpCourse, false);
                    Common.MakeReadOnly(tbpCurriculam, false);
                    Common.MakeReadOnly(tbpDescription, false);
                    Common.MakeReadOnly(tbpSpecialRemarks, false);
                    cmbStatus.Enabled = true;
                }
                else
                {
                    Common.MakeEnabled(tbpCourse, false);
                    Common.MakeEnabled(tbpCurriculam, false);
                    Common.MakeEnabled(tbpDescription, false);
                    Common.MakeEnabled(tbpSpecialRemarks, false);
                }

                if (Common.LogonType == 2)
                {
                    this.btnDelete.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnAdd.Enabled = false;
                    this.btnDel.Enabled = false;
                    this.btnEdit.Text = "View";
                    this.llblClient.Enabled = false;
                    this.llbDepartment.Enabled = false;
                    this.llblEvent.Enabled = false;
                    this.llblFinalEvt.Enabled = false;
                    this.llblInitialEvt.Enabled = false;
                    this.llblMidEvt.Enabled = false;
                    this.llblProgram.Enabled = false;
                    this.llblTeacher1_I.Enabled = false;
                    this.llblTeacher2_I.Enabled = false;
                }
            }
        }

        private void cmbClient_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbClient.SelectedIndex == 0) intClientID = 0;
            intClientID = Common.GetCompanyID(
                "Select ContactID From Contact " +
                "Where (CompanyName =@CompanyName OR NickName=@CompanyName) ", cmbClient.Text
                );

            if (intClientID != 0)
            {
                
                Common.PopulateDropdown(
                    cmbDept, "Select CompanyName = CASE " +
                    "WHEN C.NickName IS NULL THEN C.CompanyName " +
                    "WHEN C.NickName = '' THEN C.CompanyName " +
                    "ELSE C.NickName " +
                    "END From " +
                    "Department D, Contact C Where D.ContactID=C.ContactID and " +
                    "D.ClientID=" + intClientID +
                    " Order By CompanyName");

                string query = "Select CompanyName = CASE " +
                    "WHEN C.NickName IS NULL THEN C.CompanyName " +
                    "WHEN C.NickName = '' THEN C.CompanyName " +
                    "ELSE C.NickName " +
                    "END From " +
                    "Department D, Contact C Where D.ContactID=C.ContactID and " +
                    "D.DepartmentStatus=1 and D.ClientID=" + intClientID +
                    " Order By CompanyName";

                IDataReader reader = DAC.SelectStatement(query);

                while (reader.Read())
                {
                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        cmbDept.Items.Remove(reader["CompanyName"].ToString()); ;
                    }
                }
                cmbProgram.Items.Clear();
            }
            llblClient.Tag = intClientID;
        }

        private void cmbDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbDept.SelectedIndex == 0) intDepartmentID = 0;
            intDepartmentID = Common.GetCompanyID(
                "Select D.DepartmentID from Department D, Contact C " +
                "Where D.ContactID=C.ContactID and (C.CompanyName= @CompanyName OR C.NickName=@CompanyName) and ClientID=" + intClientID.ToString(), cmbDept.Text
                );

            if (intDepartmentID != 0)
            {
                llblProgram.Tag = 0;
                Common.PopulateDropdown(
                    cmbProgram, "Select [Name] = CASE " +
                    "WHEN NickName IS NULL THEN [Name] " +
                    "WHEN NickName = '' THEN [Name] " +
                    "ELSE NickName " +
                    "END From " +
                    "Program Where ProgramStatus=0 and DepartmentID=" + intDepartmentID +
                    " Order By [Name] ");

            }
            llbDepartment.Tag = intDepartmentID;
        }

        private void cmbProgram_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            intProgramID = Common.GetProgramID(
                "Select ProgramID From Program Where (Name =@Name OR NickName=@Name) and DepartmentID=" + intDepartmentID.ToString(), cmbProgram.Text
                );
            if(cmbProgram.SelectedIndex != 0)
                llblProgram.Tag = intProgramID;
            else
                llblProgram.Tag = 0;
        }

        private void llblClient_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            frmClientDlg fContDlg = new frmClientDlg();
            if (llblClient.Tag == null || Convert.ToInt32(llblClient.Tag) == 0)
                fContDlg.Mode = "Add";
            else
            {
                fContDlg.ContactID = Convert.ToInt32(llblClient.Tag);
                fContDlg.Mode = "Edit";
                fContDlg.LoadData();
            }
            //fContDlg.Mode = "Add";
            string str = cmbClient.Text;
            if (fContDlg.ShowDialog() == DialogResult.OK)
            {
                Common.PopulateDropdown(
                    cmbClient, "Select CompanyName = CASE " +
                    "WHEN NickName IS NULL THEN CompanyName " +
                    "WHEN NickName = '' THEN CompanyName " +
                    "ELSE NickName " +
                    "END From " +
                    "Contact Where ContactType=2 " +
                    " Order By CompanyName ");

                cmbClient.Text = str;
                string query = "Select CompanyName = CASE " +
                    "WHEN NickName IS NULL THEN CompanyName " +
                    "WHEN NickName = '' THEN CompanyName " +
                    "ELSE NickName " +
                    "END From " +
                    "Contact Where ContactType=2 and " +
                    "ContactStatus=1 Order By CompanyName ";

                IDataReader reader = DAC.SelectStatement(query);

                while (reader.Read())
                {
                    if (reader["CompanyName"] != DBNull.Value && reader["CompanyName"].ToString() != str)
                    {
                        cmbClient.Items.Remove(reader["CompanyName"].ToString()); ;
                    }
                }
            }
            fContDlg.Close();
            fContDlg.Dispose();
            fContDlg = null;
        }

        private void llbDepartment_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            frmDepartmentDlg fDeptDlg = new frmDepartmentDlg();
            fDeptDlg.Mode = "Add";
            if (llbDepartment.Tag == null || Convert.ToInt32(llbDepartment.Tag) == 0)
                fDeptDlg.Mode = "Add";
            else
            {
                fDeptDlg.DeptID = Convert.ToInt32(llbDepartment.Tag);
                fDeptDlg.Mode = "Edit";
                fDeptDlg.LoadData();
            }
            string str = cmbDept.Text;
            if (fDeptDlg.ShowDialog() == DialogResult.OK)
            {
                cmbClient_SelectedIndexChanged(sender, null);
                cmbDept.Text = str;
            }
            fDeptDlg.Close();
            fDeptDlg.Dispose();
            fDeptDlg = null;
        }
		
        private void frmCourseDlg_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(File.Exists(strAppPath))
			{
				File.Delete(strAppPath);
			}
		}

		private void btnPageSetup_Click(object sender, System.EventArgs e)
		{
			//PrintingFunctions.ShowPageSettings(ref ps);
            printingSystem.PageSetup();
			//printDocument1.DefaultPageSettings = ps;
		}
        DevExpressClassPrinting classPrinting;
        DevNormalPrinting devNormalPrinting;
		private void btnPrint_Click(object sender, System.EventArgs e)
        {
            DoProcessCourseTabChanging(true);
           // doSaveEvents(GetCurrentEventID((TabPage)pnlEvent.Parent));
          //  SaveEventData(ref _eventid_Initial);
            #region Intializing Values to Lists
            ArrayList arrLabel = new ArrayList();

			ArrayList arrLabel1 = new ArrayList();

			ArrayList arrValue1 = new ArrayList();
			ArrayList arrValue2 = new ArrayList();
			ArrayList arrValue3 = new ArrayList();
			ArrayList arrValue4 = new ArrayList();
			
			arrLabel.Add("------");
			arrLabel.Add("Name");
			arrLabel.Add("Name Phonetic");
			arrLabel.Add("Name Romaji");
			arrLabel.Add("Abbreviated Name");
			arrLabel.Add("Class Event");
			arrLabel.Add("Client");
			arrLabel.Add("Department");
			arrLabel.Add("Program");
			arrLabel.Add("Job Type");
			arrLabel.Add("Status");
			arrLabel.Add("------");
			arrLabel.Add("Test Initial");
			arrLabel.Add("Test Mid-term");
			arrLabel.Add("Test Final");
			arrLabel.Add("------");
			arrLabel.Add("No. of Students");
			arrLabel.Add("Homework Minutes");
			arrLabel.Add("Test Initial Form");
			arrLabel.Add("Test Mid-term Form");
			arrLabel.Add("Test Final Form");

			arrLabel.Add("------");
			arrLabel.Add("Description");
			arrLabel.Add("------");
			arrLabel.Add("Special Remarks");
			arrLabel.Add("------");
			arrLabel.Add("Curriculum");

			ArrayList arrValues = new ArrayList();
			arrValues.Add("------");
			arrValues.Add(txtCourseName.Text);
			arrValues.Add(txtNamePhonetic.Text);
			arrValues.Add(txtNameRomaji.Text);
			arrValues.Add(txtNickName.Text);
			arrValues.Add(llblEvent.Text);
			arrValues.Add(cmbClient.Text);
			arrValues.Add(cmbDept.Text);
			arrValues.Add(cmbProgram.Text);
			arrValues.Add(cmbCourseType.Text);
			arrValues.Add(cmbStatus.Text);
			arrValues.Add("------");
			arrValues.Add(llblInitialEvt.Text);
			arrValues.Add(llblMidEvt.Text);
			arrValues.Add(llblFinalEvt.Text);
			arrValues.Add("------");

			arrValues.Add(txtNumberStudents.Text);
			arrValues.Add(txtHomeWorkMinutes.Text);
			
			arrValues.Add(txtInitialForm.Text);
			arrValues.Add(txtMidtermForm.Text);
			arrValues.Add(txtFinalForm.Text);
			
			arrValues.Add("RICHTEXT");
			arrValues.Add(txtDescription.Text);
			arrValues.Add("RICHTEXT");
			arrValues.Add(txtRemarks.Text);
			arrValues.Add("RICHTEXT");
			arrValues.Add(txtCurriculam.Text);
			

			//Event//
			arrLabel1.Add("------");
			arrLabel1.Add("Name");
			arrLabel1.Add("Name Phonetic");
			arrLabel1.Add("Name Romaji");
			arrLabel1.Add("Start Date");
			arrLabel1.Add("End Date");
			//arrLabel1.Add("Recurrence");
			arrLabel1.Add("Location");
			arrLabel1.Add("Block");
			arrLabel1.Add("Room No.");
			arrLabel1.Add("Is Holiday");
			arrLabel1.Add("Date Completed");
			arrLabel1.Add("Status");
			arrLabel1.Add("Scheduled Instructor");
			arrLabel1.Add("Real Instructor");
			arrLabel1.Add("Instructor Change Reason");
			arrLabel1.Add("Exception Reason");
			arrLabel1.Add("Description");
			arrLabel1.Add("Note");

			//get the event data
			if(eventid[0]>0)
			{
                //SaveAllEvents(eventid[0]);
				LoadEvent(eventid[0], ref arrValue1);

			}
			if(eventid[1]>0)
			{
                //SaveAllEvents(eventid[1]);
				LoadEvent(eventid[1], ref arrValue2);
			}
			if(eventid[2]>0)
			{
                //SaveAllEvents(eventid[2]);
				LoadEvent(eventid[2], ref arrValue3);
			}
			if(eventid[3]>0)
			{
                //SaveAllEvents(eventid[3]);
				LoadEvent(eventid[3], ref arrValue4);
            }
            
            #endregion
            //nm = new NormalPrinting(arrLabel, arrValues, arrLabel1, arrValue1, arrValue2, arrValue3, arrValue4, printDocument1);
            devNormalPrinting = new DevNormalPrinting(arrLabel, arrValues, arrLabel1, arrValue1, arrValue2, arrValue3, arrValue4, printingSystem);
            devNormalPrinting.Label1ForeColor = label1.ForeColor;
            //xtraPrinting = new DevExpressPrinting(arrLabel, arrValues, arrLabel1, arrValue1, arrValue2, arrValue3, arrValue4, printingSystem);

            //classPrinting = new DevExpressClassPrinting(printingSystem,arrLabel, arrValues, arrLabel1, arrValue1, arrValue2, arrValue3, arrValue4);
         //   nm.PageNumber = 1;
			devNormalPrinting.PageNumber = 1;
            //xtraPrinting.PageNumber = 1;
            devNormalPrinting.RowCount = 0;
			//nm.RowCount = 0;
            //xtraPrinting.
           //xtraPrinting.DrawClass
            //classPrinting.label1ForeColor = label1.ForeColor;
            //classPrinting.ShowPreview();
            devNormalPrinting.RTitle = "Class Information";
            devNormalPrinting.PaperKind = PaperKind.A4;
            devNormalPrinting.CreateDocument();
            devNormalPrinting.PrintingSystem.PreviewFormEx.ShowDialog();
           // PrintClassDetails();
            //printingSystem.
            //printingSystem.PreviewFormEx.Show();
            //Helpers.PreviewRibbonForm frm = new Scheduler.Helpers.PreviewRibbonForm();
            //frm.MyPrintingSystem = printingSystem;
            //frm.Show();
            
           // this.printPreviewDialog1.ShowDialog();
			//if (this.printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
			}

		}

        private void PrintClassDetails()
        {
            DevExpress.XtraPrinting.BrickGraphics g = printingSystem.Graph;
            printingSystem.Begin();
            //printingSystem.Graph.
            DrawTopLabel(g);
            bool more = xtraPrinting.DrawDataGrid(g,this);
            if (more == true)
            {
                //printingSystem.Document.p
                //e.HasMorePages = true;
                //nm.PageNumber++;
                 xtraPrinting.PageNumber++;
                //DrawTopLabel(g);
                //more = xtraPrinting.DrawClass(g);
                //CompletePrinting(g);
                //PrintClassDetails();
            }
            //printingSystem

            //printingSystem.start
            printingSystem.End();
        }

        private void CompletePrinting(DevExpress.XtraPrinting.BrickGraphics g)
        {
            DrawTopLabel(g);
            bool more = xtraPrinting.DrawDataGrid(g,this);
            if (more == true)
            {
                //e.HasMorePages = true;
                //nm.PageNumber++;
                //xtraPrinting.PageNumber++;
                //CompletePrinting(g);
                //PrintClassDetails();
            }
        }
		
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{

            Graphics g = e.Graphics;
            DrawTopLabel(g);
            bool more = nm.DrawDataGrid(g);
            if (more == true)
            {
                e.HasMorePages = true;
                nm.PageNumber++;
            }

            //DevExpress.XtraPrinting.BrickGraphics g1 = printingSystem.Graph;
            ////printingSystem.Begin();
            ////printingSystem.Graph.
            //DrawTopLabel(g1);
            //more = xtraPrinting.DrawDataGrid(g1);
            //if (more == true)
            //{
            //    e.HasMorePages = true;
            //    //nm.PageNumber++;
            //    xtraPrinting.PageNumber++;

            //}
            ////printingSystem

            //printingSystem.start
            //printingSystem.End();
		}
        
		private void buttonClear_Click(object sender, EventArgs e)
		{
			if (BusinessLayer.Message.MsgConfirmation("Are you sure you want to return to the original data?") == DialogResult.No)
				return;

			LoadData();

			DoProcessCourseTabChanging(false);

		}

        //TODO: Add 'AllowTest' properties to frmEvent and set them here
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEvent = new frmEventDlg();
            frmEvent.Mode = "Add";
            frmEvent.CourseId = _courseid;
            frmEvent.EventID = eventid[3];
            frmEvent.AllowExtraClasses = IsRecurringSeries;
            frmEvent.AllowTestInitial = !HasTestInitialEvent;
            frmEvent.AllowTestMid = !HasTestMidtermEvent;
            frmEvent.AllowTestFinal = !HasTestFinalEvent;
            
            if (frmEvent.ShowDialog() == DialogResult.OK)
            {
                saved = true;
                LoadData();
                LoadOtherEvents();                                
            }
            frmEvent.Close();
            frmEvent.Dispose();
            frmEvent = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEvent = new frmEventDlg(int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolEventID).ToString()), int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolCaldendarEventID).ToString()));
            frmEvent.Mode = "Edit";
            frmEvent.CourseId = _courseid;
            frmEvent.AllowExtraClasses = IsRecurringSeries;
            //frmEvent.AllowTestInitial = !HasTestInitialEvent;
            //frmEvent.AllowTestMid = !HasTestMidtermEvent;
            //frmEvent.AllowTestFinal = !HasTestFinalEvent;

            if (frmEvent.ShowDialog() == DialogResult.OK)
            {
                saved = true;
                LoadData(); 
                LoadOtherEvents();
            }
            frmEvent.Close();
            frmEvent.Dispose();
            frmEvent = null;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string strMessage = gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolEventType).ToString();
            
            if (Scheduler.BusinessLayer.Message.MsgDelete(strMessage))
            {
                //Delete Event - both from 'Event' and 'CalendarEvent'
                int _eid,_ceid;
                string strEventType;
                bool boolSuccess = false;

                 _ceid = int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolCaldendarEventID).ToString());
                 _eid = int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolEventID).ToString());
                 strEventType = gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolEventType).ToString();
                
                objEvent = new Events();
                objEvent.EventID = _eid;
                objEvent.CalendarEventID = _ceid;
                objEvent.EventType = strEventType;

                if (objEvent.EventType == "Extra Class")
                    boolSuccess = objEvent.DeleteSingleCalendarEvent();
                else
                    boolSuccess = objEvent.DeleteTestEvent("Course",CourseID);

                if (!boolSuccess)
                {
                    Scheduler.BusinessLayer.Message.ShowException("Deleting Event Data.", objEvent.Message);
                    return;
                }

                LoadData();
                LoadOtherEvents();
            }
        }

        private void grdEvents_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
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
                    cmbTeacher2_I.Enabled = true;
                    //cmbExceptionReason_I.Enabled = true;
                    txtChangeReason_I.Enabled = true;
                    
                }
            }
            else
            {
                chkEventModified.Checked = false;
                //if(!chkEventStatus_I.Checked) chkEventStatus_I.Enabled = false;
                cmbTeacher2_I.Enabled = false;
                //cmbExceptionReason_I.Enabled = false;
                txtChangeReason_I.Enabled = false;
            }
        }

        private void chkEventModified_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEventModified.Checked)
                SetEventModificationControls(true);
            else
                SetEventModificationControls(false);
        }
        #endregion

        #region Event Business Logic Handling

        #region RulesHandling
        //Generic method, CalendarID == 0 means we're opening as series

        private void ShowEventDetails(TabPage tbp)
        {
            //load Events if any
            string strHint = "";
            Program objProgram = new Program();
            
			/*if(tbp==tbpInitial)
			{
				llblInitialEvt.Text = objProgram.getEventText(eventid[0].ToString(), "Initial", ref strHint);
			}
			else if(tbp==tbpMidterm)
			{
				llblMidEvt.Text = objProgram.getEventText(eventid[1].ToString(), "Midterm", ref strHint);
			}
			else if(tbp==tbpFinal)
			{
				llblFinalEvt.Text = objProgram.getEventText(eventid[2].ToString(), "Final", ref strHint);
			}
			else*/ if (tbp == tbpClassEvent)
            {
                llblEvent.Text = objProgram.getEventText(eventid[2].ToString(), "Final", ref strHint);
            }
        }

        private bool IsCheckOverlapTime(int _eventid,
            ref string confilictingEvent,
            string instructortype,
            ref string conflictMess)
        {
            bool Ok = false;
            if (_eventid > 0)
            {
                 DateTime dtOS = Convert.ToDateTime(StartDate);
                DateTime dtOE = Convert.ToDateTime(StartDate);

                DateTime dtNS = Convert.ToDateTime(dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text);
                DateTime dtNE = Convert.ToDateTime(dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text);

                if ((dtOS == dtNS) && (dtNE == dtOE))
                {
                    Ok = false;
                    return false;
                }
            }
            string[] arr1;
            if (instructortype == "Scheduled")
                arr1 = cmbTeacher1_I.Text.Split(new char[] { ',' });
            else
                arr1 = cmbTeacher2_I.Text.Split(new char[] { ',' });

            string str1 = "", str2 = "";
            str1 = arr1[0].Trim();
            if (arr1.Length > 1) str2 = arr1[1].Trim();

            if ((str1 == "") && (str2 == "")) return false;
            int intTeacherID = Common.GetTeacherID(
                "Select ContactID From Contact " +
                "Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
                );

            int evtid = Common.CheckOverlapTime(intTeacherID, _eventid, instructortype, ref confilictingEvent,
                dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text,
                dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text);

            if (evtid > 0)
            {
                string sOverlapMess = string.Empty;
                sOverlapMess = Common.GetConflictMess(evtid);

                conflictMess = sOverlapMess;

                return true;
            }
            else return false;

        }

        private bool IsCheckOverlapTime(int _eventid,
            ref string confilictingEvent,
            string instructortype,
            string dt1,
            string dt2,
            ref string conflictMess)
        {
            bool Ok = false;
            string[] arr1;

            if (instructortype == "Scheduled")
                arr1 = cmbTeacher1_I.Text.Split(new char[] { ',' });
            else
                arr1 = cmbTeacher2_I.Text.Split(new char[] { ',' });

            string str1 = "", str2 = "";
            str1 = arr1[0].Trim();
            if (arr1.Length > 1) str2 = arr1[1].Trim();

            if ((str1 == "") && (str2 == "")) return false;
            int intTeacherID = Common.GetTeacherID(
                "Select ContactID From Contact " +
                "Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
                );

            int evtid = Common.CheckOverlapTime(intTeacherID, _eventid, instructortype, ref confilictingEvent,
                dt1,
                dt2);

            if (evtid > 0)
            {
                string sOverlapMess = string.Empty;
                sOverlapMess = Common.GetConflictMess(evtid);

                conflictMess = sOverlapMess;

                return true;
            }
            else return false;

        }

        private void LoadEvent(int _eventid, int CalendarID)
        {
            if (saved)
            {
                saved = false;
                return;
            }
            if (_eventid == 0) return;
            _curreventid = _eventid;
            DataTable dtbl = null;

            objEvent = new Scheduler.BusinessLayer.Events();
            objEvent.EventID = _eventid;

            //pnlTop_I.Visible=false;
            //btn_ClearRecc.Visible=true;

            if (CalendarID > 0) objEvent.CalendarEventID = CalendarID;
            dtbl = objEvent.LoadData();

            if (dtbl.Rows.Count <= 0)
            {
                _eventid = 0;
                CalendarID = 0;
                _calendareventid_Initial = 0;
                _eventid_Initial = 0;
            }

            if (CalendarID != 0)
            {
                //means opening a single occurrence
                pnlTop_I.Visible = true;
                pnlBottom.Visible = false;
                objEvent.CalendarEventID = CalendarID;
                boolSaveSeries_initial = false;
            }
            else
            {
                pnlTop_I.Visible = false;
                pnlBottom.Visible = true;
                //Commented our because the 'Clear Recurrence' button should not be visible for non-repeating class events
                //btn_ClearRecc.Visible = true;
                //boolSaveSeries_initial = true;
            }

            //Adjust Textbox height
            if (pnlBottom.Visible)
                txtNote_I.Height = 130;
            else
                txtNote_I.Height = 150;

            if (dtbl.Rows.Count <= 0)
            {
                InitializeEventForm();
                return;
            }
            string strClient = "", strDept = "", strClass = "", strProgram = "";

            foreach (DataRow dr in dtbl.Rows)
            {
                RepeatRule = dr["RepeatRule"].ToString();
                NegativeException = dr["NegetiveException"].ToString();

                txtName_I.Text = dr["Name"].ToString();
                txtPhonetic_I.Text = dr["NamePhonetic"].ToString();
                txtRomaji_I.Text = dr["NameRomaji"].ToString();

                if (dr["EventType"] != System.DBNull.Value)
                {
                    cmbEventType_I.SelectedIndex = cmbEventType_I.Items.IndexOf(dr["EventType"].ToString());
                    //cmbEventType_I.SelectedIndex = Convert.ToInt16(dr["EventType"].ToString());
                }
                else
                    cmbEventType_I.SelectedIndex = -1;

                txtLocation_I.Text = dr["Location"].ToString();
                cmbBlock_I.Text = dr["BlockCode"].ToString();
                txtRoomNo_I.Text = dr["RoomNumber"].ToString();
                txtDescription_I.Text = dr["Description"].ToString();
                txtNote_I.Text = dr["Note"].ToString();
                if (dr["ExceptionReason"] != System.DBNull.Value)
                    cmbExceptionReason_I.Text = dr["ExceptionReason"].ToString();

                //cmbEventStatus_I.SelectedIndex = Convert.ToInt16(dr["EventStatus"].ToString());
                if (Convert.ToInt16(dr["EventStatus"].ToString()) == 1)
                    chkEventStatus_I.Checked = true;
                else
                    chkEventStatus_I.Checked = false;
                cmbTeacher1_I.Text = dr["ScheduledTeacher"].ToString();
                cmbTeacher2_I.Text = dr["RealTeacher"].ToString();
                txtChangeReason_I.Text = dr["ChangeReason"].ToString();

                if (dr["IsHoliday"] == System.DBNull.Value)
                    chkIsHoliday.Checked = false;
                else
                    chkIsHoliday.Checked = (Convert.ToInt16(dr["IsHoliday"]) > 0);

                XMLData_Initial = dr["RepeatRule"].ToString();

                IsRecurrenceFlag_Initial = 0;
                if (dr["RecurrenceText"] != System.DBNull.Value)
                    if (dr["RecurrenceText"].ToString() != "")
                        IsRecurrenceFlag_Initial = 1;

                if (IsRecurrenceFlag_Initial == 1)
                {
                    //For loading series or one occurrence in a series
                    if (dtblDates == null)
                    {
                        dtblDates = new DataTable();
                        dtblDates.Columns.Add("StartDate", Type.GetType("System.DateTime"));
                        dtblDates.Columns.Add("EndDate", Type.GetType("System.DateTime"));
                    }
                    else
                    {
                        dtblDates.Rows.Clear();
                    }

                    FileInfo fi = new FileInfo(strAppPath);
                    StreamWriter Tex = fi.CreateText();
                    Tex.Write(XMLData_Initial);
                    Tex.Close();
                    Tex = null;

                    if (AP == null) AP = new Serialize();
                    AP = AP.Load(strAppPath);

                    if (AP == null)
                    {
                        dtStart.Value = Convert.ToDateTime(dr["StartDateTime"].ToString());
                        dtEnd.Value = Convert.ToDateTime(dr["EndDateTime"].ToString());

                        cmbStartTime.Text = Convert.ToDateTime(dr["StartDateTime"]).ToString("HH:mm");
                        SetTime(cmbEndTime, Convert.ToDateTime(dr["EndDateTime"]).ToString("HH:mm"));

                        StartTime = cmbStartTime.Text;
                        EndTime = cmbEndTime.Text;
                    }
                    else
                    {
                        try
                        {
                            setToConfig();
                            dtStart.Value = Convert.ToDateTime(_startdate_Initial);
                            dtEnd.Value = Convert.ToDateTime(_enddate_Initial);

                            SetTime(cmbStartTime, Convert.ToDateTime(_startdate_Initial).ToString("HH:mm"));
                            SetTime(cmbEndTime, Convert.ToDateTime(_enddate_Initial).ToString("HH:mm"));

                            StartTime = cmbStartTime.Text;
                            EndTime = cmbEndTime.Text;
                            SeforRecurrence(true);
                        }
                        catch { }
                    }
                }
                else
                {
                    //For single class events that do not repeat.
                    dtStart.Value = Convert.ToDateTime(dr["StartDateTime"].ToString());
                    dtEnd.Value = Convert.ToDateTime(dr["EndDateTime"].ToString());

                    StartTime = dtStart.Value.ToString("HH:mm");
                    EndTime = dtEnd.Value.ToString("HH:mm");
                    try
                    {
                        SetTime(cmbStartTime, Convert.ToDateTime(StartTime).ToString("HH:mm"));
                        SetTime(cmbEndTime, Convert.ToDateTime(EndTime).ToString("HH:mm"));
                    }
                    catch { }
                }

                if ((_eventid > 0) && (boolSaveSeries_initial == false))
                {
                    dtStart.Value = Convert.ToDateTime(dr["StartDateTime"].ToString());
                    dtEnd.Value = Convert.ToDateTime(dr["EndDateTime"].ToString());

                    string StartTime = "";
                    string EndTime = "";
                    StartTime = dtStart.Value.ToString("HH:mm");
                    EndTime = dtEnd.Value.ToString("HH:mm");
                    try
                    {
                        //StartTime
                        StartTime = Convert.ToDateTime(StartTime).ToString("HH:mm");
                        if (StartTime.Substring(0, 1) == "0")
                        {
                            StartTime = StartTime.Substring(1, StartTime.Length - 1);
                        }
                        cmbStartTime.Text = StartTime;
                        SetTime(cmbEndTime, Convert.ToDateTime(EndTime).ToString("HH:mm"));
                    }
                    catch { }
                }

                dtDateComplete_I.Value = Convert.ToDateTime(dr["DateCompleted"].ToString());

                StartDate = dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text;
                EndDate = dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text;

                break;
            }

            if (!chkEventStatus_I.Checked && cmbTeacher2_I.SelectedIndex <= 0 && cmbExceptionReason_I.SelectedIndex <= 0 && cmbExceptionReason_I.Text == "")
                SetEventModificationControls(false);
            else
                SetEventModificationControls(true);
        }

        private void setEventID(int _eventid)
        {
            /*if (pnlEvent.Parent == tbpInitial)
            {
                eventid[0] = _eventid;
            }
            else if (pnlEvent.Parent == tbpMidterm)
            {
                eventid[1] = _eventid;
            }
            else if (pnlEvent.Parent == tbpFinal)
            {
                eventid[2] = _eventid;
            }
            else*/ if (pnlEvent.Parent == tbpClassEvent)
            {
                eventid[3] = _eventid;
            }
        }
        private int GetCurrentEventID(TabPage tbp)
        {
            int _eventid = 0;
            
			/*if(tbp==tbpInitial)
				_eventid=eventid[0];
			else if(tbp==tbpMidterm)
				_eventid=eventid[1];
			else if(tbp==tbpFinal)
				_eventid=eventid[2];
			else*/
            if (tbp == tbpClassEvent)
                _eventid = eventid[3];

            return _eventid;
        }
        private bool IsValid()
        {
            if (txtName_I.Text == "")
            {
                BusinessLayer.Message.MsgInformation("Enter Event Name");
                txtName_I.Focus();
                return false;
            }

            try
            {
                if (cmbStartTime.Text == "")
                {
                    BusinessLayer.Message.MsgInformation("Enter Event Start Time");
                    cmbStartTime.Focus();
                    return false;
                }
                if (cmbEndTime.Text == "")
                {
                    BusinessLayer.Message.MsgInformation("Enter Event End Time");
                    cmbEndTime.Focus();
                    return false;
                }

                string strStart = dtStart.Value.ToShortDateString() + " " + cmbStartTime.Text;
                string strFinish = dtEnd.Value.ToShortDateString() + " " + cmbEndTime.Text;
                dtStart.Value = Convert.ToDateTime(strStart);
                dtEnd.Value = Convert.ToDateTime(strFinish);
            }
            catch { }

            if (!boolNoOfRecords_Initial)
            {
                if (dtEnd.Value < dtStart.Value)
                {
                    BusinessLayer.Message.MsgInformation("Start Date/Time must be before End Date/Time");
                    dtStart.Focus();
                    return false;
                }
            }
            return true;
        }

        //These methods re-generate the series using the Repeat Rules
        private void GenerateEvent(int _eventid, int IsRecur, DateTime date1, DateTime date2)
        {
            DateTime StartDate1 = date1;
            DateTime EndDate1 = date2;

            if (IsRecur > 0)
            {
                if (ReccType == "Daily")
                {
                    if (Pattern1 != "")
                    {
                        GenerateDataForDaily(_eventid, "EveryDay", date1, date2);
                    }
                    else if (Pattern2 != "")
                    {
                        GenerateDataForDaily(_eventid, "EveryWeekDay", date1, date2);
                    }
                }
                else if (ReccType == "Weekly")
                {
                    if (Pattern1 != "")
                    {
                        GenerateDataForWeekly(_eventid, date1, date2);
                    }
                }
                else if (ReccType == "Monthly")
                {
                    if (Pattern1 != "")
                    {
                        GenerateDataForMonthly(_eventid, date1, date2);
                    }
                }
                else if (ReccType == "Yearly")
                {
                    if (Pattern1 != "")
                    {
                        GenerateDataForYearly(_eventid, date1, date2);
                    }
                }
            }
            else
            {
                //No Recurrence....
                SaveCalendarEvent(_eventid, StartDate1, EndDate1);
            }

        }

        #region Event Generation
        private void GenerateDataForDaily(int _eventid, string option, DateTime date1, DateTime date2)
        {
            //dtStart
            //dtEnd
            int NoOfRecords = 0;
            DateTime StartDate1 = Convert.ToDateTime(null);
            StartDate1 = date1;

            if (NoEntries == "")
            {
                TimeSpan ts = date2 - StartDate1;
                NoOfRecords = ts.Days;
                NoOfRecords++;
            }
            else
            {
                NoOfRecords = Convert.ToInt16(NoEntries);
                if (option == "EveryWeekDay")
                {
                    NoOfRecords = NoOfRecords * 7;
                }
            }

            if (option == "EveryDay")
            {
                while (NoOfRecords > 0)
                {
                    SaveCalendarEvent(_eventid, StartDate1, StartDate1);
                    StartDate1 = StartDate1.AddDays(1);
                    NoOfRecords--;
                }
            }
            else if (option == "EveryWeekDay")
            {
                bool boolOk = false;
                while (NoOfRecords > 0)
                {
                    if ((Pattern2 == "Monday") && (StartDate1.DayOfWeek == DayOfWeek.Monday)) boolOk = true;
                    else if ((Pattern2 == "Tuesday") && (StartDate1.DayOfWeek == DayOfWeek.Tuesday)) boolOk = true;
                    else if ((Pattern2 == "Wednesday") && (StartDate1.DayOfWeek == DayOfWeek.Wednesday)) boolOk = true;
                    else if ((Pattern2 == "Thursday") && (StartDate1.DayOfWeek == DayOfWeek.Thursday)) boolOk = true;
                    else if ((Pattern2 == "Friday") && (StartDate1.DayOfWeek == DayOfWeek.Friday)) boolOk = true;
                    else if ((Pattern2 == "Saturday") && (StartDate1.DayOfWeek == DayOfWeek.Saturday)) boolOk = true;
                    else if ((Pattern2 == "Sunday") && (StartDate1.DayOfWeek == DayOfWeek.Sunday)) boolOk = true;

                    if (boolOk)
                    {
                        //MessageBox.Show(StartDate.ToString());
                        SaveCalendarEvent(_eventid, StartDate1, StartDate1);
                    }
                    StartDate1 = StartDate1.AddDays(1);
                    NoOfRecords--;

                    boolOk = false;
                }
            }
        }

        private void GenerateDataForWeekly(int _eventid, DateTime date1, DateTime date2)
        {
            int NoOfRecords = 0;
            DateTime StartDate1 = Convert.ToDateTime(null);
            StartDate1 = date1;

            int WeekNo = 0;
            string WeekDay = "";

            WeekNo = Convert.ToInt16(Pattern1);

            string[] arr = Pattern2.Split(new char[] { '|' });
            int counter = arr.Length - 1;
            WeekDay = Pattern2;

            bool boolEntries = false;
            if (NoEntries == "")
            {
                TimeSpan ts = date2 - StartDate1;
                NoOfRecords = ts.Days;
                NoOfRecords++;
            }
            else
            {
                NoOfRecords = Convert.ToInt16(NoEntries);
                boolEntries = true;
            }

            bool boolOk = false;
            int cnt = 0;
            while (NoOfRecords > 0)
            {
                foreach (string s in arr)
                {
                    if (s != "")
                    {
                        boolOk = false;
                        if ((s == "Monday") && (StartDate1.DayOfWeek == DayOfWeek.Monday)) boolOk = true;
                        else if ((s == "Tuesday") && (StartDate1.DayOfWeek == DayOfWeek.Tuesday)) boolOk = true;
                        else if ((s == "Wednesday") && (StartDate1.DayOfWeek == DayOfWeek.Wednesday)) boolOk = true;
                        else if ((s == "Thursday") && (StartDate1.DayOfWeek == DayOfWeek.Thursday)) boolOk = true;
                        else if ((s == "Friday") && (StartDate1.DayOfWeek == DayOfWeek.Friday)) boolOk = true;
                        else if ((s == "Saturday") && (StartDate1.DayOfWeek == DayOfWeek.Saturday)) boolOk = true;
                        else if ((s == "Sunday") && (StartDate1.DayOfWeek == DayOfWeek.Sunday)) boolOk = true;

                        if (boolOk)
                        {
                            if (cnt < counter)
                            {
                                if (boolOk)
                                {
                                    boolOk = false;
                                }
                                SaveCalendarEvent(_eventid, StartDate1, StartDate1);
                                if (boolEntries) NoOfRecords--;
                            }
                            cnt++;
                        }
                    }
                }
                if (cnt == WeekNo * counter) cnt = 0;
                StartDate1 = StartDate1.AddDays(1);
                if (boolEntries == false) NoOfRecords--;
            }
        }

        private void GenerateDataForMonthly(int _eventid, DateTime date1, DateTime date2)
        {
            int NoOfRecords = 0;
            DateTime StartDate1 = Convert.ToDateTime(null);
            StartDate1 = date1;

            int DayNo = 0;
            int MonthFreqiency = 0;

            DayNo = Convert.ToInt16(Pattern1);
            MonthFreqiency = Convert.ToInt16(Pattern2);

            if (NoEntries == "")
            {
                TimeSpan ts = date2 - StartDate1;
                NoOfRecords = ts.Days;
                NoOfRecords++;
            }
            else
            {
                NoOfRecords = Convert.ToInt16(NoEntries);
                DateTime dtCaclEnd = StartDate1.AddMonths(NoOfRecords);
                TimeSpan ts = new TimeSpan();
                ts = dtCaclEnd.Subtract(StartDate1);
                NoOfRecords = (int)Math.Round(ts.TotalDays, 0);
            }

            bool boolOk = false;
            int cnt = 0;
            while (NoOfRecords > 0)
            {
                if (StartDate1.Day == DayNo) boolOk = true;
                if (boolOk)
                {
                    if (cnt == 0)
                    {
                        //MessageBox.Show(StartDate.ToString());
                        SaveCalendarEvent(_eventid, StartDate1, StartDate1);
                    }
                    cnt++;
                    if (cnt == MonthFreqiency) cnt = 0;
                }
                StartDate1 = StartDate1.AddDays(1);
                NoOfRecords--;

                boolOk = false;
            }
        }

        private void GenerateDataForYearly(int _eventid, DateTime date1, DateTime date2)
        {
            int NoOfRecords = 0;
            DateTime StartDate1 = Convert.ToDateTime(null);
            StartDate1 = date1;

            string Month = "";
            int DayNo = 0;

            Month = Pattern1;
            DayNo = Convert.ToInt16(Pattern2);

            if (NoEntries == "")
            {
                TimeSpan ts = date2 - StartDate1;
                NoOfRecords = ts.Days;
                NoOfRecords++;
            }
            else
            {
                NoOfRecords = Convert.ToInt16(NoEntries);
                NoOfRecords = NoOfRecords * 366;
            }

            int MonthNo = 0;
            bool boolOk = false;

            if (Month == "January") MonthNo = 1;
            else if (Month == "February") MonthNo = 2;
            else if (Month == "March") MonthNo = 3;
            else if (Month == "April") MonthNo = 4;
            else if (Month == "May") MonthNo = 5;
            else if (Month == "June") MonthNo = 6;
            else if (Month == "July") MonthNo = 7;
            else if (Month == "August") MonthNo = 8;
            else if (Month == "September") MonthNo = 9;
            else if (Month == "October") MonthNo = 10;
            else if (Month == "November") MonthNo = 11;
            else if (Month == "December") MonthNo = 12;

            while (NoOfRecords > 0)
            {
                if ((StartDate1.Day == DayNo) && (StartDate1.Month == MonthNo)) boolOk = true;
                if (boolOk)
                {
                    //MessageBox.Show(StartDate.ToString());
                    SaveCalendarEvent(_eventid, StartDate1, StartDate1);
                }
                StartDate1 = StartDate1.AddDays(1);
                NoOfRecords--;

                boolOk = false;
            }
        }
        #endregion
        #endregion

        #region Class Events
        private void SaveEventData(ref int _eventid)
        {
            bool boolSuccess;
            objEvent = null;

            if (File.Exists(strAppPath))
            {
                StreamReader re = File.OpenText(strAppPath);
                XMLData_Initial = re.ReadToEnd();
                re.Close();
                re = null;
            }
            else
            {
                XMLData_Initial = "";
                IsRecurrenceFlag_Initial = 0;
            }

            objEvent = new Scheduler.BusinessLayer.Events();
            objEvent.EventID = 0;
            objEvent.RepeatRule = XMLData_Initial;
            objEvent.NegativeException = "";
            objEvent.Description = txtDescription_I.Text;
            
            //if (cmbEventStatus_I.SelectedIndex == -1)
            //    cmbEventStatus_I.SelectedIndex = 0;
            if (chkEventStatus_I.Checked)
                objEvent.EventStatus = 1;
            else
                objEvent.EventStatus = 0;
            //objEvent.EventStatus = cmbEventStatus_I.SelectedIndex;

            if (IsRecurrenceFlag_Initial > 0)
                objEvent.RecurrenceText = lblRecurrenceText_I.Text;
            else
                objEvent.RecurrenceText = "";

            if (_eventid <= 0)
            {
                if (objEvent.Exists())
                {
                    Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Course Name not allowed");
                    txtName_I.Focus();
                    return;
                }
                boolSuccess = objEvent.InsertData();
                _eventid_Initial = objEvent.EventID;
                _eventid = objEvent.EventID;
                setEventID(objEvent.EventID);
            }
            else
            {
                objEvent.EventID = _eventid;
                boolSuccess = objEvent.UpdateData();
            }
            if (!boolSuccess)
            {
                if (_eventid == 0)
                    Scheduler.BusinessLayer.Message.ShowException("Inserting Event record.", objEvent.Message);
                else
                    Scheduler.BusinessLayer.Message.ShowException("Updating Event record.", objEvent.Message);
                return;
            }
        }
        #endregion

        #region Other Events
        private bool SaveCalendarEvent(int _eventid, DateTime mStart, DateTime mEnd)
        {
            if (!AutoSave)
            {
                if (dtblDates != null)
                {
                    dtblDates.Rows.Add(new object[] { mStart, mEnd });
                }
                return true;
            }

            bool boolSuccess = false;
            string StartTime = "";
            string EndTime = "";
            int startlength = 8;
            int endlength = 8;

            if (objEvent == null) objEvent = new Scheduler.BusinessLayer.Events();
            objEvent.EventID = _eventid;
            objEvent.Name = txtName_I.Text;
            objEvent.NamePhonetic = txtPhonetic_I.Text;
            objEvent.NameRomaji = txtRomaji_I.Text;

            string[] arr1 = cmbTeacher1_I.Text.Split(new char[] { ',' });
            string[] arr2 = cmbTeacher1_I.Text.Split(new char[] { ',' });

            string str1 = "", str2 = "";
            str1 = arr1[0].Trim();
            if (arr1.Length > 1) str2 = arr1[1].Trim();

            objEvent.SchedulerTeacherID = Common.GetTeacherID(
                "Select ContactID From Contact " +
                "Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
                );

            str1 = "";
            str2 = "";
            arr1 = cmbTeacher2_I.Text.Split(new char[] { ',' });
            arr2 = cmbTeacher2_I.Text.Split(new char[] { ',' });
            str1 = arr2[0].Trim();
            if (arr2.Length > 1) str2 = arr2[1].Trim();

            objEvent.RealTeacherID = Common.GetTeacherID(
                "Select ContactID From Contact " +
                "Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
                );

            //objEvent.EventType = cmbEventType_I.SelectedIndex;
            objEvent.EventType = cmbEventType_I.Text;
            objEvent.Location = txtLocation_I.Text;
            objEvent.BlockCode = cmbBlock_I.Text;
            objEvent.RoomNo = txtRoomNo_I.Text;
            objEvent.ChangeReason = txtChangeReason_I.Text;

            try
            {
                startlength = cmbStartTime.Text.Length;
                endlength = cmbEndTime.Text.Length;

                StartTime = mStart.ToShortDateString() + " " + cmbStartTime.Text.Trim();
                EndTime = mEnd.ToShortDateString() + " " + cmbEndTime.Text.Trim();

                mStart = Convert.ToDateTime(StartTime);
                mEnd = Convert.ToDateTime(EndTime);
            }
            catch { }
            objEvent.StartDate = mStart;
            objEvent.EndDate = mEnd;
            objEvent.DateCompleted = dtDateComplete_I.Value;

            if (chkIsHoliday.Checked)
                objEvent.IsHoliday = 1;
            else
                objEvent.IsHoliday = 0;

            objEvent.Description = txtDescription_I.Text;
            objEvent.Notes = txtNote_I.Text;
            objEvent.ExceptionReason = cmbExceptionReason_I.Text;
            if (chkEventStatus_I.Checked)
            {
                objEvent.EventStatus = 1;
                objEvent.CalendarEventStatus = 1;
            }
            else
            {
                objEvent.EventStatus = 0;
                objEvent.CalendarEventStatus = 0;
            }
            //objEvent.EventStatus = cmbEventStatus_I.SelectedIndex;
            //objEvent.CalendarEventStatus = cmbEventStatus_I.SelectedIndex;

            boolSuccess = objEvent.InsertCalendarEventData();
            if (!boolSuccess)
            {
                if (_mode == "Add" || _mode == "AddClone")
                    Scheduler.BusinessLayer.Message.ShowException("Inserting Calendar Event record.", objEvent.Message);
                else
                    Scheduler.BusinessLayer.Message.ShowException("Updating Calendar Event record.", objEvent.Message);
            }

            return boolSuccess;
        }

        private bool SaveCalendarData(int _eventid, int _calid, DateTime mStart, DateTime mEnd)
        {
            bool boolSuccess = false;
            string StartTime = "";
            string EndTime = "";
            int startlength = 8;
            int endlength = 8;

            if (objEvent == null) objEvent = new Scheduler.BusinessLayer.Events();
            objEvent.EventID = _eventid;
            objEvent.Name = txtName_I.Text;
            objEvent.NamePhonetic = txtPhonetic_I.Text;
            objEvent.NameRomaji = txtRomaji_I.Text;
            objEvent.CalendarEventID = _calid;


            string[] arr1 = cmbTeacher1_I.Text.Split(new char[] { ',' });
            string[] arr2 = cmbTeacher1_I.Text.Split(new char[] { ',' });

            string str1 = "", str2 = "";
            str1 = arr1[0].Trim();
            if (arr1.Length > 1) str2 = arr1[1].Trim();

            objEvent.SchedulerTeacherID = Common.GetTeacherID(
                "Select ContactID From Contact " +
                "Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
                );

            str1 = "";
            str2 = "";
            arr1 = cmbTeacher2_I.Text.Split(new char[] { ',' });
            arr2 = cmbTeacher2_I.Text.Split(new char[] { ',' });
            str1 = arr2[0].Trim();
            if (arr2.Length > 1) str2 = arr2[1].Trim();

            objEvent.RealTeacherID = Common.GetTeacherID(
                "Select ContactID From Contact " +
                "Where FirstName =@FirstName and LastName = @LastName and ContactType=1 ", str2, str1
                );

            objEvent.ChangeReason = txtChangeReason_I.Text;
            //objEvent.EventType = cmbEventType_I.SelectedIndex;
            objEvent.EventType = cmbEventType_I.Text;
            objEvent.Location = txtLocation_I.Text;
            objEvent.BlockCode = cmbBlock_I.Text;
            objEvent.RoomNo = txtRoomNo_I.Text;

            try
            {
                startlength = cmbStartTime.Text.Length;
                endlength = cmbEndTime.Text.Length;

                StartTime = mStart.ToShortDateString() + " " + cmbStartTime.Text.Trim();
                EndTime = mEnd.ToShortDateString() + " " + cmbEndTime.Text.Trim();

                mStart = Convert.ToDateTime(StartTime);
                mEnd = Convert.ToDateTime(EndTime);
            }
            catch { }
            objEvent.StartDate = mStart;
            objEvent.EndDate = mEnd;
            objEvent.DateCompleted = dtDateComplete_I.Value;

            if (chkIsHoliday.Checked)
                objEvent.IsHoliday = 1;
            else
                objEvent.IsHoliday = 0;

            objEvent.Description = txtDescription_I.Text;
            objEvent.Notes = txtNote_I.Text;
            objEvent.ExceptionReason = cmbExceptionReason_I.Text;

            if (chkEventStatus_I.Checked)
                objEvent.CalendarEventStatus = 1;
            else
                objEvent.CalendarEventStatus = 0;
            //objEvent.CalendarEventStatus = cmbEventStatus_I.SelectedIndex;

            boolSuccess = objEvent.UpdateCalendarEventData();
            if (!boolSuccess)
            {
                Scheduler.BusinessLayer.Message.ShowException("Updating Calendar Event record.", objEvent.Message);
            }

            return boolSuccess;
        }
        #endregion

        private bool doSaveEvents(int _eventid)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (SaveAllEvents(_eventid))
                {
                    IsEventChanged = false;

                    ShowEventDetails((TabPage)pnlEvent.Parent);
                    if (pnlEvent.Parent == tbpClassEvent)
                    {
                        eventid[3] = _eventid_Initial;
                        calendareventid[3] = _calendareventid_Initial;
                    }
					/*else if(pnlEvent.Parent==tbpInitial)
					{
						eventid[0] = _eventid_Initial;
						calendareventid[0] = _calendareventid_Initial;
					}
					else if(pnlEvent.Parent==tbpMidterm)
					{
						eventid[1] = _eventid_Initial;
						calendareventid[1] = _calendareventid_Initial;
					}
					else if(pnlEvent.Parent==tbpFinal)
					{
						eventid[2] = _eventid_Initial;
						calendareventid[2] = _calendareventid_Initial;
					}*/

                    _eventid_Initial = 0;
                    _calendareventid_Initial = 0;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void btnEventSave_Click(object sender, System.EventArgs e)
        {

            //IsEventChanged=true;
            if (IsEventChanged == false) return;
            doSaveEvents(GetCurrentEventID(tbcCourse.SelectedTab));

        }

        private bool SaveAllEvents(int _eventid)
        {
            string sConflictingEvent = "";
            if (!IsValid()) return false;

            //check real teacher first
            string strOverLapMess = "";

            //=============================
            /*if(cmbClient.Text!="")
            {
                strOverLapMess = "-<" + cmbClient.Text + ">";
                if(txtCourseName.Text!="")
                {
                    strOverLapMess += "<" + txtCourseName.Text + ">";
                }
            }
            strOverLapMess = strOverLapMess.Trim();*/

            AutoSave = false;
            GenerateEvent(_eventid, IsRecurrenceFlag_Initial, dtStart.Value, dtEnd.Value);
            AutoSave = true;

            if (cmbTeacher2_I.Text.Trim() != "")
            {
                bool Ok = false;
                if (dtblDates == null)
                {
                    Ok = IsCheckOverlapTime(_eventid, ref sConflictingEvent, "Real", ref strOverLapMess);
                }
                else
                {
                    foreach (DataRow dr in dtblDates.Rows)
                    {
                        Ok = IsCheckOverlapTime(_eventid, ref sConflictingEvent, "Real", dr[0].ToString(), dr[1].ToString(), ref strOverLapMess);
                        if (Ok) break;
                    }
                }
                if (Ok)
                {
                    DialogResult dlg =
                        BusinessLayer.Message.MsgConfirmation(
                        "<" + cmbTeacher2_I.Text + "> is already scheduled in <" +
                        sConflictingEvent + ">" + strOverLapMess +
                        "\nDo you still wish to save this event?");
                    if (dlg == DialogResult.No)
                    {
                        //if(File.Exists(strAppPath))
                        //{
                        //	File.Delete(strAppPath);
                        //}
                        IsEventChanged = false;
                        return false;
                    }
                }
            }
            else
            {
                //if real instructor blank check scheduled teacher
                bool Ok = false;
                if (dtblDates == null)
                {
                    Ok = IsCheckOverlapTime(_eventid, ref sConflictingEvent, "Scheduled", ref strOverLapMess);
                }
                else
                {
                    foreach (DataRow dr in dtblDates.Rows)
                    {
                        Ok = IsCheckOverlapTime(_eventid, ref sConflictingEvent, "Scheduled", dr[0].ToString(), dr[1].ToString(), ref strOverLapMess);
                        if (Ok) break;
                    }
                }
                if (Ok)
                {
                    DialogResult dlg =
                        BusinessLayer.Message.MsgConfirmation(
                        "<" + cmbTeacher1_I.Text + "> is already scheduled in <" +
                        sConflictingEvent + ">" + strOverLapMess +
                        "\nDo you still wish to save this event?");
                    if (dlg == DialogResult.No)
                    {
                        //if(File.Exists(strAppPath))
                        //{
                        //	File.Delete(strAppPath);
                        //}
                        IsEventChanged = false;
                        return false;
                    }
                }
            }

            //=============================

            if (boolSaveSeries_initial)
            {
                SaveEventData(ref _eventid);
                objEvent.DeleteCalendarEvent();
                GenerateEvent(_eventid, IsRecurrenceFlag_Initial, dtStart.Value, dtEnd.Value);
            }
            else
            {
                int _calid = 0;
                /*
				if(tbcCourse.SelectedTab==tbpInitial)
					_calid = calendareventid[0];
				else if(tbcCourse.SelectedTab==tbpMidterm)
					_calid = calendareventid[1];
				else if(tbcCourse.SelectedTab==tbpFinal)
					_calid = calendareventid[2];
                */
                if (tbcCourse.SelectedTab == tbpClassEvent)
                    _calid = calendareventid[3];

                SaveCalendarData(_eventid, _calid, dtStart.Value, dtEnd.Value);
            }

            _eventid_Initial = _eventid;
            return true;
        }
        #endregion

        private void printingSystem_AfterPagePrint(object sender, DevExpress.XtraPrinting.PageEventArgs e)
        {

            //MessageBox.Show("After PAge PRint");
            //PrintClassDetails();
        }

        private void printingSystem_StartPrint(object sender, DevExpress.XtraPrinting.PrintDocumentEventArgs e)
        {
            MessageBox.Show("Start Print");
            //DevExpress.XtraPrinting.BrickGraphics g = printingSystem.Graph;
            //DrawTopLabel(g);
            //bool more = xtraPrinting.DrawDataGrid(g);
            //if (more == true)
            //{
            //    //e.HasMorePages = true;
            //    //nm.PageNumber++;
            //    //xtraPrinting.PageNumber = e.PrintDocument. + 1;

            //}   
        }

        private void printingSystem_BeforePagePaint(object sender, DevExpress.XtraPrinting.PageEventArgs e)
        {
            
        }

        private void chkEventStatus_I_CheckedChanged(object sender, EventArgs e)
        {
            IsEventChanged = true;
            if (GetCurrentEventID((TabPage)pnlEvent.Parent) > 0)
            {
                cmbEventType_I_SelectedIndexChanged(sender, null);
            }
            if (chkEventStatus_I.Checked)
            {
                Common.MakeReadOnly(pnlBody_I, false);
                chkEventStatus_I.Enabled = true;
                cmbExceptionReason_I.Enabled = true;
            }
            else
            {
                Common.MakeEnabled(pnlBody_I, false);
                cmbTeacher2_I.Enabled = chkEventModified.Checked;
                txtChangeReason_I.Enabled = chkEventModified.Checked;
                //cmbExceptionReason_I.Enabled = false;
            }
        }

        private void cmbEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsEventChanged = true;
        }

        private void printingSystem_AfterPagePaint(object sender, DevExpress.XtraPrinting.PageEventArgs e)
        {
            //DevExpress.XtraPrinting.BrickGraphics g1 = printingSystem.Graph;
            ////printingSystem.Begin();
            ////printingSystem.Graph.
            //bool more;
            //DrawTopLabel(g1);
            //more = xtraPrinting.DrawDataGrid(g1,this);
            //if (more == true)
            //{
            //    e.Page.Printed = true;
            //    //nm.PageNumber++;
            //    xtraPrinting.PageNumber++;

            //}
        }

        private void llblInitialEvt_TextChanged(object sender, EventArgs e)
        {
            if (llblInitialEvt.Text.Equals("None"))
            {
                txtInitialForm.Enabled = false;
            }
            else
                txtInitialForm.Enabled = true;
        }

        private void llblMidEvt_TextChanged(object sender, EventArgs e)
        {
            if (llblMidEvt.Text.Equals("None"))
            {
                txtMidtermForm.Enabled = false;
            }
            else
                txtMidtermForm.Enabled = true;
        }

        private void llblFinalEvt_TextChanged(object sender, EventArgs e)
        {
            if (llblFinalEvt.Text.Equals("None"))
            {
                txtFinalForm.Enabled = false;
            }
            else
                txtFinalForm.Enabled = true;
        }

    }
}