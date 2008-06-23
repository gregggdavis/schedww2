using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Scheduler.BusinessLayer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmErrorDlg.
	/// </summary>
	public class frm_ErrorDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnDetails;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblOperation;
		private System.Windows.Forms.Label lblError;
		private System.Windows.Forms.PictureBox pbxErrorInfo;
		private System.Windows.Forms.RichTextBox redError;
		private System.ComponentModel.IContainer components;

		public frm_ErrorDlg(string strOperation, string strErrorMessage)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			lblOperation.Text = Scheduler.BusinessLayer.Common.DoubleAmpersand(strOperation);
			redError.Text = strErrorMessage;
			redError.Visible = false;
			this.Height = 158;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frm_ErrorDlg));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnDetails = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pbxErrorInfo = new System.Windows.Forms.PictureBox();
			this.lblOperation = new System.Windows.Forms.Label();
			this.lblError = new System.Windows.Forms.Label();
			this.redError = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(240, 96);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "&OK";
			// 
			// btnDetails
			// 
			this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDetails.Location = new System.Drawing.Point(328, 96);
			this.btnDetails.Name = "btnDetails";
			this.btnDetails.Size = new System.Drawing.Size(80, 23);
			this.btnDetails.TabIndex = 4;
			this.btnDetails.Text = "Show Details";
			this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pbxErrorInfo);
			this.groupBox1.Controls.Add(this.lblOperation);
			this.groupBox1.Controls.Add(this.lblError);
			this.groupBox1.Location = new System.Drawing.Point(13, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(397, 82);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// pbxErrorInfo
			// 
			this.pbxErrorInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbxErrorInfo.Image")));
			this.pbxErrorInfo.Location = new System.Drawing.Point(16, 21);
			this.pbxErrorInfo.Name = "pbxErrorInfo";
			this.pbxErrorInfo.Size = new System.Drawing.Size(32, 32);
			this.pbxErrorInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbxErrorInfo.TabIndex = 5;
			this.pbxErrorInfo.TabStop = false;
			// 
			// lblOperation
			// 
			this.lblOperation.AutoSize = true;
			this.lblOperation.Location = new System.Drawing.Point(65, 49);
			this.lblOperation.Name = "lblOperation";
			this.lblOperation.Size = new System.Drawing.Size(53, 17);
			this.lblOperation.TabIndex = 4;
			this.lblOperation.Text = "Operation";
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			this.lblError.Location = new System.Drawing.Point(65, 21);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(320, 17);
			this.lblError.TabIndex = 3;
			this.lblError.Text = "An Error has occured while performing the following operation:";
			// 
			// redError
			// 
			this.redError.Location = new System.Drawing.Point(13, 128);
			this.redError.Name = "redError";
			this.redError.ReadOnly = true;
			this.redError.Size = new System.Drawing.Size(395, 200);
			this.redError.TabIndex = 6;
			this.redError.Text = "";
			// 
			// frm_ErrorDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(424, 342);
			this.Controls.Add(this.redError);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnDetails);
			this.Controls.Add(this.btnOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_ErrorDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Scheduler";
			this.Load += new System.EventHandler(this.frm_ErrorDlg_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnDetails_Click(object sender, System.EventArgs e)
		{
			if (btnDetails.Text == "Show Details")
			{
				this.Height = 374;
				redError.Visible = true;
				btnDetails.Text = "Hide Details";
			}
			else
			{
				redError.Visible = false;
				this.Height = 158;
				btnDetails.Text = "Show Details";
			}

		}

		private void frm_ErrorDlg_Load(object sender, System.EventArgs e)
		{
			try
			{
				//Common.SetControlFont(this);
			}
			catch{}
			this.Refresh();
		}

	}
}
