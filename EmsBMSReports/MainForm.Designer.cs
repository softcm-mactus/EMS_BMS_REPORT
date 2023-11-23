using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class MainForm : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            tr_FromDate = new DateTimePicker();
            tr_FromDate.LostFocus += new EventHandler(tr_FromDate_LostFocus);
            tr_ToDate = new DateTimePicker();
            tr_ToDate.LostFocus += new EventHandler(tr_ToDate_LostFocus);
            bGenerate = new Button();
            bGenerate.Click += new EventHandler(bGenerate_Click);
            oReportGrid = new DataGridView();
            oReportGrid.CellClick += new DataGridViewCellEventHandler(oReportGrid_CellClick);
            ID = new DataGridViewTextBoxColumn();
            Report = new DataGridViewTextBoxColumn();
            Interval = new DataGridViewTextBoxColumn();
            GroupBox1 = new GroupBox();
            bEventReport = new RadioButton();
            bEventReport.CheckedChanged += new EventHandler(bEventReport_CheckedChanged);
            bAlarmReports = new RadioButton();
            bAlarmReports.CheckedChanged += new EventHandler(bAlarmReports_CheckedChanged);
            bAreaReports = new RadioButton();
            bAreaReports.CheckedChanged += new EventHandler(bAreaReports_CheckedChanged);
            Label5 = new Label();
            oTimer = new Timer(components);
            oTimer.Tick += new EventHandler(oTimer_Tick);
            cInterval = new ComboBox();
            oProgress = new ProgressBar();
            oGrid = new DataGridView();
            oGrid.CellClick += new DataGridViewCellEventHandler(oGrid_CellClick);
            StatusID = new DataGridViewTextBoxColumn();
            ReportFileName = new DataGridViewTextBoxColumn();
            ReportPathName = new DataGridViewTextBoxColumn();
            Open = new DataGridViewButtonColumn();
            Label6 = new Label();
            cGroup = new ComboBox();
            cGroup.SelectedIndexChanged += new EventHandler(cGroup_SelectedIndexChanged);
            bCOnfigureReports = new Button();
            bCOnfigureReports.Click += new EventHandler(bCOnfigureReports_Click);
            bConfigureAlarmReports = new Button();
            bConfigureAlarmReports.Click += new EventHandler(bConfigureAlarmReports_Click);
            bGenerateChart = new Button();
            bGenerateChart.Click += new EventHandler(bGenerateChart_Click);
            Button1 = new Button();
            Button1.Click += new EventHandler(Button1_Click);
            bConfigure = new Button();
            bConfigure.Click += new EventHandler(bConfigure_Click);
            btnExcursionReport = new Button();
            btnExcursionReport.Click += new EventHandler(btnExcursionReport_Click);
            btnBatteryPercentage = new Button();
            btnBatteryPercentage.Click += new EventHandler(btnBatteryPercentage_Click);
            ViewData = new Button();
            ViewData.Click += new EventHandler(Button2_Click);
            ViewGroups = new Button();
            ViewGroups.Click += new EventHandler(Button2_Click_1);
            ((System.ComponentModel.ISupportInitialize)oReportGrid).BeginInit();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.BackColor = Color.Navy;
            Label1.Font = new Font("Microsoft Sans Serif", 26.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label1.ForeColor = Color.White;
            Label1.Location = new Point(0, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(1085, 63);
            Label1.TabIndex = 0;
            Label1.Text = "EMS Reporting Tool";
            Label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label2.Location = new Point(315, 166);
            Label2.Name = "Label2";
            Label2.Size = new Size(166, 20);
            Label2.TabIndex = 2;
            Label2.Text = "Configured Reports";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label3.Location = new Point(709, 155);
            Label3.Name = "Label3";
            Label3.Size = new Size(94, 20);
            Label3.TabIndex = 2;
            Label3.Text = "From Date";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label4.Location = new Point(709, 240);
            Label4.Name = "Label4";
            Label4.Size = new Size(73, 20);
            Label4.TabIndex = 2;
            Label4.Text = "To Date";
            // 
            // tr_FromDate
            // 
            tr_FromDate.CustomFormat = "dd-MM-yyyy HH:mm";
            tr_FromDate.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            tr_FromDate.Format = DateTimePickerFormat.Custom;
            tr_FromDate.Location = new Point(713, 183);
            tr_FromDate.Name = "tr_FromDate";
            tr_FromDate.ShowUpDown = true;
            tr_FromDate.Size = new Size(178, 26);
            tr_FromDate.TabIndex = 327;
            // 
            // tr_ToDate
            // 
            tr_ToDate.CustomFormat = "dd-MM-yyyy HH:mm";
            tr_ToDate.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            tr_ToDate.Format = DateTimePickerFormat.Custom;
            tr_ToDate.Location = new Point(713, 268);
            tr_ToDate.Name = "tr_ToDate";
            tr_ToDate.ShowUpDown = true;
            tr_ToDate.Size = new Size(178, 26);
            tr_ToDate.TabIndex = 327;
            // 
            // bGenerate
            // 
            bGenerate.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            bGenerate.Location = new Point(713, 340);
            bGenerate.Name = "bGenerate";
            bGenerate.Size = new Size(178, 47);
            bGenerate.TabIndex = 328;
            bGenerate.Text = "Generate Report";
            bGenerate.UseVisualStyleBackColor = true;
            // 
            // oReportGrid
            // 
            oReportGrid.AllowUserToAddRows = false;
            oReportGrid.AllowUserToDeleteRows = false;
            oReportGrid.AllowUserToResizeColumns = false;
            oReportGrid.AllowUserToResizeRows = false;
            oReportGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oReportGrid.ColumnHeadersVisible = false;
            oReportGrid.Columns.AddRange(new DataGridViewColumn[] { ID, Report, Interval });
            oReportGrid.Location = new Point(319, 190);
            oReportGrid.MultiSelect = false;
            oReportGrid.Name = "oReportGrid";
            oReportGrid.RowHeadersVisible = false;
            oReportGrid.RowHeadersWidth = 51;
            oReportGrid.Size = new Size(334, 245);
            oReportGrid.TabIndex = 329;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.Width = 125;
            // 
            // Report
            // 
            Report.HeaderText = "Report Name";
            Report.MinimumWidth = 6;
            Report.Name = "Report";
            Report.ReadOnly = true;
            Report.Width = 300;
            // 
            // Interval
            // 
            Interval.HeaderText = "Interval";
            Interval.MinimumWidth = 6;
            Interval.Name = "Interval";
            Interval.ReadOnly = true;
            Interval.Visible = false;
            Interval.Width = 125;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(bEventReport);
            GroupBox1.Controls.Add(bAlarmReports);
            GroupBox1.Controls.Add(bAreaReports);
            GroupBox1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            GroupBox1.Location = new Point(22, 76);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new Size(270, 195);
            GroupBox1.TabIndex = 330;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Report Type";
            // 
            // bEventReport
            // 
            bEventReport.AutoSize = true;
            bEventReport.Location = new Point(38, 141);
            bEventReport.Name = "bEventReport";
            bEventReport.Size = new Size(137, 28);
            bEventReport.TabIndex = 0;
            bEventReport.TabStop = true;
            bEventReport.Text = "Event Report";
            bEventReport.UseVisualStyleBackColor = true;
            // 
            // bAlarmReports
            // 
            bAlarmReports.AutoSize = true;
            bAlarmReports.Location = new Point(38, 87);
            bAlarmReports.Name = "bAlarmReports";
            bAlarmReports.Size = new Size(147, 28);
            bAlarmReports.TabIndex = 0;
            bAlarmReports.TabStop = true;
            bAlarmReports.Text = "Alarm Reports";
            bAlarmReports.UseVisualStyleBackColor = true;
            // 
            // bAreaReports
            // 
            bAreaReports.AutoSize = true;
            bAreaReports.Location = new Point(38, 37);
            bAreaReports.Name = "bAreaReports";
            bAreaReports.Size = new Size(138, 28);
            bAreaReports.TabIndex = 0;
            bAreaReports.TabStop = true;
            bAreaReports.Text = "Area Reports";
            bAreaReports.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label5.Location = new Point(709, 85);
            Label5.Name = "Label5";
            Label5.Size = new Size(177, 20);
            Label5.TabIndex = 2;
            Label5.Text = "Report Time Interval ";
            // 
            // oTimer
            // 
            oTimer.Interval = 3000;
            // 
            // cInterval
            // 
            cInterval.DropDownStyle = ComboBoxStyle.DropDownList;
            cInterval.FormattingEnabled = true;
            cInterval.Items.AddRange(new object[] { "1", "5", "15", "30", "60" });
            cInterval.Location = new Point(713, 109);
            cInterval.Name = "cInterval";
            cInterval.Size = new Size(121, 24);
            cInterval.TabIndex = 334;
            // 
            // oProgress
            // 
            oProgress.Location = new Point(25, 658);
            oProgress.Name = "oProgress";
            oProgress.Size = new Size(960, 23);
            oProgress.TabIndex = 335;
            // 
            // oGrid
            // 
            oGrid.AllowUserToAddRows = false;
            oGrid.AllowUserToDeleteRows = false;
            oGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oGrid.Columns.AddRange(new DataGridViewColumn[] { StatusID, ReportFileName, ReportPathName, Open });
            oGrid.Location = new Point(334, 700);
            oGrid.Name = "oGrid";
            oGrid.RowHeadersVisible = false;
            oGrid.RowHeadersWidth = 51;
            oGrid.Size = new Size(651, 150);
            oGrid.TabIndex = 336;
            // 
            // StatusID
            // 
            StatusID.HeaderText = "StatusID";
            StatusID.MinimumWidth = 6;
            StatusID.Name = "StatusID";
            StatusID.Visible = false;
            StatusID.Width = 125;
            // 
            // ReportFileName
            // 
            ReportFileName.HeaderText = "Report File Name";
            ReportFileName.MinimumWidth = 6;
            ReportFileName.Name = "ReportFileName";
            ReportFileName.ReadOnly = true;
            ReportFileName.Width = 400;
            // 
            // ReportPathName
            // 
            ReportPathName.HeaderText = "ReportPathName";
            ReportPathName.MinimumWidth = 6;
            ReportPathName.Name = "ReportPathName";
            ReportPathName.ReadOnly = true;
            ReportPathName.Visible = false;
            ReportPathName.Width = 125;
            // 
            // Open
            // 
            Open.HeaderText = "Open";
            Open.MinimumWidth = 6;
            Open.Name = "Open";
            Open.Text = "Open";
            Open.Width = 125;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label6.Location = new Point(315, 88);
            Label6.Name = "Label6";
            Label6.Size = new Size(110, 20);
            Label6.TabIndex = 2;
            Label6.Text = "Group Name";
            // 
            // cGroup
            // 
            cGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cGroup.FormattingEnabled = true;
            cGroup.Location = new Point(319, 112);
            cGroup.Name = "cGroup";
            cGroup.Size = new Size(325, 24);
            cGroup.TabIndex = 337;
            // 
            // bCOnfigureReports
            // 
            bCOnfigureReports.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            bCOnfigureReports.Location = new Point(32, 340);
            bCOnfigureReports.Name = "bCOnfigureReports";
            bCOnfigureReports.Size = new Size(260, 37);
            bCOnfigureReports.TabIndex = 338;
            bCOnfigureReports.Text = "Configure Data Trend Reports";
            bCOnfigureReports.UseVisualStyleBackColor = true;
            bCOnfigureReports.Visible = false;
            // 
            // bConfigureAlarmReports
            // 
            bConfigureAlarmReports.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            bConfigureAlarmReports.Location = new Point(32, 473);
            bConfigureAlarmReports.Name = "bConfigureAlarmReports";
            bConfigureAlarmReports.Size = new Size(260, 37);
            bConfigureAlarmReports.TabIndex = 338;
            bConfigureAlarmReports.Text = "Configure Alarm Reports";
            bConfigureAlarmReports.UseVisualStyleBackColor = true;
            bConfigureAlarmReports.Visible = false;
            // 
            // bGenerateChart
            // 
            bGenerateChart.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            bGenerateChart.Location = new Point(713, 412);
            bGenerateChart.Name = "bGenerateChart";
            bGenerateChart.Size = new Size(178, 47);
            bGenerateChart.TabIndex = 328;
            bGenerateChart.Text = "Generate Chart";
            bGenerateChart.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            Button1.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Button1.Location = new Point(32, 516);
            Button1.Name = "Button1";
            Button1.Size = new Size(260, 37);
            Button1.TabIndex = 339;
            Button1.Text = "Synchronize Point Names";
            Button1.UseVisualStyleBackColor = true;
            // 
            // bConfigure
            // 
            bConfigure.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            bConfigure.Location = new Point(32, 297);
            bConfigure.Name = "bConfigure";
            bConfigure.Size = new Size(260, 37);
            bConfigure.TabIndex = 340;
            bConfigure.Text = "Configure Main Parameters";
            bConfigure.UseVisualStyleBackColor = true;
            // 
            // btnExcursionReport
            // 
            btnExcursionReport.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcursionReport.Location = new Point(32, 383);
            btnExcursionReport.Name = "btnExcursionReport";
            btnExcursionReport.Size = new Size(260, 37);
            btnExcursionReport.TabIndex = 341;
            btnExcursionReport.Text = "Configure Excursion Reports";
            btnExcursionReport.UseVisualStyleBackColor = true;
            btnExcursionReport.Visible = false;
            // 
            // btnBatteryPercentage
            // 
            btnBatteryPercentage.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBatteryPercentage.Location = new Point(32, 430);
            btnBatteryPercentage.Name = "btnBatteryPercentage";
            btnBatteryPercentage.Size = new Size(260, 37);
            btnBatteryPercentage.TabIndex = 342;
            btnBatteryPercentage.Text = "Configure Battery  Reports";
            btnBatteryPercentage.UseVisualStyleBackColor = true;
            btnBatteryPercentage.Visible = false;
            // 
            // ViewData
            // 
            ViewData.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ViewData.Location = new Point(713, 482);
            ViewData.Name = "ViewData";
            ViewData.Size = new Size(178, 47);
            ViewData.TabIndex = 343;
            ViewData.Text = "View Data";
            ViewData.UseVisualStyleBackColor = true;
            // 
            // ViewGroups
            // 
            ViewGroups.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ViewGroups.Location = new Point(32, 559);
            ViewGroups.Name = "ViewGroups";
            ViewGroups.Size = new Size(260, 37);
            ViewGroups.TabIndex = 344;
            ViewGroups.Text = "Configure View Groups";
            ViewGroups.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 901);
            Controls.Add(ViewGroups);
            Controls.Add(ViewData);
            Controls.Add(btnBatteryPercentage);
            Controls.Add(btnExcursionReport);
            Controls.Add(bConfigure);
            Controls.Add(Button1);
            Controls.Add(bConfigureAlarmReports);
            Controls.Add(bCOnfigureReports);
            Controls.Add(cGroup);
            Controls.Add(oGrid);
            Controls.Add(oProgress);
            Controls.Add(cInterval);
            Controls.Add(GroupBox1);
            Controls.Add(oReportGrid);
            Controls.Add(bGenerateChart);
            Controls.Add(bGenerate);
            Controls.Add(tr_ToDate);
            Controls.Add(tr_FromDate);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label5);
            Controls.Add(Label6);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)oReportGrid).EndInit();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            Load += new EventHandler(MainForm_Load);
            Closing += new System.ComponentModel.CancelEventHandler(MainForm_Closing);
            ResumeLayout(false);
            PerformLayout();

        }

        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal DateTimePicker tr_FromDate;
        internal DateTimePicker tr_ToDate;
        internal Button bGenerate;
        internal DataGridView oReportGrid;
        internal GroupBox GroupBox1;
        internal RadioButton bEventReport;
        internal RadioButton bAlarmReports;
        internal RadioButton bAreaReports;
        internal Label Label5;
        internal DataGridViewTextBoxColumn ID;
        internal DataGridViewTextBoxColumn Report;
        internal DataGridViewTextBoxColumn Interval;
        internal Timer oTimer;
        internal ComboBox cInterval;
        internal ProgressBar oProgress;
        internal DataGridView oGrid;
        internal DataGridViewTextBoxColumn StatusID;
        internal DataGridViewTextBoxColumn ReportFileName;
        internal DataGridViewTextBoxColumn ReportPathName;
        internal DataGridViewButtonColumn Open;
        internal Label Label6;
        internal ComboBox cGroup;
        internal Button bCOnfigureReports;
        internal Button bConfigureAlarmReports;
        internal Button bGenerateChart;
        internal Button Button1;
        internal Button bConfigure;
        internal Button btnExcursionReport;
        internal Button btnBatteryPercentage;
        internal Button ViewData;
        internal Button ViewGroups;
    }
}