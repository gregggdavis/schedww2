using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmContactBrw.
	/// </summary>
	public class frmContactBrw : System.Windows.Forms.Form
    {
        #region Declarations
        public System.Windows.Forms.Panel pnlBody;
		internal System.Windows.Forms.Panel pnl_SpeedSearch;
		internal System.Windows.Forms.Panel pnl_SpeedSearch1;
		internal System.Windows.Forms.TextBox txt_SpeedSearch;
		internal System.Windows.Forms.Label label1;
		public System.Windows.Forms.Panel pnl_Find;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.CheckBox chk_Anywhere;
		internal System.Windows.Forms.Button btn_Clear;
		internal System.Windows.Forms.Button btn_Find;
		internal System.Windows.Forms.Label lbl_Find;
		internal System.Windows.Forms.CheckBox chk_AdvanceSearch;
		public DevExpress.XtraGrid.GridControl grdContact;
		private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        public DevExpress.XtraGrid.Views.Grid.GridView gvwContact;
        private IContainer components;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		public DevExpress.XtraGrid.Columns.GridColumn gcolContactID;
		private DevExpress.XtraGrid.Columns.GridColumn gColLastName;


		private Scheduler.BusinessLayer.Contact objContact=null;
		private DataTable dtbl;
		private frmMain fMain=null;
		private DevExpress.XtraGrid.Columns.GridColumn gcolFirstName;
		private DevExpress.XtraGrid.Columns.GridColumn gcolCompany;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContactType;
		private DevExpress.XtraGrid.Columns.GridColumn gcolEmail1;
		private DevExpress.XtraGrid.Columns.GridColumn gcolPhone;
		private DevExpress.XtraGrid.Columns.GridColumn gcolStreet;
		private DevExpress.XtraGrid.Columns.GridColumn gcolState;
		private DevExpress.XtraGrid.Columns.GridColumn gcolCountry;
		private DevExpress.XtraGrid.Columns.GridColumn gcolCity;
		private DevExpress.XtraGrid.Columns.GridColumn gcolStatusID;
		private DevExpress.XtraGrid.Columns.GridColumn gcolType;
		private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;

		private bool boolFetch=true;
		private DevExpress.XtraGrid.Columns.GridColumn gcolFirstNameRomaji;
		private DevExpress.XtraGrid.Columns.GridColumn gcolLastNameRomaji;
		private DevExpress.XtraGrid.Columns.GridColumn gcolJobTitle;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContactName;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContactNameRomaji;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContactPhone1;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContact2Name;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContactPhone2;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContact1Name;
        private DevExpress.XtraGrid.Columns.GridColumn gcolMobilePhone;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDateJoined;
        private DevExpress.XtraGrid.Columns.GridColumn colAccRepName;
		private string option="";
        #endregion
        public string Option
		{
			get{return option;}
			set{option=value;}
		}
		public frmContactBrw()
		{
			InitializeComponent();
			pnl_Find.Height = 0;

			try
			{
				BusinessLayer.Common.SetControlFont(pnl_Find);				
				BusinessLayer.Common.SetGridFont(grdContact);
			}
			catch{}

		}

		public frmContactBrw(string _option)
		{
			option = _option; //Contact,Teacher.Client,Other
			InitializeComponent();
			pnl_Find.Height = 0;
		}

		public frmContactBrw(frmMain fTempMain)
		{
			InitializeComponent();
	        fMain = fTempMain;
	        pnl_Find.Height = 0;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactBrw));
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch1 = new System.Windows.Forms.Panel();
            this.txt_SpeedSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdContact = new DevExpress.XtraGrid.GridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gvwContact = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolContactID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContactType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFirstNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContactName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContactNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStreet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEmail1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolJobTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact1Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContactPhone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact2Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContactPhone2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolMobilePhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDateJoined = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccRepName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnl_Find = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chk_Anywhere = new System.Windows.Forms.CheckBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.lbl_Find = new System.Windows.Forms.Label();
            this.chk_AdvanceSearch = new System.Windows.Forms.CheckBox();
            this.pnlBody.SuspendLayout();
            this.pnl_SpeedSearch.SuspendLayout();
            this.pnl_SpeedSearch1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwContact)).BeginInit();
            this.pnl_Find.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnl_SpeedSearch);
            this.pnlBody.Controls.Add(this.grdContact);
            this.pnlBody.Controls.Add(this.pnl_Find);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(672, 333);
            this.pnlBody.TabIndex = 26;
            this.pnlBody.Resize += new System.EventHandler(this.pnlBody_Resize);
            // 
            // pnl_SpeedSearch
            // 
            this.pnl_SpeedSearch.BackColor = System.Drawing.Color.Black;
            this.pnl_SpeedSearch.Controls.Add(this.pnl_SpeedSearch1);
            this.pnl_SpeedSearch.Location = new System.Drawing.Point(40, 232);
            this.pnl_SpeedSearch.Name = "pnl_SpeedSearch";
            this.pnl_SpeedSearch.Size = new System.Drawing.Size(192, 72);
            this.pnl_SpeedSearch.TabIndex = 41;
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
            // grdContact
            // 
            this.grdContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContact.EmbeddedNavigator.Name = "";
            this.grdContact.ExternalRepository = this.persistentRepository1;
            this.grdContact.Location = new System.Drawing.Point(0, 88);
            this.grdContact.MainView = this.gvwContact;
            this.grdContact.Name = "grdContact";
            this.grdContact.Size = new System.Drawing.Size(672, 245);
            this.grdContact.TabIndex = 25;
            this.grdContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwContact});
            this.grdContact.DoubleClick += new System.EventHandler(this.grdContact_DoubleClick);
            this.grdContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdContact_KeyPress);
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
            // gvwContact
            // 
            this.gvwContact.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvwContact.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolContactID,
            this.gcolContactType,
            this.gcolType,
            this.gColLastName,
            this.gcolFirstName,
            this.gcolCompany,
            this.gcolLastNameRomaji,
            this.gcolFirstNameRomaji,
            this.gcolContactName,
            this.gcolContactNameRomaji,
            this.gcolStreet,
            this.gcolCity,
            this.gcolState,
            this.gcolCountry,
            this.gcolEmail1,
            this.gcolPhone,
            this.gcolJobTitle,
            this.gcolStatusID,
            this.gcolStatus,
            this.gcolContact1Name,
            this.gcolContactPhone1,
            this.gcolContact2Name,
            this.gcolContactPhone2,
            this.gcolMobilePhone,
            this.gcolDateJoined,
            this.colAccRepName});
            this.gvwContact.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvwContact.GridControl = this.grdContact;
            this.gvwContact.Name = "gvwContact";
            this.gvwContact.OptionsBehavior.Editable = false;
            this.gvwContact.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gvwContact.OptionsDetail.EnableDetailToolTip = true;
            this.gvwContact.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvwContact.OptionsPrint.UsePrintStyles = true;
            this.gvwContact.OptionsView.ShowDetailButtons = false;
            this.gvwContact.OptionsView.ShowGroupPanel = false;
            this.gvwContact.OptionsView.ShowHorzLines = false;
            this.gvwContact.OptionsView.ShowIndicator = false;
            this.gvwContact.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolContactType, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcolContactID
            // 
            this.gcolContactID.Caption = "ContactID";
            this.gcolContactID.FieldName = "ContactId";
            this.gcolContactID.Name = "gcolContactID";
            // 
            // gcolContactType
            // 
            this.gcolContactType.Caption = "Contact Type ID";
            this.gcolContactType.ColumnEdit = this.repositoryItemTextEdit1;
            this.gcolContactType.FieldName = "ContactType";
            this.gcolContactType.Name = "gcolContactType";
            this.gcolContactType.Width = 68;
            // 
            // gcolType
            // 
            this.gcolType.Caption = "Contact Type";
            this.gcolType.FieldName = "Type";
            this.gcolType.Name = "gcolType";
            // 
            // gColLastName
            // 
            this.gColLastName.Caption = "Last Name";
            this.gColLastName.FieldName = "LastName";
            this.gColLastName.Name = "gColLastName";
            this.gColLastName.Visible = true;
            this.gColLastName.VisibleIndex = 0;
            this.gColLastName.Width = 73;
            // 
            // gcolFirstName
            // 
            this.gcolFirstName.Caption = "First Name";
            this.gcolFirstName.FieldName = "FirstName";
            this.gcolFirstName.Name = "gcolFirstName";
            this.gcolFirstName.Visible = true;
            this.gcolFirstName.VisibleIndex = 1;
            this.gcolFirstName.Width = 73;
            // 
            // gcolCompany
            // 
            this.gcolCompany.Caption = "Company";
            this.gcolCompany.FieldName = "BrowseName";
            this.gcolCompany.Name = "gcolCompany";
            this.gcolCompany.Visible = true;
            this.gcolCompany.VisibleIndex = 2;
            this.gcolCompany.Width = 73;
            // 
            // gcolLastNameRomaji
            // 
            this.gcolLastNameRomaji.Caption = "Last Name Romaji";
            this.gcolLastNameRomaji.FieldName = "LastNameRomaji";
            this.gcolLastNameRomaji.Name = "gcolLastNameRomaji";
            // 
            // gcolFirstNameRomaji
            // 
            this.gcolFirstNameRomaji.Caption = "First Name Romaji";
            this.gcolFirstNameRomaji.FieldName = "FirstNameRomaji";
            this.gcolFirstNameRomaji.Name = "gcolFirstNameRomaji";
            // 
            // gcolContactName
            // 
            this.gcolContactName.Caption = "Contact Name";
            this.gcolContactName.FieldName = "ContactlastName1";
            this.gcolContactName.Name = "gcolContactName";
            // 
            // gcolContactNameRomaji
            // 
            this.gcolContactNameRomaji.Caption = "Contact Name Romaji";
            this.gcolContactNameRomaji.FieldName = "ContactlastNameRomaji1";
            this.gcolContactNameRomaji.Name = "gcolContactNameRomaji";
            // 
            // gcolStreet
            // 
            this.gcolStreet.Caption = "Street";
            this.gcolStreet.FieldName = "Street1";
            this.gcolStreet.Name = "gcolStreet";
            this.gcolStreet.Width = 69;
            // 
            // gcolCity
            // 
            this.gcolCity.Caption = "City";
            this.gcolCity.FieldName = "City";
            this.gcolCity.Name = "gcolCity";
            this.gcolCity.Width = 46;
            // 
            // gcolState
            // 
            this.gcolState.Caption = "State";
            this.gcolState.FieldName = "State";
            this.gcolState.Name = "gcolState";
            this.gcolState.Width = 46;
            // 
            // gcolCountry
            // 
            this.gcolCountry.Caption = "Country";
            this.gcolCountry.FieldName = "Country";
            this.gcolCountry.Name = "gcolCountry";
            this.gcolCountry.Width = 46;
            // 
            // gcolEmail1
            // 
            this.gcolEmail1.Caption = "Email";
            this.gcolEmail1.FieldName = "Email1";
            this.gcolEmail1.Name = "gcolEmail1";
            this.gcolEmail1.Width = 41;
            // 
            // gcolPhone
            // 
            this.gcolPhone.Caption = "Phone";
            this.gcolPhone.FieldName = "Phone1";
            this.gcolPhone.Name = "gcolPhone";
            this.gcolPhone.Visible = true;
            this.gcolPhone.VisibleIndex = 3;
            this.gcolPhone.Width = 47;
            // 
            // gcolJobTitle
            // 
            this.gcolJobTitle.Caption = "Job Title";
            this.gcolJobTitle.FieldName = "TitleForJob";
            this.gcolJobTitle.Name = "gcolJobTitle";
            // 
            // gcolStatusID
            // 
            this.gcolStatusID.Caption = "Status";
            this.gcolStatusID.FieldName = "ContactStatus";
            this.gcolStatusID.Name = "gcolStatusID";
            this.gcolStatusID.Width = 79;
            // 
            // gcolStatus
            // 
            this.gcolStatus.Caption = "Status";
            this.gcolStatus.FieldName = "Status";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.Visible = true;
            this.gcolStatus.VisibleIndex = 4;
            // 
            // gcolContact1Name
            // 
            this.gcolContact1Name.Caption = "Contact 1 Name";
            this.gcolContact1Name.FieldName = "Contact1";
            this.gcolContact1Name.Name = "gcolContact1Name";
            // 
            // gcolContactPhone1
            // 
            this.gcolContactPhone1.Caption = "Contact Phone 1";
            this.gcolContactPhone1.FieldName = "Contact1Phone";
            this.gcolContactPhone1.Name = "gcolContactPhone1";
            // 
            // gcolContact2Name
            // 
            this.gcolContact2Name.Caption = "Contact 2 Name";
            this.gcolContact2Name.FieldName = "Contact2";
            this.gcolContact2Name.Name = "gcolContact2Name";
            // 
            // gcolContactPhone2
            // 
            this.gcolContactPhone2.Caption = "Contact Phone 2";
            this.gcolContactPhone2.FieldName = "Contact2Phone";
            this.gcolContactPhone2.Name = "gcolContactPhone2";
            // 
            // gcolMobilePhone
            // 
            this.gcolMobilePhone.Caption = "Mobile Phone";
            this.gcolMobilePhone.FieldName = "PhoneMobile1";
            this.gcolMobilePhone.Name = "gcolMobilePhone";
            // 
            // gcolDateJoined
            // 
            this.gcolDateJoined.Caption = "Date Joined";
            this.gcolDateJoined.FieldName = "DateJoined";
            this.gcolDateJoined.Name = "gcolDateJoined";
            // 
            // colAccRepName
            // 
            this.colAccRepName.Caption = "Acc. Rep Name";
            this.colAccRepName.FieldName = "AccRepName";
            this.colAccRepName.Name = "colAccRepName";
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
            this.pnl_Find.Size = new System.Drawing.Size(672, 88);
            this.pnl_Find.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(484, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 84);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 84);
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
            // frmContactBrw
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(672, 333);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmContactBrw";
            this.ShowInTaskbar = false;
            this.Text = "Contacts...";
            this.Load += new System.EventHandler(this.frmContactBrw_Load);
            this.pnlBody.ResumeLayout(false);
            this.pnl_SpeedSearch.ResumeLayout(false);
            this.pnl_SpeedSearch1.ResumeLayout(false);
            this.pnl_SpeedSearch1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwContact)).EndInit();
            this.pnl_Find.ResumeLayout(false);
            this.pnl_Find.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void FindPanel()
		{
			if(pnl_Find.Height == 80)
				pnl_Find.Height = 0;
			else
			{
				while(pnl_Find.Height < 80)
				{
					pnl_Find.Height = pnl_Find.Height + 4;
					pnl_Find.Refresh();
					txtSearch.Focus();
				}
			}
		}

		public int GetRecordCount()
		{
			return gvwContact.RowCount;
		}

		private void pnlBody_Resize(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void SpeedSearch()
		{
			int iRowPos = gvwContact.FocusedRowHandle;
			string strGridValue = "";
			foreach(DevExpress.XtraGrid.Columns.GridColumn col in gvwContact.Columns)
			{
				if(col.SortIndex>=0)
				{
					for(int intCtr=0;intCtr<gvwContact.RowCount;intCtr++)
					{
						if(col.VisibleIndex>-1)
						{
							if(gvwContact.GetRowCellValue(intCtr, col) !=System.DBNull.Value)
							{
								strGridValue = gvwContact.GetRowCellValue(intCtr, col).ToString();
								if(strGridValue.ToUpper().Trim().StartsWith(txt_SpeedSearch.Text.Trim().ToUpper()))
								{
									gvwContact.FocusedRowHandle = intCtr;
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
				grdContact.Focus();
				grdContact.Select();
			}
		}

		private void txt_SpeedSearch_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			SpeedSearch();
		}

		private void grdContact_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
						grdContact.Focus();
						grdContact.Select();
					}
				}
			}		
		}

		public void LoadContact(string option)
		{
			

			objContact = new Scheduler.BusinessLayer.Contact();
			objContact.LoadData(option);
			dtbl = objContact.dtblContacts;
			grdContact.DataSource = dtbl;
            if (option == "Client")
            {
                gcolCompany.VisibleIndex = 0;
                gcolCompany.Caption = "Client Name";
                //gcolContactName.VisibleIndex=1;
                //gcolContactNameRomaji.VisibleIndex=2;
                //gcolPhone.VisibleIndex=3;
                gcolContact1Name.VisibleIndex = 1;
                gcolContactPhone1.VisibleIndex = 2;
                gcolContact2Name.VisibleIndex = 3;
                gcolContactPhone2.VisibleIndex = 4;
                colAccRepName.VisibleIndex = 5;
                gcolStatus.VisibleIndex = 6;
                gcolPhone.Caption = "Phone";
                
                gcolContactName.VisibleIndex = -1;
                gcolContactNameRomaji.VisibleIndex = -1;
                gcolPhone.VisibleIndex = -1;
                gColLastName.VisibleIndex = -1;
                gcolFirstName.VisibleIndex = -1;
                gcolLastNameRomaji.VisibleIndex = -1;
                gcolFirstNameRomaji.VisibleIndex = -1;
                gcolJobTitle.VisibleIndex = -1;
                gcolStreet.VisibleIndex = -1;
                gcolCity.VisibleIndex = -1;
                gcolState.VisibleIndex = -1;
                gcolCountry.VisibleIndex = -1;
                gcolEmail1.VisibleIndex = -1;
                gcolDateJoined.VisibleIndex = -1;
                gcolMobilePhone.VisibleIndex = -1;

            }
            else if (option == "Instructor")
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvwContact.Columns)
                {
                    col.Visible = false;
                }

                gcolCompany.Caption = "Company";


                //gColLastName.Visible = true;
                gColLastName.VisibleIndex = 0;
                gcolFirstName.VisibleIndex = 1;
                gcolPhone.Caption = "Home Phone";
                gcolPhone.VisibleIndex = 2;
                gcolMobilePhone.VisibleIndex = 3;
                gcolEmail1.VisibleIndex = 4;
                gcolDateJoined.VisibleIndex = 5;
                gcolStatus.VisibleIndex = 6;
                gcolLastNameRomaji.VisibleIndex = -1;
                gcolFirstNameRomaji.VisibleIndex = -1;
                gcolJobTitle.VisibleIndex = -1;
                //gcolPhone.VisibleIndex = -1;
                
                gcolCompany.VisibleIndex = -1;


                /*gcolContact1Name.VisibleIndex = -1;
                gcolContact1Name.VisibleIndex = -1;
                gcolContactPhone1.VisibleIndex = -1;
                gcolContact2Name.VisibleIndex = -1;
                gcolContactPhone2.VisibleIndex = -1;

                gcolStreet.VisibleIndex = -1;
                gcolCity.VisibleIndex = -1;
                gcolState.VisibleIndex = -1;
                gcolCountry.VisibleIndex = -1;
                
                gcolContactName.VisibleIndex = -1;
                gcolContactNameRomaji.VisibleIndex = -1;*/

            }
			//gvwContact.UnselectRow(0);
			//gvwContact.FocusedRowHandle = CurrRec;
			//gvwContact.SelectRow(CurrRec);

			//Global.ShowRecords(Finddtbl);
		}

		private void frmContactBrw_Load(object sender, System.EventArgs e)
		{
			//LoadContact(option);
		}

		private void FindRoutine()
		{
			gvwContact.BeginUpdate();
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
				gvwContact.EndUpdate();
			}
		}

		private void btn_Find_Click(object sender, System.EventArgs e)
		{
			if (boolFetch==false) LoadContact(option);
			FindRoutine();
		}

		private void btn_Clear_Click(object sender, System.EventArgs e)
		{
			txtSearch.Text = "";
			LoadContact(option);
		}

		private void grdContact_DoubleClick(object sender, System.EventArgs e)
		{
			int intContact=0;
			int row=0;

			row=gvwContact.FocusedRowHandle;

			if(gvwContact.FocusedRowHandle<0)
			{
				Scheduler.BusinessLayer.Message.MsgInformation("No record exists.");
				return;
			}
			intContact = Convert.ToInt32(gvwContact.GetRowCellValue(gvwContact.FocusedRowHandle, gcolContactID));

			if(Option=="Contact")
			{
				frmContactDlg fContactDlg = new frmContactDlg();
				fContactDlg.ContactID = intContact;
				fContactDlg.Mode="Edit";
				fContactDlg.LoadData();
				if(fContactDlg.ShowDialog()==DialogResult.OK)
				{
					LoadContact(option);
				}
				fContactDlg.Close();
				fContactDlg.Dispose();
				fContactDlg=null;
			}
			else if(Option=="Instructor")
			{
				frmInstructorDlg fContactDlg = new frmInstructorDlg();
				fContactDlg.ContactID = intContact;
				fContactDlg.Mode="Edit";
				fContactDlg.LoadData();
				if(fContactDlg.ShowDialog()==DialogResult.OK)
				{
					LoadContact(option);
				}
				fContactDlg.Close();
				fContactDlg.Dispose();
				fContactDlg=null;
			}
			else if(Option=="Client")
			{
				frmClientDlg fContactDlg = new frmClientDlg();
				fContactDlg.ContactID = intContact;
				fContactDlg.Mode="Edit";
				fContactDlg.LoadData();
				if(fContactDlg.ShowDialog()==DialogResult.OK)
				{
					LoadContact(option);
				}
				fContactDlg.Close();
				fContactDlg.Dispose();
				fContactDlg=null;
			}

			gvwContact.FocusedRowHandle=row;
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
