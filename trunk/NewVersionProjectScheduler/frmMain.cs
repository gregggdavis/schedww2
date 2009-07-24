using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Crownwood.Magic.Common;
using Crownwood.Magic.Docking;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraPrinting;
using FlatToolBar;
using Microsoft.Win32;
using Scheduler.BusinessLayer;
using Message=Scheduler.BusinessLayer.Message;
using Timer=System.Windows.Forms.Timer;

namespace Scheduler
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : Form
    {
        #region Initialization
        #region Declaration
        internal MainMenu mnuMain;
		internal MenuItem MenuItem1;
		internal MenuItem mnuDBLogin;
		internal MenuItem MenuItem2;
		internal MenuItem mnuNavBar;
		internal MenuItem MenuItem6;
		internal MenuItem mnuLargeIcons;
		internal MenuItem mnuSmallIcons;
		internal MenuItem mnuSideBarProp;
		internal MenuItem MenuItem4;
		internal MenuItem mnuExit;
		internal MenuItem mnuSettings;
		internal MenuItem mnu_Sett;
		internal MenuItem mnuAbout;
		internal ImageList imlMain;
		internal Timer tmrMain;
		internal ImageList imlSmallImageNavBar;
		internal ImageList imlNavBar;
		internal StatusBar sbarMain;
		internal StatusBarPanel sPnlGeneral;
		internal StatusBarPanel sPnlDate;
		internal StatusBarPanel sPnlPath;
		internal Panel pnlBody;
		internal Panel pnlMain;
		internal Panel pnlHeader;
		internal Label lblTitle;
		internal Panel pnlNavBar;
		internal NavBarControl navBar;
		private NavBarGroup navBarGroup1;
		private NavBarGroup navBarGroup2;
		private NavBarGroup navBarGroup3;
		private NavBarGroup navBarGroup4;
		private NavBarItem nBarDept;
		private NavBarItem nBarCourse;
		private NavBarItem nBarProgram;
		private NavBarItem nBarContacts;
		private ContextMenu cMenu_New;
		internal FlatToolbar tBarMain;
		internal ToolBarButton tbtnNew;
		internal ToolBarButton tbtnOpen;
		internal ToolBarButton tbtnDelete;
		internal ToolBarButton tbtnSepa;
		internal ToolBarButton tbtnFind;
		private NavBarItem nBarUser;
		private IContainer components;

		protected DockingManager _dockingManager = null;
		private MenuItem menuItem11;
		private MenuItem mnuItemUser;
		private MenuItem menuItem13;
		private MenuItem mnuItemContact;
		private MenuItem mnuItemDept;
		private MenuItem mnuItemCourse;
		private MenuItem mnuItemProgram;
		private MenuItem menuItem3;
		private StatusBarPanel sPnlLogon;
		private NavBarItem nBarTeacher;
		private NavBarItem nBarClient;
		private MenuItem mnuItemClient;
		private NavBarItem nBarEvent;

		private string strMenuOption = "";

		private frmUserBrw fUser = null;
		private frmContactBrw fContact = null;
		private frmDeptBrw fDept = null;
		private frmCourseBrw fCourse = null;
		private frmProgBrw fProgram = null;
		private MenuItem mnuItemReports;
		private NavBarItem nBarDay;
		private NavBarItem nBarWeek;
		private NavBarItem nBarMonth;
		private frmEventBrw fEvt = null;
		private frmCalendar fCalendar = null;
        private frmInstructorPayroll fpayment = null;
        private TransportationExpenses fTransportationExpenses = null;
        private frmPayrollByInstructor fpayrollByInstructor = null;

		private AppointmentFormController controller;
		private ToolBarButton tbtnPrint;
		private PrintPreviewDialog printPreviewDialog1;
		private PrintDocument printDocument1;
        private ToolBarButton tbtnDuplicate;
        private NavBarItem navBarItem1;
        private NavBarItem navBarItem2;
        private NavBarItem navBarTransportationExpenses;
        private ToolBarButton tbtnInfoProgram;
		private string strCalendar = "";
        #endregion
        public string MenuOption
		{
			get { return strMenuOption; }
			set
			{
				strMenuOption = value;
				lblTitle.Text = strMenuOption;
				sPnlGeneral.Text = strMenuOption;
			}
		}

		public frmMain()
		{
			InitializeComponent();
			AddDocking();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuDBLogin = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuNavBar = new System.Windows.Forms.MenuItem();
            this.MenuItem6 = new System.Windows.Forms.MenuItem();
            this.mnuLargeIcons = new System.Windows.Forms.MenuItem();
            this.mnuSmallIcons = new System.Windows.Forms.MenuItem();
            this.mnuSideBarProp = new System.Windows.Forms.MenuItem();
            this.MenuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuSettings = new System.Windows.Forms.MenuItem();
            this.mnu_Sett = new System.Windows.Forms.MenuItem();
            this.mnuAbout = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.imlMain = new System.Windows.Forms.ImageList(this.components);
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.imlSmallImageNavBar = new System.Windows.Forms.ImageList(this.components);
            this.imlNavBar = new System.Windows.Forms.ImageList(this.components);
            this.sbarMain = new System.Windows.Forms.StatusBar();
            this.sPnlGeneral = new System.Windows.Forms.StatusBarPanel();
            this.sPnlLogon = new System.Windows.Forms.StatusBarPanel();
            this.sPnlDate = new System.Windows.Forms.StatusBarPanel();
            this.sPnlPath = new System.Windows.Forms.StatusBarPanel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlNavBar = new System.Windows.Forms.Panel();
            this.navBar = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nBarClient = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarDept = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarProgram = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarCourse = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarTeacher = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nBarEvent = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarDay = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarWeek = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarMonth = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nBarUser = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransportationExpenses = new DevExpress.XtraNavBar.NavBarItem();
            this.nBarContacts = new DevExpress.XtraNavBar.NavBarItem();
            this.cMenu_New = new System.Windows.Forms.ContextMenu();
            this.mnuItemClient = new System.Windows.Forms.MenuItem();
            this.mnuItemDept = new System.Windows.Forms.MenuItem();
            this.mnuItemProgram = new System.Windows.Forms.MenuItem();
            this.mnuItemCourse = new System.Windows.Forms.MenuItem();
            this.mnuItemContact = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.mnuItemUser = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.mnuItemReports = new System.Windows.Forms.MenuItem();
            this.tBarMain = new FlatToolBar.FlatToolbar();
            this.tbtnNew = new System.Windows.Forms.ToolBarButton();
            this.tbtnDuplicate = new System.Windows.Forms.ToolBarButton();
            this.tbtnOpen = new System.Windows.Forms.ToolBarButton();
            this.tbtnDelete = new System.Windows.Forms.ToolBarButton();
            this.tbtnSepa = new System.Windows.Forms.ToolBarButton();
            this.tbtnFind = new System.Windows.Forms.ToolBarButton();
            this.tbtnPrint = new System.Windows.Forms.ToolBarButton();
            this.tbtnInfoProgram = new System.Windows.Forms.ToolBarButton();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.sPnlGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPnlLogon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPnlDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPnlPath)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1,
            this.mnuSettings,
            this.mnuAbout});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuDBLogin,
            this.MenuItem2,
            this.mnuNavBar,
            this.MenuItem6,
            this.mnuLargeIcons,
            this.mnuSmallIcons,
            this.mnuSideBarProp,
            this.MenuItem4,
            this.mnuExit});
            this.MenuItem1.Text = "Main";
            // 
            // mnuDBLogin
            // 
            this.mnuDBLogin.Index = 0;
            this.mnuDBLogin.Text = "Database Login";
            this.mnuDBLogin.Click += new System.EventHandler(this.mnuDBLogin_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 1;
            this.MenuItem2.Text = "-";
            // 
            // mnuNavBar
            // 
            this.mnuNavBar.Index = 2;
            this.mnuNavBar.Text = "Show Navigation Bar";
            this.mnuNavBar.Click += new System.EventHandler(this.mnuNavBar_Click);
            // 
            // MenuItem6
            // 
            this.MenuItem6.Index = 3;
            this.MenuItem6.Text = "-";
            // 
            // mnuLargeIcons
            // 
            this.mnuLargeIcons.Index = 4;
            this.mnuLargeIcons.Text = "Large Icons";
            this.mnuLargeIcons.Click += new System.EventHandler(this.mnuLargeIcons_Click);
            // 
            // mnuSmallIcons
            // 
            this.mnuSmallIcons.Index = 5;
            this.mnuSmallIcons.Text = "Small Icons";
            this.mnuSmallIcons.Click += new System.EventHandler(this.mnuSmallIcons_Click);
            // 
            // mnuSideBarProp
            // 
            this.mnuSideBarProp.Index = 6;
            this.mnuSideBarProp.Text = "Display Properties";
            this.mnuSideBarProp.Click += new System.EventHandler(this.mnuSideBarProp_Click);
            // 
            // MenuItem4
            // 
            this.MenuItem4.Index = 7;
            this.MenuItem4.Text = "-";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 8;
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Index = 1;
            this.mnuSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnu_Sett});
            this.mnuSettings.Text = "Tools";
            // 
            // mnu_Sett
            // 
            this.mnu_Sett.Index = 0;
            this.mnu_Sett.Text = "Settings";
            this.mnu_Sett.Click += new System.EventHandler(this.mnu_Sett_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Index = 2;
            this.mnuAbout.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3});
            this.mnuAbout.Text = "Help";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "About";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // imlMain
            // 
            this.imlMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMain.ImageStream")));
            this.imlMain.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imlMain.Images.SetKeyName(0, "");
            this.imlMain.Images.SetKeyName(1, "");
            this.imlMain.Images.SetKeyName(2, "");
            this.imlMain.Images.SetKeyName(3, "");
            this.imlMain.Images.SetKeyName(4, "clone-icon.gif");
            this.imlMain.Images.SetKeyName(5, "tvuPrint.ico");
            this.imlMain.Images.SetKeyName(6, "RibbonPrintPreviewDemoIcon.ico");
            this.imlMain.Images.SetKeyName(7, "Printers & Faxes.ico");
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // imlSmallImageNavBar
            // 
            this.imlSmallImageNavBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmallImageNavBar.ImageStream")));
            this.imlSmallImageNavBar.TransparentColor = System.Drawing.Color.Magenta;
            this.imlSmallImageNavBar.Images.SetKeyName(0, "");
            this.imlSmallImageNavBar.Images.SetKeyName(1, "");
            this.imlSmallImageNavBar.Images.SetKeyName(2, "");
            this.imlSmallImageNavBar.Images.SetKeyName(3, "");
            this.imlSmallImageNavBar.Images.SetKeyName(4, "");
            this.imlSmallImageNavBar.Images.SetKeyName(5, "");
            this.imlSmallImageNavBar.Images.SetKeyName(6, "");
            this.imlSmallImageNavBar.Images.SetKeyName(7, "");
            this.imlSmallImageNavBar.Images.SetKeyName(8, "");
            this.imlSmallImageNavBar.Images.SetKeyName(9, "");
            this.imlSmallImageNavBar.Images.SetKeyName(10, "");
            this.imlSmallImageNavBar.Images.SetKeyName(11, "");
            this.imlSmallImageNavBar.Images.SetKeyName(12, "");
            this.imlSmallImageNavBar.Images.SetKeyName(13, "");
            this.imlSmallImageNavBar.Images.SetKeyName(14, "");
            this.imlSmallImageNavBar.Images.SetKeyName(15, "");
            this.imlSmallImageNavBar.Images.SetKeyName(16, "");
            this.imlSmallImageNavBar.Images.SetKeyName(17, "");
            // 
            // imlNavBar
            // 
            this.imlNavBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlNavBar.ImageStream")));
            this.imlNavBar.TransparentColor = System.Drawing.Color.Magenta;
            this.imlNavBar.Images.SetKeyName(0, "");
            this.imlNavBar.Images.SetKeyName(1, "");
            this.imlNavBar.Images.SetKeyName(2, "");
            this.imlNavBar.Images.SetKeyName(3, "");
            this.imlNavBar.Images.SetKeyName(4, "");
            this.imlNavBar.Images.SetKeyName(5, "");
            this.imlNavBar.Images.SetKeyName(6, "");
            this.imlNavBar.Images.SetKeyName(7, "");
            this.imlNavBar.Images.SetKeyName(8, "");
            this.imlNavBar.Images.SetKeyName(9, "");
            this.imlNavBar.Images.SetKeyName(10, "");
            this.imlNavBar.Images.SetKeyName(11, "");
            this.imlNavBar.Images.SetKeyName(12, "");
            this.imlNavBar.Images.SetKeyName(13, "");
            this.imlNavBar.Images.SetKeyName(14, "");
            this.imlNavBar.Images.SetKeyName(15, "");
            this.imlNavBar.Images.SetKeyName(16, "");
            this.imlNavBar.Images.SetKeyName(17, "");
            this.imlNavBar.Images.SetKeyName(18, "");
            this.imlNavBar.Images.SetKeyName(19, "");
            this.imlNavBar.Images.SetKeyName(20, "");
            this.imlNavBar.Images.SetKeyName(21, "");
            this.imlNavBar.Images.SetKeyName(22, "");
            this.imlNavBar.Images.SetKeyName(23, "money_envelope.ico");
            // 
            // sbarMain
            // 
            this.sbarMain.Location = new System.Drawing.Point(0, 451);
            this.sbarMain.Name = "sbarMain";
            this.sbarMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sPnlGeneral,
            this.sPnlLogon,
            this.sPnlDate,
            this.sPnlPath});
            this.sbarMain.ShowPanels = true;
            this.sbarMain.Size = new System.Drawing.Size(832, 22);
            this.sbarMain.TabIndex = 17;
            this.sbarMain.Text = "sBarMain";
            // 
            // sPnlGeneral
            // 
            this.sPnlGeneral.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sPnlGeneral.Name = "sPnlGeneral";
            this.sPnlGeneral.Width = 325;
            // 
            // sPnlLogon
            // 
            this.sPnlLogon.Icon = ((System.Drawing.Icon)(resources.GetObject("sPnlLogon.Icon")));
            this.sPnlLogon.Name = "sPnlLogon";
            this.sPnlLogon.Text = "Logon : ";
            this.sPnlLogon.Width = 220;
            // 
            // sPnlDate
            // 
            this.sPnlDate.Name = "sPnlDate";
            this.sPnlDate.Text = "Date : ";
            this.sPnlDate.Width = 220;
            // 
            // sPnlPath
            // 
            this.sPnlPath.Icon = ((System.Drawing.Icon)(resources.GetObject("sPnlPath.Icon")));
            this.sPnlPath.Name = "sPnlPath";
            this.sPnlPath.Width = 50;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlMain);
            this.pnlBody.Controls.Add(this.pnlHeader);
            this.pnlBody.Controls.Add(this.pnlNavBar);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 46);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(832, 405);
            this.pnlBody.TabIndex = 18;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(160, 32);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(672, 373);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(160, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(672, 32);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Resize += new System.EventHandler(this.pnlHeader_Resize);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitle.Location = new System.Drawing.Point(16, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(47, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // pnlNavBar
            // 
            this.pnlNavBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNavBar.Controls.Add(this.navBar);
            this.pnlNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavBar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavBar.Name = "pnlNavBar";
            this.pnlNavBar.Size = new System.Drawing.Size(160, 405);
            this.pnlNavBar.TabIndex = 12;
            // 
            // navBar
            // 
            this.navBar.ActiveGroup = this.navBarGroup1;
            this.navBar.Appearance.ItemDisabled.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemPressed.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemPressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemPressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.ContentButtonHint = null;
            this.navBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3,
            this.navBarGroup4});
            this.navBar.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nBarUser,
            this.nBarDept,
            this.nBarCourse,
            this.nBarProgram,
            this.nBarEvent,
            this.nBarContacts,
            this.nBarTeacher,
            this.nBarClient,
            this.nBarDay,
            this.nBarWeek,
            this.nBarMonth,
            this.navBarItem1,
            this.navBarItem2,
            this.navBarTransportationExpenses});
            this.navBar.LargeImages = this.imlNavBar;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Name = "navBar";
            this.navBar.OptionsNavPane.ExpandedWidth = 156;
            this.navBar.Size = new System.Drawing.Size(156, 401);
            this.navBar.SmallImages = this.imlSmallImageNavBar;
            this.navBar.TabIndex = 5;
            this.navBar.Text = "Navigation";
            this.navBar.View = new DevExpress.XtraNavBar.ViewInfo.FlatViewInfoRegistrator();
            this.navBar.Click += new System.EventHandler(this.navBar_Click);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "System Data";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarClient),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarDept),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarProgram),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarCourse),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarTeacher)});
            this.navBarGroup1.LargeImageIndex = 16;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nBarClient
            // 
            this.nBarClient.Caption = "Client";
            this.nBarClient.LargeImageIndex = 16;
            this.nBarClient.Name = "nBarClient";
            this.nBarClient.SmallImageIndex = 14;
            this.nBarClient.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarClient_LinkClicked);
            // 
            // nBarDept
            // 
            this.nBarDept.Caption = "Department";
            this.nBarDept.LargeImageIndex = 19;
            this.nBarDept.Name = "nBarDept";
            this.nBarDept.SmallImageIndex = 4;
            this.nBarDept.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarDept_LinkClicked);
            // 
            // nBarProgram
            // 
            this.nBarProgram.Caption = "Program";
            this.nBarProgram.LargeImageIndex = 2;
            this.nBarProgram.Name = "nBarProgram";
            this.nBarProgram.SmallImageIndex = 2;
            this.nBarProgram.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarProgram_LinkClicked);
            // 
            // nBarCourse
            // 
            this.nBarCourse.Caption = "Class";
            this.nBarCourse.LargeImageIndex = 1;
            this.nBarCourse.Name = "nBarCourse";
            this.nBarCourse.SmallImageIndex = 1;
            this.nBarCourse.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarCourse_LinkClicked);
            // 
            // nBarTeacher
            // 
            this.nBarTeacher.Caption = "Instructor";
            this.nBarTeacher.LargeImageIndex = 17;
            this.nBarTeacher.Name = "nBarTeacher";
            this.nBarTeacher.SmallImageIndex = 5;
            this.nBarTeacher.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarTeacher_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Schedule";
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarEvent),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarDay),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarWeek),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarMonth)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // nBarEvent
            // 
            this.nBarEvent.Caption = "Event";
            this.nBarEvent.LargeImageIndex = 4;
            this.nBarEvent.Name = "nBarEvent";
            this.nBarEvent.SmallImageIndex = 4;
            this.nBarEvent.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarEvent_LinkClicked);
            // 
            // nBarDay
            // 
            this.nBarDay.Caption = "Day";
            this.nBarDay.LargeImageIndex = 20;
            this.nBarDay.Name = "nBarDay";
            this.nBarDay.SmallImageIndex = 15;
            this.nBarDay.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarDay_LinkClicked);
            // 
            // nBarWeek
            // 
            this.nBarWeek.Caption = "Week";
            this.nBarWeek.LargeImageIndex = 21;
            this.nBarWeek.Name = "nBarWeek";
            this.nBarWeek.SmallImageIndex = 16;
            this.nBarWeek.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarWeek_LinkClicked);
            // 
            // nBarMonth
            // 
            this.nBarMonth.Caption = "Month";
            this.nBarMonth.LargeImageIndex = 22;
            this.nBarMonth.Name = "nBarMonth";
            this.nBarMonth.SmallImageIndex = 17;
            this.nBarMonth.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarMonth_LinkClicked);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Access";
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nBarUser)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // nBarUser
            // 
            this.nBarUser.Caption = "User";
            this.nBarUser.LargeImageIndex = 18;
            this.nBarUser.Name = "nBarUser";
            this.nBarUser.SmallImageIndex = 12;
            this.nBarUser.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarUser_LinkClicked);
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "Accounting";
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransportationExpenses)});
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "Pay Details By Instructor";
            this.navBarItem1.LargeImageIndex = 6;
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem1_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Payroll By Instructor";
            this.navBarItem2.LargeImageIndex = 5;
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem2_LinkClicked);
            // 
            // navBarTransportationExpenses
            // 
            this.navBarTransportationExpenses.Caption = "Transportation Expenses";
            this.navBarTransportationExpenses.LargeImageIndex = 23;
            this.navBarTransportationExpenses.Name = "navBarTransportationExpenses";
            this.navBarTransportationExpenses.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransportationExpenses_LinkClicked);
            // 
            // nBarContacts
            // 
            this.nBarContacts.Caption = "Contacts";
            this.nBarContacts.LargeImageIndex = 16;
            this.nBarContacts.Name = "nBarContacts";
            this.nBarContacts.SmallImageIndex = 13;
            this.nBarContacts.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nBarContacts_LinkClicked);
            // 
            // cMenu_New
            // 
            this.cMenu_New.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuItemClient,
            this.mnuItemDept,
            this.mnuItemProgram,
            this.mnuItemCourse,
            this.mnuItemContact,
            this.menuItem11,
            this.mnuItemUser,
            this.menuItem13,
            this.mnuItemReports});
            // 
            // mnuItemClient
            // 
            this.mnuItemClient.Index = 0;
            this.mnuItemClient.Text = "Client";
            this.mnuItemClient.Click += new System.EventHandler(this.mnuItemClient_Click);
            // 
            // mnuItemDept
            // 
            this.mnuItemDept.Index = 1;
            this.mnuItemDept.Text = "Department";
            this.mnuItemDept.Click += new System.EventHandler(this.mnuItemDept_Click);
            // 
            // mnuItemProgram
            // 
            this.mnuItemProgram.Index = 2;
            this.mnuItemProgram.Text = "Program";
            this.mnuItemProgram.Click += new System.EventHandler(this.mnuItemProgram_Click);
            // 
            // mnuItemCourse
            // 
            this.mnuItemCourse.Index = 3;
            this.mnuItemCourse.Text = "Class";
            this.mnuItemCourse.Click += new System.EventHandler(this.mnuItemCourse_Click);
            // 
            // mnuItemContact
            // 
            this.mnuItemContact.Index = 4;
            this.mnuItemContact.Text = "Instructor";
            this.mnuItemContact.Click += new System.EventHandler(this.mnuItemContact_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 5;
            this.menuItem11.Text = "-";
            // 
            // mnuItemUser
            // 
            this.mnuItemUser.Index = 6;
            this.mnuItemUser.Text = "User";
            this.mnuItemUser.Click += new System.EventHandler(this.mnuItemUser_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 7;
            this.menuItem13.Text = "-";
            // 
            // mnuItemReports
            // 
            this.mnuItemReports.Index = 8;
            this.mnuItemReports.Text = "Reports";
            this.mnuItemReports.Click += new System.EventHandler(this.mnuItemReports_Click);
            // 
            // tBarMain
            // 
            //this.tBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbtnNew,
            this.tbtnDuplicate,
            this.tbtnOpen,
            this.tbtnDelete,
            this.tbtnSepa,
            this.tbtnFind,
            this.tbtnPrint,
            this.tbtnInfoProgram});
            this.tBarMain.ButtonSize = new System.Drawing.Size(67, 34);
            //this.tBarMain.Divider = false;
            this.tBarMain.DropDownArrows = true;
            this.tBarMain.DropDownAsOne = false;
            this.tBarMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBarMain.ImageList = this.imlMain;
            this.tBarMain.Location = new System.Drawing.Point(0, 0);
            this.tBarMain.Name = "tBarMain";
            this.tBarMain.ShowToolTips = true;
            this.tBarMain.Size = new System.Drawing.Size(832, 46);
            this.tBarMain.TabIndex = 11;
            this.tBarMain.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
            this.tBarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tBarMain_ButtonClick);
            // 
            // tbtnNew
            // 
            this.tbtnNew.DropDownMenu = this.cMenu_New;
            this.tbtnNew.ImageIndex = 0;
            this.tbtnNew.Name = "tbtnNew";
            this.tbtnNew.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbtnNew.Text = "New";
            this.tbtnNew.ToolTipText = "New";
            // 
            // tbtnDuplicate
            // 
            this.tbtnDuplicate.Enabled = false;
            this.tbtnDuplicate.ImageIndex = 4;
            this.tbtnDuplicate.Name = "tbtnDuplicate";
            this.tbtnDuplicate.Text = "Clone";
            // 
            // tbtnOpen
            // 
            this.tbtnOpen.ImageIndex = 1;
            this.tbtnOpen.Name = "tbtnOpen";
            this.tbtnOpen.Text = "Open";
            this.tbtnOpen.ToolTipText = "Open";
            // 
            // tbtnDelete
            // 
            this.tbtnDelete.ImageIndex = 2;
            this.tbtnDelete.Name = "tbtnDelete";
            this.tbtnDelete.ToolTipText = "Delete";
            // 
            // tbtnSepa
            // 
            this.tbtnSepa.Name = "tbtnSepa";
            this.tbtnSepa.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbtnFind
            // 
            this.tbtnFind.ImageIndex = 3;
            this.tbtnFind.Name = "tbtnFind";
            this.tbtnFind.ToolTipText = "Find";
            // 
            // tbtnPrint
            // 
            this.tbtnPrint.ImageIndex = 7;
            this.tbtnPrint.Name = "tbtnPrint";
            this.tbtnPrint.Text = "Print";
            // 
            // tbtnInfoProgram
            // 
            this.tbtnInfoProgram.Name = "tbtnInfoProgram";
            this.tbtnInfoProgram.Text = "Program Info";
            this.tbtnInfoProgram.Visible = false;
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
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(832, 473);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.sbarMain);
            this.Controls.Add(this.tBarMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(725, 500);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.sPnlGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPnlLogon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPnlDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPnlPath)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNavBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.Run(new frmMain());
		}

		private void AddDocking()
		{
			_dockingManager = new DockingManager(this, VisualStyle.IDE);
			_dockingManager.InnerControl = pnlBody;
			_dockingManager.OuterControl = tBarMain;
			Content ouBar = new Content(_dockingManager);

			_dockingManager.Contents.Add(ouBar);
			ouBar.Title = "Navigation";
			ouBar.FullTitle = "Navigation";
			ouBar.CaptionBar = true;
			ouBar.CloseButton = false;
			ouBar.DisplaySize = new Size(100, 410);
			ouBar.Control = pnlNavBar;
			ouBar.ImageList = imlMain;
			ouBar.ImageIndex = 3;

			_dockingManager.ShowContent(_dockingManager.Contents["Navigation"]);
			_dockingManager.AddContentWithState(ouBar, State.DockLeft);
        }
        #endregion


        private void nBarUser_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("User");
		}

		private void nBarContacts_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("Contact");
		}

		private void nBarTeacher_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("Instructor");
		}

		private void nBarClient_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("Client");
		}

		private void nBarDept_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("Department");
		}

		private void nBarCourse_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("Class");
		}

		private void nBarProgram_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("Program");
		}

		private void OpenBrowse(string caller)
		{
            bool isProgram = false;
			Cursor = Cursors.WaitCursor;
            if (caller != "Event") tbtnDuplicate.Enabled = true;
            else tbtnDuplicate.Enabled = false;
			Common.LockWindow(Handle);
			try
			{
				if (caller == "User")
				{
					if (fUser == null)
					{
						DisposeAll();
						MenuOption = "User...";
						Common.Caption = "User";
						fUser = new frmUserBrw();
						fUser.pnl_Find.Height = 0;
						fUser.LoadUser();
						//tbtnOpen.Visible = true;
					}
					fUser.pnlBody.Parent = pnlMain;
					if (fUser.GetRecordCount() <= 0)
					{
						EnableDisable(false);
						fUser.pnl_Find.Height = 0;
					}
					else
					{
						EnableDisable(true);
					}
					fUser.grdUser.Focus();
				}
				else if (caller == "Contact")
				{
					if (fContact == null)
					{
						DisposeAll();
						fContact = new frmContactBrw();
						fContact.pnl_Find.Height = 0;
						//tbtnOpen.Visible = true;
					}

					MenuOption = "Contact...";
					Common.Caption = "Contact";
					fContact.LoadContact("Contact");

					fContact.Option = "Contact";
					fContact.pnlBody.Parent = pnlMain;
					if (fContact.GetRecordCount() <= 0)
					{
						EnableDisable(false);
						fContact.pnl_Find.Height = 0;
					}
					else
					{
						EnableDisable(true);
					}
					fContact.grdContact.Focus();
				}
                else if (caller == "InstructorPayment")
                {
                    if (fpayment == null)
                    {
                        DisposeAll();
                        fpayment = new frmInstructorPayroll();
                        fpayment.pnlBody.Parent = pnlMain;
                    }
                    MenuOption = "Pay Details By Instructor...";
                    Common.Caption = "Pay Details By Instructor";
                    fpayment.LoadData();

                }
                else if (caller == "TransportationExpenses")
                {
                    if (fTransportationExpenses == null)
                    {
                        DisposeAll();
                        fTransportationExpenses = new TransportationExpenses();
                        fTransportationExpenses.pnlBody.Parent = pnlMain;
                    }
                    MenuOption = "Transportation Expenses...";
                    Common.Caption = "Transportation Expenses";
                    fTransportationExpenses.LoadData();
                }
                else if (caller == "InstructorPayroll")
                {
                    if (fpayrollByInstructor == null)
                    {
                        DisposeAll();
                        fpayrollByInstructor = new frmPayrollByInstructor();
                        fpayrollByInstructor.pnlBody.Parent = pnlMain;
                    }
                    MenuOption = "Payroll By Instructor...";
                    Common.Caption = "Payroll By Instructor";
                    fpayrollByInstructor.LoadData();
                }
                else if (caller == "Instructor")
                {
                    if (fContact == null)
                    {
                        DisposeAll();
                        fContact = new frmContactBrw();
                        fContact.pnl_Find.Height = 0;
                        //tbtnOpen.Visible = true;
                    }
                    MenuOption = "Instructor...";
                    Common.Caption = "Instructor";
                    fContact.LoadContact("Instructor");

                    fContact.Option = "Instructor";
                    fContact.pnlBody.Parent = pnlMain;
                    if (fContact.GetRecordCount() <= 0)
                    {
                        EnableDisable(false);
                        fContact.pnl_Find.Height = 0;
                    }
                    else
                    {
                        EnableDisable(true);
                    }
                    fContact.grdContact.Focus();
                }
                else if (caller == "Client")
                {
                    if (fContact == null)
                    {
                        DisposeAll();
                        fContact = new frmContactBrw();
                        fContact.pnl_Find.Height = 0;
                        //tbtnOpen.Visible = true;
                    }

                    MenuOption = "Client...";
                    Common.Caption = "Client";
                    fContact.Option = "Client";
                    fContact.LoadContact("Client");

                    fContact.pnlBody.Parent = pnlMain;
                    if (fContact.GetRecordCount() <= 0)
                    {
                        EnableDisable(false);
                        fContact.pnl_Find.Height = 0;
                    }
                    else
                    {
                        EnableDisable(true);
                    }
                    fContact.grdContact.Focus();
                }
                else if (caller == "Department")
                {
                    if (fDept == null)
                    {
                        DisposeAll();
                        MenuOption = "Department...";
                        Common.Caption = "Department";
                        fDept = new frmDeptBrw();
                        fDept.pnl_Find.Height = 0;
                        fDept.LoadDepartment();
                        //tbtnOpen.Visible = true;
                    }

                    fDept.pnlBody.Parent = pnlMain;
                    if (fDept.GetRecordCount() <= 0)
                    {
                        EnableDisable(false);
                        fDept.pnl_Find.Height = 0;
                    }
                    else
                    {
                        EnableDisable(true);
                    }
                    fDept.grdDept.Focus();
                }
                else if (caller == "Class")
                {
                    if (fCourse == null)
                    {
                        DisposeAll();
                        MenuOption = "Class...";
                        Common.Caption = "Class";
                        fCourse = new frmCourseBrw();
                        fCourse.LoadCourse();
                        //tbtnOpen.Visible = true;
                    }
                    fCourse.pnlBody.Parent = pnlMain;
                    if (fCourse.GetRecordCount() <= 0)
                    {
                        EnableDisable(false);
                        fCourse.pnl_Find.Height = 0;
                    }
                    else
                    {
                        EnableDisable(true);
                    }
                    fCourse.grdCourse.Focus();
                }
                else if (caller == "Program")
                {
                    if (fProgram == null)
                    {
                        DisposeAll();

                        MenuOption = "Program...";
                        Common.Caption = "Program";
                        fProgram = new frmProgBrw();
                        fProgram.pnl_Find.Height = 0;
                        
                        fProgram.LoadProgram();
                        //tbtnOpen.Visible = true;
                    }
                    isProgram = true;
                    tbtnInfoProgram.Visible = true;
                    fProgram.pnlBody.Parent = pnlMain;
                    if (fProgram.GetRecordCount() <= 0)
                    {
                        EnableDisable(false);
                        fProgram.pnl_Find.Height = 0;
                    }
                    else
                    {
                        EnableDisable(true);
                    }
                    fProgram.grdProgram.Focus();
                }
                else if (caller == "Event")
                {
                    if (fEvt == null)
                    {
                        DisposeAll();
                        MenuOption = "Event...";
                        Common.Caption = "Event";
                        fEvt = new frmEventBrw();
                        fEvt.pnl_Find.Height = 0;
                        fEvt.LoadEvent();
                        //fEvt.LoadFilterSettings();
                        //tbtnOpen.Visible = true;
                    }
                    tbtnInfoProgram.Visible = false;
                    fEvt.pnlBody.Parent = pnlMain;
                    if (fEvt.GetRecordCount() <= 0)
                    {
                        EnableDisable(false);
                        fEvt.pnl_Find.Height = 0;
                    }
                    else
                    {
                        EnableDisable(true);
                    }
                    fEvt.grdEvent.Focus();
                }
                else if (caller == "DayCalendar")
                {
                    tbtnInfoProgram.Visible = false;
                    DisposeAll();
                    OpenCalendar("Day");
                    EnableDisable(true);
                }
                else if (caller == "WeekCalendar")
                {

                    DisposeAll();
                    OpenCalendar("Week");
                    EnableDisable(true);
                }
                else if (caller == "MonthCalendar")
                {
                    DisposeAll();
                    OpenCalendar("Month");
                    EnableDisable(true);
                }
                tbtnInfoProgram.Visible = isProgram;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Eated Exception!" + "/n/n" + ex.Message+ex.StackTrace, "Scheduler");
			}
			finally
			{
				Common.UnLockWindow();
				Cursor = Cursors.Default;
			}
		}
		/// <summary>
		/// Opens calendar control using cpecified name of the calendar view TODO change string to enum
		/// </summary>
		/// <param name="calendarViewName">TODO change this to enum (used when load calendr to choose the view)</param>
		private void OpenCalendar(string calendarViewName)
		{
            tbtnDuplicate.Enabled = false;

            if (fCalendar == null)
			{
				fCalendar = new frmCalendar();
				fCalendar.schedulerControl1.GoToDate(DateTime.Now);
			}
            MenuOption = "Calendar...";
            Common.Caption = "Calendar";
            strCalendar = calendarViewName;
			fCalendar.pnlBody.Parent = pnlMain;
			fCalendar.LoadMain(this);
			fCalendar.PositionDayCalendar();
			fCalendar.LoadCalendar(calendarViewName);
			fCalendar.LoadFilterSettings();
			fCalendar.Focus();
		}

		private void DisposeAll()
		{
			if (fUser != null)
			{
				fUser.pnlBody.Parent = null;
				fUser.Dispose();
				fUser = null;
			}
            if (fpayment != null)
            {
                fpayment.pnlBody.Parent = null;
                fpayment.Dispose();
                fpayment = null;
            }
            if (fTransportationExpenses != null)
            {
                fTransportationExpenses.pnlBody.Parent = null;
                fTransportationExpenses.Dispose();
                fTransportationExpenses = null;
            }
            if (fpayrollByInstructor != null)
            {
                fpayrollByInstructor.pnlBody.Parent = null;
                //fpayrollByInstructor.Close();
                fpayrollByInstructor.Dispose();

                fpayrollByInstructor = null;
            }
			if (fContact != null)
			{
				fContact.pnlBody.Parent = null;
				fContact.Dispose();
				fContact = null;
			}
			if (fDept != null)
			{
				fDept.pnlBody.Parent = null;
				fDept.Dispose();
				fDept = null;
			}
			if (fCourse != null)
			{
				fCourse.pnlBody.Parent = null;
				fCourse.Dispose();
				fCourse = null;
			}
			if (fProgram != null)
			{
				fProgram.pnlBody.Parent = null;
				fProgram.Dispose();
				fProgram = null;
			}
			if (fEvt != null)
			{
				fEvt.pnlBody.Parent = null;
				fEvt.Dispose();
				fEvt = null;
			}
			
			if (fCalendar != null)
			{
				fCalendar.pnlBody.Parent = null;
				//fCalendar.pnlBody.Parent = null;
				//fCalendar.Dispose();
				//fCalendar = null;
			}
		}

		private void navBar_Click(object sender, EventArgs e)
		{
			//_dockingManager.ShowContent(_dockingManager.Contents["Navigation"]);
			//if(_dockingManager.Contents["Navigation"].AutoHidePanel == null)
			//{
			//	_dockingManager.AddContentWithState(_dockingManager.Contents["Navigation"], Crownwood.Magic.Docking.State.DockLeft);
			//}
		}

		private void tBarMain_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			//Possible null reference exception may occur here
            if (e.Button == tbtnFind)
			{
				if (strMenuOption == "User...")
				{
					fUser.FindPanel();
				}
				if ((strMenuOption == "Contact...") || (strMenuOption == "Instructor...") || (strMenuOption == "Client..."))
				{
					fContact.FindPanel();
				}
				if (strMenuOption == "Department...")
				{
					fDept.FindPanel();
				}
				if (strMenuOption == "Class...")
				{
					fCourse.FindPanel();
				}
				if (strMenuOption == "Program...")
				{
					fProgram.FindPanel();
				}
				if (strMenuOption == "Event...")
				{
					fEvt.FindPanel();
				}
			}
			else if (e.Button == tbtnNew)
			{
				NewDialog();
			}
			else if (e.Button == tbtnOpen)
			{
				OpenDialog();
			}
			else if (e.Button == tbtnDelete)
			{
				Delete();
			}
			else if (e.Button == tbtnDuplicate)
			{
				Duplicate();
			}
			else if (e.Button == tbtnPrint)
			{
				Control c = null;
				GetGridControl(pnlBody, ref c);

				if (c == null)
				{
					if (strMenuOption == "Calendar...")
					{
						if (fCalendar != null)
						{
							fCalendar.Print();
						}
						return;
					}
				}
				GridControl gc = (GridControl) c;
                if (strMenuOption == "Transportation Expenses...")
                    fTransportationExpenses.PrintGrid(gc, true);
                else if (strMenuOption == "Payroll By Instructor...")
                    fpayrollByInstructor.PrintGrid(gc, true);
                else if (strMenuOption == "Pay Details By Instructor...")
                    fpayment.PrintGrid(gc, true);
                else
                    PrintGrid(gc);
			}
            else if (e.Button == tbtnInfoProgram)
            {
                fProgram.LoadProgramInfo();
            }
		}
        
		private GridViewPrinter dataGridPrinter1 = null;

        frmProgBrw progBrowsInfo = null;
		private void PrintGrid(GridControl gc)
		{
			//GridView gvwContact = (GridView) gc.DefaultView;
            string strHeader = strMenuOption;
            strHeader = strHeader.Remove(strHeader.Length - 3, 3);
            //strHeader += " Information";
            PageHeaderFooter phf = new PageHeaderFooter();
            phf.Header.Font = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point);
            phf.Header.Content.Add(strHeader);

            PrintableComponentLink _link = new PrintableComponentLink(new PrintingSystem());
            _link.Component = gc;
            _link.Landscape = true;
            _link.PageHeaderFooter = phf;
            _link.PaperKind = PaperKind.A4;
            _link.Margins.Top = 60;
            _link.Margins.Bottom = 60;
            _link.Margins.Right = 10;
            _link.Margins.Left = 10;
            _link.ShowPreviewDialog();

            /*
            PrinterSettings settings = printDocument1.PrinterSettings;
            //Set PageSize to 'A4'
            bool found=false;
            foreach (PaperSize size in settings.PaperSizes)
            {
                if (size.PaperName == "A4, 210x297 mm")
                    found = true;
                if (found)
                {
                    settings.DefaultPageSettings.PaperSize = size;
                    break;
                }
                else continue;
            }

			printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.Margins = new Margins(50, 50, 15, 50);
            //printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4, 210x297 mm", 827, 1169);
            
			dataGridPrinter1 = new GridViewPrinter(gc, printDocument1, gvwContact);
			dataGridPrinter1.PageNumber = 1;
			dataGridPrinter1.RowCount = 0;
			if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
			}*/
		}
		
        private void GetGridControl(Control objControls, ref Control objC)
		{
			if (objC != null)
			{
				return;
			}

			foreach (Control c in objControls.Controls)
			{
				if (c.ToString() == "DevExpress.XtraGrid.GridControl")
				{
					objC = c;
					return;
				}
				else
				{
					GetGridControl(c, ref objC);
				}
			}
		}

		public void EnableDisable(bool boolEnable)
		{
			tbtnDelete.Enabled = boolEnable;
			tbtnOpen.Enabled = boolEnable;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			if (File.Exists(Application.StartupPath + "\\scheduler.config"))
			{
				DataSet ds = new DataSet();
				ds.ReadXml(Application.StartupPath + "\\scheduler.config", XmlReadMode.ReadSchema);

				if (ds.Tables.Count > 0)
				{
					if (ds.Tables[0].Rows.Count > 0)
					{
						Common.FontName = (string) ds.Tables[0].Rows[0][0];
						Common.FontSize = (float) Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());

						SetNavBarStyle();
					}
				}
			}

			bool boolSuccess = false;
			Visible = false;
			Refresh();

			frmSplash fSplash = null;
			try
			{
				fSplash = new frmSplash();
				frmUserLogin fLogin = new frmUserLogin();
				fSplash.Show();
				fSplash.Refresh();
				Thread.Sleep(100);

				boolSuccess = DoDataConnect();
				if (boolSuccess)
				{
					WindowState = FormWindowState.Maximized;
					//Global.SBarMain = Me.sbarMain

					//Dispose the Splash Screen
					fSplash.Close();
					fSplash.Dispose();

					navBar.Refresh();
					Refresh();

					//Open the Login Dialog
					Text = "SCHEDULER (" + Common.GetShortVersionInfo() + ")";
					if (fLogin.ShowDialog() == DialogResult.OK)
					{
						sPnlDate.Text = DateTime.Now.ToString();
						Visible = true;
						tmrMain.Enabled = true;

						//Admin can vie/add/modify user
                        if (Common.LogonType == 0 || Common.LogonType == 2)
                        {
                            navBarGroup3.Visible = false;
                            mnuItemUser.Visible = false;
                            navBarGroup4.Visible = false;
                        }
						Refresh();
						Common.LockWindow(Handle);

						//Set the Status Bar
						sPnlLogon.Text = "Logon User : " + Common.LogonUser;
						sPnlPath.ToolTipText = "Server : " + Common.SqlServer;

						//Open default Client Page at Startup
						nBarClient_LinkClicked(null, null);
						Common.UnLockWindow();
						Refresh();

						return;
					}
					else
					{
						tmrMain.Enabled = false;
						Application.Exit();
					}
				}
			}
			finally
			{
				if (!boolSuccess)
				{
					fSplash.Close();
					fSplash.Dispose();
					frmSqlLogin fLogin = new frmSqlLogin();
					if (fLogin.ShowDialog() == DialogResult.Cancel)
					{
						fLogin.Close();
						fLogin.Dispose();
						fLogin = null;
						Application.Exit();
					}
					else
					{
						while (fLogin.Success == false)
						{
							fLogin.Close();
							fLogin.ShowDialog();
						}
					}
					fLogin.Close();
					fLogin.Dispose();
					frmMain_Load(this, null);
				}

				Visible = true;
			}
		}

		private bool DoDataConnect()
		{
			//string ConString = "";
			string strServer;
			string strDatabase;
			string strTrustedConnection;
			string strUser;
			string strPwd;
			bool boolSuccess;

			strServer = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "SqlServer");
			strDatabase = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "SqlDatabase");
			strTrustedConnection = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "TrustedConnection");
			strUser = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "User");
			strPwd = Common.ReadFromRegistry(Registry.CurrentUser, "Scheduler", "Pwd");

			if ((strServer == "") || (strDatabase == ""))
			{
				boolSuccess = false;
			}
			else
			{
				if (strTrustedConnection == "No")
					boolSuccess = GetConnectionString(strServer, strDatabase, strUser, strPwd);
				else
					boolSuccess = GetConnectionString(strServer, strDatabase);


				if (boolSuccess)
				{
					Common.SqlServer = strServer;
				}
			}
			return boolSuccess;
		}

		private bool GetConnectionString(string Server, string Database)
		{
			string strconnstring;
			strconnstring = "Server=" + Server + ";" +
			                "Database=" + Database + ";" +
			                "Trusted_Connection=True;";
			SqlConnection cn = new SqlConnection(strconnstring);
			try
			{
				cn.Open();
				Common.ConnString = strconnstring;
				Common.ConnString1 = strconnstring;
				cn.Close();
				cn.Dispose();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Couldnot connect to SQLServer" + "/n/n" + ex.Message, "Scheduler");
				return false;
			}
		}

		private void mnu_Sett_Click(object sender, EventArgs e)
		{
			try
			{
				ComboBox cmb_Temp = AddItemsInCombo();
				frm_NavBarProperties objNavBarProperties = new frm_NavBarProperties(navBar, cmb_Temp);
				if (objNavBarProperties.ShowDialog() == DialogResult.OK)
				{
					navBar.View = objNavBarProperties.cbStyles.SelectedItem as BaseViewInfoRegistrator;
					navBar.ResetStyles();

					for (int ii = 0; ii <= navBar.Groups.Count - 1; ii++)
					{
						navBar.Groups[ii].AppearanceBackground.BackColor =
							Color.FromArgb(objNavBarProperties.bytBackColorA, objNavBarProperties.bytBackColorR,
							               objNavBarProperties.bytBackColorG, objNavBarProperties.bytBackColorB);
						navBar.Groups[ii].Appearance.Font = new Font("Tahoma", 8.25F);
					}

					if (!((Common.FontName == "") && (Common.FontSize == 0)))
					{
						SetNavBarStyle();
					}
				}
				objNavBarProperties.Dispose();
			}
			catch
			{
			}
		}

		private void pnlHeader_Resize(object sender, EventArgs e)
		{
			double dbl = Convert.ToDouble(pnlHeader.Width/2) - Convert.ToDouble(lblTitle.Width/2);
			lblTitle.Left = Convert.ToInt32(Math.Round(dbl, 0));
		}

		private void mnuItemReports_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Implemented later...");
		}

		private void mnuItemEvent_Click(object sender, EventArgs e)
		{
			strMenuOption = "Event...";
			NewDialog();
		}

		private void nBarEvent_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("Event");
		}

		private void nBarCalanderEvent_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			MessageBox.Show("Under Construction...");
		}

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            sPnlDate.Text = "Date : " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }

		private void menuItem3_Click(object sender, EventArgs e)
		{
			frmAboutDlg frm = new frmAboutDlg();
			frm.ShowDialog();
			frm.Close();
			frm.Dispose();
			frm = null;
		}

		private void frmMain_Closing(object sender, CancelEventArgs e)
		{
			Application.Exit();
			e.Cancel = false;
		}

		private void mnuDBLogin_Click(object sender, EventArgs e)
		{
			frmSqlLogin frm = new frmSqlLogin();
			if (frm.ShowDialog() == DialogResult.Cancel)
			{
				frm.Close();
				frm = null;
				return;
			}
			else
			{
				while (!frm.Success)
				{
					frm.Close();
					frm.ShowDialog();
				}
			}
			frm.Close();
			frm = null;
			frmMain_Load(this, null);
		}

		private void mnuLargeIcons_Click(object sender, EventArgs e)
		{
			for (int ii = 0; ii <= navBar.Groups.Count - 1; ii++)
			{
				navBar.Groups[ii].LinksUseSmallImage = false;
			}
		}

		private void mnuSmallIcons_Click(object sender, EventArgs e)
		{
			for (int ii = 0; ii <= navBar.Groups.Count - 1; ii++)
			{
				navBar.Groups[ii].LinksUseSmallImage = true;
			}
		}

		private void mnuNavBar_Click(object sender, EventArgs e)
		{
			_dockingManager.ShowContent(_dockingManager.Contents["Navigation"]);
			if (_dockingManager.Contents["Navigation"].AutoHidePanel == null)
			{
				_dockingManager.AddContentWithState(_dockingManager.Contents["Navigation"], State.DockLeft);
			}
		}

		private void mnuSideBarProp_Click(object sender, EventArgs e)
		{
			try
			{
				ComboBox cmb_Temp = AddItemsInCombo();
				frm_NavBarProperties objNavBarProperties = new frm_NavBarProperties(navBar, cmb_Temp);
				if (objNavBarProperties.ShowDialog() == DialogResult.OK)
				{
					navBar.View = objNavBarProperties.cbStyles.SelectedItem as BaseViewInfoRegistrator;
					navBar.ResetStyles();

					for (int ii = 0; ii <= navBar.Groups.Count - 1; ii++)
					{
						navBar.Groups[ii].AppearanceBackground.BackColor =
							Color.FromArgb(objNavBarProperties.bytBackColorA, objNavBarProperties.bytBackColorR,
							               objNavBarProperties.bytBackColorG, objNavBarProperties.bytBackColorB);
						navBar.Groups[ii].Appearance.Font = new Font("Tahoma", 8.25F);
					}

					if (!((Common.FontName == "") && (Common.FontSize == 0)))
					{
						SetNavBarStyle();
					}
				}
				objNavBarProperties.Dispose();
			}
			catch
			{
			}
		}

		private ComboBox AddItemsInCombo()
		{
			ComboBox cmb_Result = new ComboBox();
			int intTag = 0;
			for (int i = 0; i < navBar.Groups.Count; i++)
			{
				int intItemCount = navBar.Groups[i].ItemLinks.Count;
				for (int j = 0; j < intItemCount; j++)
				{
					try
					{
						intTag = Convert.ToInt32(navBar.Groups[i].ItemLinks[j].Item.Tag);
					}
					catch
					{
					}
				}
			}

			return cmb_Result;
		}

		private void mnuItemUser_Click(object sender, EventArgs e)
		{
			strMenuOption = "User...";
			NewDialog();
		}

		private void mnuItemContact_Click(object sender, EventArgs e)
		{
			strMenuOption = "Instructor...";
			NewDialog();
		}

		private void mnuItemClient_Click(object sender, EventArgs e)
		{
			strMenuOption = "Client...";
			NewDialog();
		}

		private void mnuItemProgram_Click(object sender, EventArgs e)
		{
			strMenuOption = "Program...";
			NewDialog();
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void mnuItemDept_Click(object sender, EventArgs e)
		{
			strMenuOption = "Department...";
			NewDialog();
		}

		private void mnuItemCourse_Click(object sender, EventArgs e)
		{
			strMenuOption = "Class...";
			NewDialog();
		}

		private void NewDialog()
		{
			if (strMenuOption == "User...")
			{
				frmUserDlg fUserDlg = new frmUserDlg();
				fUserDlg.Mode = "Add";
				fUserDlg.ShowDialog();
				fUserDlg.Close();
				fUserDlg.Dispose();
				fUserDlg = null;

				ReloadUsersList();
			}
			else if (strMenuOption == "Contact...")
			{
				frmContactDlg fContDlg = new frmContactDlg();
				fContDlg.Mode = "Add";
				fContDlg.ShowDialog();
				fContDlg.Close();
				fContDlg.Dispose();
				fContDlg = null;

				ReloadContactsGrid();
			}
			else if (strMenuOption == "Instructor...")
			{
				frmInstructorDlg fInstructorDlg = new frmInstructorDlg();
				fInstructorDlg.Mode = "Add";
				fInstructorDlg.ShowDialog();
				fInstructorDlg.Close();
				fInstructorDlg.Dispose();
				fInstructorDlg = null;

				ReloadInstructorsList();
			}
			else if (strMenuOption == "Client...")
			{
				frmClientDlg fClientDlg = new frmClientDlg();
				fClientDlg.Mode = "Add";
                fClientDlg.LoadData();
				fClientDlg.ShowDialog();
				fClientDlg.Close();
				fClientDlg.Dispose();
				fClientDlg = null;

				ReloadClientsList();
			}
			else if (strMenuOption == "Department...")
			{
				frmDepartmentDlg fDeptDlg = new frmDepartmentDlg();
				fDeptDlg.Mode = "Add";
                fDeptDlg.LoadData();
				fDeptDlg.ShowDialog();
				fDeptDlg.Close();
				fDeptDlg.Dispose();
				fDeptDlg = null;

				ReloadDepartmentsList();
			}
			else if (strMenuOption == "Class...")
			{
				frmClassDlg fClassDlg = new frmClassDlg();
				fClassDlg.Mode = "Add";
                fClassDlg.LoadData();
				fClassDlg.ShowDialog();
				fClassDlg.Close();
				fClassDlg.Dispose();
				fClassDlg = null;

				ReloadClassesList();
			}
			else if (strMenuOption == "Program...")
			{
				frmProgramDlg fProgDlg = new frmProgramDlg();
				fProgDlg.Mode = "Add";
                fProgDlg.LoadData();
				fProgDlg.ShowDialog();
				fProgDlg.Close();
				fProgDlg.Dispose();
				fProgDlg = null;

				ReloadProgramList();
			}
			else if (strMenuOption == "Event..." || strMenuOption == "Calendar...")
			{
                //MessageBox.Show(strMenuOption);
				MessageBox.Show(
					"New events can't be created from this window, please use program or class properties to manage events !",
					"Adding new event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (strMenuOption == "Calendar...")
			{
				DateTime dtSelect = fCalendar.schedulerControl1.SelectedInterval.Start.Date;

				TimeSpan StartTS = fCalendar.schedulerControl1.SelectedInterval.Start.TimeOfDay;
				string strStartTime = StartTS.ToString();
				strStartTime = strStartTime.Substring(0, 5);

				TimeSpan EndTS = StartTS.Add(new TimeSpan(0, 0, 30, 0, 0));
				string strEndTime = EndTS.ToString();
				strEndTime = strEndTime.Substring(0, 5);

				frmEventDlg fEvtDlg = null;

				if (strCalendar == "Day")
				{
					fEvtDlg = new frmEventDlg(dtSelect, strStartTime, strEndTime, "Calendar");
				}
				else
				{
					fEvtDlg = new frmEventDlg(dtSelect, "", "", "Calendar");
				}

				fEvtDlg.Mode = "Add";
				fEvtDlg.ShowDialog();
				fEvtDlg.Close();
				fEvtDlg.Dispose();
				fEvtDlg = null;

				if (fCalendar != null)
				{
					fCalendar.LoadCalendar();
				}
			}
		}

		private void ReloadUsersList() {
			if (fUser != null)
			{
				fUser.LoadUser();
				if (fUser.GetRecordCount() <= 0)
				{
					EnableDisable(false);
					fUser.pnl_Find.Height = 0;
				}
				else
				{
					EnableDisable(true);
				}
			}
		}

		private void ReloadProgramList() {
			if (fProgram != null)
			{
				fProgram.LoadProgram();
				if (fProgram.GetRecordCount() <= 0)
				{
					EnableDisable(false);
					fProgram.pnl_Find.Height = 0;
				}
				else
				{
					EnableDisable(true);
				}
			}
		}

		private void ReloadClassesList() {
			if (fCourse != null)
			{
				fCourse.LoadCourse();
				if (fCourse.GetRecordCount() <= 0)
				{
					EnableDisable(false);
					fCourse.pnl_Find.Height = 0;
				}
				else
				{
					EnableDisable(true);
				}
			}
		}

		private void ReloadDepartmentsList() {
			if (fDept != null)
			{
				fDept.LoadDepartment();
				if (fDept.GetRecordCount() <= 0)
				{
					EnableDisable(false);
					fDept.pnl_Find.Height = 0;
				}
				else
				{
					EnableDisable(true);
				}
			}
		}

		private void ReloadContactsGrid() {
			if (fContact != null)
			{
				fContact.LoadContact("Contact");
				if (fContact.GetRecordCount() <= 0)
				{
					EnableDisable(false);
					fContact.pnl_Find.Height = 0;
				}
				else
				{
					EnableDisable(true);
				}
			}
		}

		private void ReloadInstructorsList() {
			if (fContact != null)
			{
				fContact.LoadContact("Instructor");
				if (fContact.GetRecordCount() <= 0)
				{
					EnableDisable(false);
					fContact.pnl_Find.Height = 0;
				}
				else
				{
					EnableDisable(true);
				}
			}
		}

		private void ReloadClientsList() {
			if (fContact != null)
			{
				fContact.LoadContact("Client");
				if (fContact.GetRecordCount() <= 0)
				{
					EnableDisable(false);
					fContact.pnl_Find.Height = 0;
				}
				else
				{
					EnableDisable(true);
				}
			}
		}

		//TO DO: Remove Stored Procs.
        private void Duplicate()
		{
			if (strMenuOption == "User...")
			{
				int Row = fUser.gvwUser.FocusedRowHandle;

				if (Row >= 0)
				{
					int intUserID =
						Convert.ToInt32(fUser.gvwUser.GetRowCellValue(fUser.gvwUser.FocusedRowHandle, fUser.gcolUserID).ToString());
					int intContactID =
						Convert.ToInt32(fUser.gvwUser.GetRowCellValue(fUser.gvwUser.FocusedRowHandle, fUser.gcolContactID).ToString());

                    //intContactID = Contact.CloneData(intContactID);
                    //intUserID = User.Clone(intUserID);
                    
                    //Changing the mode to 'AddClone' and passing the same IDs for loading data
					frmUserDlg fUserDlg = new frmUserDlg();
					fUserDlg.Mode = "AddClone";
					fUserDlg.UserID = intUserID;
					fUserDlg.ContactID = intContactID;
					fUserDlg.LoadData();
					fUserDlg.ShowDialog();
					fUserDlg.Close();
					fUserDlg.Dispose();
					fUserDlg = null;

					ReloadUsersList();
				}
			}
			else if (strMenuOption == "Contact...")
			{
				int Row = fContact.gvwContact.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fContact.gvwContact.GetRowCellValue(fContact.gvwContact.FocusedRowHandle, fContact.gcolContactID).ToString());

					//intID = Contact.CloneData(intID);

					frmContactDlg fContDlg = new frmContactDlg();
					fContDlg.Mode = "AddClone";
					fContDlg.ContactID = intID;
					fContDlg.LoadData();
					fContDlg.ShowDialog();
					fContDlg.Close();
					fContDlg.Dispose();
					fContDlg = null;

					ReloadContactsGrid();
				}
			}
			else if (strMenuOption == "Instructor...")
			{
				int Row = fContact.gvwContact.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fContact.gvwContact.GetRowCellValue(fContact.gvwContact.FocusedRowHandle, fContact.gcolContactID).ToString());

					//intID = Contact.CloneData(intID);

					frmInstructorDlg fInstructorDlg = new frmInstructorDlg();
					fInstructorDlg.Mode = "AddClone";
					fInstructorDlg.ContactID = intID;
					fInstructorDlg.LoadData();
					fInstructorDlg.ShowDialog();
					fInstructorDlg.Close();
					fInstructorDlg.Dispose();
					fInstructorDlg = null;

					ReloadInstructorsList();
				}
			}
			else if (strMenuOption == "Client...")
			{
				int Row = fContact.gvwContact.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fContact.gvwContact.GetRowCellValue(fContact.gvwContact.FocusedRowHandle, fContact.gcolContactID).ToString());

					//intID = Contact.CloneData(intID);
					frmClientDlg fClientDlg = new frmClientDlg();
					fClientDlg.Mode = "AddClone";
					fClientDlg.ContactID = intID;
					fClientDlg.LoadData();
					fClientDlg.ShowDialog();
					fClientDlg.Close();
					fClientDlg.Dispose();
					fClientDlg = null;

					ReloadClientsList();
				}
			}
			else if (strMenuOption == "Department...")
			{
				int Row = fDept.gvwDept.FocusedRowHandle;

				if (Row >= 0)
				{
					int intDeptID =
						Convert.ToInt32(fDept.gvwDept.GetRowCellValue(fDept.gvwDept.FocusedRowHandle, fDept.gColDeptID).ToString());
					int intContactID =
						Convert.ToInt32(fDept.gvwDept.GetRowCellValue(fDept.gvwDept.FocusedRowHandle, fDept.gColContactID).ToString());

					//int[] array = new int[2];
                    //array = Department.CloneData(intDeptID);
                    //intDeptID = array[0];
                    //intContactID = array[1];

					frmDepartmentDlg fDeptDlg = new frmDepartmentDlg();
					fDeptDlg.Mode = "AddClone";
					fDeptDlg.DeptID = intDeptID;
					fDeptDlg.ContactID = intContactID;
					fDeptDlg.LoadData();
					fDeptDlg.ShowDialog();
					fDeptDlg.Close();
					fDeptDlg.Dispose();
					fDeptDlg = null;

					ReloadDepartmentsList();
				}
			}
			else if (strMenuOption == "Program...")
			{
				int Row = fProgram.gvwProgram.FocusedRowHandle;

				if (Row >= 0)
				{
					int intProgID =
						Convert.ToInt32(
							fProgram.gvwProgram.GetRowCellValue(fProgram.gvwProgram.FocusedRowHandle, fProgram.gcolProgID).ToString());

					//intProgID = Program.CloneData(intProgID);

					frmProgramDlg fProgDlg = new frmProgramDlg(intProgID);
					fProgDlg.Mode = "AddClone";
					fProgDlg.LoadData();
					fProgDlg.ShowDialog();
					fProgDlg.Close();
					fProgDlg.Dispose();
					fProgDlg = null;

					ReloadProgramList();
				}
			}
			else if (strMenuOption == "Class...")
			{
				int Row = fCourse.gvwCourse.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fCourse.gvwCourse.GetRowCellValue(fCourse.gvwCourse.FocusedRowHandle, fCourse.gcolCourseID).ToString());


					//intID = Course.CloneData(intID);
					
					frmClassDlg fClassDlg = new frmClassDlg();
					fClassDlg.Mode = "AddClone";
					fClassDlg.CourseID = intID;
					fClassDlg.LoadData();
					fClassDlg.ShowDialog();
					fClassDlg.Close();
					fClassDlg.Dispose();
					fClassDlg = null;

					ReloadClassesList();
				}
			}
			else if (strMenuOption == "Event...")
			{
				if (fEvt != null)
				{
					int Row = fEvt.gvwEvent.FocusedRowHandle;

					if (Row >= 0)
					{
						bool IsRecur = false;
						int intID =
							Convert.ToInt32(fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.gcolEventID).ToString());
						int intCalID =
							Convert.ToInt32(fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.colCalendarEventID).ToString());

						if (fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.gcolIsRecur).ToString() != "")
							IsRecur = true;

						int Option = -1;

						if (IsRecur)
						{
							frmOpenEvents frmOpenEvt = new frmOpenEvents();
							if (frmOpenEvt.ShowDialog() == DialogResult.OK)
							{
								Option = frmOpenEvt.Option;
							}
							else
							{
								frmOpenEvt.Close();
								frmOpenEvt.Dispose();
								frmOpenEvt = null;
								return;
							}
						}
						//this part was copy-pasted from frmCalendar.cs we exit if no module linked to the event 
						string module = string.Empty;
						int _uid = 0;
						int _eventtypeindex = 0;
						Events objEvent = new Events();
						_uid = objEvent.GetEvent(intID, ref module, ref _eventtypeindex);
						if (module == "")
						{
							return;
						}
						//---

						frmEventDlg fEvtDlg = null;
						if (Option == 1)
						{
                            if (module == "Class")
                            {
                                frmClassDlg frm = new frmClassDlg(_uid, _eventtypeindex, intCalID);
                                frm.Mode = "AddClone";
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    frm.Close();
                                    frm.Dispose();
                                    frm = null;
                                }
                            }
                            else if (module == "Program")
                            {
                                frmProgramDlg frm = new frmProgramDlg(_uid, _eventtypeindex, intCalID);
                                frm.Mode = "AddClone";
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    frm.Close();
                                    frm.Dispose();
                                    frm = null;
                                }
                            }

                            /*
                            fEvtDlg = new frmEventDlg(intID, intCalID);
							fEvtDlg.Mode = "Edit";
							fEvtDlg.EventID = intID;
							fEvtDlg.LoadData();
                            */
						}
						else
						{
                            if (module == "Class")
                            {
                                frmClassDlg frm = new frmClassDlg(_uid, _eventtypeindex);
                                frm.Mode = "AddClone";
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    frm.Close();
                                    frm.Dispose();
                                    frm = null;
                                }
                            }
                            else if (module == "Program")
                            {
                                frmProgramDlg frm = new frmProgramDlg(_uid, _eventtypeindex);
                                frm.Mode = "AddClone";
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    frm.Close();
                                    frm.Dispose();
                                    frm = null;
                                }
                            }
							/*
                            fEvtDlg = new frmEventDlg();
							fEvtDlg.Mode = "Edit";
							fEvtDlg.EventID = intID;
							fEvtDlg.LoadData();
                            */
						}
                        
                        /*
						if (fEvtDlg.ShowDialog() == DialogResult.OK)
						{
							fEvt.LoadEvent();
						}
						fEvtDlg.Close();
						fEvtDlg.Dispose();
						fEvtDlg = null;

						fEvt.gvwEvent.FocusedRowHandle = Row;
                        */
					}
				}/*
				else
				{

				}*/
			}
			else if (strMenuOption == "Calendar...")
			{
				if (fCalendar.schedulerControl1.SelectedAppointments.Count > 0)
				{
					Appointment apt = fCalendar.schedulerControl1.SelectedAppointments[0];
					bool IsRecur = false;

					controller = new AppointmentFormController(fCalendar.schedulerControl1, apt);

					int intCalID = Convert.ToInt32(controller.LabelId.ToString());
					int intEventID = Common.GetID("select EventID from CalendarEvent where CalendarEventID=" + intCalID.ToString());
					string strRecurrenceText =
						Common.GetString("select RecurrenceText from Event where EventID=" + intEventID.ToString());

					if (strRecurrenceText != "")
						IsRecur = true;

					int Option = -1;
					if (IsRecur)
					{
						frmOpenEvents frmOpenEvt = new frmOpenEvents();
						if (frmOpenEvt.ShowDialog() == DialogResult.OK)
						{
							Option = frmOpenEvt.Option;
						}
						else
						{
							frmOpenEvt.Close();
							frmOpenEvt.Dispose();
							frmOpenEvt = null;
							return;
						}
					}

					frmEventDlg fEvtDlg = null;
					if (Option == 1)
					{
						fEvtDlg = new frmEventDlg(intEventID, intCalID);
						fEvtDlg.Mode = "Edit";
						fEvtDlg.EventID = intEventID;
						fEvtDlg.LoadData();
					}
					else
					{
						fEvtDlg = new frmEventDlg();
						fEvtDlg.Mode = "Edit";
						fEvtDlg.EventID = intEventID;
						fEvtDlg.LoadData();
					}
					if (fEvtDlg.ShowDialog() == DialogResult.OK)
					{
						fCalendar.LoadCalendar();
					}
					fEvtDlg.Close();
					fEvtDlg.Dispose();
					fEvtDlg = null;
				}
			}

		}

		private void OpenDialog()
		{
			if (strMenuOption == "User...")
			{
				int Row = fUser.gvwUser.FocusedRowHandle;

				if (Row >= 0)
				{
					int intUserID =
						Convert.ToInt32(fUser.gvwUser.GetRowCellValue(fUser.gvwUser.FocusedRowHandle, fUser.gcolUserID).ToString());
					int intContactID =
						Convert.ToInt32(fUser.gvwUser.GetRowCellValue(fUser.gvwUser.FocusedRowHandle, fUser.gcolContactID).ToString());

					frmUserDlg fUserDlg = new frmUserDlg();
					fUserDlg.Mode = "Edit";
					fUserDlg.UserID = intUserID;
					fUserDlg.ContactID = intContactID;
					fUserDlg.LoadData();
					fUserDlg.ShowDialog();
					fUserDlg.Close();
					fUserDlg.Dispose();
					fUserDlg = null;
				}
			}
			else if (strMenuOption == "Contact...")
			{
				int Row = fContact.gvwContact.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fContact.gvwContact.GetRowCellValue(fContact.gvwContact.FocusedRowHandle, fContact.gcolContactID).ToString());

					frmContactDlg fContDlg = new frmContactDlg();
					fContDlg.Mode = "Edit";
					fContDlg.ContactID = intID;
					fContDlg.LoadData();
					fContDlg.ShowDialog();
					fContDlg.Close();
					fContDlg.Dispose();
					fContDlg = null;
				}
			}
			else if (strMenuOption == "Instructor...")
			{
				int Row = fContact.gvwContact.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fContact.gvwContact.GetRowCellValue(fContact.gvwContact.FocusedRowHandle, fContact.gcolContactID).ToString());

					frmInstructorDlg fInstructorDlg = new frmInstructorDlg();
					fInstructorDlg.Mode = "Edit";
					fInstructorDlg.ContactID = intID;
					fInstructorDlg.LoadData();
					fInstructorDlg.ShowDialog();
					fInstructorDlg.Close();
					fInstructorDlg.Dispose();
					fInstructorDlg = null;
				}
			}
			else if (strMenuOption == "Client...")
			{
				int Row = fContact.gvwContact.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fContact.gvwContact.GetRowCellValue(fContact.gvwContact.FocusedRowHandle, fContact.gcolContactID).ToString());

					frmClientDlg fClientDlg = new frmClientDlg();
					fClientDlg.Mode = "Edit";
					fClientDlg.ContactID = intID;
					fClientDlg.LoadData();
					fClientDlg.ShowDialog();
					fClientDlg.Close();
					fClientDlg.Dispose();
					fClientDlg = null;
				}
			}
			else if (strMenuOption == "Department...")
			{
				int Row = fDept.gvwDept.FocusedRowHandle;

				if (Row >= 0)
				{
					int intDeptID =
						Convert.ToInt32(fDept.gvwDept.GetRowCellValue(fDept.gvwDept.FocusedRowHandle, fDept.gColDeptID).ToString());
					int intContactID =
						Convert.ToInt32(fDept.gvwDept.GetRowCellValue(fDept.gvwDept.FocusedRowHandle, fDept.gColContactID).ToString());

					frmDepartmentDlg fDeptDlg = new frmDepartmentDlg();
					fDeptDlg.Mode = "Edit";
					fDeptDlg.DeptID = intDeptID;
					fDeptDlg.ContactID = intContactID;
					fDeptDlg.LoadData();
					fDeptDlg.ShowDialog();
					fDeptDlg.Close();
					fDeptDlg.Dispose();
					fDeptDlg = null;
				}
			}
			else if (strMenuOption == "Program...")
			{
				int Row = fProgram.gvwProgram.FocusedRowHandle;

				if (Row >= 0)
				{
					int intProgID =
						Convert.ToInt32(
							fProgram.gvwProgram.GetRowCellValue(fProgram.gvwProgram.FocusedRowHandle, fProgram.gcolProgID).ToString());

					frmProgramDlg fProgDlg = new frmProgramDlg(intProgID);
					fProgDlg.Mode = "Edit";
					fProgDlg.LoadData();
					fProgDlg.ShowDialog();
					fProgDlg.Close();
					fProgDlg.Dispose();
					fProgDlg = null;
				}
			}
			else if (strMenuOption == "Class...")
			{
				int Row = fCourse.gvwCourse.FocusedRowHandle;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fCourse.gvwCourse.GetRowCellValue(fCourse.gvwCourse.FocusedRowHandle, fCourse.gcolCourseID).ToString());

					frmClassDlg fClassDlg = new frmClassDlg();
					fClassDlg.Mode = "Edit";
					fClassDlg.CourseID = intID;
					fClassDlg.LoadData();
					fClassDlg.ShowDialog();
					fClassDlg.Close();
					fClassDlg.Dispose();
					fClassDlg = null;
				}
			}
			else if (strMenuOption == "Event...")
			{
				if (fEvt!=null)
				{
					int Row = fEvt.gvwEvent.FocusedRowHandle;

					if (Row >= 0)
					{
						bool IsRecur = false;
						int intID =
							Convert.ToInt32(fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.gcolEventID).ToString());
						int intCalID =
							Convert.ToInt32(fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.colCalendarEventID).ToString());

						if (fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.gcolIsRecur).ToString() != "")
							IsRecur = true;

						int Option = -1;

						if (IsRecur)
						{
							frmOpenEvents frmOpenEvt = new frmOpenEvents();
							if (frmOpenEvt.ShowDialog() == DialogResult.OK)
							{
								Option = frmOpenEvt.Option;
							}
							else
							{
								frmOpenEvt.Close();
								frmOpenEvt.Dispose();
								frmOpenEvt = null;
								return;
							}
						}
						//this part was copy-pasted from frmCalendar.cs we exit if no module linked to the event 
						string module = string.Empty;
						int _uid = 0;
						int _eventtypeindex = 0;
						Events objEvent = new Events();
						_uid = objEvent.GetEvent(intID, ref module, ref _eventtypeindex);
						if (module == "") {
							return;
						}
						//---
						
						frmEventDlg fEvtDlg = null;
						if (Option == 1)
						{
							fEvtDlg = new frmEventDlg(intID, intCalID);
							fEvtDlg.Mode = "Edit";
							fEvtDlg.EventID = intID;
							fEvtDlg.LoadData();
						}
						else
						{
							fEvtDlg = new frmEventDlg();
							fEvtDlg.Mode = "Edit";
							fEvtDlg.EventID = intID;
							fEvtDlg.LoadData();
						}

						if (fEvtDlg.ShowDialog() == DialogResult.OK)
						{
							fEvt.LoadEvent();
						}
						fEvtDlg.Close();
						fEvtDlg.Dispose();
						fEvtDlg = null;

						fEvt.gvwEvent.FocusedRowHandle = Row;
					}
				} else
				{
					
				}
			}
			else if (strMenuOption == "Calendar...")
			{
				if (fCalendar.schedulerControl1.SelectedAppointments.Count > 0)
				{
					Appointment apt = fCalendar.schedulerControl1.SelectedAppointments[0];
					bool IsRecur = false;

					controller = new AppointmentFormController(fCalendar.schedulerControl1, apt);

					int intCalID = Convert.ToInt32(controller.LabelId.ToString());
					int intEventID = Common.GetID("select EventID from CalendarEvent where CalendarEventID=" + intCalID.ToString());
					string strRecurrenceText =
						Common.GetString("select RecurrenceText from Event where EventID=" + intEventID.ToString());

					if (strRecurrenceText != "")
						IsRecur = true;

					int Option = -1;
					if (IsRecur)
					{
						frmOpenEvents frmOpenEvt = new frmOpenEvents();
						if (frmOpenEvt.ShowDialog() == DialogResult.OK)
						{
							Option = frmOpenEvt.Option;
						}
						else
						{
							frmOpenEvt.Close();
							frmOpenEvt.Dispose();
							frmOpenEvt = null;
							return;
						}
					}

					frmEventDlg fEvtDlg = null;
					if (Option == 1)
					{
						fEvtDlg = new frmEventDlg(intEventID, intCalID);
						fEvtDlg.Mode = "Edit";
						fEvtDlg.EventID = intEventID;
						fEvtDlg.LoadData();
					}
					else
					{
						fEvtDlg = new frmEventDlg();
						fEvtDlg.Mode = "Edit";
						fEvtDlg.EventID = intEventID;
						fEvtDlg.LoadData();
					}
					if (fEvtDlg.ShowDialog() == DialogResult.OK)
					{
						fCalendar.LoadCalendar();
					}
					fEvtDlg.Close();
					fEvtDlg.Dispose();
					fEvtDlg = null;
				}
			}
		}

		private void Delete()
		{
			if (strMenuOption == "User...")
			{
				int Row = fUser.gvwUser.FocusedRowHandle;
				if (Row >= 0)
				{
					int intUserID =
						Convert.ToInt32(fUser.gvwUser.GetRowCellValue(fUser.gvwUser.FocusedRowHandle, fUser.gcolUserID).ToString());
					int intContactID =
						Convert.ToInt32(fUser.gvwUser.GetRowCellValue(fUser.gvwUser.FocusedRowHandle, fUser.gcolContactID).ToString());

					if (Message.MsgDelete())
					{
						User objUser = new User();
						objUser.UserID = intUserID;
						objUser.ContactID = intContactID;
						if (!objUser.DeleteData())
						{
							Message.MsgWarning("User cannot be deleted");
							fUser.grdUser.Focus();
							return;
						}

						fUser.LoadUser();
						fUser.grdUser.Focus();
						fUser.gvwUser.FocusedRowHandle = Row - 1;
						if (fUser.gvwUser.RowCount > 0)
						{
							if (fUser.gvwUser.FocusedRowHandle < 0)
							{
								fUser.gvwUser.FocusedRowHandle = 0;
							}
						}
					}
				}
			}
			else if ((strMenuOption == "Contact...") || (strMenuOption == "Instructor...") || (strMenuOption == "Client..."))
			{
				string strtemp = "";
				int Row = fContact.gvwContact.FocusedRowHandle;
				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fContact.gvwContact.GetRowCellValue(fContact.gvwContact.FocusedRowHandle, fContact.gcolContactID).ToString());
					strtemp = strMenuOption;
					strtemp = strtemp.Replace("...", "");

					if (Message.MsgDelete())
					{
						Contact objContact = new Contact();
						objContact.ContactID = intID;
						//objContact.DeleteData();
						if (!objContact.DeleteData())
						{
							Message.MsgWarning(strtemp + " cannot be deleted");
							fContact.grdContact.Focus();
							return;
						}

						fContact.LoadContact(strtemp);
						fContact.grdContact.Focus();
						fContact.gvwContact.FocusedRowHandle = Row - 1;
						if (fContact.gvwContact.RowCount > 0)
						{
							if (fContact.gvwContact.FocusedRowHandle < 0)
							{
								fContact.gvwContact.FocusedRowHandle = 0;
							}
						}
					}
				}
			}
			else if (strMenuOption == "Department...")
			{
				int Row = fDept.gvwDept.FocusedRowHandle;
				if (Row >= 0)
				{
					int intDeptID =
						Convert.ToInt32(fDept.gvwDept.GetRowCellValue(fDept.gvwDept.FocusedRowHandle, fDept.gColDeptID).ToString());
					int intContactID =
						Convert.ToInt32(fDept.gvwDept.GetRowCellValue(fDept.gvwDept.FocusedRowHandle, fDept.gColContactID).ToString());

					if (Message.MsgDelete())
					{
						Department objDept = new Department();
						objDept.DeptID = intDeptID;
						objDept.ContactID = intContactID;
						//objDept.DeleteData();
						if (!objDept.DeleteData())
						{
							Message.MsgWarning("Department cannot be deleted");
							fDept.grdDept.Focus();
							return;
						}

						fDept.LoadDepartment();
						fDept.grdDept.Focus();
						fDept.gvwDept.FocusedRowHandle = Row - 1;
						if (fDept.gvwDept.RowCount > 0)
						{
							if (fDept.gvwDept.FocusedRowHandle < 0)
							{
								fDept.gvwDept.FocusedRowHandle = 0;
							}
						}
					}
				}
			}
			else if (strMenuOption == "Program...")
			{
				int Row = fProgram.gvwProgram.FocusedRowHandle;
				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fProgram.gvwProgram.GetRowCellValue(fProgram.gvwProgram.FocusedRowHandle, fProgram.gcolProgID).ToString());

					if (Message.MsgDelete())
					{
						Program objProg = new Program();
						objProg.ProgramID = intID;
						//objProg.DeleteData();
						if (!objProg.DeleteData())
						{
							Message.MsgWarning("Program cannot be deleted");
							fProgram.grdProgram.Focus();
							return;
						}

						fProgram.LoadProgram();
						fProgram.grdProgram.Focus();
						fProgram.gvwProgram.FocusedRowHandle = Row - 1;
						if (fProgram.gvwProgram.RowCount > 0)
						{
							if (fProgram.gvwProgram.FocusedRowHandle < 0)
							{
								fProgram.gvwProgram.FocusedRowHandle = 0;
							}
						}
					}
				}
			}
			else if (strMenuOption == "Class...")
			{
				int Row = fCourse.gvwCourse.FocusedRowHandle;
				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(
							fCourse.gvwCourse.GetRowCellValue(fCourse.gvwCourse.FocusedRowHandle, fCourse.gcolCourseID).ToString());

					if (Message.MsgDelete())
					{
						Course objCourse = new Course();
						objCourse.CourseID = intID;
						//objCourse.DeleteData();
						if (!objCourse.DeleteData())
						{
							Message.MsgWarning("Class cannot be deleted");
							fCourse.grdCourse.Focus();
							return;
						}

						fCourse.LoadCourse();
						fCourse.grdCourse.Focus();
						fCourse.gvwCourse.FocusedRowHandle = Row - 1;
						if (fCourse.gvwCourse.RowCount > 0)
						{
							if (fCourse.gvwCourse.FocusedRowHandle < 0)
							{
								fCourse.gvwCourse.FocusedRowHandle = 0;
							}
						}
					}
				}
			}
			else if (strMenuOption == "Event...")
			{
				int Row = fEvt.gvwEvent.FocusedRowHandle;
				bool IsRecur = false;

				if (Row >= 0)
				{
					int intID =
						Convert.ToInt32(fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.gcolEventID).ToString());
					int intCalID =
						Convert.ToInt32(fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.colCalendarEventID).ToString());
                    int CourseID = Convert.ToInt32(fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.gcolCourseId).ToString());

					if (fEvt.gvwEvent.GetRowCellValue(fEvt.gvwEvent.FocusedRowHandle, fEvt.gcolIsRecur).ToString() != "")
						IsRecur = true;

					if (IsRecur)
					{
						frmDeleteEvents frmDelEvt = new frmDeleteEvents(intID, intCalID);
						if (frmDelEvt.ShowDialog() == DialogResult.OK)
						{
							fEvt.LoadEvent();
							fEvt.grdEvent.Focus();
							fEvt.gvwEvent.FocusedRowHandle = Row - 1;
							if (fEvt.gvwEvent.RowCount > 0)
							{
								if (fEvt.gvwEvent.FocusedRowHandle < 0)
									fEvt.gvwEvent.FocusedRowHandle = 0;
							}
						}
						frmDelEvt.Close();
						frmDelEvt.Dispose();
						frmDelEvt = null;
					}
					else
					{
						if (Message.MsgDelete())
						{
							string strMess = "";
							Events evt = new Events();
							evt.EventID = intID;
							strMess = evt.CheckClassEvent();
							if (strMess == "") strMess = evt.CheckProgramEvent();

							if (strMess != "")
							{
								Message.MsgWarning("This Event is linked with" + strMess + ".\n\nEvent cannot be deleted.");
								return;
							}

							//evt.DeleteData(true);
                            if (evt.EventType=="Extra Class")
                                evt.DeleteSingleCalendarEvent();
                            else
                                evt.DeleteTestEvent("Course", CourseID);

                            fEvt.LoadEvent();
							fEvt.grdEvent.Focus();
							fEvt.gvwEvent.FocusedRowHandle = Row - 1;
							if (fEvt.gvwEvent.RowCount > 0)
								if (fEvt.gvwEvent.FocusedRowHandle < 0)
									fEvt.gvwEvent.FocusedRowHandle = 0;
						}
					}
				}
			}
			else if (strMenuOption == "Calendar...")
			{
				if (fCalendar.schedulerControl1.SelectedAppointments.Count > 0)
				{
					Appointment apt = fCalendar.schedulerControl1.SelectedAppointments[0];
					bool IsRecur = false;

					controller = new AppointmentFormController(fCalendar.schedulerControl1, apt);

					int intCalID = Convert.ToInt32(controller.LabelId.ToString());
					int intEventID = Common.GetID("select EventID from CalendarEvent where CalendarEventID=" + intCalID.ToString());
					string strRecurrenceText =
						Common.GetString("select RecurrenceText from Event where EventID=" + intEventID.ToString());

					if (strRecurrenceText != "")
						IsRecur = true;


					if (IsRecur)
					{
						frmDeleteEvents frmDelEvt = new frmDeleteEvents(intEventID, intCalID);
						if (frmDelEvt.ShowDialog() == DialogResult.OK)
						{
							fCalendar.LoadCalendar();
						}
						frmDelEvt.Close();
						frmDelEvt.Dispose();
						frmDelEvt = null;
					}
					else
					{
						if (Message.MsgDelete())
						{
							string strMess = "";
							Events evt = new Events();
							evt.EventID = intEventID;
							strMess = evt.CheckClassEvent();
							if (strMess == "") strMess = evt.CheckProgramEvent();

							if (strMess != "")
							{
								Message.MsgWarning("This Event is linked with" + strMess + ".\n\nEvent cannot be deleted.");
								return;
							}

							evt.DeleteData(true);
							fCalendar.LoadCalendar();
						}
					}
				}
			}
		}

		private bool GetConnectionString(string Server, string Database, string User, string Pwd)
		{
			string strconnstring;
			strconnstring = "Data Source=" + Server + ";" +
			                "Initial Catalog=" + Database + ";" +
			                "User ID=" + User + ";Password=" + Pwd + ";Trusted_Connection=False;";
			SqlConnection cn = new SqlConnection(strconnstring);
			try
			{
				cn.Open();
				Common.ConnString = strconnstring;
				Common.ConnString1 = strconnstring;
				cn.Close();
				cn.Dispose();
				cn = null;

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Couldnot connect to SQLServer" + "/n/n" + ex.Message, "Scheduler");
				return false;
			}
		}

		private void SetNavBarStyle()
		{
            navBar.Appearance.Reset();
            //navBar.Appearance.AddReplace("GroupBackground",
            //                         new ViewStyleEx("GroupBackground", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "", true, false, true,
            //                                         HorzAlignment.Center, VertAlignment.Center, null, SystemColors.ControlDark,
            //                                         Color.Black, Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("LinkDropTarget",
            //                         new ViewStyleEx("LinkDropTarget", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "", true, false, true,
            //                                         HorzAlignment.Center, VertAlignment.Center, null, Color.Black, Color.Black,
            //                                         Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("Button",
            //                         new ViewStyleEx("Button", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "", true, false, true,
            //                                         HorzAlignment.Center, VertAlignment.Center, null, SystemColors.Control,
            //                                         SystemColors.ControlText, Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("ItemPressed",
            //                         new ViewStyleEx("ItemPressed", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize + 1, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "Item",
            //                                         StyleOptions.StyleEnabled, true, true, false, HorzAlignment.Center,
            //                                         VertAlignment.Center, null, SystemColors.Control,
            //                                         SystemColors.ControlLightLight, Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("ItemDisabled",
            //                         new ViewStyleEx("ItemDisabled", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize + 1, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "Item",
            //                                         ((StyleOptions) ((StyleOptions.StyleEnabled | StyleOptions.UseForeColor))),
            //                                         true, true, false, HorzAlignment.Center, VertAlignment.Center, null,
            //                                         SystemColors.Control, SystemColors.ControlDarkDark, Color.Empty,
            //                                         LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("ButtonPressed",
            //                         new ViewStyleEx("ButtonPressed", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "Button",
            //                                         StyleOptions.StyleEnabled, true, false, true, HorzAlignment.Center,
            //                                         VertAlignment.Center, null, SystemColors.Control, SystemColors.ControlText,
            //                                         Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("GroupHeaderActive",
            //                         new ViewStyleEx("GroupHeaderActive", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "GroupHeader",
            //                                         StyleOptions.StyleEnabled, true, false, true, HorzAlignment.Center,
            //                                         VertAlignment.Center, null, SystemColors.Control, SystemColors.ControlText,
            //                                         Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("GroupHeaderPressed",
            //                         new ViewStyleEx("GroupHeaderPressed", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "GroupHeader",
            //                                         StyleOptions.StyleEnabled, true, false, true, HorzAlignment.Center,
            //                                         VertAlignment.Center, null, SystemColors.Control, SystemColors.ControlText,
            //                                         Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("GroupHeader",
            //                         new ViewStyleEx("GroupHeader", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "", true, false, true,
            //                                         HorzAlignment.Center, VertAlignment.Center, null, SystemColors.Control,
            //                                         SystemColors.ControlText, Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("Hint",
            //                         new ViewStyleEx("Hint", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "", true, true, false,
            //                                         HorzAlignment.Near, VertAlignment.Center, null, SystemColors.Info,
            //                                         SystemColors.InfoText, Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("GroupHeaderHotTracked",
            //                         new ViewStyleEx("GroupHeaderHotTracked", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "GroupHeader",
            //                                         StyleOptions.StyleEnabled, true, false, true, HorzAlignment.Center,
            //                                         VertAlignment.Center, null, SystemColors.Control, SystemColors.ControlText,
            //                                         Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("ButtonHotTracked",
            //                         new ViewStyleEx("ButtonHotTracked", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "Button",
            //                                         StyleOptions.StyleEnabled, true, false, true, HorzAlignment.Center,
            //                                         VertAlignment.Center, null, SystemColors.Control, SystemColors.ControlText,
            //                                         Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("ItemHotTracked",
            //                         new ViewStyleEx("ItemHotTracked", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize + 1, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "Item",
            //                                         StyleOptions.StyleEnabled, true, true, false, HorzAlignment.Center,
            //                                         VertAlignment.Center, null, SystemColors.Control,
            //                                         SystemColors.ControlLightLight, Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("Item",
            //                         new ViewStyleEx("Item", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "", true, true, false,
            //                                         HorzAlignment.Center, VertAlignment.Center, null, SystemColors.Control,
            //                                         SystemColors.ControlLightLight, Color.Empty, LinearGradientMode.Horizontal));
            //navBar.Styles.AddReplace("Background",
            //                         new ViewStyleEx("Background", "NavBarControl",
            //                                         new Font(Common.FontName, Common.FontSize, FontStyle.Regular,
            //                                                  GraphicsUnit.Point, ((Byte) (0))), "", true, false, false,
            //                                         HorzAlignment.Center, VertAlignment.Center, null, SystemColors.ControlDark,
            //                                         SystemColors.ControlDark, Color.Empty, LinearGradientMode.Horizontal));

			lblTitle.Font = new Font(Common.FontName, Common.FontSize + 4, FontStyle.Bold, GraphicsUnit.Point, ((Byte) (0)));
			sbarMain.Font = new Font(Common.FontName, Common.FontSize, FontStyle.Regular, GraphicsUnit.Point, ((Byte) (0)));
			tBarMain.Font = new Font(Common.FontName, Common.FontSize, FontStyle.Regular, GraphicsUnit.Point, ((Byte) (0)));

			_dockingManager.CaptionFont =
				new Font(Common.FontName, Common.FontSize, FontStyle.Regular, GraphicsUnit.Point, ((Byte) (0)));


			Refresh();
		}

		private void nBarDay_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("DayCalendar");
		}

		private void nBarWeek_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("WeekCalendar");
		}

		private void nBarMonth_LinkClicked(object sender, NavBarLinkEventArgs e)
		{
			Focus();
			OpenBrowse("MonthCalendar");
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
            DrawTopLabel(g);
           
			bool more = dataGridPrinter1.DrawDataGrid(g);
			if (more == true)
			{
				e.HasMorePages = true;
				dataGridPrinter1.PageNumber++;
			}
		}

		private void DrawTopLabel(Graphics g)
		{
			string s = strMenuOption;
			s = s.Replace(".", " ");
			Font _font =
				new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Point, ((Byte) (0)));
			g.DrawString(s, _font, new SolidBrush(Color.Blue), 10, 20, new StringFormat());
		}

        private void nBarInstructorPayroll_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            
        }

        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Focus();
            OpenBrowse("InstructorPayment");
        }

        private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Focus();
            OpenBrowse("InstructorPayroll");
        }

        private void navBarTransportationExpenses_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Focus();
            OpenBrowse("TransportationExpenses");
        }
	}
}