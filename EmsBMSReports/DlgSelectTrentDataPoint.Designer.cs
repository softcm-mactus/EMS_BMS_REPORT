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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.oGrid = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TrendLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrendLogType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrendLogName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bHide = new System.Windows.Forms.CheckBox();
            this.tPointName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(575, 69);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(67, 23);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "Select";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(575, 112);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // oGrid
            // 
            this.oGrid.AllowUserToAddRows = false;
            this.oGrid.AllowUserToDeleteRows = false;
            this.oGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.TrendLogID,
            this.TrendLogType,
            this.TrendLogName});
            this.oGrid.Location = new System.Drawing.Point(12, 72);
            this.oGrid.Name = "oGrid";
            this.oGrid.ReadOnly = true;
            this.oGrid.Size = new System.Drawing.Size(546, 451);
            this.oGrid.TabIndex = 1;
            this.oGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellClick);
            this.oGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellContentClick);
            // 
            // Selected
            // 
            this.Selected.FalseValue = "false";
            this.Selected.HeaderText = "Selected";
            this.Selected.Name = "Selected";
            this.Selected.ReadOnly = true;
            this.Selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Selected.TrueValue = "true";
            this.Selected.Width = 60;
            // 
            // TrendLogID
            // 
            this.TrendLogID.HeaderText = "TrendLogID";
            this.TrendLogID.Name = "TrendLogID";
            this.TrendLogID.ReadOnly = true;
            // 
            // TrendLogType
            // 
            this.TrendLogType.HeaderText = "TrendLogType";
            this.TrendLogType.Name = "TrendLogType";
            this.TrendLogType.ReadOnly = true;
            this.TrendLogType.Visible = false;
            // 
            // TrendLogName
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TrendLogName.DefaultCellStyle = dataGridViewCellStyle1;
            this.TrendLogName.HeaderText = "TrendLogName";
            this.TrendLogName.Name = "TrendLogName";
            this.TrendLogName.ReadOnly = true;
            this.TrendLogName.Width = 350;
            // 
            // bHide
            // 
            this.bHide.AutoSize = true;
            this.bHide.Checked = true;
            this.bHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bHide.Location = new System.Drawing.Point(468, 33);
            this.bHide.Name = "bHide";
            this.bHide.Size = new System.Drawing.Size(140, 17);
            this.bHide.TabIndex = 2;
            this.bHide.Text = "Hide Already Used Logs";
            this.bHide.UseVisualStyleBackColor = true;
            this.bHide.CheckedChanged += new System.EventHandler(this.bHide_CheckedChanged);
            // 
            // tPointName
            // 
            this.tPointName.Location = new System.Drawing.Point(13, 31);
            this.tPointName.Name = "tPointName";
            this.tPointName.Size = new System.Drawing.Size(410, 20);
            this.tPointName.TabIndex = 3;
            this.tPointName.TextChanged += new System.EventHandler(this.tPointName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search Data Points";
            // 
            // DlgSelectTrentDataPoint
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(681, 535);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tPointName);
            this.Controls.Add(this.bHide);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.oGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgSelectTrentDataPoint";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgSelectTrentDataPoint";
            this.Load += new System.EventHandler(this.DlgSelectTrentDataPoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Button OK_Button;
        internal Button Cancel_Button;
        internal DataGridView oGrid;
        internal CheckBox bHide;
        internal TextBox tPointName;
        private Label label1;
        private DataGridViewCheckBoxColumn Selected;
        private DataGridViewTextBoxColumn TrendLogID;
        private DataGridViewTextBoxColumn TrendLogType;
        private DataGridViewTextBoxColumn TrendLogName;
    }
}