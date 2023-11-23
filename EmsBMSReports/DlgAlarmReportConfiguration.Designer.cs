using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgAlarmReportConfiguration : Form
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
        private System.ComponentModel.IContainer components = null;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var DataGridViewCellStyle7 = new DataGridViewCellStyle();
            var DataGridViewCellStyle8 = new DataGridViewCellStyle();
            bDeleteReport = new Button();
            bDeleteReport.Click += new EventHandler(bDeleteReport_Click);
            oGrid = new DataGridView();
            oGrid.DataError += new DataGridViewDataErrorEventHandler(oGrid_DataError);
            ReportID = new DataGridViewTextBoxColumn();
            ReportTemplate = new DataGridViewComboBoxColumn();
            ReportType = new DataGridViewComboBoxColumn();
            ReportGroup = new DataGridViewTextBoxColumn();
            ReportTitle = new DataGridViewTextBoxColumn();
            ReportTitlle2 = new DataGridViewTextBoxColumn();
            PrntTime = new DataGridViewCheckBoxColumn();
            PrintBy = new DataGridViewCheckBoxColumn();
            PrintDates = new DataGridViewCheckBoxColumn();
            DefaultTimeInterval = new DataGridViewComboBoxColumn();
            DataAggType = new DataGridViewComboBoxColumn();
            ConfCol = new DataGridViewButtonColumn();
            OK_Button = new Button();
            OK_Button.Click += new EventHandler(OK_Button_Click_1);
            Cancel_Button = new Button();
            bAddNewReport = new Button();
            bAddNewReport.Click += new EventHandler(bAddNewReport_Click);
            TableLayoutPanel1 = new TableLayoutPanel();
            bConfigureColumns = new Button();
            bConfigureColumns.Click += new EventHandler(bConfigureColumns_Click);
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            TableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // bDeleteReport
            // 
            bDeleteReport.Location = new Point(247, 483);
            bDeleteReport.Name = "bDeleteReport";
            bDeleteReport.Size = new Size(175, 33);
            bDeleteReport.TabIndex = 7;
            bDeleteReport.Text = "Delete Report";
            bDeleteReport.UseVisualStyleBackColor = true;
            // 
            // oGrid
            // 
            oGrid.AllowUserToAddRows = false;
            oGrid.AllowUserToDeleteRows = false;
            oGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            oGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oGrid.Columns.AddRange(new DataGridViewColumn[] { ReportID, ReportTemplate, ReportType, ReportGroup, ReportTitle, ReportTitlle2, PrntTime, PrintBy, PrintDates, DefaultTimeInterval, DataAggType, ConfCol });
            oGrid.Location = new Point(-1, 3);
            oGrid.Name = "oGrid";
            oGrid.Size = new Size(1074, 461);
            oGrid.TabIndex = 5;
            // 
            // ReportID
            // 
            ReportID.HeaderText = "ReportID";
            ReportID.Name = "ReportID";
            ReportID.Visible = false;
            ReportID.Width = 80;
            // 
            // ReportTemplate
            // 
            ReportTemplate.HeaderText = "Report Template";
            ReportTemplate.Items.AddRange(new object[] { "ProtraitWiderMargin", "LandScapeWiderMargin", "ProtraitNarrowMargin", "LandScapeNarrowMargin" });
            ReportTemplate.Name = "ReportTemplate";
            // 
            // ReportType
            // 
            ReportType.HeaderText = "Report Type";
            ReportType.Items.AddRange(new object[] { "DataReport", "AlarmReport" });
            ReportType.Name = "ReportType";
            ReportType.Visible = false;
            // 
            // ReportGroup
            // 
            ReportGroup.HeaderText = "Report Group";
            ReportGroup.Name = "ReportGroup";
            ReportGroup.ReadOnly = true;
            ReportGroup.Resizable = DataGridViewTriState.True;
            ReportGroup.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ReportTitle
            // 
            DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            ReportTitle.DefaultCellStyle = DataGridViewCellStyle7;
            ReportTitle.HeaderText = "Report Title";
            ReportTitle.Name = "ReportTitle";
            ReportTitle.Width = 300;
            // 
            // ReportTitlle2
            // 
            DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            ReportTitlle2.DefaultCellStyle = DataGridViewCellStyle8;
            ReportTitlle2.HeaderText = "Report Title 2";
            ReportTitlle2.Name = "ReportTitlle2";
            ReportTitlle2.Width = 300;
            // 
            // PrntTime
            // 
            PrntTime.HeaderText = "Print Gen Time";
            PrntTime.Name = "PrntTime";
            PrntTime.Width = 70;
            // 
            // PrintBy
            // 
            PrintBy.HeaderText = "Print Gen By";
            PrintBy.Name = "PrintBy";
            PrintBy.Width = 60;
            // 
            // PrintDates
            // 
            PrintDates.HeaderText = "PrintFrom ToDate";
            PrintDates.Name = "PrintDates";
            PrintDates.Width = 70;
            // 
            // DefaultTimeInterval
            // 
            DefaultTimeInterval.AutoComplete = false;
            DefaultTimeInterval.HeaderText = "Default TimeInterval";
            DefaultTimeInterval.Items.AddRange(new object[] { "1", "5", "15", "30" });
            DefaultTimeInterval.Name = "DefaultTimeInterval";
            DefaultTimeInterval.Visible = false;
            // 
            // DataAggType
            // 
            DataAggType.AutoComplete = false;
            DataAggType.HeaderText = "Data Agg Type";
            DataAggType.Items.AddRange(new object[] { "Instance", "Minimum", "Average", "Maximum" });
            DataAggType.Name = "DataAggType";
            DataAggType.Visible = false;
            // 
            // ConfCol
            // 
            ConfCol.FlatStyle = FlatStyle.Popup;
            ConfCol.HeaderText = "Configure Columns";
            ConfCol.Name = "ConfCol";
            ConfCol.UseColumnTextForButtonValue = true;
            ConfCol.Visible = false;
            ConfCol.Width = 80;
            // 
            // OK_Button
            // 
            OK_Button.Anchor = AnchorStyles.None;
            OK_Button.Location = new Point(4, 4);
            OK_Button.Margin = new Padding(4);
            OK_Button.Name = "OK_Button";
            OK_Button.Size = new Size(89, 28);
            OK_Button.TabIndex = 0;
            OK_Button.Text = "Update";
            // 
            // Cancel_Button
            // 
            Cancel_Button.Anchor = AnchorStyles.None;
            Cancel_Button.DialogResult = DialogResult.Cancel;
            Cancel_Button.Location = new Point(101, 4);
            Cancel_Button.Margin = new Padding(4);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new Size(89, 28);
            Cancel_Button.TabIndex = 1;
            Cancel_Button.Text = "Close";
            // 
            // bAddNewReport
            // 
            bAddNewReport.Location = new Point(28, 482);
            bAddNewReport.Name = "bAddNewReport";
            bAddNewReport.Size = new Size(175, 33);
            bAddNewReport.TabIndex = 6;
            bAddNewReport.Text = "Add New Report";
            bAddNewReport.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel1
            // 
            TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TableLayoutPanel1.ColumnCount = 2;
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Controls.Add(OK_Button, 0, 0);
            TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0);
            TableLayoutPanel1.Location = new Point(783, 480);
            TableLayoutPanel1.Margin = new Padding(4);
            TableLayoutPanel1.Name = "TableLayoutPanel1";
            TableLayoutPanel1.RowCount = 1;
            TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            TableLayoutPanel1.Size = new Size(195, 36);
            TableLayoutPanel1.TabIndex = 4;
            // 
            // bConfigureColumns
            // 
            bConfigureColumns.Location = new Point(498, 484);
            bConfigureColumns.Name = "bConfigureColumns";
            bConfigureColumns.Size = new Size(175, 33);
            bConfigureColumns.TabIndex = 7;
            bConfigureColumns.Text = "Configure Columns";
            bConfigureColumns.UseVisualStyleBackColor = true;
            // 
            // DlgAlarmReportConfiguration
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 562);
            Controls.Add(bConfigureColumns);
            Controls.Add(bDeleteReport);
            Controls.Add(oGrid);
            Controls.Add(bAddNewReport);
            Controls.Add(TableLayoutPanel1);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgAlarmReportConfiguration";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alarm Reports Configuration";
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            TableLayoutPanel1.ResumeLayout(false);
            Load += new EventHandler(DlgAlarmReportConfiguration_Load);
            ResumeLayout(false);

        }

        internal Button bDeleteReport;
        internal DataGridView oGrid;
        internal Button OK_Button;
        internal Button Cancel_Button;
        internal Button bAddNewReport;
        internal TableLayoutPanel TableLayoutPanel1;
        internal DataGridViewTextBoxColumn ReportID;
        internal DataGridViewComboBoxColumn ReportTemplate;
        internal DataGridViewComboBoxColumn ReportType;
        internal DataGridViewTextBoxColumn ReportGroup;
        internal DataGridViewTextBoxColumn ReportTitle;
        internal DataGridViewTextBoxColumn ReportTitlle2;
        internal DataGridViewCheckBoxColumn PrntTime;
        internal DataGridViewCheckBoxColumn PrintBy;
        internal DataGridViewCheckBoxColumn PrintDates;
        internal DataGridViewComboBoxColumn DefaultTimeInterval;
        internal DataGridViewComboBoxColumn DataAggType;
        internal DataGridViewButtonColumn ConfCol;
        internal Button bConfigureColumns;
    }
}