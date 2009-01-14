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
	/// Summary description for frmClientDeptContactDlg.
	/// </summary>
	public class frmClientDeptContactDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ComboBox cmbStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFNameRomaji;
		private System.Windows.Forms.TextBox txtFNamePhonetic;
		private System.Windows.Forms.TextBox txtFName;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.TextBox txtMobile;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtLNameRomaji;
		private System.Windows.Forms.TextBox txtLNamePhonetic;
		private System.Windows.Forms.TextBox txtLName;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string _modeparental="";
		private string _mode="";
		private int _id=0;
		private int _refid=0;
        private TextBox txtFax;
        private Label label4;//deptid for Department & clientid for Client
		private string _contacttype="";
		
		public string ModeParental
		{
			get{return _modeparental;}
			set{_modeparental=value;}
		}
		public string Mode
		{
			get{return _mode;}
			set{_mode=value;}
		}
		public int ID
		{
			get{return _id;}
			set{_id=value;}
		}
		public int RefID
		{
			get{return _refid;}
			set{_refid=value;}
		}
		public string ContactType
		{
			get{return _contacttype;}
			set{_contacttype=value;}
		}

		public frmClientDeptContactDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientDeptContactDlg));
            this.label8 = new System.Windows.Forms.Label();
            this.txtFNameRomaji = new System.Windows.Forms.TextBox();
            this.txtFNamePhonetic = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLNameRomaji = new System.Windows.Forms.TextBox();
            this.txtLNamePhonetic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(16, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "First Name Romaji";
            // 
            // txtFNameRomaji
            // 
            this.txtFNameRomaji.Location = new System.Drawing.Point(129, 64);
            this.txtFNameRomaji.MaxLength = 255;
            this.txtFNameRomaji.Name = "txtFNameRomaji";
            this.txtFNameRomaji.Size = new System.Drawing.Size(200, 21);
            this.txtFNameRomaji.TabIndex = 5;
            // 
            // txtFNamePhonetic
            // 
            this.txtFNamePhonetic.Location = new System.Drawing.Point(129, 40);
            this.txtFNamePhonetic.MaxLength = 255;
            this.txtFNamePhonetic.Name = "txtFNamePhonetic";
            this.txtFNamePhonetic.Size = new System.Drawing.Size(200, 21);
            this.txtFNamePhonetic.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Location = new System.Drawing.Point(16, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "First Name Phonetic";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(129, 16);
            this.txtFName.MaxLength = 255;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(200, 21);
            this.txtFName.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Location = new System.Drawing.Point(16, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "First Name";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(129, 208);
            this.txtPhone.MaxLength = 255;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 21);
            this.txtPhone.TabIndex = 15;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label37.Location = new System.Drawing.Point(16, 210);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(81, 13);
            this.label37.TabIndex = 14;
            this.label37.Text = "Business Phone";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(129, 232);
            this.txtMobile.MaxLength = 255;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(200, 21);
            this.txtMobile.TabIndex = 17;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label35.Location = new System.Drawing.Point(16, 234);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(37, 13);
            this.label35.TabIndex = 16;
            this.label35.Text = "Mobile";
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtEmail.Location = new System.Drawing.Point(129, 184);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 21);
            this.txtEmail.TabIndex = 13;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label30.Location = new System.Drawing.Point(16, 186);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(31, 13);
            this.label30.TabIndex = 12;
            this.label30.Text = "Email";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(16, 285);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(129, 283);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbStatus.TabIndex = 21;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(16, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Last Name Romaji";
            // 
            // txtLNameRomaji
            // 
            this.txtLNameRomaji.Location = new System.Drawing.Point(129, 144);
            this.txtLNameRomaji.MaxLength = 255;
            this.txtLNameRomaji.Name = "txtLNameRomaji";
            this.txtLNameRomaji.Size = new System.Drawing.Size(200, 21);
            this.txtLNameRomaji.TabIndex = 11;
            // 
            // txtLNamePhonetic
            // 
            this.txtLNamePhonetic.Location = new System.Drawing.Point(129, 120);
            this.txtLNamePhonetic.MaxLength = 255;
            this.txtLNamePhonetic.Name = "txtLNamePhonetic";
            this.txtLNamePhonetic.Size = new System.Drawing.Size(200, 21);
            this.txtLNamePhonetic.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(16, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last Name Phonetic";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(129, 96);
            this.txtLName.MaxLength = 255;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(200, 21);
            this.txtLName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(16, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Name";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(252, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(172, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(129, 257);
            this.txtFax.MaxLength = 255;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(200, 21);
            this.txtFax.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(16, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fax";
            // 
            // frmClientDeptContactDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(352, 355);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLNameRomaji);
            this.Controls.Add(this.txtLNamePhonetic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFNameRomaji);
            this.Controls.Add(this.txtFNamePhonetic);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cmbStatus);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientDeptContactDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact";
            this.Load += new System.EventHandler(this.frmClientDeptContactDlg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientDeptContactDlg_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//if(txtFName.Text=="")
			//{
			//	BusinessLayer.Message.MsgInformation("Enter Contact First Name");
			//	txtFName.Focus();
			//	return;
			//}
			if(txtLName.Text=="")
			{
				BusinessLayer.Message.MsgInformation("Enter Contact Last Name");
				txtLName.Focus();
				return;
			}
			if(cmbStatus.SelectedIndex==-1)
			{
				BusinessLayer.Message.MsgInformation("Enter Contact Status");
				cmbStatus.Focus();
				return;
			}

			
			bool boolSuccess=false;
			Scheduler.BusinessLayer.Contact objContact=null;
			
			objContact=new Scheduler.BusinessLayer.Contact();
			objContact.ContactID=0;
			if(ContactType=="DepartmentContact")
				objContact.ContactType=5;
			else
				objContact.ContactType=4;

			if(_mode=="Edit")
			{
				if((txtFName.Text!=txtFName.Tag.ToString()) || (txtLName.Text!=txtLName.Tag.ToString()))
				{
					if(objContact.ContactExists(_refid, txtFName.Text, txtLName.Text))
					{
						Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Contact Name not allowed");
						txtFName.Focus();
						return;
					}
				}
			}
			else
			{
				if(objContact.ContactExists(_refid, txtFName.Text, txtLName.Text))
				{
					Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Contact Name not allowed");
					txtFName.Focus();
					return;
				}
			}
			
			objContact.LastName = txtLName.Text;
			objContact.LastNamePhonetic=txtLNamePhonetic.Text;
			objContact.LastNameRomaji=txtLNameRomaji.Text;
			objContact.FirstName=txtFName.Text;
			objContact.FirstNamePhonetic=txtFNamePhonetic.Text;
			objContact.FirstNameRomaji=txtFNameRomaji.Text;
			objContact.CompanyName="";
			objContact.CompanyNamePhonetic="";
			objContact.CompanyNameRomaji="";
			objContact.TitleForName="";
			objContact.TitleForJob="";
			objContact.Street1="";
			objContact.Street2="";
			objContact.Street3="";
			objContact.City="";
			objContact.State="";
			objContact.PostalCode="";
			objContact.Country="";
			objContact.BlockCode="";
			objContact.Email1=txtEmail.Text;
			objContact.Email2="";
			objContact.AccountRepLastName="";
			objContact.AccountRepLastNamePhonetic="";
			objContact.AccountRepLastNameRomaji="";
			objContact.AccountRepFirstName="";
			objContact.AccountRepFirstNamePhonetic="";
			objContact.AccountRepFirstNameRomaji="";
			objContact.Phone1=txtPhone.Text;
			objContact.Phone2="";
			objContact.PhoneMobile1=txtMobile.Text;
			objContact.PhoneMobile2="";
			objContact.PhoneBusiness1="";
			objContact.PhoneBusiness2="";
			objContact.PhoneFax1=txtFax.Text;
			objContact.PhoneFax2="";
			objContact.PhoneOther="";
			objContact.Url="";

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

			objContact.ClosestStation1="";
			objContact.ClosestLine1="";
			objContact.MinutesToStation1=0;
			objContact.ClosestStation2="";
			objContact.ClosestLine2="";
			objContact.MinutesToStation2=0;
			objContact.ContactStatus=cmbStatus.SelectedIndex;

			objContact.RefID=_refid;

			if((_mode=="Add") || (_mode==""))
			{
				/*if(chkNoDept.Checked==false)
				{
					if(objContact.Exists(txtCompName.Text, intCID, 3))
					{
						Scheduler.BusinessLayer.Message.MsgInformation("Duplicate Department Name not allowed");
						txtCompName.Focus();
						return;
					}
				}*/
				boolSuccess = objContact.InsertData();
			}
			else
			{
				/*if(chkNoDept.Checked==false)
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
				}*/
				objContact.ContactID=_id;
				boolSuccess = objContact.UpdateData();
			}
			if(!boolSuccess)
			{
				if(_mode=="Add")
					Scheduler.BusinessLayer.Message.ShowException("Adding Contact record.", objContact.Message);
				else
					Scheduler.BusinessLayer.Message.ShowException("Updating Contact record.", objContact.Message);
				return;
			}

			Close();
			this.DialogResult=DialogResult.OK;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
			this.DialogResult=DialogResult.Cancel;
		}

		private void LoadData()
		{
			BusinessLayer.Contact objContact=new BusinessLayer.Contact();
			objContact.ContactID=_id;
			objContact.RefID=0;
			DataTable dtbl = objContact.LoadData(_contacttype);
			foreach(DataRow dr in dtbl.Rows)
			{
				txtFName.Text = dr["FirstName"].ToString();
				txtFNamePhonetic.Text = dr["FirstNamePhonetic"].ToString();
				txtFNameRomaji.Text = dr["FirstNameRomaji"].ToString();

				txtLName.Text = dr["LastName"].ToString();
				txtLNamePhonetic.Text = dr["LastNamePhonetic"].ToString();
				txtLNameRomaji.Text = dr["LastNameRomaji"].ToString();
                txtFax.Text = dr["PhoneFax1"].ToString();
				txtFName.Tag = txtFName.Text;
				txtLName.Tag = txtLName.Text;

				txtEmail.Text = dr["Email1"].ToString();
				txtPhone.Text = dr["Phone1"].ToString();
				txtMobile.Text = dr["PhoneMobile1"].ToString();

				if(dr["ContactStatus"]==null)cmbStatus.SelectedIndex=0;
				cmbStatus.SelectedIndex = Convert.ToInt16(dr["ContactStatus"].ToString());

				break;
			}
		}

		private void frmClientDeptContactDlg_Load(object sender, System.EventArgs e)
		{
			try
			{
				Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();

			if(_mode=="Add") 
			{
				cmbStatus.SelectedIndex=0;
				return;
			}
			LoadData();
		}

		private void frmClientDeptContactDlg_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void cmbStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(_mode=="Edit")
			{
				if(cmbStatus.SelectedIndex==1)
				{
					BusinessLayer.Common.MakeReadOnly(this, false);

					cmbStatus.Enabled=true;
					btnCancel.Enabled=true;
				}
				else
				{
					BusinessLayer.Common.MakeEnabled(this, false);
				}
			}

		}
	}
}
