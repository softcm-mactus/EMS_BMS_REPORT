using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgReportsConfiguration : Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.oGrid = new System.Windows.Forms.DataGridView();
            this.ReportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportTitlle2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrntTime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrintBy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrintDates = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ConfCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PrMinMax = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrSV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bAddNewReport = new System.Windows.Forms.Button();
            this.bDeleteReport = new System.Windows.Forms.Button();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ReportTemplate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ReportType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DefaultTimeInterval = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DataAggType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(1094, 489);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(195, 36);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(4, 4);
            this.OK_Button.Margin = new System.Windows.Forms.Padding(4);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(89, 28);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "Update";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(101, 4);
            this.Cancel_Button.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(89, 28);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Close";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // oGrid
            // 
            this.oGrid.AllowUserToAddRows = false;
            this.oGrid.AllowUserToDeleteRows = false;
            this.oGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReportID,
            this.ReportTemplate,
            this.ReportType,
            this.ReportGroup,
            this.ReportTitle,
            this.ReportTitlle2,
            this.PrntTime,
            this.PrintBy,
            this.PrintDates,
            this.DefaultTimeInterval,
            this.DataAggType,
            this.ConfCol,
            this.PrMinMax,
            this.PrSV});
            this.oGrid.Location = new System.Drawing.Point(13, 12);
            this.oGrid.Name = "oGrid";
            this.oGrid.Size = new System.Drawing.Size(1276, 461);
            this.oGrid.TabIndex = 1;
            this.oGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellClick);
            this.oGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.oGrid_DataError);
            // 
            // ReportID
            // 
            this.ReportID.HeaderText = "ReportID";
            this.ReportID.Name = "ReportID";
            this.ReportID.Visible = false;
            this.ReportID.Width = 80;
            // 
            // ReportGroup
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.ReportGroup.DefaultCellStyle = dataGridViewCellStyle1;
            this.ReportGroup.HeaderText = "Report Group";
            this.ReportGroup.Name = "ReportGroup";
            this.ReportGroup.ReadOnly = true;
            this.ReportGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ReportGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ReportTitle
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReportTitle.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReportTitle.HeaderText = "Report Title";
            this.ReportTitle.Name = "ReportTitle";
            this.ReportTitle.Width = 200;
            // 
            // ReportTitlle2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReportTitlle2.DefaultCellStyle = dataGridViewCellStyle3;
            this.ReportTitlle2.HeaderText = "Report Title 2";
            this.ReportTitlle2.Name = "ReportTitlle2";
            this.ReportTitlle2.Width = 200;
            // 
            // PrntTime
            // 
            this.PrntTime.HeaderText = "Print Gen Time";
            this.PrntTime.Name = "PrntTime";
            this.PrntTime.Width = 70;
            // 
            // PrintBy
            // 
            this.PrintBy.HeaderText = "Print Gen By";
            this.PrintBy.Name = "PrintBy";
            this.PrintBy.Width = 60;
            // 
            // PrintDates
            // 
            this.PrintDates.HeaderText = "PrintFrom ToDate";
            this.PrintDates.Name = "PrintDates";
            this.PrintDates.Width = 70;
            // 
            // ConfCol
            // 
            this.ConfCol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConfCol.HeaderText = "Configure Columns";
            this.ConfCol.Name = "ConfCol";
            this.ConfCol.UseColumnTextForButtonValue = true;
            this.ConfCol.Width = 80;
            // 
            // PrMinMax
            // 
            this.PrMinMax.HeaderText = "Pr Min Max";
            this.PrMinMax.Name = "PrMinMax";
            this.PrMinMax.Width = 70;
            // 
            // PrSV
            // 
            this.PrSV.HeaderText = "Pr SV";
            this.PrSV.Name = "PrSV";
            this.PrSV.Width = 50;
            // 
            // bAddNewReport
            // 
            this.bAddNewReport.Location = new System.Drawing.Point(42, 491);
            this.bAddNewReport.Name = "bAddNewReport";
            this.bAddNewReport.Size = new System.Drawing.Size(175, 33);
            this.bAddNewReport.TabIndex = 2;
            this.bAddNewReport.Text = "Add New Report";
            this.bAddNewReport.UseVisualStyleBackColor = true;
            this.bAddNewReport.Click += new System.EventHandler(this.bAddNewReport_Click);
            // 
            // bDeleteReport
            // 
            this.bDeleteReport.Location = new System.Drawing.Point(261, 492);
            this.bDeleteReport.Name = "bDeleteReport";
            this.bDeleteReport.Size = new System.Drawing.Size(175, 33);
            this.bDeleteReport.TabIndex = 3;
            this.bDeleteReport.Text = "Delete Report";
            this.bDeleteReport.UseVisualStyleBackColor = true;
            this.bDeleteReport.Click += new System.EventHandler(this.bDeleteReport_Click);
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Report Template";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "ProtraitWiderMargin",
            "LandScapeWiderMargin",
            "ProtraitNarrowMargin",
            "LandScapeNarrowMargin"});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.HeaderText = "Report Type";
            this.dataGridViewComboBoxColumn2.Items.AddRange(new object[] {
            "DataReport",
            "AlarmReport"});
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Visible = false;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.AutoComplete = false;
            this.dataGridViewComboBoxColumn3.HeaderText = "Default TimeInterval";
            this.dataGridViewComboBoxColumn3.Items.AddRange(new object[] {
            "1",
            "5",
            "15",
            "30"});
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.AutoComplete = false;
            this.dataGridViewComboBoxColumn4.HeaderText = "Data Agg Type";
            this.dataGridViewComboBoxColumn4.Items.AddRange(new object[] {
            "Instance",
            "Minimum",
            "Average",
            "Maximum"});
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            // 
            // ReportTemplate
            // 
            this.ReportTemplate.HeaderText = "Report Template";
            this.ReportTemplate.Items.AddRange(new object[] {
            "ProtraitWiderMargin",
            "LandScapeWiderMargin",
            "ProtraitNarrowMargin",
            "LandScapeNarrowMargin"});
            this.ReportTemplate.Name = "ReportTemplate";
            // 
            // ReportType
            // 
            this.ReportType.HeaderText = "Report Type";
            this.ReportType.Items.AddRange(new object[] {
            "DataReport",
            "AlarmReport"});
            this.ReportType.Name = "ReportType";
            this.ReportType.Visible = false;
            // 
            // DefaultTimeInterval
            // 
            this.DefaultTimeInterval.AutoComplete = false;
            this.DefaultTimeInterval.HeaderText = "Default TimeInterval";
            this.DefaultTimeInterval.Items.AddRange(new object[] {
            "1",
            "5",
            "15",
            "30"});
            this.DefaultTimeInterval.Name = "DefaultTimeInterval";
            // 
            // DataAggType
            // 
            this.DataAggType.AutoComplete = false;
            this.DataAggType.HeaderText = "Data Agg Type";
            this.DataAggType.Items.AddRange(new object[] {
            "Instance",
            "Minimum",
            "Average",
            "Maximum"});
            this.DataAggType.Name = "DataAggType";
            // 
            // DlgReportsConfiguration
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(1305, 540);
            this.Controls.Add(this.bDeleteReport);
            this.Controls.Add(this.bAddNewReport);
            this.Controls.Add(this.oGrid);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DlgReportsConfiguration";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgReportsConfiguration";
            this.Load += new System.EventHandler(this.DlgReportsConfiguration_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).EndInit();
            this.ResumeLayout(false);

        }
        internal TableLayoutPanel TableLayoutPanel1;
        internal Button OK_Button;
        internal Button Cancel_Button;
        internal DataGridView oGrid;
        internal Button bAddNewReport;
        internal Button bDeleteReport;
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
        internal DataGridViewCheckBoxColumn PrMinMax;
        internal DataGridViewCheckBoxColumn PrSV;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
    }
}