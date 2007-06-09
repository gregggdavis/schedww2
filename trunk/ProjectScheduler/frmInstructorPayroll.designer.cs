namespace Scheduler
{
    partial class frmInstructorPayroll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSet11 = new Scheduler.BusinessLayer.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProgramName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colEndDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.colDayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalendarEventId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colTeacherID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstructorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colScheduledHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colEventDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colHomeworkMinutes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditStartDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.DataMember = "viewInstructorPaymentDetails";
            this.gridControl1.DataSource = this.dataSet11;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemDateEdit1,
            this.repositoryItemTimeEdit2,
            this.repositoryItemDateEdit2,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2});
            this.gridControl1.Size = new System.Drawing.Size(688, 360);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 70);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem1,
            this.exportToHTMLToolStripMenuItem,
            this.exportToXMLToolStripMenuItem,
            this.exportToTXTToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.exportToolStripMenuItem1.Text = "Export To Excel";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // exportToHTMLToolStripMenuItem
            // 
            this.exportToHTMLToolStripMenuItem.Name = "exportToHTMLToolStripMenuItem";
            this.exportToHTMLToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportToHTMLToolStripMenuItem.Text = "Export to HTML";
            this.exportToHTMLToolStripMenuItem.Click += new System.EventHandler(this.exportToHTMLToolStripMenuItem_Click);
            // 
            // exportToXMLToolStripMenuItem
            // 
            this.exportToXMLToolStripMenuItem.Name = "exportToXMLToolStripMenuItem";
            this.exportToXMLToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportToXMLToolStripMenuItem.Text = "Export to XML";
            this.exportToXMLToolStripMenuItem.Click += new System.EventHandler(this.exportToXMLToolStripMenuItem_Click);
            // 
            // exportToTXTToolStripMenuItem
            // 
            this.exportToTXTToolStripMenuItem.Name = "exportToTXTToolStripMenuItem";
            this.exportToTXTToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportToTXTToolStripMenuItem.Text = "Export to TXT";
            this.exportToTXTToolStripMenuItem.Click += new System.EventHandler(this.exportToTXTToolStripMenuItem_Click);
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDepartment,
            this.colClientName,
            this.colProgramName,
            this.colClassName,
            this.colClassType,
            this.colClientShortName,
            this.colStartDateTime,
            this.colEndDateTime,
            this.colDayName,
            this.colCalendarEventId,
            this.colPaidHours,
            this.colTeacherID,
            this.colInstructorName,
            this.colScheduledHours,
            this.colEventDate,
            this.colHomeworkMinutes});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ScheduledHours", null, "Scheduled Hours = {0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaidHours", null, "Total Paid Hours = {0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ScheduledHours", this.colScheduledHours, "Scheduled Hours = {0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaidHours", this.colPaidHours, "Total Paid Hours = {0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colInstructorName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "Department";
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsColumn.AllowEdit = false;
            this.colDepartment.OptionsColumn.ReadOnly = true;
            this.colDepartment.Width = 69;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "ClientName";
            this.colClientName.FieldName = "ClientName";
            this.colClientName.Name = "colClientName";
            this.colClientName.OptionsColumn.AllowEdit = false;
            this.colClientName.OptionsColumn.ReadOnly = true;
            this.colClientName.Width = 66;
            // 
            // colProgramName
            // 
            this.colProgramName.Caption = "Program";
            this.colProgramName.FieldName = "ProgramName";
            this.colProgramName.Name = "colProgramName";
            this.colProgramName.OptionsColumn.AllowEdit = false;
            this.colProgramName.OptionsColumn.ReadOnly = true;
            this.colProgramName.Visible = true;
            this.colProgramName.VisibleIndex = 5;
            this.colProgramName.Width = 62;
            // 
            // colClassName
            // 
            this.colClassName.Caption = "Class";
            this.colClassName.FieldName = "Class";
            this.colClassName.Name = "colClassName";
            this.colClassName.OptionsColumn.AllowEdit = false;
            this.colClassName.OptionsColumn.ReadOnly = true;
            this.colClassName.Visible = true;
            this.colClassName.VisibleIndex = 6;
            this.colClassName.Width = 47;
            // 
            // colClassType
            // 
            this.colClassType.Caption = "Job Type";
            this.colClassType.FieldName = "JobType";
            this.colClassType.Name = "colClassType";
            this.colClassType.OptionsColumn.AllowEdit = false;
            this.colClassType.OptionsColumn.ReadOnly = true;
            this.colClassType.Visible = true;
            this.colClassType.VisibleIndex = 7;
            this.colClassType.Width = 66;
            // 
            // colClientShortName
            // 
            this.colClientShortName.Caption = "Client";
            this.colClientShortName.FieldName = "ClientNickName";
            this.colClientShortName.Name = "colClientShortName";
            this.colClientShortName.OptionsColumn.AllowEdit = false;
            this.colClientShortName.OptionsColumn.ReadOnly = true;
            this.colClientShortName.Visible = true;
            this.colClientShortName.VisibleIndex = 8;
            this.colClientShortName.Width = 49;
            // 
            // colStartDateTime
            // 
            this.colStartDateTime.Caption = "Start Time";
            this.colStartDateTime.ColumnEdit = this.repositoryItemTimeEdit1;
            this.colStartDateTime.FieldName = "StartDateTime";
            this.colStartDateTime.Name = "colStartDateTime";
            this.colStartDateTime.OptionsColumn.AllowEdit = false;
            this.colStartDateTime.OptionsColumn.ReadOnly = true;
            this.colStartDateTime.Visible = true;
            this.colStartDateTime.VisibleIndex = 3;
            this.colStartDateTime.Width = 71;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit1.Mask.EditMask = "hh:mm:ss tt";
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // colEndDateTime
            // 
            this.colEndDateTime.Caption = "End Time";
            this.colEndDateTime.ColumnEdit = this.repositoryItemTimeEdit2;
            this.colEndDateTime.FieldName = "EndDateTime";
            this.colEndDateTime.Name = "colEndDateTime";
            this.colEndDateTime.OptionsColumn.AllowEdit = false;
            this.colEndDateTime.OptionsColumn.ReadOnly = true;
            this.colEndDateTime.Visible = true;
            this.colEndDateTime.VisibleIndex = 4;
            this.colEndDateTime.Width = 65;
            // 
            // repositoryItemTimeEdit2
            // 
            this.repositoryItemTimeEdit2.AutoHeight = false;
            this.repositoryItemTimeEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit2.DisplayFormat.FormatString = "hh:mm:ss tt";
            this.repositoryItemTimeEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemTimeEdit2.Name = "repositoryItemTimeEdit2";
            // 
            // colDayName
            // 
            this.colDayName.Caption = "Day";
            this.colDayName.FieldName = "DayName";
            this.colDayName.Name = "colDayName";
            this.colDayName.OptionsColumn.AllowEdit = false;
            this.colDayName.OptionsColumn.ReadOnly = true;
            this.colDayName.Visible = true;
            this.colDayName.VisibleIndex = 2;
            this.colDayName.Width = 41;
            // 
            // colCalendarEventId
            // 
            this.colCalendarEventId.Caption = "CalendarEventId";
            this.colCalendarEventId.FieldName = "CalendarEventId";
            this.colCalendarEventId.Name = "colCalendarEventId";
            this.colCalendarEventId.OptionsColumn.AllowEdit = false;
            this.colCalendarEventId.OptionsColumn.ReadOnly = true;
            this.colCalendarEventId.Width = 93;
            // 
            // colPaidHours
            // 
            this.colPaidHours.Caption = "Paid Hours";
            this.colPaidHours.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colPaidHours.FieldName = "PaidHours";
            this.colPaidHours.Name = "colPaidHours";
            this.colPaidHours.OptionsColumn.AllowEdit = false;
            this.colPaidHours.OptionsColumn.ReadOnly = true;
            this.colPaidHours.SummaryItem.DisplayFormat = "Paid Hours = {0}";
            this.colPaidHours.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colPaidHours.Visible = true;
            this.colPaidHours.VisibleIndex = 10;
            this.colPaidHours.Width = 172;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit2.DisplayFormat.FormatString = "n";
            this.repositoryItemSpinEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit2.Mask.EditMask = "n";
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // colTeacherID
            // 
            this.colTeacherID.Caption = "TeacherID";
            this.colTeacherID.FieldName = "TeacherId";
            this.colTeacherID.Name = "colTeacherID";
            this.colTeacherID.OptionsColumn.AllowEdit = false;
            this.colTeacherID.OptionsColumn.ReadOnly = true;
            this.colTeacherID.Width = 62;
            // 
            // colInstructorName
            // 
            this.colInstructorName.Caption = "Instructor Name";
            this.colInstructorName.FieldName = "InstructorName";
            this.colInstructorName.Name = "colInstructorName";
            this.colInstructorName.OptionsColumn.AllowEdit = false;
            this.colInstructorName.OptionsColumn.ReadOnly = true;
            this.colInstructorName.Visible = true;
            this.colInstructorName.VisibleIndex = 0;
            this.colInstructorName.Width = 113;
            // 
            // colScheduledHours
            // 
            this.colScheduledHours.Caption = "Scheduled Hours";
            this.colScheduledHours.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colScheduledHours.FieldName = "ScheduledHours";
            this.colScheduledHours.Name = "colScheduledHours";
            this.colScheduledHours.OptionsColumn.AllowEdit = false;
            this.colScheduledHours.OptionsColumn.ReadOnly = true;
            this.colScheduledHours.SummaryItem.DisplayFormat = "Scheduled Hours = {0}";
            this.colScheduledHours.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colScheduledHours.Visible = true;
            this.colScheduledHours.VisibleIndex = 9;
            this.colScheduledHours.Width = 162;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "n";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.Mask.EditMask = "n";
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colEventDate
            // 
            this.colEventDate.Caption = "Date";
            this.colEventDate.ColumnEdit = this.repositoryItemDateEdit2;
            this.colEventDate.FieldName = "StartDateTime";
            this.colEventDate.Name = "colEventDate";
            this.colEventDate.OptionsColumn.AllowEdit = false;
            this.colEventDate.OptionsColumn.ReadOnly = true;
            this.colEventDate.Visible = true;
            this.colEventDate.VisibleIndex = 1;
            this.colEventDate.Width = 45;
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.repositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit2.Mask.EditMask = "MM/dd/yyyy";
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // colHomeworkMinutes
            // 
            this.colHomeworkMinutes.Caption = "HomeworkMinutes";
            this.colHomeworkMinutes.FieldName = "HomeworkMinutes";
            this.colHomeworkMinutes.Name = "colHomeworkMinutes";
            this.colHomeworkMinutes.OptionsColumn.AllowEdit = false;
            this.colHomeworkMinutes.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.panelControl2);
            this.pnlBody.Controls.Add(this.panelControl1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(692, 455);
            this.pnlBody.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 91);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(692, 364);
            this.panelControl2.TabIndex = 2;
            this.panelControl2.Text = "panelControl2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.checkEdit2);
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.dateEditEndDate);
            this.panelControl1.Controls.Add(this.dateEditStartDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(692, 91);
            this.panelControl1.TabIndex = 1;
            this.panelControl1.Text = "panelControl1";
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(23, 49);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "End Date:";
            this.checkEdit2.Size = new System.Drawing.Size(75, 19);
            this.checkEdit2.TabIndex = 12;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit2_CheckedChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(23, 24);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Start Date:";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 11;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(305, 24);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(81, 44);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "Search";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dateEditEndDate
            // 
            this.dateEditEndDate.EditValue = new System.DateTime(2007, 3, 22, 7, 25, 31, 171);
            this.dateEditEndDate.Enabled = false;
            this.dateEditEndDate.Location = new System.Drawing.Point(130, 49);
            this.dateEditEndDate.Name = "dateEditEndDate";
            this.dateEditEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEndDate.Properties.DisplayFormat.FormatString = "D";
            this.dateEditEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEndDate.Size = new System.Drawing.Size(169, 19);
            this.dateEditEndDate.TabIndex = 9;
            // 
            // dateEditStartDate
            // 
            this.dateEditStartDate.EditValue = new System.DateTime(2007, 3, 22, 7, 25, 23, 234);
            this.dateEditStartDate.Enabled = false;
            this.dateEditStartDate.Location = new System.Drawing.Point(130, 24);
            this.dateEditStartDate.Name = "dateEditStartDate";
            this.dateEditStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStartDate.Properties.DisplayFormat.FormatString = "D";
            this.dateEditStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditStartDate.Size = new System.Drawing.Size(169, 19);
            this.dateEditStartDate.TabIndex = 8;
            // 
            // frmInstructorPayroll
            // 
            this.ClientSize = new System.Drawing.Size(692, 455);
            this.Controls.Add(this.pnlBody);
            this.Name = "frmInstructorPayroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pay Details By Instructor";
            this.Load += new System.EventHandler(this.frmInstructorPayroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStartDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        public System.Windows.Forms.Panel pnlBody;
        private Scheduler.BusinessLayer.DataSet1 dataSet11;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colClientName;
        private DevExpress.XtraGrid.Columns.GridColumn colProgramName;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colClassType;
        private DevExpress.XtraGrid.Columns.GridColumn colClientShortName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDayName;
        private DevExpress.XtraGrid.Columns.GridColumn colCalendarEventId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidHours;
        private DevExpress.XtraGrid.Columns.GridColumn colTeacherID;
        private DevExpress.XtraGrid.Columns.GridColumn colInstructorName;
        private DevExpress.XtraGrid.Columns.GridColumn colScheduledHours;
        private DevExpress.XtraGrid.Columns.GridColumn colEventDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToTXTToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colHomeworkMinutes;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit dateEditEndDate;
        private DevExpress.XtraEditors.DateEdit dateEditStartDate;
    }
}