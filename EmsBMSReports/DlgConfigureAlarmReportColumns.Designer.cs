using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace EmsBMSReports
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class DlgConfigureAlarmReportColumns : Form
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
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            oGrid = new DataGridView();
            oGrid.DataError += new DataGridViewDataErrorEventHandler(oGrid_DataError);
            bMoveUp = new Button();
            bMoveUp.Click += new EventHandler(bMoveUp_Click);
            bMoveDown = new Button();
            bMoveDown.Click += new EventHandler(bMoveDown_Click);
            bUpdate = new Button();
            bUpdate.Click += new EventHandler(bUpdate_Click);
            bCancel = new Button();
            colID = new DataGridViewTextBoxColumn();
            ColNameInDB = new DataGridViewTextBoxColumn();
            ColType = new DataGridViewTextBoxColumn();
            ColWidth = new DataGridViewTextBoxColumn();
            ColFormat = new DataGridViewTextBoxColumn();
            ColJust = new DataGridViewComboBoxColumn();
            COlHeader2 = new DataGridViewTextBoxColumn();
            EnumID = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)oGrid).BeginInit();
            SuspendLayout();
            // 
            // oGrid
            // 
            oGrid.AllowUserToAddRows = false;
            oGrid.AllowUserToDeleteRows = false;
            oGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oGrid.Columns.AddRange(new DataGridViewColumn[] { colID, ColNameInDB, ColType, ColWidth, ColFormat, ColJust, COlHeader2, EnumID });
            oGrid.Location = new Point(12, 12);
            oGrid.Name = "oGrid";
            oGrid.Size = new Size(858, 455);
            oGrid.TabIndex = 2;
            // 
            // bMoveUp
            // 
            bMoveUp.Location = new Point(145, 473);
            bMoveUp.Name = "bMoveUp";
            bMoveUp.Size = new Size(175, 33);
            bMoveUp.TabIndex = 7;
            bMoveUp.Text = "Move Row Up";
            bMoveUp.UseVisualStyleBackColor = true;
            // 
            // bMoveDown
            // 
            bMoveDown.Location = new Point(437, 473);
            bMoveDown.Name = "bMoveDown";
            bMoveDown.Size = new Size(175, 33);
            bMoveDown.TabIndex = 8;
            bMoveDown.Text = "Move Row Down";
            bMoveDown.UseVisualStyleBackColor = true;
            // 
            // bUpdate
            // 
            bUpdate.Location = new Point(892, 33);
            bUpdate.Name = "bUpdate";
            bUpdate.Size = new Size(148, 33);
            bUpdate.TabIndex = 8;
            bUpdate.Text = "Update";
            bUpdate.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            bCancel.DialogResult = DialogResult.Cancel;
            bCancel.Location = new Point(892, 115);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(148, 33);
            bCancel.TabIndex = 8;
            bCancel.Text = "Cancel";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // colID
            // 
            colID.HeaderText = "colid";
            colID.Name = "colID";
            colID.Visible = false;
            // 
            // ColNameInDB
            // 
            ColNameInDB.HeaderText = "DB Col Name";
            ColNameInDB.Name = "ColNameInDB";
            ColNameInDB.ReadOnly = true;
            ColNameInDB.Resizable = DataGridViewTriState.False;
            // 
            // ColType
            // 
            DataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            ColType.DefaultCellStyle = DataGridViewCellStyle1;
            ColType.HeaderText = "Type";
            ColType.Name = "ColType";
            ColType.ReadOnly = true;
            ColType.Resizable = DataGridViewTriState.True;
            ColType.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColWidth
            // 
            ColWidth.HeaderText = "Col Width";
            ColWidth.Name = "ColWidth";
            ColWidth.Width = 50;
            // 
            // ColFormat
            // 
            ColFormat.HeaderText = "Column Format";
            ColFormat.Name = "ColFormat";
            ColFormat.Width = 150;
            // 
            // ColJust
            // 
            ColJust.HeaderText = "Justification";
            ColJust.Items.AddRange(new object[] { "Center", "Left", "Right" });
            ColJust.Name = "ColJust";
            // 
            // COlHeader2
            // 
            COlHeader2.HeaderText = "Column Title";
            COlHeader2.Name = "COlHeader2";
            COlHeader2.Width = 230;
            // 
            // EnumID
            // 
            EnumID.HeaderText = "Visible";
            EnumID.Name = "EnumID";
            EnumID.Resizable = DataGridViewTriState.True;
            EnumID.SortMode = DataGridViewColumnSortMode.Automatic;
            EnumID.Width = 70;
            // 
            // DlgConfigureAlarmReportColumns
            // 
            AutoScaleDimensions = new SizeF(8.0f, 16.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 518);
            Controls.Add(bCancel);
            Controls.Add(bUpdate);
            Controls.Add(bMoveDown);
            Controls.Add(bMoveUp);
            Controls.Add(oGrid);
            Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DlgConfigureAlarmReportColumns";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "DlgConfigureAlarmReportColumns";
            ((System.ComponentModel.ISupportInitialize)oGrid).EndInit();
            Load += new EventHandler(DlgConfigureAlarmReportColumns_Load);
            ResumeLayout(false);

        }

        internal DataGridView oGrid;
        internal Button bMoveUp;
        internal Button bMoveDown;
        internal Button bUpdate;
        internal Button bCancel;
        internal DataGridViewTextBoxColumn colID;
        internal DataGridViewTextBoxColumn ColNameInDB;
        internal DataGridViewTextBoxColumn ColType;
        internal DataGridViewTextBoxColumn ColWidth;
        internal DataGridViewTextBoxColumn ColFormat;
        internal DataGridViewComboBoxColumn ColJust;
        internal DataGridViewTextBoxColumn COlHeader2;
        internal DataGridViewCheckBoxColumn EnumID;
    }
}