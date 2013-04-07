using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Scheduler.BusinessLayer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmContactDlg.
	/// </summary>
	public class frmContactDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tbcContact;
		private System.Windows.Forms.TabPage tbpPersonal;
		private System.Windows.Forms.TabPage tbpOther;
		private System.Windows.Forms.Label lblLNameRomaji;
		private System.Windows.Forms.Label lblLNamePhonetic;
		private System.Windows.Forms.Label lblLName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.TabPage tbpLocation;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.TextBox txtTitleJob;
		private System.Windows.Forms.TextBox txtCompRomaji;
		private System.Windows.Forms.TextBox txtCompPhonetic;
		private System.Windows.Forms.TextBox txtCompName;
		private System.Windows.Forms.TextBox txtFNameRomaji;
		private System.Windows.Forms.TextBox txtFNamePhonetic;
		private System.Windows.Forms.TextBox txtFName;
		private System.Windows.Forms.TextBox txtLNameRomaji;
		private System.Windows.Forms.TextBox txtLNamePhonetic;
		private System.Windows.Forms.TextBox txtLName;
		private System.Windows.Forms.TextBox txtContactRomaji2;
		private System.Windows.Forms.TextBox txtContactPhonetic2;
		private System.Windows.Forms.TextBox txtContactName2;
		private System.Windows.Forms.TextBox txtContactRomaji1;
		private System.Windows.Forms.TextBox txtContactPhonetic1;
		private System.Windows.Forms.TextBox txtContactName1;
		private System.Windows.Forms.TextBox txtAccFirstName;
		private System.Windows.Forms.TextBox txtAccLPhonetic;
		private System.Windows.Forms.TextBox txtAccLName;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.TextBox txtFax2;
		private System.Windows.Forms.TextBox txtFax1;
		private System.Windows.Forms.Label lblMarried;
		private System.Windows.Forms.ComboBox cmbMarried;
		private System.Windows.Forms.TextBox txtNoDependent;
		private System.Windows.Forms.TextBox txtVisaStatus;
		private System.Windows.Forms.TextBox txtPhone4;
		private System.Windows.Forms.TextBox txtPhone3;
		private System.Windows.Forms.TextBox txtMobile2;
		private System.Windows.Forms.TextBox txtMobile1;
		private System.Windows.Forms.TextBox txtPhone2;
		private System.Windows.Forms.TextBox txtPhone1;
		private System.Windows.Forms.TextBox txtEmail2;
		private System.Windows.Forms.TextBox txtEmail1;
		private System.Windows.Forms.ComboBox cmbBlock;
		private System.Windows.Forms.TextBox txtCountry;
		private System.Windows.Forms.TextBox txtPost;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.TextBox txtStreet3;
		private System.Windows.Forms.TextBox txtStreet2;
		private System.Windows.Forms.TextBox txtStreet1;
		private System.Windows.Forms.TextBox txtMintSt1;
		private System.Windows.Forms.TextBox txtClosestLine1;
		private System.Windows.Forms.TextBox txtClosestSt1;
		private System.Windows.Forms.TextBox txtMintSt2;
		private System.Windows.Forms.TextBox txtClosestLine2;
		private System.Windows.Forms.TextBox txtClosestSt2;
		private System.Windows.Forms.DateTimePicker dtDOB;
		private System.Windows.Forms.DateTimePicker dtJoined;
		private System.Windows.Forms.DateTimePicker dtEnded;
		private System.Windows.Forms.DateTimePicker dtVisaFrom;
		private System.Windows.Forms.DateTimePicker dtVisaTo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.TextBox txtAccLRomaji1;
		private System.Windows.Forms.TextBox txtAccFirstRomaji;
		private System.Windows.Forms.TextBox txtAccFirstPhonetic;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox txtPhoneOther;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.TextBox txtNationality;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.ComboBox cmbStatus;
		
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox cmbTitle;

		private string _mode="";
		private string _contacttype="";
		private Label label28;
		private int _contactid=0;

		public frmContactDlg()
		{
			InitializeComponent();
		}
		public frmContactDlg(string contacttype)
		{
			InitializeComponent();
			if(contacttype!="")
			{
				_contacttype=contacttype;
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactDlg));
			this.tbcContact = new System.Windows.Forms.TabControl();
			this.tbpPersonal = new System.Windows.Forms.TabPage();
			this.cmbTitle = new System.Windows.Forms.ComboBox();
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
			this.label17 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtContactRomaji2 = new System.Windows.Forms.TextBox();
			this.txtContactPhonetic2 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtContactName2 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtContactRomaji1 = new System.Windows.Forms.TextBox();
			this.txtContactPhonetic1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtContactName1 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTitleJob = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
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
			this.tbpOther = new System.Windows.Forms.TabPage();
			this.label28 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.txtNationality = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.txtPhoneOther = new System.Windows.Forms.TextBox();
			this.dtVisaTo = new System.Windows.Forms.DateTimePicker();
			this.dtVisaFrom = new System.Windows.Forms.DateTimePicker();
			this.dtEnded = new System.Windows.Forms.DateTimePicker();
			this.dtJoined = new System.Windows.Forms.DateTimePicker();
			this.dtDOB = new System.Windows.Forms.DateTimePicker();
			this.label63 = new System.Windows.Forms.Label();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
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
			this.label23 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label45 = new System.Windows.Forms.Label();
			this.txtVisaStatus = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.txtNoDependent = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.lblMarried = new System.Windows.Forms.Label();
			this.cmbMarried = new System.Windows.Forms.ComboBox();
			this.label42 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.txtFax2 = new System.Windows.Forms.TextBox();
			this.txtFax1 = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.tbpLocation = new System.Windows.Forms.TabPage();
			this.label59 = new System.Windows.Forms.Label();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.txtMintSt2 = new System.Windows.Forms.TextBox();
			this.txtClosestLine2 = new System.Windows.Forms.TextBox();
			this.label60 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.txtClosestSt2 = new System.Windows.Forms.TextBox();
			this.label62 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.txtMintSt1 = new System.Windows.Forms.TextBox();
			this.txtClosestLine1 = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.txtClosestSt1 = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.tbcContact.SuspendLayout();
			this.tbpPersonal.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tbpOther.SuspendLayout();
			this.tbpLocation.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbcContact
			// 
			this.tbcContact.Controls.Add(this.tbpPersonal);
			this.tbcContact.Controls.Add(this.tbpOther);
			this.tbcContact.Controls.Add(this.tbpLocation);
			this.tbcContact.Location = new System.Drawing.Point(0, 0);
			this.tbcContact.Name = "tbcContact";
			this.tbcContact.SelectedIndex = 0;
			this.tbcContact.Size = new System.Drawing.Size(696, 470);
			this.tbcContact.TabIndex = 80;
			// 
			// tbpPersonal
			// 
			this.tbpPersonal.Controls.Add(this.cmbTitle);
			this.tbpPersonal.Controls.Add(this.label48);
			this.tbpPersonal.Controls.Add(this.groupBox9);
			this.tbpPersonal.Controls.Add(this.txtAccFirstRomaji);
			this.tbpPersonal.Controls.Add(this.txtAccFirstPhonetic);
			this.tbpPersonal.Controls.Add(this.label49);
			this.tbpPersonal.Controls.Add(this.label50);
			this.tbpPersonal.Controls.Add(this.txtAccFirstName);
			this.tbpPersonal.Controls.Add(this.label51);
			this.tbpPersonal.Controls.Add(this.txtAccLRomaji1);
			this.tbpPersonal.Controls.Add(this.txtAccLPhonetic);
			this.tbpPersonal.Controls.Add(this.label52);
			this.tbpPersonal.Controls.Add(this.label53);
			this.tbpPersonal.Controls.Add(this.txtAccLName);
			this.tbpPersonal.Controls.Add(this.label54);
			this.tbpPersonal.Controls.Add(this.label17);
			this.tbpPersonal.Controls.Add(this.groupBox5);
			this.tbpPersonal.Controls.Add(this.label14);
			this.tbpPersonal.Controls.Add(this.txtContactRomaji2);
			this.tbpPersonal.Controls.Add(this.txtContactPhonetic2);
			this.tbpPersonal.Controls.Add(this.label15);
			this.tbpPersonal.Controls.Add(this.txtContactName2);
			this.tbpPersonal.Controls.Add(this.label16);
			this.tbpPersonal.Controls.Add(this.label8);
			this.tbpPersonal.Controls.Add(this.label7);
			this.tbpPersonal.Controls.Add(this.groupBox2);
			this.tbpPersonal.Controls.Add(this.txtContactRomaji1);
			this.tbpPersonal.Controls.Add(this.txtContactPhonetic1);
			this.tbpPersonal.Controls.Add(this.label9);
			this.tbpPersonal.Controls.Add(this.txtContactName1);
			this.tbpPersonal.Controls.Add(this.label10);
			this.tbpPersonal.Controls.Add(this.txtTitleJob);
			this.tbpPersonal.Controls.Add(this.label21);
			this.tbpPersonal.Controls.Add(this.label22);
			this.tbpPersonal.Controls.Add(this.label19);
			this.tbpPersonal.Controls.Add(this.cmbType);
			this.tbpPersonal.Controls.Add(this.label18);
			this.tbpPersonal.Controls.Add(this.groupBox6);
			this.tbpPersonal.Controls.Add(this.label12);
			this.tbpPersonal.Controls.Add(this.groupBox4);
			this.tbpPersonal.Controls.Add(this.label13);
			this.tbpPersonal.Controls.Add(this.groupBox1);
			this.tbpPersonal.Controls.Add(this.txtCompRomaji);
			this.tbpPersonal.Controls.Add(this.txtCompPhonetic);
			this.tbpPersonal.Controls.Add(this.label4);
			this.tbpPersonal.Controls.Add(this.label5);
			this.tbpPersonal.Controls.Add(this.txtCompName);
			this.tbpPersonal.Controls.Add(this.label6);
			this.tbpPersonal.Controls.Add(this.txtFNameRomaji);
			this.tbpPersonal.Controls.Add(this.txtFNamePhonetic);
			this.tbpPersonal.Controls.Add(this.label1);
			this.tbpPersonal.Controls.Add(this.label2);
			this.tbpPersonal.Controls.Add(this.txtFName);
			this.tbpPersonal.Controls.Add(this.label3);
			this.tbpPersonal.Controls.Add(this.txtLNameRomaji);
			this.tbpPersonal.Controls.Add(this.txtLNamePhonetic);
			this.tbpPersonal.Controls.Add(this.lblLNameRomaji);
			this.tbpPersonal.Controls.Add(this.lblLNamePhonetic);
			this.tbpPersonal.Controls.Add(this.txtLName);
			this.tbpPersonal.Controls.Add(this.lblLName);
			this.tbpPersonal.Location = new System.Drawing.Point(4, 22);
			this.tbpPersonal.Name = "tbpPersonal";
			this.tbpPersonal.Size = new System.Drawing.Size(688, 444);
			this.tbpPersonal.TabIndex = 0;
			this.tbpPersonal.Text = "Personal";
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
			this.cmbTitle.Location = new System.Drawing.Point(136, 260);
			this.cmbTitle.Name = "cmbTitle";
			this.cmbTitle.Size = new System.Drawing.Size(184, 21);
			this.cmbTitle.TabIndex = 153;
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label48.Location = new System.Drawing.Point(364, 241);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(84, 13);
			this.label48.TabIndex = 152;
			this.label48.Text = "Accounts Rep";
			// 
			// groupBox9
			// 
			this.groupBox9.Location = new System.Drawing.Point(352, 248);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(312, 3);
			this.groupBox9.TabIndex = 151;
			this.groupBox9.TabStop = false;
			// 
			// txtAccFirstRomaji
			// 
			this.txtAccFirstRomaji.Location = new System.Drawing.Point(472, 392);
			this.txtAccFirstRomaji.MaxLength = 255;
			this.txtAccFirstRomaji.Name = "txtAccFirstRomaji";
			this.txtAccFirstRomaji.Size = new System.Drawing.Size(184, 21);
			this.txtAccFirstRomaji.TabIndex = 23;
			// 
			// txtAccFirstPhonetic
			// 
			this.txtAccFirstPhonetic.Location = new System.Drawing.Point(472, 368);
			this.txtAccFirstPhonetic.MaxLength = 255;
			this.txtAccFirstPhonetic.Name = "txtAccFirstPhonetic";
			this.txtAccFirstPhonetic.Size = new System.Drawing.Size(184, 21);
			this.txtAccFirstPhonetic.TabIndex = 22;
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label49.Location = new System.Drawing.Point(352, 394);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(93, 13);
			this.label49.TabIndex = 148;
			this.label49.Text = "First Name Romaji";
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label50.Location = new System.Drawing.Point(352, 370);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(102, 13);
			this.label50.TabIndex = 147;
			this.label50.Text = "First Name Phonetic";
			// 
			// txtAccFirstName
			// 
			this.txtAccFirstName.Location = new System.Drawing.Point(472, 344);
			this.txtAccFirstName.MaxLength = 255;
			this.txtAccFirstName.Name = "txtAccFirstName";
			this.txtAccFirstName.Size = new System.Drawing.Size(184, 21);
			this.txtAccFirstName.TabIndex = 21;
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label51.Location = new System.Drawing.Point(352, 346);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(58, 13);
			this.label51.TabIndex = 146;
			this.label51.Text = "First Name";
			// 
			// txtAccLRomaji1
			// 
			this.txtAccLRomaji1.Location = new System.Drawing.Point(472, 312);
			this.txtAccLRomaji1.MaxLength = 255;
			this.txtAccLRomaji1.Name = "txtAccLRomaji1";
			this.txtAccLRomaji1.Size = new System.Drawing.Size(184, 21);
			this.txtAccLRomaji1.TabIndex = 20;
			// 
			// txtAccLPhonetic
			// 
			this.txtAccLPhonetic.Location = new System.Drawing.Point(472, 288);
			this.txtAccLPhonetic.MaxLength = 255;
			this.txtAccLPhonetic.Name = "txtAccLPhonetic";
			this.txtAccLPhonetic.Size = new System.Drawing.Size(184, 21);
			this.txtAccLPhonetic.TabIndex = 19;
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label52.Location = new System.Drawing.Point(352, 314);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(92, 13);
			this.label52.TabIndex = 142;
			this.label52.Text = "Last Name Romaji";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label53.Location = new System.Drawing.Point(352, 290);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(101, 13);
			this.label53.TabIndex = 141;
			this.label53.Text = "Last Name Phonetic";
			// 
			// txtAccLName
			// 
			this.txtAccLName.Location = new System.Drawing.Point(472, 264);
			this.txtAccLName.MaxLength = 255;
			this.txtAccLName.Name = "txtAccLName";
			this.txtAccLName.Size = new System.Drawing.Size(184, 21);
			this.txtAccLName.TabIndex = 18;
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label54.Location = new System.Drawing.Point(352, 266);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(57, 13);
			this.label54.TabIndex = 140;
			this.label54.Text = "Last Name";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label17.Location = new System.Drawing.Point(364, 137);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(69, 13);
			this.label17.TabIndex = 138;
			this.label17.Text = "Contact - 2";
			// 
			// groupBox5
			// 
			this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox5.Location = new System.Drawing.Point(352, 144);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(312, 3);
			this.groupBox5.TabIndex = 137;
			this.groupBox5.TabStop = false;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label14.Location = new System.Drawing.Point(360, 210);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(69, 13);
			this.label14.TabIndex = 136;
			this.label14.Text = "Name Romaji";
			// 
			// txtContactRomaji2
			// 
			this.txtContactRomaji2.Location = new System.Drawing.Point(472, 208);
			this.txtContactRomaji2.MaxLength = 255;
			this.txtContactRomaji2.Name = "txtContactRomaji2";
			this.txtContactRomaji2.Size = new System.Drawing.Size(184, 21);
			this.txtContactRomaji2.TabIndex = 17;
			// 
			// txtContactPhonetic2
			// 
			this.txtContactPhonetic2.Location = new System.Drawing.Point(472, 184);
			this.txtContactPhonetic2.MaxLength = 255;
			this.txtContactPhonetic2.Name = "txtContactPhonetic2";
			this.txtContactPhonetic2.Size = new System.Drawing.Size(184, 21);
			this.txtContactPhonetic2.TabIndex = 16;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label15.Location = new System.Drawing.Point(360, 186);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(78, 13);
			this.label15.TabIndex = 133;
			this.label15.Text = "Name Phonetic";
			// 
			// txtContactName2
			// 
			this.txtContactName2.Location = new System.Drawing.Point(472, 160);
			this.txtContactName2.MaxLength = 255;
			this.txtContactName2.Name = "txtContactName2";
			this.txtContactName2.Size = new System.Drawing.Size(184, 21);
			this.txtContactName2.TabIndex = 15;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label16.Location = new System.Drawing.Point(360, 162);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(34, 13);
			this.label16.TabIndex = 132;
			this.label16.Text = "Name";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.Location = new System.Drawing.Point(360, 98);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 13);
			this.label8.TabIndex = 130;
			this.label8.Text = "Name Romaji";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label7.Location = new System.Drawing.Point(364, 17);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 13);
			this.label7.TabIndex = 129;
			this.label7.Text = "Contact - 1";
			// 
			// groupBox2
			// 
			this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(352, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(312, 3);
			this.groupBox2.TabIndex = 128;
			this.groupBox2.TabStop = false;
			// 
			// txtContactRomaji1
			// 
			this.txtContactRomaji1.Location = new System.Drawing.Point(472, 96);
			this.txtContactRomaji1.MaxLength = 255;
			this.txtContactRomaji1.Name = "txtContactRomaji1";
			this.txtContactRomaji1.Size = new System.Drawing.Size(184, 21);
			this.txtContactRomaji1.TabIndex = 14;
			// 
			// txtContactPhonetic1
			// 
			this.txtContactPhonetic1.Location = new System.Drawing.Point(472, 72);
			this.txtContactPhonetic1.MaxLength = 255;
			this.txtContactPhonetic1.Name = "txtContactPhonetic1";
			this.txtContactPhonetic1.Size = new System.Drawing.Size(184, 21);
			this.txtContactPhonetic1.TabIndex = 13;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label9.Location = new System.Drawing.Point(360, 74);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(78, 13);
			this.label9.TabIndex = 125;
			this.label9.Text = "Name Phonetic";
			// 
			// txtContactName1
			// 
			this.txtContactName1.Location = new System.Drawing.Point(472, 48);
			this.txtContactName1.MaxLength = 255;
			this.txtContactName1.Name = "txtContactName1";
			this.txtContactName1.Size = new System.Drawing.Size(184, 21);
			this.txtContactName1.TabIndex = 12;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label10.Location = new System.Drawing.Point(360, 50);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 13);
			this.label10.TabIndex = 124;
			this.label10.Text = "Name";
			// 
			// txtTitleJob
			// 
			this.txtTitleJob.Location = new System.Drawing.Point(136, 284);
			this.txtTitleJob.MaxLength = 255;
			this.txtTitleJob.Name = "txtTitleJob";
			this.txtTitleJob.Size = new System.Drawing.Size(184, 21);
			this.txtTitleJob.TabIndex = 8;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label21.Location = new System.Drawing.Point(16, 286);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(47, 13);
			this.label21.TabIndex = 97;
			this.label21.Text = "Title Job";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label22.Location = new System.Drawing.Point(16, 262);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(27, 13);
			this.label22.TabIndex = 96;
			this.label22.Text = "Title";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label19.Location = new System.Drawing.Point(16, 42);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(45, 13);
			this.label19.TabIndex = 94;
			this.label19.Text = "Contact";
			// 
			// cmbType
			// 
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.Items.AddRange(new object[] {
            "User",
            "Teacher",
            "Client",
            "Department"});
			this.cmbType.Location = new System.Drawing.Point(136, 40);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(184, 21);
			this.cmbType.TabIndex = 0;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label18.Location = new System.Drawing.Point(26, 17);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(35, 13);
			this.label18.TabIndex = 92;
			this.label18.Text = "Type";
			// 
			// groupBox6
			// 
			this.groupBox6.Location = new System.Drawing.Point(16, 24);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(312, 3);
			this.groupBox6.TabIndex = 91;
			this.groupBox6.TabStop = false;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label12.Location = new System.Drawing.Point(26, 65);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(51, 13);
			this.label12.TabIndex = 82;
			this.label12.Text = "Contact";
			// 
			// groupBox4
			// 
			this.groupBox4.Location = new System.Drawing.Point(16, 72);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(312, 3);
			this.groupBox4.TabIndex = 81;
			this.groupBox4.TabStop = false;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label13.Location = new System.Drawing.Point(26, 319);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 13);
			this.label13.TabIndex = 71;
			this.label13.Text = "Company";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Location = new System.Drawing.Point(16, 326);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 3);
			this.groupBox1.TabIndex = 70;
			this.groupBox1.TabStop = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label11.Location = new System.Drawing.Point(24, -56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(60, 13);
			this.label11.TabIndex = 73;
			this.label11.Text = "Company";
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(0, -48);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(312, 17);
			this.groupBox3.TabIndex = 72;
			this.groupBox3.TabStop = false;
			// 
			// txtCompRomaji
			// 
			this.txtCompRomaji.Location = new System.Drawing.Point(136, 392);
			this.txtCompRomaji.MaxLength = 255;
			this.txtCompRomaji.Name = "txtCompRomaji";
			this.txtCompRomaji.Size = new System.Drawing.Size(184, 21);
			this.txtCompRomaji.TabIndex = 11;
			// 
			// txtCompPhonetic
			// 
			this.txtCompPhonetic.Location = new System.Drawing.Point(136, 368);
			this.txtCompPhonetic.MaxLength = 255;
			this.txtCompPhonetic.Name = "txtCompPhonetic";
			this.txtCompPhonetic.Size = new System.Drawing.Size(184, 21);
			this.txtCompPhonetic.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(16, 394);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 13);
			this.label4.TabIndex = 56;
			this.label4.Text = "Name Romaji";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Location = new System.Drawing.Point(16, 370);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 13);
			this.label5.TabIndex = 55;
			this.label5.Text = "Name Phonetic";
			// 
			// txtCompName
			// 
			this.txtCompName.Location = new System.Drawing.Point(136, 344);
			this.txtCompName.MaxLength = 255;
			this.txtCompName.Name = "txtCompName";
			this.txtCompName.Size = new System.Drawing.Size(184, 21);
			this.txtCompName.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Location = new System.Drawing.Point(16, 346);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 54;
			this.label6.Text = "Name";
			// 
			// txtFNameRomaji
			// 
			this.txtFNameRomaji.Location = new System.Drawing.Point(136, 224);
			this.txtFNameRomaji.MaxLength = 255;
			this.txtFNameRomaji.Name = "txtFNameRomaji";
			this.txtFNameRomaji.Size = new System.Drawing.Size(184, 21);
			this.txtFNameRomaji.TabIndex = 6;
			// 
			// txtFNamePhonetic
			// 
			this.txtFNamePhonetic.Location = new System.Drawing.Point(136, 200);
			this.txtFNamePhonetic.MaxLength = 255;
			this.txtFNamePhonetic.Name = "txtFNamePhonetic";
			this.txtFNamePhonetic.Size = new System.Drawing.Size(184, 21);
			this.txtFNamePhonetic.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(16, 226);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 50;
			this.label1.Text = "First Name Romaji";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Location = new System.Drawing.Point(16, 202);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 13);
			this.label2.TabIndex = 49;
			this.label2.Text = "First Name Phonetic";
			// 
			// txtFName
			// 
			this.txtFName.Location = new System.Drawing.Point(136, 176);
			this.txtFName.MaxLength = 255;
			this.txtFName.Name = "txtFName";
			this.txtFName.Size = new System.Drawing.Size(184, 21);
			this.txtFName.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Location = new System.Drawing.Point(16, 178);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 48;
			this.label3.Text = "First Name";
			// 
			// txtLNameRomaji
			// 
			this.txtLNameRomaji.Location = new System.Drawing.Point(136, 136);
			this.txtLNameRomaji.MaxLength = 255;
			this.txtLNameRomaji.Name = "txtLNameRomaji";
			this.txtLNameRomaji.Size = new System.Drawing.Size(184, 21);
			this.txtLNameRomaji.TabIndex = 3;
			// 
			// txtLNamePhonetic
			// 
			this.txtLNamePhonetic.Location = new System.Drawing.Point(136, 112);
			this.txtLNamePhonetic.MaxLength = 255;
			this.txtLNamePhonetic.Name = "txtLNamePhonetic";
			this.txtLNamePhonetic.Size = new System.Drawing.Size(184, 21);
			this.txtLNamePhonetic.TabIndex = 2;
			// 
			// lblLNameRomaji
			// 
			this.lblLNameRomaji.AutoSize = true;
			this.lblLNameRomaji.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblLNameRomaji.Location = new System.Drawing.Point(16, 138);
			this.lblLNameRomaji.Name = "lblLNameRomaji";
			this.lblLNameRomaji.Size = new System.Drawing.Size(92, 13);
			this.lblLNameRomaji.TabIndex = 44;
			this.lblLNameRomaji.Text = "Last Name Romaji";
			// 
			// lblLNamePhonetic
			// 
			this.lblLNamePhonetic.AutoSize = true;
			this.lblLNamePhonetic.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblLNamePhonetic.Location = new System.Drawing.Point(16, 114);
			this.lblLNamePhonetic.Name = "lblLNamePhonetic";
			this.lblLNamePhonetic.Size = new System.Drawing.Size(101, 13);
			this.lblLNamePhonetic.TabIndex = 43;
			this.lblLNamePhonetic.Text = "Last Name Phonetic";
			// 
			// txtLName
			// 
			this.txtLName.Location = new System.Drawing.Point(136, 88);
			this.txtLName.MaxLength = 255;
			this.txtLName.Name = "txtLName";
			this.txtLName.Size = new System.Drawing.Size(184, 21);
			this.txtLName.TabIndex = 1;
			// 
			// lblLName
			// 
			this.lblLName.AutoSize = true;
			this.lblLName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblLName.Location = new System.Drawing.Point(16, 90);
			this.lblLName.Name = "lblLName";
			this.lblLName.Size = new System.Drawing.Size(57, 13);
			this.lblLName.TabIndex = 42;
			this.lblLName.Text = "Last Name";
			// 
			// tbpOther
			// 
			this.tbpOther.Controls.Add(this.label28);
			this.tbpOther.Controls.Add(this.label20);
			this.tbpOther.Controls.Add(this.label65);
			this.tbpOther.Controls.Add(this.cmbStatus);
			this.tbpOther.Controls.Add(this.txtNationality);
			this.tbpOther.Controls.Add(this.label64);
			this.tbpOther.Controls.Add(this.label43);
			this.tbpOther.Controls.Add(this.txtPhoneOther);
			this.tbpOther.Controls.Add(this.dtVisaTo);
			this.tbpOther.Controls.Add(this.dtVisaFrom);
			this.tbpOther.Controls.Add(this.dtEnded);
			this.tbpOther.Controls.Add(this.dtJoined);
			this.tbpOther.Controls.Add(this.dtDOB);
			this.tbpOther.Controls.Add(this.label63);
			this.tbpOther.Controls.Add(this.groupBox12);
			this.tbpOther.Controls.Add(this.label33);
			this.tbpOther.Controls.Add(this.txtPhone4);
			this.tbpOther.Controls.Add(this.txtPhone3);
			this.tbpOther.Controls.Add(this.label37);
			this.tbpOther.Controls.Add(this.txtMobile2);
			this.tbpOther.Controls.Add(this.label34);
			this.tbpOther.Controls.Add(this.txtMobile1);
			this.tbpOther.Controls.Add(this.label35);
			this.tbpOther.Controls.Add(this.txtPhone2);
			this.tbpOther.Controls.Add(this.txtPhone1);
			this.tbpOther.Controls.Add(this.label32);
			this.tbpOther.Controls.Add(this.txtEmail2);
			this.tbpOther.Controls.Add(this.label31);
			this.tbpOther.Controls.Add(this.txtEmail1);
			this.tbpOther.Controls.Add(this.label30);
			this.tbpOther.Controls.Add(this.label29);
			this.tbpOther.Controls.Add(this.cmbBlock);
			this.tbpOther.Controls.Add(this.txtCountry);
			this.tbpOther.Controls.Add(this.label27);
			this.tbpOther.Controls.Add(this.txtPost);
			this.tbpOther.Controls.Add(this.txtState);
			this.tbpOther.Controls.Add(this.label26);
			this.tbpOther.Controls.Add(this.txtCity);
			this.tbpOther.Controls.Add(this.label25);
			this.tbpOther.Controls.Add(this.txtStreet3);
			this.tbpOther.Controls.Add(this.txtStreet2);
			this.tbpOther.Controls.Add(this.txtStreet1);
			this.tbpOther.Controls.Add(this.label24);
			this.tbpOther.Controls.Add(this.label23);
			this.tbpOther.Controls.Add(this.groupBox8);
			this.tbpOther.Controls.Add(this.label45);
			this.tbpOther.Controls.Add(this.txtVisaStatus);
			this.tbpOther.Controls.Add(this.label46);
			this.tbpOther.Controls.Add(this.label47);
			this.tbpOther.Controls.Add(this.txtNoDependent);
			this.tbpOther.Controls.Add(this.label44);
			this.tbpOther.Controls.Add(this.lblMarried);
			this.tbpOther.Controls.Add(this.cmbMarried);
			this.tbpOther.Controls.Add(this.label42);
			this.tbpOther.Controls.Add(this.label36);
			this.tbpOther.Controls.Add(this.txtUrl);
			this.tbpOther.Controls.Add(this.label38);
			this.tbpOther.Controls.Add(this.label39);
			this.tbpOther.Controls.Add(this.label40);
			this.tbpOther.Controls.Add(this.txtFax2);
			this.tbpOther.Controls.Add(this.txtFax1);
			this.tbpOther.Controls.Add(this.label41);
			this.tbpOther.Location = new System.Drawing.Point(4, 22);
			this.tbpOther.Name = "tbpOther";
			this.tbpOther.Size = new System.Drawing.Size(688, 444);
			this.tbpOther.TabIndex = 1;
			this.tbpOther.Text = "Contact";
			// 
			// label28
			// 
			this.label28.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label28.Location = new System.Drawing.Point(202, 151);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(48, 27);
			this.label28.TabIndex = 196;
			this.label28.Text = "Postal\r\nCode";
			this.label28.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label20.Location = new System.Drawing.Point(24, 338);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(90, 13);
			this.label20.TabIndex = 195;
			this.label20.Text = "Business Phone 2";
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label65.Location = new System.Drawing.Point(368, 410);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(38, 13);
			this.label65.TabIndex = 194;
			this.label65.Text = "Status";
			// 
			// cmbStatus
			// 
			this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
			this.cmbStatus.Location = new System.Drawing.Point(496, 408);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(144, 21);
			this.cmbStatus.TabIndex = 29;
			// 
			// txtNationality
			// 
			this.txtNationality.Location = new System.Drawing.Point(496, 232);
			this.txtNationality.MaxLength = 255;
			this.txtNationality.Name = "txtNationality";
			this.txtNationality.Size = new System.Drawing.Size(144, 21);
			this.txtNationality.TabIndex = 23;
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label64.Location = new System.Drawing.Point(368, 234);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(58, 13);
			this.label64.TabIndex = 192;
			this.label64.Text = "Nationality";
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label43.Location = new System.Drawing.Point(24, 362);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(68, 13);
			this.label43.TabIndex = 190;
			this.label43.Text = "Phone Other";
			// 
			// txtPhoneOther
			// 
			this.txtPhoneOther.Location = new System.Drawing.Point(120, 360);
			this.txtPhoneOther.MaxLength = 255;
			this.txtPhoneOther.Name = "txtPhoneOther";
			this.txtPhoneOther.Size = new System.Drawing.Size(216, 21);
			this.txtPhoneOther.TabIndex = 14;
			// 
			// dtVisaTo
			// 
			this.dtVisaTo.CustomFormat = "MM/dd/yyyy";
			this.dtVisaTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtVisaTo.Location = new System.Drawing.Point(496, 368);
			this.dtVisaTo.Name = "dtVisaTo";
			this.dtVisaTo.ShowCheckBox = true;
			this.dtVisaTo.Size = new System.Drawing.Size(144, 21);
			this.dtVisaTo.TabIndex = 28;
			// 
			// dtVisaFrom
			// 
			this.dtVisaFrom.CustomFormat = "MM/dd/yyyy";
			this.dtVisaFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtVisaFrom.Location = new System.Drawing.Point(496, 344);
			this.dtVisaFrom.Name = "dtVisaFrom";
			this.dtVisaFrom.ShowCheckBox = true;
			this.dtVisaFrom.Size = new System.Drawing.Size(144, 21);
			this.dtVisaFrom.TabIndex = 27;
			// 
			// dtEnded
			// 
			this.dtEnded.CustomFormat = "MM/dd/yyyy";
			this.dtEnded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEnded.Location = new System.Drawing.Point(496, 188);
			this.dtEnded.Name = "dtEnded";
			this.dtEnded.ShowCheckBox = true;
			this.dtEnded.Size = new System.Drawing.Size(144, 21);
			this.dtEnded.TabIndex = 22;
			// 
			// dtJoined
			// 
			this.dtJoined.CustomFormat = "MM/dd/yyyy";
			this.dtJoined.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtJoined.Location = new System.Drawing.Point(496, 164);
			this.dtJoined.Name = "dtJoined";
			this.dtJoined.ShowCheckBox = true;
			this.dtJoined.Size = new System.Drawing.Size(144, 21);
			this.dtJoined.TabIndex = 21;
			// 
			// dtDOB
			// 
			this.dtDOB.CustomFormat = "MM/dd/yyyy";
			this.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtDOB.Location = new System.Drawing.Point(496, 140);
			this.dtDOB.Name = "dtDOB";
			this.dtDOB.ShowCheckBox = true;
			this.dtDOB.Size = new System.Drawing.Size(144, 21);
			this.dtDOB.TabIndex = 20;
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label63.Location = new System.Drawing.Point(368, 115);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(39, 13);
			this.label63.TabIndex = 188;
			this.label63.Text = "Other";
			// 
			// groupBox12
			// 
			this.groupBox12.Location = new System.Drawing.Point(352, 122);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(288, 2);
			this.groupBox12.TabIndex = 187;
			this.groupBox12.TabStop = false;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label33.Location = new System.Drawing.Point(24, 290);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(46, 13);
			this.label33.TabIndex = 186;
			this.label33.Text = "Phone 2";
			// 
			// txtPhone4
			// 
			this.txtPhone4.Location = new System.Drawing.Point(120, 336);
			this.txtPhone4.MaxLength = 255;
			this.txtPhone4.Name = "txtPhone4";
			this.txtPhone4.Size = new System.Drawing.Size(216, 21);
			this.txtPhone4.TabIndex = 13;
			// 
			// txtPhone3
			// 
			this.txtPhone3.Location = new System.Drawing.Point(120, 312);
			this.txtPhone3.MaxLength = 255;
			this.txtPhone3.Name = "txtPhone3";
			this.txtPhone3.Size = new System.Drawing.Size(216, 21);
			this.txtPhone3.TabIndex = 12;
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label37.Location = new System.Drawing.Point(24, 314);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(90, 13);
			this.label37.TabIndex = 184;
			this.label37.Text = "Business Phone 1";
			// 
			// txtMobile2
			// 
			this.txtMobile2.Location = new System.Drawing.Point(120, 408);
			this.txtMobile2.MaxLength = 255;
			this.txtMobile2.Name = "txtMobile2";
			this.txtMobile2.Size = new System.Drawing.Size(216, 21);
			this.txtMobile2.TabIndex = 16;
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label34.Location = new System.Drawing.Point(24, 410);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(46, 13);
			this.label34.TabIndex = 182;
			this.label34.Text = "Mobile 2";
			// 
			// txtMobile1
			// 
			this.txtMobile1.Location = new System.Drawing.Point(120, 384);
			this.txtMobile1.MaxLength = 255;
			this.txtMobile1.Name = "txtMobile1";
			this.txtMobile1.Size = new System.Drawing.Size(216, 21);
			this.txtMobile1.TabIndex = 15;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label35.Location = new System.Drawing.Point(24, 386);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(46, 13);
			this.label35.TabIndex = 180;
			this.label35.Text = "Mobile 1";
			// 
			// txtPhone2
			// 
			this.txtPhone2.Location = new System.Drawing.Point(120, 288);
			this.txtPhone2.MaxLength = 255;
			this.txtPhone2.Name = "txtPhone2";
			this.txtPhone2.Size = new System.Drawing.Size(216, 21);
			this.txtPhone2.TabIndex = 11;
			// 
			// txtPhone1
			// 
			this.txtPhone1.Location = new System.Drawing.Point(120, 264);
			this.txtPhone1.MaxLength = 255;
			this.txtPhone1.Name = "txtPhone1";
			this.txtPhone1.Size = new System.Drawing.Size(216, 21);
			this.txtPhone1.TabIndex = 10;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label32.Location = new System.Drawing.Point(24, 266);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(46, 13);
			this.label32.TabIndex = 177;
			this.label32.Text = "Phone 1";
			// 
			// txtEmail2
			// 
			this.txtEmail2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.txtEmail2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmail2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtEmail2.Location = new System.Drawing.Point(120, 232);
			this.txtEmail2.MaxLength = 255;
			this.txtEmail2.Name = "txtEmail2";
			this.txtEmail2.Size = new System.Drawing.Size(216, 21);
			this.txtEmail2.TabIndex = 9;
			this.txtEmail2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtEmail1_MouseDown);
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label31.Location = new System.Drawing.Point(24, 234);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(41, 13);
			this.label31.TabIndex = 175;
			this.label31.Text = "Email-2";
			// 
			// txtEmail1
			// 
			this.txtEmail1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.txtEmail1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmail1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtEmail1.Location = new System.Drawing.Point(120, 208);
			this.txtEmail1.MaxLength = 255;
			this.txtEmail1.Name = "txtEmail1";
			this.txtEmail1.Size = new System.Drawing.Size(216, 21);
			this.txtEmail1.TabIndex = 8;
			this.txtEmail1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtEmail1_MouseDown);
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label30.Location = new System.Drawing.Point(24, 210);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(41, 13);
			this.label30.TabIndex = 173;
			this.label30.Text = "Email-1";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label29.Location = new System.Drawing.Point(24, 34);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(31, 13);
			this.label29.TabIndex = 171;
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
			this.cmbBlock.Location = new System.Drawing.Point(120, 32);
			this.cmbBlock.Name = "cmbBlock";
			this.cmbBlock.Size = new System.Drawing.Size(72, 21);
			this.cmbBlock.TabIndex = 0;
			// 
			// txtCountry
			// 
			this.txtCountry.Location = new System.Drawing.Point(120, 181);
			this.txtCountry.MaxLength = 255;
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.Size = new System.Drawing.Size(216, 21);
			this.txtCountry.TabIndex = 7;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label27.Location = new System.Drawing.Point(24, 183);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(46, 13);
			this.label27.TabIndex = 168;
			this.label27.Text = "Country";
			// 
			// txtPost
			// 
			this.txtPost.Location = new System.Drawing.Point(256, 154);
			this.txtPost.MaxLength = 255;
			this.txtPost.Name = "txtPost";
			this.txtPost.Size = new System.Drawing.Size(80, 21);
			this.txtPost.TabIndex = 6;
			// 
			// txtState
			// 
			this.txtState.Location = new System.Drawing.Point(120, 154);
			this.txtState.MaxLength = 255;
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(80, 21);
			this.txtState.TabIndex = 5;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label26.Location = new System.Drawing.Point(24, 156);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(33, 13);
			this.label26.TabIndex = 164;
			this.label26.Text = "State";
			// 
			// txtCity
			// 
			this.txtCity.Location = new System.Drawing.Point(120, 128);
			this.txtCity.MaxLength = 255;
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(216, 21);
			this.txtCity.TabIndex = 4;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label25.Location = new System.Drawing.Point(24, 130);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(26, 13);
			this.label25.TabIndex = 162;
			this.label25.Text = "City";
			// 
			// txtStreet3
			// 
			this.txtStreet3.Location = new System.Drawing.Point(120, 104);
			this.txtStreet3.MaxLength = 255;
			this.txtStreet3.Name = "txtStreet3";
			this.txtStreet3.Size = new System.Drawing.Size(216, 21);
			this.txtStreet3.TabIndex = 3;
			// 
			// txtStreet2
			// 
			this.txtStreet2.Location = new System.Drawing.Point(120, 80);
			this.txtStreet2.MaxLength = 255;
			this.txtStreet2.Name = "txtStreet2";
			this.txtStreet2.Size = new System.Drawing.Size(216, 21);
			this.txtStreet2.TabIndex = 2;
			// 
			// txtStreet1
			// 
			this.txtStreet1.Location = new System.Drawing.Point(120, 56);
			this.txtStreet1.MaxLength = 255;
			this.txtStreet1.Name = "txtStreet1";
			this.txtStreet1.Size = new System.Drawing.Size(216, 21);
			this.txtStreet1.TabIndex = 1;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label24.Location = new System.Drawing.Point(24, 58);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(37, 13);
			this.label24.TabIndex = 158;
			this.label24.Text = "Street";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label23.Location = new System.Drawing.Point(24, 11);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(53, 13);
			this.label23.TabIndex = 157;
			this.label23.Text = "Address";
			// 
			// groupBox8
			// 
			this.groupBox8.Location = new System.Drawing.Point(16, 18);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(296, 3);
			this.groupBox8.TabIndex = 156;
			this.groupBox8.TabStop = false;
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label45.Location = new System.Drawing.Point(368, 370);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(76, 13);
			this.label45.TabIndex = 155;
			this.label45.Text = "Visa Until Date";
			// 
			// txtVisaStatus
			// 
			this.txtVisaStatus.Location = new System.Drawing.Point(496, 320);
			this.txtVisaStatus.MaxLength = 255;
			this.txtVisaStatus.Name = "txtVisaStatus";
			this.txtVisaStatus.Size = new System.Drawing.Size(144, 21);
			this.txtVisaStatus.TabIndex = 26;
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label46.Location = new System.Drawing.Point(368, 346);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(79, 13);
			this.label46.TabIndex = 153;
			this.label46.Text = "Visa From Date";
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label47.Location = new System.Drawing.Point(368, 322);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(60, 13);
			this.label47.TabIndex = 151;
			this.label47.Text = "Visa Status";
			// 
			// txtNoDependent
			// 
			this.txtNoDependent.Location = new System.Drawing.Point(496, 280);
			this.txtNoDependent.MaxLength = 255;
			this.txtNoDependent.Name = "txtNoDependent";
			this.txtNoDependent.Size = new System.Drawing.Size(80, 21);
			this.txtNoDependent.TabIndex = 25;
			this.txtNoDependent.Text = "0";
			this.txtNoDependent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNoDependent.Leave += new System.EventHandler(this.txtNoDependent_Leave);
			this.txtNoDependent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoDependent_KeyPress);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label44.Location = new System.Drawing.Point(368, 282);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(94, 13);
			this.label44.TabIndex = 148;
			this.label44.Text = "No of Dependents";
			// 
			// lblMarried
			// 
			this.lblMarried.AutoSize = true;
			this.lblMarried.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblMarried.Location = new System.Drawing.Point(368, 258);
			this.lblMarried.Name = "lblMarried";
			this.lblMarried.Size = new System.Drawing.Size(43, 13);
			this.lblMarried.TabIndex = 147;
			this.lblMarried.Text = "Married";
			// 
			// cmbMarried
			// 
			this.cmbMarried.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMarried.Items.AddRange(new object[] {
            "Yes",
            "No"});
			this.cmbMarried.Location = new System.Drawing.Point(496, 256);
			this.cmbMarried.Name = "cmbMarried";
			this.cmbMarried.Size = new System.Drawing.Size(80, 21);
			this.cmbMarried.TabIndex = 24;
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label42.Location = new System.Drawing.Point(368, 190);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(63, 13);
			this.label42.TabIndex = 145;
			this.label42.Text = "Date Ended";
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label36.Location = new System.Drawing.Point(368, 58);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(34, 13);
			this.label36.TabIndex = 144;
			this.label36.Text = "Fax 2";
			// 
			// txtUrl
			// 
			this.txtUrl.Cursor = System.Windows.Forms.Cursors.Hand;
			this.txtUrl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUrl.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txtUrl.Location = new System.Drawing.Point(496, 80);
			this.txtUrl.MaxLength = 255;
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(144, 21);
			this.txtUrl.TabIndex = 19;
			this.txtUrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtUrl_MouseDown);
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label38.Location = new System.Drawing.Point(368, 82);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(26, 13);
			this.label38.TabIndex = 142;
			this.label38.Text = "URL";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label39.Location = new System.Drawing.Point(368, 166);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(64, 13);
			this.label39.TabIndex = 140;
			this.label39.Text = "Date Joined";
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label40.Location = new System.Drawing.Point(368, 142);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(68, 13);
			this.label40.TabIndex = 138;
			this.label40.Text = "Date of Birth";
			// 
			// txtFax2
			// 
			this.txtFax2.Location = new System.Drawing.Point(496, 56);
			this.txtFax2.MaxLength = 255;
			this.txtFax2.Name = "txtFax2";
			this.txtFax2.Size = new System.Drawing.Size(144, 21);
			this.txtFax2.TabIndex = 18;
			// 
			// txtFax1
			// 
			this.txtFax1.Location = new System.Drawing.Point(496, 32);
			this.txtFax1.MaxLength = 255;
			this.txtFax1.Name = "txtFax1";
			this.txtFax1.Size = new System.Drawing.Size(144, 21);
			this.txtFax1.TabIndex = 17;
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label41.Location = new System.Drawing.Point(368, 34);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(34, 13);
			this.label41.TabIndex = 135;
			this.label41.Text = "Fax 1";
			// 
			// tbpLocation
			// 
			this.tbpLocation.Controls.Add(this.label59);
			this.tbpLocation.Controls.Add(this.groupBox11);
			this.tbpLocation.Controls.Add(this.txtMintSt2);
			this.tbpLocation.Controls.Add(this.txtClosestLine2);
			this.tbpLocation.Controls.Add(this.label60);
			this.tbpLocation.Controls.Add(this.label61);
			this.tbpLocation.Controls.Add(this.txtClosestSt2);
			this.tbpLocation.Controls.Add(this.label62);
			this.tbpLocation.Controls.Add(this.label58);
			this.tbpLocation.Controls.Add(this.groupBox10);
			this.tbpLocation.Controls.Add(this.txtMintSt1);
			this.tbpLocation.Controls.Add(this.txtClosestLine1);
			this.tbpLocation.Controls.Add(this.label55);
			this.tbpLocation.Controls.Add(this.label56);
			this.tbpLocation.Controls.Add(this.txtClosestSt1);
			this.tbpLocation.Controls.Add(this.label57);
			this.tbpLocation.Location = new System.Drawing.Point(4, 22);
			this.tbpLocation.Name = "tbpLocation";
			this.tbpLocation.Size = new System.Drawing.Size(688, 444);
			this.tbpLocation.TabIndex = 2;
			this.tbpLocation.Text = "Location";
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label59.Location = new System.Drawing.Point(40, 168);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(58, 13);
			this.label59.TabIndex = 167;
			this.label59.Text = "Station 2";
			// 
			// groupBox11
			// 
			this.groupBox11.Location = new System.Drawing.Point(24, 176);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(320, 3);
			this.groupBox11.TabIndex = 166;
			this.groupBox11.TabStop = false;
			// 
			// txtMintSt2
			// 
			this.txtMintSt2.Location = new System.Drawing.Point(160, 250);
			this.txtMintSt2.MaxLength = 255;
			this.txtMintSt2.Name = "txtMintSt2";
			this.txtMintSt2.Size = new System.Drawing.Size(64, 21);
			this.txtMintSt2.TabIndex = 5;
			this.txtMintSt2.Text = "0";
			this.txtMintSt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMintSt2.Leave += new System.EventHandler(this.txtNoDependent_Leave);
			this.txtMintSt2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoDependent_KeyPress);
			// 
			// txtClosestLine2
			// 
			this.txtClosestLine2.Location = new System.Drawing.Point(160, 226);
			this.txtClosestLine2.MaxLength = 255;
			this.txtClosestLine2.Name = "txtClosestLine2";
			this.txtClosestLine2.Size = new System.Drawing.Size(200, 21);
			this.txtClosestLine2.TabIndex = 4;
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label60.Location = new System.Drawing.Point(40, 252);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(94, 13);
			this.label60.TabIndex = 163;
			this.label60.Text = "Minutes to Station";
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label61.Location = new System.Drawing.Point(40, 228);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(64, 13);
			this.label61.TabIndex = 162;
			this.label61.Text = "Closest Line";
			// 
			// txtClosestSt2
			// 
			this.txtClosestSt2.Location = new System.Drawing.Point(160, 202);
			this.txtClosestSt2.MaxLength = 255;
			this.txtClosestSt2.Name = "txtClosestSt2";
			this.txtClosestSt2.Size = new System.Drawing.Size(200, 21);
			this.txtClosestSt2.TabIndex = 3;
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label62.Location = new System.Drawing.Point(40, 204);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(79, 13);
			this.label62.TabIndex = 161;
			this.label62.Text = "Closest Station";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.label58.Location = new System.Drawing.Point(40, 24);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(58, 13);
			this.label58.TabIndex = 159;
			this.label58.Text = "Station 1";
			// 
			// groupBox10
			// 
			this.groupBox10.Location = new System.Drawing.Point(24, 32);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(320, 3);
			this.groupBox10.TabIndex = 158;
			this.groupBox10.TabStop = false;
			// 
			// txtMintSt1
			// 
			this.txtMintSt1.Location = new System.Drawing.Point(160, 106);
			this.txtMintSt1.MaxLength = 255;
			this.txtMintSt1.Name = "txtMintSt1";
			this.txtMintSt1.Size = new System.Drawing.Size(64, 21);
			this.txtMintSt1.TabIndex = 2;
			this.txtMintSt1.Text = "0";
			this.txtMintSt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMintSt1.Leave += new System.EventHandler(this.txtNoDependent_Leave);
			this.txtMintSt1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoDependent_KeyPress);
			// 
			// txtClosestLine1
			// 
			this.txtClosestLine1.Location = new System.Drawing.Point(160, 82);
			this.txtClosestLine1.MaxLength = 255;
			this.txtClosestLine1.Name = "txtClosestLine1";
			this.txtClosestLine1.Size = new System.Drawing.Size(200, 21);
			this.txtClosestLine1.TabIndex = 1;
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label55.Location = new System.Drawing.Point(40, 108);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(94, 13);
			this.label55.TabIndex = 56;
			this.label55.Text = "Minutes to Station";
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label56.Location = new System.Drawing.Point(40, 84);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(64, 13);
			this.label56.TabIndex = 55;
			this.label56.Text = "Closest Line";
			// 
			// txtClosestSt1
			// 
			this.txtClosestSt1.Location = new System.Drawing.Point(160, 58);
			this.txtClosestSt1.MaxLength = 255;
			this.txtClosestSt1.Name = "txtClosestSt1";
			this.txtClosestSt1.Size = new System.Drawing.Size(200, 21);
			this.txtClosestSt1.TabIndex = 0;
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label57.Location = new System.Drawing.Point(40, 60);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(79, 13);
			this.label57.TabIndex = 54;
			this.label57.Text = "Closest Station";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(587, 480);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 82;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(507, 480);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 81;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmContactDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(682, 518);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.tbcContact);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmContactDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Adding Contact...";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContactDlg_KeyDown);
			this.Load += new System.EventHandler(this.frmContactDlg_Load);
			this.tbcContact.ResumeLayout(false);
			this.tbpPersonal.ResumeLayout(false);
			this.tbpPersonal.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tbpOther.ResumeLayout(false);
			this.tbpOther.PerformLayout();
			this.tbpLocation.ResumeLayout(false);
			this.tbpLocation.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

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

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;
			Close();
		}

		private void frmContactDlg_Load(object sender, System.EventArgs e)
		{
            if (Common.LogonType == 2)
            {
               // this.btnDelete.Enabled = false;
                this.btnSave.Enabled = false;
            }
			this.ActiveControl=cmbType;

			try
			{
				Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();


			if(_mode=="Edit")
			{
				this.Text = "Editing Contact...";
				
			}
			else
			{
				this.Text = "Adding Contact...";
				cmbType.SelectedIndex=0;
				cmbStatus.SelectedIndex=0;

				if(_contacttype!="")
				{
					cmbType.Text = _contacttype;
					cmbType.Enabled = false;
				}
			}
		}

		private string GetContactType(int ptype)
		{
			if(ptype==0)
				return "User";
			else if(ptype==1)
				return "Teacher";
			else if(ptype==2)
				return "Client";
			else if(ptype==3)
				return "Department";

			return "";
		}

		public void LoadData()
		{
			if(_mode=="Edit" || _mode=="AddClone")
			{
                if (_mode == "Edit")
                    this.Text = "Editing Course...";
                else
                    this.Text = "Adding Contact Clone...";
				
				Scheduler.BusinessLayer.Contact objContact=new Scheduler.BusinessLayer.Contact();
				objContact.ContactID = _contactid;
				objContact.LoadData("Contact");

				foreach(DataRow dr in objContact.dtblContacts.Rows)
				{
					cmbType.SelectedIndex = Convert.ToInt16(dr["ContactType"].ToString());
					
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

					txtContactName1.Text = dr["ContactlastName1"].ToString();
					txtContactPhonetic1.Text = dr["ContactlastNamePhonetic1"].ToString();
					txtContactRomaji1.Text = dr["ContactLastNameRomaji1"].ToString();
					txtContactName2.Text = dr["ContactLastName2"].ToString();
					txtContactPhonetic2.Text = dr["ContactLastNamePhonetic2"].ToString();
					txtContactRomaji2.Text = dr["ContactLastNameRomaji2"].ToString();

					txtAccLName.Text = dr["AccountRepLastName"].ToString();
					txtAccLPhonetic.Text = dr["AccountRepLastNamePhonetic"].ToString();
					txtAccLRomaji1.Text = dr["AccountRepLastNameRomaji"].ToString();
					txtAccFirstName.Text = dr["AccountRepFirstName"].ToString();
					txtAccFirstPhonetic.Text = dr["AccountRepFirstNamePhonetic"].ToString();
					txtAccFirstRomaji.Text = dr["AccountRepFirstNameRomaji"].ToString();

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

					cmbStatus.SelectedIndex = Convert.ToInt16(dr["ContactStatus"].ToString());
				}
			}
			else
			{
				this.Text = "Adding Contact...";
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(txtLName.Text=="")
			{
				Scheduler.BusinessLayer.Message.MsgInformation("Enter Last Name");
				txtLName.Focus();
				return;
			}
			if(txtFName.Text=="")
			{
				Scheduler.BusinessLayer.Message.MsgInformation("Enter First Name");
				txtFName.Focus();
				return;
			}
			
			bool boolSuccess;
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
			objContact.ContactType=cmbType.SelectedIndex;
			objContact.BlockCode=cmbBlock.Text;
			objContact.Email1=txtEmail1.Text;
			objContact.Email2=txtEmail2.Text;
			objContact.AccountRepLastName=txtAccLName.Text;
			objContact.AccountRepLastNamePhonetic=txtAccLPhonetic.Text;
			objContact.AccountRepLastNameRomaji=txtAccLRomaji1.Text;
			objContact.AccountRepFirstName=txtAccFirstName.Text;
			objContact.AccountRepFirstNamePhonetic=txtAccFirstPhonetic.Text;
			objContact.AccountRepFirstNameRomaji=txtAccFirstRomaji.Text;
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
			
			//objContact.TimeStatus=.Text;
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

            if ((_mode == "Add") || (_mode == "AddClone") || (_mode == ""))
			{
				if(objContact.Exists())
				{
					Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Contact Name not allowed");
					txtLName.Focus();
					return;
				}
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

		private void txtNoDependent_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			BusinessLayer.Common.MaskInteger(e);
		}

		private void txtNoDependent_Leave(object sender, System.EventArgs e)
		{
			TextBox tb = (TextBox)sender;
			if(tb.Text.Trim()=="")
			{
				tb.Text="0";
			}
		}

		private void frmContactDlg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtEmail1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TextBox tb=(TextBox)sender;
			if(tb.Text!="")
			{
				if(e.Clicks==2)
				{
					System.Diagnostics.Process.Start("mailto:" + tb.Text);
				}
			}
		}

		private void txtUrl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TextBox tb=(TextBox)sender;
			if(tb.Text!="")
			{
				if(e.Clicks==2)
				{
					System.Diagnostics.Process.Start(tb.Text);
				}
			}
		}

	}
}
