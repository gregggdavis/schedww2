using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Scheduler.BusinessLayer;
using System.Drawing.Printing;

namespace Scheduler
{
	/// <summary>
	/// Summary description for editing depatment form.
	/// </summary>
	public class frmDepartmentDlg : System.Windows.Forms.Form
	{
		#region Controls 
		private Button btnCancel;
		private Button btnSave;
		private Label lblStatus;
		private ComboBox cmbStatus;
		private TabControl tbcDepartment;
		private TabPage tbpDeptInfo;
		private Label label13;
		private GroupBox groupBox1;
		private Label label11;
		private TextBox txtCompRomaji;
		private TextBox txtCompPhonetic;
		private Label label4;
		private Label label5;
		private TextBox txtCompName;
		private Label label6;
		private DateTimePicker dtEnded;
		private DateTimePicker dtJoined;
		private Label lblHRHeader;
		private GroupBox groupBox12;
		private Label label42;
		private Label label39;
		private Label label36;
		private TextBox txtUrl;
		private Label label38;
		private TextBox txtFax2;
		private TextBox txtFax1;
		private Label label41;
		private Label lblContactInfoHeader;
		private GroupBox groupBox2;
		private Label label43;
		private TextBox txtPhoneOther;
		private Label label33;
		private TextBox txtPhone2;
		private TextBox txtPhone1;
		private Label label32;
		private Label lblStation2Header;
		private GroupBox groupBox11;
		private TextBox txtMintSt2;
		private TextBox txtClosestLine2;
		private Label label60;
		private Label label61;
		private TextBox txtClosestSt2;
		private Label label62;
		private Label lblStation1Header;
		private GroupBox groupBox10;
		private TextBox txtMintSt1;
		private TextBox txtClosestLine1;
		private Label label55;
		private Label label56;
		private TextBox txtClosestSt1;
		private Label label57;
		private Label label28;
		private Label label29;
		private ComboBox cmbBlock;
		private TextBox txtCountry;
		private Label label27;
		private TextBox txtPost;
		private TextBox txtState;
		private Label label26;
		private TextBox txtCity;
		private Label label25;
		private TextBox txtStreet3;
		private TextBox txtStreet2;
		private TextBox txtStreet1;
		private Label label24;
		private Label lblAddressHeader;
        private GroupBox groupBox8;
		private LinkLabel llblClient;
		private ComboBox cmbClient;
		private Label label48;
		private GroupBox groupBox9;
		private TextBox txtAccFirstRomaji;
		private TextBox txtAccFirstPhonetic;
		private Label label49;
		private Label label50;
		private TextBox txtAccFirstName;
		private Label label51;
		private TextBox txtAccLRomaji1;
		private TextBox txtAccLPhonetic;
		private Label label52;
		private Label label53;
		private TextBox txtAccLName;
		private Label label54;
		private Button btnDelete;
		private TabPage tbpAddress;
		private TabPage tbpContact;
		private PersistentRepository persistentRepository1;
		private Panel pnlBody;
		private Panel pnlBottom;
		private RepositoryItemTextEdit repositoryItemTextEdit1;
		public GridControl grdContact;
		public GridView gvwContact;
		public GridColumn gcolContactID;
		private GridColumn gcolContactType;
		private GridColumn gcolType;
		private GridColumn gColLastName;
		private GridColumn gcolFirstName;
		private GridColumn gcolLastNameRomaji;
		private GridColumn gcolFirstNameRomaji;
		private GridColumn gcolEmail1;
		private GridColumn gcolPhone;
		private GridColumn gcolMobile;
		private GridColumn gcolStatusID;
		private GridColumn gcolStatus;
		private Button btnDel;
		private Button btnEdit;
		private Button btnAdd;
		private CheckBox chkNoDept;
		private TextBox txtNickName;
		private Label lblNickName;
		private Button btnPrint;
		private Panel pnlDeptInfo;
		private Panel pnlAddress;
		private Button btnPageSetup;
		private Button button1;
		private PrintPreviewDialog printPreviewDialog1;
        private PrintDocument printDocument1;
        private Button btnImportClientAddress;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private Panel pnlContact;
		private IContainer components;
		#endregion Controls

		public frmDepartmentDlg()
		{
			InitializeComponent();
            string query = "Select CompanyName = CASE " +
                "WHEN NickName IS NULL THEN [CompanyName] " +
                "WHEN NickName = '' THEN [CompanyName] " +
                "ELSE NickName " +
                "END From " +
                "Contact Where ContactType=2 " +
                " Order By CompanyName";
            
			Common.PopulateDropdown(
				cmbClient, query);

            

			/*Common.PopulateDropdown(
				cmbContact, "Select LastName + ', ' + FirstName from " +
				"Contact Where ContactStatus=0 " +
				"Order By ContactID");
			*/
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartmentDlg));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tbcDepartment = new System.Windows.Forms.TabControl();
            this.tbpDeptInfo = new System.Windows.Forms.TabPage();
            this.pnlDeptInfo = new System.Windows.Forms.Panel();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.lblNickName = new System.Windows.Forms.Label();
            this.chkNoDept = new System.Windows.Forms.CheckBox();
            this.llblClient = new System.Windows.Forms.LinkLabel();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.dtEnded = new System.Windows.Forms.DateTimePicker();
            this.dtJoined = new System.Windows.Forms.DateTimePicker();
            this.lblHRHeader = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCompRomaji = new System.Windows.Forms.TextBox();
            this.txtCompPhonetic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbpAddress = new System.Windows.Forms.TabPage();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.btnImportClientAddress = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtAccFirstRomaji = new System.Windows.Forms.TextBox();
            this.txtAccFirstPhonetic = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.txtAccFirstName = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtAccLRomaji1 = new System.Windows.Forms.TextBox();
            this.txtAccLPhonetic = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txtAccLName = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtFax2 = new System.Windows.Forms.TextBox();
            this.txtFax1 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.lblContactInfoHeader = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtPhoneOther = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.lblStation2Header = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtMintSt2 = new System.Windows.Forms.TextBox();
            this.txtClosestLine2 = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.txtClosestSt2 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.lblStation1Header = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtMintSt1 = new System.Windows.Forms.TextBox();
            this.txtClosestLine1 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtClosestSt1 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbBlock = new System.Windows.Forms.ComboBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtStreet3 = new System.Windows.Forms.TextBox();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.txtStreet1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lblAddressHeader = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbpContact = new System.Windows.Forms.TabPage();
            this.pnlContact = new System.Windows.Forms.Panel();
            this.grdContact = new DevExpress.XtraGrid.GridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gvwContact = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolContactID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContactType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLastNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFirstNameRomaji = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEmail1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.tbcDepartment.SuspendLayout();
            this.tbpDeptInfo.SuspendLayout();
            this.pnlDeptInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbpAddress.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.tbpContact.SuspendLayout();
            this.pnlContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwContact)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(480, 525);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(397, 525);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(384, 106);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(88, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(486, 104);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 21);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // tbcDepartment
            // 
            this.tbcDepartment.Controls.Add(this.tbpDeptInfo);
            this.tbcDepartment.Controls.Add(this.tbpAddress);
            this.tbcDepartment.Controls.Add(this.tbpContact);
            this.tbcDepartment.Location = new System.Drawing.Point(0, 2);
            this.tbcDepartment.Name = "tbcDepartment";
            this.tbcDepartment.SelectedIndex = 0;
            this.tbcDepartment.Size = new System.Drawing.Size(648, 510);
            this.tbcDepartment.TabIndex = 15;
            // 
            // tbpDeptInfo
            // 
            this.tbpDeptInfo.Controls.Add(this.pnlDeptInfo);
            this.tbpDeptInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpDeptInfo.Name = "tbpDeptInfo";
            this.tbpDeptInfo.Size = new System.Drawing.Size(640, 484);
            this.tbpDeptInfo.TabIndex = 0;
            this.tbpDeptInfo.Text = "Department Info";
            // 
            // pnlDeptInfo
            // 
            this.pnlDeptInfo.Controls.Add(this.txtNickName);
            this.pnlDeptInfo.Controls.Add(this.lblNickName);
            this.pnlDeptInfo.Controls.Add(this.chkNoDept);
            this.pnlDeptInfo.Controls.Add(this.llblClient);
            this.pnlDeptInfo.Controls.Add(this.cmbClient);
            this.pnlDeptInfo.Controls.Add(this.dtEnded);
            this.pnlDeptInfo.Controls.Add(this.dtJoined);
            this.pnlDeptInfo.Controls.Add(this.lblHRHeader);
            this.pnlDeptInfo.Controls.Add(this.groupBox12);
            this.pnlDeptInfo.Controls.Add(this.label42);
            this.pnlDeptInfo.Controls.Add(this.label39);
            this.pnlDeptInfo.Controls.Add(this.label13);
            this.pnlDeptInfo.Controls.Add(this.groupBox1);
            this.pnlDeptInfo.Controls.Add(this.txtCompRomaji);
            this.pnlDeptInfo.Controls.Add(this.txtCompPhonetic);
            this.pnlDeptInfo.Controls.Add(this.label4);
            this.pnlDeptInfo.Controls.Add(this.label5);
            this.pnlDeptInfo.Controls.Add(this.txtCompName);
            this.pnlDeptInfo.Controls.Add(this.label6);
            this.pnlDeptInfo.Controls.Add(this.lblStatus);
            this.pnlDeptInfo.Controls.Add(this.cmbStatus);
            this.pnlDeptInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeptInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlDeptInfo.Name = "pnlDeptInfo";
            this.pnlDeptInfo.Size = new System.Drawing.Size(640, 484);
            this.pnlDeptInfo.TabIndex = 337;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(147, 153);
            this.txtNickName.MaxLength = 255;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(192, 21);
            this.txtNickName.TabIndex = 3;
            // 
            // lblNickName
            // 
            this.lblNickName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNickName.Location = new System.Drawing.Point(27, 155);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(114, 17);
            this.lblNickName.TabIndex = 336;
            this.lblNickName.Text = "Abbreviated Name";
            // 
            // chkNoDept
            // 
            this.chkNoDept.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNoDept.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoDept.Location = new System.Drawing.Point(27, 56);
            this.chkNoDept.Name = "chkNoDept";
            this.chkNoDept.Size = new System.Drawing.Size(134, 16);
            this.chkNoDept.TabIndex = 334;
            this.chkNoDept.Text = "No Department";
            this.chkNoDept.CheckedChanged += new System.EventHandler(this.chkNoDept_CheckedChanged);
            // 
            // llblClient
            // 
            this.llblClient.Location = new System.Drawing.Point(24, 34);
            this.llblClient.Name = "llblClient";
            this.llblClient.Size = new System.Drawing.Size(104, 17);
            this.llblClient.TabIndex = 3;
            this.llblClient.TabStop = true;
            this.llblClient.Text = "Client";
            this.llblClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblClient_LinkClicked);
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Items.AddRange(new object[] {
            "Class",
            "Desk",
            "Presentation Training",
            "Recording",
            "Mendan",
            "Other"});
            this.cmbClient.Location = new System.Drawing.Point(147, 31);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(192, 21);
            this.cmbClient.TabIndex = 4;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // dtEnded
            // 
            this.dtEnded.CustomFormat = "MM/dd/yyyy";
            this.dtEnded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnded.Location = new System.Drawing.Point(486, 56);
            this.dtEnded.Name = "dtEnded";
            this.dtEnded.ShowCheckBox = true;
            this.dtEnded.Size = new System.Drawing.Size(120, 21);
            this.dtEnded.TabIndex = 6;
            // 
            // dtJoined
            // 
            this.dtJoined.CustomFormat = "MM/dd/yyyy";
            this.dtJoined.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtJoined.Location = new System.Drawing.Point(486, 32);
            this.dtJoined.Name = "dtJoined";
            this.dtJoined.ShowCheckBox = true;
            this.dtJoined.Size = new System.Drawing.Size(120, 21);
            this.dtJoined.TabIndex = 5;
            // 
            // lblHRHeader
            // 
            this.lblHRHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHRHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHRHeader.Location = new System.Drawing.Point(384, 9);
            this.lblHRHeader.Name = "lblHRHeader";
            this.lblHRHeader.Size = new System.Drawing.Size(27, 17);
            this.lblHRHeader.TabIndex = 238;
            this.lblHRHeader.Text = "HR";
            // 
            // groupBox12
            // 
            this.groupBox12.Location = new System.Drawing.Point(408, 16);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(200, 2);
            this.groupBox12.TabIndex = 237;
            this.groupBox12.TabStop = false;
            // 
            // label42
            // 
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.Location = new System.Drawing.Point(384, 58);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(88, 17);
            this.label42.TabIndex = 236;
            this.label42.Text = "Date Ended";
            // 
            // label39
            // 
            this.label39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label39.Location = new System.Drawing.Point(384, 34);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(88, 17);
            this.label39.TabIndex = 235;
            this.label39.Text = "Date Joined";
            // 
            // label13
            // 
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(24, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 17);
            this.label13.TabIndex = 79;
            this.label13.Text = "Department";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(110, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 2);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(24, -56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 21);
            this.label11.TabIndex = 73;
            this.label11.Text = "Company";
            // 
            // txtCompRomaji
            // 
            this.txtCompRomaji.Location = new System.Drawing.Point(147, 128);
            this.txtCompRomaji.MaxLength = 255;
            this.txtCompRomaji.Name = "txtCompRomaji";
            this.txtCompRomaji.Size = new System.Drawing.Size(192, 21);
            this.txtCompRomaji.TabIndex = 2;
            // 
            // txtCompPhonetic
            // 
            this.txtCompPhonetic.Location = new System.Drawing.Point(147, 104);
            this.txtCompPhonetic.MaxLength = 255;
            this.txtCompPhonetic.Name = "txtCompPhonetic";
            this.txtCompPhonetic.Size = new System.Drawing.Size(192, 21);
            this.txtCompPhonetic.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(27, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Name Romaji";
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(27, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Name Phonetic";
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(147, 80);
            this.txtCompName.MaxLength = 255;
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(192, 21);
            this.txtCompName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(27, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 75;
            this.label6.Text = "Name";
            // 
            // tbpAddress
            // 
            this.tbpAddress.Controls.Add(this.pnlAddress);
            this.tbpAddress.Location = new System.Drawing.Point(4, 22);
            this.tbpAddress.Name = "tbpAddress";
            this.tbpAddress.Size = new System.Drawing.Size(640, 484);
            this.tbpAddress.TabIndex = 1;
            this.tbpAddress.Text = "Address";
            // 
            // pnlAddress
            // 
            this.pnlAddress.Controls.Add(this.btnImportClientAddress);
            this.pnlAddress.Controls.Add(this.label48);
            this.pnlAddress.Controls.Add(this.groupBox9);
            this.pnlAddress.Controls.Add(this.txtAccFirstRomaji);
            this.pnlAddress.Controls.Add(this.txtAccFirstPhonetic);
            this.pnlAddress.Controls.Add(this.label49);
            this.pnlAddress.Controls.Add(this.label50);
            this.pnlAddress.Controls.Add(this.txtAccFirstName);
            this.pnlAddress.Controls.Add(this.label51);
            this.pnlAddress.Controls.Add(this.txtAccLRomaji1);
            this.pnlAddress.Controls.Add(this.txtAccLPhonetic);
            this.pnlAddress.Controls.Add(this.label52);
            this.pnlAddress.Controls.Add(this.label53);
            this.pnlAddress.Controls.Add(this.txtAccLName);
            this.pnlAddress.Controls.Add(this.label54);
            this.pnlAddress.Controls.Add(this.label36);
            this.pnlAddress.Controls.Add(this.txtUrl);
            this.pnlAddress.Controls.Add(this.label38);
            this.pnlAddress.Controls.Add(this.txtFax2);
            this.pnlAddress.Controls.Add(this.txtFax1);
            this.pnlAddress.Controls.Add(this.label41);
            this.pnlAddress.Controls.Add(this.lblContactInfoHeader);
            this.pnlAddress.Controls.Add(this.groupBox2);
            this.pnlAddress.Controls.Add(this.label43);
            this.pnlAddress.Controls.Add(this.txtPhoneOther);
            this.pnlAddress.Controls.Add(this.label33);
            this.pnlAddress.Controls.Add(this.txtPhone2);
            this.pnlAddress.Controls.Add(this.txtPhone1);
            this.pnlAddress.Controls.Add(this.label32);
            this.pnlAddress.Controls.Add(this.lblStation2Header);
            this.pnlAddress.Controls.Add(this.groupBox11);
            this.pnlAddress.Controls.Add(this.txtMintSt2);
            this.pnlAddress.Controls.Add(this.txtClosestLine2);
            this.pnlAddress.Controls.Add(this.label60);
            this.pnlAddress.Controls.Add(this.label61);
            this.pnlAddress.Controls.Add(this.txtClosestSt2);
            this.pnlAddress.Controls.Add(this.label62);
            this.pnlAddress.Controls.Add(this.lblStation1Header);
            this.pnlAddress.Controls.Add(this.groupBox10);
            this.pnlAddress.Controls.Add(this.txtMintSt1);
            this.pnlAddress.Controls.Add(this.txtClosestLine1);
            this.pnlAddress.Controls.Add(this.label55);
            this.pnlAddress.Controls.Add(this.label56);
            this.pnlAddress.Controls.Add(this.txtClosestSt1);
            this.pnlAddress.Controls.Add(this.label57);
            this.pnlAddress.Controls.Add(this.label28);
            this.pnlAddress.Controls.Add(this.label29);
            this.pnlAddress.Controls.Add(this.cmbBlock);
            this.pnlAddress.Controls.Add(this.txtCountry);
            this.pnlAddress.Controls.Add(this.label27);
            this.pnlAddress.Controls.Add(this.txtPost);
            this.pnlAddress.Controls.Add(this.txtState);
            this.pnlAddress.Controls.Add(this.label26);
            this.pnlAddress.Controls.Add(this.txtCity);
            this.pnlAddress.Controls.Add(this.label25);
            this.pnlAddress.Controls.Add(this.txtStreet3);
            this.pnlAddress.Controls.Add(this.txtStreet2);
            this.pnlAddress.Controls.Add(this.txtStreet1);
            this.pnlAddress.Controls.Add(this.label24);
            this.pnlAddress.Controls.Add(this.lblAddressHeader);
            this.pnlAddress.Controls.Add(this.groupBox8);
            this.pnlAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddress.Location = new System.Drawing.Point(0, 0);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(640, 484);
            this.pnlAddress.TabIndex = 312;
            // 
            // btnImportClientAddress
            // 
            this.btnImportClientAddress.Enabled = false;
            this.btnImportClientAddress.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImportClientAddress.Location = new System.Drawing.Point(200, 7);
            this.btnImportClientAddress.Name = "btnImportClientAddress";
            this.btnImportClientAddress.Size = new System.Drawing.Size(240, 23);
            this.btnImportClientAddress.TabIndex = 312;
            this.btnImportClientAddress.Text = "Import Client\'s Address Information";
            this.btnImportClientAddress.Click += new System.EventHandler(this.btnImportClientAddress_Click);
            // 
            // label48
            // 
            this.label48.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label48.Location = new System.Drawing.Point(342, 284);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(151, 17);
            this.label48.TabIndex = 311;
            this.label48.Text = "Internal Accounts Rep";
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(474, 292);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(144, 2);
            this.groupBox9.TabIndex = 310;
            this.groupBox9.TabStop = false;
            // 
            // txtAccFirstRomaji
            // 
            this.txtAccFirstRomaji.Location = new System.Drawing.Point(464, 436);
            this.txtAccFirstRomaji.MaxLength = 255;
            this.txtAccFirstRomaji.Name = "txtAccFirstRomaji";
            this.txtAccFirstRomaji.Size = new System.Drawing.Size(165, 21);
            this.txtAccFirstRomaji.TabIndex = 255;
            // 
            // txtAccFirstPhonetic
            // 
            this.txtAccFirstPhonetic.Location = new System.Drawing.Point(464, 412);
            this.txtAccFirstPhonetic.MaxLength = 255;
            this.txtAccFirstPhonetic.Name = "txtAccFirstPhonetic";
            this.txtAccFirstPhonetic.Size = new System.Drawing.Size(165, 21);
            this.txtAccFirstPhonetic.TabIndex = 254;
            // 
            // label49
            // 
            this.label49.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label49.Location = new System.Drawing.Point(342, 438);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(114, 17);
            this.label49.TabIndex = 309;
            this.label49.Text = "First Name Romaji";
            // 
            // label50
            // 
            this.label50.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label50.Location = new System.Drawing.Point(342, 414);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(118, 17);
            this.label50.TabIndex = 308;
            this.label50.Text = "First Name Phonetic";
            // 
            // txtAccFirstName
            // 
            this.txtAccFirstName.Location = new System.Drawing.Point(464, 388);
            this.txtAccFirstName.MaxLength = 255;
            this.txtAccFirstName.Name = "txtAccFirstName";
            this.txtAccFirstName.Size = new System.Drawing.Size(165, 21);
            this.txtAccFirstName.TabIndex = 253;
            // 
            // label51
            // 
            this.label51.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label51.Location = new System.Drawing.Point(342, 390);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(114, 17);
            this.label51.TabIndex = 307;
            this.label51.Text = "First Name";
            // 
            // txtAccLRomaji1
            // 
            this.txtAccLRomaji1.Location = new System.Drawing.Point(464, 356);
            this.txtAccLRomaji1.MaxLength = 255;
            this.txtAccLRomaji1.Name = "txtAccLRomaji1";
            this.txtAccLRomaji1.Size = new System.Drawing.Size(165, 21);
            this.txtAccLRomaji1.TabIndex = 252;
            // 
            // txtAccLPhonetic
            // 
            this.txtAccLPhonetic.Location = new System.Drawing.Point(464, 332);
            this.txtAccLPhonetic.MaxLength = 255;
            this.txtAccLPhonetic.Name = "txtAccLPhonetic";
            this.txtAccLPhonetic.Size = new System.Drawing.Size(165, 21);
            this.txtAccLPhonetic.TabIndex = 251;
            this.txtAccLPhonetic.TextChanged += new System.EventHandler(this.txtAccLPhonetic_TextChanged);
            // 
            // label52
            // 
            this.label52.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label52.Location = new System.Drawing.Point(342, 358);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(114, 17);
            this.label52.TabIndex = 306;
            this.label52.Text = "Last Name Romaji";
            // 
            // label53
            // 
            this.label53.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label53.Location = new System.Drawing.Point(342, 334);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(114, 17);
            this.label53.TabIndex = 305;
            this.label53.Text = "Last Name Phonetic";
            this.label53.Click += new System.EventHandler(this.label53_Click);
            // 
            // txtAccLName
            // 
            this.txtAccLName.Location = new System.Drawing.Point(464, 308);
            this.txtAccLName.MaxLength = 255;
            this.txtAccLName.Name = "txtAccLName";
            this.txtAccLName.Size = new System.Drawing.Size(165, 21);
            this.txtAccLName.TabIndex = 250;
            // 
            // label54
            // 
            this.label54.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label54.Location = new System.Drawing.Point(342, 310);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(114, 17);
            this.label54.TabIndex = 304;
            this.label54.Text = "Last Name";
            // 
            // label36
            // 
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.Location = new System.Drawing.Point(344, 188);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(114, 17);
            this.label36.TabIndex = 287;
            this.label36.Text = "Fax 2";
            // 
            // txtUrl
            // 
            this.txtUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUrl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtUrl.Location = new System.Drawing.Point(464, 210);
            this.txtUrl.MaxLength = 255;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(165, 21);
            this.txtUrl.TabIndex = 249;
            // 
            // label38
            // 
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.Location = new System.Drawing.Point(344, 212);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(114, 17);
            this.label38.TabIndex = 286;
            this.label38.Text = "URL";
            // 
            // txtFax2
            // 
            this.txtFax2.Location = new System.Drawing.Point(464, 186);
            this.txtFax2.MaxLength = 255;
            this.txtFax2.Name = "txtFax2";
            this.txtFax2.Size = new System.Drawing.Size(165, 21);
            this.txtFax2.TabIndex = 248;
            // 
            // txtFax1
            // 
            this.txtFax1.Location = new System.Drawing.Point(464, 162);
            this.txtFax1.MaxLength = 255;
            this.txtFax1.Name = "txtFax1";
            this.txtFax1.Size = new System.Drawing.Size(165, 21);
            this.txtFax1.TabIndex = 247;
            // 
            // label41
            // 
            this.label41.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label41.Location = new System.Drawing.Point(344, 164);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(114, 17);
            this.label41.TabIndex = 285;
            this.label41.Text = "Fax 1";
            // 
            // lblContactInfoHeader
            // 
            this.lblContactInfoHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblContactInfoHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInfoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblContactInfoHeader.Location = new System.Drawing.Point(342, 47);
            this.lblContactInfoHeader.Name = "lblContactInfoHeader";
            this.lblContactInfoHeader.Size = new System.Drawing.Size(86, 17);
            this.lblContactInfoHeader.TabIndex = 284;
            this.lblContactInfoHeader.Text = "Contact Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(421, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 2);
            this.groupBox2.TabIndex = 283;
            this.groupBox2.TabStop = false;
            // 
            // label43
            // 
            this.label43.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label43.Location = new System.Drawing.Point(344, 140);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(114, 17);
            this.label43.TabIndex = 281;
            this.label43.Text = "Phone Other";
            // 
            // txtPhoneOther
            // 
            this.txtPhoneOther.Location = new System.Drawing.Point(464, 138);
            this.txtPhoneOther.MaxLength = 255;
            this.txtPhoneOther.Name = "txtPhoneOther";
            this.txtPhoneOther.Size = new System.Drawing.Size(165, 21);
            this.txtPhoneOther.TabIndex = 246;
            // 
            // label33
            // 
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.Location = new System.Drawing.Point(342, 102);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(114, 17);
            this.label33.TabIndex = 280;
            this.label33.Text = "Phone 2";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(464, 100);
            this.txtPhone2.MaxLength = 255;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(165, 21);
            this.txtPhone2.TabIndex = 245;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(464, 76);
            this.txtPhone1.MaxLength = 255;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(165, 21);
            this.txtPhone1.TabIndex = 244;
            // 
            // label32
            // 
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label32.Location = new System.Drawing.Point(342, 78);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(114, 17);
            this.label32.TabIndex = 276;
            this.label32.Text = "Phone 1";
            // 
            // lblStation2Header
            // 
            this.lblStation2Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStation2Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation2Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStation2Header.Location = new System.Drawing.Point(12, 339);
            this.lblStation2Header.Name = "lblStation2Header";
            this.lblStation2Header.Size = new System.Drawing.Size(75, 17);
            this.lblStation2Header.TabIndex = 273;
            this.lblStation2Header.Text = "Station 2";
            // 
            // groupBox11
            // 
            this.groupBox11.Location = new System.Drawing.Point(80, 346);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(235, 2);
            this.groupBox11.TabIndex = 272;
            this.groupBox11.TabStop = false;
            // 
            // txtMintSt2
            // 
            this.txtMintSt2.Location = new System.Drawing.Point(120, 412);
            this.txtMintSt2.MaxLength = 255;
            this.txtMintSt2.Name = "txtMintSt2";
            this.txtMintSt2.Size = new System.Drawing.Size(72, 21);
            this.txtMintSt2.TabIndex = 243;
            this.txtMintSt2.Tag = "N";
            this.txtMintSt2.Text = "0";
            this.txtMintSt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMintSt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMintSt1_KeyPress);
            // 
            // txtClosestLine2
            // 
            this.txtClosestLine2.Location = new System.Drawing.Point(120, 388);
            this.txtClosestLine2.MaxLength = 255;
            this.txtClosestLine2.Name = "txtClosestLine2";
            this.txtClosestLine2.Size = new System.Drawing.Size(192, 21);
            this.txtClosestLine2.TabIndex = 242;
            // 
            // label60
            // 
            this.label60.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label60.Location = new System.Drawing.Point(12, 414);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(107, 17);
            this.label60.TabIndex = 271;
            this.label60.Text = "Minutes to Station";
            // 
            // label61
            // 
            this.label61.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label61.Location = new System.Drawing.Point(12, 390);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(100, 17);
            this.label61.TabIndex = 270;
            this.label61.Text = "Closest Line";
            // 
            // txtClosestSt2
            // 
            this.txtClosestSt2.Location = new System.Drawing.Point(120, 364);
            this.txtClosestSt2.MaxLength = 255;
            this.txtClosestSt2.Name = "txtClosestSt2";
            this.txtClosestSt2.Size = new System.Drawing.Size(192, 21);
            this.txtClosestSt2.TabIndex = 241;
            // 
            // label62
            // 
            this.label62.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label62.Location = new System.Drawing.Point(12, 366);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(107, 17);
            this.label62.TabIndex = 269;
            this.label62.Text = "Closest Station";
            // 
            // lblStation1Header
            // 
            this.lblStation1Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStation1Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation1Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStation1Header.Location = new System.Drawing.Point(8, 244);
            this.lblStation1Header.Name = "lblStation1Header";
            this.lblStation1Header.Size = new System.Drawing.Size(79, 17);
            this.lblStation1Header.TabIndex = 268;
            this.lblStation1Header.Text = "Station 1";
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(79, 252);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(235, 2);
            this.groupBox10.TabIndex = 267;
            this.groupBox10.TabStop = false;
            // 
            // txtMintSt1
            // 
            this.txtMintSt1.Location = new System.Drawing.Point(120, 308);
            this.txtMintSt1.MaxLength = 255;
            this.txtMintSt1.Name = "txtMintSt1";
            this.txtMintSt1.Size = new System.Drawing.Size(72, 21);
            this.txtMintSt1.TabIndex = 240;
            this.txtMintSt1.Tag = "N";
            this.txtMintSt1.Text = "0";
            this.txtMintSt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMintSt1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMintSt1_KeyPress);
            // 
            // txtClosestLine1
            // 
            this.txtClosestLine1.Location = new System.Drawing.Point(120, 284);
            this.txtClosestLine1.MaxLength = 255;
            this.txtClosestLine1.Name = "txtClosestLine1";
            this.txtClosestLine1.Size = new System.Drawing.Size(192, 21);
            this.txtClosestLine1.TabIndex = 239;
            // 
            // label55
            // 
            this.label55.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label55.Location = new System.Drawing.Point(12, 310);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(107, 17);
            this.label55.TabIndex = 266;
            this.label55.Text = "Minutes to Station";
            // 
            // label56
            // 
            this.label56.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label56.Location = new System.Drawing.Point(12, 286);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(100, 17);
            this.label56.TabIndex = 265;
            this.label56.Text = "Closest Line";
            // 
            // txtClosestSt1
            // 
            this.txtClosestSt1.Location = new System.Drawing.Point(120, 260);
            this.txtClosestSt1.MaxLength = 255;
            this.txtClosestSt1.Name = "txtClosestSt1";
            this.txtClosestSt1.Size = new System.Drawing.Size(192, 21);
            this.txtClosestSt1.TabIndex = 238;
            // 
            // label57
            // 
            this.label57.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label57.Location = new System.Drawing.Point(12, 262);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(107, 17);
            this.label57.TabIndex = 264;
            this.label57.Text = "Closest Station";
            // 
            // label28
            // 
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label28.Location = new System.Drawing.Point(195, 164);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 29);
            this.label28.TabIndex = 263;
            this.label28.Text = "Postal\r\nCode";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Location = new System.Drawing.Point(12, 220);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 17);
            this.label29.TabIndex = 262;
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
            this.cmbBlock.Location = new System.Drawing.Point(120, 218);
            this.cmbBlock.Name = "cmbBlock";
            this.cmbBlock.Size = new System.Drawing.Size(72, 21);
            this.cmbBlock.TabIndex = 237;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(120, 194);
            this.txtCountry.MaxLength = 255;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(192, 21);
            this.txtCountry.TabIndex = 236;
            // 
            // label27
            // 
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label27.Location = new System.Drawing.Point(12, 196);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 17);
            this.label27.TabIndex = 261;
            this.label27.Text = "Country";
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(253, 167);
            this.txtPost.MaxLength = 255;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(59, 21);
            this.txtPost.TabIndex = 235;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(120, 167);
            this.txtState.MaxLength = 255;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(72, 21);
            this.txtState.TabIndex = 234;
            // 
            // label26
            // 
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label26.Location = new System.Drawing.Point(12, 169);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 17);
            this.label26.TabIndex = 260;
            this.label26.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(120, 140);
            this.txtCity.MaxLength = 255;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(192, 21);
            this.txtCity.TabIndex = 233;
            // 
            // label25
            // 
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label25.Location = new System.Drawing.Point(12, 142);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 17);
            this.label25.TabIndex = 259;
            this.label25.Text = "City";
            // 
            // txtStreet3
            // 
            this.txtStreet3.Location = new System.Drawing.Point(120, 116);
            this.txtStreet3.MaxLength = 255;
            this.txtStreet3.Name = "txtStreet3";
            this.txtStreet3.Size = new System.Drawing.Size(192, 21);
            this.txtStreet3.TabIndex = 232;
            // 
            // txtStreet2
            // 
            this.txtStreet2.Location = new System.Drawing.Point(120, 92);
            this.txtStreet2.MaxLength = 255;
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(192, 21);
            this.txtStreet2.TabIndex = 231;
            // 
            // txtStreet1
            // 
            this.txtStreet1.Location = new System.Drawing.Point(120, 68);
            this.txtStreet1.MaxLength = 255;
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size(192, 21);
            this.txtStreet1.TabIndex = 230;
            // 
            // label24
            // 
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label24.Location = new System.Drawing.Point(12, 70);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 17);
            this.label24.TabIndex = 258;
            this.label24.Text = "Street";
            // 
            // lblAddressHeader
            // 
            this.lblAddressHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddressHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblAddressHeader.Location = new System.Drawing.Point(12, 47);
            this.lblAddressHeader.Name = "lblAddressHeader";
            this.lblAddressHeader.Size = new System.Drawing.Size(75, 17);
            this.lblAddressHeader.TabIndex = 257;
            this.lblAddressHeader.Text = "Address";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(80, 54);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(235, 2);
            this.groupBox8.TabIndex = 256;
            this.groupBox8.TabStop = false;
            // 
            // tbpContact
            // 
            this.tbpContact.Controls.Add(this.pnlContact);
            this.tbpContact.Controls.Add(this.pnlBottom);
            this.tbpContact.Controls.Add(this.pnlBody);
            this.tbpContact.Location = new System.Drawing.Point(4, 22);
            this.tbpContact.Name = "tbpContact";
            this.tbpContact.Size = new System.Drawing.Size(640, 484);
            this.tbpContact.TabIndex = 2;
            this.tbpContact.Text = "Contact";
            // 
            // pnlContact
            // 
            this.pnlContact.Controls.Add(this.grdContact);
            this.pnlContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContact.Location = new System.Drawing.Point(0, 0);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(640, 436);
            this.pnlContact.TabIndex = 2;
            // 
            // grdContact
            // 
            this.grdContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContact.ExternalRepository = this.persistentRepository1;
            this.grdContact.Location = new System.Drawing.Point(0, 0);
            this.grdContact.MainView = this.gvwContact;
            this.grdContact.Name = "grdContact";
            this.grdContact.Size = new System.Drawing.Size(640, 436);
            this.grdContact.TabIndex = 27;
            this.grdContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwContact});
            this.grdContact.DoubleClick += new System.EventHandler(this.grdContact_DoubleClick);
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
            this.gcolLastNameRomaji,
            this.gcolFirstNameRomaji,
            this.gcolEmail1,
            this.gcolPhone,
            this.gcolMobile,
            this.gcolStatusID,
            this.gcolStatus});
            this.gvwContact.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvwContact.GridControl = this.grdContact;
            this.gvwContact.Name = "gvwContact";
            this.gvwContact.OptionsBehavior.Editable = false;
            this.gvwContact.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gvwContact.OptionsCustomization.AllowFilter = false;
            this.gvwContact.OptionsDetail.EnableDetailToolTip = true;
            this.gvwContact.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvwContact.OptionsPrint.UsePrintStyles = true;
            this.gvwContact.OptionsView.ShowDetailButtons = false;
            this.gvwContact.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvwContact.OptionsView.ShowGroupPanel = false;
            this.gvwContact.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
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
            this.gColLastName.Width = 157;
            // 
            // gcolFirstName
            // 
            this.gcolFirstName.Caption = "First Name";
            this.gcolFirstName.FieldName = "FirstName";
            this.gcolFirstName.Name = "gcolFirstName";
            this.gcolFirstName.Visible = true;
            this.gcolFirstName.VisibleIndex = 1;
            this.gcolFirstName.Width = 157;
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
            // gcolEmail1
            // 
            this.gcolEmail1.Caption = "EMail";
            this.gcolEmail1.FieldName = "Email1";
            this.gcolEmail1.Name = "gcolEmail1";
            this.gcolEmail1.Visible = true;
            this.gcolEmail1.VisibleIndex = 2;
            this.gcolEmail1.Width = 78;
            // 
            // gcolPhone
            // 
            this.gcolPhone.Caption = "Phone";
            this.gcolPhone.FieldName = "Phone1";
            this.gcolPhone.Name = "gcolPhone";
            this.gcolPhone.Visible = true;
            this.gcolPhone.VisibleIndex = 3;
            this.gcolPhone.Width = 78;
            // 
            // gcolMobile
            // 
            this.gcolMobile.Caption = "Mobile";
            this.gcolMobile.DisplayFormat.FormatString = "Mobile";
            this.gcolMobile.FieldName = "PhoneMobile1";
            this.gcolMobile.Name = "gcolMobile";
            this.gcolMobile.Visible = true;
            this.gcolMobile.VisibleIndex = 4;
            this.gcolMobile.Width = 78;
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
            this.gcolStatus.VisibleIndex = 5;
            this.gcolStatus.Width = 80;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.button1);
            this.pnlBottom.Controls.Add(this.btnDel);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 436);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(640, 48);
            this.pnlBottom.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(279, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Print";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(178, 13);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 19;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Location = new System.Drawing.Point(98, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(16, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Location = new System.Drawing.Point(0, 142);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(446, 342);
            this.pnlBody.TabIndex = 0;
            this.pnlBody.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(563, 525);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(16, 525);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPageSetup.Location = new System.Drawing.Point(100, 525);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(75, 23);
            this.btnPageSetup.TabIndex = 18;
            this.btnPageSetup.Text = "Page Setup";
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
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
            // frmDepartmentDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(650, 560);
            this.Controls.Add(this.btnPageSetup);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbcDepartment);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepartmentDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding Department...";
            this.Load += new System.EventHandler(this.frmDepartmentDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDepartmentDlg_KeyDown);
            this.tbcDepartment.ResumeLayout(false);
            this.tbpDeptInfo.ResumeLayout(false);
            this.pnlDeptInfo.ResumeLayout(false);
            this.pnlDeptInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tbpAddress.ResumeLayout(false);
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.tbpContact.ResumeLayout(false);
            this.pnlContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwContact)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private string _mode="";
		private int _deptid=-1;
		private int _contactid=0;
		private bool deleted=false;
		private int intContactID=0;

		public string Mode
		{
			get{return _mode;}
			set{_mode=value;}
		}
		public int DeptID
		{
			get{return _deptid;}
			set{_deptid=value;}
		}
		public int ContactID
		{
			get{return _contactid;}
			set{_contactid=value;}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if(!deleted) this.DialogResult = DialogResult.Cancel;
			else if(deleted) this.DialogResult = DialogResult.OK;
			Close();
		}

		public void LoadData()
		{
            string revQuery = "Select CompanyName = CASE " +
                "WHEN NickName IS NULL THEN [CompanyName] " +
                "WHEN NickName = '' THEN [CompanyName] " +
                "ELSE NickName " +
                "END From " +
                "Contact Where ContactType=2 and " +
                "ContactStatus=1 Order By CompanyName";
            IDataReader reader = DAC.SelectStatement(revQuery);
			if (_mode == "Add")
			{
                while(reader.Read())
                {
                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        cmbClient.Items.Remove(reader["CompanyName"].ToString());
                    }
                }
				cmbClient.Text = String.Empty;
				cmbClient.Tag = String.Empty;
				cmbStatus.SelectedIndex = 0;

				txtCompName.Text = String.Empty;
				txtCompName.Tag = String.Empty;

				chkNoDept.Checked = false;

				txtCompPhonetic.Text = String.Empty;
				txtCompRomaji.Text = String.Empty;

				txtNickName.Text = String.Empty;
				txtNickName.Tag = String.Empty;

				txtAccLName.Text = String.Empty;
				txtAccLPhonetic.Text = String.Empty;
				txtAccLRomaji1.Text = String.Empty;
				txtAccFirstName.Text = String.Empty;
				txtAccFirstPhonetic.Text = String.Empty;
				txtAccFirstRomaji.Text = String.Empty;

				cmbBlock.Text = String.Empty;

				txtStreet1.Text = String.Empty;
				txtStreet2.Text = String.Empty;
				txtStreet3.Text = String.Empty;
				txtCity.Text = String.Empty;
				txtState.Text = String.Empty;
				txtPost.Text = String.Empty;
				txtCountry.Text = String.Empty;

				txtPhone1.Text = String.Empty;
				txtPhone2.Text = String.Empty;
				txtFax1.Text = String.Empty;
				txtFax2.Text = String.Empty;
				txtPhoneOther.Text = String.Empty;
				txtUrl.Text = String.Empty;
				
				dtJoined.Value = dtEnded.Value = DateTime.Now;

				dtJoined.Checked = true;
				dtEnded.Checked = true;

				txtMintSt1.Text = String.Empty;
				txtClosestSt1.Text = String.Empty;
				txtClosestLine1.Text = String.Empty;

				txtMintSt2.Text = String.Empty;
				txtClosestSt2.Text = String.Empty;
				txtClosestLine2.Text = String.Empty;

				cmbStatus.SelectedIndex = 0;

				

			}
			else
			{
				//Calling the Dept. class file
				int intClientID=0;
				int intStatus=0;
				
				Department objDept=new Department();
				objDept.DeptID = _deptid;
				objDept.LoadData();
				
				//read the values
				intClientID = objDept.ClientID;
				intContactID = objDept.ContactID;
				cmbClient.Text = objDept.ClientName;
                while (reader.Read())
                {
                    if (reader["CompanyName"] != DBNull.Value && reader["CompanyName"].ToString() != objDept.ClientName)
                    {
                        cmbClient.Items.Remove(reader["CompanyName"].ToString());
                    }
                }
				cmbClient.Tag = objDept.ClientName;
				intStatus = objDept.StatusID;

				cmbStatus.SelectedIndex=intStatus;

				//Getting data from Contact Table
				Contact objContact=new Contact();
				objContact.ContactID = _contactid;
				objContact.LoadData("Department");

				foreach(DataRow dr in objContact.dtblContacts.Rows)
				{
                    txtCompName.Text = dr["CompanyName"].ToString();
                    txtCompName.Tag = dr["CompanyName"].ToString();
                    
                    if (txtCompName.Text == "No Department")
                        chkNoDept.Checked = true;
                    else
                        if (_mode == "AddClone")
                            txtCompName.Text = "Copy of " + txtCompName.Text;

                    txtCompPhonetic.Text = dr["CompanyNamePhonetic"].ToString();
					txtCompRomaji.Text = dr["CompanyNameRomaji"].ToString();

					txtNickName.Text = dr["NickName"].ToString();
					txtNickName.Tag = txtNickName.Text;

					txtAccLName.Text = dr["AccountRepLastName"].ToString();
					txtAccLPhonetic.Text = dr["AccountRepLastNamePhonetic"].ToString();
					txtAccLRomaji1.Text = dr["AccountRepLastNameRomaji"].ToString();
					txtAccFirstName.Text = dr["AccountRepFirstName"].ToString();
					txtAccFirstPhonetic.Text = dr["AccountRepFirstNamePhonetic"].ToString();
					txtAccFirstRomaji.Text = dr["AccountRepFirstNameRomaji"].ToString();

					if(dr["BlockCode"].ToString().Trim()!="")
					{
						cmbBlock.Text = dr["BlockCode"].ToString();
					}
					txtStreet1.Text = dr["Street1"].ToString();
					txtStreet2.Text = dr["Street2"].ToString();
					txtStreet3.Text = dr["Street3"].ToString();
					txtCity.Text = dr["City"].ToString();
					txtState.Text = dr["State"].ToString();
					txtPost.Text = dr["PostalCode"].ToString();
					txtCountry.Text = dr["Country"].ToString();

					txtPhone1.Text = dr["Phone1"].ToString();
					txtPhone2.Text = dr["Phone2"].ToString();
					txtFax1.Text = dr["PhoneFax1"].ToString();
					txtFax2.Text = dr["PhoneFax2"].ToString();
					txtPhoneOther.Text = dr["PhoneOther"].ToString();
					txtUrl.Text = dr["url"].ToString();

					if(dr["DateJoined"]!=DBNull.Value)
					{
						dtJoined.Value = Convert.ToDateTime(dr["DateJoined"].ToString());
						dtJoined.Checked = true;
					}
					else
					{
						dtJoined.Checked=false;
					}

					if(dr["DateEnded"]!=DBNull.Value)
					{
						dtEnded.Value = Convert.ToDateTime(dr["DateEnded"].ToString());
						dtEnded.Checked = true;
					}
					else
					{
						dtEnded.Checked=false;
					}

					txtMintSt1.Text = dr["MinutesToStation1"].ToString();
					txtClosestSt1.Text = dr["ClosestStation1"].ToString();
					txtClosestLine1.Text = dr["Closestline1"].ToString();
				
					txtMintSt2.Text = dr["MinutesToStation2"].ToString();
					txtClosestSt2.Text = dr["ClosestStation2"].ToString();
					txtClosestLine2.Text = dr["Closestline2"].ToString();

					cmbStatus.SelectedIndex = Convert.ToInt16(dr["ContactStatus"].ToString());
				}

				if(chkNoDept.Checked) txtCompName.Text = "No Department";


                LoadContact();
			}
			
		}

		private void frmDepartmentDlg_Load(object sender, System.EventArgs e)
		{
            if (Common.LogonType == 2)
            {
                this.btnDelete.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnImportClientAddress.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnEdit.Text = "View";
                this.llblClient.Enabled = false;
            }
			this.ActiveControl = txtCompName;

			try
			{
				Common.SetControlFont(this);
				Common.SetGridFont(grdContact);
				Common.SetControlFont(pnlBottom);
			}
			catch{}
			this.Refresh();

			if((_mode=="Add") || (_mode==""))
			{
				this.Text = "Adding Department...";	
				cmbStatus.SelectedIndex=0;
				txtCompName.Tag="";
				txtNickName.Tag="";
				btnDelete.Enabled=false;
			}
            else if (_mode == "AddClone")
            {
                this.Text = "Adding Department Clone...";
                btnDelete.Enabled = false;
            }
            else
            {
                this.Text = "Editing Department...";
                if ((txtCompName.Text == "No Department") && (txtCompPhonetic.Text == "") && (txtCompRomaji.Text == ""))
                {
                    chkNoDept.Checked = true;
                    //txtCompName.Tag="1";
                }
            }
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//Adding to Contact Table
			if(chkNoDept.Checked==false)
			{
				if(txtCompName.Text=="")
				{
					tbcDepartment.SelectedIndex=0;
					Scheduler.BusinessLayer.Message.MsgInformation("Enter Department Name");
					txtCompName.Focus();
					return;
				}
			}

			if(cmbClient.Text=="")
			{
				tbcDepartment.SelectedIndex=0;
				BusinessLayer.Message.MsgInformation("Enter Client");
				cmbClient.Focus();
				return;
			}

			bool boolSuccess;
			Scheduler.BusinessLayer.Contact objContact=null;
			
			objContact=new Scheduler.BusinessLayer.Contact();
			objContact.ContactID=0;

			objContact.LastName = "";
			objContact.LastNamePhonetic="";
			objContact.LastNameRomaji="";
			objContact.FirstName="";
			objContact.FirstNamePhonetic="";
			objContact.FirstNameRomaji="";
			//if(chkNoDept.Checked)
			//	objContact.CompanyName="No Department";
			//else
			objContact.NickName=txtNickName.Text;
			objContact.CompanyName=txtCompName.Text;
			objContact.CompanyNamePhonetic=txtCompPhonetic.Text;
			objContact.CompanyNameRomaji=txtCompRomaji.Text;
			objContact.TitleForName="";
			objContact.TitleForJob="";
			objContact.Street1=txtStreet1.Text;
			objContact.Street2=txtStreet2.Text;
			objContact.Street3=txtStreet3.Text;
			objContact.City=txtCity.Text;
			objContact.State=txtState.Text;
			objContact.PostalCode=txtPost.Text;
			objContact.Country=txtCountry.Text;
			objContact.ContactType=3;
			objContact.BlockCode=cmbBlock.Text;
			objContact.Email1="";
			objContact.Email2="";
			objContact.AccountRepLastName=txtAccLName.Text;
			objContact.AccountRepLastNamePhonetic=txtAccLPhonetic.Text;
			objContact.AccountRepLastNameRomaji=txtAccLRomaji1.Text;
			objContact.AccountRepFirstName=txtAccFirstName.Text;
			objContact.AccountRepFirstNamePhonetic=txtAccFirstPhonetic.Text;
			objContact.AccountRepFirstNameRomaji=txtAccFirstRomaji.Text;
			objContact.Phone1=txtPhone1.Text;
			objContact.Phone2=txtPhone2.Text;
			objContact.PhoneMobile1="";
			objContact.PhoneMobile2="";
			objContact.PhoneBusiness1="";
			objContact.PhoneBusiness2="";
			objContact.PhoneFax1=txtFax1.Text;
			objContact.PhoneFax2=txtFax2.Text;
			objContact.PhoneOther=txtPhoneOther.Text;
			objContact.Url=txtUrl.Text;

			objContact.DateBirth=Convert.ToDateTime(null);
			objContact.DateJoined=Convert.ToDateTime(null);
			objContact.DateEnded=Convert.ToDateTime(null);
			
			//objContact.TimeStatus=.Text;
			objContact.Nationality="";
			objContact.Married=0;
			objContact.NumberDependents=0;

			objContact.VisaStatus="";
			objContact.VisaFromDate=Convert.ToDateTime(null);
			objContact.VisaUntilDate=Convert.ToDateTime(null);

			objContact.ClosestStation1=txtClosestSt1.Text;
			objContact.ClosestLine1=txtClosestLine1.Text;
            Int16 minToStation = 0;
            if (txtMintSt1.Text != "")
            {
                Int16.TryParse(txtMintSt1.Text, out minToStation);
            }
            Int16 minToStation2 = 0;
            if (txtMintSt2.Text != "")
            {
                Int16.TryParse(txtMintSt2.Text, out minToStation2);
            }
			objContact.MinutesToStation1=minToStation;
            objContact.MinutesToStation2 = minToStation2;
			objContact.ClosestStation2=txtClosestSt2.Text;
			objContact.ClosestLine2=txtClosestLine2.Text;
			
			objContact.ContactStatus=cmbStatus.SelectedIndex;

			int intCID=0;
			intCID = Common.GetCompanyID(
				"Select ContactID From Contact " +
				"Where (CompanyName =@CompanyName OR NickName=@CompanyName) ", cmbClient.Text
				);

            if ((_mode == "Add") || (_mode == "AddClone") || (_mode == ""))
			{
				if(objContact.Exists(txtCompName.Text, intCID, 3))
				{
					Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Department Name not allowed");
					txtCompName.Focus();
					return;
				}
				if(txtNickName.Text!="")
				{
					if(objContact.NickNameExists(txtNickName.Text, intCID, 3))
					{
						Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Abbreviated Name not allowed");
						txtNickName.Focus();
						return;
					}
				}
				boolSuccess = objContact.InsertData();
			}
			else
			{
				if((txtCompName.Tag.ToString()!=txtCompName.Text) || (cmbClient.Tag.ToString()!=cmbClient.Text))
				{
					if(objContact.Exists(txtCompName.Text, intCID, 3))
					{
						Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Department Name not allowed");
						txtCompName.Focus();
						return;
					}
				}
				if(txtNickName.Text!="")
				{
					if((txtNickName.Tag.ToString()!=txtNickName.Text) || (cmbClient.Tag.ToString()!=cmbClient.Text))
					{
						if(objContact.NickNameExists(txtNickName.Text, intCID, 3))
						{
							Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Abbreviated Name not allowed");
							txtNickName.Focus();
							return;
						}
					}
				}
				objContact.ContactID=_contactid;
				boolSuccess = objContact.UpdateData();
			}
			if(!boolSuccess)
			{
                if (_mode == "Add")
                    Scheduler.BusinessLayer.Message.ShowException("Adding Contact record.", objContact.Message);
                else if (_mode == "AddClone")
                    Scheduler.BusinessLayer.Message.ShowException("Cloning Contact record.", objContact.Message);
                else
                    Scheduler.BusinessLayer.Message.ShowException("Updating Contact record.", objContact.Message);
				return;
			}

			//Getting ContactID
			_contactid = objContact.ContactID;

			//Adding to Department Table
			
			
			/*if(txtDeptName.Text=="")
			{
				BusinessLayer.Message.MsgInformation("Enter Department");
				txtDeptName.Focus();
				return;
			}
			if(cmbContact.Text=="")
			{
				BusinessLayer.Message.MsgInformation("Enter Contact");
				cmbContact.Focus();
				return;
			}
			if(cmbClient.Text=="")
			{
				BusinessLayer.Message.MsgInformation("Enter Client");
				cmbClient.Focus();
				return;
			}*/
			
			
			Department objDept=new Department();
			//objDept.DeptName = txtDeptName.Text;

			if(cmbClient.Text.Trim()=="")
			{
				objDept.ClientID=0;
			}
			else
			{
				objDept.ClientID = Common.GetCompanyID(
					"Select ContactID From Contact " +
					"Where (CompanyName =@CompanyName OR NickName=@CompanyName) ", cmbClient.Text
					);
			}

			/*if(cmbContact.Text.Trim()=="")
			{
				objDept.ContactID=0;
			}
			else
			{
				string[] arr = cmbContact.Text.Split(new char[]{','});
				if(arr.Length==1)
				{
					objDept.ContactID = Common.GetID(
						"Select ContactID From Contact " +
						"Where LastName ='" + arr[0].Trim() + "' "
						);
				}
				else
				{
					objDept.ContactID = Common.GetID(
						"Select ContactID From Contact " +
						"Where LastName ='" + arr[0].Trim() + "' and FirstName = '" + arr[1].Trim() + "' "
						);
				}
			}*/

			objDept.ContactID = _contactid;
			objDept.StatusID = cmbStatus.SelectedIndex;

            if ((_mode == "Add") || (_mode == "AddClone") || (_mode == ""))
			{
				if(objDept.InsertData()==false)
				{
					BusinessLayer.Message.ShowException("Adding Department", objDept.Message);
				}
				else
				{
					if(intRandomNo>0)
					{
						//replace the randomno with deptid
						objContact.RefID=objDept.DeptID;
						objContact.UpdateRefID(intRandomNo);
					}
				}
			}
			else
			{
				objDept.DeptID=_deptid;
				if(objDept.UpdateData()==false)
				{
					BusinessLayer.Message.ShowException("Editing Department", objDept.Message);
				}
			}

			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void llblContact_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			/*frmContactDlg fContDlg=new frmContactDlg();
			fContDlg.Mode="Add";
			if(fContDlg.ShowDialog()==DialogResult.OK)
			{
				Common.PopulateDropdown(
					cmbContact, "Select LastName + ', ' + FirstName from " +
								"Contact Where ContactStatus=0 " +
								"Order By ContactID");
				cmbContact.SelectedIndex = cmbContact.Items.Count-1;

				int i = cmbClient.SelectedIndex;
				Common.PopulateDropdown(
					cmbClient, "Select LastName + ', ' + FirstName from " +
					"Contact Where ContactType=2 and " +
					"ContactStatus=0 Order By ContactID");
				cmbClient.SelectedIndex=i;
			}
			fContDlg.Close();
			fContDlg.Dispose();
			fContDlg=null;*/
		}

		private void llblClient_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmClientDlg fContDlg=new frmClientDlg();
			fContDlg.Mode="Add";
			if(fContDlg.ShowDialog()==DialogResult.OK)
			{
				Common.PopulateDropdown(
					cmbClient, "Select CompanyName = CASE " +
					"WHEN NickName IS NULL THEN [CompanyName] " +
					"WHEN NickName = '' THEN [CompanyName] " +
					"ELSE NickName " +
					"END From " +
					"Contact Where ContactType=2  " +
					" Order By ContactID");
				cmbClient.SelectedIndex = cmbClient.Items.Count-1;
                string revQuery = "Select CompanyName = CASE " +
                "WHEN NickName IS NULL THEN [CompanyName] " +
                "WHEN NickName = '' THEN [CompanyName] " +
                "ELSE NickName " +
                "END From " +
                "Contact Where ContactType=2 and " +
                "ContactStatus=1 Order By CompanyName";
                IDataReader reader = DAC.SelectStatement(revQuery);
                if (_mode == "Add")
                {
                    while (reader.Read())
                    {
                        if (reader["CompanyName"] != DBNull.Value)
                        {
                            cmbClient.Items.Remove(reader["CompanyName"].ToString());
                        }
                    }
                }
                else
                {
                    while (reader.Read())
                    {
                        if (reader["CompanyName"] != DBNull.Value && reader["CompanyName"].ToString() != cmbClient.Text)
                        {
                            cmbClient.Items.Remove(reader["CompanyName"].ToString());
                        }
                    }
                }
			}
			fContDlg.Close();
			fContDlg.Dispose();
			fContDlg=null;
		}

		private void frmDepartmentDlg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtMintSt1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			Common.MaskInteger(e);
		}

		private void label53_Click(object sender, System.EventArgs e)
		{
		
		}

		private void txtAccLPhonetic_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void chkNoDept_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkNoDept.Checked)
			{
				txtCompName.Text = "No Department";
				txtCompRomaji.Text="";
				txtCompPhonetic.Text="";
				//txtCompName.Tag = "1";
				txtCompName.Enabled=false;
				txtCompPhonetic.Enabled=false;
				txtCompRomaji.Enabled=false;
			}
			else
			{
				//txtCompName.Tag="";
				txtCompName.Text = "";
				txtCompRomaji.Text="";
				txtCompPhonetic.Text="";
				txtCompName.Enabled=true;
				txtCompPhonetic.Enabled=true;
				txtCompRomaji.Enabled=true;
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(BusinessLayer.Message.MsgDelete())
			{
				Scheduler.BusinessLayer.Department objDept=new Scheduler.BusinessLayer.Department();
				objDept.DeptID = _deptid;
				objDept.ContactID = intContactID;
				if(!objDept.DeleteData())
				{
					BusinessLayer.Message.MsgWarning("Department cannot be deleted");
					return;
				}
				else
				{
					deleted=true;
					btnDelete.Enabled=false;
					this.Text = "Adding Department...";
					_mode="Add";
					_deptid=0;

					foreach(Control c in tbpContact.Controls)
					{
						if(c.GetType().ToString() == "System.Windows.Forms.TextBox")
						{
							if(c.Tag==null) c.Text="";
							else if(c.Tag.ToString()=="N") c.Text="0";
						}
						if(c.GetType().ToString() == "System.Windows.Forms.ComboBox")
						{
							c.Text="";
						}
						if(c.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
						{
							DateTimePicker dp=c as DateTimePicker;
							dp.Value = DateTime.Now;
						}
					}
					foreach(Control c in tbpDeptInfo.Controls)
					{
						if(c.GetType().ToString() == "System.Windows.Forms.TextBox")
						{
							if(c.Tag==null) c.Text="";
							else if(c.Tag.ToString()=="N") c.Text="0";
						}
						if(c.GetType().ToString() == "System.Windows.Forms.ComboBox")
						{
							c.Text="";
						}
						if(c.GetType().ToString() == "System.Windows.Forms.DateTimePicker")
						{
							DateTimePicker dp=c as DateTimePicker;
							dp.Value = DateTime.Now;
						}
					}
					this.DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		private void cmbStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if(_mode=="Edit")
			{
				if(cmbStatus.SelectedIndex==1)
				{
					Common.MakeReadOnly(tbpContact, false);
					Common.MakeReadOnly(tbpDeptInfo, false);
					Common.MakeReadOnly(tbpAddress, false);
					cmbStatus.Enabled=true;
					
					grdContact.Enabled=false;
					btnAdd.Enabled=false;
					btnDel.Enabled=false;
					btnEdit.Enabled=false;
				}
				else
				{
					Common.MakeEnabled(tbpContact, false);
					Common.MakeEnabled(tbpDeptInfo, false);
					Common.MakeEnabled(tbpAddress, false);

					grdContact.Enabled=true;
					btnAdd.Enabled=true;
					btnDel.Enabled=true;
					btnEdit.Enabled=true;
				}
			}
		}

		private int intRandomNo=0;

		private int getRandomNo()
		{
			System.Random r=new Random(9999999);
			intRandomNo=r.Next(99999999);
			return intRandomNo;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			frmClientDeptContactDlg objContact=new frmClientDeptContactDlg();
			objContact.ContactType = "DepartmentContact";
			objContact.Mode="Add";
			objContact.ModeParental=_mode;
			if(_deptid<=0) 
			{
				getRandomNo();
				objContact.RefID=intRandomNo;
			}
			else objContact.RefID=_deptid;
			if(objContact.ShowDialog()==DialogResult.OK)
			{
				LoadContact();
			}
			objContact.Close();
			objContact.Dispose();
			objContact=null;
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			int rowhandle=0;
			rowhandle=gvwContact.FocusedRowHandle;
			
			if(rowhandle<0) return;
			frmClientDeptContactDlg objContact=new frmClientDeptContactDlg();
			objContact.ContactType = "DepartmentContact";
			objContact.Mode="Edit";
			objContact.ModeParental=_mode;
			int _contid=0;
			_contid=Convert.ToInt32(gvwContact.GetRowCellValue(gvwContact.FocusedRowHandle, gcolContactID).ToString());
			objContact.ID =_contid;
			if(objContact.ShowDialog()==DialogResult.OK)
			{
				LoadContact();
			}
			objContact.Close();
			objContact.Dispose();
			objContact=null;
			gvwContact.FocusedRowHandle=rowhandle;
		}

		private void LoadContact()
		{
            if (_mode != "AddClone")
            {
                BusinessLayer.Contact objContact = new BusinessLayer.Contact();
                objContact.ContactType = 5;
                objContact.RefID = _deptid;
                if (_deptid <= 0) objContact.RefID = intRandomNo;
                DataTable dtbl = objContact.LoadData("DepartmentContact");
                grdContact.DataSource = (DataTable)dtbl;
            }
		}

		private void grdContact_DoubleClick(object sender, System.EventArgs e)
		{
			btnEdit_Click(sender, e);
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			BusinessLayer.Contact objContact=new BusinessLayer.Contact();
			objContact.ContactType=5;

			if(gvwContact.FocusedRowHandle<0) return;
			int _contid=0;
			_contid=Convert.ToInt32(gvwContact.GetRowCellValue(gvwContact.FocusedRowHandle, gcolContactID).ToString());
			objContact.ContactID =_contid;
			objContact.DeleteData();
            //Delete the contacts from the Program Table as well
            objContact.DeleteContactFromProgram();

			LoadData();
		}


		/// <summary>
		/// Printing Functionality
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//Create a Panel and clip all other panels to this panel
			Panel pnl=new Panel();
			pnl.Tag = "Department Information";
            pnl.Font = new Font("Arial", 8F, GraphicsUnit.Point);
			pnl.Width = tbcDepartment.Width;
			pnl.Height = tbcDepartment.Height*2+20;
            pnl.Controls.Add(pnlContact);
			pnl.Controls.Add(pnlAddress);

            pnlDeptInfo.Controls.Remove(chkNoDept);
			pnl.Controls.Add(pnlDeptInfo);
            
            //Resize for print-outs
            pnlDeptInfo.Height = 185;
			pnlDeptInfo.Dock = DockStyle.Top;
			pnlAddress.Dock = DockStyle.Fill;

			CreateFormPrintingObject(pnl);
			//PrintingFunctions.SetProperties(ref fp, ps);
            PrintingFunctions.SetProperties(ref xfp);

			// Print!
            //fp.Print();
            xfp.PaperKind = PaperKind.A4;
			xfp.Print();
            pnlDeptInfo.Controls.Add(chkNoDept);
			tbpDeptInfo.Controls.Add(pnlDeptInfo);
			tbpAddress.Controls.Add(pnlAddress);
            //tbpContact.Controls.Clear();
            tbpContact.Controls.Add(pnlContact);
            //pnlContact.Height = 484;
            //pnlContact.Dock = DockStyle.Fill;
            //pnlContact.Dock = DockStyle.Fill;
            //pnlContact.Controls[0].Dock = DockStyle.Fill;
            //pnlContact.Controls[1].Dock = DockStyle.Bottom;
            //Back to original values so the panel displays fine on the UI
            pnlDeptInfo.Height = 484;
            pnlDeptInfo.Dock = DockStyle.Fill;

			pnl.Dispose();
			pnl=null;
		}

		//private FormPrinting fp=null;
        private clsDevExpressFormPrinting xfp = null;
		private void CreateFormPrintingObject(System.Windows.Forms.Control c)
		{
		//	fp = new FormPrinting(c);
            xfp = new clsDevExpressFormPrinting(c,printingSystem1);
		}
		
		//private PageSettings ps=null;
		private void btnPageSetup_Click(object sender, System.EventArgs e)
		{
			//PrintingFunctions.ShowPageSettings(ref ps);
            printingSystem1.PageSetup();
		}

		private GridViewPrinter dataGridPrinter1=null;
		private void button1_Click(object sender, System.EventArgs e)
		{
			dataGridPrinter1 = new GridViewPrinter(grdContact, printDocument1, gvwContact);

			dataGridPrinter1.PageNumber = 1;
			dataGridPrinter1.RowCount = 0;
			if (this.printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
			}
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Graphics	g = e.Graphics;
			DrawTopLabel(g);
			bool more = dataGridPrinter1.DrawDataGrid(g);
			if (more == true)
			{
				e.HasMorePages = true;
				dataGridPrinter1.PageNumber++;
			}
		}

		void DrawTopLabel(Graphics g)
		{
			int TopMargin = printDocument1.DefaultPageSettings.Margins.Top;

			//g.FillRectangle(new SolidBrush(System.Drawing.Color.Gray), 0, 2 , 200, label1.Size.Height);
			Font _font = 
				new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            g.DrawString("Department Contacts", _font, new SolidBrush(lblContactInfoHeader.ForeColor), 10, 40, new StringFormat());
		}

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClient.Text != "")
            {
                btnImportClientAddress.Enabled = true;

            }
            else
                btnImportClientAddress.Enabled = false;
        }

        private void btnImportClientAddress_Click(object sender, EventArgs e)
        {
            int intCID = 0;
            intCID = Common.GetCompanyID(
                "Select ContactID From Contact " +
                "Where (CompanyName =@CompanyName OR NickName=@CompanyName) ", cmbClient.Text
                );
            

            clsContactInfo contactInfo = new clsContactInfo();
            contactInfo.ContactID = intCID;
            contactInfo.LoadData();
            txtPhone1.Text = contactInfo.Phone1;
            txtPhone2.Text = contactInfo.Phone2;
            txtPhoneOther.Text = contactInfo.OtherPhone;
            txtFax1.Text = contactInfo.Fax1;
            txtFax2.Text = contactInfo.Fax2;
            txtUrl.Text = contactInfo.Url;
            //------------------------------
            txtAccFirstName.Text = contactInfo.FirstName;
            txtAccFirstPhonetic.Text = contactInfo.FirstNamePhonetic;
            txtAccFirstRomaji.Text = contactInfo.FirstNameRomaji;
            txtAccLName.Text = contactInfo.LastName;
            txtAccLPhonetic.Text = contactInfo.LastNamePhonetic;
            txtAccLRomaji1.Text = contactInfo.LastNameRomaji;
            //--------------------------------
            txtStreet1.Text = contactInfo.Street1;
            txtStreet2.Text = contactInfo.Street2;
            txtStreet3.Text = contactInfo.Street3;
            txtCity.Text = contactInfo.City;
            txtPost.Text = contactInfo.PostalCode;
            txtState.Text = contactInfo.State;
            txtCountry.Text = contactInfo.Country;
            cmbBlock.Text = contactInfo.Block;
            //------------------------------

            txtClosestLine1.Text = contactInfo.ClosestLine1;
            txtClosestLine2.Text = contactInfo.ClosestLine2;
            txtClosestSt1.Text = contactInfo.ClosestStation1;
            txtClosestSt2.Text = contactInfo.ClosestStation2;
            txtMintSt1.Text = contactInfo.MinutesToStation1;
            txtMintSt2.Text = contactInfo.MinutesToStation2;
        }
	}
}

