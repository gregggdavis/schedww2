using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmCourseBrw.
	/// </summary>
	public class frmCourseBrw : System.Windows.Forms.Form
    {
        #region Declarations
        private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
		public System.Windows.Forms.Panel pnl_Find;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.CheckBox chk_Anywhere;
		internal System.Windows.Forms.Button btn_Clear;
		internal System.Windows.Forms.Button btn_Find;
		internal System.Windows.Forms.Label lbl_Find;
		internal System.Windows.Forms.CheckBox chk_AdvanceSearch;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		public System.Windows.Forms.Panel pnlBody;
		internal System.Windows.Forms.Panel pnl_SpeedSearch;
		internal System.Windows.Forms.Panel pnl_SpeedSearch1;
		internal System.Windows.Forms.TextBox txt_SpeedSearch;
		internal System.Windows.Forms.Label label1;
		public DevExpress.XtraGrid.Views.Grid.GridView gvwCourse;

		internal DevExpress.XtraGrid.GridControl grdCourse;
		public DevExpress.XtraGrid.Columns.GridColumn gColName;
		public DevExpress.XtraGrid.Columns.GridColumn gcolPhonetic;
		public DevExpress.XtraGrid.Columns.GridColumn gcolNameRomaji;
		private DevExpress.XtraGrid.Columns.GridColumn gcolTestIniEventID;
		private DevExpress.XtraGrid.Columns.GridColumn gColTestMidEventID;
		private DevExpress.XtraGrid.Columns.GridColumn gColTestFinalEventID;
		private DevExpress.XtraGrid.Columns.GridColumn gcolTestIniForm;
		private DevExpress.XtraGrid.Columns.GridColumn gColTestMidForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolTestFinalForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolDateLastLogin;
		private DevExpress.XtraGrid.Columns.GridColumn gcolDateCreated;
		private DevExpress.XtraGrid.Columns.GridColumn gcolLastModified;
		private DevExpress.XtraGrid.Columns.GridColumn gcolLastModifiedByUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDescription;
        private IContainer components;


		private DataTable dtbl=null;
        public DevExpress.XtraGrid.Columns.GridColumn gcolCourseId;
		public DevExpress.XtraGrid.Columns.GridColumn gColProgram;
		private DevExpress.XtraGrid.Columns.GridColumn gcolCourseType;
		private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;
		private DevExpress.XtraGrid.Columns.GridColumn gcolNumberStudents;
		private DevExpress.XtraGrid.Columns.GridColumn gcolHomeWorkMinutes;
		private DevExpress.XtraGrid.Columns.GridColumn gcolCurriculam;
		private Scheduler.BusinessLayer.Course objCourse=null;
		private DevExpress.XtraGrid.Columns.GridColumn gcolDept;
		private DevExpress.XtraGrid.Columns.GridColumn gcolClient;
		private DevExpress.XtraGrid.Columns.GridColumn gcolEventDateTime;
		private DevExpress.XtraGrid.Columns.GridColumn gcolEndDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEventId;
        private DevExpress.XtraGrid.Columns.GridColumn gcolOccurrenceCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gcolScheduledInstructor;
        private DevExpress.Xpo.XPServerCollectionSource xpServerCollectionSource1;
        private DevExpress.Xpo.Session session1;
		private bool boolFetch=true;
        #endregion

        public frmCourseBrw()
		{
			InitializeComponent();
            //this.gvwCourse.ActiveFilter.Add(gcolStatus, new ColumnFilterInfo("Status='Active'"));
            pnl_Find.Height = 0;
            XpoDefault.ConnectionString = BusinessLayer.Common.ConnString;
			try
			{
				BusinessLayer.Common.SetControlFont(pnl_Find);				
				BusinessLayer.Common.SetGridFont(grdCourse);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCourseBrw));
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.pnl_Find = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chk_Anywhere = new System.Windows.Forms.CheckBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.lbl_Find = new System.Windows.Forms.Label();
            this.chk_AdvanceSearch = new System.Windows.Forms.CheckBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch1 = new System.Windows.Forms.Panel();
            this.txt_SpeedSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdCourse = new DevExpress.XtraGrid.GridControl();
            this.xpServerCollectionSource1 = new DevExpress.Xpo.XPServerCollectionSource();
            this.session1 = new DevExpress.Xpo.Session();
            this.gvwCourse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolCourseId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolPhonetic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCourseType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColProgram = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEventDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEndDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNumberStudents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolHomeWorkMinutes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTestIniEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTestMidEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTestFinalEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTestIniForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTestMidForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTestFinalForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCurriculam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDateLastLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDateCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastModified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastModifiedByUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEventId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolOccurrenceCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolScheduledInstructor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTimeEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.pnl_Find.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnl_SpeedSearch.SuspendLayout();
            this.pnl_SpeedSearch1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpServerCollectionSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).BeginInit();
            this.SuspendLayout();
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
            this.pnl_Find.Size = new System.Drawing.Size(672, 129);
            this.pnl_Find.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(386, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 125);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(102, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(474, 27);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // chk_Anywhere
            // 
            this.chk_Anywhere.BackColor = System.Drawing.SystemColors.Window;
            this.chk_Anywhere.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk_Anywhere.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Anywhere.Location = new System.Drawing.Point(336, 63);
            this.chk_Anywhere.Name = "chk_Anywhere";
            this.chk_Anywhere.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk_Anywhere.Size = new System.Drawing.Size(246, 34);
            this.chk_Anywhere.TabIndex = 7;
            this.chk_Anywhere.Text = "Search Anywhere in Fields";
            this.chk_Anywhere.UseVisualStyleBackColor = false;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Clear.Location = new System.Drawing.Point(592, 63);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(120, 33);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Find.Location = new System.Drawing.Point(592, 21);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(120, 33);
            this.btn_Find.TabIndex = 4;
            this.btn_Find.Text = "Find";
            this.btn_Find.UseVisualStyleBackColor = false;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // lbl_Find
            // 
            this.lbl_Find.AutoSize = true;
            this.lbl_Find.Location = new System.Drawing.Point(24, 27);
            this.lbl_Find.Name = "lbl_Find";
            this.lbl_Find.Size = new System.Drawing.Size(46, 21);
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
            this.chk_AdvanceSearch.Location = new System.Drawing.Point(102, 63);
            this.chk_AdvanceSearch.Name = "chk_AdvanceSearch";
            this.chk_AdvanceSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chk_AdvanceSearch.Size = new System.Drawing.Size(180, 34);
            this.chk_AdvanceSearch.TabIndex = 8;
            this.chk_AdvanceSearch.Text = "Search All Fields";
            this.chk_AdvanceSearch.UseVisualStyleBackColor = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnl_SpeedSearch);
            this.pnlBody.Controls.Add(this.grdCourse);
            this.pnlBody.Controls.Add(this.pnl_Find);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(672, 357);
            this.pnlBody.TabIndex = 29;
            this.pnlBody.Resize += new System.EventHandler(this.pnlBody_Resize);
            // 
            // pnl_SpeedSearch
            // 
            this.pnl_SpeedSearch.BackColor = System.Drawing.Color.Black;
            this.pnl_SpeedSearch.Controls.Add(this.pnl_SpeedSearch1);
            this.pnl_SpeedSearch.Location = new System.Drawing.Point(64, 309);
            this.pnl_SpeedSearch.Name = "pnl_SpeedSearch";
            this.pnl_SpeedSearch.Size = new System.Drawing.Size(307, 102);
            this.pnl_SpeedSearch.TabIndex = 42;
            this.pnl_SpeedSearch.Visible = false;
            // 
            // pnl_SpeedSearch1
            // 
            this.pnl_SpeedSearch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(143)))), ((int)(((byte)(230)))));
            this.pnl_SpeedSearch1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_SpeedSearch1.Controls.Add(this.txt_SpeedSearch);
            this.pnl_SpeedSearch1.Controls.Add(this.label1);
            this.pnl_SpeedSearch1.Location = new System.Drawing.Point(6, 6);
            this.pnl_SpeedSearch1.Name = "pnl_SpeedSearch1";
            this.pnl_SpeedSearch1.Size = new System.Drawing.Size(295, 91);
            this.pnl_SpeedSearch1.TabIndex = 39;
            // 
            // txt_SpeedSearch
            // 
            this.txt_SpeedSearch.Location = new System.Drawing.Point(18, 41);
            this.txt_SpeedSearch.Name = "txt_SpeedSearch";
            this.txt_SpeedSearch.Size = new System.Drawing.Size(251, 27);
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
            this.label1.Location = new System.Drawing.Point(90, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fast Search";
            // 
            // grdCourse
            // 
            this.grdCourse.DataSource = this.xpServerCollectionSource1;
            this.grdCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCourse.ExternalRepository = this.persistentRepository1;
            this.grdCourse.Location = new System.Drawing.Point(0, 129);
            this.grdCourse.MainView = this.gvwCourse;
            this.grdCourse.Name = "grdCourse";
            this.grdCourse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemTimeEdit2});
            //this.grdCourse.ServerMode = true;
            this.grdCourse.Size = new System.Drawing.Size(672, 228);
            this.grdCourse.TabIndex = 26;
            this.grdCourse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwCourse});
            this.grdCourse.DoubleClick += new System.EventHandler(this.grdCourse_DoubleClick);
            this.grdCourse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdCourse_KeyPress);
            // 
            // xpServerCollectionSource1
            // 
            this.xpServerCollectionSource1.ObjectType = typeof(Scheduler.BusinessLayer.CoursePO);
            this.xpServerCollectionSource1.Session = this.session1;
            // 
            // gvwCourse
            // 
            this.gvwCourse.ActiveFilterString = "[CourseStatus] = \'Active\'";
            this.gvwCourse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvwCourse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolCourseId,
            this.gColName,
            this.gcolPhonetic,
            this.gcolNameRomaji,
            this.gcolCourseType,
            this.gColProgram,
            this.gcolClient,
            this.gcolDept,
            this.gcolEventDateTime,
            this.gcolEndDateTime,
            this.gcolNumberStudents,
            this.gcolHomeWorkMinutes,
            this.gcolTestIniEventID,
            this.gColTestMidEventID,
            this.gColTestFinalEventID,
            this.gcolTestIniForm,
            this.gColTestMidForm,
            this.gcolTestFinalForm,
            this.gcolCurriculam,
            this.gcolStatus,
            this.gcolDescription,
            this.gcolDateLastLogin,
            this.gcolDateCreated,
            this.gcolLastModified,
            this.gcolLastModifiedByUser,
            this.gcolEventId,
            this.gcolOccurrenceCount,
            this.gcolScheduledInstructor});
            this.gvwCourse.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvwCourse.GridControl = this.grdCourse;
            this.gvwCourse.Name = "gvwCourse";
            this.gvwCourse.OptionsBehavior.Editable = false;
            this.gvwCourse.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gvwCourse.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvwCourse.OptionsView.ShowDetailButtons = false;
            this.gvwCourse.OptionsView.ShowGroupPanel = false;
            this.gvwCourse.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvwCourse.OptionsView.ShowIndicator = false;
            this.gvwCourse.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolClient, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gColName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolEventDateTime, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcolCourseId
            // 
            this.gcolCourseId.Caption = "Course Id";
            this.gcolCourseId.FieldName = "CourseId";
            this.gcolCourseId.Name = "gcolCourseId";
            // 
            // gColName
            // 
            this.gColName.Caption = "Class Name";
            this.gColName.FieldName = "BrowseName";
            this.gColName.Name = "gColName";
            this.gColName.Visible = true;
            this.gColName.VisibleIndex = 3;
            this.gColName.Width = 203;
            // 
            // gcolPhonetic
            // 
            this.gcolPhonetic.Caption = "Name Phonetic";
            this.gcolPhonetic.FieldName = "NamePhonetic";
            this.gcolPhonetic.Name = "gcolPhonetic";
            this.gcolPhonetic.Width = 78;
            // 
            // gcolNameRomaji
            // 
            this.gcolNameRomaji.Caption = "Name Romaji";
            this.gcolNameRomaji.FieldName = "NameRomaji";
            this.gcolNameRomaji.Name = "gcolNameRomaji";
            this.gcolNameRomaji.Width = 78;
            // 
            // gcolCourseType
            // 
            this.gcolCourseType.Caption = "Type";
            this.gcolCourseType.FieldName = "CourseType";
            this.gcolCourseType.Name = "gcolCourseType";
            this.gcolCourseType.Width = 60;
            // 
            // gColProgram
            // 
            this.gColProgram.Caption = "Program Name";
            this.gColProgram.FieldName = "Program";
            this.gColProgram.Name = "gColProgram";
            this.gColProgram.Visible = true;
            this.gColProgram.VisibleIndex = 2;
            this.gColProgram.Width = 203;
            // 
            // gcolClient
            // 
            this.gcolClient.Caption = "Client Name";
            this.gcolClient.FieldName = "Client";
            this.gcolClient.Name = "gcolClient";
            this.gcolClient.Visible = true;
            this.gcolClient.VisibleIndex = 0;
            this.gcolClient.Width = 223;
            // 
            // gcolDept
            // 
            this.gcolDept.Caption = "Department Name";
            this.gcolDept.FieldName = "Department";
            this.gcolDept.Name = "gcolDept";
            this.gcolDept.Visible = true;
            this.gcolDept.VisibleIndex = 1;
            this.gcolDept.Width = 208;
            // 
            // gcolEventDateTime
            // 
            this.gcolEventDateTime.Caption = "Event Start Date";
            this.gcolEventDateTime.DisplayFormat.FormatString = "MM/dd/yyyy HH:mm";
            this.gcolEventDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcolEventDateTime.FieldName = "EventStartDateTime";
            this.gcolEventDateTime.Name = "gcolEventDateTime";
            this.gcolEventDateTime.Visible = true;
            this.gcolEventDateTime.VisibleIndex = 4;
            this.gcolEventDateTime.Width = 160;
            // 
            // gcolEndDateTime
            // 
            this.gcolEndDateTime.Caption = "Event End Date";
            this.gcolEndDateTime.DisplayFormat.FormatString = "MM/dd/yyyy HH:mm";
            this.gcolEndDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcolEndDateTime.FieldName = "EventEndDateTime";
            this.gcolEndDateTime.Name = "gcolEndDateTime";
            this.gcolEndDateTime.Visible = true;
            this.gcolEndDateTime.VisibleIndex = 5;
            this.gcolEndDateTime.Width = 160;
            // 
            // gcolNumberStudents
            // 
            this.gcolNumberStudents.Caption = "No. Students";
            this.gcolNumberStudents.FieldName = "NumberStudents";
            this.gcolNumberStudents.Name = "gcolNumberStudents";
            // 
            // gcolHomeWorkMinutes
            // 
            this.gcolHomeWorkMinutes.Caption = "Homework Mints.";
            this.gcolHomeWorkMinutes.FieldName = "HomeWorkMinutes";
            this.gcolHomeWorkMinutes.Name = "gcolHomeWorkMinutes";
            this.gcolHomeWorkMinutes.Width = 76;
            // 
            // gcolTestIniEventID
            // 
            this.gcolTestIniEventID.Caption = "Initial EventID";
            this.gcolTestIniEventID.FieldName = "TestInitialEventID";
            this.gcolTestIniEventID.Name = "gcolTestIniEventID";
            // 
            // gColTestMidEventID
            // 
            this.gColTestMidEventID.Caption = "Mid-term EventID";
            this.gColTestMidEventID.FieldName = "TestMidTermEventID";
            this.gColTestMidEventID.Name = "gColTestMidEventID";
            // 
            // gColTestFinalEventID
            // 
            this.gColTestFinalEventID.Caption = "Final EventID";
            this.gColTestFinalEventID.FieldName = "TestFinalEventID";
            this.gColTestFinalEventID.Name = "gColTestFinalEventID";
            // 
            // gcolTestIniForm
            // 
            this.gcolTestIniForm.Caption = "Initial Form";
            this.gcolTestIniForm.FieldName = "TestInitialForm";
            this.gcolTestIniForm.Name = "gcolTestIniForm";
            // 
            // gColTestMidForm
            // 
            this.gColTestMidForm.Caption = "Mid-term Form";
            this.gColTestMidForm.FieldName = "TestMidTermForm";
            this.gColTestMidForm.Name = "gColTestMidForm";
            // 
            // gcolTestFinalForm
            // 
            this.gcolTestFinalForm.Caption = "Final Form";
            this.gcolTestFinalForm.FieldName = "TestFinalForm";
            this.gcolTestFinalForm.Name = "gcolTestFinalForm";
            // 
            // gcolCurriculam
            // 
            this.gcolCurriculam.Caption = "Curriculam";
            this.gcolCurriculam.FieldName = "Curriculam";
            this.gcolCurriculam.Name = "gcolCurriculam";
            this.gcolCurriculam.Width = 44;
            // 
            // gcolStatus
            // 
            this.gcolStatus.Caption = "Status";
            this.gcolStatus.FieldName = "CourseStatus";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.Visible = true;
            this.gcolStatus.VisibleIndex = 7;
            this.gcolStatus.Width = 183;
            // 
            // gcolDescription
            // 
            this.gcolDescription.Caption = "Description";
            this.gcolDescription.FieldName = "Description";
            this.gcolDescription.Name = "gcolDescription";
            this.gcolDescription.Width = 102;
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
            // gcolEventId
            // 
            this.gcolEventId.Caption = "EventId";
            this.gcolEventId.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcolEventId.FieldName = "EventID";
            this.gcolEventId.Name = "gcolEventId";
            // 
            // gcolOccurrenceCount
            // 
            this.gcolOccurrenceCount.Caption = "Occured / Total";
            this.gcolOccurrenceCount.FieldName = "OccurrenceCount";
            this.gcolOccurrenceCount.Name = "gcolOccurrenceCount";
            this.gcolOccurrenceCount.Visible = true;
            this.gcolOccurrenceCount.VisibleIndex = 8;
            this.gcolOccurrenceCount.Width = 224;
            // 
            // gcolScheduledInstructor
            // 
            this.gcolScheduledInstructor.Caption = "Scheduled Instructor";
            this.gcolScheduledInstructor.FieldName = "ScheduledInstructor";
            this.gcolScheduledInstructor.Name = "gcolScheduledInstructor";
            this.gcolScheduledInstructor.Visible = true;
            this.gcolScheduledInstructor.VisibleIndex = 6;
            this.gcolScheduledInstructor.Width = 183;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.Mask.EditMask = "hh:mm:ss tt";
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemTimeEdit2
            // 
            this.repositoryItemTimeEdit2.AutoHeight = false;
            this.repositoryItemTimeEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit2.DisplayFormat.FormatString = "MM/dd/yyyy HH:mm";
            this.repositoryItemTimeEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit2.Mask.EditMask = "MM/dd/yyyy HH:mm";
            this.repositoryItemTimeEdit2.Name = "repositoryItemTimeEdit2";
            // 
            // frmCourseBrw
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 20);
            this.ClientSize = new System.Drawing.Size(672, 357);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCourseBrw";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`";
            this.Load += new System.EventHandler(this.frmCourseBrw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.pnl_Find.ResumeLayout(false);
            this.pnl_Find.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnl_SpeedSearch.ResumeLayout(false);
            this.pnl_SpeedSearch1.ResumeLayout(false);
            this.pnl_SpeedSearch1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpServerCollectionSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).EndInit();
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
			return gvwCourse.RowCount;
		}

		public void LoadCourse()
		{
//            xpServerCollectionSource1.Reload();
//            grdCourse.RefreshDataSource();
//            grdCourse.Update();

            objCourse = new Scheduler.BusinessLayer.Course();
          //DateTime dt = DateTime.Now;

			objCourse.LoadDataN();
			dtbl = objCourse.CourseDataTable;
            grdCourse.DataSource = dtbl;

            //grdCourse.DataSource = xpServerCollectionSource1;
            //grdCourse.ServerMode = true;
          //DateTime dt1 = DateTime.Now;
          //TimeSpan ts= dt1 - dt;
            //MessageBox.Show(ts.Seconds.ToString());
			//gvwContact.UnselectRow(0);
			//gvwContact.FocusedRowHandle = CurrRec;
			//gvwContact.SelectRow(CurrRec);

			//Global.ShowRecords(Finddtbl);
		}

		private void frmCourseBrw_Load(object sender, System.EventArgs e)
		{
			LoadCourse();
		}

		private void SpeedSearch()
		{
			int iRowPos = gvwCourse.FocusedRowHandle;
			string strGridValue = "";
			foreach(DevExpress.XtraGrid.Columns.GridColumn col in gvwCourse.Columns)
			{
				if(col.SortIndex>=0)
				{
					for(int intCtr=0;intCtr<gvwCourse.RowCount;intCtr++)
					{
						if(col.VisibleIndex>-1)
						{
							if(gvwCourse.GetRowCellValue(intCtr, col) !=System.DBNull.Value)
							{
								strGridValue = gvwCourse.GetRowCellValue(intCtr, col).ToString();
								if(strGridValue.ToUpper().Trim().StartsWith(txt_SpeedSearch.Text.Trim().ToUpper()))
								{
									gvwCourse.FocusedRowHandle = intCtr;
									break;
								}
							}
						}
					}
				}
			}
		}

		private void txt_SpeedSearch_TextChanged(object sender, System.EventArgs e)
		{
			SpeedSearch();
		}

		private void txt_SpeedSearch_Leave(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Visible = false;
			this.KeyPreview = true;
		}

		private void txt_SpeedSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if((e.KeyData == Keys.Enter) || (e.KeyData == Keys.Escape))
			{
				pnl_SpeedSearch.Visible = false;
				grdCourse.Focus();
				grdCourse.Select();
			}
		}

		private void txt_SpeedSearch_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			SpeedSearch();
		}

		private void grdCourse_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
						grdCourse.Focus();
						grdCourse.Select();
					}
				}
			}
	
		}

		private void pnlBody_Resize(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void grdCourse_DoubleClick(object sender, System.EventArgs e)
		{
			int row=0;
			int intCourse= 0;
            int intEventId = 0;
            int intIndex = 0;
            frmClassDlg fClassDlg = null;
			row=gvwCourse.FocusedRowHandle;
			if(gvwCourse.FocusedRowHandle<0)
			{
				Scheduler.BusinessLayer.Message.MsgInformation("No record exists.");
				return;
			}

            intCourse = Convert.ToInt32(gvwCourse.GetRowCellValue(gvwCourse.FocusedRowHandle, gcolCourseId));
            intEventId = Convert.ToInt32(gvwCourse.GetRowCellValue(gvwCourse.FocusedRowHandle, gcolEventId));
            //Two possibilities exist here. Either a class event exists or it doesn't.
            if (intEventId != 0)
            {
                intIndex = 3;
                fClassDlg = new frmClassDlg(intCourse, intIndex);
            }
            else
            {
                fClassDlg = new frmClassDlg(intCourse);
                fClassDlg.Mode = "Edit";
                fClassDlg.LoadData();
            }
		
			if(fClassDlg.ShowDialog()==DialogResult.OK)
				LoadCourse();

			fClassDlg.Close();
			fClassDlg.Dispose();
			fClassDlg=null;

			gvwCourse.FocusedRowHandle=row;
		}

		private void FindRoutine()
		{
			gvwCourse.BeginUpdate();
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
						object[] obj=new object[dtbl.Columns.Count];
						for(int i=0;i<dtbl.Columns.Count;i++)
						{
							obj[i] = CollSearchRow[intRowCtr][i];
						}
						dtbl.Rows.Add(obj);
					}
				}	

				dtbl.AcceptChanges();
			}
			finally
			{
				gvwCourse.EndUpdate();
			}
		}

		private void btn_Find_Click(object sender, System.EventArgs e)
		{
			if (boolFetch==false) LoadCourse();
			FindRoutine();
		}

		private void btn_Clear_Click(object sender, System.EventArgs e)
		{
			txtSearch.Text = "";
			LoadCourse();
		}

		private void txtSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyData==Keys.Enter)
			{
				btn_Find_Click(sender, null);
			}
		}
	}
}
