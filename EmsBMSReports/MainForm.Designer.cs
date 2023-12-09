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
            this.components = new System.ComponentModel.Container();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.tr_FromDate = new System.Windows.Forms.DateTimePicker();
            this.tr_ToDate = new System.Windows.Forms.DateTimePicker();
            this.bGenerate = new System.Windows.Forms.Button();
            this.oReportGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Report = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.bEventReport = new System.Windows.Forms.RadioButton();
            this.bAlarmReports = new System.Windows.Forms.RadioButton();
            this.bAreaReports = new System.Windows.Forms.RadioButton();
            this.Label5 = new System.Windows.Forms.Label();
            this.oTimer = new System.Windows.Forms.Timer(this.components);
            this.cInterval = new System.Windows.Forms.ComboBox();
            this.oProgress = new System.Windows.Forms.ProgressBar();
            this.oGrid = new System.Windows.Forms.DataGridView();
            this.ReportHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label6 = new System.Windows.Forms.Label();
            this.cGroup = new System.Windows.Forms.ComboBox();
            this.bCOnfigureReports = new System.Windows.Forms.Button();
            this.bConfigureAlarmReports = new System.Windows.Forms.Button();
            this.bGenerateChart = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.bConfigure = new System.Windows.Forms.Button();
            this.btnExcursionReport = new System.Windows.Forms.Button();
            this.btnBatteryPercentage = new System.Windows.Forms.Button();
            this.ViewData = new System.Windows.Forms.Button();
            this.ViewGroups = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.oReportGrid)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Navy;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(1085, 63);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "EMS Reporting Tool";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(315, 166);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(166, 20);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Configured Reports";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(709, 155);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(94, 20);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "From Date";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(709, 240);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(73, 20);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "To Date";
            // 
            // tr_FromDate
            // 
            this.tr_FromDate.CustomFormat = "dd-MM-yyyy HH:mm";
            this.tr_FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tr_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tr_FromDate.Location = new System.Drawing.Point(713, 183);
            this.tr_FromDate.Name = "tr_FromDate";
            this.tr_FromDate.ShowUpDown = true;
            this.tr_FromDate.Size = new System.Drawing.Size(178, 26);
            this.tr_FromDate.TabIndex = 327;
            this.tr_FromDate.LostFocus += new System.EventHandler(this.tr_FromDate_LostFocus);
            // 
            // tr_ToDate
            // 
            this.tr_ToDate.CustomFormat = "dd-MM-yyyy HH:mm";
            this.tr_ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tr_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tr_ToDate.Location = new System.Drawing.Point(713, 268);
            this.tr_ToDate.Name = "tr_ToDate";
            this.tr_ToDate.ShowUpDown = true;
            this.tr_ToDate.Size = new System.Drawing.Size(178, 26);
            this.tr_ToDate.TabIndex = 327;
            this.tr_ToDate.LostFocus += new System.EventHandler(this.tr_ToDate_LostFocus);
            // 
            // bGenerate
            // 
            this.bGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGenerate.Location = new System.Drawing.Point(713, 340);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(178, 47);
            this.bGenerate.TabIndex = 328;
            this.bGenerate.Text = "Generate Report";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // oReportGrid
            // 
            this.oReportGrid.AllowUserToAddRows = false;
            this.oReportGrid.AllowUserToDeleteRows = false;
            this.oReportGrid.AllowUserToResizeColumns = false;
            this.oReportGrid.AllowUserToResizeRows = false;
            this.oReportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oReportGrid.ColumnHeadersVisible = false;
            this.oReportGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Report,
            this.Interval});
            this.oReportGrid.Location = new System.Drawing.Point(319, 190);
            this.oReportGrid.MultiSelect = false;
            this.oReportGrid.Name = "oReportGrid";
            this.oReportGrid.RowHeadersVisible = false;
            this.oReportGrid.RowHeadersWidth = 51;
            this.oReportGrid.Size = new System.Drawing.Size(334, 245);
            this.oReportGrid.TabIndex = 329;
            this.oReportGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oReportGrid_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // Report
            // 
            this.Report.HeaderText = "Report Name";
            this.Report.MinimumWidth = 6;
            this.Report.Name = "Report";
            this.Report.ReadOnly = true;
            this.Report.Width = 300;
            // 
            // Interval
            // 
            this.Interval.HeaderText = "Interval";
            this.Interval.MinimumWidth = 6;
            this.Interval.Name = "Interval";
            this.Interval.ReadOnly = true;
            this.Interval.Visible = false;
            this.Interval.Width = 125;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.bEventReport);
            this.GroupBox1.Controls.Add(this.bAlarmReports);
            this.GroupBox1.Controls.Add(this.bAreaReports);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(22, 76);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(270, 195);
            this.GroupBox1.TabIndex = 330;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Report Type";
            // 
            // bEventReport
            // 
            this.bEventReport.AutoSize = true;
            this.bEventReport.Location = new System.Drawing.Point(38, 141);
            this.bEventReport.Name = "bEventReport";
            this.bEventReport.Size = new System.Drawing.Size(137, 28);
            this.bEventReport.TabIndex = 0;
            this.bEventReport.TabStop = true;
            this.bEventReport.Text = "Event Report";
            this.bEventReport.UseVisualStyleBackColor = true;
            this.bEventReport.CheckedChanged += new System.EventHandler(this.bEventReport_CheckedChanged);
            // 
            // bAlarmReports
            // 
            this.bAlarmReports.AutoSize = true;
            this.bAlarmReports.Location = new System.Drawing.Point(38, 87);
            this.bAlarmReports.Name = "bAlarmReports";
            this.bAlarmReports.Size = new System.Drawing.Size(147, 28);
            this.bAlarmReports.TabIndex = 0;
            this.bAlarmReports.TabStop = true;
            this.bAlarmReports.Text = "Alarm Reports";
            this.bAlarmReports.UseVisualStyleBackColor = true;
            this.bAlarmReports.CheckedChanged += new System.EventHandler(this.bAlarmReports_CheckedChanged);
            // 
            // bAreaReports
            // 
            this.bAreaReports.AutoSize = true;
            this.bAreaReports.Location = new System.Drawing.Point(38, 37);
            this.bAreaReports.Name = "bAreaReports";
            this.bAreaReports.Size = new System.Drawing.Size(138, 28);
            this.bAreaReports.TabIndex = 0;
            this.bAreaReports.TabStop = true;
            this.bAreaReports.Text = "Area Reports";
            this.bAreaReports.UseVisualStyleBackColor = true;
            this.bAreaReports.CheckedChanged += new System.EventHandler(this.bAreaReports_CheckedChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(709, 85);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(177, 20);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Report Time Interval ";
            // 
            // oTimer
            // 
            this.oTimer.Interval = 3000;
            this.oTimer.Tick += new System.EventHandler(this.oTimer_Tick);
            // 
            // cInterval
            // 
            this.cInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cInterval.FormattingEnabled = true;
            this.cInterval.Items.AddRange(new object[] {
            "1",
            "5",
            "15",
            "30",
            "60"});
            this.cInterval.Location = new System.Drawing.Point(713, 109);
            this.cInterval.Name = "cInterval";
            this.cInterval.Size = new System.Drawing.Size(121, 24);
            this.cInterval.TabIndex = 334;
            // 
            // oProgress
            // 
            this.oProgress.Location = new System.Drawing.Point(25, 658);
            this.oProgress.Name = "oProgress";
            this.oProgress.Size = new System.Drawing.Size(960, 23);
            this.oProgress.TabIndex = 335;
            // 
            // oGrid
            // 
            this.oGrid.AllowUserToAddRows = false;
            this.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportHeader,
            this.ReportTitle,
            this.Username,
            this.FromDate,
            this.ToDate,
            this.Progress,
            this.Output});
            this.oGrid.Location = new System.Drawing.Point(60, 700);
            this.oGrid.Name = "oGrid";
            this.oGrid.RowHeadersWidth = 51;
            this.oGrid.Size = new System.Drawing.Size(925, 150);
            this.oGrid.TabIndex = 336;
            this.oGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellClick);
            this.oGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellContentClick);
            this.oGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.oGrid_UserDeletedRow);
            // 
            // ReportHeader
            // 
            this.ReportHeader.HeaderText = "Report Header";
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.Width = 200;
            // 
            // ReportTitle
            // 
            this.ReportTitle.HeaderText = "Report Title";
            this.ReportTitle.Name = "ReportTitle";
            this.ReportTitle.Width = 200;
            // 
            // Username
            // 
            this.Username.HeaderText = "User Name";
            this.Username.Name = "Username";
            // 
            // FromDate
            // 
            this.FromDate.HeaderText = "From Date";
            this.FromDate.Name = "FromDate";
            this.FromDate.Width = 120;
            // 
            // ToDate
            // 
            this.ToDate.HeaderText = "To Date";
            this.ToDate.Name = "ToDate";
            this.ToDate.Width = 120;
            // 
            // Progress
            // 
            this.Progress.HeaderText = "Progress";
            this.Progress.Name = "Progress";
            this.Progress.Width = 60;
            // 
            // Output
            // 
            this.Output.HeaderText = "Output";
            this.Output.Name = "Output";
            this.Output.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Output.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(315, 88);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(110, 20);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Group Name";
            // 
            // cGroup
            // 
            this.cGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cGroup.FormattingEnabled = true;
            this.cGroup.Location = new System.Drawing.Point(319, 112);
            this.cGroup.Name = "cGroup";
            this.cGroup.Size = new System.Drawing.Size(325, 24);
            this.cGroup.TabIndex = 337;
            this.cGroup.DropDown += new System.EventHandler(this.cGroup_DropDown);
            this.cGroup.SelectionChangeCommitted += new System.EventHandler(this.cGroup_SelectedIndexChanged);
            // 
            // bCOnfigureReports
            // 
            this.bCOnfigureReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCOnfigureReports.Location = new System.Drawing.Point(32, 340);
            this.bCOnfigureReports.Name = "bCOnfigureReports";
            this.bCOnfigureReports.Size = new System.Drawing.Size(260, 37);
            this.bCOnfigureReports.TabIndex = 338;
            this.bCOnfigureReports.Text = "Configure Data Trend Reports";
            this.bCOnfigureReports.UseVisualStyleBackColor = true;
            this.bCOnfigureReports.Visible = false;
            this.bCOnfigureReports.Click += new System.EventHandler(this.bCOnfigureReports_Click);
            // 
            // bConfigureAlarmReports
            // 
            this.bConfigureAlarmReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConfigureAlarmReports.Location = new System.Drawing.Point(32, 473);
            this.bConfigureAlarmReports.Name = "bConfigureAlarmReports";
            this.bConfigureAlarmReports.Size = new System.Drawing.Size(260, 37);
            this.bConfigureAlarmReports.TabIndex = 338;
            this.bConfigureAlarmReports.Text = "Configure Alarm Reports";
            this.bConfigureAlarmReports.UseVisualStyleBackColor = true;
            this.bConfigureAlarmReports.Visible = false;
            this.bConfigureAlarmReports.Click += new System.EventHandler(this.bConfigureAlarmReports_Click);
            // 
            // bGenerateChart
            // 
            this.bGenerateChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGenerateChart.Location = new System.Drawing.Point(713, 412);
            this.bGenerateChart.Name = "bGenerateChart";
            this.bGenerateChart.Size = new System.Drawing.Size(178, 47);
            this.bGenerateChart.TabIndex = 328;
            this.bGenerateChart.Text = "Generate Chart";
            this.bGenerateChart.UseVisualStyleBackColor = true;
            this.bGenerateChart.Click += new System.EventHandler(this.bGenerateChart_Click);
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(32, 516);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(260, 37);
            this.Button1.TabIndex = 339;
            this.Button1.Text = "Synchronize Point Names";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // bConfigure
            // 
            this.bConfigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConfigure.Location = new System.Drawing.Point(32, 297);
            this.bConfigure.Name = "bConfigure";
            this.bConfigure.Size = new System.Drawing.Size(260, 37);
            this.bConfigure.TabIndex = 340;
            this.bConfigure.Text = "Configure Main Parameters";
            this.bConfigure.UseVisualStyleBackColor = true;
            this.bConfigure.Click += new System.EventHandler(this.bConfigure_Click);
            // 
            // btnExcursionReport
            // 
            this.btnExcursionReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcursionReport.Location = new System.Drawing.Point(32, 383);
            this.btnExcursionReport.Name = "btnExcursionReport";
            this.btnExcursionReport.Size = new System.Drawing.Size(260, 37);
            this.btnExcursionReport.TabIndex = 341;
            this.btnExcursionReport.Text = "Configure Excursion Reports";
            this.btnExcursionReport.UseVisualStyleBackColor = true;
            this.btnExcursionReport.Visible = false;
            this.btnExcursionReport.Click += new System.EventHandler(this.btnExcursionReport_Click);
            // 
            // btnBatteryPercentage
            // 
            this.btnBatteryPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatteryPercentage.Location = new System.Drawing.Point(32, 430);
            this.btnBatteryPercentage.Name = "btnBatteryPercentage";
            this.btnBatteryPercentage.Size = new System.Drawing.Size(260, 37);
            this.btnBatteryPercentage.TabIndex = 342;
            this.btnBatteryPercentage.Text = "Configure Battery  Reports";
            this.btnBatteryPercentage.UseVisualStyleBackColor = true;
            this.btnBatteryPercentage.Visible = false;
            this.btnBatteryPercentage.Click += new System.EventHandler(this.btnBatteryPercentage_Click);
            // 
            // ViewData
            // 
            this.ViewData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewData.Location = new System.Drawing.Point(713, 482);
            this.ViewData.Name = "ViewData";
            this.ViewData.Size = new System.Drawing.Size(178, 47);
            this.ViewData.TabIndex = 343;
            this.ViewData.Text = "View Data";
            this.ViewData.UseVisualStyleBackColor = true;
            this.ViewData.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ViewGroups
            // 
            this.ViewGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewGroups.Location = new System.Drawing.Point(32, 559);
            this.ViewGroups.Name = "ViewGroups";
            this.ViewGroups.Size = new System.Drawing.Size(260, 37);
            this.ViewGroups.TabIndex = 344;
            this.ViewGroups.Text = "Configure View Groups";
            this.ViewGroups.UseVisualStyleBackColor = true;
            this.ViewGroups.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 901);
            this.Controls.Add(this.ViewGroups);
            this.Controls.Add(this.ViewData);
            this.Controls.Add(this.btnBatteryPercentage);
            this.Controls.Add(this.btnExcursionReport);
            this.Controls.Add(this.bConfigure);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.bConfigureAlarmReports);
            this.Controls.Add(this.bCOnfigureReports);
            this.Controls.Add(this.cGroup);
            this.Controls.Add(this.oGrid);
            this.Controls.Add(this.oProgress);
            this.Controls.Add(this.cInterval);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.oReportGrid);
            this.Controls.Add(this.bGenerateChart);
            this.Controls.Add(this.bGenerate);
            this.Controls.Add(this.tr_ToDate);
            this.Controls.Add(this.tr_FromDate);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oReportGrid)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private DataGridViewTextBoxColumn ReportHeader;
        private DataGridViewTextBoxColumn ReportTitle;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn FromDate;
        private DataGridViewTextBoxColumn ToDate;
        private DataGridViewTextBoxColumn Progress;
        private DataGridViewTextBoxColumn Output;
    }
}