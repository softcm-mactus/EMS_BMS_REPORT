using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class dlgTableView : Form
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
            this.oGrid = new System.Windows.Forms.DataGridView();
            this.viewData = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cGroup = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.oReports = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SelectColumn = new System.Windows.Forms.Button();
            this.ColInfo = new System.Windows.Forms.TextBox();
            this.CheckInfo = new System.Windows.Forms.TextBox();
            this.ColQuery = new System.Windows.Forms.TextBox();
            this.oEndTime = new System.Windows.Forms.DateTimePicker();
            this.oStartTime = new System.Windows.Forms.DateTimePicker();
            this.oEndDate = new System.Windows.Forms.DateTimePicker();
            this.oStartDate = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.oTolerance = new System.Windows.Forms.NumericUpDown();
            this.oPrecision = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.oIncludeEvents = new System.Windows.Forms.CheckBox();
            this.RowQuery = new System.Windows.Forms.TextBox();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // oGrid
            // 
            this.oGrid.AllowUserToAddRows = false;
            this.oGrid.AllowUserToDeleteRows = false;
            this.oGrid.AllowUserToResizeRows = false;
            this.oGrid.Location = new System.Drawing.Point(13, 117);
            this.oGrid.MultiSelect = false;
            this.oGrid.Name = "oGrid";
            this.oGrid.Size = new System.Drawing.Size(1361, 516);
            this.oGrid.TabIndex = 1;
            this.oGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellContentClick);
            this.oGrid.CurrentCellChanged += new System.EventHandler(this.oGrid_CurrentCellChanged);
            // 
            // viewData
            // 
            this.viewData.Location = new System.Drawing.Point(1312, 18);
            this.viewData.Name = "viewData";
            this.viewData.Size = new System.Drawing.Size(62, 56);
            this.viewData.TabIndex = 4;
            this.viewData.Text = "View";
            this.viewData.UseVisualStyleBackColor = true;
            this.viewData.Click += new System.EventHandler(this.ViewData_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(14, 50);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(73, 20);
            this.Label4.TabIndex = 328;
            this.Label4.Text = "To Date";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(14, 17);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(94, 20);
            this.Label3.TabIndex = 329;
            this.Label3.Text = "From Date";
            // 
            // cGroup
            // 
            this.cGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cGroup.FormattingEnabled = true;
            this.cGroup.Location = new System.Drawing.Point(465, 13);
            this.cGroup.Name = "cGroup";
            this.cGroup.Size = new System.Drawing.Size(312, 24);
            this.cGroup.TabIndex = 339;
            this.cGroup.SelectedIndexChanged += new System.EventHandler(this.cGroup_SelectedIndexChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(349, 16);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(110, 20);
            this.Label6.TabIndex = 338;
            this.Label6.Text = "Group Name";
            // 
            // oReports
            // 
            this.oReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oReports.FormattingEnabled = true;
            this.oReports.Location = new System.Drawing.Point(465, 47);
            this.oReports.Name = "oReports";
            this.oReports.Size = new System.Drawing.Size(312, 24);
            this.oReports.TabIndex = 341;
            this.oReports.SelectedIndexChanged += new System.EventHandler(this.Reports_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(349, 50);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(115, 20);
            this.Label1.TabIndex = 340;
            this.Label1.Text = "Report Name";
            // 
            // SelectColumn
            // 
            this.SelectColumn.Location = new System.Drawing.Point(1182, 18);
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.Size = new System.Drawing.Size(124, 56);
            this.SelectColumn.TabIndex = 344;
            this.SelectColumn.Text = "Select Columns";
            this.SelectColumn.UseVisualStyleBackColor = true;
            this.SelectColumn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ColInfo
            // 
            this.ColInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ColInfo.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColInfo.Location = new System.Drawing.Point(13, 630);
            this.ColInfo.Multiline = true;
            this.ColInfo.Name = "ColInfo";
            this.ColInfo.ReadOnly = true;
            this.ColInfo.Size = new System.Drawing.Size(446, 58);
            this.ColInfo.TabIndex = 347;
            // 
            // CheckInfo
            // 
            this.CheckInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CheckInfo.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold);
            this.CheckInfo.Location = new System.Drawing.Point(465, 630);
            this.CheckInfo.Multiline = true;
            this.CheckInfo.Name = "CheckInfo";
            this.CheckInfo.ReadOnly = true;
            this.CheckInfo.Size = new System.Drawing.Size(253, 58);
            this.CheckInfo.TabIndex = 348;
            this.CheckInfo.TextChanged += new System.EventHandler(this.CheckInfo_TextChanged);
            // 
            // ColQuery
            // 
            this.ColQuery.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ColQuery.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold);
            this.ColQuery.Location = new System.Drawing.Point(724, 630);
            this.ColQuery.Multiline = true;
            this.ColQuery.Name = "ColQuery";
            this.ColQuery.ReadOnly = true;
            this.ColQuery.Size = new System.Drawing.Size(250, 58);
            this.ColQuery.TabIndex = 349;
            this.ColQuery.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColQuery_MouseClick);
            // 
            // oEndTime
            // 
            this.oEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.oEndTime.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.oEndTime.Location = new System.Drawing.Point(222, 51);
            this.oEndTime.Name = "oEndTime";
            this.oEndTime.ShowUpDown = true;
            this.oEndTime.Size = new System.Drawing.Size(102, 22);
            this.oEndTime.TabIndex = 346;
            this.oEndTime.Value = new System.DateTime(2023, 11, 22, 21, 0, 13, 0);
            this.oEndTime.ValueChanged += new System.EventHandler(this.oEndTime_ValueChanged);
            // 
            // oStartTime
            // 
            this.oStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.oStartTime.Location = new System.Drawing.Point(222, 17);
            this.oStartTime.Name = "oStartTime";
            this.oStartTime.ShowUpDown = true;
            this.oStartTime.Size = new System.Drawing.Size(102, 22);
            this.oStartTime.TabIndex = 345;
            this.oStartTime.Value = new System.DateTime(2023, 11, 22, 21, 0, 13, 0);
            this.oStartTime.ValueChanged += new System.EventHandler(this.oStartTime_ValueChanged);
            // 
            // oEndDate
            // 
            this.oEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.oEndDate.Location = new System.Drawing.Point(114, 50);
            this.oEndDate.Name = "oEndDate";
            this.oEndDate.Size = new System.Drawing.Size(102, 22);
            this.oEndDate.TabIndex = 343;
            this.oEndDate.Value = new System.DateTime(2023, 11, 22, 20, 59, 38, 0);
            this.oEndDate.ValueChanged += new System.EventHandler(this.oEndDate_ValueChanged);
            // 
            // oStartDate
            // 
            this.oStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.oStartDate.Location = new System.Drawing.Point(114, 16);
            this.oStartDate.Name = "oStartDate";
            this.oStartDate.Size = new System.Drawing.Size(102, 22);
            this.oStartDate.TabIndex = 342;
            this.oStartDate.Value = new System.DateTime(2023, 11, 20, 21, 37, 0, 0);
            this.oStartDate.ValueChanged += new System.EventHandler(this.oStartDate_ValueChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(790, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(88, 20);
            this.Label2.TabIndex = 350;
            this.Label2.Text = "Tolerance";
            this.Label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // oTolerance
            // 
            this.oTolerance.Location = new System.Drawing.Point(885, 17);
            this.oTolerance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.oTolerance.Name = "oTolerance";
            this.oTolerance.Size = new System.Drawing.Size(96, 22);
            this.oTolerance.TabIndex = 352;
            this.oTolerance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.oTolerance.ValueChanged += new System.EventHandler(this.oTolerance_ValueChanged);
            // 
            // oPrecision
            // 
            this.oPrecision.Location = new System.Drawing.Point(885, 52);
            this.oPrecision.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.oPrecision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.oPrecision.Name = "oPrecision";
            this.oPrecision.Size = new System.Drawing.Size(96, 22);
            this.oPrecision.TabIndex = 354;
            this.oPrecision.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.oPrecision.ValueChanged += new System.EventHandler(this.NumericUpDown2_ValueChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(796, 51);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(82, 20);
            this.Label5.TabIndex = 353;
            this.Label5.Text = "Precision";
            this.Label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(987, 18);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(37, 20);
            this.Label7.TabIndex = 355;
            this.Label7.Text = "sec";
            // 
            // oIncludeEvents
            // 
            this.oIncludeEvents.AutoSize = true;
            this.oIncludeEvents.Location = new System.Drawing.Point(1049, 19);
            this.oIncludeEvents.Name = "oIncludeEvents";
            this.oIncludeEvents.Size = new System.Drawing.Size(113, 20);
            this.oIncludeEvents.TabIndex = 356;
            this.oIncludeEvents.Text = "Include Events";
            this.oIncludeEvents.UseVisualStyleBackColor = true;
            this.oIncludeEvents.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // RowQuery
            // 
            this.RowQuery.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RowQuery.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold);
            this.RowQuery.Location = new System.Drawing.Point(1010, 630);
            this.RowQuery.Multiline = true;
            this.RowQuery.Name = "RowQuery";
            this.RowQuery.ReadOnly = true;
            this.RowQuery.Size = new System.Drawing.Size(250, 58);
            this.RowQuery.TabIndex = 357;
            this.RowQuery.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RowQuery_MouseClick);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1500;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ToolTip1
            // 
            this.ToolTip1.AutoPopDelay = 5000;
            this.ToolTip1.InitialDelay = 0;
            this.ToolTip1.ReshowDelay = 0;
            // 
            // dlgTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 689);
            this.Controls.Add(this.RowQuery);
            this.Controls.Add(this.oIncludeEvents);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.oPrecision);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.oTolerance);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.ColQuery);
            this.Controls.Add(this.CheckInfo);
            this.Controls.Add(this.ColInfo);
            this.Controls.Add(this.oEndTime);
            this.Controls.Add(this.oStartTime);
            this.Controls.Add(this.SelectColumn);
            this.Controls.Add(this.oEndDate);
            this.Controls.Add(this.oStartDate);
            this.Controls.Add(this.oReports);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cGroup);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.viewData);
            this.Controls.Add(this.oGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dlgTableView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgColumnsConfiguration";
            this.Load += new System.EventHandler(this.dlgTableView_load);
            this.Resize += new System.EventHandler(this.dlgTableView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oPrecision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal DataGridView oGrid;
        internal Button viewData;
        internal Label Label4;
        internal Label Label3;
        internal ComboBox cGroup;
        internal Label Label6;
        internal ComboBox oReports;
        internal Label Label1;
        internal DateTimePicker oStartDate;
        internal DateTimePicker oEndDate;
        internal Button SelectColumn;
        internal DateTimePicker oEndTime;
        internal DateTimePicker oStartTime;
        internal TextBox ColInfo;
        internal TextBox CheckInfo;
        internal TextBox ColQuery;
        internal Label Label2;
        internal NumericUpDown oTolerance;
        internal NumericUpDown oPrecision;
        internal Label Label5;
        internal Label Label7;
        internal CheckBox oIncludeEvents;
        internal TextBox RowQuery;
        internal Timer Timer1;
        internal ToolTip ToolTip1;
        internal ToolTip ToolTip2;
    }
}