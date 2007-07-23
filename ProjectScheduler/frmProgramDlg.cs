using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Scheduler.BusinessLayer;
using Message=System.Windows.Forms.Message;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmProgramDlg.
	/// </summary>
	/// 
	public enum EventType
	{
		Initial = 1,
		MidTerm = 2,
		Final = 3,
        Extra = 4
	}

	public class frmProgramDlg : Form
	{
		#region Controls 
		private Button btnCancel;
		private Button btnSave;
		private TabControl tbcCourse;
		private TabPage tbpCourse;
		private Label label8;
		private Label label9;
		private Label label10;
		private Label label1;
		private ComboBox cmbDept;
		private Label lblPassword;
		private Label lblStatus;
		private Label lblUser;
		private ComboBox cmbStatus;
		private TabPage tbpDescription;
		private TextBox txtDescription;
		private TabPage tbpSpecialRemarks;
		private TextBox txtRemarks;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label11;
		private TextBox txtFinalEvent;
		private TextBox txtMidtermEvent;
		private TextBox txtInitialEvent;
		private TextBox txtNameRomaji;
		private TextBox txtNamePhonetic;
		private TextBox txtProgramName;
		private TextBox txtMidtermForm;
		private TextBox txtQuestionaireFinalForm;
		private TextBox txtQuestionaireMidtermForm;
		private TextBox txtEvaluationFinalForm;
		private TextBox txtEvaluationMidtermForm;
		private TextBox txtFinalForm;
		private GroupBox grpTest;
		private Label label12;
		private Label label13;
		private GroupBox groupBox1;
		private LinkLabel llbDepartment;
		private Label label5;
		private GroupBox groupBox2;
		private LinkLabel llblFinalEvt;
		private LinkLabel llblMidEvt;
        private LinkLabel llblInitialEvt;
        private IContainer components;
		private Label label7;
		private Label label6;
		private Label label14;
		private Button btnDelete;
		private Label lblContact2;
		private Label lblContact1;
		private ComboBox cmbContact1;
		private ComboBox cmbContact2;
		private LinkLabel llblClient;
		private ComboBox cmbClient;
		private TextBox txtNickName;
		private Label lblNickName;
		private Label label15;
		private RadioButton rbtnNone;
		private RadioButton rbtnWeekly;
		private RadioButton rbtnMonthly;
		private RadioButton rbtnEnd;
		private CheckBox chkEF;
		private CheckBox chkEM;
		private CheckBox chkQM;
		private CheckBox chkQF;
        private TextBox txtInitialForm;

		private Button btnPageSetup;
		private Button btnPrint;
		private PrintDocument printDocument1;
		private PrintPreviewDialog printPreviewDialog1;
        private DataTable dtblDates = null;

		#endregion Controls

		private bool deleted = false;
		private int intClientID = 0;
		private int intDepartmentID = 0;
		private int intContact1ID = 0;
		private int intContact2ID = 0;

		//Events newly added
		private Events objEvent = null;
		//private string NoEntries = "";
		private string Pattern1 = "";
		private string Pattern2 = "";
        private int[] eventid = new int[3];
        private bool HasTestInitialEvent = false;
        private bool HasTestMidtermEvent = false;
        private bool HasTestFinalEvent = false;

        private TabPage tbpTestEvents;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDel;
        private Button buttonClear;
        public DevExpress.XtraGrid.GridControl grdEvents;
        public DevExpress.XtraGrid.Views.Grid.GridView gvwEvents;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCaldendarEventID;
        public DevExpress.XtraGrid.Columns.GridColumn gcolEventID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEventType;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStartDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEndDateTime;
        private frmEventDlg frmEvent;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private PageSettings ps = null;

		public frmProgramDlg()
		{
			InitializeComponent();

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				           "WHEN NickName IS NULL THEN [CompanyName] " +
				           "WHEN NickName = '' THEN [CompanyName] " +
				           "ELSE NickName " +
				           "END From " +
				           "Contact Where ContactType=2 and " +
				           "ContactStatus=0 Order By CompanyName");
            /*
			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By LastName, FirstName ");

			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By ContactID");
            */
		}

		public frmProgramDlg(int id)
		{
			InitializeComponent();
			_programid = id;

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				           "WHEN NickName IS NULL THEN [CompanyName] " +
				           "WHEN NickName = '' THEN [CompanyName] " +
				           "ELSE NickName " +
				           "END From " +
				           "Contact Where ContactType=2 and " +
				           "ContactStatus=0 Order By CompanyName");
            /*
			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By LastName, FirstName ");

			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By ContactID");
             */
		}

		public frmProgramDlg(int id, int eventindex)
		{
			InitializeComponent();
			//tbpInitial.Controls.Remove(pnlEvent);

			_programid = id;
			_mode = "Edit";

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				           "WHEN NickName IS NULL THEN [CompanyName] " +
				           "WHEN NickName = '' THEN [CompanyName] " +
				           "ELSE NickName " +
				           "END From " +
				           "Contact Where ContactType=2 and " +
				           "ContactStatus=0 Order By CompanyName");

            /*
			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By LastName, FirstName ");

			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By ContactID");
            */
			LoadData();


            switch (eventindex)
            {
                default:
                case 0:
                case 1:
                case 2:
                    tbcCourse.SelectedTab = tbpTestEvents; break;
            }

            tbcCourse_SelectedIndexChanged(tbcCourse, new EventArgs());
            
		}

		public frmProgramDlg(int id, int eventindex, int CalID)
		{
			InitializeComponent();
			//tbpInitial.Controls.Remove(pnlEvent);

			_programid = id;
			_mode = "Edit";

			Common.PopulateDropdown(
				cmbClient, "Select CompanyName = CASE " +
				           "WHEN NickName IS NULL THEN [CompanyName] " +
				           "WHEN NickName = '' THEN [CompanyName] " +
				           "ELSE NickName " +
				           "END From " +
				           "Contact Where ContactType=2 and " +
				           "ContactStatus=0 Order By CompanyName");
            /*
			Common.PopulateDropdown(
				cmbTeacher1_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By LastName, FirstName ");

			Common.PopulateDropdown(
				cmbTeacher2_I, "Select " +
				               "TeacherName = CASE " +
				               "WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				               "WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				               "ELSE NickName " +
				               "END From " +
				               "Contact Where ContactType=1 and " +
				               "ContactStatus=0 Order By ContactID");

			calendareventid[eventindex] = CalID;
            */
			LoadData();

            switch (eventindex)
            {
                default:
                case 0:
                case 1:
                case 2:
                    tbcCourse.SelectedTab = tbpTestEvents; break;
            }
            tbcCourse_SelectedIndexChanged(tbcCourse, new EventArgs());
            
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgramDlg));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbcCourse = new System.Windows.Forms.TabControl();
            this.tbpCourse = new System.Windows.Forms.TabPage();
            this.txtInitialForm = new System.Windows.Forms.TextBox();
            this.chkQF = new System.Windows.Forms.CheckBox();
            this.chkQM = new System.Windows.Forms.CheckBox();
            this.chkEM = new System.Windows.Forms.CheckBox();
            this.chkEF = new System.Windows.Forms.CheckBox();
            this.rbtnEnd = new System.Windows.Forms.RadioButton();
            this.rbtnMonthly = new System.Windows.Forms.RadioButton();
            this.rbtnWeekly = new System.Windows.Forms.RadioButton();
            this.rbtnNone = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.lblNickName = new System.Windows.Forms.Label();
            this.lblContact2 = new System.Windows.Forms.Label();
            this.lblContact1 = new System.Windows.Forms.Label();
            this.cmbContact2 = new System.Windows.Forms.ComboBox();
            this.cmbContact1 = new System.Windows.Forms.ComboBox();
            this.llblClient = new System.Windows.Forms.LinkLabel();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.llblFinalEvt = new System.Windows.Forms.LinkLabel();
            this.llblMidEvt = new System.Windows.Forms.LinkLabel();
            this.llblInitialEvt = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.llbDepartment = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.txtQuestionaireFinalForm = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQuestionaireMidtermForm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEvaluationFinalForm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEvaluationMidtermForm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinalForm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMidtermForm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFinalEvent = new System.Windows.Forms.TextBox();
            this.txtMidtermEvent = new System.Windows.Forms.TextBox();
            this.txtInitialEvent = new System.Windows.Forms.TextBox();
            this.txtNameRomaji = new System.Windows.Forms.TextBox();
            this.txtNamePhonetic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtProgramName = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tbpDescription = new System.Windows.Forms.TabPage();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tbpSpecialRemarks = new System.Windows.Forms.TabPage();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tbpTestEvents = new System.Windows.Forms.TabPage();
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.buttonClear = new System.Windows.Forms.Button();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.tbcCourse.SuspendLayout();
            this.tbpCourse.SuspendLayout();
            this.tbpDescription.SuspendLayout();
            this.tbpSpecialRemarks.SuspendLayout();
            this.tbpTestEvents.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(600, 606);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(517, 606);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbcCourse
            // 
            this.tbcCourse.Controls.Add(this.tbpCourse);
            this.tbcCourse.Controls.Add(this.tbpDescription);
            this.tbcCourse.Controls.Add(this.tbpSpecialRemarks);
            this.tbcCourse.Controls.Add(this.tbpTestEvents);
            this.tbcCourse.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbcCourse.Location = new System.Drawing.Point(0, 0);
            this.tbcCourse.Multiline = true;
            this.tbcCourse.Name = "tbcCourse";
            this.tbcCourse.SelectedIndex = 0;
            this.tbcCourse.ShowToolTips = true;
            this.tbcCourse.Size = new System.Drawing.Size(770, 592);
            this.tbcCourse.TabIndex = 0;
            this.tbcCourse.SelectedIndexChanged += new System.EventHandler(this.tbcCourse_SelectedIndexChanged);
            // 
            // tbpCourse
            // 
            this.tbpCourse.Controls.Add(this.txtInitialForm);
            this.tbpCourse.Controls.Add(this.chkQF);
            this.tbpCourse.Controls.Add(this.chkQM);
            this.tbpCourse.Controls.Add(this.chkEM);
            this.tbpCourse.Controls.Add(this.chkEF);
            this.tbpCourse.Controls.Add(this.rbtnEnd);
            this.tbpCourse.Controls.Add(this.rbtnMonthly);
            this.tbpCourse.Controls.Add(this.rbtnWeekly);
            this.tbpCourse.Controls.Add(this.rbtnNone);
            this.tbpCourse.Controls.Add(this.label15);
            this.tbpCourse.Controls.Add(this.txtNickName);
            this.tbpCourse.Controls.Add(this.lblNickName);
            this.tbpCourse.Controls.Add(this.lblContact2);
            this.tbpCourse.Controls.Add(this.lblContact1);
            this.tbpCourse.Controls.Add(this.cmbContact2);
            this.tbpCourse.Controls.Add(this.cmbContact1);
            this.tbpCourse.Controls.Add(this.llblClient);
            this.tbpCourse.Controls.Add(this.cmbClient);
            this.tbpCourse.Controls.Add(this.label7);
            this.tbpCourse.Controls.Add(this.label6);
            this.tbpCourse.Controls.Add(this.label14);
            this.tbpCourse.Controls.Add(this.llblFinalEvt);
            this.tbpCourse.Controls.Add(this.llblMidEvt);
            this.tbpCourse.Controls.Add(this.llblInitialEvt);
            this.tbpCourse.Controls.Add(this.label5);
            this.tbpCourse.Controls.Add(this.groupBox2);
            this.tbpCourse.Controls.Add(this.llbDepartment);
            this.tbpCourse.Controls.Add(this.label13);
            this.tbpCourse.Controls.Add(this.groupBox1);
            this.tbpCourse.Controls.Add(this.label12);
            this.tbpCourse.Controls.Add(this.grpTest);
            this.tbpCourse.Controls.Add(this.txtQuestionaireFinalForm);
            this.tbpCourse.Controls.Add(this.label11);
            this.tbpCourse.Controls.Add(this.txtQuestionaireMidtermForm);
            this.tbpCourse.Controls.Add(this.label2);
            this.tbpCourse.Controls.Add(this.txtEvaluationFinalForm);
            this.tbpCourse.Controls.Add(this.label3);
            this.tbpCourse.Controls.Add(this.txtEvaluationMidtermForm);
            this.tbpCourse.Controls.Add(this.label4);
            this.tbpCourse.Controls.Add(this.txtFinalForm);
            this.tbpCourse.Controls.Add(this.label8);
            this.tbpCourse.Controls.Add(this.txtMidtermForm);
            this.tbpCourse.Controls.Add(this.label9);
            this.tbpCourse.Controls.Add(this.label10);
            this.tbpCourse.Controls.Add(this.txtFinalEvent);
            this.tbpCourse.Controls.Add(this.txtMidtermEvent);
            this.tbpCourse.Controls.Add(this.txtInitialEvent);
            this.tbpCourse.Controls.Add(this.txtNameRomaji);
            this.tbpCourse.Controls.Add(this.txtNamePhonetic);
            this.tbpCourse.Controls.Add(this.label1);
            this.tbpCourse.Controls.Add(this.cmbDept);
            this.tbpCourse.Controls.Add(this.lblPassword);
            this.tbpCourse.Controls.Add(this.txtProgramName);
            this.tbpCourse.Controls.Add(this.lblStatus);
            this.tbpCourse.Controls.Add(this.lblUser);
            this.tbpCourse.Controls.Add(this.cmbStatus);
            this.tbpCourse.Location = new System.Drawing.Point(4, 22);
            this.tbpCourse.Name = "tbpCourse";
            this.tbpCourse.Size = new System.Drawing.Size(762, 566);
            this.tbpCourse.TabIndex = 0;
            this.tbpCourse.Text = "Program";
            this.tbpCourse.UseVisualStyleBackColor = true;
            // 
            // txtInitialForm
            // 
            this.txtInitialForm.Location = new System.Drawing.Point(216, 291);
            this.txtInitialForm.MaxLength = 50;
            this.txtInitialForm.Name = "txtInitialForm";
            this.txtInitialForm.Size = new System.Drawing.Size(320, 21);
            this.txtInitialForm.TabIndex = 10;
            // 
            // chkQF
            // 
            this.chkQF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkQF.Location = new System.Drawing.Point(216, 544);
            this.chkQF.Name = "chkQF";
            this.chkQF.Size = new System.Drawing.Size(16, 16);
            this.chkQF.TabIndex = 25;
            this.chkQF.CheckedChanged += new System.EventHandler(this.chkQF_CheckedChanged);
            // 
            // chkQM
            // 
            this.chkQM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkQM.Location = new System.Drawing.Point(216, 520);
            this.chkQM.Name = "chkQM";
            this.chkQM.Size = new System.Drawing.Size(16, 16);
            this.chkQM.TabIndex = 23;
            this.chkQM.CheckedChanged += new System.EventHandler(this.chkQM_CheckedChanged);
            // 
            // chkEM
            // 
            this.chkEM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEM.Location = new System.Drawing.Point(216, 472);
            this.chkEM.Name = "chkEM";
            this.chkEM.Size = new System.Drawing.Size(16, 16);
            this.chkEM.TabIndex = 19;
            this.chkEM.CheckedChanged += new System.EventHandler(this.chkEM_CheckedChanged);
            // 
            // chkEF
            // 
            this.chkEF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEF.Location = new System.Drawing.Point(216, 496);
            this.chkEF.Name = "chkEF";
            this.chkEF.Size = new System.Drawing.Size(16, 16);
            this.chkEF.TabIndex = 21;
            this.chkEF.CheckedChanged += new System.EventHandler(this.chkEF_CheckedChanged);
            // 
            // rbtnEnd
            // 
            this.rbtnEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtnEnd.Location = new System.Drawing.Point(481, 448);
            this.rbtnEnd.Name = "rbtnEnd";
            this.rbtnEnd.Size = new System.Drawing.Size(53, 16);
            this.rbtnEnd.TabIndex = 18;
            this.rbtnEnd.Text = "End";
            // 
            // rbtnMonthly
            // 
            this.rbtnMonthly.Checked = true;
            this.rbtnMonthly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtnMonthly.Location = new System.Drawing.Point(389, 448);
            this.rbtnMonthly.Name = "rbtnMonthly";
            this.rbtnMonthly.Size = new System.Drawing.Size(64, 16);
            this.rbtnMonthly.TabIndex = 17;
            this.rbtnMonthly.TabStop = true;
            this.rbtnMonthly.Text = "Monthly";
            // 
            // rbtnWeekly
            // 
            this.rbtnWeekly.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtnWeekly.Location = new System.Drawing.Point(297, 448);
            this.rbtnWeekly.Name = "rbtnWeekly";
            this.rbtnWeekly.Size = new System.Drawing.Size(64, 16);
            this.rbtnWeekly.TabIndex = 16;
            this.rbtnWeekly.Text = "Weekly";
            // 
            // rbtnNone
            // 
            this.rbtnNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtnNone.Location = new System.Drawing.Point(216, 448);
            this.rbtnNone.Name = "rbtnNone";
            this.rbtnNone.Size = new System.Drawing.Size(53, 16);
            this.rbtnNone.TabIndex = 15;
            this.rbtnNone.Text = "None";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(48, 448);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 341;
            this.label15.Text = "Report Attendance";
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(216, 96);
            this.txtNickName.MaxLength = 255;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(320, 21);
            this.txtNickName.TabIndex = 3;
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNickName.Location = new System.Drawing.Point(48, 96);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(96, 13);
            this.lblNickName.TabIndex = 340;
            this.lblNickName.Text = "Abbreviated Name";
            // 
            // lblContact2
            // 
            this.lblContact2.AutoSize = true;
            this.lblContact2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblContact2.Location = new System.Drawing.Point(48, 194);
            this.lblContact2.Name = "lblContact2";
            this.lblContact2.Size = new System.Drawing.Size(54, 13);
            this.lblContact2.TabIndex = 93;
            this.lblContact2.Text = "Contact 2";
            // 
            // lblContact1
            // 
            this.lblContact1.AutoSize = true;
            this.lblContact1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblContact1.Location = new System.Drawing.Point(48, 170);
            this.lblContact1.Name = "lblContact1";
            this.lblContact1.Size = new System.Drawing.Size(54, 13);
            this.lblContact1.TabIndex = 92;
            this.lblContact1.Text = "Contact 1";
            // 
            // cmbContact2
            // 
            this.cmbContact2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContact2.Location = new System.Drawing.Point(216, 192);
            this.cmbContact2.Name = "cmbContact2";
            this.cmbContact2.Size = new System.Drawing.Size(320, 21);
            this.cmbContact2.TabIndex = 7;
            this.cmbContact2.SelectedIndexChanged += new System.EventHandler(this.cmbContact2_SelectedIndexChanged);
            // 
            // cmbContact1
            // 
            this.cmbContact1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContact1.Location = new System.Drawing.Point(216, 168);
            this.cmbContact1.Name = "cmbContact1";
            this.cmbContact1.Size = new System.Drawing.Size(320, 21);
            this.cmbContact1.TabIndex = 6;
            this.cmbContact1.SelectedIndexChanged += new System.EventHandler(this.cmbContact1_SelectedIndexChanged);
            // 
            // llblClient
            // 
            this.llblClient.AutoSize = true;
            this.llblClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llblClient.Location = new System.Drawing.Point(48, 122);
            this.llblClient.Name = "llblClient";
            this.llblClient.Size = new System.Drawing.Size(34, 13);
            this.llblClient.TabIndex = 888;
            this.llblClient.TabStop = true;
            this.llblClient.Text = "Client";
            this.llblClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClient_LinkClicked);
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Location = new System.Drawing.Point(216, 120);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(320, 21);
            this.cmbClient.TabIndex = 4;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(48, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Test Final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(48, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Test Midterm";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Location = new System.Drawing.Point(48, 272);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 84;
            this.label14.Text = "Test Initial";
            // 
            // llblFinalEvt
            // 
            this.llblFinalEvt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llblFinalEvt.Location = new System.Drawing.Point(216, 372);
            this.llblFinalEvt.Name = "llblFinalEvt";
            this.llblFinalEvt.Size = new System.Drawing.Size(320, 21);
            this.llblFinalEvt.TabIndex = 13;
            this.llblFinalEvt.TabStop = true;
            this.llblFinalEvt.Text = "None";
            this.llblFinalEvt.TextChanged += new System.EventHandler(this.llblFinalEvt_TextChanged);
            this.llblFinalEvt.MouseLeave += new System.EventHandler(this.llblFinalEvt_MouseLeave);
            this.llblFinalEvt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblFinalEvt_LinkClicked);
            this.llblFinalEvt.MouseEnter += new System.EventHandler(this.llblFinalEvt_MouseEnter);
            // 
            // llblMidEvt
            // 
            this.llblMidEvt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llblMidEvt.Location = new System.Drawing.Point(216, 320);
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
            this.llblInitialEvt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llblInitialEvt.Location = new System.Drawing.Point(216, 270);
            this.llblInitialEvt.Name = "llblInitialEvt";
            this.llblInitialEvt.Size = new System.Drawing.Size(320, 21);
            this.llblInitialEvt.TabIndex = 9;
            this.llblInitialEvt.TabStop = true;
            this.llblInitialEvt.Text = "None";
            this.llblInitialEvt.TextChanged += new System.EventHandler(this.llblInitialEvt_TextChanged);
            this.llblInitialEvt.MouseLeave += new System.EventHandler(this.llblInitialEvt_MouseLeave);
            this.llblInitialEvt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblInitialEvt_LinkClicked);
            this.llblInitialEvt.MouseEnter += new System.EventHandler(this.llblInitialEvt_MouseEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(24, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Test Event Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(24, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 3);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            // 
            // llbDepartment
            // 
            this.llbDepartment.AutoSize = true;
            this.llbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.llbDepartment.Location = new System.Drawing.Point(48, 146);
            this.llbDepartment.Name = "llbDepartment";
            this.llbDepartment.Size = new System.Drawing.Size(64, 13);
            this.llbDepartment.TabIndex = 999;
            this.llbDepartment.TabStop = true;
            this.llbDepartment.Text = "Department";
            this.llbDepartment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDepartment_LinkClicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(24, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Basic Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 3);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(24, 423);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Test Details";
            // 
            // grpTest
            // 
            this.grpTest.Location = new System.Drawing.Point(24, 430);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(568, 3);
            this.grpTest.TabIndex = 66;
            this.grpTest.TabStop = false;
            // 
            // txtQuestionaireFinalForm
            // 
            this.txtQuestionaireFinalForm.Enabled = false;
            this.txtQuestionaireFinalForm.Location = new System.Drawing.Point(256, 542);
            this.txtQuestionaireFinalForm.MaxLength = 50;
            this.txtQuestionaireFinalForm.Name = "txtQuestionaireFinalForm";
            this.txtQuestionaireFinalForm.Size = new System.Drawing.Size(280, 21);
            this.txtQuestionaireFinalForm.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Location = new System.Drawing.Point(48, 544);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Questionaire Final Form";
            // 
            // txtQuestionaireMidtermForm
            // 
            this.txtQuestionaireMidtermForm.Enabled = false;
            this.txtQuestionaireMidtermForm.Location = new System.Drawing.Point(256, 518);
            this.txtQuestionaireMidtermForm.MaxLength = 50;
            this.txtQuestionaireMidtermForm.Name = "txtQuestionaireMidtermForm";
            this.txtQuestionaireMidtermForm.Size = new System.Drawing.Size(280, 21);
            this.txtQuestionaireMidtermForm.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(48, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Questionaire Mid Term Form";
            // 
            // txtEvaluationFinalForm
            // 
            this.txtEvaluationFinalForm.Enabled = false;
            this.txtEvaluationFinalForm.Location = new System.Drawing.Point(256, 494);
            this.txtEvaluationFinalForm.MaxLength = 50;
            this.txtEvaluationFinalForm.Name = "txtEvaluationFinalForm";
            this.txtEvaluationFinalForm.Size = new System.Drawing.Size(280, 21);
            this.txtEvaluationFinalForm.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(48, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Evaluation Final Form";
            // 
            // txtEvaluationMidtermForm
            // 
            this.txtEvaluationMidtermForm.Enabled = false;
            this.txtEvaluationMidtermForm.Location = new System.Drawing.Point(256, 470);
            this.txtEvaluationMidtermForm.MaxLength = 50;
            this.txtEvaluationMidtermForm.Name = "txtEvaluationMidtermForm";
            this.txtEvaluationMidtermForm.Size = new System.Drawing.Size(280, 21);
            this.txtEvaluationMidtermForm.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(48, 472);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Evaluation Mid Term Form";
            // 
            // txtFinalForm
            // 
            this.txtFinalForm.Enabled = false;
            this.txtFinalForm.Location = new System.Drawing.Point(216, 393);
            this.txtFinalForm.MaxLength = 50;
            this.txtFinalForm.Name = "txtFinalForm";
            this.txtFinalForm.Size = new System.Drawing.Size(320, 21);
            this.txtFinalForm.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(48, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Test Final Form";
            // 
            // txtMidtermForm
            // 
            this.txtMidtermForm.Enabled = false;
            this.txtMidtermForm.Location = new System.Drawing.Point(216, 342);
            this.txtMidtermForm.MaxLength = 50;
            this.txtMidtermForm.Name = "txtMidtermForm";
            this.txtMidtermForm.Size = new System.Drawing.Size(320, 21);
            this.txtMidtermForm.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Location = new System.Drawing.Point(48, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Test Mid Term Form";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Location = new System.Drawing.Point(48, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Test Initial Form";
            // 
            // txtFinalEvent
            // 
            this.txtFinalEvent.Location = new System.Drawing.Point(552, 216);
            this.txtFinalEvent.MaxLength = 15;
            this.txtFinalEvent.Name = "txtFinalEvent";
            this.txtFinalEvent.ReadOnly = true;
            this.txtFinalEvent.Size = new System.Drawing.Size(112, 21);
            this.txtFinalEvent.TabIndex = 8;
            this.txtFinalEvent.Tag = "N";
            this.txtFinalEvent.Text = "0";
            this.txtFinalEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFinalEvent.Visible = false;
            this.txtFinalEvent.Leave += new System.EventHandler(this.txtReportAttendence_Leave);
            this.txtFinalEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReportAttendence_KeyPress);
            // 
            // txtMidtermEvent
            // 
            this.txtMidtermEvent.Location = new System.Drawing.Point(472, 216);
            this.txtMidtermEvent.MaxLength = 15;
            this.txtMidtermEvent.Name = "txtMidtermEvent";
            this.txtMidtermEvent.ReadOnly = true;
            this.txtMidtermEvent.Size = new System.Drawing.Size(112, 21);
            this.txtMidtermEvent.TabIndex = 6;
            this.txtMidtermEvent.Tag = "N";
            this.txtMidtermEvent.Text = "0";
            this.txtMidtermEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMidtermEvent.Visible = false;
            this.txtMidtermEvent.Leave += new System.EventHandler(this.txtReportAttendence_Leave);
            this.txtMidtermEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReportAttendence_KeyPress);
            // 
            // txtInitialEvent
            // 
            this.txtInitialEvent.Location = new System.Drawing.Point(392, 216);
            this.txtInitialEvent.MaxLength = 15;
            this.txtInitialEvent.Name = "txtInitialEvent";
            this.txtInitialEvent.ReadOnly = true;
            this.txtInitialEvent.Size = new System.Drawing.Size(112, 21);
            this.txtInitialEvent.TabIndex = 7;
            this.txtInitialEvent.Tag = "N";
            this.txtInitialEvent.Text = "0";
            this.txtInitialEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInitialEvent.Visible = false;
            this.txtInitialEvent.Leave += new System.EventHandler(this.txtReportAttendence_Leave);
            this.txtInitialEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReportAttendence_KeyPress);
            // 
            // txtNameRomaji
            // 
            this.txtNameRomaji.Location = new System.Drawing.Point(216, 72);
            this.txtNameRomaji.MaxLength = 255;
            this.txtNameRomaji.Name = "txtNameRomaji";
            this.txtNameRomaji.Size = new System.Drawing.Size(320, 21);
            this.txtNameRomaji.TabIndex = 2;
            // 
            // txtNamePhonetic
            // 
            this.txtNamePhonetic.Location = new System.Drawing.Point(216, 48);
            this.txtNamePhonetic.MaxLength = 255;
            this.txtNamePhonetic.Name = "txtNamePhonetic";
            this.txtNamePhonetic.Size = new System.Drawing.Size(320, 21);
            this.txtNamePhonetic.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(48, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Name Romaji";
            // 
            // cmbDept
            // 
            this.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDept.Location = new System.Drawing.Point(216, 144);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(320, 21);
            this.cmbDept.TabIndex = 5;
            this.cmbDept.SelectedIndexChanged += new System.EventHandler(this.cmbDept_SelectedIndexChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPassword.Location = new System.Drawing.Point(48, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 13);
            this.lblPassword.TabIndex = 32;
            this.lblPassword.Text = "Name Phonetic";
            // 
            // txtProgramName
            // 
            this.txtProgramName.Location = new System.Drawing.Point(216, 24);
            this.txtProgramName.MaxLength = 255;
            this.txtProgramName.Name = "txtProgramName";
            this.txtProgramName.Size = new System.Drawing.Size(320, 21);
            this.txtProgramName.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(48, 218);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 34;
            this.lblStatus.Text = "Status";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Location = new System.Drawing.Point(48, 26);
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
            this.cmbStatus.Location = new System.Drawing.Point(216, 216);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(152, 21);
            this.cmbStatus.TabIndex = 8;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // tbpDescription
            // 
            this.tbpDescription.Controls.Add(this.txtDescription);
            this.tbpDescription.Location = new System.Drawing.Point(4, 22);
            this.tbpDescription.Name = "tbpDescription";
            this.tbpDescription.Size = new System.Drawing.Size(762, 566);
            this.tbpDescription.TabIndex = 1;
            this.tbpDescription.Text = "Description";
            this.tbpDescription.UseVisualStyleBackColor = true;
            this.tbpDescription.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(0, 0);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(762, 566);
            this.txtDescription.TabIndex = 0;
            // 
            // tbpSpecialRemarks
            // 
            this.tbpSpecialRemarks.Controls.Add(this.txtRemarks);
            this.tbpSpecialRemarks.Location = new System.Drawing.Point(4, 22);
            this.tbpSpecialRemarks.Name = "tbpSpecialRemarks";
            this.tbpSpecialRemarks.Size = new System.Drawing.Size(762, 566);
            this.tbpSpecialRemarks.TabIndex = 2;
            this.tbpSpecialRemarks.Text = "Special Remarks";
            this.tbpSpecialRemarks.UseVisualStyleBackColor = true;
            this.tbpSpecialRemarks.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(0, 0);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(762, 566);
            this.txtRemarks.TabIndex = 1;
            // 
            // tbpTestEvents
            // 
            this.tbpTestEvents.Controls.Add(this.pnlButtons);
            this.tbpTestEvents.Controls.Add(this.grdEvents);
            this.tbpTestEvents.Location = new System.Drawing.Point(4, 22);
            this.tbpTestEvents.Name = "tbpTestEvents";
            this.tbpTestEvents.Size = new System.Drawing.Size(762, 566);
            this.tbpTestEvents.TabIndex = 6;
            this.tbpTestEvents.Text = "Test Events";
            this.tbpTestEvents.UseVisualStyleBackColor = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 524);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(762, 42);
            this.pnlButtons.TabIndex = 34;
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
            this.grdEvents.Size = new System.Drawing.Size(762, 566);
            this.grdEvents.TabIndex = 33;
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
            this.gvwEvents.ViewStyles.AddReplace("FocusedRow", "SelectedRow");
            this.gvwEvents.ViewStyles.AddReplace("FocusedCell", "SelectedRow");
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
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(683, 606);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPageSetup.Location = new System.Drawing.Point(112, 606);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(75, 23);
            this.btnPageSetup.TabIndex = 24;
            this.btnPageSetup.Text = "Page Setup";
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(24, 606);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
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
            // buttonClear
            // 
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonClear.Location = new System.Drawing.Point(507, 13);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 25;
            this.buttonClear.Text = "Delete Event";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // frmProgramDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(770, 640);
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
            this.Name = "frmProgramDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding Program...";
            this.Load += new System.EventHandler(this.frmProgramDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProgramDlg_KeyDown);
            this.tbcCourse.ResumeLayout(false);
            this.tbpCourse.ResumeLayout(false);
            this.tbpCourse.PerformLayout();
            this.tbpDescription.ResumeLayout(false);
            this.tbpDescription.PerformLayout();
            this.tbpSpecialRemarks.ResumeLayout(false);
            this.tbpSpecialRemarks.PerformLayout();
            this.tbpTestEvents.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private string _mode = "";
		private int _programid;

		public string Mode
		{
			get { return _mode; }
			set { _mode = value; }
		}

		public int ProgramID
		{
			get { return _programid; }
			set { _programid = value; }
		}

		private void frmProgramDlg_Load(object sender, EventArgs e)
		{
			if (_mode != "Edit") cmbStatus.SelectedIndex = 0;
			ActiveControl = txtProgramName;

			//cmbEventType_I.SelectedIndex = 0;
			//IsEventChanged = false;

			try
			{
				Common.SetControlFont(this);
			}
			catch {}
			Refresh();

			SetControlEnabled();
		}

		public void LoadData()
		{
			string strEM = "", strEF = "", strQM = "", strQF = "";
            if (_mode == "Edit" || _mode == "AddClone")
            {
                if (_mode == "Edit")
                {
                    btnDelete.Enabled = true;
                    Text = "Editing Program...";
                }
                else
                {
                    btnDelete.Enabled = false;
                    this.Text = "Adding Program Clone...";
                }

                Program objProgram = new Program();
                objProgram.ProgramID = _programid;
                objProgram.LoadData();
                bool[] boolArray = objProgram.CheckTestEvents();
                HasTestInitialEvent = boolArray[0];
                HasTestMidtermEvent = boolArray[1];
                HasTestFinalEvent = boolArray[2];                

                foreach (DataRow dr in objProgram.ProgramDataTable.Rows)
                {
                    intClientID = Convert.ToInt32(dr["ClientID"].ToString());
                    if (intClientID > 0)
                    {
                        cmbClient.Text = Common.GetCompanyName("Select CompanyName = CASE " +
                                                               "WHEN NickName IS NULL THEN CompanyName " +
                                                               "WHEN NickName = '' THEN CompanyName " +
                                                               "ELSE NickName " +
                                                               "END  " +
                                                               "from Contact where ContactID=@ContactID", intClientID);
                        Common.PopulateDropdown(
                            cmbDept, "Select CompanyName = CASE " +
                                     "WHEN C.NickName IS NULL THEN C.CompanyName " +
                                     "WHEN C.NickName = '' THEN C.CompanyName " +
                                     "ELSE C.NickName " +
                                     "END From " +
                                     "Department D, Contact C Where D.ContactID=C.ContactID and " +
                                     "D.DepartmentStatus=0 and D.ClientID=" + intClientID +
                                     " Order By D.CompanyName ");
                    }

                    txtProgramName.Text = dr["Name"].ToString();
                    if (_mode == "AddClone") txtProgramName.Text = "Copy of " + txtProgramName.Text;
                    txtNamePhonetic.Text = dr["NamePhonetic"].ToString();
                    txtNameRomaji.Text = dr["NameRomaji"].ToString();
                    txtNickName.Text = dr["NickName"].ToString();
                    cmbDept.Text = dr["Department"].ToString();

                    cmbContact1.Text = dr["Contact1"].ToString();
                    cmbContact2.Text = dr["Contact2"].ToString();

                    txtDescription.Text = dr["Description"].ToString();
                    txtRemarks.Text = dr["SpecialRemarks"].ToString();

                    if (dr["ReportAttendence"].ToString() != "")
                    {
                        if (dr["ReportAttendence"].ToString() == "None")
                            rbtnNone.Checked = true;
                        else if (dr["ReportAttendence"].ToString() == "Weekly")
                            rbtnWeekly.Checked = true;
                        else if (dr["ReportAttendence"].ToString() == "Monthly")
                            rbtnMonthly.Checked = true;
                        else if (dr["ReportAttendence"].ToString() == "End")
                            rbtnEnd.Checked = true;
                    }

                    if (dr["ProgramStatus"].ToString() == "Active")
                        cmbStatus.SelectedIndex = 0;
                    else
                        cmbStatus.SelectedIndex = 1;

                    if (_mode == "Edit")
                    {
                        txtInitialEvent.Text = dr["TestInitialEventId"].ToString();
                        txtMidtermEvent.Text = dr["TestMidTermEventId"].ToString();
                        txtFinalEvent.Text = dr["TestFinalEventId"].ToString();

                        eventid[0] = Convert.ToInt32(dr["TestInitialEventId"].ToString());
                        eventid[1] = Convert.ToInt32(dr["TestMidTermEventId"].ToString());
                        eventid[2] = Convert.ToInt32(dr["TestFinalEventId"].ToString());

                        txtInitialForm.Text = dr["TestInitialForm"].ToString();
                        txtMidtermForm.Text = dr["TestMidTermForm"].ToString();
                        txtFinalForm.Text = dr["TestFinalForm"].ToString();

                        strEM = dr["EvaluationMidtermForm"].ToString().Trim();
                        strEF = dr["EvaluationFinalForm"].ToString().Trim();
                        strQM = dr["QuestionaireMidtermForm"].ToString().Trim();
                        strQF = dr["QuestionaireFinalForm"].ToString().Trim();

                        chkEM.Checked = false;
                        chkEF.Checked = false;
                        chkQM.Checked = false;
                        chkQF.Checked = false;

                        if (strEM.Length > 0)
                        {
                            if (strEM.Substring(strEM.Length - 1, 1) == "|")
                            {
                                chkEM.Checked = true;
                                strEM = strEM.Substring(0, strEM.Length - 1);
                            }
                        }
                        if (strEF.Length > 0)
                        {
                            if (strEF.Substring(strEF.Length - 1, 1) == "|")
                            {
                                chkEF.Checked = true;
                                strEF = strEF.Substring(0, strEF.Length - 1);
                            }
                        }

                        if (strQM.Length > 0)
                        {
                            if (strQM.Substring(strQM.Length - 1, 1) == "|")
                            {
                                chkQM.Checked = true;
                                strQM = strQM.Substring(0, strQM.Length - 1);
                            }
                        }

                        if (strQF.Length > 0)
                        {
                            if (strQF.Substring(strQF.Length - 1, 1) == "|")
                            {
                                chkQF.Checked = true;
                                strQF = strQF.Substring(0, strQF.Length - 1);
                            }
                        }

                        txtEvaluationMidtermForm.Text = strEM;
                        txtEvaluationFinalForm.Text = strEF;

                        txtQuestionaireMidtermForm.Text = strQM;
                        txtQuestionaireFinalForm.Text = strQF;
                    }
                    else
                    {
                        txtInitialEvent.Text = "0";
                        txtMidtermEvent.Text = "0";
                        txtFinalEvent.Text = "0";

                        eventid[0] = 0;
                        eventid[1] = 0;
                        eventid[2] = 0;

                        txtInitialForm.Text = String.Empty;
                        txtMidtermForm.Text = String.Empty;
                        txtFinalForm.Text = String.Empty;

                        strEM = String.Empty;
                        strEF = String.Empty;
                        strQM = String.Empty;
                        strQF = String.Empty;

                        chkEM.Checked = false;
                        chkEF.Checked = false;
                        chkQM.Checked = false;
                        chkQF.Checked = false;

                        txtEvaluationMidtermForm.Text = strEM;
                        txtEvaluationFinalForm.Text = strEF;

                        txtQuestionaireMidtermForm.Text = strQM;
                        txtQuestionaireFinalForm.Text = strQF;

                        llblInitialEvt.Text = "None";
                        llblMidEvt.Text = "None";
                        llblFinalEvt.Text = "None";
                    }
                    break;
                }

                if (_mode == "Edit")
                {
                    //load Events if any
                    string strHint = "";
                    llblInitialEvt.Text = objProgram.getEventText(txtInitialEvent.Text, "Initial", ref strHint);
                    strHint = "";

                    llblMidEvt.Text = objProgram.getEventText(txtMidtermEvent.Text, "Midterm", ref strHint);

                    llblFinalEvt.Text = objProgram.getEventText(txtFinalEvent.Text, "Final", ref strHint);

                    //if (eventid[0] > 0)
                    //    LoadEvent(eventid[0], calendareventid[0]);
                }
            }
			else
			{
				btnDelete.Enabled = false;
				Text = "Adding Department...";
				if (cmbDept.Items.Count > 0)
					cmbDept.SelectedIndex = 0;
				cmbStatus.SelectedIndex = 0;

				txtProgramName.Text = String.Empty;
				txtNamePhonetic.Text = String.Empty;
				txtNameRomaji.Text = String.Empty;
				txtNickName.Text = String.Empty;
				cmbDept.Text = String.Empty;

				cmbContact1.Text = String.Empty;
				cmbContact2.Text = String.Empty;

				txtDescription.Text = String.Empty;
				txtRemarks.Text = String.Empty;

				rbtnNone.Checked = rbtnWeekly.Checked = rbtnMonthly.Checked = rbtnEnd.Checked = false;

				txtInitialEvent.Text = String.Empty;
				txtMidtermEvent.Text = String.Empty;
				txtFinalEvent.Text = String.Empty;

				eventid[0] = 0;
				eventid[1] = 0;
				eventid[2] = 0;

				txtInitialForm.Text = String.Empty;
				txtMidtermForm.Text = String.Empty;
				txtFinalForm.Text = String.Empty;

				strEM = String.Empty;
				strEF = String.Empty;
				strQM = String.Empty;
				strQF = String.Empty;

				chkEM.Checked = false;
				chkEF.Checked = false;
				chkQM.Checked = false;
				chkQF.Checked = false;

				txtEvaluationMidtermForm.Text = strEM;
				txtEvaluationFinalForm.Text = strEF;

				txtQuestionaireMidtermForm.Text = strQM;
				txtQuestionaireFinalForm.Text = strQF;

				cmbStatus.SelectedIndex = 0;

				cmbClient.SelectedIndex = 0;
				intClientID = 0;

			}

			SetControlEnabled();

			
		}
        /*
		private void LoadEvent()
		{
			llblInitialEvt.Text = "None";
			llblMidEvt.Text = "None";
			llblFinalEvt.Text = "None";

			Program objProgram = new Program();
			objProgram.ProgramID = _programid;
			objProgram.LoadData();

			foreach (DataRow dr in objProgram.ProgramDataTable.Rows)
			{
				txtInitialEvent.Text = dr["TestInitialEventId"].ToString();
				txtMidtermEvent.Text = dr["TestMidTermEventId"].ToString();
				txtFinalEvent.Text = dr["TestFinalEventId"].ToString();
				break;
			}


			//load Events if any
			string strHint = "";
			llblInitialEvt.Text = objProgram.getEventText(txtInitialEvent.Text, "Initial", ref strHint);
			strHint = "";
			llblMidEvt.Text = objProgram.getEventText(txtMidtermEvent.Text, "Midterm", ref strHint);
			strHint = "";
			llblFinalEvt.Text = objProgram.getEventText(txtFinalEvent.Text, "Final", ref strHint);
		}
        */
        //Loads test events for the program (if any)
        private void LoadTestEvents()
        {
            BusinessLayer.Program objProgram = new Program();
            objProgram.ProgramID = _programid;
            objProgram.LoadData();
            //Load Test Events
            DataTable dtbl = objProgram.LoadTestEvents();
            grdEvents.DataSource = dtbl;
            if (dtbl.Rows.Count == 0)
            {
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
            }

            if (HasTestInitialEvent && HasTestMidtermEvent && HasTestFinalEvent)
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
        }

		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (!deleted) DialogResult = DialogResult.Cancel;
			else if (deleted) DialogResult = DialogResult.OK;
			Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				if (txtProgramName.Text == "")
				{
					tbcCourse.SelectedIndex = 0;
					BusinessLayer.Message.MsgInformation("Enter Program Name");
					txtProgramName.Focus();
					return;
				}
				if (cmbDept.Text == "")
				{
					tbcCourse.SelectedIndex = 0;
					BusinessLayer.Message.MsgInformation("Enter Department");
					cmbDept.Focus();
					return;
				}
				if (cmbContact1.Text != "")
				{
					if (cmbContact1.SelectedIndex == cmbContact2.SelectedIndex)
					{
						tbcCourse.SelectedIndex = 0;
						BusinessLayer.Message.MsgInformation("Same Contact 1 and Contact 2 are not allowed");
						cmbContact1.Focus();
						return;
					}
				}

				bool boolSuccess;
				Program objProgram = null;

				objProgram = new Program();
				objProgram.ProgramID = 0;

				objProgram.name = txtProgramName.Text;
				objProgram.NamePhonetic = txtNamePhonetic.Text;
				objProgram.NameRomaji = txtNameRomaji.Text;
				objProgram.NickName = txtNickName.Text;
				objProgram.DepartmentID = intDepartmentID;
				objProgram.Contact1ID = intContact1ID;
				objProgram.Contact2ID = intContact2ID;

				objProgram.Description = txtDescription.Text;
				objProgram.SpecialRemarks = txtRemarks.Text;

				if (rbtnNone.Checked)
					objProgram.ReportAttendence = "None";
				else if (rbtnWeekly.Checked)
					objProgram.ReportAttendence = "Weekly";
				else if (rbtnMonthly.Checked)
					objProgram.ReportAttendence = "Monthly";
				else if (rbtnEnd.Checked)
					objProgram.ReportAttendence = "End";

				objProgram.TestInitialEventID = eventid[0]; //Convert.ToInt32(txtInitialEvent.Text);
				objProgram.TestMidEventID = eventid[1]; //Convert.ToInt32(txtMidtermEvent.Text);
				objProgram.TestFinalEventID = eventid[2]; //Convert.ToInt32(txtFinalEvent.Text);

				objProgram.TestInitialForm = txtInitialForm.Text;
				objProgram.TestMidtermForm = txtMidtermForm.Text;
				objProgram.TestFinalForm = txtFinalForm.Text;

				objProgram.EvaluationMidtermForm = txtEvaluationMidtermForm.Text;
				objProgram.EvaluationFinalForm = txtEvaluationFinalForm.Text;

				objProgram.QuestionaireMidtermForm = txtQuestionaireMidtermForm.Text;
				objProgram.QuestionaireFinalForm = txtQuestionaireFinalForm.Text;


				if (chkEM.Checked)
					objProgram.EvaluationMidtermForm += "|";
				if (chkEF.Checked)
					objProgram.EvaluationFinalForm += "|";

				if (chkQM.Checked)
					objProgram.QuestionaireMidtermForm += "|";
				if (chkQF.Checked)
					objProgram.QuestionaireFinalForm += "|";


				objProgram.ProgramStatus = cmbStatus.SelectedIndex;


				objProgram.ProgramID = _programid;
				if (objProgram.Exists())
				{
					BusinessLayer.Message.MsgInformation("Duplicate Program Name not allowed");
					txtProgramName.Focus();
					return;
				}
				if (txtNickName.Text != "")
				{
					if (objProgram.NickNameExists())
					{
						BusinessLayer.Message.MsgInformation("Duplicate Abbreviated Name not allowed");
						txtNickName.Focus();
						return;
					}
				}
				if ((_mode == "Add") || (_mode=="AddClone") || (_mode == ""))
					boolSuccess = objProgram.InsertData();
				else
				{
					objProgram.ProgramID = _programid;
					boolSuccess = objProgram.UpdateData();
				}
                /*
				if (IsEventChanged)
				{
					DialogResult dlg =
						MessageBox.Show(this, "You have made changes to the events.\n\nWould you like to save the changes?", "Scheduler",
						                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (dlg == DialogResult.Yes)
						SaveAllEvents(GetCurrentEventID((TabPage) pnlEvent.Parent));
				}
				if (objEvent != null)
				{
					//Update the events
					_programid = objProgram.ProgramID;
					if (_programid != 0)
					{
						int _id = 0;
						//Test Initial Event
						if (eventid[0] != 0)
						{
							_id = eventid[0];
							if (_id < 0) _id = 0;
							objEvent.UpdateProgramEvent("TestInitialEventID", _id, _programid);
							_id = 0;
						}
						//Test Midterm Event
						if (eventid[1] != 0)
						{
							_id = eventid[1];
							if (_id < 0) _id = 0;
							objEvent.UpdateProgramEvent("TestMidtermEventID", _id, _programid);
							_id = 0;
						}
						//Test Final Event
						if (eventid[2] != 0)
						{
							_id = eventid[2];
							if (_id < 0) _id = 0;
							objEvent.UpdateProgramEvent("TestFinalEventID", _id, _programid);
							_id = 0;
						}
					}
				}*/

				if (!boolSuccess)
				{
                    if (_mode == "Add")
                        BusinessLayer.Message.ShowException("Inserting Program record.", objProgram.Message);
                    else if (_mode == "AddClone")
                        BusinessLayer.Message.ShowException("Cloning Program record.", objProgram.Message);
                    else
                        BusinessLayer.Message.ShowException("Updating Program record.", objProgram.Message);
					return;
				}

				DialogResult = DialogResult.OK;
				Close();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
		}
			
		private void llbDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmDepartmentDlg fDeptDlg = new frmDepartmentDlg();
			fDeptDlg.Mode = "Add";
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

		private void txtReportAttendence_KeyPress(object sender, KeyPressEventArgs e)
		{
			Common.MaskInteger(e);
		}

		private void txtReportAttendence_Leave(object sender, EventArgs e)
		{
			TextBox tb = (TextBox) sender;
			if (tb.Text.Trim() == "")
				tb.Text = "0";
		}

		private void frmProgramDlg_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				//if (!((this.ActiveControl.GetType().Name == "RichTextBox") ||
				ProcessTabKey(true);
			}
			if (e.KeyData == Keys.Escape)
				Close();
		}

		private void llblInitialEvt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            tbcCourse.SelectedTab = tbpTestEvents;
		}

		private void llblMidEvt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            tbcCourse.SelectedTab = tbpTestEvents;
		}

		private void llblFinalEvt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            tbcCourse.SelectedTab = tbpTestEvents;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (BusinessLayer.Message.MsgDelete())
			{
				Program objProg = new Program();
				objProg.ProgramID = _programid;
				if (!objProg.DeleteData())
				{
					BusinessLayer.Message.MsgWarning("Program cannot be deleted");
					return;
				}
				else
				{
					deleted = true;
					btnDelete.Enabled = false;
					Text = "Adding Program...";
					_mode = "Add";
					_programid = 0;

					foreach (Control c in tbpCourse.Controls)
					{
						if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
						{
							if (c.Tag == null) c.Text = "";
							else if (c.Tag.ToString() == "N") c.Text = "0";
						}
						if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
							c.Text = "";
					}
					foreach (Control c in tbpDescription.Controls)
					{
						if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
						{
							if (c.Tag == null) c.Text = "";
							else if (c.Tag.ToString() == "N") c.Text = "0";
						}
						if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
							c.Text = "";
					}
					foreach (Control c in tbpSpecialRemarks.Controls)
					{
						if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
						{
							if (c.Tag == null) c.Text = "";
							else if (c.Tag.ToString() == "N") c.Text = "0";
						}
						if (c.GetType().ToString() == "System.Windows.Forms.ComboBox")
							c.Text = "";
					}
					DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		private void llblInitialEvt_MouseEnter(object sender, EventArgs e)
		{
			if (llblInitialEvt.Tag != null)
			{
				//lblHint.Text = llblInitialEvt.Tag.ToString();
				//if(lblHint.Text!="") lblHint.Visible=true;
				//lblHint.Top = llblInitialEvt.Top + 20;
			}
		}

		private void llblInitialEvt_MouseLeave(object sender, EventArgs e)
		{
			//lblHint.Visible=false;
		}

		private void llblMidEvt_MouseEnter(object sender, EventArgs e)
		{
			if (llblMidEvt.Tag != null)
			{
				//lblHint.Text = llblMidEvt.Tag.ToString();
				//if(lblHint.Text!="") lblHint.Visible=true;
				//lblHint.Top = llblMidEvt.Top + 20;
			}
		}

		private void llblMidEvt_MouseLeave(object sender, EventArgs e)
		{
			//lblHint.Visible=false;		
		}

		private void llblFinalEvt_MouseEnter(object sender, EventArgs e)
		{
			if (llblFinalEvt.Tag != null)
			{
				//lblHint.Text = llblFinalEvt.Tag.ToString();
				//if(lblHint.Text!="") lblHint.Visible=true;
				//lblHint.Top = llblFinalEvt.Top + 20;
			}
		}

		private void llblFinalEvt_MouseLeave(object sender, EventArgs e)
		{
			//lblHint.Visible=false;		
		}

		private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (_mode == "Edit")
			{
				if (cmbStatus.SelectedIndex == 1)
				{
					Common.MakeReadOnly(tbpCourse, false);
					Common.MakeReadOnly(tbpDescription, false);
					Common.MakeReadOnly(tbpSpecialRemarks, false);
					cmbStatus.Enabled = true;
				}
				else
				{
					Common.MakeEnabled(tbpCourse, false);
					Common.MakeEnabled(tbpDescription, false);
					Common.MakeEnabled(tbpSpecialRemarks, false);
				}
			}
		}

		private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbClient.SelectedIndex == 0) intClientID = 0;

			string str1 = cmbContact1.Text;
			string str2 = cmbContact2.Text;

			string str3 = cmbDept.Text;

			cmbContact1.Text = "";
			cmbContact2.Text = "";
			cmbDept.Text = "";

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
					         "D.DepartmentStatus=0 and D.ClientID=" + intClientID +
					         " Order By CompanyName");

				cmbDept.Text = str3;
				if (cmbDept.Text != "")
				{
					cmbContact1.Text = str1;
					cmbContact2.Text = str2;
				}
			}
		}

		private void llblClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmClientDlg fContDlg = new frmClientDlg();
			fContDlg.Mode = "Add";
			string str = cmbClient.Text;
			if (fContDlg.ShowDialog() == DialogResult.OK)
			{
				Common.PopulateDropdown(
					cmbClient, "Select CompanyName = CASE " +
					           "WHEN NickName IS NULL THEN CompanyName " +
					           "WHEN NickName = '' THEN CompanyName " +
					           "ELSE NickName " +
					           "END From " +
					           "Contact Where ContactType=2 and " +
					           "ContactStatus=0 Order By CompanyName ");

				cmbClient.Text = str;
			}
			fContDlg.Close();
			fContDlg.Dispose();
			fContDlg = null;
		}

		private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbDept.SelectedIndex == 0) intDepartmentID = 0;

			string str1 = cmbContact1.Text;
			string str2 = cmbContact2.Text;

			cmbContact1.Text = "";
			cmbContact2.Text = "";


			intDepartmentID = Common.GetCompanyID(
				"Select D.DepartmentID from Department D, Contact C " +
				"Where D.ContactID=C.ContactID and (C.CompanyName= @CompanyName OR C.NickName=@CompanyName) and ClientID=" +
				intClientID.ToString(), cmbDept.Text
				);

			if (intDepartmentID != 0)
			{
				string sql = "Select ContactName = CASE " + //"C.LastName + ', ' + C.FirstName " +
				             "WHEN C.NickName IS NULL THEN C.LastName + ', ' + C.FirstName " +
				             "WHEN C.NickName = '' THEN C.LastName + ', ' + C.FirstName " +
				             "ELSE C.NickName " +
				             "END From " +
				             "Contact C Where C.ContactStatus=0 and C.ContactType=5 and C.RefID=" + intDepartmentID.ToString() +
				             " Order By C.ContactName ";
				Common.PopulateDropdown(cmbContact1, sql);
				Common.PopulateDropdown(cmbContact2, sql);

				if (cmbDept.Text != "")
				{
					cmbContact1.Text = str1;
					cmbContact2.Text = str2;
				}
			}
		}

		private void cmbContact1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbContact1.SelectedIndex == 0) intContact1ID = 0;
			if (cmbContact1.Text == "") return;
			string[] arr = cmbContact1.Text.Split(new char[] {','});
			if (arr.Length > 1)
			{
				intContact1ID = Common.GetContactID(
					"Select ContactID From Contact " +
					"Where FirstName =@FName AND LastName=@LName AND ContactType=5 AND RefID=" + intDepartmentID.ToString(),
					arr[1].ToString().Trim(), arr[0].ToString().Trim());
			}
			else
			{
				intContact1ID = Common.GetContactID(
					"Select ContactID From Contact " +
					"Where FirstName =@FName AND LastName=@LName AND ContactType=5 AND RefID=" + intDepartmentID.ToString(),
					arr[1].ToString().Trim(), arr[0].ToString().Trim());
			}
		}

		private void cmbContact2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbContact2.SelectedIndex == 0) intContact2ID = 0;
			if (cmbContact2.Text == "") return;
			string[] arr = cmbContact2.Text.Split(new char[] {','});
			intContact2ID = Common.GetContactID(
				"Select ContactID From Contact " +
				"Where FirstName =@FName AND LastName=@LName AND ContactType=5 AND RefID=" + intDepartmentID.ToString(),
				arr[1].ToString().Trim(), arr[0].ToString().Trim());
		}

		private void chkEF_CheckedChanged(object sender, EventArgs e)
		{
			if (chkEF.Checked) txtEvaluationFinalForm.Enabled = true;
			if (!chkEF.Checked) txtEvaluationFinalForm.Enabled = false;
		}

		private void chkEM_CheckedChanged(object sender, EventArgs e)
		{
			if (chkEM.Checked) txtEvaluationMidtermForm.Enabled = true;
			if (!chkEM.Checked) txtEvaluationMidtermForm.Enabled = false;
		}

		private void chkQM_CheckedChanged(object sender, EventArgs e)
		{
			if (chkQM.Checked) txtQuestionaireMidtermForm.Enabled = true;
			if (!chkQM.Checked) txtQuestionaireMidtermForm.Enabled = false;
		}

		private void chkQF_CheckedChanged(object sender, EventArgs e)
		{
			if (chkQF.Checked) txtQuestionaireFinalForm.Enabled = true;
			if (!chkQF.Checked) txtQuestionaireFinalForm.Enabled = false;
		}

		private void SetControlEnabled()
		{
			if (cmbStatus.Text == "Active")
			{
				if (chkEM.Checked) txtEvaluationMidtermForm.Enabled = true;
				if (chkEF.Checked) txtEvaluationFinalForm.Enabled = true;
				if (chkQM.Checked) txtQuestionaireMidtermForm.Enabled = true;
				if (chkQF.Checked) txtQuestionaireFinalForm.Enabled = true;

				/*if(txtEvaluationFinalForm.Text.Trim()!="") 
				{
					txtEvaluationFinalForm.Enabled=true;
					//chkEF.Checked=true;
				}
				if(txtEvaluationMidtermForm.Text.Trim()!="") 
				{
					txtEvaluationMidtermForm.Enabled=true;
					//chkEM.Checked=true;
				}
				if(txtQuestionaireMidtermForm.Text.Trim()!="") 
				{
					txtQuestionaireMidtermForm.Enabled=true;
					//chkQM.Checked=true;
				}
				if(txtQuestionaireFinalForm.Text.Trim()!="") 
				{
					txtQuestionaireFinalForm.Enabled=true;
					//chkQF.Checked=true;
				}*/


				if (llblInitialEvt.Text.Trim() == "None")
					txtInitialForm.Enabled = false;
				else
					txtInitialForm.Enabled = true;
				if (llblMidEvt.Text.Trim() == "None")
					txtMidtermForm.Enabled = false;
				else
					txtMidtermForm.Enabled = true;
				if (llblFinalEvt.Text.Trim() == "None")
					txtFinalForm.Enabled = false;
				else
					txtFinalForm.Enabled = true;
			}
		}

		private void llblInitialEvt_TextChanged(object sender, EventArgs e)
		{
			if (llblInitialEvt.Text.Trim() == "None")
				txtInitialForm.Enabled = false;
			else
				txtInitialForm.Enabled = true;
		}

		private void llblMidEvt_TextChanged(object sender, EventArgs e)
		{
			if (llblMidEvt.Text.Trim() == "None")
				txtMidtermForm.Enabled = false;
			else
				txtMidtermForm.Enabled = true;
		}

		private void llblFinalEvt_TextChanged(object sender, EventArgs e)
		{
			if (llblFinalEvt.Text.Trim() == "None")
				txtFinalForm.Enabled = false;
			else
				txtFinalForm.Enabled = true;
		}

        private void tbcCourse_SelectedIndexChanged(object sender, EventArgs e)
		{
			//DoEventTabChange(true, tbcCourse.SelectedTab != pnlEvent.Parent);
            DoEventTabChange(true);
		}

		private void DoEventTabChange(bool showSaveConfirmation) 
		{
			//pnlBottom.Visible = false;
			//tbcCourse.SelectedIndexChanged -= new EventHandler(tbcCourse_SelectedIndexChanged);
            try
            {
                TabPage tbpSelected = tbcCourse.SelectedTab;

                if (tbcCourse.SelectedTab == tbpTestEvents)
                {
                    if (_mode == "Edit") LoadTestEvents();
                    /*if (IsEventChanged)
                    {
                        if (pnlEvent.Parent != tbpSelected)
                            tbcCourse.SelectedTab = (TabPage) pnlEvent.Parent;

                        DialogResult dlg = DialogResult.No;

                        if (showSaveConfirmation)
                        {
                            dlg = MessageBox.Show(this, "Are you sure, you want to save the current events?" +
                                                  "\r\rCancelling will result a loss of event data.", "Scheduler",
                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
							
                        }

                        if (dlg == DialogResult.Cancel)
                        {
                            tbcCourse.SelectedTab = (TabPage) pnlEvent.Parent;
                            return;
                        }
                        else if (dlg == DialogResult.Yes)
                        {
                            if (!doSaveEvents(GetCurrentEventID((TabPage) pnlEvent.Parent)))
                            {
                                tbcCourse.SelectedTab = (TabPage) pnlEvent.Parent;
                                return;
                            }
                        }
                        tbcCourse.SelectedTab = tbpSelected;
                    }

                    
                    if (reloadEventControl)
                    {
                        if (pnlEvent.Parent != null)
                            pnlEvent.Parent.Controls.Remove(pnlEvent);
                        tbcCourse.SelectedTab.Controls.Add(pnlEvent);
                        InitializeEventForm();
                    }

                    if (tbcCourse.SelectedTab == tbpInitial)
                    {
                        if (eventid[0] == 0)
                        {
                            txtName_I.Text = txtProgramName.Text + " Initial Test";
                            cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
                            cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0, 0, 30, 0, 0)).ToString("HH:mm");
                        }
                        else
                            LoadEvent(eventid[0], calendareventid[0]);
                    }
                    if (tbcCourse.SelectedTab == tbpMidterm)
                    {
                        if (eventid[1] == 0)
                        {
                            txtName_I.Text = txtProgramName.Text + " Midterm Test";
                            cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
                            cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0, 0, 30, 0, 0)).ToString("HH:mm");
                        }
                        else
                            LoadEvent(eventid[1], calendareventid[0]);
                    }
                    if (tbcCourse.SelectedTab == tbpFinal)
                    {
                        if (eventid[2] == 0)
                        {
                            txtName_I.Text = txtProgramName.Text + " Final Test";
                            cmbStartTime.Text = DateTime.Now.ToString("HH:mm");
                            cmbEndTime.Text = DateTime.Now.Add(new TimeSpan(0, 0, 30, 0, 0)).ToString("HH:mm");
                        }
                        else
                            LoadEvent(eventid[2], calendareventid[0]);
                    }*/
                    //IsEventChanged = false;
                }
            }
            catch { }
		}
        DevNormalPrinting xnm = null;
		private void btnPrint_Click(object sender, EventArgs e)
        {
            #region Initializaing Values
            ArrayList arrLabel = new ArrayList();

			ArrayList arrLabel1 = new ArrayList();
			ArrayList arrLabel2 = new ArrayList();
			ArrayList arrLabel3 = new ArrayList();

			ArrayList arrValue1 = new ArrayList();
			ArrayList arrValue2 = new ArrayList();
			ArrayList arrValue3 = new ArrayList();

			arrLabel.Add("------");
			arrLabel.Add("Name");
			arrLabel.Add("Name Phonetic");
			arrLabel.Add("Name Romaji");
			arrLabel.Add("Abbreviated Name");
			arrLabel.Add("Client");
			arrLabel.Add("Department");
			arrLabel.Add("Contact1");
			arrLabel.Add("Contact2");
			arrLabel.Add("Status");
			arrLabel.Add("------");
			arrLabel.Add("Test Initial");
			arrLabel.Add("Test Initial Form");
			arrLabel.Add("Test Mid Term");
			arrLabel.Add("Test Mid Term Form");
			arrLabel.Add("Test Final");
			arrLabel.Add("Test Final Form");
			arrLabel.Add("------");
			arrLabel.Add("Report Attendance");
			arrLabel.Add("Evaluation Midterm Form");
			arrLabel.Add("Evaluation Final Form");
			arrLabel.Add("Questionaire Mid Term Form");
			arrLabel.Add("Questionaire Final Form");
			arrLabel.Add("------");
			arrLabel.Add("Description");
			arrLabel.Add("------");
			arrLabel.Add("Special Remarks");

			ArrayList arrValues = new ArrayList();
			arrValues.Add("------");
			arrValues.Add(txtProgramName.Text);
			arrValues.Add(txtNamePhonetic.Text);
			arrValues.Add(txtNameRomaji.Text);
			arrValues.Add(txtNickName.Text);
			arrValues.Add(cmbClient.Text);
			arrValues.Add(cmbDept.Text);
			arrValues.Add(cmbContact1.Text);
			arrValues.Add(cmbContact2.Text);
			arrValues.Add(cmbStatus.Text);
			arrValues.Add("------");
			arrValues.Add(llblInitialEvt.Text);
			arrValues.Add(txtInitialEvent.Text);
			arrValues.Add(txtEvaluationMidtermForm.Text);
			arrValues.Add(txtEvaluationFinalForm.Text);
			arrValues.Add(txtQuestionaireMidtermForm.Text);
			arrValues.Add(txtQuestionaireFinalForm.Text);
			arrValues.Add("------");

			string sReportAttendance = string.Empty;
			if (rbtnNone.Checked)
				sReportAttendance = "None";
			else if (rbtnWeekly.Checked)
				sReportAttendance = "Weekly";
			else if (rbtnMonthly.Checked)
				sReportAttendance = "Monthly";
			else if (rbtnEnd.Checked)
				sReportAttendance = "End";
			else
				sReportAttendance = "None";

			arrValues.Add(sReportAttendance);
			arrValues.Add(txtEvaluationMidtermForm.Text);
			arrValues.Add(txtEvaluationFinalForm.Text);
			arrValues.Add(txtQuestionaireMidtermForm.Text);
			arrValues.Add(txtQuestionaireFinalForm.Text);
			arrValues.Add("RICHTEXT");
			arrValues.Add(txtDescription.Text);
			arrValues.Add("RICHTEXT");
			arrValues.Add(txtRemarks.Text);


			//Event//
			arrLabel1.Add("------");
			/*
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
            */

			foreach (string s in arrLabel1)
			{
				arrLabel2.Add(s);
				arrLabel3.Add(s);
            }
            #endregion
            //get the event data
			/*
            if (eventid[0] > 0)
				LoadEvent(eventid[0], ref arrValue1);
			if (eventid[1] > 0)
				LoadEvent(eventid[1], ref arrValue2);
			if (eventid[2] > 0)
				LoadEvent(eventid[2], ref arrValue3);

            */
			//nm = new NormalPrinting(arrLabel, arrValues, arrLabel1, arrValue1, arrValue2, arrValue3, printDocument1);
            xnm = new DevNormalPrinting(arrLabel, arrValues, arrLabel1, arrValue1, arrValue2, arrValue3, printingSystem1);

			//nm.PageNumber = 1;
			//nm.RowCount = 0;

            xnm.PageNumber = 1;
            xnm.RowCount = 0;
            xnm.RTitle = "Program Information";
            xnm.CreateDocument();
            xnm.PrintingSystem.PreviewFormEx.ShowDialog();
			//if (printPreviewDialog1.ShowDialog() == DialogResult.OK) {}
		}

		private NormalPrinting nm = null;

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
			DrawTopLabel(g);
			bool more = nm.DrawDataGrid(g);
			if (more == true)
			{
				e.HasMorePages = true;
				nm.PageNumber++;
			}
		}

		private void DrawTopLabel(Graphics g)
		{
			int TopMargin = printDocument1.DefaultPageSettings.Margins.Top;

			Font _font =
				new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Point, ((Byte) (0)));
			g.DrawString("Program Information", _font, new SolidBrush(label1.ForeColor), 20, 40, new StringFormat());
		}

    	private void btnPageSetup_Click(object sender, EventArgs e)
		{
			PrintingFunctions.ShowPageSettings(ref ps);
			printDocument1.DefaultPageSettings = ps;
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			if (BusinessLayer.Message.MsgConfirmation("Are you sure you want to return to the original data?") == DialogResult.No)
				return;

			LoadData();

			DoEventTabChange(false);
		}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEvent = new frmEventDlg();
            frmEvent.Mode = "Add";
            frmEvent.ProgramId = _programid;
            frmEvent.AllowExtraClasses = false;
            frmEvent.AllowTestInitial = !HasTestInitialEvent;
            frmEvent.AllowTestMid = !HasTestMidtermEvent;
            frmEvent.AllowTestFinal = !HasTestFinalEvent;

            if (frmEvent.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                LoadTestEvents();
            }
            frmEvent.Close();
            frmEvent.Dispose();
            frmEvent = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEvent = new frmEventDlg(int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolEventID).ToString()), int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolCaldendarEventID).ToString()));
            frmEvent.Mode = "Edit";
            frmEvent.ProgramId = _programid;
            frmEvent.AllowExtraClasses = false;

            //Re-load the Test events as well as the original Program data
            if (frmEvent.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                LoadTestEvents();
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
                int _eid, _ceid;
                string strEventType;
                bool boolSuccess = false;

                _ceid = int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolCaldendarEventID).ToString());
                _eid = int.Parse(gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolEventID).ToString());
                strEventType = gvwEvents.GetRowCellValue(gvwEvents.FocusedRowHandle, gcolEventType).ToString();

                objEvent = new Events();
                objEvent.EventID = _eid;
                objEvent.CalendarEventID = _ceid;
                objEvent.EventType = strEventType;

                boolSuccess = objEvent.DeleteTestEvent("Program",_programid);

                if (!boolSuccess)
                {
                    Scheduler.BusinessLayer.Message.ShowException("Deleting Event Data.", objEvent.Message);
                    return;
                }

                LoadData();
                LoadTestEvents();
            }            
        }

        private void grdEvents_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }
	}
}