using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgSelectTrentDataPoint : Form
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
            var DataGridViewCellStyle4 = new DataGridViewCellStyle();
            OK_Button = new Button();
            OK_Button.Click += new EventHandler(OK_Button_Click);
            Cancel_Button = new Button();
            Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            oGrid = new DataGridView();
            oGrid.CellClick += new DataGridViewCellEventHandler(oGrid_CellClick);
            TrendLogID = new DataGridViewTextBoxColumn();
            TrendLogType = new DataGridViewTextBoxColumn();
            TrendLogName = new DataGridViewTextBoxColumn();
            bHide = new CheckBox();
            bHide.CheckedChanged += new EventHandler(bHide_CheckedChanged);
            tPointName = new TextBox();
            tPointName.TextChanged += new EventHandler(tPointName_TextChanged);
            bGetSimilorPoints = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            SuspendLayout();
            // 
            // OK_Button
            // 
            OK_Button.Anchor = AnchorStyles.None;
            OK_Button.Enabled = false;
            OK_Button.Location = new Point(575, 69);
            OK_Button.Name = "OK_Button";
            OK_Button.Size = new Size(67, 23);
            OK_Button.TabIndex = 0;
            OK_Button.Text = "Select";
            // 
            // Cancel_Button
            // 
            Cancel_Button.Anchor = AnchorStyles.None;
            Cancel_Button.DialogResult = DialogResult.Cancel;
            Cancel_Button.Location = new Point(575, 112);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new Size(67, 23);
            Cancel_Button.TabIndex = 1;
            Cancel_Button.Text = "Cancel";
            // 
            // oGrid
            // 
            oGrid.AllowUserToAddRows = false;
            oGrid.AllowUserToDeleteRows = false;
            oGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            oGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oGrid.Columns.AddRange(new DataGridViewColumn[] { TrendLogID, TrendLogType, TrendLogName });
            oGrid.Location = new Point(12, 69);
            oGrid.Name = "oGrid";
            oGrid.ReadOnly = true;
            oGrid.Size = new Size(517, 451);
            oGrid.TabIndex = 1;
            // 
            // TrendLogID
            // 
            TrendLogID.HeaderText = "TrendLogID";
            TrendLogID.Name = "TrendLogID";
            TrendLogID.ReadOnly = true;
            // 
            // TrendLogType
            // 
            TrendLogType.HeaderText = "TrendLogType";
            TrendLogType.Name = "TrendLogType";
            TrendLogType.ReadOnly = true;
            TrendLogType.Visible = false;
            // 
            // TrendLogName
            // 
            DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            TrendLogName.DefaultCellStyle = DataGridViewCellStyle4;
            TrendLogName.HeaderText = "TrendLogName";
            TrendLogName.Name = "TrendLogName";
            TrendLogName.ReadOnly = true;
            TrendLogName.Width = 350;
            // 
            // bHide
            // 
            bHide.AutoSize = true;
            bHide.Checked = true;
            bHide.CheckState = CheckState.Checked;
            bHide.Location = new Point(468, 33);
            bHide.Name = "bHide";
            bHide.Size = new Size(140, 17);
            bHide.TabIndex = 2;
            bHide.Text = "Hide Already Used Logs";
            bHide.UseVisualStyleBackColor = true;
            // 
            // tPointName
            // 
            tPointName.Location = new Point(13, 31);
            tPointName.Name = "tPointName";
            tPointName.Size = new Size(410, 20);
            tPointName.TabIndex = 3;
            // 
            // bGetSimilorPoints
            // 
            bGetSimilorPoints.AutoSize = true;
            bGetSimilorPoints.Location = new Point(13, 8);
            bGetSimilorPoints.Name = "bGetSimilorPoints";
            bGetSimilorPoints.Size = new Size(156, 17);
            bGetSimilorPoints.TabIndex = 4;
            bGetSimilorPoints.Text = "Search Similar Point Names";
            bGetSimilorPoints.UseVisualStyleBackColor = true;
            // 
            // DlgSelectTrentDataPoint
            // 
            AcceptButton = OK_Button;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = Cancel_Button;
            ClientSize = new Size(681, 535);
            Controls.Add(bGetSimilorPoints);
            Controls.Add(tPointName);
            Controls.Add(bHide);
            Controls.Add(Cancel_Button);
            Controls.Add(OK_Button);
            Controls.Add(oGrid);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgSelectTrentDataPoint";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "DlgSelectTrentDataPoint";
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            Load += new EventHandler(DlgSelectTrentDataPoint_Load);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Button OK_Button;
        internal Button Cancel_Button;
        internal DataGridView oGrid;
        internal CheckBox bHide;
        internal DataGridViewTextBoxColumn TrendLogID;
        internal DataGridViewTextBoxColumn TrendLogType;
        internal DataGridViewTextBoxColumn TrendLogName;
        internal TextBox tPointName;
        internal CheckBox bGetSimilorPoints;
    }
}