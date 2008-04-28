using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;


namespace Scheduler
{
	public class frm_NavBarProperties : Form
	{
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_Ok;
		private System.ComponentModel.IContainer components = null;
		
		public Byte bytBackColorA;
		public Byte bytBackColorR;
		public Byte bytBackColorG;
		public Byte bytBackColorB;
		public Byte bytTextColorA;
		public Byte bytTextColorR;
		public Byte bytTextColorG;
		public Byte bytTextColorB;
		private System.Windows.Forms.Label lbl_Styles;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFont;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.LinkLabel linkLabel1;
		public System.Windows.Forms.ComboBox cbStyles;

		public frm_NavBarProperties(DevExpress.XtraNavBar.NavBarControl NavBar, System.Windows.Forms.ComboBox cmb_Temp)
		{
			InitializeComponent();
			cbStyles.Items.AddRange(NavBar.AvailableNavBarViews.ToArray(typeof(object)) as object[]);
				cbStyles.SelectedIndex = IndexOf(cbStyles.Items, NavBar.View.ToString());

			//for (int i = 0; i < cmb_Temp.Items.Count; i++)
			//{
			//	cmb_Items.Items.Add(cmb_Temp.Items[i].ToString());
			//}

			//cmb_Items.Text = cmb_Temp.Text;

			bytBackColorA = NavBar.Groups[0].AppearanceBackground.BackColor.A;
			bytBackColorR = NavBar.Groups[0].AppearanceBackground.BackColor.R;

			bytBackColorG = NavBar.Groups[0].AppearanceBackground.BackColor.G;
			bytBackColorB = NavBar.Groups[0].AppearanceBackground.BackColor.B;
			bytTextColorA = NavBar.Groups[0].ItemLinks[0].Item.Appearance.ForeColor.A;
			bytTextColorR = NavBar.Groups[0].ItemLinks[0].Item.Appearance.ForeColor.R;
			bytTextColorG = NavBar.Groups[0].ItemLinks[0].Item.Appearance.ForeColor.G;
			bytTextColorB = NavBar.Groups[0].ItemLinks[0].Item.Appearance.ForeColor.B;

			//cmb_TextColor.EditValue = Color.FromArgb(bytTextColorA, bytTextColorR, bytTextColorG, bytTextColorB);
			//cmb_BackColor.EditValue = Color.FromArgb(bytBackColorA, bytBackColorR, bytBackColorG, bytBackColorB);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frm_NavBarProperties));
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Ok = new System.Windows.Forms.Button();
			this.cbStyles = new System.Windows.Forms.ComboBox();
			this.lbl_Styles = new System.Windows.Forms.Label();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFont = new System.Windows.Forms.TextBox();
			this.btnFont = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_Cancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Cancel.Location = new System.Drawing.Point(292, 86);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(72, 21);
			this.btn_Cancel.TabIndex = 6;
			this.btn_Cancel.Text = "&Cancel";
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Ok
			// 
			this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_Ok.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn_Ok.Location = new System.Drawing.Point(214, 86);
			this.btn_Ok.Name = "btn_Ok";
			this.btn_Ok.Size = new System.Drawing.Size(72, 21);
			this.btn_Ok.TabIndex = 5;
			this.btn_Ok.Text = "&OK";
			this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
			// 
			// cbStyles
			// 
			this.cbStyles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStyles.Location = new System.Drawing.Point(130, 19);
			this.cbStyles.MaxDropDownItems = 15;
			this.cbStyles.Name = "cbStyles";
			this.cbStyles.Size = new System.Drawing.Size(235, 21);
			this.cbStyles.TabIndex = 0;
			// 
			// lbl_Styles
			// 
			this.lbl_Styles.AutoSize = true;
			this.lbl_Styles.Location = new System.Drawing.Point(16, 21);
			this.lbl_Styles.Name = "lbl_Styles";
			this.lbl_Styles.Size = new System.Drawing.Size(105, 17);
			this.lbl_Styles.TabIndex = 0;
			this.lbl_Styles.Text = "Navigation Bar Style";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "Application Font";
			// 
			// txtFont
			// 
			this.txtFont.Location = new System.Drawing.Point(130, 50);
			this.txtFont.Name = "txtFont";
			this.txtFont.ReadOnly = true;
			this.txtFont.Size = new System.Drawing.Size(214, 21);
			this.txtFont.TabIndex = 3;
			this.txtFont.Text = "Tahoma, 8.25pt";
			// 
			// btnFont
			// 
			this.btnFont.Location = new System.Drawing.Point(341, 49);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(24, 23);
			this.btnFont.TabIndex = 4;
			this.btnFont.Text = "...";
			this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(16, 88);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(100, 16);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Set Default Font";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// frm_NavBarProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(378, 120);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.btnFont);
			this.Controls.Add(this.txtFont);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbl_Styles);
			this.Controls.Add(this.cbStyles);
			this.Controls.Add(this.btn_Cancel);
			this.Controls.Add(this.btn_Ok);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_NavBarProperties";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Properties";
			this.Load += new System.EventHandler(this.frm_NavBarProperties_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private int IndexOf(ComboBox.ObjectCollection objCollection, string s) 
		{
			for(int i = 0; i < objCollection.Count; i++)
				if(objCollection[i].ToString() == s) return i;
			return -1;
		}

		private void btn_Ok_Click(object sender, System.EventArgs e)
		{
			//bytBackColorA = cmb_BackColor.Color.A;
			//bytBackColorR = cmb_BackColor.Color.R;
			//bytBackColorG = cmb_BackColor.Color.G;
			//bytBackColorB = cmb_BackColor.Color.B;

			//bytTextColorA = cmb_TextColor.Color.A;
			//bytTextColorR = cmb_TextColor.Color.R;
			//bytTextColorG = cmb_TextColor.Color.G;
			//bytTextColorB = cmb_TextColor.Color.B;

			string font = txtFont.Text;
			if(font.Trim()!="")
			{
				font=font.Replace("pt","");
				font=font.Trim();

				string[] arr = font.Split(new char[]{','});
				if(arr.Length==2)
				{
					BusinessLayer.Common.FontName = arr[0].Trim();
					BusinessLayer.Common.FontSize = (float)Convert.ToDouble(arr[1].Trim());
				}

				DataTable dtbl=new DataTable();
				dtbl.Columns.Add("FontName", Type.GetType("System.String"));
				dtbl.Columns.Add("FontSize", Type.GetType("System.Double"));
			
				dtbl.Rows.Add(new object[]{BusinessLayer.Common.FontName,
											  BusinessLayer.Common.FontSize});
				DataSet ds=new DataSet("Settings");
				ds.Tables.Add(dtbl);
				ds.WriteXml(Application.StartupPath + "\\scheduler.config", XmlWriteMode.WriteSchema);
			}

			DialogResult = DialogResult.OK;
		}

		private void btn_Cancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void cmb_Items_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnFont_Click(object sender, System.EventArgs e)
		{
			if(fontDialog1.ShowDialog()==DialogResult.OK)
			{
				txtFont.Text = fontDialog1.Font.Name + ", " + fontDialog1.Font.Size.ToString() + "pt";
			}
		}

		private void frm_NavBarProperties_Load(object sender, System.EventArgs e)
		{
			if(BusinessLayer.Common.FontName.Trim()!="")
			{
				txtFont.Text = BusinessLayer.Common.FontName + ", " + BusinessLayer.Common.FontSize.ToString() + "pt";
			}
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			txtFont.Text="";
			if(System.IO.File.Exists(Application.StartupPath + "\\scheduler.config"))
			{
				System.IO.File.Delete(Application.StartupPath + "\\scheduler.config");
				BusinessLayer.Message.MsgInformation("Default Font will take effect on next Logon");
			}
		}

	}
}

