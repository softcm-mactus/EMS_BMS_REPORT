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
            components = new System.ComponentModel.Container();
            oGrid = new DataGridView();
            oGrid.CellContentClick += new DataGridViewCellEventHandler(oGrid_CellContentClick);
            oGrid.CurrentCellChanged += new EventHandler(oGrid_CurrentCellChanged);
            viewData = new Button();
            viewData.Click += new EventHandler(ViewData_Click);
            Label4 = new Label();
            Label3 = new Label();
            cGroup = new ComboBox();
            cGroup.SelectedIndexChanged += new EventHandler(cGroup_SelectedIndexChanged);
            Label6 = new Label();
            oReports = new ComboBox();
            oReports.SelectedIndexChanged += new EventHandler(Reports_SelectedIndexChanged);
            Label1 = new Label();
            SelectColumn = new Button();
            SelectColumn.Click += new EventHandler(Button1_Click);
            ColInfo = new TextBox();
            CheckInfo = new TextBox();
            CheckInfo.TextChanged += new EventHandler(CheckInfo_TextChanged);
            ColQuery = new TextBox();
            ColQuery.MouseClick += new MouseEventHandler(ColQuery_MouseClick);
            oEndTime = new DateTimePicker();
            oEndTime.ValueChanged += new EventHandler(oEndTime_ValueChanged);
            oStartTime = new DateTimePicker();
            oStartTime.ValueChanged += new EventHandler(oStartTime_ValueChanged);
            oEndDate = new DateTimePicker();
            oEndDate.ValueChanged += new EventHandler(oEndDate_ValueChanged);
            oStartDate = new DateTimePicker();
            oStartDate.ValueChanged += new EventHandler(oStartDate_ValueChanged);
            Label2 = new Label();
            Label2.Click += new EventHandler(Label2_Click);
            oTolerance = new NumericUpDown();
            oTolerance.ValueChanged += new EventHandler(oTolerance_ValueChanged);
            oPrecision = new NumericUpDown();
            oPrecision.ValueChanged += new EventHandler(NumericUpDown2_ValueChanged);
            Label5 = new Label();
            Label5.Click += new EventHandler(Label5_Click);
            Label7 = new Label();
            oIncludeEvents = new CheckBox();
            oIncludeEvents.CheckedChanged += new EventHandler(CheckBox1_CheckedChanged);
            RowQuery = new TextBox();
            RowQuery.MouseClick += new MouseEventHandler(RowQuery_MouseClick);
            Timer1 = new Timer(components);
            Timer1.Tick += new EventHandler(Timer1_Tick);
            ToolTip1 = new ToolTip(components);
            ToolTip2 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oTolerance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)oPrecision).BeginInit();
            SuspendLayout();
            // 
            // oGrid
            // 
            oGrid.AllowUserToAddRows = false;
            oGrid.AllowUserToDeleteRows = false;
            oGrid.AllowUserToResizeRows = false;
            oGrid.Location = new Point(13, 117);
            oGrid.MultiSelect = false;
            oGrid.Name = "oGrid";
            oGrid.Size = new Size(1361, 516);
            oGrid.TabIndex = 1;
            // 
            // viewData
            // 
            viewData.Location = new Point(1312, 18);
            viewData.Name = "viewData";
            viewData.Size = new Size(62, 56);
            viewData.TabIndex = 4;
            viewData.Text = "View";
            viewData.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label4.Location = new Point(14, 50);
            Label4.Name = "Label4";
            Label4.Size = new Size(73, 20);
            Label4.TabIndex = 328;
            Label4.Text = "To Date";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label3.Location = new Point(14, 17);
            Label3.Name = "Label3";
            Label3.Size = new Size(94, 20);
            Label3.TabIndex = 329;
            Label3.Text = "From Date";
            // 
            // cGroup
            // 
            cGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            cGroup.FormattingEnabled = true;
            cGroup.Location = new Point(465, 13);
            cGroup.Name = "cGroup";
            cGroup.Size = new Size(312, 24);
            cGroup.TabIndex = 339;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label6.Location = new Point(349, 16);
            Label6.Name = "Label6";
            Label6.Size = new Size(110, 20);
            Label6.TabIndex = 338;
            Label6.Text = "Group Name";
            // 
            // oReports
            // 
            oReports.DropDownStyle = ComboBoxStyle.DropDownList;
            oReports.FormattingEnabled = true;
            oReports.Location = new Point(465, 47);
            oReports.Name = "oReports";
            oReports.Size = new Size(312, 24);
            oReports.TabIndex = 341;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label1.Location = new Point(349, 50);
            Label1.Name = "Label1";
            Label1.Size = new Size(115, 20);
            Label1.TabIndex = 340;
            Label1.Text = "Report Name";
            // 
            // SelectColumn
            // 
            SelectColumn.Location = new Point(1182, 18);
            SelectColumn.Name = "SelectColumn";
            SelectColumn.Size = new Size(124, 56);
            SelectColumn.TabIndex = 344;
            SelectColumn.Text = "Select Columns";
            SelectColumn.UseVisualStyleBackColor = true;
            // 
            // ColInfo
            // 
            ColInfo.BackColor = SystemColors.ControlLightLight;
            ColInfo.Font = new Font("Courier New", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ColInfo.Location = new Point(13, 630);
            ColInfo.Multiline = true;
            ColInfo.Name = "ColInfo";
            ColInfo.ReadOnly = true;
            ColInfo.Size = new Size(446, 58);
            ColInfo.TabIndex = 347;
            // 
            // CheckInfo
            // 
            CheckInfo.BackColor = SystemColors.ControlLightLight;
            CheckInfo.Font = new Font("Courier New", 11.25f, FontStyle.Bold);
            CheckInfo.Location = new Point(465, 630);
            CheckInfo.Multiline = true;
            CheckInfo.Name = "CheckInfo";
            CheckInfo.ReadOnly = true;
            CheckInfo.Size = new Size(253, 58);
            CheckInfo.TabIndex = 348;
            // 
            // ColQuery
            // 
            ColQuery.BackColor = SystemColors.ControlLightLight;
            ColQuery.Font = new Font("Courier New", 11.25f, FontStyle.Bold);
            ColQuery.Location = new Point(724, 630);
            ColQuery.Multiline = true;
            ColQuery.Name = "ColQuery";
            ColQuery.ReadOnly = true;
            ColQuery.Size = new Size(250, 58);
            ColQuery.TabIndex = 349;
            // 
            // oEndTime
            // 
            oEndTime.Format = DateTimePickerFormat.Time;
            oEndTime.ImeMode = ImeMode.Disable;
            oEndTime.Location = new Point(222, 51);
            oEndTime.Name = "oEndTime";
            oEndTime.ShowUpDown = true;
            oEndTime.Size = new Size(102, 22);
            oEndTime.TabIndex = 346;
            oEndTime.Value = new DateTime(2023, 11, 22, 21, 0, 13, 0);
            // 
            // oStartTime
            // 
            oStartTime.Format = DateTimePickerFormat.Time;
            oStartTime.Location = new Point(222, 17);
            oStartTime.Name = "oStartTime";
            oStartTime.ShowUpDown = true;
            oStartTime.Size = new Size(102, 22);
            oStartTime.TabIndex = 345;
            oStartTime.Value = new DateTime(2023, 11, 22, 21, 0, 13, 0);
            // 
            // oEndDate
            // 
            oEndDate.Format = DateTimePickerFormat.Short;
            oEndDate.Location = new Point(114, 50);
            oEndDate.Name = "oEndDate";
            oEndDate.Size = new Size(102, 22);
            oEndDate.TabIndex = 343;
            oEndDate.Value = new DateTime(2023, 11, 22, 20, 59, 38, 0);
            // 
            // oStartDate
            // 
            oStartDate.Format = DateTimePickerFormat.Short;
            oStartDate.Location = new Point(114, 16);
            oStartDate.Name = "oStartDate";
            oStartDate.Size = new Size(102, 22);
            oStartDate.TabIndex = 342;
            oStartDate.Value = new DateTime(2023, 11, 20, 21, 37, 0, 0);
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label2.Location = new Point(790, 16);
            Label2.Name = "Label2";
            Label2.Size = new Size(88, 20);
            Label2.TabIndex = 350;
            Label2.Text = "Tolerance";
            // 
            // oTolerance
            // 
            oTolerance.Location = new Point(885, 17);
            oTolerance.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            oTolerance.Name = "oTolerance";
            oTolerance.Size = new Size(96, 22);
            oTolerance.TabIndex = 352;
            oTolerance.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // oPrecision
            // 
            oPrecision.Location = new Point(885, 52);
            oPrecision.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            oPrecision.Minimum = new decimal(new int[] { 1, 0, 0, (int)-2147483648L });
            oPrecision.Name = "oPrecision";
            oPrecision.Size = new Size(96, 22);
            oPrecision.TabIndex = 354;
            oPrecision.Value = new decimal(new int[] { 1, 0, 0, (int)-2147483648L });
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label5.Location = new Point(796, 51);
            Label5.Name = "Label5";
            Label5.Size = new Size(82, 20);
            Label5.TabIndex = 353;
            Label5.Text = "Precision";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label7.Location = new Point(987, 18);
            Label7.Name = "Label7";
            Label7.Size = new Size(32, 20);
            Label7.TabIndex = 355;
            Label7.Text = "ms";
            // 
            // oIncludeEvents
            // 
            oIncludeEvents.AutoSize = true;
            oIncludeEvents.Location = new Point(1049, 19);
            oIncludeEvents.Name = "oIncludeEvents";
            oIncludeEvents.Size = new Size(113, 20);
            oIncludeEvents.TabIndex = 356;
            oIncludeEvents.Text = "Include Events";
            oIncludeEvents.UseVisualStyleBackColor = true;
            // 
            // RowQuery
            // 
            RowQuery.BackColor = SystemColors.ControlLightLight;
            RowQuery.Font = new Font("Courier New", 11.25f, FontStyle.Bold);
            RowQuery.Location = new Point(1010, 630);
            RowQuery.Multiline = true;
            RowQuery.Name = "RowQuery";
            RowQuery.ReadOnly = true;
            RowQuery.Size = new Size(250, 58);
            RowQuery.TabIndex = 357;
            // 
            // Timer1
            // 
            Timer1.Interval = 1500;
            // 
            // ToolTip1
            // 
            ToolTip1.AutoPopDelay = 5000;
            ToolTip1.InitialDelay = 0;
            ToolTip1.ReshowDelay = 0;
            // 
            // dlgTableView
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 689);
            Controls.Add(RowQuery);
            Controls.Add(oIncludeEvents);
            Controls.Add(Label7);
            Controls.Add(oPrecision);
            Controls.Add(Label5);
            Controls.Add(oTolerance);
            Controls.Add(Label2);
            Controls.Add(ColQuery);
            Controls.Add(CheckInfo);
            Controls.Add(ColInfo);
            Controls.Add(oEndTime);
            Controls.Add(oStartTime);
            Controls.Add(SelectColumn);
            Controls.Add(oEndDate);
            Controls.Add(oStartDate);
            Controls.Add(oReports);
            Controls.Add(Label1);
            Controls.Add(cGroup);
            Controls.Add(Label6);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(viewData);
            Controls.Add(oGrid);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "dlgTableView";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "dlgColumnsConfiguration";
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)oTolerance).EndInit();
            ((System.ComponentModel.ISupportInitialize)oPrecision).EndInit();
            Load += new EventHandler(dlgTableView_load);
            Resize += new EventHandler(dlgTableView_Resize);
            ResumeLayout(false);
            PerformLayout();

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