using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlTypes;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Scheduler.BusinessLayer;
using Message=Scheduler.BusinessLayer.Message;
using System.Collections.Generic;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmEventBrw.
	/// </summary>
	public class frmEventBrw : Form
    {
        #region Declarations
        public Panel pnlBody;
		internal Panel pnl_SpeedSearch;
		internal Panel pnl_SpeedSearch1;
		internal TextBox txt_SpeedSearch;
		internal Label label1;
		public Panel pnl_Find;
		private Panel panel1;
		private PictureBox pictureBox1;
		internal TextBox txtSearch;
		internal CheckBox chk_Anywhere;
		internal Button btn_Clear;
		internal Button btn_Find;
		internal Label lbl_Find;
		internal CheckBox chk_AdvanceSearch;
		public GridColumn gColName;
		public GridColumn gcolPhonetic;
		public GridColumn gcolNameRomaji;
		private GridColumn gcolStatus;
		private GridColumn gcolDescription;
		private GridColumn gcolDateLastLogin;
		private GridColumn gcolDateCreated;
		private GridColumn gcolLastModified;
		private GridColumn gcolLastModifiedByUser;
		internal GridControl grdEvent;
		public GridView gvwEvent;
		public GridColumn gcolEventID;
		private GridColumn gcolEventType;
		private PersistentRepository persistentRepository1;
		private RepositoryItemTextEdit repositoryItemTextEdit1;
		private IContainer components;

		private Events objEvent=null;
		private GridColumn colStartDateTime;
		private GridColumn colEndDateTime;
		public GridColumn colCalendarEventID;
		public GridColumn gcolIsRecur;
		private GridColumn gcolClass;
		private GridColumn gcolProgram;
		private DataTable dtbl=null;
		private GridColumn gcolDept;
		private GridColumn gcolClient;
		private GridColumn gcolScheduledIns;
		private GridColumn gcolRealIns;
		private GridColumn gcolInstructor;
		private GridColumn gcolExceptionReason;
		private Panel pnlFilter;
		public ComboBox cmbClass;
		private Label lblClass;
		public ComboBox cmbProgram;
		private Label lblProgram;
		public ComboBox cmbInstructor;
		private Label lblInstructor;
		public ComboBox cmbClient;
		private Label lblClient;
		private Label lblMonth;
		private Label lblYear;
		private Panel pnlBrowse;
		private bool boolFetch=true;
		private bool isProcess=true;
		private Button btnClear;
		private DateTimePicker datePickerEnd;
        private DateTimePicker datePickerStart;
        public GridColumn gcolCourseId;
		private bool IsLoad=true;
        private GridColumn gcolDayOfWeek;
        private ImageList imgContext;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private GridColumn colDateAndTime;
        private bool IsAllow = false;
        #endregion

        public frmEventBrw()
		{
			InitializeComponent();
			pnl_Find.Height = 0;
			pnl_Find.Visible=true;

			try
			{
				Common.SetControlFont(pnl_Find);				
				Common.SetGridFont(grdEvent);
			}
			catch{}

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventBrw));
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlBrowse = new System.Windows.Forms.Panel();
            this.grdEvent = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gvwEvent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalendarEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolPhonetic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolScheduledIns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolRealIns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDateLastLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDateCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastModified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastModifiedByUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolIsRecur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolInstructor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolExceptionReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCourseId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDayOfWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateAndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbInstructor = new System.Windows.Forms.ComboBox();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.pnl_SpeedSearch = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch1 = new System.Windows.Forms.Panel();
            this.txt_SpeedSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Find = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chk_Anywhere = new System.Windows.Forms.CheckBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.lbl_Find = new System.Windows.Forms.Label();
            this.chk_AdvanceSearch = new System.Windows.Forms.CheckBox();
            this.imgContext = new System.Windows.Forms.ImageList(this.components);
            this.pnlBody.SuspendLayout();
            this.pnlBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvent)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwEvent)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnl_SpeedSearch.SuspendLayout();
            this.pnl_SpeedSearch1.SuspendLayout();
            this.pnl_Find.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcolStatus
            // 
            this.gcolStatus.Caption = "Status";
            this.gcolStatus.FieldName = "EventStatus";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.Width = 70;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlBrowse);
            this.pnlBody.Controls.Add(this.pnlFilter);
            this.pnlBody.Controls.Add(this.pnl_SpeedSearch);
            this.pnlBody.Controls.Add(this.pnl_Find);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(760, 430);
            this.pnlBody.TabIndex = 30;
            this.pnlBody.Resize += new System.EventHandler(this.pnlBody_Resize);
            // 
            // pnlBrowse
            // 
            this.pnlBrowse.Controls.Add(this.grdEvent);
            this.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowse.Location = new System.Drawing.Point(0, 154);
            this.pnlBrowse.Name = "pnlBrowse";
            this.pnlBrowse.Size = new System.Drawing.Size(760, 276);
            this.pnlBrowse.TabIndex = 45;
            // 
            // grdEvent
            // 
            this.grdEvent.ContextMenuStrip = this.contextMenuStrip1;
            this.grdEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEvent.EmbeddedNavigator.Name = "";
            this.grdEvent.ExternalRepository = this.persistentRepository1;
            this.grdEvent.Location = new System.Drawing.Point(0, 0);
            this.grdEvent.MainView = this.gvwEvent;
            this.grdEvent.Name = "grdEvent";
            this.grdEvent.Size = new System.Drawing.Size(760, 276);
            this.grdEvent.TabIndex = 26;
            this.grdEvent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwEvent});
            this.grdEvent.DoubleClick += new System.EventHandler(this.grdEvent_DoubleClick);
            this.grdEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdEvent_KeyPress);
            this.grdEvent.Click += new System.EventHandler(this.grdEvent_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AllowFocused = false;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gvwEvent
            // 
            this.gvwEvent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvwEvent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolEventID,
            this.colCalendarEventID,
            this.colStartDateTime,
            this.colEndDateTime,
            this.gColName,
            this.gcolClass,
            this.gcolProgram,
            this.gcolDescription,
            this.gcolPhonetic,
            this.gcolNameRomaji,
            this.gcolEventType,
            this.gcolScheduledIns,
            this.gcolRealIns,
            this.gcolStatus,
            this.gcolDateLastLogin,
            this.gcolDateCreated,
            this.gcolLastModified,
            this.gcolLastModifiedByUser,
            this.gcolIsRecur,
            this.gcolDept,
            this.gcolClient,
            this.gcolInstructor,
            this.gcolExceptionReason,
            this.gcolCourseId,
            this.gcolDayOfWeek,
            this.colDateAndTime});
            this.gvwEvent.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvwEvent.GridControl = this.grdEvent;
            this.gvwEvent.Name = "gvwEvent";
            this.gvwEvent.OptionsBehavior.Editable = false;
            this.gvwEvent.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gvwEvent.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvwEvent.OptionsView.ShowDetailButtons = false;
            this.gvwEvent.OptionsView.ShowGroupPanel = false;
            this.gvwEvent.OptionsView.ShowHorzLines = false;
            this.gvwEvent.OptionsView.ShowIndicator = false;
            this.gvwEvent.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolClass, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvwEvent.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwEvent_RowCellStyle);
            // 
            // gcolEventID
            // 
            this.gcolEventID.Caption = "Event ID";
            this.gcolEventID.FieldName = "EventID";
            this.gcolEventID.Name = "gcolEventID";
            // 
            // colCalendarEventID
            // 
            this.colCalendarEventID.Caption = "CalendarEventID";
            this.colCalendarEventID.FieldName = "CalendarEventID";
            this.colCalendarEventID.Name = "colCalendarEventID";
            // 
            // colStartDateTime
            // 
            this.colStartDateTime.Caption = "Start Date";
            this.colStartDateTime.DisplayFormat.FormatString = "MM/dd/yyyy HH:mm";
            this.colStartDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartDateTime.FieldName = "StartDateTime";
            this.colStartDateTime.MinWidth = 90;
            this.colStartDateTime.Name = "colStartDateTime";
            this.colStartDateTime.Width = 105;
            // 
            // colEndDateTime
            // 
            this.colEndDateTime.Caption = "End Date";
            this.colEndDateTime.DisplayFormat.FormatString = "MM/dd/yyyy HH:mm";
            this.colEndDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndDateTime.FieldName = "EndDateTime";
            this.colEndDateTime.MinWidth = 90;
            this.colEndDateTime.Name = "colEndDateTime";
            this.colEndDateTime.Width = 90;
            // 
            // gColName
            // 
            this.gColName.Caption = "Event Name";
            this.gColName.FieldName = "Name";
            this.gColName.Name = "gColName";
            this.gColName.Visible = true;
            this.gColName.VisibleIndex = 5;
            this.gColName.Width = 93;
            // 
            // gcolClass
            // 
            this.gcolClass.Caption = "Class";
            this.gcolClass.FieldName = "Class";
            this.gcolClass.Name = "gcolClass";
            this.gcolClass.Width = 98;
            // 
            // gcolProgram
            // 
            this.gcolProgram.Caption = "Program";
            this.gcolProgram.FieldName = "Program";
            this.gcolProgram.Name = "gcolProgram";
            this.gcolProgram.Visible = true;
            this.gcolProgram.VisibleIndex = 4;
            this.gcolProgram.Width = 82;
            // 
            // gcolDescription
            // 
            this.gcolDescription.Caption = "Description";
            this.gcolDescription.FieldName = "Description";
            this.gcolDescription.Name = "gcolDescription";
            this.gcolDescription.Width = 114;
            // 
            // gcolPhonetic
            // 
            this.gcolPhonetic.Caption = "Name Phonetic";
            this.gcolPhonetic.FieldName = "NamePhonetic";
            this.gcolPhonetic.Name = "gcolPhonetic";
            this.gcolPhonetic.Width = 90;
            // 
            // gcolNameRomaji
            // 
            this.gcolNameRomaji.Caption = "Name Romaji";
            this.gcolNameRomaji.FieldName = "NameRomaji";
            this.gcolNameRomaji.Name = "gcolNameRomaji";
            this.gcolNameRomaji.Width = 90;
            // 
            // gcolEventType
            // 
            this.gcolEventType.Caption = "Event Type";
            this.gcolEventType.FieldName = "EventType";
            this.gcolEventType.Name = "gcolEventType";
            this.gcolEventType.Width = 61;
            // 
            // gcolScheduledIns
            // 
            this.gcolScheduledIns.Caption = "Scheduled Instructor";
            this.gcolScheduledIns.FieldName = "ScheduledTeacher";
            this.gcolScheduledIns.Name = "gcolScheduledIns";
            this.gcolScheduledIns.Visible = true;
            this.gcolScheduledIns.VisibleIndex = 6;
            this.gcolScheduledIns.Width = 72;
            // 
            // gcolRealIns
            // 
            this.gcolRealIns.Caption = "Actual Instructor";
            this.gcolRealIns.FieldName = "RealTeacher";
            this.gcolRealIns.Name = "gcolRealIns";
            this.gcolRealIns.Width = 80;
            // 
            // gcolDateLastLogin
            // 
            this.gcolDateLastLogin.Caption = "Date Last Login";
            this.gcolDateLastLogin.FieldName = "DatelastLogin";
            this.gcolDateLastLogin.Name = "gcolDateLastLogin";
            // 
            // gcolDateCreated
            // 
            this.gcolDateCreated.Caption = "Date Created";
            this.gcolDateCreated.FieldName = "DateCreated";
            this.gcolDateCreated.Name = "gcolDateCreated";
            // 
            // gcolLastModified
            // 
            this.gcolLastModified.Caption = "Date Last Modified";
            this.gcolLastModified.FieldName = "DateLastModified";
            this.gcolLastModified.Name = "gcolLastModified";
            // 
            // gcolLastModifiedByUser
            // 
            this.gcolLastModifiedByUser.Caption = "Last Modified User ID";
            this.gcolLastModifiedByUser.FieldName = "LastModifiedByUserID";
            this.gcolLastModifiedByUser.Name = "gcolLastModifiedByUser";
            // 
            // gcolIsRecur
            // 
            this.gcolIsRecur.Caption = "IsRecur";
            this.gcolIsRecur.FieldName = "RecurrenceText";
            this.gcolIsRecur.Name = "gcolIsRecur";
            // 
            // gcolDept
            // 
            this.gcolDept.Caption = "Department";
            this.gcolDept.FieldName = "Department";
            this.gcolDept.Name = "gcolDept";
            this.gcolDept.Visible = true;
            this.gcolDept.VisibleIndex = 3;
            this.gcolDept.Width = 85;
            // 
            // gcolClient
            // 
            this.gcolClient.Caption = "Client";
            this.gcolClient.FieldName = "Client";
            this.gcolClient.Name = "gcolClient";
            this.gcolClient.Visible = true;
            this.gcolClient.VisibleIndex = 2;
            this.gcolClient.Width = 85;
            // 
            // gcolInstructor
            // 
            this.gcolInstructor.Caption = "Actual Instructor";
            this.gcolInstructor.FieldName = "Instructor";
            this.gcolInstructor.Name = "gcolInstructor";
            this.gcolInstructor.Visible = true;
            this.gcolInstructor.VisibleIndex = 7;
            this.gcolInstructor.Width = 72;
            // 
            // gcolExceptionReason
            // 
            this.gcolExceptionReason.Caption = "Exception Reason";
            this.gcolExceptionReason.FieldName = "ExceptionReason";
            this.gcolExceptionReason.Name = "gcolExceptionReason";
            this.gcolExceptionReason.Visible = true;
            this.gcolExceptionReason.VisibleIndex = 8;
            this.gcolExceptionReason.Width = 84;
            // 
            // gcolCourseId
            // 
            this.gcolCourseId.Caption = "CourseId";
            this.gcolCourseId.FieldName = "CourseID";
            this.gcolCourseId.Name = "gcolCourseId";
            // 
            // gcolDayOfWeek
            // 
            this.gcolDayOfWeek.Caption = "Day Of Week";
            this.gcolDayOfWeek.FieldName = "DayOfWeek";
            this.gcolDayOfWeek.Name = "gcolDayOfWeek";
            this.gcolDayOfWeek.Visible = true;
            this.gcolDayOfWeek.VisibleIndex = 1;
            this.gcolDayOfWeek.Width = 67;
            // 
            // colDateAndTime
            // 
            this.colDateAndTime.Caption = "Date and Time";
            this.colDateAndTime.DisplayFormat.FormatString = "G";
            this.colDateAndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateAndTime.FieldName = "DateAndTime";
            this.colDateAndTime.Name = "colDateAndTime";
            this.colDateAndTime.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colDateAndTime.Visible = true;
            this.colDateAndTime.VisibleIndex = 0;
            this.colDateAndTime.Width = 116;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.GrayText;
            this.pnlFilter.Controls.Add(this.datePickerEnd);
            this.pnlFilter.Controls.Add(this.datePickerStart);
            this.pnlFilter.Controls.Add(this.btnClear);
            this.pnlFilter.Controls.Add(this.cmbClass);
            this.pnlFilter.Controls.Add(this.lblClass);
            this.pnlFilter.Controls.Add(this.cmbProgram);
            this.pnlFilter.Controls.Add(this.lblProgram);
            this.pnlFilter.Controls.Add(this.cmbInstructor);
            this.pnlFilter.Controls.Add(this.lblInstructor);
            this.pnlFilter.Controls.Add(this.cmbClient);
            this.pnlFilter.Controls.Add(this.lblClient);
            this.pnlFilter.Controls.Add(this.lblMonth);
            this.pnlFilter.Controls.Add(this.lblYear);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 90);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(760, 64);
            this.pnlFilter.TabIndex = 44;
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Checked = false;
            this.datePickerEnd.CustomFormat = "MM/dd/yyyy";
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEnd.Location = new System.Drawing.Point(190, 37);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.ShowCheckBox = true;
            this.datePickerEnd.Size = new System.Drawing.Size(96, 21);
            this.datePickerEnd.TabIndex = 15;
            this.datePickerEnd.ValueChanged += new System.EventHandler(this.datePickerValueChanged);
            // 
            // datePickerStart
            // 
            this.datePickerStart.Checked = false;
            this.datePickerStart.CustomFormat = "MM/dd/yyyy";
            this.datePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerStart.Location = new System.Drawing.Point(190, 9);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.ShowCheckBox = true;
            this.datePickerStart.Size = new System.Drawing.Size(96, 21);
            this.datePickerStart.TabIndex = 14;
            this.datePickerStart.ValueChanged += new System.EventHandler(this.datePickerValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(10, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear All Filters";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ItemHeight = 13;
            this.cmbClass.Items.AddRange(new object[] {
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
            this.cmbClass.Location = new System.Drawing.Point(584, 35);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(144, 21);
            this.cmbClass.TabIndex = 12;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(512, 39);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(36, 13);
            this.lblClass.TabIndex = 11;
            this.lblClass.Text = "Class";
            // 
            // cmbProgram
            // 
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Items.AddRange(new object[] {
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
            this.cmbProgram.Location = new System.Drawing.Point(584, 9);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(144, 21);
            this.cmbProgram.TabIndex = 10;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgram.Location = new System.Drawing.Point(512, 12);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(56, 13);
            this.lblProgram.TabIndex = 9;
            this.lblProgram.Text = "Program";
            // 
            // cmbInstructor
            // 
            this.cmbInstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInstructor.ItemHeight = 13;
            this.cmbInstructor.Items.AddRange(new object[] {
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
            this.cmbInstructor.Location = new System.Drawing.Point(364, 34);
            this.cmbInstructor.Name = "cmbInstructor";
            this.cmbInstructor.Size = new System.Drawing.Size(131, 21);
            this.cmbInstructor.TabIndex = 8;
            this.cmbInstructor.SelectedIndexChanged += new System.EventHandler(this.cmbInstructor_SelectedIndexChanged);
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructor.Location = new System.Drawing.Point(292, 38);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(65, 13);
            this.lblInstructor.TabIndex = 7;
            this.lblInstructor.Text = "Instructor";
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Items.AddRange(new object[] {
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
            this.cmbClient.Location = new System.Drawing.Point(364, 8);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(131, 21);
            this.cmbClient.TabIndex = 6;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(292, 11);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 5;
            this.lblClient.Text = "Client";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(120, 40);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(57, 13);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "End Date";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(120, 13);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(66, 13);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Start Date";
            // 
            // pnl_SpeedSearch
            // 
            this.pnl_SpeedSearch.BackColor = System.Drawing.Color.Black;
            this.pnl_SpeedSearch.Controls.Add(this.pnl_SpeedSearch1);
            this.pnl_SpeedSearch.Location = new System.Drawing.Point(64, 288);
            this.pnl_SpeedSearch.Name = "pnl_SpeedSearch";
            this.pnl_SpeedSearch.Size = new System.Drawing.Size(192, 72);
            this.pnl_SpeedSearch.TabIndex = 42;
            this.pnl_SpeedSearch.Visible = false;
            // 
            // pnl_SpeedSearch1
            // 
            this.pnl_SpeedSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(143)))), ((int)(((byte)(230)))));
            this.pnl_SpeedSearch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_SpeedSearch1.Controls.Add(this.txt_SpeedSearch);
            this.pnl_SpeedSearch1.Controls.Add(this.label1);
            this.pnl_SpeedSearch1.Location = new System.Drawing.Point(4, 4);
            this.pnl_SpeedSearch1.Name = "pnl_SpeedSearch1";
            this.pnl_SpeedSearch1.Size = new System.Drawing.Size(184, 64);
            this.pnl_SpeedSearch1.TabIndex = 39;
            // 
            // txt_SpeedSearch
            // 
            this.txt_SpeedSearch.Location = new System.Drawing.Point(11, 29);
            this.txt_SpeedSearch.Name = "txt_SpeedSearch";
            this.txt_SpeedSearch.Size = new System.Drawing.Size(157, 21);
            this.txt_SpeedSearch.TabIndex = 10;
            this.txt_SpeedSearch.TextChanged += new System.EventHandler(this.txt_SpeedSearch_TextChanged);
            this.txt_SpeedSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SpeedSearch_KeyDown);
            this.txt_SpeedSearch.Leave += new System.EventHandler(this.txt_SpeedSearch_Leave);
            this.txt_SpeedSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_SpeedSearch_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fast Search";
            // 
            // pnl_Find
            // 
            this.pnl_Find.BackColor = System.Drawing.SystemColors.Window;
            this.pnl_Find.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Find.Controls.Add(this.panel1);
            this.pnl_Find.Controls.Add(this.txtSearch);
            this.pnl_Find.Controls.Add(this.chk_Anywhere);
            this.pnl_Find.Controls.Add(this.btn_Clear);
            this.pnl_Find.Controls.Add(this.btn_Find);
            this.pnl_Find.Controls.Add(this.lbl_Find);
            this.pnl_Find.Controls.Add(this.chk_AdvanceSearch);
            this.pnl_Find.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Find.Location = new System.Drawing.Point(0, 0);
            this.pnl_Find.Name = "pnl_Find";
            this.pnl_Find.Size = new System.Drawing.Size(760, 90);
            this.pnl_Find.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(580, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 86);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(64, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(296, 21);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // chk_Anywhere
            // 
            this.chk_Anywhere.BackColor = System.Drawing.SystemColors.Window;
            this.chk_Anywhere.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk_Anywhere.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Anywhere.Location = new System.Drawing.Point(210, 44);
            this.chk_Anywhere.Name = "chk_Anywhere";
            this.chk_Anywhere.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk_Anywhere.Size = new System.Drawing.Size(154, 24);
            this.chk_Anywhere.TabIndex = 7;
            this.chk_Anywhere.Text = "Search Anywhere in Fields";
            this.chk_Anywhere.UseVisualStyleBackColor = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Clear.Location = new System.Drawing.Point(370, 44);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Find.Location = new System.Drawing.Point(370, 15);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(75, 23);
            this.btn_Find.TabIndex = 4;
            this.btn_Find.Text = "Find";
            this.btn_Find.UseVisualStyleBackColor = false;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // lbl_Find
            // 
            this.lbl_Find.AutoSize = true;
            this.lbl_Find.Location = new System.Drawing.Point(15, 19);
            this.lbl_Find.Name = "lbl_Find";
            this.lbl_Find.Size = new System.Drawing.Size(30, 13);
            this.lbl_Find.TabIndex = 0;
            this.lbl_Find.Text = " Find";
            // 
            // chk_AdvanceSearch
            // 
            this.chk_AdvanceSearch.BackColor = System.Drawing.SystemColors.Window;
            this.chk_AdvanceSearch.Checked = true;
            this.chk_AdvanceSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_AdvanceSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk_AdvanceSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_AdvanceSearch.Location = new System.Drawing.Point(64, 44);
            this.chk_AdvanceSearch.Name = "chk_AdvanceSearch";
            this.chk_AdvanceSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk_AdvanceSearch.Size = new System.Drawing.Size(112, 24);
            this.chk_AdvanceSearch.TabIndex = 8;
            this.chk_AdvanceSearch.Text = "Search All Fields";
            this.chk_AdvanceSearch.UseVisualStyleBackColor = false;
            // 
            // imgContext
            // 
            this.imgContext.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgContext.ImageStream")));
            this.imgContext.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imgContext.Images.SetKeyName(0, "");
            this.imgContext.Images.SetKeyName(1, "");
            // 
            // frmEventBrw
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(760, 430);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmEventBrw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEventBrw";
            this.Load += new System.EventHandler(this.frmEventBrw_Load);
            this.Resize += new System.EventHandler(this.frmEventBrw_Resize);
            this.pnlBody.ResumeLayout(false);
            this.pnlBrowse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEvent)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwEvent)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnl_SpeedSearch.ResumeLayout(false);
            this.pnl_SpeedSearch1.ResumeLayout(false);
            this.pnl_SpeedSearch1.PerformLayout();
            this.pnl_Find.ResumeLayout(false);
            this.pnl_Find.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void FindPanel()
		{
			pnl_Find.Visible=true;
			if(pnl_Find.Height == 90)
				pnl_Find.Height = 0;
			else
			{
				while(pnl_Find.Height < 90)
				{
					pnl_Find.Height = pnl_Find.Height + 5;
					pnl_Find.Refresh();
					txtSearch.Focus();
				}
			}
		}

		public int GetRecordCount()
		{
			return gvwEvent.RowCount;
		}

		private void frmEventBrw_Load(object sender, EventArgs e)
		{
			LoadEvent();		
		}

		public void LoadEvent()
		{
			isProcess=false;
			int year=0, month=0;

			DateTime dtStart = SqlDateTime.MinValue.Value;
			DateTime dtEnd = SqlDateTime.MaxValue.Value;

			if(IsLoad)
			{
				PopulateDropDowns();
				LoadFilterSettings();
			
			}

            if (datePickerStart.Checked)
                dtStart = datePickerStart.Value;

            if (datePickerEnd.Checked)
                dtEnd = datePickerEnd.Value;

			IsLoad=false;

			objEvent = new Events();
			//dtbl = objEvent.LoadData(dtStart, dtEnd, cmbClient.Text, cmbInstructor.Text, cmbProgram.Text, cmbClass.Text);
            dtbl = objEvent.LoadData(dtStart, dtEnd, ((ValuePair)cmbClient.SelectedItem).Value, ((ValuePair)cmbInstructor.SelectedItem).Value, "", "",true);
			grdEvent.DataSource = dtbl;
			isProcess = true;

		}

		private void frmEventBrw_Resize(object sender, EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void SpeedSearch()
		{
			int iRowPos = gvwEvent.FocusedRowHandle;
			string strGridValue = "";
			foreach(GridColumn col in gvwEvent.Columns)
			{
				if(col.SortIndex>=0)
				{
					for(int intCtr=0;intCtr<gvwEvent.RowCount;intCtr++)
					{
						if(col.VisibleIndex>-1)
						{
							if(gvwEvent.GetRowCellValue(intCtr, col) !=DBNull.Value)
							{
								strGridValue = gvwEvent.GetRowCellValue(intCtr, col).ToString();
								if(strGridValue.ToUpper().Trim().StartsWith(txt_SpeedSearch.Text.Trim().ToUpper()))
								{
									gvwEvent.FocusedRowHandle = intCtr;
									break;
								}
							}
						}
					}
				}
			}
		}

		private void txt_SpeedSearch_Leave(object sender, EventArgs e)
		{
			pnl_SpeedSearch.Visible = false;
			this.KeyPreview = true;
		}

		private void txt_SpeedSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if((e.KeyData == Keys.Enter) || (e.KeyData == Keys.Escape))
			{
				pnl_SpeedSearch.Visible = false;
				grdEvent.Focus();
				grdEvent.Select();
			}
		}

		private void txt_SpeedSearch_KeyUp(object sender, KeyEventArgs e)
		{
			SpeedSearch();
		}

		private void txt_SpeedSearch_TextChanged(object sender, EventArgs e)
		{
			SpeedSearch();
		}
        public void OpenEvent()
        {
            int row = 0;
            int intEventID = 0;
            bool IsRecur = false;

            row = gvwEvent.FocusedRowHandle;

            if (gvwEvent.FocusedRowHandle < 0)
            {
                Message.MsgInformation("No record exists.");
                return;
            }

            intEventID = Convert.ToInt32(gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, gcolEventID));
            int intCalID = Convert.ToInt32(gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, colCalendarEventID).ToString());
            //int CourseID = Common.ConvertToInteger(gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, gcolCourseId).ToString());
            //int ProgramID = Common.ConvertToInteger(gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, gcolProgramId).ToString());
            string strEventType = gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, gcolEventType).ToString();

            if (gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, gcolIsRecur).ToString() != "")
                IsRecur = true;

            int Option = -1;

            if (IsRecur)
            {
                if (strEventType != "Extra Class")
                {
                    frmOpenEvents frmOpenEvt = new frmOpenEvents();
                    if (frmOpenEvt.ShowDialog() == DialogResult.OK)
                    {
                        Option = frmOpenEvt.Option;
                    }
                    else
                    {
                        frmOpenEvt.Close();
                        frmOpenEvt.Dispose();
                        return;
                    }
                }
            }

            frmEventDlg fEvtDlg = null;
            //Option '0' means a single occurence and '1' means the entire series
            if (Option == 1)
            {
                //fEvtDlg=new frmEventDlg(intEventID, intCalID);
                //fEvtDlg.Mode="Edit";
                //fEvtDlg.EventID = intEventID;
                //fEvtDlg.LoadData();

                string module = string.Empty;
                int _uid = 0;
                int _eventtypeindex = 0;
                Events objEvent = new Events();
                //Returns Course/Program ID
                _uid = objEvent.GetEvent(intEventID, ref module, ref _eventtypeindex);

                if (module != "")
                {
                    if (module == "Class")
                    {
                        frmClassDlg frm = new frmClassDlg(_uid, _eventtypeindex, intCalID);
                        frm.Mode = "Edit";
                       //if (frm.ShowDialog() == DialogResult.OK)
                        frm.ShowDialog();
                        {
                            LoadEvent();
                            frm.Close();
                            frm.Dispose();
                            frm = null;
                        }
                    }
                    else if (module == "Program")
                    {
                        frmProgramDlg frm = new frmProgramDlg(_uid, _eventtypeindex);
                        frm.Mode = "Edit";
                        //if (frm.ShowDialog() == DialogResult.OK)
                        frm.ShowDialog();
                        {
                            LoadEvent();
                            frm.Close();
                            frm.Dispose();
                            frm = null;
                        }
                    }
                }
                //				else
                //				{
                //					fEvtDlg=new frmEventDlg();
                //					fEvtDlg.Mode="Edit";
                //					fEvtDlg.EventID = intEventID;
                //					fEvtDlg.LoadData();
                //				}
            }
            /*else if(Option==-1 && strEventType!="Event")
            {
                //For Extra Classes and Test Events;
                fEvtDlg = new frmEventDlg(int.Parse(gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, gcolEventID).ToString()), int.Parse(gvwEvent.GetRowCellValue(gvwEvent.FocusedRowHandle, colCalendarEventID).ToString()));
                fEvtDlg.Mode = "Edit";
                fEvtDlg.CourseId = CourseID;

                Course _course = new Course();
                _course.CourseID = CourseID;
                _course.LoadData();
                fEvtDlg.AllowExtraClasses = _course.IsRecurring();
                if (fEvtDlg.ShowDialog() == DialogResult.OK)
                    LoadEvent();
                fEvtDlg.Close();
                fEvtDlg.Dispose();
                fEvtDlg = null;
            }*/
            else
            {
                string module = string.Empty;
                int _uid = 0;
                int _eventtypeindex = 0;
                Events objEvent = new Events();
                _uid = objEvent.GetEvent(intEventID, ref module, ref _eventtypeindex);
                if (strEventType == "Extra Class") _eventtypeindex = 4;

                if (module != "")
                {
                    if (module == "Class")
                    {
                        frmClassDlg frm = new frmClassDlg(_uid, _eventtypeindex);
                        frm.Mode = "Edit";
                     //   if (frm.ShowDialog() == DialogResult.OK)
                        frm.ShowDialog();
                        {
                            LoadEvent();
                            frm.Close();
                            frm.Dispose();
                            frm = null;
                        }
                    }
                    else if (module == "Program")
                    {
                        frmProgramDlg frm = new frmProgramDlg(_uid, _eventtypeindex);
                        frm.Mode = "Edit";
                     //   if (frm.ShowDialog() == DialogResult.OK)
                        frm.ShowDialog();
                        {
                            LoadEvent();
                            frm.Close();
                            frm.Dispose();
                            frm = null;
                        }
                    }
                }
                //				else
                //				{
                //					fEvtDlg=new frmEventDlg();
                //					fEvtDlg.Mode="Edit";
                //					fEvtDlg.EventID = intEventID;
                //					fEvtDlg.LoadData();
                //				}
            }
            /*
            if(fEvtDlg!=null)
            {
                if(fEvtDlg.ShowDialog()==DialogResult.OK)
                {
                    LoadEvent();
                }

                fEvtDlg.Close();
                fEvtDlg.Dispose();
                fEvtDlg=null;
            }
            */
            gvwEvent.FocusedRowHandle = row;
        }
		private void grdEvent_DoubleClick(object sender, EventArgs e)
		{
            OpenEvent();
		}

		private void btn_Find_Click(object sender, EventArgs e)
		{
			if (boolFetch==false) LoadEvent();
			FindRoutine();
		}

		private void btn_Clear_Click(object sender, EventArgs e)
		{
			txtSearch.Text = "";
			LoadEvent();
		}

		private void grdEvent_KeyPress(object sender, KeyPressEventArgs e)
		{
			if((Convert.ToByte(e.KeyChar) > 47) && (Convert.ToByte(e.KeyChar) < 255))
			{
				if(!txtSearch.Focused)
				{
					pnl_SpeedSearch.Visible = true;
					txt_SpeedSearch.Focus();
					txt_SpeedSearch.Text = e.KeyChar.ToString();
					txt_SpeedSearch.Select(1, 1);

					if(Convert.ToByte(e.KeyChar) == 13)
					{
						pnl_SpeedSearch.Visible = false;
						grdEvent.Focus();
						grdEvent.Select();
					}
				}
			}
		}

		private void FindRoutine()
		{
			gvwEvent.BeginUpdate();
			try
			{
				if (txtSearch.Text.Trim() == "") return;

				//Creating Temp. Table
				DataTable Tempdtbl = new DataTable("TEMPTABLE");
				Tempdtbl = dtbl.Copy();
				dtbl.Rows.Clear();
			
			
				DataRowCollection CollSearchRow = Tempdtbl.Rows;
				bool boolFound = false; 			
				string strCellVal = "";
				int intMaxColCtr=0;			
				string strFindText = txtSearch.Text.Trim();

				if(strFindText.EndsWith(".00"))
					strFindText = strFindText.Substring(0, strFindText.Length -3);
				if(strFindText.EndsWith(".0"))
					strFindText = strFindText.Substring(0, strFindText.Length -2);

				if(chk_AdvanceSearch.Checked)
				{
					intMaxColCtr = Tempdtbl.Columns.Count - 1;
				}
				else
				{
					intMaxColCtr = 3;
				}

				for (int intRowCtr = 0; intRowCtr <= CollSearchRow.Count-1;intRowCtr++)
				{
					DataRow SearchRow = CollSearchRow[intRowCtr];				
					boolFound = false; 
					strCellVal = "";
					for (int intColCtr = 1; intColCtr <= intMaxColCtr;intColCtr++)
					{
						strCellVal = SearchRow[intColCtr].ToString().Trim().ToUpper();
						if (chk_Anywhere.Checked)
						{
							if (strCellVal.IndexOf(strFindText.ToUpper())>=0)
							{
								boolFound = true;
								break;							
							}
						}
						else
						{
							if (strCellVal.StartsWith(strFindText.ToUpper()))
							{
								boolFound = true;
								break;
							}
						}					
					}	
					if (boolFound)
					{
						boolFetch=false;					
						dtbl.Rows.Add(new object[] 
						{
							CollSearchRow[intRowCtr]["EventID"],
							CollSearchRow[intRowCtr]["CalendarEventID"],
							CollSearchRow[intRowCtr]["RepeatRule"],
							CollSearchRow[intRowCtr]["NegetiveException"],
							CollSearchRow[intRowCtr]["Note"],
							CollSearchRow[intRowCtr]["RecurrenceText"],
							CollSearchRow[intRowCtr]["Description"],
							CollSearchRow[intRowCtr]["EventStatus"],
							CollSearchRow[intRowCtr]["StartDateTime"],
							CollSearchRow[intRowCtr]["EndDateTime"],
							CollSearchRow[intRowCtr]["DateCompleted"],
							CollSearchRow[intRowCtr]["Name"],
							CollSearchRow[intRowCtr]["NamePhonetic"],
							CollSearchRow[intRowCtr]["NameRomaji"],
							CollSearchRow[intRowCtr]["Location"],
							CollSearchRow[intRowCtr]["BlockCode"],
							CollSearchRow[intRowCtr]["RoomNumber"],
							CollSearchRow[intRowCtr]["ScheduledTeacherID"],
							CollSearchRow[intRowCtr]["RealTeacherID"],
							CollSearchRow[intRowCtr]["ChangeReason"],
							CollSearchRow[intRowCtr]["IsHoliday"],
							CollSearchRow[intRowCtr]["EventType"],
							CollSearchRow[intRowCtr]["ExceptionReason"],
							CollSearchRow[intRowCtr]["ScheduledTeacher"],
							CollSearchRow[intRowCtr]["RealTeacher"],
							CollSearchRow[intRowCtr]["CourseID"],
							CollSearchRow[intRowCtr]["Class"],
							CollSearchRow[intRowCtr]["ProgramID"],
							CollSearchRow[intRowCtr]["Program"],
							CollSearchRow[intRowCtr]["Department"],
							CollSearchRow[intRowCtr]["Client"],
							CollSearchRow[intRowCtr]["TestEvent"],
							CollSearchRow[intRowCtr]["Instructor"]
						});
					}
				}	

				dtbl.AcceptChanges();
			}
			finally
			{
				gvwEvent.EndUpdate();
			}
		}

		private void pnlBody_Resize(object sender, EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData==Keys.Enter)
			{
				btn_Find_Click(sender, null);
			}
		}

		public void PopulateDropDowns()
		{
			Common.PopulateDropdownWithValue(
				cmbClient, "Select CompanyName, DisplayName = CASE " +
                "WHEN NickName IS NULL OR NickName = '' THEN CompanyName " +
				//"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 and " +
				"ContactStatus=0 Order By DisplayName ");
            //IDataReader reader = DAC.SelectStatement("Select");
            List<string> contacts = new List<string>();
            bool found = false;
            for (int i = 0; i < cmbClient.Items.Count; i++)
            {
                Scheduler.BusinessLayer.ValuePair p = cmbClient.Items[i] as Scheduler.BusinessLayer.ValuePair;
                found = false;
                foreach (string str in contacts)
                {
                    if (p.Name == str)
                    {
                        found = true;
                    }
                }
                if (!found)
                    contacts.Add(p.Name);
                else
                    cmbClient.Items.RemoveAt(i);
            }
			Common.PopulateDropdownWithValue(
                cmbInstructor, "Select LastName + ', ' + FirstName, " +
				"TeacherName = CASE " +
                "WHEN NickName IS NULL OR NickName = '' THEN LastName + ', ' + FirstName " +
				//"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 and " +
				"ContactStatus=0 Order By LastName, FirstName ");
            
            contacts.Clear();
            for (int i = 0; i < cmbInstructor.Items.Count; i++)
            {
                Scheduler.BusinessLayer.ValuePair p = cmbInstructor.Items[i] as Scheduler.BusinessLayer.ValuePair;
                found = false;
                foreach (string str in contacts)
                {
                    if (p.Name == str)
                    {
                        found = true;
                    }
                }
                if (!found)
                    contacts.Add(p.Name);
                else
                    cmbInstructor.Items.RemoveAt(i);
            }
			Common.PopulateDropdownWithValue(
				cmbClass, "Select Distinct [Name], ClassName = CASE " +
				"WHEN NickName IS NULL THEN Name " +
				"WHEN NickName = '' THEN Name " +
				"ELSE NickName " +
				"END " +
				"From Course Where CourseStatus=0 " +  //and ProgramID=" + intProgramID + 
				" Order By ClassName ");

			Common.PopulateDropdownWithValue(
				cmbProgram, "Select Distinct [Name], ProgramName = CASE " +
				"WHEN NickName IS NULL THEN Name " +
				"WHEN NickName = '' THEN Name " +
				"ELSE NickName " +
				"END " +
				"From Program Where ProgramStatus=0 " +// and DepartmentID=" + intDepartmentID + 
				" Order By ProgramName ");
		}

		private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (IsAllow)
            {
                CalendarFilter.ClientName = cmbClient.Text;

                //CalendarFilter.ProgramName = cmbProgram.Text;
                if (CalendarFilter.ClientName == "")
                {
                    gvwEvent.ActiveFilter.Remove(gcolClient);
                }
                else
                    gvwEvent.ActiveFilter.Add(gcolClient, new ColumnFilterInfo("Client = '" + CalendarFilter.ClientName + "'"));
                //gvwEvent.ActiveFilter.NonColumnFilterCriteria = "[Program] = '" + CalendarFilter.ProgramName + "'";
            }
            //if(IsAllow) CalendarFilter.ClientIndex=cmbClient.SelectedIndex;
            //if(isProcess)
            //    LoadEvent();
		}

		private void cmbInstructor_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (IsAllow)
            {
                CalendarFilter.InstructorName = cmbInstructor.Text;

                //CalendarFilter.ProgramName = cmbProgram.Text;
                if (CalendarFilter.InstructorName == "")
                {
                    gvwEvent.ActiveFilter.Remove(gcolScheduledIns);
                }
                else
                    gvwEvent.ActiveFilter.Add(gcolScheduledIns, new ColumnFilterInfo("ScheduledTeacher = '" + CalendarFilter.InstructorName + "'"));
                //gvwEvent.ActiveFilter.NonColumnFilterCriteria = "[Program] = '" + CalendarFilter.ProgramName + "'";
            }
            //if (IsAllow) CalendarFilter.InstructorIndex = cmbInstructor.SelectedIndex;
            //if(isProcess)
            //{
            //    LoadEvent();		
            //}
		}

		private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (IsAllow)
            {
                CalendarFilter.ProgramIndex = cmbProgram.SelectedIndex;
                
                CalendarFilter.ProgramName = cmbProgram.Text;
                if (CalendarFilter.ProgramName == "")
                {
                    gvwEvent.ActiveFilter.Remove(gcolProgram);
                }
                else
                    gvwEvent.ActiveFilter.Add(gcolProgram, new ColumnFilterInfo("Program = '" + CalendarFilter.ProgramName + "'"));
                //gvwEvent.ActiveFilter.NonColumnFilterCriteria = "[Program] = '" + CalendarFilter.ProgramName + "'";
            }
			if(isProcess)
			{
				//LoadEvent();		
			}
		}

		private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (IsAllow)
            {
                CalendarFilter.ClassIndex = cmbClass.SelectedIndex;
                CalendarFilter.ClassName = cmbClass.Text;
                if (CalendarFilter.ClassName == "")
                {
                    gvwEvent.ActiveFilter.Remove(gcolClass);
                }
                else
                    gvwEvent.ActiveFilter.Add(gcolClass, new ColumnFilterInfo("Class = '" + CalendarFilter.ClassName + "'"));
            }
			if(isProcess)
			{
				LoadEvent();		
			}
		}

		private void datePickerValueChanged(object sender, EventArgs e)
		{
			if (!isProcess)
				return;
			
			DateTimePicker dtPicker = sender as DateTimePicker;

			if (dtPicker == null)
				return;
			
			if (dtPicker.Name == "datePickerStart")
			{
				if (dtPicker.Checked)
					CalendarFilter.StartDate = dtPicker.Value;
				else
					CalendarFilter.StartDate = DateTime.MinValue;

			}
			else
			{
				if (dtPicker.Checked)
					CalendarFilter.EndDate = dtPicker.Value;
				else
					CalendarFilter.EndDate = DateTime.MaxValue;
			}
			
			if (isProcess)
			{
				LoadEvent();
			}

		}

		public void LoadFilterSettings()
		{
			isProcess=false;
            IsAllow = false;
			
			if (CalendarFilter.StartDate != DateTime.MinValue)
			{
				datePickerStart.Value = CalendarFilter.StartDate;
				datePickerStart.Checked = true;
			}
			else
			{
				datePickerStart.Checked = false;
			}
			
			if (CalendarFilter.EndDate != DateTime.MaxValue)
			{
				datePickerEnd.Value = CalendarFilter.EndDate;
				datePickerEnd.Checked = true;
			}
			else
			{
				datePickerEnd.Checked = false;
            }
            IsAllow = true;
            cmbClient.SelectedIndex = CalendarFilter.ClientIndex;
			cmbInstructor.SelectedIndex = CalendarFilter.InstructorIndex;
			cmbProgram.SelectedIndex = CalendarFilter.ProgramIndex;
			cmbClass.SelectedIndex = CalendarFilter.ClassIndex;

			isProcess=true;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			cmbProgram.SelectedIndex=0;
            CalendarFilter.ProgramIndex = 0;
			cmbClass.SelectedIndex=0;
            CalendarFilter.ClassIndex = 0;
			cmbInstructor.SelectedIndex=0;
            CalendarFilter.InstructorIndex = 0;
			cmbClient.SelectedIndex=0;
            CalendarFilter.ClientIndex = 0;
			datePickerEnd.Checked = false;
            CalendarFilter.StartDate = DateTime.MinValue;
			datePickerStart.Checked = false;
            CalendarFilter.EndDate = DateTime.MaxValue;
			CalendarFilter.ShowAll=true;
			if(isProcess)
			{
				LoadEvent();		
			}
		}

		private void grdEvent_Click(object sender, EventArgs e)
		{
           
		}

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEvent();
        }
        void DeleteEvent()
        {
            System.Data.DataRow eventRow = null;
            
            if (gvwEvent.SelectedRowsCount > 0)
                eventRow = gvwEvent.GetDataRow(gvwEvent.FocusedRowHandle);
            if (eventRow != null)
            {
                bool isRecur = false;
                int calEventID = Convert.ToInt32(eventRow["CalendarEventID"]);
                int eventID = Convert.ToInt32(eventRow["EventID"]);
                string strRecurrenceText = Common.GetString("select RecurrenceText from Event where EventID=" + eventID.ToString());

                if (strRecurrenceText != "")
                    isRecur = true;

               
                if (isRecur)
                {
                    #region Delete Recurrence
                    frmDeleteEvents frmDelEvt = new frmDeleteEvents(eventID, calEventID);
                    if (frmDelEvt.ShowDialog() == DialogResult.OK)
                    {
                        LoadEvent();
                    }
                    frmDelEvt.Close();
					frmDelEvt.Dispose();
                    #endregion

                }
                else
                {
                    #region DeleteEvent
                    if (Message.MsgDelete()) 
                    {
					    string strMess;
					    Events evt = new Events();
					    evt.EventID = eventID;
					    strMess = evt.CheckClassEvent();
					    if (strMess == "") strMess = evt.CheckProgramEvent();

					    if (strMess != "") {
						    Message.MsgWarning("This Event is linked with" + strMess + ".\n\nEvent cannot be deleted.");
						    return;
					    }


					    evt.DeleteData(true);
                        if (!evt.CheckEventExists(eventID))
                        {
                            string module = string.Empty;
                            int _uid = 0;
                            int _eventtypeindex = 0;
                            Events objEvent = new Events();
                            //Returns Course/Program ID
                            _uid = objEvent.GetEvent(eventID, ref module, ref _eventtypeindex);
                            objEvent.EventID = 0;
                            objEvent.UpdateClassEvent(_uid, "EventId");
                        }
					    LoadEvent();
                    }
                    #endregion
                }
               


            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }

        private void gvwEvent_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if(Convert.ToString(gvwEvent.GetRowCellValue(e.RowHandle,"EventStatus")) == "Inactive")
                e.Appearance.Font = new Font(e.Appearance.Font,(FontStyle.Bold|FontStyle.Strikeout));
        }
	}
}
