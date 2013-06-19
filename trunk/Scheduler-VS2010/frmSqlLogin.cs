using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;
using Scheduler.BusinessLayer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmSqlLogin.
	/// </summary>
	public class frmSqlLogin : System.Windows.Forms.Form
    {
        #region Declarations
        internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.RadioButton rbtnSQLAuth;
		internal System.Windows.Forms.RadioButton rbtnWindowsAuth;
		internal System.Windows.Forms.TextBox txtPwd;
		internal System.Windows.Forms.TextBox txtLogin;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label lblConnection;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.Label lblServer;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Button btnLogin;
		internal System.Windows.Forms.Label label3;
        #endregion
        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSqlLogin()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSqlLogin));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnSQLAuth = new System.Windows.Forms.RadioButton();
            this.rbtnWindowsAuth = new System.Windows.Forms.RadioButton();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.GroupBox1.Location = new System.Drawing.Point(11, 321);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(403, 2);
            this.GroupBox1.TabIndex = 82;
            this.GroupBox1.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.PeachPuff;
            this.GroupBox2.Location = new System.Drawing.Point(123, 165);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(280, 3);
            this.GroupBox2.TabIndex = 81;
            this.GroupBox2.TabStop = false;
            // 
            // rbtnSQLAuth
            // 
            this.rbtnSQLAuth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnSQLAuth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtnSQLAuth.Location = new System.Drawing.Point(45, 214);
            this.rbtnSQLAuth.Name = "rbtnSQLAuth";
            this.rbtnSQLAuth.Size = new System.Drawing.Size(257, 19);
            this.rbtnSQLAuth.TabIndex = 3;
            this.rbtnSQLAuth.Text = "Use SQL Server Authentication";
            this.rbtnSQLAuth.CheckedChanged += new System.EventHandler(this.rbtnSQLAuth_CheckedChanged);
            // 
            // rbtnWindowsAuth
            // 
            this.rbtnWindowsAuth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnWindowsAuth.Checked = true;
            this.rbtnWindowsAuth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtnWindowsAuth.Location = new System.Drawing.Point(45, 185);
            this.rbtnWindowsAuth.Name = "rbtnWindowsAuth";
            this.rbtnWindowsAuth.Size = new System.Drawing.Size(257, 19);
            this.rbtnWindowsAuth.TabIndex = 2;
            this.rbtnWindowsAuth.TabStop = true;
            this.rbtnWindowsAuth.Text = "Use Windows Authentication";
            this.rbtnWindowsAuth.CheckedChanged += new System.EventHandler(this.rbtnWindowsAuth_CheckedChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Enabled = false;
            this.txtPwd.Location = new System.Drawing.Point(146, 282);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(257, 24);
            this.txtPwd.TabIndex = 5;
            // 
            // txtLogin
            // 
            this.txtLogin.Enabled = false;
            this.txtLogin.Location = new System.Drawing.Point(146, 253);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(257, 24);
            this.txtLogin.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(45, 282);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(66, 17);
            this.Label2.TabIndex = 77;
            this.Label2.Text = "Password";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(45, 155);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(78, 17);
            this.lblConnection.TabIndex = 79;
            this.lblConnection.Text = "Connection";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(45, 253);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(80, 17);
            this.Label6.TabIndex = 78;
            this.Label6.Text = "Login Name";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(45, 117);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 17);
            this.Label1.TabIndex = 76;
            this.Label1.Text = "Database";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(146, 114);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(257, 24);
            this.TextBox2.TabIndex = 1;
            this.TextBox2.Text = "SchedulerDB";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(45, 84);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(48, 17);
            this.lblServer.TabIndex = 75;
            this.lblServer.Text = "Server";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(146, 81);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(257, 24);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "(local)";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(225, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Location = new System.Drawing.Point(108, 344);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 28);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "&Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 24);
            this.label3.TabIndex = 85;
            this.label3.Text = "SQL Server configuration...";
            // 
            // frmSqlLogin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 395);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.rbtnSQLAuth);
            this.Controls.Add(this.rbtnWindowsAuth);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLogin);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSqlLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Connection...";
            this.Load += new System.EventHandler(this.frmSqlLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSqlLogin_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private string strServer="";
		private string strDatabase="";
		private string strconnstring="";
		public bool Success;

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			Success=false;
			Application.Exit();
			//Close();
		}

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			strServer = TextBox1.Text;
			strDatabase = TextBox2.Text;

			if(rbtnWindowsAuth.Checked)
				strconnstring = "Server=" + strServer + ";" + 
					"Database=" + strDatabase + ";" + 
					"User ID=;Password=;Trusted_Connection=True;";
			else
				strconnstring = "Data Source=" + strServer + ";" + 
					"Initial Catalog=" + strDatabase + ";" + 
					"User ID=" + txtLogin.Text + ";Password=" + txtPwd.Text + ";Trusted_Connection=False;";

			SqlConnection cn =new SqlConnection(strconnstring);

			try
			{
				cn.Open();
			}
			catch(SqlException ex)
			{
				MessageBox.Show("Couldnot connect to SQLServer" + "\n\n" + ex.Message);
				Success = false;
				return;
			}

			Common.SqlServer = strServer;
			Common.ConnString = strconnstring;
			Common.ConnString1 = strconnstring;

			Common.WriteToRegistry(Registry.CurrentUser, "Scheduler", "SqlServer", strServer);
			Common.WriteToRegistry(Registry.CurrentUser, "Scheduler", "SqlDatabase", strDatabase);
			if(rbtnSQLAuth.Checked)
				Common.WriteToRegistry(Registry.CurrentUser, "Scheduler", "TrustedConnection", "No");
			else
				Common.WriteToRegistry(Registry.CurrentUser, "Scheduler", "TrustedConnection", "Yes");
			Common.WriteToRegistry(Registry.CurrentUser, "Scheduler", "User", txtLogin.Text);
			Common.WriteToRegistry(Registry.CurrentUser, "Scheduler", "Pwd", txtPwd.Text);
            DAC.ConnectionString = strconnstring;
			Success = true;
		}

		private void rbtnWindowsAuth_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbtnWindowsAuth.Checked)
			{
				txtLogin.Enabled = false;
				txtPwd.Enabled = false;
			}
			else
			{
				txtLogin.Enabled = true;
				txtPwd.Enabled = true;
				txtLogin.Focus();
			}
		}

		private void rbtnSQLAuth_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbtnWindowsAuth.Checked)
			{
				txtLogin.Enabled = false;
				txtPwd.Enabled = false;
			}
			else
			{
				txtLogin.Enabled = true;
				txtPwd.Enabled = true;
			}
		}

		private void frmSqlLogin_Load(object sender, System.EventArgs e)
		{
			this.ActiveControl = TextBox1;

			try
			{
				Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();

			string strTrustedConnection="";
			string strUser ="";
			string strPwd ="";

			strServer = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "SqlServer");
			strDatabase = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "SqlDatabase");
			strTrustedConnection = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "TrustedConnection");
			strUser = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "User");
			strPwd = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "Pwd");

			if(strServer!="")
			{
				TextBox1.Text = strServer;
				TextBox2.Text = strDatabase;

				if(strTrustedConnection == "No")
				{
					rbtnSQLAuth.Checked = true;
					txtLogin.Text = strUser;
					txtPwd.Text = strPwd;
				}
				else
				{
					rbtnWindowsAuth.Checked = true;
				}
			}
		}

		private void frmSqlLogin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

	}
}
