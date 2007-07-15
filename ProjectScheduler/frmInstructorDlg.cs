using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Scheduler.BusinessLayer;
using System.Drawing.Printing;
using Message=Scheduler.BusinessLayer.Message;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmInstructorDlg.
	/// </summary>
	public class frmInstructorDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tbcUser;
		private System.Windows.Forms.TabPage tbpPersonal;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmbEmpStatus;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ComboBox cmbStatus;
		private System.Windows.Forms.TextBox txtNationality;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.DateTimePicker dtVisaTo;
		private System.Windows.Forms.DateTimePicker dtVisaFrom;
		private System.Windows.Forms.DateTimePicker dtEnded;
		private System.Windows.Forms.DateTimePicker dtJoined;
		private System.Windows.Forms.DateTimePicker dtDOB;
		private System.Windows.Forms.Label lblHRHeader;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TextBox txtVisaStatus;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox txtNoDependent;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label lblMarried;
		private System.Windows.Forms.ComboBox cmbMarried;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.ComboBox cmbTitle;
		private System.Windows.Forms.TextBox txtTitleJob;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label lblUserHeader;
		private System.Windows.Forms.Label lblCompHeader;
		private System.Windows.Forms.TextBox txtCompRomaji;
		private System.Windows.Forms.TextBox txtCompPhonetic;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCompName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtFNameRomaji;
		private System.Windows.Forms.TextBox txtFNamePhonetic;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLNameRomaji;
		private System.Windows.Forms.TextBox txtLNamePhonetic;
		private System.Windows.Forms.Label lblLNameRomaji;
		private System.Windows.Forms.Label lblLNamePhonetic;
		private System.Windows.Forms.TextBox txtLName;
		private System.Windows.Forms.Label lblLName;
		private System.Windows.Forms.TabPage tbpContact;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.TextBox txtFax2;
		private System.Windows.Forms.TextBox txtFax1;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label lblContactInfoHeader;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox txtPhoneOther;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox txtPhone4;
		private System.Windows.Forms.TextBox txtPhone3;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox txtMobile2;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox txtMobile1;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox txtPhone2;
		private System.Windows.Forms.TextBox txtPhone1;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txtEmail2;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox txtEmail1;
		private System.Windows.Forms.Label label30;
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
        private IContainer components;

		private string _mode="";
		private System.Windows.Forms.Button btnDelete;
		private int _contactid=0;
		private System.Windows.Forms.Panel pnlPersonal;
		private System.Windows.Forms.Panel pnlAddress;
		private System.Windows.Forms.Button btnPageSetup;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox1;
        private Label label28;
        private Label label8;
        private TextBox spinBaseRate;
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

		public frmInstructorDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            this.tbcUser = new System.Windows.Forms.TabControl();
            this.tbpPersonal = new System.Windows.Forms.TabPage();
            this.pnlPersonal = new System.Windows.Forms.Panel();
            this.spinBaseRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEmpStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.dtVisaTo = new System.Windows.Forms.DateTimePicker();
            this.dtVisaFrom = new System.Windows.Forms.DateTimePicker();
            this.dtEnded = new System.Windows.Forms.DateTimePicker();
            this.dtJoined = new System.Windows.Forms.DateTimePicker();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.lblHRHeader = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtVisaStatus = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.txtNoDependent = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.lblMarried = new System.Windows.Forms.Label();
            this.cmbMarried = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.txtTitleJob = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblUserHeader = new System.Windows.Forms.Label();
            this.lblCompHeader = new System.Windows.Forms.Label();
            this.txtCompRomaji = new System.Windows.Forms.TextBox();
            this.txtCompPhonetic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFNameRomaji = new System.Windows.Forms.TextBox();
            this.txtFNamePhonetic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLNameRomaji = new System.Windows.Forms.TextBox();
            this.txtLNamePhonetic = new System.Windows.Forms.TextBox();
            this.lblLNameRomaji = new System.Windows.Forms.Label();
            this.lblLNamePhonetic = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.lblLName = new System.Windows.Forms.Label();
            this.tbpContact = new System.Windows.Forms.TabPage();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtFax2 = new System.Windows.Forms.TextBox();
            this.txtFax1 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.lblContactInfoHeader = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtPhoneOther = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtPhone4 = new System.Windows.Forms.TextBox();
            this.txtPhone3 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtMobile2 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtMobile1 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPageSetup = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.tbcUser.SuspendLayout();
            this.tbpPersonal.SuspendLayout();
            this.pnlPersonal.SuspendLayout();
            this.tbpContact.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcUser
            // 
            this.tbcUser.Controls.Add(this.tbpPersonal);
            this.tbcUser.Controls.Add(this.tbpContact);
            this.tbcUser.Location = new System.Drawing.Point(0, 2);
            this.tbcUser.Name = "tbcUser";
            this.tbcUser.SelectedIndex = 0;
            this.tbcUser.Size = new System.Drawing.Size(656, 456);
            this.tbcUser.TabIndex = 3;
            // 
            // tbpPersonal
            // 
            this.tbpPersonal.Controls.Add(this.pnlPersonal);
            this.tbpPersonal.Location = new System.Drawing.Point(4, 22);
            this.tbpPersonal.Name = "tbpPersonal";
            this.tbpPersonal.Size = new System.Drawing.Size(648, 430);
            this.tbpPersonal.TabIndex = 1;
            this.tbpPersonal.Text = "Personal";
            this.tbpPersonal.Visible = false;
            // 
            // pnlPersonal
            // 
            this.pnlPersonal.Controls.Add(this.spinBaseRate);
            this.pnlPersonal.Controls.Add(this.label8);
            this.pnlPersonal.Controls.Add(this.groupBox1);
            this.pnlPersonal.Controls.Add(this.groupBox4);
            this.pnlPersonal.Controls.Add(this.label7);
            this.pnlPersonal.Controls.Add(this.cmbEmpStatus);
            this.pnlPersonal.Controls.Add(this.lblStatus);
            this.pnlPersonal.Controls.Add(this.cmbStatus);
            this.pnlPersonal.Controls.Add(this.txtNationality);
            this.pnlPersonal.Controls.Add(this.label64);
            this.pnlPersonal.Controls.Add(this.dtVisaTo);
            this.pnlPersonal.Controls.Add(this.dtVisaFrom);
            this.pnlPersonal.Controls.Add(this.dtEnded);
            this.pnlPersonal.Controls.Add(this.dtJoined);
            this.pnlPersonal.Controls.Add(this.dtDOB);
            this.pnlPersonal.Controls.Add(this.lblHRHeader);
            this.pnlPersonal.Controls.Add(this.groupBox12);
            this.pnlPersonal.Controls.Add(this.label45);
            this.pnlPersonal.Controls.Add(this.txtVisaStatus);
            this.pnlPersonal.Controls.Add(this.label46);
            this.pnlPersonal.Controls.Add(this.label47);
            this.pnlPersonal.Controls.Add(this.txtNoDependent);
            this.pnlPersonal.Controls.Add(this.label44);
            this.pnlPersonal.Controls.Add(this.lblMarried);
            this.pnlPersonal.Controls.Add(this.cmbMarried);
            this.pnlPersonal.Controls.Add(this.label42);
            this.pnlPersonal.Controls.Add(this.label39);
            this.pnlPersonal.Controls.Add(this.label40);
            this.pnlPersonal.Controls.Add(this.cmbTitle);
            this.pnlPersonal.Controls.Add(this.txtTitleJob);
            this.pnlPersonal.Controls.Add(this.label21);
            this.pnlPersonal.Controls.Add(this.label22);
            this.pnlPersonal.Controls.Add(this.lblUserHeader);
            this.pnlPersonal.Controls.Add(this.lblCompHeader);
            this.pnlPersonal.Controls.Add(this.txtCompRomaji);
            this.pnlPersonal.Controls.Add(this.txtCompPhonetic);
            this.pnlPersonal.Controls.Add(this.label4);
            this.pnlPersonal.Controls.Add(this.label5);
            this.pnlPersonal.Controls.Add(this.txtCompName);
            this.pnlPersonal.Controls.Add(this.label6);
            this.pnlPersonal.Controls.Add(this.txtFNameRomaji);
            this.pnlPersonal.Controls.Add(this.txtFNamePhonetic);
            this.pnlPersonal.Controls.Add(this.label1);
            this.pnlPersonal.Controls.Add(this.label2);
            this.pnlPersonal.Controls.Add(this.txtFName);
            this.pnlPersonal.Controls.Add(this.label3);
            this.pnlPersonal.Controls.Add(this.txtLNameRomaji);
            this.pnlPersonal.Controls.Add(this.txtLNamePhonetic);
            this.pnlPersonal.Controls.Add(this.lblLNameRomaji);
            this.pnlPersonal.Controls.Add(this.lblLNamePhonetic);
            this.pnlPersonal.Controls.Add(this.txtLName);
            this.pnlPersonal.Controls.Add(this.lblLName);
            this.pnlPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPersonal.Location = new System.Drawing.Point(0, 0);
            this.pnlPersonal.Name = "pnlPersonal";
            this.pnlPersonal.Size = new System.Drawing.Size(648, 430);
            this.pnlPersonal.TabIndex = 238;
            // 
            // spinBaseRate
            // 
            this.spinBaseRate.Location = new System.Drawing.Point(497, 343);
            this.spinBaseRate.MaxLength = 255;
            this.spinBaseRate.Name = "spinBaseRate";
            this.spinBaseRate.Size = new System.Drawing.Size(80, 21);
            this.spinBaseRate.TabIndex = 241;
            this.spinBaseRate.Tag = "N";
            this.spinBaseRate.Text = "0";
            this.spinBaseRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinBaseRate.Leave += new System.EventHandler(this.spinBaseRate_Leave);
            this.spinBaseRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spinBaseRate_KeyPress);
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(347, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 17);
            this.label8.TabIndex = 240;
            this.label8.Text = "Base Pay Rate(yen/hr)";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(84, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 2);
            this.groupBox1.TabIndex = 239;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(86, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(234, 2);
            this.groupBox4.TabIndex = 238;
            this.groupBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(347, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 17);
            this.label7.TabIndex = 237;
            this.label7.Text = "Employee Status";
            // 
            // cmbEmpStatus
            // 
            this.cmbEmpStatus.Items.AddRange(new object[] {
            "Full-time",
            "Part-time",
            "Special",
            "Other"});
            this.cmbEmpStatus.Location = new System.Drawing.Point(497, 40);
            this.cmbEmpStatus.Name = "cmbEmpStatus";
            this.cmbEmpStatus.Size = new System.Drawing.Size(144, 21);
            this.cmbEmpStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(347, 321);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(112, 17);
            this.lblStatus.TabIndex = 235;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(497, 319);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(144, 21);
            this.cmbStatus.TabIndex = 21;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(497, 152);
            this.txtNationality.MaxLength = 255;
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(144, 21);
            this.txtNationality.TabIndex = 15;
            // 
            // label64
            // 
            this.label64.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label64.Location = new System.Drawing.Point(347, 154);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(112, 17);
            this.label64.TabIndex = 233;
            this.label64.Text = "Nationality";
            // 
            // dtVisaTo
            // 
            this.dtVisaTo.CustomFormat = "MM/dd/yyyy";
            this.dtVisaTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisaTo.Location = new System.Drawing.Point(497, 294);
            this.dtVisaTo.Name = "dtVisaTo";
            this.dtVisaTo.ShowCheckBox = true;
            this.dtVisaTo.Size = new System.Drawing.Size(144, 21);
            this.dtVisaTo.TabIndex = 20;
            // 
            // dtVisaFrom
            // 
            this.dtVisaFrom.CustomFormat = "MM/dd/yyyy";
            this.dtVisaFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisaFrom.Location = new System.Drawing.Point(497, 270);
            this.dtVisaFrom.Name = "dtVisaFrom";
            this.dtVisaFrom.ShowCheckBox = true;
            this.dtVisaFrom.Size = new System.Drawing.Size(144, 21);
            this.dtVisaFrom.TabIndex = 19;
            // 
            // dtEnded
            // 
            this.dtEnded.CustomFormat = "MM/dd/yyyy";
            this.dtEnded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnded.Location = new System.Drawing.Point(497, 113);
            this.dtEnded.Name = "dtEnded";
            this.dtEnded.ShowCheckBox = true;
            this.dtEnded.Size = new System.Drawing.Size(144, 21);
            this.dtEnded.TabIndex = 14;
            // 
            // dtJoined
            // 
            this.dtJoined.CustomFormat = "MM/dd/yyyy";
            this.dtJoined.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtJoined.Location = new System.Drawing.Point(497, 88);
            this.dtJoined.Name = "dtJoined";
            this.dtJoined.ShowCheckBox = true;
            this.dtJoined.Size = new System.Drawing.Size(144, 21);
            this.dtJoined.TabIndex = 13;
            // 
            // dtDOB
            // 
            this.dtDOB.CustomFormat = "MM/dd/yyyy";
            this.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDOB.Location = new System.Drawing.Point(497, 64);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.ShowCheckBox = true;
            this.dtDOB.Size = new System.Drawing.Size(144, 21);
            this.dtDOB.TabIndex = 12;
            // 
            // lblHRHeader
            // 
            this.lblHRHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHRHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHRHeader.Location = new System.Drawing.Point(348, 18);
            this.lblHRHeader.Name = "lblHRHeader";
            this.lblHRHeader.Size = new System.Drawing.Size(28, 17);
            this.lblHRHeader.TabIndex = 232;
            this.lblHRHeader.Text = "HR";
            // 
            // groupBox12
            // 
            this.groupBox12.Location = new System.Drawing.Point(369, 24);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(250, 3);
            this.groupBox12.TabIndex = 231;
            this.groupBox12.TabStop = false;
            // 
            // label45
            // 
            this.label45.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label45.Location = new System.Drawing.Point(347, 296);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(112, 17);
            this.label45.TabIndex = 230;
            this.label45.Text = "Visa Until Date";
            // 
            // txtVisaStatus
            // 
            this.txtVisaStatus.Location = new System.Drawing.Point(497, 246);
            this.txtVisaStatus.MaxLength = 255;
            this.txtVisaStatus.Name = "txtVisaStatus";
            this.txtVisaStatus.Size = new System.Drawing.Size(144, 21);
            this.txtVisaStatus.TabIndex = 18;
            // 
            // label46
            // 
            this.label46.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label46.Location = new System.Drawing.Point(347, 272);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(112, 17);
            this.label46.TabIndex = 229;
            this.label46.Text = "Visa From Date";
            // 
            // label47
            // 
            this.label47.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label47.Location = new System.Drawing.Point(347, 248);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(112, 17);
            this.label47.TabIndex = 228;
            this.label47.Text = "Visa Status";
            // 
            // txtNoDependent
            // 
            this.txtNoDependent.Location = new System.Drawing.Point(497, 200);
            this.txtNoDependent.MaxLength = 255;
            this.txtNoDependent.Name = "txtNoDependent";
            this.txtNoDependent.Size = new System.Drawing.Size(80, 21);
            this.txtNoDependent.TabIndex = 17;
            this.txtNoDependent.Tag = "N";
            this.txtNoDependent.Text = "0";
            this.txtNoDependent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoDependent.Leave += new System.EventHandler(this.txtNoDependent_Leave);
            this.txtNoDependent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoDependent_KeyPress);
            // 
            // label44
            // 
            this.label44.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label44.Location = new System.Drawing.Point(347, 202);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(112, 17);
            this.label44.TabIndex = 227;
            this.label44.Text = "No of Dependents";
            // 
            // lblMarried
            // 
            this.lblMarried.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMarried.Location = new System.Drawing.Point(347, 178);
            this.lblMarried.Name = "lblMarried";
            this.lblMarried.Size = new System.Drawing.Size(112, 17);
            this.lblMarried.TabIndex = 226;
            this.lblMarried.Text = "Married";
            // 
            // cmbMarried
            // 
            this.cmbMarried.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarried.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbMarried.Location = new System.Drawing.Point(497, 176);
            this.cmbMarried.Name = "cmbMarried";
            this.cmbMarried.Size = new System.Drawing.Size(80, 21);
            this.cmbMarried.TabIndex = 16;
            // 
            // label42
            // 
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.Location = new System.Drawing.Point(347, 115);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(112, 17);
            this.label42.TabIndex = 225;
            this.label42.Text = "Date Ended";
            // 
            // label39
            // 
            this.label39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label39.Location = new System.Drawing.Point(347, 90);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(112, 17);
            this.label39.TabIndex = 224;
            this.label39.Text = "Date Joined";
            // 
            // label40
            // 
            this.label40.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label40.Location = new System.Drawing.Point(347, 66);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(112, 17);
            this.label40.TabIndex = 223;
            this.label40.Text = "Date of Birth";
            // 
            // cmbTitle
            // 
            this.cmbTitle.Items.AddRange(new object[] {
            "Mr.",
            "Ms.",
            "Mrs.",
            "Miss",
            "Prof.",
            "Dr."});
            this.cmbTitle.Location = new System.Drawing.Point(136, 208);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(184, 21);
            this.cmbTitle.TabIndex = 6;
            // 
            // txtTitleJob
            // 
            this.txtTitleJob.Location = new System.Drawing.Point(136, 232);
            this.txtTitleJob.MaxLength = 255;
            this.txtTitleJob.Name = "txtTitleJob";
            this.txtTitleJob.Size = new System.Drawing.Size(184, 21);
            this.txtTitleJob.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label21.Location = new System.Drawing.Point(16, 234);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 17);
            this.label21.TabIndex = 194;
            this.label21.Text = "Job Title";
            // 
            // label22
            // 
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label22.Location = new System.Drawing.Point(16, 210);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 17);
            this.label22.TabIndex = 193;
            this.label22.Text = "Title";
            // 
            // lblUserHeader
            // 
            this.lblUserHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUserHeader.Location = new System.Drawing.Point(16, 17);
            this.lblUserHeader.Name = "lblUserHeader";
            this.lblUserHeader.Size = new System.Drawing.Size(72, 17);
            this.lblUserHeader.TabIndex = 189;
            this.lblUserHeader.Text = "Instructor";
            // 
            // lblCompHeader
            // 
            this.lblCompHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCompHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCompHeader.Location = new System.Drawing.Point(16, 273);
            this.lblCompHeader.Name = "lblCompHeader";
            this.lblCompHeader.Size = new System.Drawing.Size(65, 17);
            this.lblCompHeader.TabIndex = 187;
            this.lblCompHeader.Text = "Company";
            // 
            // txtCompRomaji
            // 
            this.txtCompRomaji.Location = new System.Drawing.Point(136, 344);
            this.txtCompRomaji.MaxLength = 255;
            this.txtCompRomaji.Name = "txtCompRomaji";
            this.txtCompRomaji.Size = new System.Drawing.Size(184, 21);
            this.txtCompRomaji.TabIndex = 10;
            // 
            // txtCompPhonetic
            // 
            this.txtCompPhonetic.Location = new System.Drawing.Point(136, 320);
            this.txtCompPhonetic.MaxLength = 255;
            this.txtCompPhonetic.Name = "txtCompPhonetic";
            this.txtCompPhonetic.Size = new System.Drawing.Size(184, 21);
            this.txtCompPhonetic.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(16, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 185;
            this.label4.Text = "Name Romaji";
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(16, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 184;
            this.label5.Text = "Name Phonetic";
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(136, 296);
            this.txtCompName.MaxLength = 255;
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(184, 21);
            this.txtCompName.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(16, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 183;
            this.label6.Text = "Name";
            // 
            // txtFNameRomaji
            // 
            this.txtFNameRomaji.Location = new System.Drawing.Point(136, 176);
            this.txtFNameRomaji.MaxLength = 255;
            this.txtFNameRomaji.Name = "txtFNameRomaji";
            this.txtFNameRomaji.Size = new System.Drawing.Size(184, 21);
            this.txtFNameRomaji.TabIndex = 5;
            // 
            // txtFNamePhonetic
            // 
            this.txtFNamePhonetic.Location = new System.Drawing.Point(136, 152);
            this.txtFNamePhonetic.MaxLength = 255;
            this.txtFNamePhonetic.Name = "txtFNamePhonetic";
            this.txtFNamePhonetic.Size = new System.Drawing.Size(184, 21);
            this.txtFNamePhonetic.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(16, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 182;
            this.label1.Text = "First Name Romaji";
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(16, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 181;
            this.label2.Text = "First Name Phonetic";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(136, 128);
            this.txtFName.MaxLength = 255;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(184, 21);
            this.txtFName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(16, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 180;
            this.label3.Text = "First Name";
            // 
            // txtLNameRomaji
            // 
            this.txtLNameRomaji.Location = new System.Drawing.Point(136, 88);
            this.txtLNameRomaji.MaxLength = 255;
            this.txtLNameRomaji.Name = "txtLNameRomaji";
            this.txtLNameRomaji.Size = new System.Drawing.Size(184, 21);
            this.txtLNameRomaji.TabIndex = 2;
            // 
            // txtLNamePhonetic
            // 
            this.txtLNamePhonetic.Location = new System.Drawing.Point(136, 64);
            this.txtLNamePhonetic.MaxLength = 255;
            this.txtLNamePhonetic.Name = "txtLNamePhonetic";
            this.txtLNamePhonetic.Size = new System.Drawing.Size(184, 21);
            this.txtLNamePhonetic.TabIndex = 1;
            // 
            // lblLNameRomaji
            // 
            this.lblLNameRomaji.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLNameRomaji.Location = new System.Drawing.Point(16, 90);
            this.lblLNameRomaji.Name = "lblLNameRomaji";
            this.lblLNameRomaji.Size = new System.Drawing.Size(112, 17);
            this.lblLNameRomaji.TabIndex = 179;
            this.lblLNameRomaji.Text = "Last Name Romaji";
            // 
            // lblLNamePhonetic
            // 
            this.lblLNamePhonetic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLNamePhonetic.Location = new System.Drawing.Point(16, 66);
            this.lblLNamePhonetic.Name = "lblLNamePhonetic";
            this.lblLNamePhonetic.Size = new System.Drawing.Size(118, 17);
            this.lblLNamePhonetic.TabIndex = 178;
            this.lblLNamePhonetic.Text = "Last Name Phonetic";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(136, 40);
            this.txtLName.MaxLength = 255;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(184, 21);
            this.txtLName.TabIndex = 0;
            // 
            // lblLName
            // 
            this.lblLName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLName.Location = new System.Drawing.Point(16, 42);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(112, 17);
            this.lblLName.TabIndex = 177;
            this.lblLName.Text = "Last Name";
            // 
            // tbpContact
            // 
            this.tbpContact.Controls.Add(this.pnlAddress);
            this.tbpContact.Location = new System.Drawing.Point(4, 22);
            this.tbpContact.Name = "tbpContact";
            this.tbpContact.Size = new System.Drawing.Size(648, 430);
            this.tbpContact.TabIndex = 2;
            this.tbpContact.Text = "Address";
            this.tbpContact.Visible = false;
            // 
            // pnlAddress
            // 
            this.pnlAddress.Controls.Add(this.label28);
            this.pnlAddress.Controls.Add(this.label36);
            this.pnlAddress.Controls.Add(this.txtUrl);
            this.pnlAddress.Controls.Add(this.label38);
            this.pnlAddress.Controls.Add(this.txtFax2);
            this.pnlAddress.Controls.Add(this.txtFax1);
            this.pnlAddress.Controls.Add(this.label41);
            this.pnlAddress.Controls.Add(this.lblContactInfoHeader);
            this.pnlAddress.Controls.Add(this.groupBox2);
            this.pnlAddress.Controls.Add(this.label20);
            this.pnlAddress.Controls.Add(this.label43);
            this.pnlAddress.Controls.Add(this.txtPhoneOther);
            this.pnlAddress.Controls.Add(this.label33);
            this.pnlAddress.Controls.Add(this.txtPhone4);
            this.pnlAddress.Controls.Add(this.txtPhone3);
            this.pnlAddress.Controls.Add(this.label37);
            this.pnlAddress.Controls.Add(this.txtMobile2);
            this.pnlAddress.Controls.Add(this.label34);
            this.pnlAddress.Controls.Add(this.txtMobile1);
            this.pnlAddress.Controls.Add(this.label35);
            this.pnlAddress.Controls.Add(this.txtPhone2);
            this.pnlAddress.Controls.Add(this.txtPhone1);
            this.pnlAddress.Controls.Add(this.label32);
            this.pnlAddress.Controls.Add(this.txtEmail2);
            this.pnlAddress.Controls.Add(this.label31);
            this.pnlAddress.Controls.Add(this.txtEmail1);
            this.pnlAddress.Controls.Add(this.label30);
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
            this.pnlAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddress.Location = new System.Drawing.Point(0, 0);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(648, 430);
            this.pnlAddress.TabIndex = 230;
            // 
            // label28
            // 
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label28.Location = new System.Drawing.Point(206, 136);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 27);
            this.label28.TabIndex = 230;
            this.label28.Text = "Postal\r\nCode";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.Location = new System.Drawing.Point(344, 306);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(104, 17);
            this.label36.TabIndex = 229;
            this.label36.Text = "Fax 2";
            // 
            // txtUrl
            // 
            this.txtUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUrl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtUrl.Location = new System.Drawing.Point(455, 328);
            this.txtUrl.MaxLength = 255;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(176, 21);
            this.txtUrl.TabIndex = 26;
            // 
            // label38
            // 
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.Location = new System.Drawing.Point(344, 330);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(104, 17);
            this.label38.TabIndex = 228;
            this.label38.Text = "URL";
            // 
            // txtFax2
            // 
            this.txtFax2.Location = new System.Drawing.Point(455, 304);
            this.txtFax2.MaxLength = 255;
            this.txtFax2.Name = "txtFax2";
            this.txtFax2.Size = new System.Drawing.Size(176, 21);
            this.txtFax2.TabIndex = 25;
            // 
            // txtFax1
            // 
            this.txtFax1.Location = new System.Drawing.Point(455, 280);
            this.txtFax1.MaxLength = 255;
            this.txtFax1.Name = "txtFax1";
            this.txtFax1.Size = new System.Drawing.Size(176, 21);
            this.txtFax1.TabIndex = 24;
            // 
            // label41
            // 
            this.label41.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label41.Location = new System.Drawing.Point(344, 282);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(104, 17);
            this.label41.TabIndex = 227;
            this.label41.Text = "Fax 1";
            // 
            // lblContactInfoHeader
            // 
            this.lblContactInfoHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblContactInfoHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInfoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblContactInfoHeader.Location = new System.Drawing.Point(344, 15);
            this.lblContactInfoHeader.Name = "lblContactInfoHeader";
            this.lblContactInfoHeader.Size = new System.Drawing.Size(85, 17);
            this.lblContactInfoHeader.TabIndex = 223;
            this.lblContactInfoHeader.Text = "Contact Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(424, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 3);
            this.groupBox2.TabIndex = 222;
            this.groupBox2.TabStop = false;
            // 
            // label20
            // 
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label20.Location = new System.Drawing.Point(344, 170);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(108, 17);
            this.label20.TabIndex = 221;
            this.label20.Text = "Business Phone 2";
            // 
            // label43
            // 
            this.label43.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label43.Location = new System.Drawing.Point(344, 194);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(104, 17);
            this.label43.TabIndex = 220;
            this.label43.Text = "Phone Other";
            // 
            // txtPhoneOther
            // 
            this.txtPhoneOther.Location = new System.Drawing.Point(455, 192);
            this.txtPhoneOther.MaxLength = 255;
            this.txtPhoneOther.Name = "txtPhoneOther";
            this.txtPhoneOther.Size = new System.Drawing.Size(176, 21);
            this.txtPhoneOther.TabIndex = 21;
            // 
            // label33
            // 
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.Location = new System.Drawing.Point(344, 122);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(104, 17);
            this.label33.TabIndex = 219;
            this.label33.Text = "Phone 2";
            // 
            // txtPhone4
            // 
            this.txtPhone4.Location = new System.Drawing.Point(455, 168);
            this.txtPhone4.MaxLength = 255;
            this.txtPhone4.Name = "txtPhone4";
            this.txtPhone4.Size = new System.Drawing.Size(176, 21);
            this.txtPhone4.TabIndex = 20;
            // 
            // txtPhone3
            // 
            this.txtPhone3.Location = new System.Drawing.Point(455, 144);
            this.txtPhone3.MaxLength = 255;
            this.txtPhone3.Name = "txtPhone3";
            this.txtPhone3.Size = new System.Drawing.Size(176, 21);
            this.txtPhone3.TabIndex = 19;
            // 
            // label37
            // 
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label37.Location = new System.Drawing.Point(344, 146);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(108, 17);
            this.label37.TabIndex = 218;
            this.label37.Text = "Business Phone 1";
            // 
            // txtMobile2
            // 
            this.txtMobile2.Location = new System.Drawing.Point(455, 240);
            this.txtMobile2.MaxLength = 255;
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Size = new System.Drawing.Size(176, 21);
            this.txtMobile2.TabIndex = 23;
            // 
            // label34
            // 
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.Location = new System.Drawing.Point(344, 242);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(104, 17);
            this.label34.TabIndex = 217;
            this.label34.Text = "Mobile 2";
            // 
            // txtMobile1
            // 
            this.txtMobile1.Location = new System.Drawing.Point(455, 216);
            this.txtMobile1.MaxLength = 255;
            this.txtMobile1.Name = "txtMobile1";
            this.txtMobile1.Size = new System.Drawing.Size(176, 21);
            this.txtMobile1.TabIndex = 22;
            // 
            // label35
            // 
            this.label35.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label35.Location = new System.Drawing.Point(344, 218);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(104, 17);
            this.label35.TabIndex = 216;
            this.label35.Text = "Mobile 1";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(455, 120);
            this.txtPhone2.MaxLength = 255;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(176, 21);
            this.txtPhone2.TabIndex = 18;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(455, 96);
            this.txtPhone1.MaxLength = 255;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(176, 21);
            this.txtPhone1.TabIndex = 17;
            // 
            // label32
            // 
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label32.Location = new System.Drawing.Point(344, 98);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(104, 17);
            this.label32.TabIndex = 215;
            this.label32.Text = "Phone 1";
            // 
            // txtEmail2
            // 
            this.txtEmail2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEmail2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtEmail2.Location = new System.Drawing.Point(455, 64);
            this.txtEmail2.MaxLength = 255;
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(176, 21);
            this.txtEmail2.TabIndex = 16;
            // 
            // label31
            // 
            this.label31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label31.Location = new System.Drawing.Point(344, 66);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(104, 17);
            this.label31.TabIndex = 214;
            this.label31.Text = "Email-2";
            // 
            // txtEmail1
            // 
            this.txtEmail1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEmail1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtEmail1.Location = new System.Drawing.Point(455, 40);
            this.txtEmail1.MaxLength = 255;
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(176, 21);
            this.txtEmail1.TabIndex = 15;
            // 
            // label30
            // 
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label30.Location = new System.Drawing.Point(344, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(104, 17);
            this.label30.TabIndex = 213;
            this.label30.Text = "Email-1";
            // 
            // lblStation2Header
            // 
            this.lblStation2Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStation2Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation2Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStation2Header.Location = new System.Drawing.Point(16, 319);
            this.lblStation2Header.Name = "lblStation2Header";
            this.lblStation2Header.Size = new System.Drawing.Size(65, 17);
            this.lblStation2Header.TabIndex = 203;
            this.lblStation2Header.Text = "Station 2";
            // 
            // groupBox11
            // 
            this.groupBox11.Location = new System.Drawing.Point(82, 326);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(232, 2);
            this.groupBox11.TabIndex = 202;
            this.groupBox11.TabStop = false;
            // 
            // txtMintSt2
            // 
            this.txtMintSt2.Location = new System.Drawing.Point(132, 389);
            this.txtMintSt2.MaxLength = 255;
            this.txtMintSt2.Name = "txtMintSt2";
            this.txtMintSt2.Size = new System.Drawing.Size(64, 21);
            this.txtMintSt2.TabIndex = 14;
            this.txtMintSt2.Tag = "N";
            this.txtMintSt2.Text = "0";
            this.txtMintSt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMintSt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMintSt1_KeyPress);
            // 
            // txtClosestLine2
            // 
            this.txtClosestLine2.Location = new System.Drawing.Point(132, 365);
            this.txtClosestLine2.MaxLength = 255;
            this.txtClosestLine2.Name = "txtClosestLine2";
            this.txtClosestLine2.Size = new System.Drawing.Size(184, 21);
            this.txtClosestLine2.TabIndex = 13;
            // 
            // label60
            // 
            this.label60.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label60.Location = new System.Drawing.Point(16, 391);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(112, 17);
            this.label60.TabIndex = 201;
            this.label60.Text = "Minutes to Station";
            // 
            // label61
            // 
            this.label61.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label61.Location = new System.Drawing.Point(16, 367);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(104, 17);
            this.label61.TabIndex = 200;
            this.label61.Text = "Closest Line";
            // 
            // txtClosestSt2
            // 
            this.txtClosestSt2.Location = new System.Drawing.Point(132, 341);
            this.txtClosestSt2.MaxLength = 255;
            this.txtClosestSt2.Name = "txtClosestSt2";
            this.txtClosestSt2.Size = new System.Drawing.Size(184, 21);
            this.txtClosestSt2.TabIndex = 12;
            // 
            // label62
            // 
            this.label62.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label62.Location = new System.Drawing.Point(16, 343);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(112, 17);
            this.label62.TabIndex = 199;
            this.label62.Text = "Closest Station";
            // 
            // lblStation1Header
            // 
            this.lblStation1Header.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStation1Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation1Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStation1Header.Location = new System.Drawing.Point(16, 214);
            this.lblStation1Header.Name = "lblStation1Header";
            this.lblStation1Header.Size = new System.Drawing.Size(65, 17);
            this.lblStation1Header.TabIndex = 198;
            this.lblStation1Header.Text = "Station 1";
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(82, 221);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(232, 2);
            this.groupBox10.TabIndex = 197;
            this.groupBox10.TabStop = false;
            // 
            // txtMintSt1
            // 
            this.txtMintSt1.Location = new System.Drawing.Point(132, 285);
            this.txtMintSt1.MaxLength = 255;
            this.txtMintSt1.Name = "txtMintSt1";
            this.txtMintSt1.Size = new System.Drawing.Size(64, 21);
            this.txtMintSt1.TabIndex = 11;
            this.txtMintSt1.Tag = "N";
            this.txtMintSt1.Text = "0";
            this.txtMintSt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMintSt1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMintSt1_KeyPress);
            // 
            // txtClosestLine1
            // 
            this.txtClosestLine1.Location = new System.Drawing.Point(132, 261);
            this.txtClosestLine1.MaxLength = 255;
            this.txtClosestLine1.Name = "txtClosestLine1";
            this.txtClosestLine1.Size = new System.Drawing.Size(184, 21);
            this.txtClosestLine1.TabIndex = 10;
            // 
            // label55
            // 
            this.label55.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label55.Location = new System.Drawing.Point(16, 287);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(112, 17);
            this.label55.TabIndex = 196;
            this.label55.Text = "Minutes to Station";
            // 
            // label56
            // 
            this.label56.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label56.Location = new System.Drawing.Point(16, 263);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(104, 17);
            this.label56.TabIndex = 195;
            this.label56.Text = "Closest Line";
            // 
            // txtClosestSt1
            // 
            this.txtClosestSt1.Location = new System.Drawing.Point(132, 237);
            this.txtClosestSt1.MaxLength = 255;
            this.txtClosestSt1.Name = "txtClosestSt1";
            this.txtClosestSt1.Size = new System.Drawing.Size(184, 21);
            this.txtClosestSt1.TabIndex = 9;
            // 
            // label57
            // 
            this.label57.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label57.Location = new System.Drawing.Point(16, 239);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(112, 17);
            this.label57.TabIndex = 194;
            this.label57.Text = "Closest Station";
            // 
            // label29
            // 
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Location = new System.Drawing.Point(16, 192);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(104, 17);
            this.label29.TabIndex = 186;
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
            this.cmbBlock.Location = new System.Drawing.Point(132, 190);
            this.cmbBlock.Name = "cmbBlock";
            this.cmbBlock.Size = new System.Drawing.Size(64, 21);
            this.cmbBlock.TabIndex = 8;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(132, 166);
            this.txtCountry.MaxLength = 255;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(184, 21);
            this.txtCountry.TabIndex = 7;
            // 
            // label27
            // 
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label27.Location = new System.Drawing.Point(16, 168);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 17);
            this.label27.TabIndex = 185;
            this.label27.Text = "Country";
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(260, 139);
            this.txtPost.MaxLength = 255;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(56, 21);
            this.txtPost.TabIndex = 6;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(132, 139);
            this.txtState.MaxLength = 255;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(64, 21);
            this.txtState.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label26.Location = new System.Drawing.Point(16, 141);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 17);
            this.label26.TabIndex = 184;
            this.label26.Text = "State";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(132, 112);
            this.txtCity.MaxLength = 255;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(184, 21);
            this.txtCity.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label25.Location = new System.Drawing.Point(16, 114);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 17);
            this.label25.TabIndex = 183;
            this.label25.Text = "City";
            // 
            // txtStreet3
            // 
            this.txtStreet3.Location = new System.Drawing.Point(132, 88);
            this.txtStreet3.MaxLength = 255;
            this.txtStreet3.Name = "txtStreet3";
            this.txtStreet3.Size = new System.Drawing.Size(184, 21);
            this.txtStreet3.TabIndex = 3;
            // 
            // txtStreet2
            // 
            this.txtStreet2.Location = new System.Drawing.Point(132, 64);
            this.txtStreet2.MaxLength = 255;
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(184, 21);
            this.txtStreet2.TabIndex = 2;
            // 
            // txtStreet1
            // 
            this.txtStreet1.Location = new System.Drawing.Point(132, 40);
            this.txtStreet1.MaxLength = 255;
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size(184, 21);
            this.txtStreet1.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label24.Location = new System.Drawing.Point(16, 42);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(104, 17);
            this.label24.TabIndex = 182;
            this.label24.Text = "Street";
            // 
            // lblAddressHeader
            // 
            this.lblAddressHeader.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAddressHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblAddressHeader.Location = new System.Drawing.Point(16, 15);
            this.lblAddressHeader.Name = "lblAddressHeader";
            this.lblAddressHeader.Size = new System.Drawing.Size(60, 17);
            this.lblAddressHeader.TabIndex = 181;
            this.lblAddressHeader.Text = "Address";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(82, 22);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(232, 2);
            this.groupBox8.TabIndex = 180;
            this.groupBox8.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(492, 468);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(409, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(575, 468);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPageSetup
            // 
            this.btnPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPageSetup.Location = new System.Drawing.Point(112, 468);
            this.btnPageSetup.Name = "btnPageSetup";
            this.btnPageSetup.Size = new System.Drawing.Size(75, 23);
            this.btnPageSetup.TabIndex = 22;
            this.btnPageSetup.Text = "Page Setup";
            this.btnPageSetup.Click += new System.EventHandler(this.btnPageSetup_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(24, 468);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmInstructorDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(658, 504);
            this.Controls.Add(this.btnPageSetup);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbcUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstructorDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instructor...";
            this.Load += new System.EventHandler(this.frmTeacherDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTeacherDlg_KeyDown);
            this.tbcUser.ResumeLayout(false);
            this.tbpPersonal.ResumeLayout(false);
            this.pnlPersonal.ResumeLayout(false);
            this.pnlPersonal.PerformLayout();
            this.tbpContact.ResumeLayout(false);
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if(!deleted) this.DialogResult = DialogResult.Cancel;
			else if(deleted) this.DialogResult = DialogResult.OK;

			Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			bool boolSuccess;

			if(txtFName.Text=="")
			{
				Scheduler.BusinessLayer.Message.MsgInformation("Enter First Name");
				txtFName.Focus();
				return;
			}
			if(txtLName.Text=="")
			{
				Scheduler.BusinessLayer.Message.MsgInformation("Enter Last Name");
				txtLName.Focus();
				return;
			}
			
			Scheduler.BusinessLayer.Contact objContact=null;
			
			objContact=new Scheduler.BusinessLayer.Contact();
			objContact.ContactID=0;

			objContact.LastName = txtLName.Text;
			objContact.LastNamePhonetic=txtLNamePhonetic.Text;
			objContact.LastNameRomaji=txtLNameRomaji.Text;
			objContact.FirstName=txtFName.Text;
			objContact.FirstNamePhonetic=txtFNamePhonetic.Text;
			objContact.FirstNameRomaji=txtFNameRomaji.Text;
			objContact.CompanyName=txtCompName.Text;
			objContact.CompanyNamePhonetic=txtCompPhonetic.Text;
			objContact.CompanyNameRomaji=txtCompRomaji.Text;
			objContact.TitleForName=cmbTitle.Text;
			objContact.TitleForJob=txtTitleJob.Text;
			objContact.Street1=txtStreet1.Text;
			objContact.Street2=txtStreet2.Text;
			objContact.Street3=txtStreet3.Text;
			objContact.City=txtCity.Text;
			objContact.State=txtState.Text;
			objContact.PostalCode=txtPost.Text;
			objContact.Country=txtCountry.Text;
			objContact.ContactType=1;
			objContact.BlockCode=cmbBlock.Text;
			objContact.Email1=txtEmail1.Text;
			objContact.Email2=txtEmail2.Text;
			objContact.AccountRepLastName="";
			objContact.AccountRepLastNamePhonetic="";
			objContact.AccountRepLastNameRomaji="";
			objContact.AccountRepFirstName="";
			objContact.AccountRepFirstNamePhonetic="";
			objContact.AccountRepFirstNameRomaji="";
			objContact.Phone1=txtPhone1.Text;
			objContact.Phone2=txtPhone2.Text;
			objContact.PhoneMobile1=txtMobile1.Text;
			objContact.PhoneMobile2=txtMobile2.Text;
			objContact.PhoneBusiness1=txtPhone3.Text;
			objContact.PhoneBusiness2=txtPhone4.Text;
			objContact.PhoneFax1=txtFax1.Text;
			objContact.PhoneFax2=txtFax2.Text;
			objContact.PhoneOther=txtPhoneOther.Text;
			objContact.Url=txtUrl.Text;
            objContact.BaseRate = Convert.ToDecimal(spinBaseRate.Text);
			if(dtDOB.Checked)
				objContact.DateBirth=dtDOB.Value;
			else
				objContact.DateBirth=Convert.ToDateTime(null);

			if(dtJoined.Checked)
				objContact.DateJoined=dtJoined.Value;
			else
				objContact.DateJoined=Convert.ToDateTime(null);

			if(dtEnded.Checked)
				objContact.DateEnded=dtEnded.Value;
			else
				objContact.DateEnded=Convert.ToDateTime(null);
			
			objContact.TimeStatus= cmbEmpStatus.Text;
			objContact.Nationality=txtNationality.Text;
			objContact.Married=cmbMarried.SelectedIndex;
			objContact.NumberDependents=Convert.ToInt16(txtNoDependent.Text);

			objContact.VisaStatus=txtVisaStatus.Text;
			if(dtVisaTo.Checked)
				objContact.VisaFromDate=dtVisaFrom.Value;
			else
				objContact.VisaFromDate=Convert.ToDateTime(null);
			
			if(dtVisaTo.Checked)
				objContact.VisaUntilDate=dtVisaTo.Value;
			else
				objContact.VisaUntilDate=Convert.ToDateTime(null);

			objContact.ClosestStation1=txtClosestSt1.Text;
			objContact.ClosestLine1=txtClosestLine1.Text;
			objContact.MinutesToStation1=Convert.ToInt16(txtMintSt1.Text);
			objContact.ClosestStation2=txtClosestSt2.Text;
			objContact.ClosestLine2=txtClosestLine2.Text;
			objContact.MinutesToStation2=Convert.ToInt16(txtMintSt2.Text);
			objContact.ContactStatus=cmbStatus.SelectedIndex;

			objContact.ContactID=_contactid;
			if(objContact.Exists(txtFName.Text, txtLName.Text, 1))
			{
				Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Instructor Name not allowed");
				txtLName.Focus();
				return;
			}

            if ((_mode == "Add") || (_mode == "AddClone") || (_mode == ""))
			{
				boolSuccess = objContact.InsertData();
			}
			else
			{
				objContact.ContactID=_contactid;
				boolSuccess = objContact.UpdateData();
			}
			if(!boolSuccess)
			{
                if (_mode == "Add")
                    Scheduler.BusinessLayer.Message.ShowException("Adding Instructor record.", objContact.Message);
                else if (_mode == "AddClone")
                    Scheduler.BusinessLayer.Message.ShowException("Cloning Instructor record.", objContact.Message);
                else
                    Scheduler.BusinessLayer.Message.ShowException("Updating Instructor record.", objContact.Message);
				return;
			}

			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void frmTeacherDlg_Load(object sender, System.EventArgs e)
		{
			this.ActiveControl=txtLName;
            printingSystem1.PageSettings.RightMargin = 80;
            printingSystem1.PageSettings.LeftMargin = 80;
            
			try
			{
				Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();

			if(_mode=="Edit")
			{
				this.Text = "Editing Instructor...";
			}
			else
			{
				btnDelete.Enabled=false;
				this.Text = "Adding Instructor...";
				cmbStatus.SelectedIndex=0;
			}
		}

		public void LoadData()
		{
            if (_mode == "Edit" || _mode == "AddClone")
			{
                if (_mode == "Edit")
                    this.Text = "Editing Instructor...";
                else
                    this.Text = "Adding Instructor Clone...";
				
				Scheduler.BusinessLayer.Contact objContact=new Scheduler.BusinessLayer.Contact();
				objContact.ContactID = _contactid;
				objContact.LoadData("Teacher");

				foreach(DataRow dr in objContact.dtblContacts.Rows)
				{
					txtLName.Text = dr["LastName"].ToString();
					txtLNamePhonetic.Text = dr["LastNamePhonetic"].ToString();
					txtLNameRomaji.Text = dr["LastNameRomaji"].ToString();
					txtFName.Text = dr["FirstName"].ToString();
                    if (_mode == "AddClone") txtFName.Text = "Copy of " + txtFName.Text;
					txtFNamePhonetic.Text = dr["FirstNamePhonetic"].ToString();
					txtFNameRomaji.Text = dr["FirstNameRomaji"].ToString();

					txtCompName.Text = dr["CompanyName"].ToString();
					txtCompPhonetic.Text = dr["CompanyNamePhonetic"].ToString();
					txtCompRomaji.Text = dr["CompanyNameRomaji"].ToString();

					cmbTitle.Text = dr["TitleForname"].ToString();
					txtTitleJob.Text = dr["TitleForJob"].ToString();

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

					txtEmail1.Text = dr["Email1"].ToString();
					txtEmail2.Text = dr["EMail2"].ToString();

					txtPhone1.Text = dr["Phone1"].ToString();
					txtPhone2.Text = dr["Phone2"].ToString();
					txtMobile1.Text = dr["PhoneMobile1"].ToString();
					txtMobile2.Text = dr["PhoneMobile2"].ToString();
					txtPhone3.Text = dr["PhoneBusiness1"].ToString();
					txtPhone4.Text = dr["PhoneBusiness2"].ToString();
					txtFax1.Text = dr["PhoneFax1"].ToString();
					txtFax2.Text = dr["PhoneFax2"].ToString();
					txtPhoneOther.Text = dr["PhoneOther"].ToString();
					txtUrl.Text = dr["url"].ToString();

					if(dr["DateBirth"]!=System.DBNull.Value)
						dtDOB.Value = Convert.ToDateTime(dr["DateBirth"].ToString());
					else
						dtDOB.Checked=false;

					if(dr["DateJoined"]!=System.DBNull.Value)
						dtJoined.Value = Convert.ToDateTime(dr["DateJoined"].ToString());
					else
						dtJoined.Checked=false;

					if(dr["DateEnded"]!=System.DBNull.Value)
						dtEnded.Value = Convert.ToDateTime(dr["DateEnded"].ToString());
					else
						dtEnded.Checked=false;

					txtNationality.Text = dr["Nationality"].ToString();
					cmbMarried.SelectedIndex = Convert.ToInt16(dr["Married"].ToString());
					txtNoDependent.Text = dr["NumberDependents"].ToString();

					txtVisaStatus.Text = dr["VisaStatus"].ToString();

					if(dr["VisaFromDate"]!=System.DBNull.Value)
						dtVisaFrom.Value = Convert.ToDateTime(dr["VisaFromDate"].ToString());
					else
						dtVisaFrom.Checked=false;

					if(dr["VisaUntilDate"]!=System.DBNull.Value)
						dtVisaTo.Value = Convert.ToDateTime(dr["VisaUntilDate"].ToString());
					else
						dtVisaTo.Checked=false;

					txtMintSt1.Text = dr["MinutesToStation1"].ToString();
					txtClosestSt1.Text = dr["ClosestStation1"].ToString();
					txtClosestLine1.Text = dr["Closestline1"].ToString();
				
					txtMintSt2.Text = dr["MinutesToStation2"].ToString();
					txtClosestSt2.Text = dr["ClosestStation2"].ToString();
					txtClosestLine2.Text = dr["Closestline2"].ToString();

					cmbEmpStatus.Text = dr["TimeStatus"].ToString();
					cmbStatus.SelectedIndex = Convert.ToInt16(dr["ContactStatus"].ToString());
                    spinBaseRate.Text = dr["BasePayField"].ToString();
				}
			}
			else
			{
				this.Text = "Adding Instructor...";

				txtLName.Text = String.Empty;
				txtLNamePhonetic.Text = String.Empty;
				txtLNameRomaji.Text = String.Empty;
				txtFName.Text = String.Empty;
				txtFNamePhonetic.Text = String.Empty;
				txtFNameRomaji.Text = String.Empty;

				txtCompName.Text = String.Empty;
				txtCompPhonetic.Text = String.Empty;
				txtCompRomaji.Text = String.Empty;

				cmbTitle.Text = String.Empty;
				txtTitleJob.Text = String.Empty;

				cmbBlock.Text = String.Empty;

				txtStreet1.Text = String.Empty;
				txtStreet2.Text = String.Empty;
				txtStreet3.Text = String.Empty;
				txtCity.Text = String.Empty;
				txtState.Text = String.Empty;
				txtPost.Text = String.Empty;
				txtCountry.Text = String.Empty;

				txtEmail1.Text = String.Empty;
				txtEmail2.Text = String.Empty;

				txtPhone1.Text = String.Empty;
				txtPhone2.Text = String.Empty;
				txtMobile1.Text = String.Empty;
				txtMobile2.Text = String.Empty;
				txtPhone3.Text = String.Empty;
				txtPhone4.Text = String.Empty;
				txtFax1.Text = String.Empty;
				txtFax2.Text = String.Empty;
				txtPhoneOther.Text = String.Empty;
				txtUrl.Text = String.Empty;

				dtDOB.Checked = false;

				dtJoined.Checked = false;

				dtEnded.Checked = false;

				txtNationality.Text = String.Empty;
				cmbMarried.SelectedIndex = 0;
				txtNoDependent.Text = String.Empty;

				txtVisaStatus.Text = String.Empty;

				dtVisaFrom.Checked = false;

				dtVisaTo.Checked = false;

				txtMintSt1.Text = String.Empty;
				txtClosestSt1.Text = String.Empty;
				txtClosestLine1.Text = String.Empty;

				txtMintSt2.Text = String.Empty;
				txtClosestSt2.Text = String.Empty;
				txtClosestLine2.Text = String.Empty;

				cmbEmpStatus.Text = String.Empty;
				cmbStatus.SelectedIndex = 0;

			}
		}

		private void frmTeacherDlg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtNoDependent_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			Common.MaskInteger(e);
		}

		private void txtNoDependent_Leave(object sender, System.EventArgs e)
		{
			if(txtNoDependent.Text=="")
			{
				txtNoDependent.Text="0";
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(BusinessLayer.Message.MsgDelete())
			{
				Scheduler.BusinessLayer.Contact objContact=new Scheduler.BusinessLayer.Contact();
				objContact.ContactID = _contactid;
				if(!objContact.DeleteData())
				{
					BusinessLayer.Message.MsgWarning("Teacher cannot be deleted");
					return;
				}
				else
				{
					deleted=true;
					btnDelete.Enabled=false;
					this.Text = "Adding Instructor...";
					_mode="Add";
					_contactid=0;

					foreach(Control c in tbpContact.Controls)
					{
						if(c.GetType().ToString() == "System.Windows.Forms.TextBox")
						{
							if(c.Tag==null) c.Text="";
							else if(c.Tag.ToString()=="N") c.Text="0";
						}
						if(c.GetType().ToString() == "System.Windows.Forms.LinkLabel")
						{
							c.Text="None";
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
					foreach(Control c in tbpPersonal.Controls)
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
			if(_mode=="Edit")
			{
				if(cmbStatus.SelectedIndex==1)
				{
					Common.MakeReadOnly(tbpContact, false);
					Common.MakeReadOnly(tbpPersonal, false);
					cmbStatus.Enabled=true;
				}
				else
				{
					Common.MakeEnabled(tbpContact, false);
					Common.MakeEnabled(tbpPersonal, false);
				}
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			//Create a Panel and clip all other panels to this panel
			Panel pnl=new Panel();
			pnl.Tag = "Instructor Information";
            pnl.Font = new Font("Arial", 8F, GraphicsUnit.Point);
			pnl.Width = tbcUser.Width;
			pnl.Height = tbcUser.Height*3+20;

			pnl.Controls.Add(pnlAddress);
			pnl.Controls.Add(pnlPersonal);
			pnlPersonal.Dock = DockStyle.Top;
			pnlAddress.Dock = DockStyle.Fill;

			CreateFormPrintingObject(pnl);
			//PrintingFunctions.SetProperties(ref fp, ps);
            PrintingFunctions.SetProperties(ref xfp);

			// Print!
			//fp.Print();
            xfp.Print();
			tbpPersonal.Controls.Add(pnlPersonal);
			tbpContact.Controls.Add(pnlAddress);
            pnlPersonal.Dock = DockStyle.Fill;

			pnl.Dispose();
			pnl=null;
		}



		private FormPrinting fp=null;
        private clsDevExpressFormPrinting xfp= null;
		private void CreateFormPrintingObject(System.Windows.Forms.Control c)
		{
			fp = new FormPrinting(c);
            xfp = new clsDevExpressFormPrinting(c,printingSystem1);
		}


		private PageSettings ps=null;
		private void btnPageSetup_Click(object sender, System.EventArgs e)
		{
			//PrintingFunctions.ShowPageSettings(ref ps);
            //fp.PrintingSystem.PageSetup();
            printingSystem1.PageSetup();
		}

        private void spinBaseRate_Leave(object sender, EventArgs e)
        {
            if (spinBaseRate.Text == "")
            {
                spinBaseRate.Text = "0";
            }
        }

        private void spinBaseRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.MaskInteger(e);
        }
	}
}
