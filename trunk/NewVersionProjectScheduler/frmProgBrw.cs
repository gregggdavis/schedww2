using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmProgBrw.
	/// </summary>
	public class frmProgBrw : System.Windows.Forms.Form
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
		public System.Windows.Forms.Panel pnlBody;
		public System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.Panel pnl_SpeedSearch;
		internal System.Windows.Forms.Panel pnl_SpeedSearch1;
		internal System.Windows.Forms.TextBox txt_SpeedSearch;
		internal System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		internal DevExpress.XtraGrid.GridControl grdProgram;
		public DevExpress.XtraGrid.Views.Grid.GridView gvwProgram;
		public DevExpress.XtraGrid.Columns.GridColumn gcolProgID;
		public DevExpress.XtraGrid.Columns.GridColumn gColName;
		public DevExpress.XtraGrid.Columns.GridColumn gcolPhonetic;
		public DevExpress.XtraGrid.Columns.GridColumn gcolNameRomaji;
		public DevExpress.XtraGrid.Columns.GridColumn gColDepartment;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraGrid.Columns.GridColumn gcolTestIniEventID;
		private DevExpress.XtraGrid.Columns.GridColumn gColTestMidEventID;
		private DevExpress.XtraGrid.Columns.GridColumn gColTestFinalEventID;
		private DevExpress.XtraGrid.Columns.GridColumn gcolTestIniForm;
		private DevExpress.XtraGrid.Columns.GridColumn gColTestMidForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolTestFinalForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolEvaluationMidForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolEvaluationFinalForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolQuestMidForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolQuestFinalForm;
		private DevExpress.XtraGrid.Columns.GridColumn gcolProgramStatus;
		private DevExpress.XtraGrid.Columns.GridColumn gcolDateLastLogin;
		private DevExpress.XtraGrid.Columns.GridColumn gcolDateCreated;
		private DevExpress.XtraGrid.Columns.GridColumn gcolLastModified;
		private DevExpress.XtraGrid.Columns.GridColumn gcolLastModifiedByUser;
		private DevExpress.XtraGrid.Columns.GridColumn gcolReportAttendence;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDescription;
        private IContainer components;
		
		private DataTable dtbl=null;
		private Scheduler.BusinessLayer.Program objProgram=null;
		private DevExpress.XtraGrid.Columns.GridColumn gcolClientName;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContact1;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContact2;
		private bool boolFetch=true;
        #endregion

        public frmProgBrw()
		{
			InitializeComponent();
			pnl_Find.Height = 0;

			try
			{
				BusinessLayer.Common.SetControlFont(pnl_Find);				
				BusinessLayer.Common.SetGridFont(grdProgram);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgBrw));
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch1 = new System.Windows.Forms.Panel();
            this.txt_SpeedSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdProgram = new DevExpress.XtraGrid.GridControl();
            this.gvwProgram = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolProgID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolPhonetic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolReportAttendence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTestIniEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTestMidEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTestFinalEventID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTestIniForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColTestMidForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTestFinalForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEvaluationMidForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEvaluationFinalForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolQuestMidForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolQuestFinalForm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolProgramStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDateLastLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDateCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastModified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastModifiedByUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.pnl_Find.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnl_SpeedSearch.SuspendLayout();
            this.pnl_SpeedSearch1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwProgram)).BeginInit();
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
            this.pnl_Find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_Find.Location = new System.Drawing.Point(0, 0);
            this.pnl_Find.Name = "pnl_Find";
            this.pnl_Find.Size = new System.Drawing.Size(672, 90);
            this.pnl_Find.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(484, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 86);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 86);
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
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.panel2);
            this.pnlBody.Controls.Add(this.pnl_Find);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(672, 366);
            this.pnlBody.TabIndex = 27;
            this.pnlBody.Resize += new System.EventHandler(this.pnlBody_Resize);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnl_SpeedSearch);
            this.panel2.Controls.Add(this.grdProgram);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 276);
            this.panel2.TabIndex = 43;
            // 
            // pnl_SpeedSearch
            // 
            this.pnl_SpeedSearch.BackColor = System.Drawing.Color.Black;
            this.pnl_SpeedSearch.Controls.Add(this.pnl_SpeedSearch1);
            this.pnl_SpeedSearch.Location = new System.Drawing.Point(40, 184);
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
            // grdProgram
            // 
            this.grdProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProgram.EmbeddedNavigator.Name = "";
            this.grdProgram.ExternalRepository = this.persistentRepository1;
            this.grdProgram.Location = new System.Drawing.Point(0, 0);
            this.grdProgram.MainView = this.gvwProgram;
            this.grdProgram.Name = "grdProgram";
            this.grdProgram.Size = new System.Drawing.Size(672, 276);
            this.grdProgram.TabIndex = 25;
            this.grdProgram.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwProgram});
            this.grdProgram.DoubleClick += new System.EventHandler(this.grdProgram_DoubleClick);
            this.grdProgram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdProgram_KeyPress);
            // 
            // gvwProgram
            // 
            this.gvwProgram.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvwProgram.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolProgID,
            this.gColName,
            this.gcolPhonetic,
            this.gcolNameRomaji,
            this.gColDepartment,
            this.gcolClientName,
            this.gcolContact1,
            this.gcolContact2,
            this.gcolReportAttendence,
            this.gcolTestIniEventID,
            this.gColTestMidEventID,
            this.gColTestFinalEventID,
            this.gcolTestIniForm,
            this.gColTestMidForm,
            this.gcolTestFinalForm,
            this.gcolEvaluationMidForm,
            this.gcolEvaluationFinalForm,
            this.gcolQuestMidForm,
            this.gcolQuestFinalForm,
            this.gcolProgramStatus,
            this.gcolDescription,
            this.gcolDateLastLogin,
            this.gcolDateCreated,
            this.gcolLastModified,
            this.gcolLastModifiedByUser});
            this.gvwProgram.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvwProgram.GridControl = this.grdProgram;
            this.gvwProgram.Name = "gvwProgram";
            this.gvwProgram.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolClientName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcolProgID
            // 
            this.gcolProgID.Caption = "Program ID";
            this.gcolProgID.FieldName = "ProgramID";
            this.gcolProgID.Name = "gcolProgID";
            this.gcolProgID.OptionsColumn.AllowEdit = false;
            this.gcolProgID.OptionsColumn.ReadOnly = true;
            // 
            // gColName
            // 
            this.gColName.Caption = "Program Name";
            this.gColName.FieldName = "BrowseName";
            this.gColName.Name = "gColName";
            this.gColName.OptionsColumn.AllowEdit = false;
            this.gColName.OptionsColumn.ReadOnly = true;
            this.gColName.Visible = true;
            this.gColName.VisibleIndex = 2;
            this.gColName.Width = 116;
            // 
            // gcolPhonetic
            // 
            this.gcolPhonetic.Caption = "Name Phonetic";
            this.gcolPhonetic.FieldName = "NamePhonetic";
            this.gcolPhonetic.Name = "gcolPhonetic";
            this.gcolPhonetic.OptionsColumn.AllowEdit = false;
            this.gcolPhonetic.OptionsColumn.ReadOnly = true;
            this.gcolPhonetic.Width = 88;
            // 
            // gcolNameRomaji
            // 
            this.gcolNameRomaji.Caption = "Name Romaji";
            this.gcolNameRomaji.FieldName = "NameRomaji";
            this.gcolNameRomaji.Name = "gcolNameRomaji";
            this.gcolNameRomaji.OptionsColumn.AllowEdit = false;
            this.gcolNameRomaji.OptionsColumn.ReadOnly = true;
            this.gcolNameRomaji.Width = 88;
            // 
            // gColDepartment
            // 
            this.gColDepartment.Caption = "Department";
            this.gColDepartment.FieldName = "Department";
            this.gColDepartment.Name = "gColDepartment";
            this.gColDepartment.OptionsColumn.AllowEdit = false;
            this.gColDepartment.OptionsColumn.ReadOnly = true;
            this.gColDepartment.Visible = true;
            this.gColDepartment.VisibleIndex = 1;
            this.gColDepartment.Width = 120;
            // 
            // gcolClientName
            // 
            this.gcolClientName.Caption = "Client Name";
            this.gcolClientName.FieldName = "Client";
            this.gcolClientName.Name = "gcolClientName";
            this.gcolClientName.OptionsColumn.AllowEdit = false;
            this.gcolClientName.OptionsColumn.ReadOnly = true;
            this.gcolClientName.Visible = true;
            this.gcolClientName.VisibleIndex = 0;
            this.gcolClientName.Width = 120;
            // 
            // gcolContact1
            // 
            this.gcolContact1.Caption = "Contact 1 Name";
            this.gcolContact1.FieldName = "Contact1";
            this.gcolContact1.Name = "gcolContact1";
            this.gcolContact1.OptionsColumn.AllowEdit = false;
            this.gcolContact1.OptionsColumn.ReadOnly = true;
            this.gcolContact1.Visible = true;
            this.gcolContact1.VisibleIndex = 3;
            this.gcolContact1.Width = 120;
            // 
            // gcolContact2
            // 
            this.gcolContact2.Caption = "Contact 2 Name";
            this.gcolContact2.FieldName = "Contact2";
            this.gcolContact2.Name = "gcolContact2";
            this.gcolContact2.OptionsColumn.AllowEdit = false;
            this.gcolContact2.OptionsColumn.ReadOnly = true;
            this.gcolContact2.Visible = true;
            this.gcolContact2.VisibleIndex = 4;
            this.gcolContact2.Width = 120;
            // 
            // gcolReportAttendence
            // 
            this.gcolReportAttendence.Caption = "Report Attendence";
            this.gcolReportAttendence.FieldName = "ReportAttendence";
            this.gcolReportAttendence.Name = "gcolReportAttendence";
            this.gcolReportAttendence.OptionsColumn.AllowEdit = false;
            this.gcolReportAttendence.OptionsColumn.ReadOnly = true;
            this.gcolReportAttendence.Width = 88;
            // 
            // gcolTestIniEventID
            // 
            this.gcolTestIniEventID.Caption = "Initial EventID";
            this.gcolTestIniEventID.FieldName = "TestInitialEventID";
            this.gcolTestIniEventID.Name = "gcolTestIniEventID";
            this.gcolTestIniEventID.OptionsColumn.AllowEdit = false;
            this.gcolTestIniEventID.OptionsColumn.ReadOnly = true;
            // 
            // gColTestMidEventID
            // 
            this.gColTestMidEventID.Caption = "Mid-term EventID";
            this.gColTestMidEventID.FieldName = "TestMidTermEventID";
            this.gColTestMidEventID.Name = "gColTestMidEventID";
            this.gColTestMidEventID.OptionsColumn.AllowEdit = false;
            this.gColTestMidEventID.OptionsColumn.ReadOnly = true;
            // 
            // gColTestFinalEventID
            // 
            this.gColTestFinalEventID.Caption = "Final EventID";
            this.gColTestFinalEventID.FieldName = "TestFinalEventID";
            this.gColTestFinalEventID.Name = "gColTestFinalEventID";
            this.gColTestFinalEventID.OptionsColumn.AllowEdit = false;
            this.gColTestFinalEventID.OptionsColumn.ReadOnly = true;
            // 
            // gcolTestIniForm
            // 
            this.gcolTestIniForm.Caption = "Initial Form";
            this.gcolTestIniForm.FieldName = "TestInitialForm";
            this.gcolTestIniForm.Name = "gcolTestIniForm";
            this.gcolTestIniForm.OptionsColumn.AllowEdit = false;
            this.gcolTestIniForm.OptionsColumn.ReadOnly = true;
            // 
            // gColTestMidForm
            // 
            this.gColTestMidForm.Caption = "Mid-term Form";
            this.gColTestMidForm.FieldName = "TestMidTermForm";
            this.gColTestMidForm.Name = "gColTestMidForm";
            this.gColTestMidForm.OptionsColumn.AllowEdit = false;
            this.gColTestMidForm.OptionsColumn.ReadOnly = true;
            // 
            // gcolTestFinalForm
            // 
            this.gcolTestFinalForm.Caption = "Final Form";
            this.gcolTestFinalForm.FieldName = "TestFinalForm";
            this.gcolTestFinalForm.Name = "gcolTestFinalForm";
            this.gcolTestFinalForm.OptionsColumn.AllowEdit = false;
            this.gcolTestFinalForm.OptionsColumn.ReadOnly = true;
            // 
            // gcolEvaluationMidForm
            // 
            this.gcolEvaluationMidForm.Caption = "Eval. Mid-term Form";
            this.gcolEvaluationMidForm.FieldName = "EvaluationMidTermForm";
            this.gcolEvaluationMidForm.Name = "gcolEvaluationMidForm";
            this.gcolEvaluationMidForm.OptionsColumn.AllowEdit = false;
            this.gcolEvaluationMidForm.OptionsColumn.ReadOnly = true;
            // 
            // gcolEvaluationFinalForm
            // 
            this.gcolEvaluationFinalForm.Caption = "Eval. Final Form";
            this.gcolEvaluationFinalForm.FieldName = "EvaluationFinalForm";
            this.gcolEvaluationFinalForm.Name = "gcolEvaluationFinalForm";
            this.gcolEvaluationFinalForm.OptionsColumn.AllowEdit = false;
            this.gcolEvaluationFinalForm.OptionsColumn.ReadOnly = true;
            // 
            // gcolQuestMidForm
            // 
            this.gcolQuestMidForm.Caption = "Questionnaire Mid-term Form";
            this.gcolQuestMidForm.FieldName = "QuestionaireMidtermForm";
            this.gcolQuestMidForm.Name = "gcolQuestMidForm";
            this.gcolQuestMidForm.OptionsColumn.AllowEdit = false;
            this.gcolQuestMidForm.OptionsColumn.ReadOnly = true;
            // 
            // gcolQuestFinalForm
            // 
            this.gcolQuestFinalForm.Caption = "Questionnaire Final Form";
            this.gcolQuestFinalForm.FieldName = "QuestionaireFinalForm";
            this.gcolQuestFinalForm.Name = "gcolQuestFinalForm";
            this.gcolQuestFinalForm.OptionsColumn.AllowEdit = false;
            this.gcolQuestFinalForm.OptionsColumn.ReadOnly = true;
            // 
            // gcolProgramStatus
            // 
            this.gcolProgramStatus.Caption = "Status";
            this.gcolProgramStatus.FieldName = "ProgramStatus";
            this.gcolProgramStatus.Name = "gcolProgramStatus";
            this.gcolProgramStatus.OptionsColumn.AllowEdit = false;
            this.gcolProgramStatus.OptionsColumn.ReadOnly = true;
            this.gcolProgramStatus.Visible = true;
            this.gcolProgramStatus.VisibleIndex = 5;
            this.gcolProgramStatus.Width = 72;
            // 
            // gcolDescription
            // 
            this.gcolDescription.Caption = "Description";
            this.gcolDescription.FieldName = "Description";
            this.gcolDescription.Name = "gcolDescription";
            this.gcolDescription.OptionsColumn.AllowEdit = false;
            this.gcolDescription.OptionsColumn.ReadOnly = true;
            this.gcolDescription.Width = 168;
            // 
            // gcolDateLastLogin
            // 
            this.gcolDateLastLogin.Caption = "Date Last Login";
            this.gcolDateLastLogin.FieldName = "DatelastLogin";
            this.gcolDateLastLogin.Name = "gcolDateLastLogin";
            this.gcolDateLastLogin.OptionsColumn.AllowEdit = false;
            this.gcolDateLastLogin.OptionsColumn.ReadOnly = true;
            // 
            // gcolDateCreated
            // 
            this.gcolDateCreated.Caption = "Date Created";
            this.gcolDateCreated.FieldName = "DateCreated";
            this.gcolDateCreated.Name = "gcolDateCreated";
            this.gcolDateCreated.OptionsColumn.AllowEdit = false;
            this.gcolDateCreated.OptionsColumn.ReadOnly = true;
            // 
            // gcolLastModified
            // 
            this.gcolLastModified.Caption = "Date Last Modified";
            this.gcolLastModified.FieldName = "DateLastModified";
            this.gcolLastModified.Name = "gcolLastModified";
            this.gcolLastModified.OptionsColumn.AllowEdit = false;
            this.gcolLastModified.OptionsColumn.ReadOnly = true;
            // 
            // gcolLastModifiedByUser
            // 
            this.gcolLastModifiedByUser.Caption = "Last Modified User ID";
            this.gcolLastModifiedByUser.FieldName = "LastModifiedByUserID";
            this.gcolLastModifiedByUser.Name = "gcolLastModifiedByUser";
            this.gcolLastModifiedByUser.OptionsColumn.AllowEdit = false;
            this.gcolLastModifiedByUser.OptionsColumn.ReadOnly = true;
            // 
            // frmProgBrw
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(672, 366);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "frmProgBrw";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program...";
            this.Load += new System.EventHandler(this.frmProgBrw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.pnl_Find.ResumeLayout(false);
            this.pnl_Find.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnl_SpeedSearch.ResumeLayout(false);
            this.pnl_SpeedSearch1.ResumeLayout(false);
            this.pnl_SpeedSearch1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwProgram)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void FindPanel()
		{
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
			return gvwProgram.RowCount;
		}

		public void LoadProgram()
		{
			objProgram = new Scheduler.BusinessLayer.Program();
			objProgram.LoadData();
			dtbl = objProgram.ProgramDataTable;
			grdProgram.DataSource = dtbl;

			//gvwContact.UnselectRow(0);
			//gvwContact.FocusedRowHandle = CurrRec;
			//gvwContact.SelectRow(CurrRec);

			//Global.ShowRecords(Finddtbl);
		}
        public void LoadProgramInfo()
        {
            if (gvwProgram.SelectedRowsCount > 0)
            {
                DataRow row = gvwProgram.GetDataRow(gvwProgram.FocusedRowHandle);
                if (row != null)
                {
                    Scheduler.Reports.ProgamInfodlg frm = new Scheduler.Reports.ProgamInfodlg();
                    frm.LoadData(row["ProgramID"].ToString(), row["BrowseName"].ToString());
                    frm.ShowDialog();
                }
            }
            
        }
		private void grdProgram_DoubleClick(object sender, System.EventArgs e)
		{
			int row=0;
			int intProg=0;

			row = gvwProgram.FocusedRowHandle;
			if(gvwProgram.FocusedRowHandle<0)
			{
				Scheduler.BusinessLayer.Message.MsgInformation("No record exists.");
				return;
			}

			intProg = Convert.ToInt32(gvwProgram.GetRowCellValue(gvwProgram.FocusedRowHandle, gcolProgID));
			frmProgramDlg fProgDlg = new frmProgramDlg();
			fProgDlg.ProgramID = intProg;
			fProgDlg.Mode="Edit";
			fProgDlg.LoadData();
			if(fProgDlg.ShowDialog()==DialogResult.OK)
				LoadProgram();
			fProgDlg.Close();
			fProgDlg.Dispose();
			fProgDlg=null;

			gvwProgram.FocusedRowHandle=row;
		}

		private void frmProgBrw_Load(object sender, System.EventArgs e)
		{
			LoadProgram();
		}

		private void SpeedSearch()
		{
			int iRowPos = gvwProgram.FocusedRowHandle;
			string strGridValue = "";
			foreach(DevExpress.XtraGrid.Columns.GridColumn col in gvwProgram.Columns)
			{
				if(col.SortIndex>=0)
				{
					for(int intCtr=0;intCtr<gvwProgram.RowCount;intCtr++)
					{
						if(col.VisibleIndex>-1)
						{
							if(gvwProgram.GetRowCellValue(intCtr, col) !=System.DBNull.Value)
							{
								strGridValue = gvwProgram.GetRowCellValue(intCtr, col).ToString();
								if(strGridValue.ToUpper().Trim().StartsWith(txt_SpeedSearch.Text.Trim().ToUpper()))
								{
									gvwProgram.FocusedRowHandle = intCtr;
									break;
								}
							}
						}
					}
				}
			}
		}

		private void txt_SpeedSearch_Leave(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Visible = false;
			this.KeyPreview = true;
		}

		private void txt_SpeedSearch_TextChanged(object sender, System.EventArgs e)
		{
			SpeedSearch();		
		}

		private void txt_SpeedSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if((e.KeyData == Keys.Enter) || (e.KeyData == Keys.Escape))
			{
				pnl_SpeedSearch.Visible = false;
				grdProgram.Focus();
				grdProgram.Select();
			}
		}

		private void txt_SpeedSearch_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			SpeedSearch();		
		}

		private void grdProgram_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
						grdProgram.Focus();
						grdProgram.Select();
					}
				}
			}
		}

		private void pnlBody_Resize(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void FindRoutine()
		{
			gvwProgram.BeginUpdate();
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
				gvwProgram.EndUpdate();
			}
		}

		private void btn_Find_Click(object sender, System.EventArgs e)
		{
			if (boolFetch==false) LoadProgram();
			FindRoutine();
		}

		private void btn_Clear_Click(object sender, System.EventArgs e)
		{
			txtSearch.Text = "";
			LoadProgram();
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
