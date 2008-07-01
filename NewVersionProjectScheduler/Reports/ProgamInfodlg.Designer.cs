namespace Scheduler.Reports
{
    partial class ProgamInfodlg
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
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.lblProgramNameValue = new DevExpress.XtraEditors.LabelControl();
            this.lblProgramName = new DevExpress.XtraEditors.LabelControl();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dataSet11 = new Scheduler.BusinessLayer.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProgramId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProgramName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCourseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colCourseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalendarEventId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.pnlTop.Controls.Add(this.lblProgramNameValue);
            this.pnlTop.Controls.Add(this.lblProgramName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(481, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblProgramNameValue
            // 
            this.lblProgramNameValue.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblProgramNameValue.Appearance.Options.UseFont = true;
            this.lblProgramNameValue.Location = new System.Drawing.Point(153, 25);
            this.lblProgramNameValue.Name = "lblProgramNameValue";
            this.lblProgramNameValue.Size = new System.Drawing.Size(61, 19);
            this.lblProgramNameValue.TabIndex = 1;
            this.lblProgramNameValue.Text = "[Name]";
            // 
            // lblProgramName
            // 
            this.lblProgramName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblProgramName.Appearance.Options.UseFont = true;
            this.lblProgramName.Location = new System.Drawing.Point(12, 25);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(122, 19);
            this.lblProgramName.TabIndex = 0;
            this.lblProgramName.Text = "Program Name";
            // 
            // pnlBody
            // 
            this.pnlBody.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.pnlBody.Controls.Add(this.btnCancel);
            this.pnlBody.Controls.Add(this.btnOK);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBody.Location = new System.Drawing.Point(0, 352);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(481, 52);
            this.pnlBody.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(376, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(295, 17);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "viewSimpleProgramInfo";
            this.gridControl1.DataSource = this.dataSet11;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.FormsUseDefaultLookAndFeel = false;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(477, 288);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProgramId,
            this.colProgramName,
            this.colCourseName,
            this.colStartDateTime,
            this.colEndDateTime,
            this.colCourseID,
            this.colID,
            this.colCalendarEventId});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colProgramId
            // 
            this.colProgramId.Caption = "ProgramId";
            this.colProgramId.FieldName = "ProgramId";
            this.colProgramId.Name = "colProgramId";
            this.colProgramId.OptionsColumn.AllowEdit = false;
            this.colProgramId.OptionsColumn.ReadOnly = true;
            // 
            // colProgramName
            // 
            this.colProgramName.Caption = "ProgramName";
            this.colProgramName.FieldName = "ProgramName";
            this.colProgramName.Name = "colProgramName";
            this.colProgramName.OptionsColumn.AllowEdit = false;
            this.colProgramName.OptionsColumn.ReadOnly = true;
            // 
            // colCourseName
            // 
            this.colCourseName.Caption = "Course Name";
            this.colCourseName.FieldName = "CourseName";
            this.colCourseName.Name = "colCourseName";
            this.colCourseName.OptionsColumn.AllowEdit = false;
            this.colCourseName.OptionsColumn.ReadOnly = true;
            this.colCourseName.Visible = true;
            this.colCourseName.VisibleIndex = 0;
            // 
            // colStartDateTime
            // 
            this.colStartDateTime.Caption = "Event Start Date";
            this.colStartDateTime.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.colStartDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartDateTime.FieldName = "StartDateTime";
            this.colStartDateTime.Name = "colStartDateTime";
            this.colStartDateTime.OptionsColumn.AllowEdit = false;
            this.colStartDateTime.OptionsColumn.ReadOnly = true;
            this.colStartDateTime.Visible = true;
            this.colStartDateTime.VisibleIndex = 1;
            // 
            // colEndDateTime
            // 
            this.colEndDateTime.Caption = "Event End Date";
            this.colEndDateTime.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.colEndDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndDateTime.FieldName = "EndDateTime";
            this.colEndDateTime.Name = "colEndDateTime";
            this.colEndDateTime.OptionsColumn.AllowEdit = false;
            this.colEndDateTime.OptionsColumn.ReadOnly = true;
            this.colEndDateTime.Visible = true;
            this.colEndDateTime.VisibleIndex = 2;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colCourseID
            // 
            this.colCourseID.Caption = "CourseID";
            this.colCourseID.FieldName = "CourseID";
            this.colCourseID.Name = "colCourseID";
            this.colCourseID.OptionsColumn.AllowEdit = false;
            this.colCourseID.OptionsColumn.ReadOnly = true;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            // 
            // colCalendarEventId
            // 
            this.colCalendarEventId.Caption = "CalendarEventId";
            this.colCalendarEventId.FieldName = "CalendarEventId";
            this.colCalendarEventId.Name = "colCalendarEventId";
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(481, 292);
            this.panelControl1.TabIndex = 2;
            // 
            // ProgamInfodlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 404);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgamInfodlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Information";
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.LabelControl lblProgramNameValue;
        private DevExpress.XtraEditors.LabelControl lblProgramName;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private Scheduler.BusinessLayer.DataSet1 dataSet11;
        private DevExpress.XtraGrid.Columns.GridColumn colProgramId;
        private DevExpress.XtraGrid.Columns.GridColumn colProgramName;
        private DevExpress.XtraGrid.Columns.GridColumn colCourseName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colCourseID;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCalendarEventId;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}