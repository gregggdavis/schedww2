using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Forms;
using DevExpress.XtraScheduler.Printing;
using DevExpress.XtraScheduler.UI;
using Scheduler.BusinessLayer;
using Message = Scheduler.BusinessLayer.Message;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraPrinting.Design;
using DevExpress.XtraPrinting;
using System.Text;

namespace Scheduler {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmCalendar : Form {
		#region Controls 
		private SchedulerStorage schedulerStorage1;
		public Panel pnlBody;
		public SchedulerControl schedulerControl1;
		private IContainer components;
		private Panel pnlCalendar;
		public Panel pnlDateNavigator;
		private DateNavigator dateNavigator1;
		private ImageList imgContext;
		private Panel pnlFilter;

		private AppointmentFormController controller;
		public ComboBox cmbClient;
		private Label lblClient;
		public ComboBox cmbInstructor;
		private Label lblInstructor;
		public ComboBox cmbClass;
		private Label lblClass;
		public ComboBox cmbProgram;
		private Label lblProgram;
		private bool isProcess = false;
		private Splitter splitter1;
		private frmMain fMain = null;
		private Button btnClearFilters;
		private DateTimePicker EndDatePickerTop;
		private DateTimePicker StartDatePickerTop;
		private Label lblMonth;
		private Label lblYear;
		private CultureInfo culture = null;
        private DevExpress.XtraEditors.CheckEdit chkHideWeekends;
        private bool IsAllow = false;
		#endregion Controls


		public frmCalendar() {
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
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
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
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.Printing.DailyPrintStyle dailyPrintStyle1 = new DevExpress.XtraScheduler.Printing.DailyPrintStyle();
            DevExpress.XtraScheduler.Printing.WeeklyPrintStyle weeklyPrintStyle1 = new DevExpress.XtraScheduler.Printing.WeeklyPrintStyle();
            DevExpress.XtraScheduler.Printing.MonthlyPrintStyle monthlyPrintStyle1 = new DevExpress.XtraScheduler.Printing.MonthlyPrintStyle();
            DevExpress.XtraScheduler.Printing.TriFoldPrintStyle triFoldPrintStyle1 = new DevExpress.XtraScheduler.Printing.TriFoldPrintStyle();
            DevExpress.XtraScheduler.Printing.CalendarDetailsPrintStyle calendarDetailsPrintStyle1 = new DevExpress.XtraScheduler.Printing.CalendarDetailsPrintStyle();
            DevExpress.XtraScheduler.Printing.MemoPrintStyle memoPrintStyle1 = new DevExpress.XtraScheduler.Printing.MemoPrintStyle();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendar));
            this.StartDatePickerTop = new System.Windows.Forms.DateTimePicker();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.pnlBody = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.EndDatePickerTop = new System.Windows.Forms.DateTimePicker();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.cmbProgram = new System.Windows.Forms.ComboBox();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbInstructor = new System.Windows.Forms.ComboBox();
            this.lblInstructor = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.pnlDateNavigator = new System.Windows.Forms.Panel();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.imgContext = new System.Windows.Forms.ImageList(this.components);
            this.chkHideWeekends = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlDateNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHideWeekends.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // StartDatePickerTop
            // 
            this.StartDatePickerTop.Checked = false;
            this.StartDatePickerTop.CustomFormat = "MM/dd/yyyy";
            this.StartDatePickerTop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePickerTop.Location = new System.Drawing.Point(190, 9);
            this.StartDatePickerTop.Name = "StartDatePickerTop";
            this.StartDatePickerTop.ShowCheckBox = true;
            this.StartDatePickerTop.Size = new System.Drawing.Size(96, 21);
            this.StartDatePickerTop.TabIndex = 15;
            this.StartDatePickerTop.ValueChanged += new System.EventHandler(this.datePickerTop_ValueChanged);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.Mappings.Description = "Status";
            this.schedulerStorage1.Appointments.Mappings.End = "ENDDATETIME";
            this.schedulerStorage1.Appointments.Mappings.Label = "CEID";
            this.schedulerStorage1.Appointments.Mappings.Start = "STARTDATETIME";
            this.schedulerStorage1.Appointments.Mappings.Subject = "TASKDESC";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.splitter1);
            this.pnlBody.Controls.Add(this.pnlCalendar);
            this.pnlBody.Controls.Add(this.pnlDateNavigator);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(976, 622);
            this.pnlBody.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(789, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 622);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Controls.Add(this.schedulerControl1);
            this.pnlCalendar.Controls.Add(this.pnlFilter);
            this.pnlCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalendar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCalendar.Location = new System.Drawing.Point(0, 0);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(792, 622);
            this.pnlCalendar.TabIndex = 2;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.Appearance.Appointment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Appearance.Appointment.Options.UseFont = true;
            this.schedulerControl1.Appearance.Selection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Appearance.Selection.Options.UseFont = true;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Location = new System.Drawing.Point(0, 64);
            this.schedulerControl1.Name = "schedulerControl1";
            dailyPrintStyle1.CalendarHeaderVisible = false;
            weeklyPrintStyle1.CalendarHeaderVisible = false;
            monthlyPrintStyle1.CalendarHeaderVisible = false;
            triFoldPrintStyle1.CalendarHeaderVisible = false;
            this.schedulerControl1.PrintStyles.AddRange(new DevExpress.XtraScheduler.Printing.SchedulerPrintStyle[] {
            dailyPrintStyle1,
            weeklyPrintStyle1,
            monthlyPrintStyle1,
            triFoldPrintStyle1,
            calendarDetailsPrintStyle1,
            memoPrintStyle1});
            this.schedulerControl1.Size = new System.Drawing.Size(792, 558);
            this.schedulerControl1.Start = new System.DateTime(2006, 3, 6, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 1;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.Appearance.AllDayArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.DayView.Appearance.AllDayArea.Options.UseFont = true;
            this.schedulerControl1.Views.DayView.Appearance.AlternateHeaderCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.DayView.Appearance.AlternateHeaderCaption.Options.UseFont = true;
            this.schedulerControl1.Views.DayView.Appearance.Appointment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.DayView.Appearance.Appointment.Options.UseFont = true;
            this.schedulerControl1.Views.DayView.Appearance.HeaderCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.DayView.Appearance.HeaderCaption.Options.UseFont = true;
            this.schedulerControl1.Views.DayView.Appearance.Selection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.DayView.Appearance.Selection.Options.UseFont = true;
            this.schedulerControl1.Views.DayView.Appearance.TimeRuler.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.DayView.Appearance.TimeRuler.Options.UseFont = true;
            this.schedulerControl1.Views.DayView.Appearance.TimeRulerNowArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.DayView.Appearance.TimeRulerNowArea.Options.UseFont = true;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.Options.UseFont = true;
            this.schedulerControl1.Views.WeekView.Appearance.CellHeaderCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.WeekView.Appearance.CellHeaderCaption.Options.UseFont = true;
            this.schedulerControl1.Views.WeekView.Appearance.CellHeaderCaptionLine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.WeekView.Appearance.CellHeaderCaptionLine.Options.UseFont = true;
            this.schedulerControl1.Views.WeekView.Appearance.HeaderCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.WeekView.Appearance.HeaderCaption.Options.UseFont = true;
            this.schedulerControl1.Views.WeekView.Appearance.HeaderCaptionLine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.WeekView.Appearance.HeaderCaptionLine.Options.UseFont = true;
            this.schedulerControl1.Views.WeekView.Appearance.Selection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schedulerControl1.Views.WeekView.Appearance.Selection.Options.UseFont = true;
            this.schedulerControl1.Views.WorkWeekView.ShowFullWeek = true;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Click += new System.EventHandler(this.schedulerControl1_Click);
            this.schedulerControl1.CustomDrawAppointment += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointment);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl_EditAppointmentFormShowing);
            this.schedulerControl1.AppointmentViewInfoCustomizing += new DevExpress.XtraScheduler.AppointmentViewInfoCustomizingEventHandler(this.schedulerControl1_AppointmentViewInfoCustomizing);
            this.schedulerControl1.PreparePopupMenu += new DevExpress.XtraScheduler.PreparePopupMenuEventHandler(this.OnPreparePopupMenu);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.GrayText;
            this.pnlFilter.Controls.Add(this.chkHideWeekends);
            this.pnlFilter.Controls.Add(this.lblMonth);
            this.pnlFilter.Controls.Add(this.lblYear);
            this.pnlFilter.Controls.Add(this.EndDatePickerTop);
            this.pnlFilter.Controls.Add(this.StartDatePickerTop);
            this.pnlFilter.Controls.Add(this.btnClearFilters);
            this.pnlFilter.Controls.Add(this.cmbClass);
            this.pnlFilter.Controls.Add(this.lblClass);
            this.pnlFilter.Controls.Add(this.cmbProgram);
            this.pnlFilter.Controls.Add(this.lblProgram);
            this.pnlFilter.Controls.Add(this.cmbInstructor);
            this.pnlFilter.Controls.Add(this.lblInstructor);
            this.pnlFilter.Controls.Add(this.cmbClient);
            this.pnlFilter.Controls.Add(this.lblClient);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(792, 64);
            this.pnlFilter.TabIndex = 3;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(120, 40);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(57, 13);
            this.lblMonth.TabIndex = 19;
            this.lblMonth.Text = "End Date";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(120, 13);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(66, 13);
            this.lblYear.TabIndex = 18;
            this.lblYear.Text = "Start Date";
            // 
            // EndDatePickerTop
            // 
            this.EndDatePickerTop.Checked = false;
            this.EndDatePickerTop.CustomFormat = "MM/dd/yyyy";
            this.EndDatePickerTop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDatePickerTop.Location = new System.Drawing.Point(190, 37);
            this.EndDatePickerTop.Name = "EndDatePickerTop";
            this.EndDatePickerTop.ShowCheckBox = true;
            this.EndDatePickerTop.Size = new System.Drawing.Size(96, 21);
            this.EndDatePickerTop.TabIndex = 17;
            this.EndDatePickerTop.ValueChanged += new System.EventHandler(this.datePickerTop_ValueChanged);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.Location = new System.Drawing.Point(10, 7);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(104, 23);
            this.btnClearFilters.TabIndex = 13;
            this.btnClearFilters.Text = "Clear All Filters";
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ItemHeight = 13;
            this.cmbClass.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbClass.Location = new System.Drawing.Point(584, 35);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(144, 21);
            this.cmbClass.TabIndex = 12;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(512, 39);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(36, 13);
            this.lblClass.TabIndex = 11;
            this.lblClass.Text = "Class";
            // 
            // cmbProgram
            // 
            this.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgram.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbProgram.Location = new System.Drawing.Point(584, 9);
            this.cmbProgram.Name = "cmbProgram";
            this.cmbProgram.Size = new System.Drawing.Size(144, 21);
            this.cmbProgram.TabIndex = 10;
            this.cmbProgram.SelectedIndexChanged += new System.EventHandler(this.cmbProgram_SelectedIndexChanged);
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgram.Location = new System.Drawing.Point(512, 12);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(56, 13);
            this.lblProgram.TabIndex = 9;
            this.lblProgram.Text = "Program";
            // 
            // cmbInstructor
            // 
            this.cmbInstructor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInstructor.ItemHeight = 13;
            this.cmbInstructor.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbInstructor.Location = new System.Drawing.Point(364, 34);
            this.cmbInstructor.Name = "cmbInstructor";
            this.cmbInstructor.Size = new System.Drawing.Size(131, 21);
            this.cmbInstructor.TabIndex = 8;
            this.cmbInstructor.SelectedIndexChanged += new System.EventHandler(this.cmbInstructor_SelectedIndexChanged);
            // 
            // lblInstructor
            // 
            this.lblInstructor.AutoSize = true;
            this.lblInstructor.BackColor = System.Drawing.SystemColors.GrayText;
            this.lblInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructor.Location = new System.Drawing.Point(292, 38);
            this.lblInstructor.Name = "lblInstructor";
            this.lblInstructor.Size = new System.Drawing.Size(65, 13);
            this.lblInstructor.TabIndex = 7;
            this.lblInstructor.Text = "Instructor";
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbClient.Location = new System.Drawing.Point(364, 8);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(131, 21);
            this.cmbClient.TabIndex = 6;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.Location = new System.Drawing.Point(292, 11);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 5;
            this.lblClient.Text = "Client";
            // 
            // pnlDateNavigator
            // 
            this.pnlDateNavigator.Controls.Add(this.dateNavigator1);
            this.pnlDateNavigator.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDateNavigator.Location = new System.Drawing.Point(792, 0);
            this.pnlDateNavigator.Name = "pnlDateNavigator";
            this.pnlDateNavigator.Size = new System.Drawing.Size(184, 622);
            this.pnlDateNavigator.TabIndex = 4;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.Size = new System.Drawing.Size(184, 622);
            this.dateNavigator1.TabIndex = 0;
            this.dateNavigator1.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo;
            // 
            // imgContext
            // 
            this.imgContext.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgContext.ImageStream")));
            this.imgContext.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imgContext.Images.SetKeyName(0, "");
            this.imgContext.Images.SetKeyName(1, "");
            // 
            // chkHideWeekends
            // 
            this.chkHideWeekends.Location = new System.Drawing.Point(13, 34);
            this.chkHideWeekends.Name = "chkHideWeekends";
            this.chkHideWeekends.Properties.Caption = "Hide Weekends";
            this.chkHideWeekends.Size = new System.Drawing.Size(101, 19);
            this.chkHideWeekends.TabIndex = 20;
            this.chkHideWeekends.CheckedChanged += new System.EventHandler(this.chkHideWeekends_CheckedChanged);
            // 
            // frmCalendar
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(976, 622);
            this.Controls.Add(this.pnlBody);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCalendar";
            this.Text = "Scheduler Calendar";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlCalendar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlDateNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHideWeekends.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private string _viewModeName;
		
		public void PopulateDropDowns() {
            Common.PopulateDropdownWithValue(
				cmbClient, "Select CompanyName, DisplayName = CASE " +
				"WHEN NickName IS NULL THEN CompanyName " +
				"WHEN NickName = '' THEN CompanyName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=2 and " +
				"ContactStatus=0 Order By DisplayName ");

            Common.PopulateDropdownWithValue(
                cmbInstructor, "Select LastName + ', ' + FirstName, " +
				"TeacherName = CASE " +
				"WHEN NickName IS NULL THEN LastName + ', ' + FirstName " +
				"WHEN NickName = '' THEN LastName + ', ' + FirstName " +
				"ELSE NickName " +
				"END From " +
				"Contact Where ContactType=1 and " +
				"ContactStatus=0 Order By LastName, FirstName ");

            Common.PopulateDropdownWithValue(
                cmbClass, "Select Distinct [Name], ClassName = CASE " +
				"WHEN NickName IS NULL THEN Name " +
				"WHEN NickName = '' THEN Name " +
				"ELSE NickName " +
				"END " +
				"From Course Where CourseStatus=0 " +  //and ProgramID=" + intProgramID + 
				" Order By ClassName ");

            Common.PopulateDropdownWithValue(
                cmbProgram, "Select Distinct [Name], ProgramName = CASE " +
				"WHEN NickName IS NULL THEN Name " +
				"WHEN NickName = '' THEN Name " +
				"ELSE NickName " +
				"END " +
				"From Program Where ProgramStatus=0 " +// and DepartmentID=" + intDepartmentID + 
				" Order By ProgramName ");

		}

		public void PositionDayCalendar() {
			pnlDateNavigator.Width = 188;
		}

		public void LoadCalendar(string strView) {
			_viewModeName = strView;
			culture = new CultureInfo(CultureInfo.CurrentCulture.LCID);
			culture.DateTimeFormat.ShortTimePattern = "H:mm";
			Thread.CurrentThread.CurrentCulture = culture;
			//schedulerControl1.Start = DateTime.Now;

			LoadFont(strView);
			isProcess = false;

			PopulateDropDowns();
			pnlDateNavigator.Hide();
			if (strView == "Day") {
				schedulerControl1.ActiveViewType = SchedulerViewType.Day;
				pnlDateNavigator.Show();
			} else if (strView == "Week") {
				schedulerControl1.ActiveViewType = SchedulerViewType.WorkWeek;
				pnlCalendar.Dock = DockStyle.Fill;
			} else if (strView == "Month") {
				schedulerControl1.ActiveViewType = SchedulerViewType.Month;
				pnlCalendar.Dock = DockStyle.Fill;
				//we set hegiht of appointment and make it multiline
				//schedulerControl1.Views.MonthView.AppointmentHeight = 35;
				schedulerControl1.Views.MonthView.Appearance.Appointment.TextOptions.Assign(TextOptions.DefaultOptions);
			}
            isProcess = true;
		}

		public void LoadCalendar() {
			culture = new CultureInfo(CultureInfo.CurrentCulture.LCID);
			culture.DateTimeFormat.ShortTimePattern = "H:mm";
			Thread.CurrentThread.CurrentCulture = culture;
			//get dates from pickers or min/max if they are not checked TODO what for is CalendarFilter???
			DateTime startDate = DateTime.MinValue;
			if (StartDatePickerTop.Checked) {
				startDate = StartDatePickerTop.Value.Date;
			}
			DateTime endDate = DateTime.MaxValue;
			if (EndDatePickerTop.Checked) {
				endDate = EndDatePickerTop.Value.Date.AddDays(1).AddMilliseconds(-1);
			}
			
			//DataTable dtblEvents = FetchGridData(startDate, endDate, cmbClient.Text, cmbInstructor.Text, cmbProgram.Text, cmbClass.Text);
            DataTable dtblEvents = FetchGridData(startDate, endDate, ((ValuePair)cmbClient.SelectedItem).Value, ((ValuePair)cmbInstructor.SelectedItem).Value, cmbProgram.Text, cmbClass.Text);
			schedulerStorage1.Appointments.DataSource = dtblEvents;
			if (fMain != null) {
                if(dtblEvents != null)
				    fMain.EnableDisable(dtblEvents.Rows.Count > 0);
			}
		}

		private void OnPreparePopupMenu(object sender, PreparePopupMenuEventArgs e) {
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoToday);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoThisDay);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoDate);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.SwitchViewMenu);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.DeleteAppointment);
			e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAppointment);

			// Check if it's the default menu of a Scheduler.
			if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu) {
				// Find the "New Appointment" menu item and rename it.
				//				SchedulerMenuItem item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);
				//				if (item != null) item.Caption = "New...";

				SchedulerMenuItem item = e.Menu.GetMenuItemById(SchedulerMenuItemId.OpenAppointment);
				if (item != null) item.Caption = "Open...";

				//item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);
				//if (item != null) item.Caption = "New...";
			}


			DXMenuItem iDelete = new DXMenuItem("Delete...");

			if (schedulerControl1.SelectedAppointments.Count > 0) {
				e.Menu.Items.Add(iDelete);
				iDelete.Click += new EventHandler(iDelete_Click);
			}
		}

		private void iDelete_Click(object sender, EventArgs e) {
			if (schedulerControl1.SelectedAppointments.Count > 0) {
				Appointment apt = schedulerControl1.SelectedAppointments[0];
				bool IsRecur = false;

				controller = new AppointmentFormController(schedulerControl1, apt);

				//int intCalID = Convert.ToInt32(apt.GetValue(schedulerControl1.Storage,"CEID"));
				int intCalID = Convert.ToInt32(controller.LabelId.ToString());
				int intEventID = Common.GetID("select EventID from CalendarEvent where CalendarEventID=" + intCalID.ToString());
				string strRecurrenceText = Common.GetString("select RecurrenceText from Event where EventID=" + intEventID.ToString());

				if (strRecurrenceText != "")
					IsRecur = true;



				if (IsRecur) {
					frmDeleteEvents frmDelEvt = new frmDeleteEvents(intEventID, intCalID);
					if (frmDelEvt.ShowDialog() == DialogResult.OK) {
						schedulerStorage1.Appointments.DataSource = FetchGridData();

					}
					frmDelEvt.Close();
					frmDelEvt.Dispose();
				} else {
					if (Message.MsgDelete()) {
						string strMess;
						Events evt = new Events();
						evt.EventID = intEventID;
						strMess = evt.CheckClassEvent();
						if (strMess == "") strMess = evt.CheckProgramEvent();

						if (strMess != "") {
							Message.MsgWarning("This Event is linked with" + strMess + ".\n\nEvent cannot be deleted.");
							return;
						}

						evt.DeleteData(true);
						schedulerStorage1.Appointments.DataSource = FetchGridData();

					}
				}

			}
		}
		/// <summary>
		/// Loads Events without filters
		/// </summary>
		/// <returns>DataTable of events</returns>
		public DataTable FetchGridData() {
			return FetchGridData(DateTime.MinValue, DateTime.MaxValue, string.Empty, string.Empty, string.Empty, string.Empty);
		}
		/// <summary>
		/// Loads Events with filters
		/// </summary>
		/// <param name="dtStart">Start date</param>
		/// <param name="dtEnd">End Date</param>
		/// <param name="client">Client name</param>
		/// <param name="instructor">Instructor name</param>
		/// <param name="program">Programm name</param>
		/// <param name="course">Course Name</param>
		/// <returns></returns>
		public DataTable FetchGridData(DateTime dtStart, DateTime dtEnd, string client, string instructor, string program, string course) {
			Events evt = new Events();
			return evt.LoadCalendarData(dtStart, dtEnd, client, instructor, program, course);
		}

		private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
			Appointment apt = e.Appointment;

			controller = new AppointmentFormController(schedulerControl1, apt);
			// Required to open the recurrence form via context menu.
			bool isNewApp = schedulerStorage1.Appointments.IsNewAppointment(apt);

			if (isNewApp)
			{
				e.Handled = true;
				return;
			}

			frmEventDlg fEvtDlg = null;
			bool IsRecur = false;
            bool IsExtraClass = false;
			e.Handled = true;


			int intCalID = Convert.ToInt32(controller.LabelId.ToString());
			int intEventID = Common.GetID("select EventID from CalendarEvent where CalendarEventID=" + intCalID.ToString());
			string strRecurrenceText = Common.GetString("select RecurrenceText from Event where EventID=" + intEventID.ToString());
            IsExtraClass = apt.Subject.Contains("Extra Class");

			if (strRecurrenceText != "")
				IsRecur = true;

			int Option = -1;
			if (IsRecur)
			{
                if (!IsExtraClass)
                {
                    frmOpenEvents frmOpenEvt = new frmOpenEvents();
                    if (frmOpenEvt.ShowDialog() == DialogResult.OK)
                    {
                        Option = frmOpenEvt.Option;
                    }
                    else
                    {
                        e.Handled = true;
                        frmOpenEvt.Close();
                        frmOpenEvt.Dispose();
                        return;
                    }
                }

			}
			if (Option == 1)
			{
				//fEvtDlg=new frmEventDlg(intEventID, intCalID);
				//fEvtDlg.Mode="Edit";
				//fEvtDlg.EventID = intEventID;
				//fEvtDlg.LoadData();

				string module = string.Empty;
				int _uid;
				int _eventtypeindex = 0;
				Events objEvent = new Events();
				_uid = objEvent.GetEvent(intEventID, ref module, ref _eventtypeindex);

				if (module != "")
				{
					if (module == "Class")
					{
						frmClassDlg frm = new frmClassDlg(_uid, _eventtypeindex, intCalID);
                        frm.Mode = "Edit";
						if (frm.ShowDialog() == DialogResult.OK)
						{
							LoadCalendar();
							frm.Close();
							frm.Dispose();
						}
					}
					else if (module == "Program")
					{
						frmProgramDlg frm = new frmProgramDlg(_uid, _eventtypeindex, intCalID);
                        frm.Mode = "Edit";
						if (frm.ShowDialog() == DialogResult.OK)
						{
							LoadCalendar();
							frm.Close();
							frm.Dispose();
						}
					}
				}
				else
				{
					fEvtDlg = new frmEventDlg();
					fEvtDlg.Mode = "Edit";
					fEvtDlg.EventID = intEventID;
					fEvtDlg.LoadData();
				}
			}
			else
			{
				string module = string.Empty;
				int _uid;
				int _eventtypeindex = 0;
				Events objEvent = new Events();
				_uid = objEvent.GetEvent(intEventID, ref module, ref _eventtypeindex);
                if (IsExtraClass) _eventtypeindex = 4;

				if (module != "")
				{
					if (module == "Class")
					{
						frmClassDlg frm = new frmClassDlg(_uid, _eventtypeindex);
                        frm.Mode = "Edit";
						if (frm.ShowDialog() == DialogResult.OK)
						{
							LoadCalendar();
							frm.Close();
							frm.Dispose();

						}
					}
					else if (module == "Program")
					{
						frmProgramDlg frm = new frmProgramDlg(_uid, _eventtypeindex);
                        frm.Mode = "Edit";
						if (frm.ShowDialog() == DialogResult.OK)
						{
							LoadCalendar();
							frm.Close();
							frm.Dispose();

						}
					}
				}
			}
            /*
			if (fEvtDlg != null)
			{
				if (fEvtDlg.ShowDialog() == DialogResult.OK)
				{
					schedulerStorage1.Appointments.DataSource = FetchGridData();
					e.Handled = true;
				}
				e.Handled = true;
				fEvtDlg.Close();
				fEvtDlg.Dispose();
			}*/
		}

		private void cmbClient_SelectedIndexChanged(object sender, EventArgs e) {
            if (IsAllow) CalendarFilter.ClientIndex = cmbClient.SelectedIndex;
			if (isProcess) {
				LoadCalendar();
			}
		}

		private void cmbInstructor_SelectedIndexChanged(object sender, EventArgs e) {
            if (IsAllow) CalendarFilter.InstructorIndex = cmbInstructor.SelectedIndex;
			if (isProcess) {
				LoadCalendar();
			}
		}

		private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e) {
            if (IsAllow)
            {
                CalendarFilter.ProgramIndex = cmbProgram.SelectedIndex;
                CalendarFilter.ProgramName = cmbProgram.Text;
                
                
            }
			if (isProcess) {
				LoadCalendar();
			}
		}

		private void cmbClass_SelectedIndexChanged(object sender, EventArgs e) {
            if (IsAllow)
            {
                CalendarFilter.ClassIndex = cmbClass.SelectedIndex;
                CalendarFilter.ClassName = cmbClass.Name;
            }
			if (isProcess) {
				LoadCalendar();
			}
		}

		public void LoadFilterSettings() {
            //if (_viewModeName == "Day")
            //{
            //    chkHideWeekends.Checked = CalendarFilter.DailyHideWeekends;
            //}
            //else if (_viewModeName == "Week")
            //{
            //    chkHideWeekends.Checked = CalendarFilter.WeeklyHideWeekends;
            //}
            //else if (_viewModeName == "Month")
            {
                chkHideWeekends.Checked = CalendarFilter.MonthlyHideWeekends;
            }
            
			isProcess = false;
            IsAllow = false;

			if (CalendarFilter.StartDate != DateTime.MinValue)
			{
				StartDatePickerTop.Value = CalendarFilter.StartDate;
				StartDatePickerTop.Checked = true;
			}
			else
			{
				StartDatePickerTop.Checked = false;
			}

			if (CalendarFilter.EndDate != DateTime.MaxValue)
			{
				EndDatePickerTop.Value = CalendarFilter.EndDate;
				EndDatePickerTop.Checked = true;
			}
			else
			{
				EndDatePickerTop.Checked = false;
			}
            IsAllow = true;

			if (CalendarFilter.ClientIndex >= 0) cmbClient.SelectedIndex = CalendarFilter.ClientIndex;
			if (CalendarFilter.InstructorIndex >= 0) cmbInstructor.SelectedIndex = CalendarFilter.InstructorIndex;
			if (CalendarFilter.ProgramIndex >= 0) cmbProgram.SelectedIndex = CalendarFilter.ProgramIndex;
			if (CalendarFilter.ClassIndex >= 0) cmbClass.SelectedIndex = CalendarFilter.ClassIndex;

			LoadCalendar();

			isProcess = true;
            
		}

		public void LoadMain(frmMain f)
        {
			fMain = f;
            IsAllow = false;
		}

		private void frmCalendar_Load(object sender, EventArgs e) {
			
		}

		private void LoadFont(string strView) {
			if (Common.FontName == "") return;
			if (Common.FontSize <= 0) return;
			Font f = new Font(Common.FontName, Common.FontSize);


			schedulerControl1.Appearance.Appointment.Font = f;
			schedulerControl1.Appearance.HeaderCaption.Font = f;
			schedulerControl1.Appearance.Selection.Font = f;

			if (strView == "Day") {
				schedulerControl1.DayView.Appearance.Appointment.Font = f;
				schedulerControl1.DayView.Appearance.HeaderCaption.Font = f;
				schedulerControl1.DayView.Appearance.AlternateHeaderCaption.Font = f;
				schedulerControl1.DayView.Appearance.Selection.Font = f;
				schedulerControl1.DayView.Appearance.TimeRuler.Font = f;
			}

			if (strView == "Month") {
				schedulerControl1.MonthView.Appearance.Appointment.Font = f;
				schedulerControl1.MonthView.Appearance.CellHeaderCaption.Font = f;
				schedulerControl1.MonthView.Appearance.Selection.Font = f;
			}

			if (strView == "Week") {
				schedulerControl1.WeekView.Appearance.Appointment.Font = f;
				schedulerControl1.WeekView.Appearance.CellHeaderCaption.Font = f;
				schedulerControl1.WeekView.Appearance.Selection.Font = f;

                schedulerControl1.WorkWeekView.Appearance.Appointment.Font = f;
                schedulerControl1.WorkWeekView.Appearance.HeaderCaption.Font = f;
                schedulerControl1.WorkWeekView.Appearance.Selection.Font = f;

			}

			//schedulerControl1.Refresh();
		}

		private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbProgram.SelectedIndex = 0;
            CalendarFilter.ProgramIndex = 0;
            cmbClass.SelectedIndex = 0;
            CalendarFilter.ClassIndex = 0;
            cmbInstructor.SelectedIndex = 0;
            CalendarFilter.InstructorIndex = 0;
            cmbClient.SelectedIndex = 0;
            CalendarFilter.ClientIndex = 0;
            StartDatePickerTop.Checked = false;
            CalendarFilter.StartDate = DateTime.MinValue;
            EndDatePickerTop.Checked = false;
            CalendarFilter.EndDate = DateTime.MaxValue;
			CalendarFilter.ShowAll = true;
			if (isProcess) {
				LoadCalendar();
			}
		}

		public void Print() {
			try {
				//we change print styles
				foreach (SchedulerPrintStyle schedulerPrintStyle in schedulerControl1.PrintStyles)
                {
					PrintStyleWithAppointmentHeight printStyle = schedulerPrintStyle as PrintStyleWithAppointmentHeight;
					//we change print style
                    if (printStyle != null)
                    {
                        printStyle.CalendarHeaderVisible = false;
                            
                        if (StartDatePickerTop.Checked) printStyle.StartRangeDate = CalendarFilter.StartDate;
                        if (EndDatePickerTop.Checked) printStyle.EndRangeDate = CalendarFilter.EndDate;
                        
                    }
                    
                    PrintStyleWithResourceOptions printresources = schedulerPrintStyle as PrintStyleWithResourceOptions;
                    if (printresources != null)
                    {
                        printresources.CalendarHeaderVisible = false;
                        if (StartDatePickerTop.Checked) printresources.StartRangeDate = CalendarFilter.StartDate;
                        if (EndDatePickerTop.Checked) printresources.EndRangeDate = CalendarFilter.EndDate;                        
                        
                    }

                    
                    
                    Common.FontSize = 8.25f;
					schedulerPrintStyle.AppointmentFont = new Font(Common.FontName, Common.FontSize - 2);
					schedulerPrintStyle.HeadingsFont = new Font(Common.FontName, Common.FontSize);
					schedulerPrintStyle.PageSettings.Margins = new Margins(10, 10, 20, 20);
					schedulerPrintStyle.PageSettings.Landscape = true;
                    
                    
                    
//                    PrintableComponentLink pcl = new PrintableComponentLink(new
//PrintingSystem());
//                    pcl.CreateMarginalHeaderArea += new
//                    CreateAreaEventHandler(pcl_CreateMarginalHeaderArea);
//                    schedulerControl1.OptionsPrint.PrintStyle =
//                    DevExpress.XtraScheduler.Printing.SchedulerPrintStyleKind.Weekly;
//                    pcl.Component = this.schedulerControl1;
//                    pcl.ShowPreview();

                    //------------------
                    PrinterSettings settings = new PrinterSettings();
                    //Set PageSize to 'A4'
                    bool found = false;
                    foreach (PaperSize size in settings.PaperSizes)
                    {
                        if (size.PaperName == "A4, 210x297 mm")
                            found = true;
                        if (found)
                        {
                            schedulerPrintStyle.PageSettings.PaperSize = size;
                            break;
                        }
                        else continue;
                    }
				}

				///Setting printing style
				switch (_viewModeName)
				{
					case "Day":
						schedulerControl1.OptionsPrint.PrintStyle = SchedulerPrintStyleKind.Daily;
						break;
					case "Week":
						schedulerControl1.OptionsPrint.PrintStyle = SchedulerPrintStyleKind.Weekly;
						break;
					case "Month":
						schedulerControl1.OptionsPrint.PrintStyle = SchedulerPrintStyleKind.Monthly;
                        //schedulerControl1.
						break;
				}
                //print
                if (_viewModeName == "Week")
                    schedulerControl1.OptionsPrint.PrintStyle = SchedulerPrintStyleKind.Weekly;
                //schedulerControl1.PrintStyles.
                //schedulerControl1.print
                
                schedulerControl1.ShowPrintOptionsForm();
                

                if(_viewModeName == "Week")
                    schedulerControl1.OptionsPrint.PrintStyle = SchedulerPrintStyleKind.Weekly;
                DevExpress.XtraPrinting.PrintableComponentLink comp = new DevExpress.XtraPrinting.PrintableComponentLink(new PrintingSystem());
                comp.Component = schedulerControl1;
                PageHeaderFooter footer = comp.PageHeaderFooter as PageHeaderFooter;

                if (footer != null)
                {
                    footer.Footer.Font = new Font(footer.Footer.Font.FontFamily, 12, FontStyle.Bold);
                    footer.Footer.Content.Add(GetFilterText());
                }

                comp.Landscape = schedulerControl1.ActivePrintStyle.PageSettings.Landscape;
                comp.PaperKind = PaperKind.A4;
                comp.Margins.Bottom = 60;
                comp.Margins.Top = 60;
                comp.Margins.Left = 10;
                comp.Margins.Right = 10;
                comp.CreateMarginalFooterArea += new CreateAreaEventHandler(pcl_CreateMarginalFooterArea);
                //comp.CreateDocument();
                comp.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

        private string GetFilterText()
        {
            bool nothingSet = true;
            StringBuilder strBuilder = new StringBuilder("Filter Info: ");
            if (!cmbClass.Text.Equals(""))
            {
                strBuilder.Append(" Class = \"" + cmbClass.Text + "\"");
                nothingSet = false;
            }
            if (!cmbClient.Text.Equals(""))
            {
                strBuilder.Append(" Client = \"" + cmbClient.Text + "\"");
                nothingSet = false;
            }
            if (!cmbInstructor.Text.Equals(""))
            {
                strBuilder.Append(" Instructor = \"" + cmbInstructor.Text + "\"");
                nothingSet = false;
            }
            if (!cmbProgram.Text.Equals(""))
            {
                strBuilder.Append(" Program = \"" + cmbProgram.Text + "\"");
                nothingSet = false;
            }

            if (nothingSet)
                return "All";
            else
                return strBuilder.ToString();
        }
        void pcl_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            
            //e.Graph.DrawString("All", new RectangleF(0, 0, 500, 30));
        }

		private void datePickerTop_ValueChanged(object sender, EventArgs e) {
			DateTimePicker dtPicker = sender as DateTimePicker;

			if (!isProcess)
				return; 
			
			if (dtPicker == null)
				return;

			if (dtPicker.Name == "StartDatePickerTop")
			{
				if (dtPicker.Checked)
					CalendarFilter.StartDate = dtPicker.Value;
				else
					CalendarFilter.StartDate = DateTime.MinValue;

			}
			else
			{
				if (dtPicker.Checked)
					CalendarFilter.EndDate = dtPicker.Value;
				else
					CalendarFilter.EndDate = DateTime.MaxValue;

			}

			
			if (isProcess) {
				LoadCalendar();
			}
		}

		private void schedulerControl1_Click(object sender, EventArgs e)
		{

		}

        private void schedulerControl1_CustomDrawAppointment(object sender, CustomDrawObjectEventArgs e)
        {
            
        }

        private void schedulerControl1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            if (e.ViewInfo.Appointment.Description.Contains("InActive"))
            {
                e.ViewInfo.Appearance.Font = new Font(e.ViewInfo.Appearance.Font,(FontStyle.Bold|FontStyle.Strikeout));
            }

        }

        private void chkHideWeekends_CheckedChanged(object sender, EventArgs e)
        {
            //if (_viewModeName == "Day")
            //{
            //    CalendarFilter.DailyHideWeekends = chkHideWeekends.Checked;
            //}
            //else if (_viewModeName == "Week")
            //{
            //    CalendarFilter.WeeklyHideWeekends  = chkHideWeekends.Checked;
            //}
            //else if (_viewModeName == "Month")
            //{
            //    CalendarFilter.MonthlyHideWeekends = chkHideWeekends.Checked ;
            //}
            CalendarFilter.MonthlyHideWeekends = chkHideWeekends.Checked;
            //if(chkHideWeekends.Checked)
                
            //else
            //    schedulerControl1.WeekView.Type = SchedulerViewType.Month;

          //  schedulerControl1.WeekView.ViewInfo.ShowWeekend = !chkHideWeekends.Checked;
            schedulerControl1.WorkWeekView.ShowFullWeek = !chkHideWeekends.Checked;
            schedulerControl1.MonthView.ShowWeekend = !chkHideWeekends.Checked;
            
        }
	}
}