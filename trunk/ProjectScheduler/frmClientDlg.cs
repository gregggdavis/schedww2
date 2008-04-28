using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Scheduler.BusinessLayer;
using System.Drawing.Printing;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmClientDlg.
	/// </summary>
	public class frmClientDlg : System.Windows.Forms.Form {
		private IContainer components;

		private string _mode="";
		private System.Windows.Forms.DateTimePicker dtEnded;
		private System.Windows.Forms.DateTimePicker dtJoined;
		private System.Windows.Forms.Label lblHRHeader;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtCompRomaji;
		private System.Windows.Forms.TextBox txtCompPhonetic;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCompName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.TextBox txtFax2;
		private System.Windows.Forms.TextBox txtFax1;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label lblContactInfoHeader;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox txtPhoneOther;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox txtPhone2;
		private System.Windows.Forms.TextBox txtPhone1;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label lblStation2Header;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.TextBox txtMintSt2;
		private System.Windows.Forms.TextBox txtClosestLine2;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.TextBox txtClosestSt2;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label lblStation1Header;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox txtMintSt1;
		private System.Windows.Forms.TextBox txtClosestLine1;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.TextBox txtClosestSt1;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ComboBox cmbBlock;
		private System.Windows.Forms.TextBox txtCountry;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox txtPost;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox txtStreet3;
		private System.Windows.Forms.TextBox txtStreet2;
		private System.Windows.Forms.TextBox txtStreet1;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label lblAddressHeader;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox txtAccFirstRomaji;
		private System.Windows.Forms.TextBox txtAccFirstPhonetic;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.TextBox txtAccFirstName;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.TextBox txtAccLRomaji1;
		private System.Windows.Forms.TextBox txtAccLPhonetic;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.TextBox txtAccLName;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.TabPage tbpAddress;
		private System.Windows.Forms.TabPage tbpContact;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Panel pnlBody;
		public DevExpress.XtraGrid.GridControl grdContact;
		public DevExpress.XtraGrid.Views.Grid.GridView gvwContact;
		public DevExpress.XtraGrid.Columns.GridColumn gcolContactID;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContactType;
		private DevExpress.XtraGrid.Columns.GridColumn gcolType;
		private DevExpress.XtraGrid.Columns.GridColumn gColLastName;
		private DevExpress.XtraGrid.Columns.GridColumn gcolFirstName;
		private DevExpress.XtraGrid.Columns.GridColumn gcolLastNameRomaji;
		private DevExpress.XtraGrid.Columns.GridColumn gcolFirstNameRomaji;
		private DevExpress.XtraGrid.Columns.GridColumn gcolEmail1;
		private DevExpress.XtraGrid.Columns.GridColumn gcolPhone;
		private DevExpress.XtraGrid.Columns.GridColumn gcolMobile;
		private DevExpress.XtraGrid.Columns.GridColumn gcolStatusID;
		private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;
		private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;

		private int _contactid=0;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private System.Windows.Forms.TabControl tbcClient;
		private System.Windows.Forms.TabPage tbpClientInfo;
		private System.Windows.Forms.TextBox txtNickName;
		private System.Windows.Forms.Label lblNickName;
		private System.Windows.Forms.Panel pnlClientInfo;
		private System.Windows.Forms.Button btnPageSetup;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Panel pnlAddress;
		private System.Windows.Forms.Button button1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
		private bool deleted=false;

		public string Mode
		{
			get{return _mode;}
			set{_mode=value;}
		}
		public int ContactID
		{
			get{return _contactid;}
			set{_contactid=value;}
		}


		public frmClientDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			tbcClient.Controls.Remove(tbpContact);
			tbcClient.SelectedIndex=0;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientDlg));
            this.tbcClient = new System.Windows.Forms.TabControl();
            this.tbpClientInfo = new System.Windows.Forms.TabPage();
            this.pnlClientInfo = new System.Windows.Forms.Panel();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.lblNickName = new System.Windows.Forms.Label();
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tbpAddress = new System.Windows.Forms.TabPage();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.lblContactInfoHeader = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.label28 = new System.Windows.Forms.Label();
            this.tbpContact = new System.Windows.Forms.TabPage();
            this.pnlBody = new System.Windows.Forms.Panel();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.tbcClient.SuspendLayout();
            this.tbpClientInfo.SuspendLayout();
            this.pnlClientInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbpAddress.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.tbpContact.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwContact)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcClient
            // 
            this.tbcClient.Controls.Add(this.tbpClientInfo);
            this.tbcClient.Controls.Add(this.tbpAddress);
            this.tbcClient.Controls.Add(this.tbpContact);
            this.tbcClient.Location = new System.Drawing.Point(0, 1);
            this.tbcClient.Name = "tbcClient";
            this.tbcClient.SelectedIndex = 0;
            this.tbcClient.Size = new System.Drawing.Size(640, 510);
            this.tbcClient.TabIndex = 18;
            // 
            // tbpClientInfo
            // 
            this.tbpClientInfo.Controls.Add(this.pnlClientInfo);
            this.tbpClientInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpClientInfo.Name = "tbpClientInfo";
            this.tbpClientInfo.Size = new System.Drawing.Size(632, 484);
            this.tbpClientInfo.TabIndex = 0;
            this.tbpClientInfo.Text = "Client Info";
            // 
            // pnlClientInfo
            // 
            this.pnlClientInfo.Controls.Add(this.txtNickName);
            this.pnlClientInfo.Controls.Add(this.lblNickName);
            this.pnlClientInfo.Controls.Add(this.dtEnded);
            this.pnlClientInfo.Controls.Add(this.dtJoined);
            this.pnlClientInfo.Controls.Add(this.lblHRHeader);
            this.pnlClientInfo.Controls.Add(this.groupBox12);
            this.pnlClientInfo.Controls.Add(this.label42);
            this.pnlClientInfo.Controls.Add(this.label39);
            this.pnlClientInfo.Controls.Add(this.label13);
            this.pnlClientInfo.Controls.Add(this.groupBox1);
            this.pnlClientInfo.Controls.Add(this.txtCompRomaji);
            this.pnlClientInfo.Controls.Add(this.txtCompPhonetic);
            this.pnlClientInfo.Controls.Add(this.label4);
            this.pnlClientInfo.Controls.Add(this.label5);
            this.pnlClientInfo.Controls.Add(this.txtCompName);
            this.pnlClientInfo.Controls.Add(this.label6);
            this.pnlClientInfo.Controls.Add(this.lblStatus);
            this.pnlClientInfo.Controls.Add(this.cmbStatus);
            this.pnlClientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClientInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlClientInfo.Name = "pnlClientInfo";
            this.pnlClientInfo.Size = new System.Drawing.Size(632, 484);
            this.pnlClientInfo.TabIndex = 241;
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(152, 115);
            this.txtNickName.MaxLength = 255;
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(193, 21);
            this.txtNickName.TabIndex = 3;
            // 
            // lblNickName
            // 
            this.lblNickName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNickName.Location = new System.Drawing.Point(32, 117);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(112, 17);
            this.lblNickName.TabIndex = 240;
            this.lblNickName.Text = "Abbreviated Name";
            // 
            // dtEnded
            // 
            this.dtEnded.CustomFormat = "MM/dd/yyyy";
            this.dtEnded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnded.Location = new System.Drawing.Point(480, 65);
            this.dtEnded.Name = "dtEnded";
            this.dtEnded.ShowCheckBox = true;
            this.dtEnded.Size = new System.Drawing.Size(136, 21);
            this.dtEnded.TabIndex = 5;
            // 
            // dtJoined
            // 
            this.dtJoined.CustomFormat = "MM/dd/yyyy";
            this.dtJoined.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtJoined.Location = new System.Drawing.Point(480, 41);
            this.dtJoined.Name = "dtJoined";
            this.dtJoined.ShowCheckBox = true;
            this.dtJoined.Size = new System.Drawing.Size(136, 21);
            this.dtJoined.TabIndex = 4;
            // 
            // lblHRHeader
            // 
            this.lblHRHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHRHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHRHeader.Location = new System.Drawing.Point(384, 18);
            this.lblHRHeader.Name = "lblHRHeader";
            this.lblHRHeader.Size = new System.Drawing.Size(33, 17);
            this.lblHRHeader.TabIndex = 238;
            this.lblHRHeader.Text = "HR";
            // 
            // groupBox12
            // 
            this.groupBox12.Location = new System.Drawing.Point(408, 25);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(208, 2);
            this.groupBox12.TabIndex = 237;
            this.groupBox12.TabStop = false;
            // 
            // label42
            // 
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.Location = new System.Drawing.Point(384, 67);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(88, 17);
            this.label42.TabIndex = 236;
            this.label42.Text = "Date Ended";
            // 
            // label39
            // 
            this.label39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label39.Location = new System.Drawing.Point(384, 43);
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
            this.label13.Location = new System.Drawing.Point(32, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 17);
            this.label13.TabIndex = 79;
            this.label13.Text = "Client";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(70, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 3);
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
            this.label11.Size = new System.Drawing.Size(57, 20);
            this.label11.TabIndex = 73;
            this.label11.Text = "Company";
            // 
            // txtCompRomaji
            // 
            this.txtCompRomaji.Location = new System.Drawing.Point(152, 89);
            this.txtCompRomaji.MaxLength = 255;
            this.txtCompRomaji.Name = "txtCompRomaji";
            this.txtCompRomaji.Size = new System.Drawing.Size(193, 21);
            this.txtCompRomaji.TabIndex = 2;
            // 
            // txtCompPhonetic
            // 
            this.txtCompPhonetic.Location = new System.Drawing.Point(152, 65);
            this.txtCompPhonetic.MaxLength = 255;
            this.txtCompPhonetic.Name = "txtCompPhonetic";
            this.txtCompPhonetic.Size = new System.Drawing.Size(193, 21);
            this.txtCompPhonetic.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(32, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "Name Romaji";
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(32, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "Name Phonetic";
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(152, 41);
            this.txtCompName.MaxLength = 255;
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(193, 21);
            this.txtCompName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(32, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 75;
            this.label6.Text = "Name";
            // 
            // lblStatus
            // 
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(384, 115);
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
            this.cmbStatus.Location = new System.Drawing.Point(480, 113);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(136, 21);
            this.cmbStatus.TabIndex = 6;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // tbpAddress
            // 
            this.tbpAddress.Controls.Add(this.pnlAddress);
            this.tbpAddress.Location = new System.Drawing.Point(4, 22);
            this.tbpAddress.Name = "tbpAddress";
            this.tbpAddress.Size = new System.Drawing.Size(632, 484);
            this.tbpAddress.TabIndex = 1;
            this.tbpAddress.Text = "Address";
            this.tbpAddress.Visible = false;
            // 
            // pnlAddress
            // 
            this.pnlAddress.Controls.Add(this.lblContactInfoHeader);
            this.pnlAddress.Controls.Add(this.groupBox2);
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
            this.pnlAddress.Controls.Add(this.label28);
            this.pnlAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddress.Location = new System.Drawing.Point(0, 0);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(632, 484);
            this.pnlAddress.TabIndex = 312;
            this.pnlAddress.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAddress_Paint);
            // 
            // lblContactInfoHeader
            // 
            this.lblContactInfoHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblContactInfoHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInfoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblContactInfoHeader.Location = new System.Drawing.Point(334, 11);
            this.lblContactInfoHeader.Name = "lblContactInfoHeader";
            this.lblContactInfoHeader.Size = new System.Drawing.Size(90, 17);
            this.lblContactInfoHeader.TabIndex = 284;
            this.lblContactInfoHeader.Text = "Contact Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(416, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 2);
            this.groupBox2.TabIndex = 312;
            this.groupBox2.TabStop = false;
            // 
            // label48
            // 
            this.label48.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label48.Location = new System.Drawing.Point(334, 232);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(159, 17);
            this.label48.TabIndex = 311;
            this.label48.Text = "Internal Accounts Rep";
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(474, 239);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(142, 2);
            this.groupBox9.TabIndex = 310;
            this.groupBox9.TabStop = false;
            // 
            // txtAccFirstRomaji
            // 
            this.txtAccFirstRomaji.Location = new System.Drawing.Point(457, 392);
            this.txtAccFirstRomaji.MaxLength = 255;
            this.txtAccFirstRomaji.Name = "txtAccFirstRomaji";
            this.txtAccFirstRomaji.Size = new System.Drawing.Size(158, 21);
            this.txtAccFirstRomaji.TabIndex = 255;
            // 
            // txtAccFirstPhonetic
            // 
            this.txtAccFirstPhonetic.Location = new System.Drawing.Point(457, 368);
            this.txtAccFirstPhonetic.MaxLength = 255;
            this.txtAccFirstPhonetic.Name = "txtAccFirstPhonetic";
            this.txtAccFirstPhonetic.Size = new System.Drawing.Size(158, 21);
            this.txtAccFirstPhonetic.TabIndex = 254;
            // 
            // label49
            // 
            this.label49.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label49.Location = new System.Drawing.Point(334, 394);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(106, 17);
            this.label49.TabIndex = 309;
            this.label49.Text = "First Name Romaji";
            // 
            // label50
            // 
            this.label50.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label50.Location = new System.Drawing.Point(334, 370);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(119, 17);
            this.label50.TabIndex = 308;
            this.label50.Text = "First Name Phonetic";
            // 
            // txtAccFirstName
            // 
            this.txtAccFirstName.Location = new System.Drawing.Point(457, 344);
            this.txtAccFirstName.MaxLength = 255;
            this.txtAccFirstName.Name = "txtAccFirstName";
            this.txtAccFirstName.Size = new System.Drawing.Size(158, 21);
            this.txtAccFirstName.TabIndex = 253;
            // 
            // label51
            // 
            this.label51.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label51.Location = new System.Drawing.Point(334, 346);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(106, 17);
            this.label51.TabIndex = 307;
            this.label51.Text = "First Name";
            // 
            // txtAccLRomaji1
            // 
            this.txtAccLRomaji1.Location = new System.Drawing.Point(457, 312);
            this.txtAccLRomaji1.MaxLength = 255;
            this.txtAccLRomaji1.Name = "txtAccLRomaji1";
            this.txtAccLRomaji1.Size = new System.Drawing.Size(158, 21);
            this.txtAccLRomaji1.TabIndex = 252;
            // 
            // txtAccLPhonetic
            // 
            this.txtAccLPhonetic.Location = new System.Drawing.Point(457, 288);
            this.txtAccLPhonetic.MaxLength = 255;
            this.txtAccLPhonetic.Name = "txtAccLPhonetic";
            this.txtAccLPhonetic.Size = new System.Drawing.Size(158, 21);
            this.txtAccLPhonetic.TabIndex = 251;
            // 
            // label52
            // 
            this.label52.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label52.Location = new System.Drawing.Point(334, 314);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(106, 17);
            this.label52.TabIndex = 306;
            this.label52.Text = "Last Name Romaji";
            // 
            // label53
            // 
            this.label53.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label53.Location = new System.Drawing.Point(334, 290);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(114, 17);
            this.label53.TabIndex = 305;
            this.label53.Text = "Last Name Phonetic";
            // 
            // txtAccLName
            // 
            this.txtAccLName.Location = new System.Drawing.Point(457, 264);
            this.txtAccLName.MaxLength = 255;
            this.txtAccLName.Name = "txtAccLName";
            this.txtAccLName.Size = new System.Drawing.Size(158, 21);
            this.txtAccLName.TabIndex = 250;
            // 
            // label54
            // 
            this.label54.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label54.Location = new System.Drawing.Point(334, 266);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(114, 17);
            this.label54.TabIndex = 304;
            this.label54.Text = "Last Name";
            // 
            // label36
            // 
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.Location = new System.Drawing.Point(334, 133);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(106, 17);
            this.label36.TabIndex = 287;
            this.label36.Text = "Fax 2";
            // 
            // txtUrl
            // 
            this.txtUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUrl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtUrl.Location = new System.Drawing.Point(457, 158);
            this.txtUrl.MaxLength = 255;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(158, 21);
            this.txtUrl.TabIndex = 249;
            // 
            // label38
            // 
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.Location = new System.Drawing.Point(334, 160);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(106, 17);
            this.label38.TabIndex = 286;
            this.label38.Text = "URL";
            // 
            // txtFax2
            // 
            this.txtFax2.Location = new System.Drawing.Point(457, 131);
            this.txtFax2.MaxLength = 255;
            this.txtFax2.Name = "txtFax2";
            this.txtFax2.Size = new System.Drawing.Size(158, 21);
            this.txtFax2.TabIndex = 248;
            // 
            // txtFax1
            // 
            this.txtFax1.Location = new System.Drawing.Point(457, 107);
            this.txtFax1.MaxLength = 255;
            this.txtFax1.Name = "txtFax1";
            this.txtFax1.Size = new System.Drawing.Size(158, 21);
            this.txtFax1.TabIndex = 247;
            // 
            // label41
            // 
            this.label41.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label41.Location = new System.Drawing.Point(334, 109);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(106, 17);
            this.label41.TabIndex = 285;
            this.label41.Text = "Fax 1";
            // 
            // label43
            // 
            this.label43.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label43.Location = new System.Drawing.Point(334, 85);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(106, 17);
            this.label43.TabIndex = 281;
            this.label43.Text = "Phone Other";
            // 
            // txtPhoneOther
            // 
            this.txtPhoneOther.Location = new System.Drawing.Point(457, 83);
            this.txtPhoneOther.MaxLength = 255;
            this.txtPhoneOther.Name = "txtPhoneOther";
            this.txtPhoneOther.Size = new System.Drawing.Size(158, 21);
            this.txtPhoneOther.TabIndex = 246;
            // 
            // label33
            // 
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.Location = new System.Drawing.Point(334, 58);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(106, 17);
            this.label33.TabIndex = 280;
            this.label33.Text = "Phone 2";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(457, 56);
            this.txtPhone2.MaxLength = 255;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(158, 21);
            this.txtPhone2.TabIndex = 245;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(457, 32);
            this.txtPhone1.MaxLength = 255;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(158, 21);
            this.txtPhone1.TabIndex = 244;
            // 
            // label32
            // 
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label32.Location = new System.Drawing.Point(334, 34);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(104, 17);
            this.label32.TabIndex = 276;
            this.label32.Text = "Phone 1";
            // 
            // lblStation2Header
            // 
            this.lblStation2Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStation2Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation2Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStation2Header.Location = new System.Drawing.Point(16, 320);
            this.lblStation2Header.Name = "lblStation2Header";
            this.lblStation2Header.Size = new System.Drawing.Size(81, 17);
            this.lblStation2Header.TabIndex = 273;
            this.lblStation2Header.Text = "Station 2";
            // 
            // groupBox11
            // 
            this.groupBox11.Location = new System.Drawing.Point(83, 326);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(232, 2);
            this.groupBox11.TabIndex = 272;
            this.groupBox11.TabStop = false;
            // 
            // txtMintSt2
            // 
            this.txtMintSt2.Location = new System.Drawing.Point(124, 382);
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
            this.txtClosestLine2.Location = new System.Drawing.Point(124, 358);
            this.txtClosestLine2.MaxLength = 255;
            this.txtClosestLine2.Name = "txtClosestLine2";
            this.txtClosestLine2.Size = new System.Drawing.Size(203, 21);
            this.txtClosestLine2.TabIndex = 242;
            // 
            // label60
            // 
            this.label60.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label60.Location = new System.Drawing.Point(16, 384);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(104, 17);
            this.label60.TabIndex = 271;
            this.label60.Text = "Minutes to Station";
            // 
            // label61
            // 
            this.label61.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label61.Location = new System.Drawing.Point(16, 360);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(104, 17);
            this.label61.TabIndex = 270;
            this.label61.Text = "Closest Line";
            // 
            // txtClosestSt2
            // 
            this.txtClosestSt2.Location = new System.Drawing.Point(124, 334);
            this.txtClosestSt2.MaxLength = 255;
            this.txtClosestSt2.Name = "txtClosestSt2";
            this.txtClosestSt2.Size = new System.Drawing.Size(203, 21);
            this.txtClosestSt2.TabIndex = 241;
            // 
            // label62
            // 
            this.label62.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label62.Location = new System.Drawing.Point(16, 336);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(104, 17);
            this.label62.TabIndex = 269;
            this.label62.Text = "Closest Station";
            // 
            // lblStation1Header
            // 
            this.lblStation1Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStation1Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation1Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStation1Header.Location = new System.Drawing.Point(16, 211);
            this.lblStation1Header.Name = "lblStation1Header";
            this.lblStation1Header.Size = new System.Drawing.Size(81, 17);
            this.lblStation1Header.TabIndex = 268;
            this.lblStation1Header.Text = "Station 1";
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(83, 219);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(236, 2);
            this.groupBox10.TabIndex = 267;
            this.groupBox10.TabStop = false;
            // 
            // txtMintSt1
            // 
            this.txtMintSt1.Location = new System.Drawing.Point(124, 276);
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
            this.txtClosestLine1.Location = new System.Drawing.Point(124, 252);
            this.txtClosestLine1.MaxLength = 255;
            this.txtClosestLine1.Name = "txtClosestLine1";
            this.txtClosestLine1.Size = new System.Drawing.Size(203, 21);
            this.txtClosestLine1.TabIndex = 239;
            // 
            // label55
            // 
            this.label55.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label55.Location = new System.Drawing.Point(16, 278);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(104, 17);
            this.label55.TabIndex = 266;
            this.label55.Text = "Minutes to Station";
            // 
            // label56
            // 
            this.label56.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label56.Location = new System.Drawing.Point(16, 254);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(104, 17);
            this.label56.TabIndex = 265;
            this.label56.Text = "Closest Line";
            // 
            // txtClosestSt1
            // 
            this.txtClosestSt1.Location = new System.Drawing.Point(124, 228);
            this.txtClosestSt1.MaxLength = 255;
            this.txtClosestSt1.Name = "txtClosestSt1";
            this.txtClosestSt1.Size = new System.Drawing.Size(203, 21);
            this.txtClosestSt1.TabIndex = 238;
            // 
            // label57
            // 
            this.label57.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label57.Location = new System.Drawing.Point(16, 230);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(104, 17);
            this.label57.TabIndex = 264;
            this.label57.Text = "Closest Station";
            // 
            // label29
            // 
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Location = new System.Drawing.Point(16, 184);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 17);
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
            this.cmbBlock.Location = new System.Drawing.Point(124, 182);
            this.cmbBlock.Name = "cmbBlock";
            this.cmbBlock.Size = new System.Drawing.Size(72, 21);
            this.cmbBlock.TabIndex = 237;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(124, 158);
            this.txtCountry.MaxLength = 255;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(203, 21);
            this.txtCountry.TabIndex = 236;
            // 
            // label27
            // 
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label27.Location = new System.Drawing.Point(16, 160);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 17);
            this.label27.TabIndex = 261;
            this.label27.Text = "Country";
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(260, 131);
            this.txtPost.MaxLength = 255;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(67, 21);
            this.txtPost.TabIndex = 235;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(124, 131);
            this.txtState.MaxLength = 255;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(71, 21);
            this.txtState.TabIndex = 234;
            // 
            // label26
            // 
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label26.Location = new System.Drawing.Point(16, 133);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(96, 17);
            this.label26.TabIndex = 260;
            this.label26.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(124, 104);
            this.txtCity.MaxLength = 255;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(203, 21);
            this.txtCity.TabIndex = 233;
            // 
            // label25
            // 
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label25.Location = new System.Drawing.Point(16, 106);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 17);
            this.label25.TabIndex = 259;
            this.label25.Text = "City";
            // 
            // txtStreet3
            // 
            this.txtStreet3.Location = new System.Drawing.Point(124, 80);
            this.txtStreet3.MaxLength = 255;
            this.txtStreet3.Name = "txtStreet3";
            this.txtStreet3.Size = new System.Drawing.Size(203, 21);
            this.txtStreet3.TabIndex = 232;
            // 
            // txtStreet2
            // 
            this.txtStreet2.Location = new System.Drawing.Point(124, 56);
            this.txtStreet2.MaxLength = 255;
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(203, 21);
            this.txtStreet2.TabIndex = 231;
            // 
            // txtStreet1
            // 
            this.txtStreet1.Location = new System.Drawing.Point(124, 32);
            this.txtStreet1.MaxLength = 255;
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size(203, 21);
            this.txtStreet1.TabIndex = 230;
            // 
            // label24
            // 
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label24.Location = new System.Drawing.Point(16, 34);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 17);
            this.label24.TabIndex = 258;
            this.label24.Text = "Street";
            // 
            // lblAddressHeader
            // 
            this.lblAddressHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddressHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblAddressHeader.Location = new System.Drawing.Point(16, 11);
            this.lblAddressHeader.Name = "lblAddressHeader";
            this.lblAddressHeader.Size = new System.Drawing.Size(67, 17);
            this.lblAddressHeader.TabIndex = 257;
            this.lblAddressHeader.Text = "Address";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(79, 18);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(236, 2);
            this.groupBox8.TabIndex = 256;
            this.groupBox8.TabStop = false;
            // 
            // label28
            // 
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label28.Location = new System.Drawing.Point(201, 128);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 27);
            this.label28.TabIndex = 263;
            this.label28.Text = "Postal\r\nCode";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpContact
            // 
            this.tbpContact.Controls.Add(this.pnlBody);
            this.tbpContact.Controls.Add(this.pnlBottom);
            this.tbpContact.Location = new System.Drawing.Point(4, 22);
            this.tbpContact.Name = "tbpContact";
            this.tbpContact.Size = new System.Drawing.Size(632, 484);
            this.tbpContact.TabIndex = 2;
            this.tbpContact.Text = "Contact";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.grdContact);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(632, 436);
            this.pnlBody.TabIndex = 3;
            // 
            // grdContact
            // 
            this.grdContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContact.EmbeddedNavigator.Name = "";
            this.grdContact.ExternalRepository = this.persistentRepository1;
            this.grdContact.Location = new System.Drawing.Point(0, 0);
            this.grdContact.MainView = this.gvwContact;
            this.grdContact.Name = "grdContact";
            this.grdContact.Size = new System.Drawing.Size(632, 436);
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
            this.gvwContact.OptionsView.ShowHorzLines = false;
            this.gvwContact.OptionsView.ShowIndicator = false;
            this.gvwContact.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolContactType, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvwContact.Appearance.FocusedRow.AssignInternal(this.gvwContact.Appearance.SelectedRow);
            //this.gvwContact.ViewStyles.AddReplace("FocusedRow", "SelectedRow");
            //this.gvwContact.ViewStyles.AddReplace("FocusedCell", "SelectedRow");
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
            this.pnlBottom.Size = new System.Drawing.Size(632, 48);
            this.pnlBottom.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(279, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Delete";
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
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(465, 524);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(382, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(548, 524);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPageSetup.Location = new System.Drawing.Point(99, 524);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(75, 23);
            this.btnPageSetup.TabIndex = 22;
            this.btnPageSetup.Text = "Page Setup";
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(16, 524);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
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
            // frmClientDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(642, 558);
            this.Controls.Add(this.btnPageSetup);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbcClient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client...";
            this.Load += new System.EventHandler(this.frmClientDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientDlg_KeyDown);
            this.tbcClient.ResumeLayout(false);
            this.tbpClientInfo.ResumeLayout(false);
            this.pnlClientInfo.ResumeLayout(false);
            this.pnlClientInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tbpAddress.ResumeLayout(false);
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.tbpContact.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwContact)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void LoadData()
		{
            if (_mode == "Edit" || _mode == "AddClone")
			{
                if (_mode == "Edit")
                {
                    btnDelete.Enabled = true;
                    this.Text = "Editing Client...";
                }
                else
                {
                    btnDelete.Enabled = false;
                    this.Text = "Adding Client Clone...";
                }
				
				Scheduler.BusinessLayer.Contact objContact=new Scheduler.BusinessLayer.Contact();
				objContact.ContactID = _contactid;
				objContact.LoadData("Contact");

				foreach(DataRow dr in objContact.dtblContacts.Rows)
				{
					txtCompName.Text = dr["CompanyName"].ToString();
					txtCompName.Tag = txtCompName.Text;
                    if (_mode == "AddClone") txtCompName.Text = "Copy of " + txtCompName.Text;

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

					if(dr["DateJoined"]!=System.DBNull.Value)
					{
						dtJoined.Value = Convert.ToDateTime(dr["DateJoined"].ToString());
						dtJoined.Checked = true;
					}
					else
					{
						dtJoined.Checked=false;
					}

					if(dr["DateEnded"]!=System.DBNull.Value)
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
			}
			else
			{
				btnDelete.Enabled=true;
				this.Text = "Adding Client...";

				txtCompName.Text = String.Empty;
				txtCompName.Tag = String.Empty;

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

				dtJoined.Checked = dtEnded.Checked = true;
				dtJoined.Value = dtEnded.Value = DateTime.Now;

				txtMintSt1.Text = String.Empty;
				txtClosestSt1.Text = String.Empty;
				txtClosestLine1.Text = String.Empty;

				txtMintSt2.Text = String.Empty;
				txtClosestSt2.Text = String.Empty;
				txtClosestLine2.Text = String.Empty;

				cmbStatus.SelectedIndex = 0;

			}
			LoadContact();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if(!deleted) this.DialogResult = DialogResult.Cancel;
			else if(deleted) this.DialogResult = DialogResult.OK;

			Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			bool boolSuccess;
			
			if(txtCompName.Text=="")
			{
				Scheduler.BusinessLayer.Message.MsgInformation("Enter Company Name");
				txtCompName.Focus();
				return;
			}
			
			Scheduler.BusinessLayer.Contact objContact=null;
			
			objContact=new Scheduler.BusinessLayer.Contact();
			objContact.ContactID=0;

			objContact.LastName = "";
			objContact.LastNamePhonetic="";
			objContact.LastNameRomaji="";
			objContact.FirstName="";
			objContact.FirstNamePhonetic="";
			objContact.FirstNameRomaji="";
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
			objContact.ContactType=2;
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

			if(dtJoined.Checked)
				objContact.DateJoined=dtJoined.Value;
			else
				objContact.DateJoined=Convert.ToDateTime(null);

			if(dtEnded.Checked)
				objContact.DateEnded=dtEnded.Value;
			else
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
			objContact.MinutesToStation1=Convert.ToInt16(txtMintSt1.Text);
			objContact.ClosestStation2=txtClosestSt2.Text;
			objContact.ClosestLine2=txtClosestLine2.Text;
			objContact.MinutesToStation2=Convert.ToInt16(txtMintSt2.Text);
			objContact.ContactStatus=cmbStatus.SelectedIndex;

            if ((_mode == "Add") || (_mode == "AddClone") || (_mode == ""))
			{
				if(objContact.Exists(txtCompName.Text, 2))
				{
					Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Client Name not allowed");
					txtCompName.Focus();
					return;
				}
				if(txtNickName.Text!="")
				{
					if(objContact.NickNameExists(txtNickName.Text, 2))
					{
						Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Abbreviated Name not allowed");
						txtNickName.Focus();
						return;
					}
				}
				boolSuccess = objContact.InsertData();
				if(boolSuccess)
				{
					if(intRandomNo>0)
					{
						//replace the randomno with deptid
						objContact.RefID=objContact.ContactID;
						objContact.UpdateRefID(intRandomNo);
					}
				}
			}
			else
			{
				if(txtCompName.Text!=txtCompName.Tag.ToString())
				{
					if(objContact.Exists(txtCompName.Text, 2))
					{
						Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Client Name not allowed");
						txtCompName.Focus();
						return;
					}
				}
				if(txtNickName.Text!="")
				{
					if(txtNickName.Text!=txtNickName.Tag.ToString())
					{
						if(objContact.NickNameExists(txtNickName.Text, 2))
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
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void frmClientDlg_Load(object sender, System.EventArgs e)
		{
			this.ActiveControl=txtCompName;

			try
			{
				Common.SetControlFont(this);
				Common.SetGridFont(grdContact);
			}
			catch{}
			this.Refresh();
			
			if(_mode=="Edit")
			{
				this.Text = "Editing Client...";
			}
			else
			{
				this.Text = "Adding Client...";
				cmbStatus.SelectedIndex=0;
			}
		}

		private void frmClientDlg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(BusinessLayer.Message.MsgDelete())
			{
				Scheduler.BusinessLayer.Contact objContact=new Scheduler.BusinessLayer.Contact();
				objContact.ContactID = _contactid;
				if(!objContact.DeleteData())
				{
					BusinessLayer.Message.MsgWarning("Client cannot be deleted");
					return;
				}
				else
				{
					deleted=true;
					btnDelete.Enabled=false;
					this.Text = "Adding Client...";
					_mode="Add";
					_contactid=0;

					foreach(Control c in tbpAddress.Controls)
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
					foreach(Control c in tbpClientInfo.Controls)
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
					Common.MakeReadOnly(tbpClientInfo, false);
					Common.MakeReadOnly(tbpAddress, false);
					cmbStatus.Enabled=true;
				}
				else
				{
					Common.MakeEnabled(tbpClientInfo, false);
					Common.MakeEnabled(tbpAddress, false);
				}
			}
		}

		private int intRandomNo=0;

		private int getRandomNo()
		{
			System.Random r=new Random();
			intRandomNo=r.Next(999999999);
			return intRandomNo;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			frmClientDeptContactDlg objContact=new frmClientDeptContactDlg();
			objContact.ContactType = "ClientContact";
			objContact.Mode="Add";
			if(_contactid<=0) 
			{
				getRandomNo();
				objContact.RefID=intRandomNo;
			}
			else objContact.RefID=_contactid;
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
			objContact.ContactType = "ClientContact";
			objContact.Mode="Edit";
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

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			BusinessLayer.Contact objContact=new BusinessLayer.Contact();
			objContact.ContactType=4;

			if(gvwContact.FocusedRowHandle<0) return;
			int _contid=0;
			_contid=Convert.ToInt32(gvwContact.GetRowCellValue(gvwContact.FocusedRowHandle, gcolContactID).ToString());
			objContact.ContactID =_contid;
			objContact.DeleteData();

			LoadData();
		}

		private void grdContact_DoubleClick(object sender, System.EventArgs e)
		{
			btnEdit_Click(sender, e);
		}

		private void LoadContact()
		{
            if (_mode != "AddClone")
            {
                BusinessLayer.Contact objContact = new BusinessLayer.Contact();
                objContact.ContactType = 4;
                objContact.RefID = _contactid;
                if (_contactid <= 0) objContact.RefID = intRandomNo;
                DataTable dtbl = objContact.LoadData("ClientContact");
                grdContact.DataSource = (DataTable)dtbl;
            }
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel pnl=new Panel();
			//pnl.Tag = "Client Information";
			pnl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			pnl.Tag = "Client Information";
			pnl.Width = tbcClient.Width;
			pnl.Height = tbcClient.Height*3+20;

			pnlClientInfo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			//pnlClientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

			pnl.Controls.Add(pnlAddress);
			pnl.Controls.Add(pnlClientInfo);
            
            //Resize for print-outs
            pnlClientInfo.Height = 160;
			pnlClientInfo.Dock = DockStyle.Top;
			pnlAddress.Dock = DockStyle.Fill;
			

			CreateFormPrintingObject(pnl);
			//PrintingFunctions.SetProperties(ref fp, ps);
            PrintingFunctions.SetProperties(ref xfp);

			// Print!
			xfp.Print();

			tbpClientInfo.Controls.Add(pnlClientInfo);
			tbpAddress.Controls.Add(pnlAddress);
            pnlClientInfo.Height = 484;
            pnlClientInfo.Dock = DockStyle.Fill;

			pnl.Dispose();
			pnl=null;
		}

		private FormPrinting fp=null;
        private clsDevExpressFormPrinting xfp = null;
		private void CreateFormPrintingObject(System.Windows.Forms.Control c)
		{
			//fp = new FormPrinting(c);
            xfp = new clsDevExpressFormPrinting(c, printingSystem1);
		}

		private PageSettings ps=null;
		private void btnPageSetup_Click(object sender, System.EventArgs e)
		{
			//PrintingFunctions.ShowPageSettings(ref ps);
            //printingSystem.PageSetup();
            printingSystem1.PageSetup();
		}

		private DataGridPrinter dataGridPrinter1=null;
		private void button1_Click(object sender, System.EventArgs e)
		{
			DataTable dtbl = (DataTable)gvwContact.DataSource;
			dataGridPrinter1 = new DataGridPrinter(grdContact, printDocument1, dtbl);

			dataGridPrinter1.PageNumber = 1;
			dataGridPrinter1.RowCount = 0;
			if (this.printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
			}
		}

		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Graphics	g = e.Graphics;
			float yPosition = DrawTopLabel(g);
			bool more = dataGridPrinter1.DrawDataGrid(g, yPosition);
			if (more == true)
			{
				e.HasMorePages = true;
				dataGridPrinter1.PageNumber++;
			}
		}

		float DrawTopLabel(Graphics g)
		{
			int TopMargin = printDocument1.DefaultPageSettings.Margins.Top;

            g.FillRectangle(new SolidBrush(lblContactInfoHeader.BackColor),
                            lblContactInfoHeader.Location.X, lblContactInfoHeader.Location.Y + TopMargin, lblContactInfoHeader.Size.Width, lblContactInfoHeader.Size.Height);
            g.DrawString(lblContactInfoHeader.Text, lblContactInfoHeader.Font, new SolidBrush(lblContactInfoHeader.ForeColor),
                         lblContactInfoHeader.Location.X + 50, lblContactInfoHeader.Location.Y + TopMargin, new StringFormat());
            return lblContactInfoHeader.Location.Y + TopMargin + lblContactInfoHeader.Size.Height;
		}

		private void pnlAddress_Paint(object sender, PaintEventArgs e)
        {}
	}
}
