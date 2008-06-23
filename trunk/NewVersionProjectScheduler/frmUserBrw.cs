using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Scheduler
{
	/// <summary>
	/// Summary description for frmUserBrw.
	/// </summary>
	public class frmUserBrw : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Panel pnlBody;
		internal System.Windows.Forms.Panel pnl_SpeedSearch;
		internal System.Windows.Forms.Panel pnl_SpeedSearch1;
		internal System.Windows.Forms.TextBox txt_SpeedSearch;
		internal System.Windows.Forms.Label label1;
		public System.Windows.Forms.Panel pnl_Find;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		internal System.Windows.Forms.TextBox txtSearch;
		internal System.Windows.Forms.CheckBox chk_Anywhere;
		internal System.Windows.Forms.Button btn_Clear;
		internal System.Windows.Forms.Button btn_Find;
		internal System.Windows.Forms.Label lbl_Find;
		internal System.Windows.Forms.CheckBox chk_AdvanceSearch;
		public DevExpress.XtraGrid.Columns.GridColumn gcolUserID;
		public DevExpress.XtraGrid.Columns.GridColumn gcolUserName;
		public DevExpress.XtraGrid.Columns.GridColumn gcolUserType;
		public DevExpress.XtraGrid.Columns.GridColumn gcolUserStatus;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private frmMain fMain=null;
		public DevExpress.XtraGrid.GridControl grdUser;
		private Scheduler.BusinessLayer.User objUser=null;
		private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		public DevExpress.XtraGrid.Views.Grid.GridView gvwUser;
		private DataTable dtbl;
		public DevExpress.XtraGrid.Columns.GridColumn gcolContactID;
		private bool boolFetch = true;

		public frmUserBrw()
		{
			InitializeComponent();

			try
			{
				BusinessLayer.Common.SetControlFont(pnl_Find);				
				BusinessLayer.Common.SetGridFont(grdUser);
			}
			catch{}

		}

		public frmUserBrw(frmMain fTempMain)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUserBrw));
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnl_SpeedSearch = new System.Windows.Forms.Panel();
			this.pnl_SpeedSearch1 = new System.Windows.Forms.Panel();
			this.txt_SpeedSearch = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grdUser = new DevExpress.XtraGrid.GridControl();
			this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.gvwUser = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gcolUserID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcolUserName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcolUserType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcolUserStatus = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnl_Find = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.chk_Anywhere = new System.Windows.Forms.CheckBox();
			this.btn_Clear = new System.Windows.Forms.Button();
			this.btn_Find = new System.Windows.Forms.Button();
			this.lbl_Find = new System.Windows.Forms.Label();
			this.chk_AdvanceSearch = new System.Windows.Forms.CheckBox();
			this.gcolContactID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnlBody.SuspendLayout();
			this.pnl_SpeedSearch.SuspendLayout();
			this.pnl_SpeedSearch1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvwUser)).BeginInit();
			this.pnl_Find.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.pnl_SpeedSearch);
			this.pnlBody.Controls.Add(this.grdUser);
			this.pnlBody.Controls.Add(this.pnl_Find);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 0);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Size = new System.Drawing.Size(648, 334);
			this.pnlBody.TabIndex = 27;
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
			this.pnl_SpeedSearch1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(38)), ((System.Byte)(143)), ((System.Byte)(230)));
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
			this.txt_SpeedSearch.Size = new System.Drawing.Size(157, 20);
			this.txt_SpeedSearch.TabIndex = 10;
			this.txt_SpeedSearch.Text = "";
			this.txt_SpeedSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SpeedSearch_KeyDown);
			this.txt_SpeedSearch.TextChanged += new System.EventHandler(this.txt_SpeedSearch_TextChanged);
			this.txt_SpeedSearch.Leave += new System.EventHandler(this.txt_SpeedSearch_Leave);
			this.txt_SpeedSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_SpeedSearch_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(56, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fast Search";
			// 
			// grdUser
			// 
			this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdUser.ExternalRepository = this.persistentRepository1;
			this.grdUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grdUser.Location = new System.Drawing.Point(0, 90);
			this.grdUser.MainView = this.gvwUser;
			this.grdUser.Name = "grdUser";
			this.grdUser.Size = new System.Drawing.Size(648, 244);
            //this.grdUser.Styles.AddReplace("Preview", new DevExpress.Utils.ViewStyle("Preview", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, true, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, null, System.Drawing.SystemColors.Window, System.Drawing.Color.Blue));
            //this.grdUser.Styles.AddReplace("FooterPanel", new DevExpress.Utils.ViewStyle("FooterPanel", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
            //this.grdUser.Styles.AddReplace("GroupButton", new DevExpress.Utils.ViewStyle("GroupButton", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
            //this.grdUser.Styles.AddReplace("FilterButtonPressed", new DevExpress.Utils.ViewStyle("FilterButtonPressed", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlText, System.Drawing.SystemColors.Window));
            //this.grdUser.Styles.AddReplace("EvenRow", new DevExpress.Utils.ViewStyle("EvenRow", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.WhiteSmoke, System.Drawing.SystemColors.WindowText));
            //this.grdUser.Styles.AddReplace("HideSelectionRow", new DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.InactiveCaption, System.Drawing.SystemColors.InactiveCaptionText));
            //this.grdUser.Styles.AddReplace("FilterButton", new DevExpress.Utils.ViewStyle("FilterButton", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
            //this.grdUser.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlLightLight));
            //this.grdUser.Styles.AddReplace("GroupPanel", new DevExpress.Utils.ViewStyle("GroupPanel", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlText));
            //this.grdUser.Styles.AddReplace("ColumnFilterButtonPressed", new DevExpress.Utils.ViewStyle("ColumnFilterButtonPressed", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlText, System.Drawing.Color.Blue));
            //this.grdUser.Styles.AddReplace("Empty", new DevExpress.Utils.ViewStyle("Empty", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.Window));
            //this.grdUser.Styles.AddReplace("HeaderPanel", new DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
            //this.grdUser.Styles.AddReplace("GroupRow", new DevExpress.Utils.ViewStyle("GroupRow", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlLight, System.Drawing.SystemColors.WindowText));
            //this.grdUser.Styles.AddReplace("HorzLine", new DevExpress.Utils.ViewStyle("HorzLine", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlDark));
            //this.grdUser.Styles.AddReplace("ColumnFilterButton", new DevExpress.Utils.ViewStyle("ColumnFilterButton", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
            //this.grdUser.Styles.AddReplace("FocusedRow", new DevExpress.Utils.ViewStyle("FocusedRow", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText));
            //this.grdUser.Styles.AddReplace("VertLine", new DevExpress.Utils.ViewStyle("VertLine", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlDark));
            //this.grdUser.Styles.AddReplace("GroupFooter", new DevExpress.Utils.ViewStyle("GroupFooter", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Control, System.Drawing.SystemColors.ControlText));
            //this.grdUser.Styles.AddReplace("FocusedCell", new DevExpress.Utils.ViewStyle("FocusedCell", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText));
            //this.grdUser.Styles.AddReplace("OddRow", new DevExpress.Utils.ViewStyle("OddRow", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.White, System.Drawing.SystemColors.WindowText));
            //this.grdUser.Styles.AddReplace("SelectedRow", new DevExpress.Utils.ViewStyle("SelectedRow", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseImage))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText));
            //this.grdUser.Styles.AddReplace("FocusedGroup", new DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText));
            //this.grdUser.Styles.AddReplace("Row", new DevExpress.Utils.ViewStyle("Row", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", DevExpress.Utils.StyleOptions.StyleEnabled, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText));
            //this.grdUser.Styles.AddReplace("FilterPanel", new DevExpress.Utils.ViewStyle("FilterPanel", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.ControlDark, System.Drawing.SystemColors.ControlLightLight));
            //this.grdUser.Styles.AddReplace("DetailTip", new DevExpress.Utils.ViewStyle("DetailTip", "GridView", new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((((((((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor) 
            //    | DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) 
            //    | DevExpress.Utils.StyleOptions.UseDrawFocusRect) 
            //    | DevExpress.Utils.StyleOptions.UseFont) 
            //    | DevExpress.Utils.StyleOptions.UseForeColor) 
            //    | DevExpress.Utils.StyleOptions.UseHorzAlignment) 
            //    | DevExpress.Utils.StyleOptions.UseImage) 
            //    | DevExpress.Utils.StyleOptions.UseWordWrap) 
            //    | DevExpress.Utils.StyleOptions.UseVertAlignment))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Info, System.Drawing.SystemColors.InfoText));
			this.grdUser.TabIndex = 25;
			this.grdUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdUser_KeyPress);
			this.grdUser.DoubleClick += new System.EventHandler(this.grdUser_DoubleClick);
			// 
			// persistentRepository1
			// 
			this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
																												 this.repositoryItemTextEdit1});
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			this.repositoryItemTextEdit1.Properties.AllowFocused = false;
			this.repositoryItemTextEdit1.Properties.AutoHeight = false;
			this.repositoryItemTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			// 
			// gvwUser
			// 
            //this.gvwUser.BehaviorOptions = ((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail | DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) 
            //    | DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) 
            //    | DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoSelectAllInEditor) 
            //    | DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) 
            //    | DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) 
            //    | DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) 
            //    | DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)));
			this.gvwUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.gvwUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
																						   this.gcolUserID,
																						   this.gcolUserName,
																						   this.gcolUserType,
																						   this.gcolUserStatus,
																						   this.gcolContactID});
			this.gvwUser.DefaultEdit = this.repositoryItemTextEdit1;
			this.gvwUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gvwUser.Name = "gvwUser";
            this.gvwUser.OptionsPrint.AutoWidth = true;
            this.gvwUser.OptionsPrint.PrintDetails = true;
            this.gvwUser.OptionsPrint.PrintFooter = true;
            this.gvwUser.OptionsPrint.PrintFilterInfo = true;
            this.gvwUser.OptionsPrint.PrintGroupFooter = true;
            this.gvwUser.OptionsPrint.PrintHeader = true;
            this.gvwUser.OptionsPrint.PrintHorzLines = true;
            this.gvwUser.OptionsPrint.PrintPreview = true;
            this.gvwUser.OptionsPrint.PrintVertLines = true;
            this.gvwUser.OptionsPrint.UsePrintStyles = true;
            //this.gvwUser.PrintOptions = ((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags)(((((((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintDetails) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFilterInfo) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintPreview) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines) 
            //    | DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.UsePrintStyles)));

            
            //this.gvwUser.ViewOptions = ((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth | DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) 
            //    | DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowGroupedColumns) 
            //    | DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines)));
            this.gvwUser.Appearance.FocusedRow.AssignInternal(this.gvwUser.Appearance.SelectedRow);
            //this.gvwUser.ViewStyles.AddReplace("FocusedRow", "SelectedRow");
            //this.gvwUser.ViewStyles.AddReplace("FocusedCell", "SelectedRow");
			// 
			// gcolUserID
			// 
			this.gcolUserID.Caption = "User ID";
			this.gcolUserID.FieldName = "UserID";
			this.gcolUserID.Name = "gcolUserID";
			
			// 
			// gcolUserName
			// 
			this.gcolUserName.Caption = "User Name";
			this.gcolUserName.FieldName = "UserName";
			this.gcolUserName.Name = "gcolUserName";
			this.gcolUserName.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
			this.gcolUserName.VisibleIndex = 0;
			this.gcolUserName.Width = 200;
			// 
			// gcolUserType
			// 
			this.gcolUserType.Caption = "User Type";
			this.gcolUserType.FieldName = "UserType";
			this.gcolUserType.Name = "gcolUserType";
			this.gcolUserType.VisibleIndex = 1;
			this.gcolUserType.Width = 90;
			// 
			// gcolUserStatus
			// 
			this.gcolUserStatus.Caption = "User Status";
			this.gcolUserStatus.FieldName = "UserStatus";
			this.gcolUserStatus.Name = "gcolUserStatus";
			this.gcolUserStatus.VisibleIndex = 2;
			this.gcolUserStatus.Width = 90;
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
			this.pnl_Find.Size = new System.Drawing.Size(648, 90);
			this.pnl_Find.TabIndex = 26;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(460, 0);
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
			this.txtSearch.Size = new System.Drawing.Size(296, 20);
			this.txtSearch.TabIndex = 9;
			this.txtSearch.Text = "";
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// chk_Anywhere
			// 
			this.chk_Anywhere.BackColor = System.Drawing.SystemColors.Window;
			this.chk_Anywhere.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk_Anywhere.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chk_Anywhere.Location = new System.Drawing.Point(210, 44);
			this.chk_Anywhere.Name = "chk_Anywhere";
			this.chk_Anywhere.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chk_Anywhere.Size = new System.Drawing.Size(154, 24);
			this.chk_Anywhere.TabIndex = 7;
			this.chk_Anywhere.Text = "Search Anywhere in Fields";
			// 
			// btn_Clear
			// 
			this.btn_Clear.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_Clear.Location = new System.Drawing.Point(370, 44);
			this.btn_Clear.Name = "btn_Clear";
			this.btn_Clear.TabIndex = 6;
			this.btn_Clear.Text = "Clear";
			this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
			// 
			// btn_Find
			// 
			this.btn_Find.BackColor = System.Drawing.SystemColors.Control;
			this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_Find.Location = new System.Drawing.Point(370, 15);
			this.btn_Find.Name = "btn_Find";
			this.btn_Find.TabIndex = 4;
			this.btn_Find.Text = "Find";
			this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
			// 
			// lbl_Find
			// 
			this.lbl_Find.AutoSize = true;
			this.lbl_Find.Location = new System.Drawing.Point(15, 19);
			this.lbl_Find.Name = "lbl_Find";
			this.lbl_Find.Size = new System.Drawing.Size(29, 16);
			this.lbl_Find.TabIndex = 0;
			this.lbl_Find.Text = " Find";
			// 
			// chk_AdvanceSearch
			// 
			this.chk_AdvanceSearch.BackColor = System.Drawing.SystemColors.Window;
			this.chk_AdvanceSearch.Checked = true;
			this.chk_AdvanceSearch.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_AdvanceSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk_AdvanceSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chk_AdvanceSearch.Location = new System.Drawing.Point(64, 44);
			this.chk_AdvanceSearch.Name = "chk_AdvanceSearch";
			this.chk_AdvanceSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.chk_AdvanceSearch.Size = new System.Drawing.Size(112, 24);
			this.chk_AdvanceSearch.TabIndex = 8;
			this.chk_AdvanceSearch.Text = "Search All Fields";
			// 
			// gcolContactID
			// 
			this.gcolContactID.Caption = "ContactID";
			this.gcolContactID.FieldName = "ContactID";
			this.gcolContactID.Name = "gcolContactID";
			// 
			// frmUserBrw
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 334);
			this.Controls.Add(this.pnlBody);
			this.Name = "frmUserBrw";
			this.Text = "User...";
			this.Resize += new System.EventHandler(this.frmUserBrw_Resize);
			this.Load += new System.EventHandler(this.frmUserBrw_Load);
			this.pnlBody.ResumeLayout(false);
			this.pnl_SpeedSearch.ResumeLayout(false);
			this.pnl_SpeedSearch1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvwUser)).EndInit();
			this.pnl_Find.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void FindPanel()
		{
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
			return gvwUser.RowCount;
		}

		public void LoadUser()
		{
			objUser = new Scheduler.BusinessLayer.User();
			objUser.LoadData();
			dtbl = objUser.UserDataTable;
			grdUser.DataSource = dtbl;

			//gvwContact.UnselectRow(0);
			//gvwContact.FocusedRowHandle = CurrRec;
			//gvwContact.SelectRow(CurrRec);

			//Global.ShowRecords(Finddtbl);
		}

		private void frmUserBrw_Load(object sender, System.EventArgs e)
		{
			LoadUser();
		}

		private void grdUser_DoubleClick(object sender, System.EventArgs e)
		{
			int row;
			int intUser=0;
			int intContact=0;

			row=gvwUser.FocusedRowHandle;
			if(gvwUser.FocusedRowHandle<0)
			{
				Scheduler.BusinessLayer.Message.MsgInformation("No record exists.");
				return;
			}

			intUser = Convert.ToInt32(gvwUser.GetRowCellValue(gvwUser.FocusedRowHandle, gcolUserID));
			intContact = Convert.ToInt32(gvwUser.GetRowCellValue(gvwUser.FocusedRowHandle, gcolContactID));

			frmUserDlg fUserDlg = new frmUserDlg();
			fUserDlg.UserID = intUser;
			fUserDlg.ContactID = intContact;
			fUserDlg.Mode="Edit";
			fUserDlg.LoadData();
			if(fUserDlg.ShowDialog()==DialogResult.OK)
			{
				LoadUser();
			}
			fUserDlg.Close();
			fUserDlg.Dispose();
			fUserDlg=null;

			gvwUser.FocusedRowHandle=row;
		}

		private void frmUserBrw_Resize(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void SpeedSearch()
		{
			int iRowPos = gvwUser.FocusedRowHandle;
			string strGridValue = "";
			foreach(DevExpress.XtraGrid.Columns.GridColumn col in gvwUser.Columns)
			{
				if(col.SortIndex>=0)
				{
					for(int intCtr=0;intCtr<gvwUser.RowCount;intCtr++)
					{
						if(col.VisibleIndex>-1)
						{
							if(gvwUser.GetRowCellValue(intCtr, col) !=System.DBNull.Value)
							{
								strGridValue = gvwUser.GetRowCellValue(intCtr, col).ToString();
								if(strGridValue.ToUpper().Trim().StartsWith(txt_SpeedSearch.Text.Trim().ToUpper()))
								{
									gvwUser.FocusedRowHandle = intCtr;
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
				grdUser.Focus();
				grdUser.Select();
			}
		}

		private void txt_SpeedSearch_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			SpeedSearch();
		}

		private void grdUser_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
						grdUser.Focus();
						grdUser.Select();
					}
				}
			}
		}

		private void pnlBody_Resize(object sender, System.EventArgs e)
		{
			pnl_SpeedSearch.Left = pnlBody.Left + 40;
			pnl_SpeedSearch.Top = pnlBody.Top + pnlBody.Height - pnl_SpeedSearch.Height - 40;
		}

		private void FindRoutine()
		{
			gvwUser.BeginUpdate();
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
							CollSearchRow[intRowCtr]["UserID"],
							CollSearchRow[intRowCtr]["UserName"],
							CollSearchRow[intRowCtr]["Password"],
							CollSearchRow[intRowCtr]["ContactID"],
							CollSearchRow[intRowCtr]["UserType"],
							CollSearchRow[intRowCtr]["UserStatus"]
						});
					}
				}	
				dtbl.AcceptChanges();
			}
			finally
			{
				gvwUser.EndUpdate();
			}
		}

		private void btn_Find_Click(object sender, System.EventArgs e)
		{
			if (boolFetch==false) LoadUser();
			FindRoutine();
		}

		private void btn_Clear_Click(object sender, System.EventArgs e)
		{
			txtSearch.Text = "";
			LoadUser();
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
