using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmDeptBrw.
	/// </summary>
	public class frmDeptBrw : System.Windows.Forms.Form
	{
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
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		public System.Windows.Forms.Panel pnlBody;
		internal System.Windows.Forms.Panel pnl_SpeedSearch;
		internal System.Windows.Forms.Panel pnl_SpeedSearch1;
		internal System.Windows.Forms.TextBox txt_SpeedSearch;
		internal System.Windows.Forms.Label label1;
		internal DevExpress.XtraGrid.GridControl grdDept;
		public DevExpress.XtraGrid.Views.Grid.GridView gvwDept;
        public DevExpress.XtraGrid.Columns.GridColumn gColDeptID;
        private IContainer components;

		private Scheduler.BusinessLayer.Department objDepartment=null;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContact;
		private DevExpress.XtraGrid.Columns.GridColumn gcolClient;
		private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;
		private DataTable dtbl;
		public DevExpress.XtraGrid.Columns.GridColumn gColContactID;
		private DevExpress.XtraGrid.Columns.GridColumn gColContact1;
		private DevExpress.XtraGrid.Columns.GridColumn gcolContact2;
		public DevExpress.XtraGrid.Columns.GridColumn gColDeptName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolContact1Phone;
        private DevExpress.XtraGrid.Columns.GridColumn gcolContact2Phone;
		private bool boolFetch=true;

		public frmDeptBrw()
		{
			InitializeComponent();
			pnl_Find.Height = 0;
			pnl_Find.Visible=true;

			try
			{
				BusinessLayer.Common.SetControlFont(pnl_Find);				
				BusinessLayer.Common.SetGridFont(grdDept);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeptBrw));
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
            this.pnl_SpeedSearch = new System.Windows.Forms.Panel();
            this.pnl_SpeedSearch1 = new System.Windows.Forms.Panel();
            this.txt_SpeedSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDept = new DevExpress.XtraGrid.GridControl();
            this.gvwDept = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gColDeptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColContactID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColDeptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gColContact1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact1Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact2Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolContact = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.pnl_Find.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnl_SpeedSearch.SuspendLayout();
            this.pnl_SpeedSearch1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDept)).BeginInit();
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
            this.pnl_Find.Location = new System.Drawing.Point(0, 0);
            this.pnl_Find.Name = "pnl_Find";
            this.pnl_Find.Size = new System.Drawing.Size(672, 90);
            this.pnl_Find.TabIndex = 28;
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
            this.pnlBody.Controls.Add(this.pnl_SpeedSearch);
            this.pnlBody.Controls.Add(this.grdDept);
            this.pnlBody.Controls.Add(this.pnl_Find);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(672, 333);
            this.pnlBody.TabIndex = 29;
            this.pnlBody.Resize += new System.EventHandler(this.pnlBody_Resize);
            // 
            // pnl_SpeedSearch
            // 
            this.pnl_SpeedSearch.BackColor = System.Drawing.Color.Black;
            this.pnl_SpeedSearch.Controls.Add(this.pnl_SpeedSearch1);
            this.pnl_SpeedSearch.Location = new System.Drawing.Point(40, 184);
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
            this.txt_SpeedSearch.Leave += new System.EventHandler(this.txt_SpeedSearch_Leave);
            this.txt_SpeedSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_SpeedSearch_KeyUp);
            this.txt_SpeedSearch.TextChanged += new System.EventHandler(this.txt_SpeedSearch_TextChanged);
            this.txt_SpeedSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SpeedSearch_KeyDown);
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
            // grdDept
            // 
            this.grdDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDept.EmbeddedNavigator.Name = "";
            this.grdDept.ExternalRepository = this.persistentRepository1;
            this.grdDept.Location = new System.Drawing.Point(0, 90);
            this.grdDept.MainView = this.gvwDept;
            this.grdDept.Name = "grdDept";
            this.grdDept.Size = new System.Drawing.Size(672, 243);
            this.grdDept.TabIndex = 25;
            this.grdDept.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwDept});
            this.grdDept.DoubleClick += new System.EventHandler(this.grdDept_DoubleClick);
            this.grdDept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdDept_KeyPress);
            // 
            // gvwDept
            // 
            this.gvwDept.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvwDept.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gColDeptID,
            this.gColContactID,
            this.gcolClient,
            this.gColDeptName,
            this.gColContact1,
            this.gcolContact1Phone,
            this.gcolContact2,
            this.gcolContact2Phone,
            this.gcolContact,
            this.gcolStatus});
            this.gvwDept.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvwDept.GridControl = this.grdDept;
            this.gvwDept.Name = "gvwDept";
            this.gvwDept.OptionsBehavior.Editable = false;
            this.gvwDept.OptionsBehavior.KeepGroupExpandedOnSorting = false;
            this.gvwDept.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvwDept.OptionsView.ShowDetailButtons = false;
            this.gvwDept.OptionsView.ShowGroupPanel = false;
            this.gvwDept.OptionsView.ShowHorzLines = false;
            this.gvwDept.OptionsView.ShowIndicator = false;
            this.gvwDept.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gColDeptName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvwDept.ViewStyles.AddReplace("FocusedRow", "SelectedRow");
            this.gvwDept.ViewStyles.AddReplace("FocusedCell", "SelectedRow");
            // 
            // gColDeptID
            // 
            this.gColDeptID.Caption = "Department ID";
            this.gColDeptID.FieldName = "DepartmentID";
            this.gColDeptID.Name = "gColDeptID";
            // 
            // gColContactID
            // 
            this.gColContactID.Caption = "ContactID";
            this.gColContactID.FieldName = "ContactID";
            this.gColContactID.Name = "gColContactID";
            // 
            // gcolClient
            // 
            this.gcolClient.Caption = "Client Name";
            this.gcolClient.FieldName = "Client";
            this.gcolClient.Name = "gcolClient";
            this.gcolClient.OptionsColumn.ShowInCustomizationForm = false;
            this.gcolClient.Visible = true;
            this.gcolClient.VisibleIndex = 0;
            this.gcolClient.Width = 135;
            // 
            // gColDeptName
            // 
            this.gColDeptName.Caption = "Department Name";
            this.gColDeptName.FieldName = "Name";
            this.gColDeptName.Name = "gColDeptName";
            this.gColDeptName.Visible = true;
            this.gColDeptName.VisibleIndex = 1;
            this.gColDeptName.Width = 135;
            // 
            // gColContact1
            // 
            this.gColContact1.Caption = "Contact 1 Name";
            this.gColContact1.FieldName = "Contact1";
            this.gColContact1.Name = "gColContact1";
            this.gColContact1.Visible = true;
            this.gColContact1.VisibleIndex = 2;
            this.gColContact1.Width = 145;
            // 
            // gcolContact1Phone
            // 
            this.gcolContact1Phone.Caption = "Contact 1 Phone";
            this.gcolContact1Phone.FieldName = "Contact1Phone";
            this.gcolContact1Phone.Name = "gcolContact1Phone";
            this.gcolContact1Phone.Visible = true;
            this.gcolContact1Phone.VisibleIndex = 3;
            // 
            // gcolContact2
            // 
            this.gcolContact2.Caption = "Contact 2 Name";
            this.gcolContact2.FieldName = "Contact2";
            this.gcolContact2.Name = "gcolContact2";
            this.gcolContact2.Visible = true;
            this.gcolContact2.VisibleIndex = 4;
            this.gcolContact2.Width = 145;
            // 
            // gcolContact2Phone
            // 
            this.gcolContact2Phone.Caption = "Contact 2 Phone";
            this.gcolContact2Phone.FieldName = "Contact2Phone";
            this.gcolContact2Phone.Name = "gcolContact2Phone";
            this.gcolContact2Phone.Visible = true;
            this.gcolContact2Phone.VisibleIndex = 5;
            // 
            // gcolContact
            // 
            this.gcolContact.Caption = "Contact";
            this.gcolContact.FieldName = "Contact";
            this.gcolContact.Name = "gcolContact";
            this.gcolContact.Width = 120;
            // 
            // gcolStatus
            // 
            this.gcolStatus.Caption = "Status";
            this.gcolStatus.FieldName = "DepartmentStatus";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.Visible = true;
            this.gcolStatus.VisibleIndex = 6;
            this.gcolStatus.Width = 108;
            // 
            // frmDeptBrw
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(672, 333);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDeptBrw";
            this.ShowInTaskbar = false;
            this.Text = "Departments...";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.pnl_Find.ResumeLayout(false);
            this.pnl_Find.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnl_SpeedSearch.ResumeLayout(false);
            this.pnl_SpeedSearch1.ResumeLayout(false);
            this.pnl_SpeedSearch1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDept)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void FindPanel()
		{
			pnl_Find.Visible=true;
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
			return gvwDept.RowCount;
		}

		private void frmDeptBrw_Resize(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void SpeedSearch()
		{
			int iRowPos = gvwDept.FocusedRowHandle;
			string strGridValue = "";
			foreach(DevExpress.XtraGrid.Columns.GridColumn col in gvwDept.Columns)
			{
				if(col.SortIndex>=0)
				{
					for(int intCtr=0;intCtr<gvwDept.RowCount;intCtr++)
					{
						if(col.VisibleIndex>-1)
						{
							if(gvwDept.GetRowCellValue(intCtr, col) !=System.DBNull.Value)
							{
								strGridValue = gvwDept.GetRowCellValue(intCtr, col).ToString();
								if(strGridValue.ToUpper().Trim().StartsWith(txt_SpeedSearch.Text.Trim().ToUpper()))
								{
									gvwDept.FocusedRowHandle = intCtr;
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

		private void txt_SpeedSearch_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			SpeedSearch();		
		}

		private void txt_SpeedSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if((e.KeyData == Keys.Enter) || (e.KeyData == Keys.Escape))
			{
				pnl_SpeedSearch.Visible = false;
				grdDept.Focus();
				grdDept.Select();
			}
		}

		private void grdDept_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
						grdDept.Focus();
						grdDept.Select();
					}
				}
			}
		}

		private void pnlBody_Resize(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		public void LoadDepartment()
		{
			objDepartment = new Scheduler.BusinessLayer.Department();
			objDepartment.LoadData();
			dtbl = objDepartment.DeptDataTable;
			grdDept.DataSource = dtbl;

			//gvwContact.UnselectRow(0);
			//gvwContact.FocusedRowHandle = CurrRec;
			//gvwContact.SelectRow(CurrRec);

			//Global.ShowRecords(Finddtbl);
		}

		private void frmDeptBrw_Load(object sender, System.EventArgs e)
		{
			LoadDepartment();
		}

		private void grdDept_DoubleClick(object sender, System.EventArgs e)
		{
			int row=0;
			int intDeptID=0;
			int intContactID=0;
			
			row=gvwDept.FocusedRowHandle;

			if(gvwDept.FocusedRowHandle<0)
			{
				Scheduler.BusinessLayer.Message.MsgInformation("No record exists.");
				return;
			}

			intDeptID = Convert.ToInt32(gvwDept.GetRowCellValue(gvwDept.FocusedRowHandle, gColDeptID));
			intContactID = Convert.ToInt32(gvwDept.GetRowCellValue(gvwDept.FocusedRowHandle, gColContactID));

			frmDepartmentDlg fDeptDlg = new frmDepartmentDlg();
			fDeptDlg.DeptID = intDeptID;
			fDeptDlg.ContactID = intContactID;
			fDeptDlg.Mode="Edit";
			fDeptDlg.LoadData();
			if(fDeptDlg.ShowDialog()==DialogResult.OK)
			{
				LoadDepartment();
			}
			fDeptDlg.Close();
			fDeptDlg.Dispose();
			fDeptDlg=null;

			gvwDept.FocusedRowHandle = row;
		}

		private void FindRoutine()
		{
			gvwDept.BeginUpdate();
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
						dtbl.Rows.Add(new object[] 
						{
							CollSearchRow[intRowCtr]["DepartmentID"],
							CollSearchRow[intRowCtr]["Name"],
							CollSearchRow[intRowCtr]["ContactID"],
							CollSearchRow[intRowCtr]["Contact"],
							CollSearchRow[intRowCtr]["ClientID"],
							CollSearchRow[intRowCtr]["Client"],
							CollSearchRow[intRowCtr]["Contact1"],
							CollSearchRow[intRowCtr]["Contact2"],
							CollSearchRow[intRowCtr]["DepartmentStatus"]
						});
					}
				}	
				dtbl.AcceptChanges();
			}
			finally
			{
				gvwDept.EndUpdate();
			}
		}

		private void btn_Find_Click(object sender, System.EventArgs e)
		{
			if (boolFetch==false) LoadDepartment();
			FindRoutine();
		}

		private void btn_Clear_Click(object sender, System.EventArgs e)
		{
			txtSearch.Text = "";
			LoadDepartment();
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
